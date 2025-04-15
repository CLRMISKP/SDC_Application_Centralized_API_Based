using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using SDC_Application.Classess;
using System.Text.RegularExpressions;


namespace SDC_Application.AL
{
    public partial class frmDowraSchedule : Form
    {
        DL.Database objDB=new DL.Database();
        public frmDowraSchedule()
        {
            InitializeComponent();
        }

        private void picBoxSave_Click(object sender, EventArgs e)
        {
            DateTime firstDayOfMonth = GetFirstDayOfMonth(DateTime.Now); ;
            // Check if an item is selected in the ComboBox
            if (cmbMonths.SelectedItem != null)
            {
                // Get the selected MonthItem
                MonthItem selectedMonth = (MonthItem)cmbMonths.SelectedItem;
                firstDayOfMonth = selectedMonth.FirstDayOfMonth;
            }

            InsertOrUpdateDowaraStatus(Tehsilid, this.getChkWeekDaysToCSV(), this.GetSelectedDates(), firstDayOfMonth);
            //labelSavingMessage.Text = "Record Saved";
            //labelSavingMessage.ForeColor = Color.Orange; // Light Orange color
            labelSavingMessage.Visible = true;
            labelSavingMessage.BackColor = Color.Transparent;

            // Start the timer
            timerSavingMessage.Start();
        }



        string dsvr = "";//SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
        string db = "";//SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
        string password = "";//SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
        string connectionString ="";// "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";


        public class Sp_Arg_and_Meta_Info
        {
            public string ProcName { get; set; }
            public Dictionary<string, string> MetadataContent { get; set; }
            public Dictionary<string, string> Arguments { get; set; }

            public Sp_Arg_and_Meta_Info(string procName, Dictionary<string, string> metadataContent, Dictionary<string, string> arguments)
            {
                ProcName = procName;
                MetadataContent = metadataContent;
                Arguments = arguments;
            }

            public Sp_Arg_and_Meta_Info(string procName)
            {
                ProcName = procName;
                MetadataContent = new Dictionary<string, string>();
                Arguments = new Dictionary<string, string>();
            }

            public Sp_Arg_and_Meta_Info()
            {
                ProcName = "";
                MetadataContent = new Dictionary<string, string>();
                Arguments = new Dictionary<string, string>();
            }

            public override string ToString()
            {
                if (MetadataContent != null && MetadataContent.ContainsKey("Title") && !string.IsNullOrWhiteSpace(MetadataContent["Title"]))
                {
                    return MetadataContent["Title"];
                }

                return ProcName;
            }
        }





        public int Tehsilid = 0;
        public class MonthItem
        {
            public string MonthName { get; set; }
            public DateTime FirstDayOfMonth { get; set; }
        }

        MonthInfo monthInfo = new MonthInfo(DateTime.Now);
        class MonthInfo
        {
            public MonthInfo()
            {
                offset = currentDate = DaysInMonth;
            }
            public int offset; // i.e week of 1st of that month 0 bein sun
            public int currentDate ;
            public int DaysInMonth;

            public MonthInfo(DateTime dt)
            {
                offset = (int)dt.DayOfWeek; // DayOfWeek returns 0 for Sunday, 1 for Monday, and so on.

                currentDate = dt.Day;
                DaysInMonth = DateTime.DaysInMonth(dt.Year, dt.Month);
            }
        }
        public  DateTime GetFirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }


        System.Windows.Forms.CheckBox[] chkWeekDays = new CheckBox[5];
        


        // FORM_Load
        private void frmDowraSchedule_Load(object sender, EventArgs e)
        {

              //dsvr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
              //db = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
              //password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
              //connectionString = "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";


            chkWeekDays = new CheckBox[]
            {
                checkBox1,
                checkBox2,
                checkBox3,
                checkBox4,
                checkBox5
            };
            
            int CurrentMonth = DateTime.Now.Month;
            for (int month = CurrentMonth; month <= 12; month++)
            {
                DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, month, 1);
                string monthNameAbbreviated = firstDayOfMonth.ToString("MMM");

                cmbMonths.Items.Add(new MonthItem
                {
                    MonthName = monthNameAbbreviated,
                    FirstDayOfMonth = firstDayOfMonth
                });
            }

            // Set up ComboBox display and value members
            cmbMonths.DisplayMember = "MonthName";
            cmbMonths.ValueMember = "FirstDayOfMonth";

            if (cmbMonths.Items.Count > 0)
            {
                cmbMonths.SelectedIndex = 0;
            }
            
            cmbMonths.SelectedIndexChanged += ComboBox_SelectedIndexChanged;




            if (UsersManagments._Tehsilid == 0) UsersManagments._Tehsilid = 11;// for testing
            Tehsilid = UsersManagments._Tehsilid;

            ComboBox_SelectedIndexChanged(null, null);


        }


        public class DowraStatus
        {
            public int TehsilId { get; set; }
            public string WeekDays { get; set; }
            public string DaysOfMonth { get; set; }
            public DateTime Dated { get; set; }
        }


        private DowraStatus getDowraStatus()
        {
            DateTime firstDayOfMonth = DateTime.Now;
            if (cmbMonths.SelectedItem != null)
            {
                // Get the selected MonthItem
                MonthItem selectedMonth = (MonthItem)cmbMonths.SelectedItem;
                firstDayOfMonth = selectedMonth.FirstDayOfMonth;
            }     

            return getDowraStatus(firstDayOfMonth);
        }


        private DowraStatus getDowraStatus(DateTime dated)
        {

            DowraStatus dowraStatus = null;

            //int tehsilId = UsersManagments._Tehsilid;

            // Connection string setup
            try
            {
                DataTable dt = new DataTable();
                dt = objDB.filldatatable_from_storedProcedure("getDowraStatus " + Tehsilid + ",'" + dated + "'," + UsersManagments.SubSdcId.ToString());
                if (dt != null)
                {
                    dowraStatus = new DowraStatus
                    {
                        TehsilId = int.Parse(dt.Rows[0]["Tehsilid"].ToString()),
                        WeekDays = dt.Rows[0]["WeekDays"].ToString(),
                        DaysOfMonth = dt.Rows[0]["DaysOfMonth"].ToString(),
                        Dated = DateTime.Parse(dt.Rows[0]["Dated"].ToString())
                    };
                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        connection.Open();

            //        // Create a SqlCommand instance for the stored procedure
            //        SqlCommand command = new SqlCommand("getDowraStatus", connection);
            //        command.CommandType = CommandType.StoredProcedure;
            //        command.CommandTimeout = 5;

            //        // Add parameters to the stored procedure
            //        command.Parameters.AddWithValue("@TehsilId", Tehsilid);
            //        command.Parameters.AddWithValue("@Dated", dated);
            //        command.Parameters.AddWithValue("@SubSdcId", UsersManagments.SubSdcId);

            //        // Execute the stored procedure and retrieve the result set
            //        SqlDataReader reader = command.ExecuteReader();
                    
            //        if (reader.Read())
            //        {
            //            dowraStatus = new DowraStatus
            //            {
            //                TehsilId = reader.GetInt32(reader.GetOrdinal("Tehsilid")),
            //                WeekDays = reader.GetString(reader.GetOrdinal("WeekDays")),
            //                DaysOfMonth = reader.GetString(reader.GetOrdinal("DaysOfMonth")),
            //                Dated = reader.GetDateTime(reader.GetOrdinal("Dated"))
            //            };

            //            // Use the retrieved values as needed
            //        }

            //        reader.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            return dowraStatus;
        }


        private void InsertOrUpdateDowaraStatus(int tehsilId, string weekDays, string daysOfMonth, DateTime dated)
        {
            try
            {
            DataTable dt= objDB.filldatatable_from_storedProcedure("insertOrUpdateDowraStatus " + tehsilId + ",'" + weekDays + "','" + daysOfMonth + "','" + dated + "', NULL," + UsersManagments.SubSdcId.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    try
            //    {
            //        connection.Open();

            //        // Create a SqlCommand instance for the stored procedure
            //        SqlCommand command = new SqlCommand("insertOrUpdateDowraStatus", connection);
            //        command.CommandType = CommandType.StoredProcedure;
            //        command.CommandTimeout = 5;

            //        // Add parameters to the stored procedure
            //        command.Parameters.AddWithValue("@TehsilId", tehsilId);
            //        command.Parameters.AddWithValue("@WeekDays", weekDays);
            //        command.Parameters.AddWithValue("@DaysOfMonth", daysOfMonth);
            //        command.Parameters.AddWithValue("@Dated", dated);
            //        command.Parameters.Add("@Err_Msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
            //        command.Parameters.AddWithValue("@SubSdcId", UsersManagments.SubSdcId);

            //        // Execute the stored procedure
            //        command.ExecuteNonQuery();

            //        // Retrieve the output parameter value (if needed)
            //        string errMessage = command.Parameters["@Err_Msg"].Value.ToString();

            //        // Handle the output parameter value as needed
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private string getChkWeekDaysToCSV()
        {
             
            StringBuilder csvBuilder = new StringBuilder();

            for (int i = 0; i < chkWeekDays.Length; i++)
            {
                if (chkWeekDays[i].Checked)
                {
                    csvBuilder.Append(i);
                    csvBuilder.Append(",");
                }
            }

            if (csvBuilder.Length > 0)
            {
                // Remove the trailing comma
                csvBuilder.Length -= 1;
            }

            return csvBuilder.ToString();
        }

        private void setChkWeekDaysFromCSV(string csv)
        {

            // First, uncheck all checkboxes
            foreach (CheckBox chk in chkWeekDays)
            {
                chk.Checked = false;
            }
            string[] indexes = csv.Split(',');

            foreach (string indexStr in indexes)
            {
                int index;
                if (int.TryParse(indexStr, out index) && index >= 0 && index < chkWeekDays.Length)
                {
                    chkWeekDays[index].Checked = true;
                }
            }
        }


        private void chkWeekDays_CheckedChanged(object sender, EventArgs e)
        {
               // int Tehsilid= UsersManagments._Tehsilid;
                //if (Tehsilid == -1 || Tehsilid == 0) return;


            /*
            string dsvr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
            string db = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
            string password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
            string connectionString = "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                bool bMonday = this.checkBox1.Checked;
                bool bTuesday = this.checkBox2.Checked;
                bool bWednesday = this.checkBox3.Checked;
                bool bThursday = this.checkBox4.Checked;
                bool bFriday = this.checkBox5.Checked;

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("setDowaraWeekDays", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Monday",  bMonday));
                    command.Parameters.Add(new SqlParameter("@Tuesday",  bTuesday));
                    command.Parameters.Add(new SqlParameter("@Wednesday", bWednesday ));
                    command.Parameters.Add(new SqlParameter("@Thursday",  bThursday));
                    command.Parameters.Add(new SqlParameter("@Friday", bFriday));
                    command.Parameters.Add(new SqlParameter("@Tehsilid", Tehsilid));
                    command.CommandTimeout = 5;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    this.dataGridView1.DataSource = ds.Tables[0];



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            */


            String Dates = this.GetSelectedDates();
            this.PopulateCalendarGrid(Dates, this.monthInfo);

        }



        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime firstDayOfMonth = GetFirstDayOfMonth(DateTime.Now); ;
            // Check if an item is selected in the ComboBox
            if (cmbMonths.SelectedItem != null)
            {
                // Get the selected MonthItem
                MonthItem selectedMonth = (MonthItem)cmbMonths.SelectedItem;
                firstDayOfMonth = selectedMonth.FirstDayOfMonth;
            }            

                // Create a new MonthInfo instance using the first day of the selected month
                monthInfo = new MonthInfo(firstDayOfMonth);

                // Call methods to initialize and populate the calendar grid
                InitializeCalendarGrid(monthInfo);

                DowraStatus status = getDowraStatus(firstDayOfMonth);
               // this.set 
                this.setChkWeekDaysFromCSV(status.WeekDays);
                PopulateCalendarGrid(status.DaysOfMonth, monthInfo);
        }


        string datesSelected = "";
        private void InitializeCalendarGrid(MonthInfo monthInfo)
        {
            calendarPanel.Controls.Clear();
            int offset = monthInfo.offset;
            int currentDate = monthInfo.currentDate;
            int NumberInMonth = monthInfo.DaysInMonth;
            //offset = 7;
            offset = offset % 7;// start of month may be sat sun mon tue wed etc. or any day of week 
            int x = 0; // initial position
            int y = 0; // adjust this to account for the week day row
            int width = 50; // width of each PictureBox
            int height = 30; // height of each PictureBox
            int GapBetween = 0;
            // First, let's add the weekdays row
            string[] weekDays = new string[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            for (int i = 0; i < 7; i++)
            {
                PictureBox weekDayPicBox = new PictureBox();
                Label weekDayLbl = new Label();

                weekDayPicBox.Name = "weekDayPicBox" + i.ToString();
                weekDayPicBox.Width = width;
                weekDayPicBox.Height = height;
                weekDayPicBox.BorderStyle = BorderStyle.None;
                weekDayPicBox.BackColor = Color.LightGray;
                weekDayPicBox.Location = new Point(x, y);
                

                weekDayLbl.Name = "weekDayLbl" + i.ToString();
                weekDayLbl.Text = weekDays[i];
                weekDayLbl.Font = new Font(weekDayLbl.Font, FontStyle.Bold);
                weekDayLbl.ForeColor = (i == 0 || i == 6) ? Color.Red : Color.Black;
                weekDayLbl.TextAlign = ContentAlignment.MiddleCenter;
                weekDayLbl.Dock = DockStyle.Fill;

                if (i != 0 && i != 6) // Sun and Sat not selectable 
                {
                    weekDayPicBox.Click += new EventHandler(WeekDayPictureBox_Click);
                    weekDayLbl.Click += new EventHandler(WeekDayPictureBox_Click);
                }
                weekDayPicBox.Controls.Add(weekDayLbl);
                calendarPanel.Controls.Add(weekDayPicBox);

                x += width + GapBetween;
            }

             width = 50; // width of each PictureBox
             height = 30; // height of each PictureBox
            // Now, let's add the 6 rows of 7 days each
            x = 0;
            x += ((width + GapBetween) * offset);
            y += height ; // starting y-position for the days

            int picBoxCount = NumberInMonth;// calendarPanel.Controls.OfType<PictureBox>().Count(pb => pb.Name.StartsWith("picBox"));
            for (int i = 1; i <= picBoxCount; i++)
            {
                PictureBox picBox = new PictureBox();
                Label lbl = new Label();

                picBox.Name = "picBox" + i.ToString();
                picBox.Width = width;
                picBox.Height = height;
                picBox.BorderStyle = BorderStyle.None;
                picBox.Location = new Point(x, y);
                picBox.Tag = new pic_box_status { selected = false };

                lbl.Name = "lbl" + i.ToString();
                lbl.ForeColor = Color.White;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Dock = DockStyle.Fill;

                picBox.Controls.Add(lbl);


                // Gray scale or distinguish Sat and Sunday
                if (!(((i + offset + 0) % 7 == 0) || ((i + offset + 6) % 7 == 0)))// Saturday
                {
                    picBox.Click += PictureBox_Click;
                    lbl.Click += PictureBox_Click;
                }
                
                calendarPanel.Controls.Add(picBox);

                x += width + GapBetween;

                if ((i + offset) % 7 == 0)
                {
                    x = 0;
                    y += height + 0;
                }
            }

            // After adding all the picture boxes and labels:
            int totalWidth = (width * 7) + (GapBetween * 6); // 7 picture boxes and 6 gaps
            int totalHeight = height * 7; // 1 row for weekdays and a maximum of 6 rows for the days of the month.

            calendarPanel.Size = new Size(totalWidth, totalHeight);

        }

        private void WeekDayPictureBox_Click(object sender, EventArgs e)
        {
            if (sender is Label) sender = ((Label)sender).Parent;
            if (sender is PictureBox )
            {
                PictureBox pictureBox = (PictureBox)sender;
                string pictureBoxName = pictureBox.Name;
                int pictureBoxNumber = int.Parse(pictureBoxName.Replace("weekDayPicBox", ""));
                // Use pictureBoxNumber as needed
                //MessageBox.Show("Clicked on PictureBox with number: " + pictureBoxNumber);
                CheckBox chk = chkWeekDays[pictureBoxNumber - 1];
                chk.Checked = !chk.Checked;
            }
        }


        private string PopulateCalendarGrid(string dates, MonthInfo monthInfo)
        {
            int offset = monthInfo.offset;
            int currentDate = monthInfo.currentDate;
            int NumberInMonth = monthInfo.DaysInMonth;

            List<int> dateList = new List<int>();
            try
            {
                dateList = dates.Split(',').Select(s => int.Parse(s.Trim())).ToList();
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Data=" + dates + "->" + ex.Message);
            }
            

            int picBoxCount = calendarPanel.Controls.OfType<PictureBox>().Count(pb => pb.Name.StartsWith("picBox"));
            for (int i = 1; i <= picBoxCount; i++)
            {
                PictureBox picBox = calendarPanel.Controls["picBox" + i.ToString()] as PictureBox;
                Label lbl = picBox.Controls["lbl" + i.ToString()] as Label;

                pic_box_status status = null;
                lbl.Text = i.ToString();

                if(picBox.Tag is pic_box_status)
                {
                    status = (pic_box_status)picBox.Tag;
                    status.selected = dateList.Contains(i);
                }
                else
                {
                    status = new pic_box_status() { selected = dateList.Contains(i) };
                    picBox.Tag = status;
                }

                picBox.BackColor = dateList.Contains(i) ? Color.Green : Color.Black;
                lbl.ForeColor = Color.White;

                status.selected = dateList.Contains(i); 
                
                // SATURDAY => selected = false;
                if ((i + offset+0) % 7 == 0) // Saturday
                {
                    picBox.BackColor = Color.LightGray;
                    lbl.ForeColor = Color.Black;
                    status.selected = false;
                }
                // SUNDAY => selected = false;
                if((i + offset + 6) % 7 == 0) 
                {
                    picBox.BackColor = Color.LightGray;
                    lbl.ForeColor = Color.Black;
                    status.selected = false;
                }

                // NOW SELECTION SHOW OF SELECTED WEEK DAYS ---- START
                if (
                    this.chkWeekDays[0].Checked && ((i + offset + 5) % 7 == 0)// 5 -- Monday
                    || this.chkWeekDays[1].Checked && ((i + offset + 4) % 7 == 0)// 5 -- Tuesday
                    || this.chkWeekDays[2].Checked && ((i + offset + 3) % 7 == 0)// 5 -- Wed
                    || this.chkWeekDays[3].Checked && ((i + offset + 2) % 7 == 0)// 5 -- Thrusday
                    || this.chkWeekDays[4].Checked && ((i + offset + 1) % 7 == 0)// 5 -- Friday                    
                   ) 
                {
                    picBox.BackColor = Color.Green;
                }
                // NOW SELECTION SHOW OF SELECTED WEEK DAYS ---- END

            }
            return GetSelectedDates();
        }




        public string GetSelectedDates()
        {
            List<string> selectedDates = new List<string>();

            foreach (PictureBox picBox in calendarPanel.Controls.OfType<PictureBox>()) // Ensure only PictureBox controls are looped through
            {
                if (picBox.Name.StartsWith("picBox"))
                {
                    pic_box_status status = (pic_box_status)picBox.Tag;
                    if (status.selected)
                    {
                        selectedDates.Add(picBox.Name.Replace("picBox", ""));
                    }
                }
            }

            return string.Join(",", selectedDates);
        }






        private List<int> selectedDates = new List<int>();
        public class pic_box_status
        {
            public pic_box_status() { selected = false; }
            public bool selected;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox;

            if (sender is Label)
            {
                clickedPictureBox = (PictureBox)((Label)sender).Parent;
            }
            else
            {
                clickedPictureBox = sender as PictureBox;
            }

            Label associatedLabel = clickedPictureBox.Controls[0] as Label;

            pic_box_status clickedPictureBoxTag = (pic_box_status)clickedPictureBox.Tag;
            clickedPictureBoxTag.selected = !clickedPictureBoxTag.selected;
            clickedPictureBox.Tag = clickedPictureBoxTag; // Update the Tag property with new status

            // Generating a comma separated string of selected dates
            string selectedDates = string.Join(",",
                                               calendarPanel.Controls.OfType<PictureBox>()
                                                              .Where(pb => pb.Name.StartsWith("picBox") && ((pic_box_status)pb.Tag).selected)
                                                              .Select(pb => pb.Name.Replace("picBox", ""))
                                             );


            PopulateCalendarGrid(selectedDates,this.monthInfo);
        }


        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            // Right shadow
            e.Graphics.DrawLine(Pens.Gray, new Point(pb.Width - 1, 0), new Point(pb.Width - 1, pb.Height));

            // Bottom shadow
            e.Graphics.DrawLine(Pens.Gray, new Point(0, pb.Height - 1), new Point(pb.Width, pb.Height - 1));
        }



        private void timerSavingMessage_Tick(object sender, EventArgs e)
        {
            // Hide the message and stop the timer
            labelSavingMessage.Visible = false;
            timerSavingMessage.Stop();
        }
        /*
        private void picBoxSave_Click(object sender, EventArgs e)
        {

            DateTime firstDayOfMonth = GetFirstDayOfMonth(DateTime.Now); ;
            // Check if an item is selected in the ComboBox
            if (cmbMonths.SelectedItem != null)
            {
                // Get the selected MonthItem
                MonthItem selectedMonth = (MonthItem)cmbMonths.SelectedItem;
                firstDayOfMonth = selectedMonth.FirstDayOfMonth;
            }

            InsertOrUpdateDowaraStatus(Tehsilid, this.getChkWeekDaysToCSV(), this.GetSelectedDates(), firstDayOfMonth);
            //labelSavingMessage.Text = "Record Saved";
            //labelSavingMessage.ForeColor = Color.Orange; // Light Orange color
            labelSavingMessage.Visible = true;
            labelSavingMessage.BackColor = Color.Transparent;

            // Start the timer
            timerSavingMessage.Start();
        }
        */
        private void timerSavingMessage_Tick_1(object sender, EventArgs e)
        {
            // Hide the message and stop the timer
            labelSavingMessage.Visible = false;
            timerSavingMessage.Stop();        
        }


    }
}
