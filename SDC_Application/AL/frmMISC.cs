using System;
using System.IO;
using System.Diagnostics;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SDC_Application.Classess;
using System.Text.RegularExpressions;


namespace SDC_Application.AL
{
    public partial class frmMISC : Form
    {


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

        public frmMISC()
        {
            InitializeComponent();
        }

        System.Windows.Forms.CheckBox[] chkWeekDays = new CheckBox[5];
        


        // FORM_Load
        private void frmMISC_Load(object sender, EventArgs e)
        {

              dsvr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
              db = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
              password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
              connectionString = "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";

              PopulateReportsComboBox(getReportInfoFromProcedures());

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


            /*
            // Connection string setup
            string dsvr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
            string db = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
            string password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
            string connectionString = "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Create a SqlCommand instance for the stored procedure
                    SqlCommand command = new SqlCommand("getDowraStatus", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 5;

                    // Add parameters to the stored procedure
                    command.Parameters.AddWithValue("@TehsilId", Tehsilid);

                    // Add output parameters for @Dated and @Err_Msg
                    command.Parameters.Add("@Dated", SqlDbType.DateTime).Value = DBNull.Value; // You might need to adjust this based on your logic
                    command.Parameters.Add("@Err_Msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    // Retrieve the output parameter values (if needed)
                    string errMessage = command.Parameters["@Err_Msg"].Value.ToString();

                    // Update checkbox states based on the retrieved data
                    // Implement your logic here to get the data from the result and populate checkboxes accordingly
                    // Note: Since the procedure's logic is not known, you'll need to adjust this part
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            */


            ComboBox_SelectedIndexChanged(null, null);

            //this.calendarPanel
            label2.Top = this.calendarPanel.Top + this.calendarPanel.Height + 10;
            this.cmbReports.Top = this.calendarPanel.Top+this.calendarPanel.Height+10;

            this.panelParameters.Top = this.cmbReports.Top + this.cmbReports.Height;

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

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Create a SqlCommand instance for the stored procedure
                    SqlCommand command = new SqlCommand("getDowraStatus", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 5;

                    // Add parameters to the stored procedure
                    command.Parameters.AddWithValue("@TehsilId", Tehsilid);
                    command.Parameters.AddWithValue("@Dated", dated);

                    // Execute the stored procedure and retrieve the result set
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        dowraStatus = new DowraStatus
                        {
                            TehsilId = reader.GetInt32(reader.GetOrdinal("Tehsilid")),
                            WeekDays = reader.GetString(reader.GetOrdinal("WeekDays")),
                            DaysOfMonth = reader.GetString(reader.GetOrdinal("DaysOfMonth")),
                            Dated = reader.GetDateTime(reader.GetOrdinal("Dated"))
                        };

                        // Use the retrieved values as needed
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dowraStatus;
        }


        private void InsertOrUpdateDowaraStatus(int tehsilId, string weekDays, string daysOfMonth, DateTime dated)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Create a SqlCommand instance for the stored procedure
                    SqlCommand command = new SqlCommand("insertOrUpdateDowraStatus", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 5;

                    // Add parameters to the stored procedure
                    command.Parameters.AddWithValue("@TehsilId", tehsilId);
                    command.Parameters.AddWithValue("@WeekDays", weekDays);
                    command.Parameters.AddWithValue("@DaysOfMonth", daysOfMonth);
                    command.Parameters.AddWithValue("@Dated", dated);
                    command.Parameters.Add("@Err_Msg", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;

                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    // Retrieve the output parameter value (if needed)
                    string errMessage = command.Parameters["@Err_Msg"].Value.ToString();

                    // Handle the output parameter value as needed
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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


        //--------------------------------------------------------------------------------  REPORT PORTION --------------------------------------------------------------------------------------------------------------------------------------
        
        void PopulateReportsComboBox(List<Sp_Arg_and_Meta_Info> reportInfo)
        {
            foreach (Sp_Arg_and_Meta_Info report in reportInfo)
            {
                cmbReports.Items.Add(report);
            }
        }

        private List<Sp_Arg_and_Meta_Info> getReportInfoFromProcedures(string procNameFilter = null)
        {
            List<Sp_Arg_and_Meta_Info> ret = new List<Sp_Arg_and_Meta_Info>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("getReportsMetaData", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    // Add the @ProcName parameter to filter the reports if a value is provided
                    if (!string.IsNullOrEmpty(procNameFilter))
                    {
                        cmd.Parameters.AddWithValue("@ProcName", procNameFilter);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Sp_Arg_and_Meta_Info report = new Sp_Arg_and_Meta_Info();
                            report.ProcName = reader["ProcName"].ToString();

                            // Parse MetadataContent into Dictionary
                            report.MetadataContent = ParseKeyValuePairs(reader["MetadataContent"].ToString());

                            // Parse Arguments into Dictionary
                            report.Arguments = ParseKeyValuePairs(reader["Arguments"].ToString(), true);

                            ret.Add(report);
                        }
                    }
                }
            }
            return ret;
        }



private Dictionary<string, string> ParseKeyValuePairs(string content, bool isArguments = false)
{
    Dictionary<string, string> result = new Dictionary<string, string>();

    // Normalize content: Convert multiple spaces or tabs to a single space
    if (isArguments) content = System.Text.RegularExpressions.Regex.Replace(content, @"\s+", " ");

    string[] items;

    if (isArguments)
    {
        // Split arguments based on the comma for further processing
        items = content.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    }
    else
    {
        items = content.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
    }

    foreach (string item in items)
    {

        string[] parts = null;
        if (isArguments)
        {
            // For arguments, we expect a space to separate the key and value
            parts = item.Split(new char[] { ' ' }, 2);
            if (parts.Length == 2)
            {
                result[parts[0].Trim()] = parts[1].Trim();
            }
        }
        else
        {
            parts = item.Split('=');
            if (parts.Length >1 )
            {
                string key = parts[0].Trim();                
                string value = string.Join("=", parts.Skip(1)).Trim();
                value = value.Split(new[] { "--" }, StringSplitOptions.None)[0].Trim();
                result[key] = value;
            }
        }
    }

    return result;
}

private void handleError(string errMsg)
{
    handleError(errMsg, this.panelParameters);
}
private void handleError(string errMsg, Panel panelOfControls)
{
    // Split the errMsg using the '|' delimiter
    string[] parts = errMsg.Split('|');

    if (parts.Length >= 3)
    {
        string errorType = parts[0].Trim();
        string title = parts[1].Trim();
        string message = parts[2].Trim();

        // Display the message in a MessageBox
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        // If the error type is "CTRL_NOT_VALID"
        if (errorType == "CTRL_NOT_VALID")
        {
            if (parts.Length >= 3)
            {
                string controlName = parts[1].Trim();

                // Find the control with the specified name on the panel
                Control[] foundControls = panelOfControls.Controls.Find(controlName, true);

                if (foundControls.Length > 0)
                {
                    Control targetControl = foundControls[0];
                    targetControl.Focus();
                    // Set focus to the control
                    if (targetControl is TextBox )
                    {
                        TextBox textBox = (TextBox)targetControl;                        
                        textBox.SelectAll(); // Select the text in the TextBox if it's a TextBox
                    }


                }
            }
        }
    }
}

        class DataSetContainer
        {
            public DataSet ds;
            public string Err_Msg;
            public int Return;

            public DataSetContainer()
            {
                ds = new DataSet();
                Err_Msg = string.Empty;
                Return = 100;
            }
        }

        private DataSetContainer getDataSet(Sp_Arg_and_Meta_Info selectedReport)
        {
            
            DataSetContainer dc = new DataSetContainer();
            if (selectedReport == null) return dc;

                string procName = selectedReport.ProcName;
                Dictionary<string, string> metaData = selectedReport.MetadataContent;
                Dictionary<string, string> arguments = selectedReport.Arguments;

                string errMsg = string.Empty;
                int returnValue;

                using (SqlConnection conn = new SqlConnection(connectionString)) //replace with your connection string
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Create output parameter for "@Err_Msg"
                        SqlParameter errParam = new SqlParameter("@Err_Msg", SqlDbType.VarChar, 100)
                        {
                            Direction = ParameterDirection.Output,
                            Value = DBNull.Value
                        };
                        cmd.Parameters.Add(errParam);

                        // Create return value parameter
                        SqlParameter returnParam = new SqlParameter("@Return", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        cmd.Parameters.Add(returnParam);

                        // Populate other parameters from arguments dictionary
                        foreach (var arg in arguments)
                        {
                            if (!arg.Value.ToLower().Contains("output")) // Since we've already handled "@Err_Msg"
                            {
                                var parameterControl = panelParameters.Controls.Find(arg.Key.Replace("@", ""), false).FirstOrDefault();
                                if (parameterControl != null)
                                {
                                    var textBox = parameterControl as TextBox;
                                    if (textBox != null)
                                    {
                                        cmd.Parameters.AddWithValue(arg.Key, textBox.Text);
                                    }
                                    else
                                    {
                                        var comboBox = parameterControl as ComboBox;
                                        if (comboBox != null)
                                        {
                                            if (comboBox.SelectedItem != null)
                                            {
                                                cmd.Parameters.AddWithValue(arg.Key, comboBox.SelectedItem.ToString());
                                            }
                                            else
                                            {
                                                // Handle case where no item is selected in the ComboBox
                                                cmd.Parameters.AddWithValue(arg.Key, DBNull.Value);
                                            }
                                        }
                                        else
                                        {
                                            var dateTimePicker = parameterControl as DateTimePicker;
                                            if (dateTimePicker != null)
                                            {
                                                cmd.Parameters.AddWithValue(arg.Key, dateTimePicker.Value);
                                            }
                                            // You can continue to add more control types if needed...
                                        }
                                    }
                                }
                            }
                        }



                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        // Retrieve output parameter and return value post execution
                        errMsg = errParam.Value != null ? errParam.Value.ToString() : null;
                        returnValue = (int)returnParam.Value;
                        dc.ds = ds;
                        dc.Err_Msg = errMsg;
                        dc.Return = returnValue;


                        // Now ds contains the result. You can bind it to a control, process it, etc.
                        // For example: dataGridView1.DataSource = ds.Tables[0];
                    }
                }

                // Now, you have errMsg and returnValue to handle accordingly.
                if (!string.IsNullOrEmpty(errMsg))
                {
                    // MessageBox.Show(errMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Handle returnValue as per your logic.
            


            return dc;
        }

private void btnShowReport_Click(object sender, EventArgs e)
{
    Sp_Arg_and_Meta_Info selectedReport = cmbReports.SelectedItem as Sp_Arg_and_Meta_Info;
    if (selectedReport != null)
    {
        DataSetContainer dc= getDataSet(selectedReport);
        if (dc.Return == 100)
            HandleOutputFormat(selectedReport.MetadataContent, selectedReport.Arguments, dc.ds);
        else
            handleError(dc.Err_Msg);
    }
}

private void SaveAndOpenCSV(DataSet dataSet)
{
    DataTable data = dataSet.Tables[0];

    // Get the user-specific temporary folder
    string tempFolderPath = Path.GetTempPath();

    // Create a unique CSV file name
    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
    string csvFileName = "output_" + timestamp + ".csv";

    // Combine the temporary folder and file name to create the full output path
    string csvFilePath = Path.Combine(tempFolderPath, csvFileName);

    // Create a StringBuilder to build the CSV content
    StringBuilder csvContent = new StringBuilder();

    // Build the CSV header row
    csvContent.AppendLine(string.Join(",", data.Columns.Cast<DataColumn>().Select(col => "\"" + col.ColumnName + "\"")));

    // Build the CSV data rows
    foreach (DataRow row in data.Rows)
    {
        var rowData = row.ItemArray.Select(item => "\"" + item.ToString().Replace("\"", "\"\"") + "\"");
        csvContent.AppendLine(string.Join(",", rowData));
    }

    // Save the CSV content to the specified output path with UTF-8 encoding
    File.WriteAllText(csvFilePath, csvContent.ToString(), Encoding.Unicode);

    // Open the CSV file with explorer.exe
    Process.Start("explorer.exe", csvFilePath);
}



private void SaveDataAsCsv(DataSet dataSet, string outputPath)
{
    
    DataTable data = dataSet.Tables[0];
    // Create a StringBuilder to build the CSV content
    StringBuilder csvContent = new StringBuilder();

    // Build the CSV header row
    csvContent.AppendLine(string.Join(",", data.Columns.Cast<DataColumn>().Select(col => "'" + col.ColumnName + "'")));

    // Build the CSV data rows
    foreach (DataRow row in data.Rows)
    {
        csvContent.AppendLine(string.Join(",", row.ItemArray.Select(item => "'" + item.ToString().Replace(",", "''") + "'")));
    }

    // Save the CSV content to the specified output path
    File.WriteAllText(outputPath, csvContent.ToString(),Encoding.Unicode);
}


public enum ControlType
{
    TEXT,
    DATE,
    COMBO
    
}

public class ControlCreationAndBindingInfo
{
    public ControlCreationAndBindingInfo(string controlName)
    {
        ControlName = controlName;
        ControlType = ControlType.TEXT; // Default to TextBox
        DataSource = string.Empty;
        DataSourceColumn = string.Empty;
        FilterControl = string.Empty;
        WhereClause = new List<string>();
    }

    public string ControlName { get; set; }
    public ControlType ControlType { get; set; }
    public string DataSource { get; set; }
    public string DataSourceColumn { get; set; }
    public string FilterControl { get; set; }
    public List<string> WhereClause { get; set; }
}


public  List<string> ExtractBracketValues(string s, string TokenStart)
{
    
    List<string> result = new List<string>();

    // Split the string based on '|'
    string[] tokens = s.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

    // Define the pattern to match square bracket contents
    string pattern = @"\[(.*?)\]";

    foreach (var token in tokens)
    {

        // Trim spaces and check if the token starts with "Where "
        if (token.TrimStart().StartsWith(TokenStart, StringComparison.OrdinalIgnoreCase))
        {
            // Match all values inside square brackets
            var matches = Regex.Matches(token, pattern);
            foreach (Match match in matches)
            {
                result.Add(match.Groups[1].Value);
            }
        }
    }

    return result;
}


private List<ControlCreationAndBindingInfo> getNewControlCreationInfroFromMetaData(Dictionary<string, string> metaData)
{
    List<ControlCreationAndBindingInfo> ret = new List<ControlCreationAndBindingInfo>();

    // Get all keys from metaData with starting string "mapping_report_argument_"
    // like ProcedureArgument_To_Map|Sno_of_Report_Param|Data Type it will be Date/String/Number

     var parameterKeys = metaData.Keys
        .Where(key => key.StartsWith("create_control_"))
        .Select(key => key.Substring("create_control_".Length)) // Remove the prefix
        .ToList();


    foreach (var parameterKey in parameterKeys)
    {
        string parameterName = parameterKey;
        string parameterValue = metaData["create_control_"+parameterKey];

        // Split parameterValue into its parts
        string[] parameterParts = parameterValue.Split('|');
        var v = new ControlCreationAndBindingInfo(parameterKey);

        if(parameterParts.Length>1){
            if(parameterParts[0]=="COMBO")v.ControlType = ControlType.COMBO;
            if(parameterParts[0]=="DATE")v.ControlType = ControlType.DATE;
            if(parameterParts[0]=="TEXT")v.ControlType = ControlType.TEXT;
        }

        if(parameterParts.Length>2){
            v.DataSource = parameterParts[1];
        }

        if(parameterParts.Length>3){
            v.DataSourceColumn = parameterParts[2];
        }

        if(parameterParts.Length>4){
            v.FilterControl = parameterParts[3];
        }


        v.WhereClause = ExtractBracketValues(parameterValue, "where");
        

        ret.Add(v);
    }

    return ret;
}


class ReportParameterInfoFromComments
{
    public ReportParameterInfoFromComments()
    {
        // Initialize all properties here
        ParamName = string.Empty;
        DataType = string.Empty;
        BoundingControl = null;
    }

    public string ParamName { get; set; }
    public string DataType { get; set; }
    public Control BoundingControl { get; set; }
}


private List<ReportParameterInfoFromComments> GetReportParameterInfoFromComments(Dictionary<string, string> metaData)
{
    List<ReportParameterInfoFromComments> ret = new List<ReportParameterInfoFromComments>();

    // Get all keys from metaData with starting string "mapping_report_argument_"
    // like ProcedureArgument_To_Map|Sno_of_Report_Param|Data Type it will be Date/String/Number'
    var parameterKeys = metaData.Keys
        .Where(key => key.StartsWith("mapping_report_argument_"))
        .ToList();

    // Sort the parameterKeys based on "Sno_of_Report_Param"
    parameterKeys.Sort((key1, key2) =>
    {
        int sno1 = int.Parse(metaData[key1].Split('|')[1]);
        int sno2 = int.Parse(metaData[key2].Split('|')[1]);
        return sno1.CompareTo(sno2);
    });

    foreach (var parameterKey in parameterKeys)
    {
        string parameterName = parameterKey.Replace("mapping_report_argument_", "");
        string parameterValue = metaData[parameterKey];

        // Split parameterValue into its parts
        string[] parameterParts = parameterValue.Split('|');

        ReportParameterInfoFromComments paramInfo = new ReportParameterInfoFromComments
        {
            ParamName = parameterName,
            DataType = parameterParts.Length >= 3 ? parameterParts[2].Trim() : string.Empty
        };

        // Find the control based on the first part of the parameterValue
        Control[] foundControls = panelParameters.Controls.Find(parameterParts[0], true);
        paramInfo.BoundingControl = foundControls.Length > 0 ? foundControls[0] : null;

        // Add the parameter to the list
        ret.Add(paramInfo);
    }

    return ret;
}



private void HandleOutputFormat(Dictionary<string, string> metaData, Dictionary<string, string> arguments, DataSet data)
{
   // DataTable data = dataSet.Tables[0];

    if (metaData.ContainsKey("Output_format"))
    {
        string outputFormat = metaData["Output_format"].Trim();

        if (outputFormat == "GRID") {
            dataGridView1.Visible = true;
            dataGridView1.DataSource = data.Tables[0];
        }else
        if (outputFormat == "CrystalReport")
        {
            // Check for the 'Report' key in the metadata
            if (metaData.ContainsKey("Report"))
            {
                string reportName = metaData["Report"].Trim();

                // Check if the reportName exists in resource 'Resource1.resx'
                //if (!Resource1.ResourceManager.GetString(reportName, Resource1.Culture).IsNullOrEmpty())
                if (!string.IsNullOrEmpty(Resource1.ResourceManager.GetString(reportName, Resource1.Culture))
                    ||
                    File.Exists(Path.Combine(Environment.CurrentDirectory, reportName))
                    )
                {
                    try
                    {

                        List<ReportParameterInfoFromComments> ret = GetReportParameterInfoFromComments(metaData);
                        Dictionary<string, string> parameterDictionary = new Dictionary<string, string>();
                        foreach (var paramInforFromMeta in ret)
                        {
                            string controlValue = "0"; // to handle both default number and string format to avoid errors
                            if (paramInforFromMeta.BoundingControl != null) controlValue = paramInforFromMeta.BoundingControl.Text;
                            parameterDictionary.Add(paramInforFromMeta.ParamName, controlValue);
                        }


                        // Now you have a parameterDictionary with parameter names and values
                        // Call your LoadGenericReport method with this dictionary as an argument
                        FardForPersonalRecord_Cr frm = new FardForPersonalRecord_Cr();
                        //frm.bUsingForGeneralpurposeThisReport = true;
                        //frm.LoadGenericReport(data, parameterDictionary, reportName);
                        //frm.Show();
                        frm.ShowDialog();

                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show(ex2.Message);
                         SaveAndOpenCSV(data);
                    }
                }
                else
                { SaveAndOpenCSV(data);
                    // Report not found in resources
                    // Check in the local folder if present
                    string localReportPath = Path.Combine(Environment.CurrentDirectory, reportName );

                    if (File.Exists(localReportPath))
                    {
                        // Report found in the local folder
                        // Proceed with handling it or loading it as needed
                        // Example: Load the Crystal Report from the local path
                        // crystalReportViewer1.ReportSource = localReportPath;
                    }
                    else
                    {
                        // Report not found in resources or local folder
                        // Save and open data as CSV
                       
                    }
                }
            }
            else
            {
                // 'Report' key not found in metadata, save and open data as CSV
                SaveAndOpenCSV(data);
            }
        }
        else if (outputFormat == "SSRS_Report")
        {
            // Handle SSRS Report logic here
            // ...
        }
        else
        {
            // Output format not recognized, save and open data as CSV
            SaveAndOpenCSV(data);
        }
    }
    else
    {
        // 'Output_format' key not found in metadata, save and open data as CSV
        SaveAndOpenCSV(data);
    }
}

// Usage:
// Call HandleOutputFormat(metaData, ds.Tables[0]) with your metadata and data table


private void cmbReports_SelectedIndexChanged(object sender, EventArgs e)
{

    dataGridView1.Visible = false;
    
    // Clear existing controls from the panel
    panelParameters.Controls.Clear();
    int ControlWidth = 200;
    int spacing = 10;

    Sp_Arg_and_Meta_Info selectedReport = cmbReports.SelectedItem as Sp_Arg_and_Meta_Info;
    if (selectedReport != null)
    {
        int yOffset = 10;  // Starting offset

        foreach (var arg in selectedReport.Arguments)
        {
            // Skip if it contains the keyword "output"
            if (arg.Value.Contains("output"))
                continue;

            // Create a label for the argument
            Label lbl = new Label();

            // Remove "@" and replace "_" with a space
            string friendlyArgName = arg.Key.TrimStart('@').Replace('_', ' ');
            lbl.Text = friendlyArgName;// +" (" + arg.Value + "):";
            lbl.Top = yOffset;
            lbl.Left = 10;
            lbl.Width = 150;

            Control inputControl;

            // Check for DATETIME and use appropriate control
            if (arg.Value.ToUpper().Contains("DATETIME"))
            {
                DateTimePicker dtp = new DateTimePicker();
                //dtp.Name = "dtp" + arg.Key;
                dtp.Name = arg.Key.Replace("@","");
                dtp.Format = DateTimePickerFormat.Custom;
                dtp.CustomFormat = "dd MMM yyyy";
                dtp.Top = yOffset;
                dtp.Left = lbl.Right + 10;
                dtp.Width = ControlWidth;
                inputControl = dtp;
            }
            else
            {
                TextBox txt = new TextBox();
                //txt.Name = "txt" + arg.Key;
                txt.Name = arg.Key.Replace("@", ""); ;
                txt.Top = yOffset;
                txt.Left = lbl.Right + 10;
                txt.Width = ControlWidth;

                if (arg.Key.Equals("@UserId", StringComparison.OrdinalIgnoreCase))
                {
                    /*txt.Click += (sender2, e2) =>
                    {
                        // Show your custom dialog here. 
                        // Assuming it returns a string value which you want to set to the TextBox.
                       // string dialogValue = ShowCustomDialog();
                        txt.Text = "1822";// dialogValue;
                    };*/
                    txt.Text = UsersManagments.UserId.ToString();
                    txt.ReadOnly = true;
                }

                if (arg.Key.Equals("@TehsilId", StringComparison.OrdinalIgnoreCase))
                {
                 /*   txt.Click += (sender2, e2) =>
                    {
                        txt.Text = "1822";// dialogValue;
                    };
                    */
                    txt.Text = this.Tehsilid.ToString();
                    txt.ReadOnly = true;
                }

                if (arg.Key.Equals("@TokenNo", StringComparison.OrdinalIgnoreCase))
                {
                    txt.Click += (sender2, e2) =>
                    {
                        frmTokenPopulate PopulateO = new frmTokenPopulate();
                        PopulateO.ServiceTypeId = "0";// GetServiceTypeIdByServiceName("Inteqal");
                        PopulateO.fromform = "1";
                        PopulateO.InteqalMain = true;

                        PopulateO.FormClosed += (sender3, e3) =>
                        {
                            /*
                            frmTokenPopulate Populate = sender3 as frmTokenPopulate;
                            string TokenId = Populate.TokenID;
                            string TokenNo  = Populate.TokenNo;
                            int MozaId = Convert.ToInt32(Populate.Mouzaid);
                            txt.Text = TokenId;
                            */

                            txt.Text = PopulateO.TokenID;
                            txt.ReadOnly = true;
                        };
                        PopulateO.ShowDialog();
                        
                    };
                }

                inputControl = txt;
            }


            // Add the label and input control to the panel
            panelParameters.Controls.Add(lbl);
            panelParameters.Controls.Add(inputControl);

            // Adjust the offset for the next controls
            yOffset += inputControl.Height + 10;
        }

        // Resize the panel to fit the controls with some additional padding
        panelParameters.Height = yOffset + 20;

        // Position the button below the panelParameters
        btnShowReport.Visible = true;

        panelParameters.BackColor = Color.LightGray; // Change to your desired lighter color       
        btnShowReport.Top = panelParameters.Top + panelParameters.Height + spacing;
        this.btnShowReport.Left = panelParameters.Width - this.btnShowReport.Width - spacing;


        // Show the panel
        panelParameters.Visible = true;

        addAdditionalControlOrUpdateExistingToPanel(selectedReport.MetadataContent);

        List<ControlCreationAndBindingInfo> controlCreationInfo2 = this.getNewControlCreationInfroFromMetaData(selectedReport.MetadataContent);



        // Now it is sure that all controll has been created so now papulating them

    }
    else
    {
        panelParameters.Visible = false;  // Hide the panel if no valid report is selected
    }
}

public Control GetPanelControlByName(string name)
{
    foreach (Control control in panelParameters.Controls)
    {
        if (control.Name == name)
        {
            return control;
        }
    }
    return null; // Return null if no control with the given name is found
}
        /*
private void AddDataSourceToControls(Dictionary<string, string> metaData)
{
    List<ControlCreationAndBindingInfo> controlCreationInfo = this.getNewControlCreationInfroFromMetaData(metaData);
    AddDataSourceToControls(controlCreationInfo);
}
        */
private void AddDataSourceToControls(List<ControlCreationAndBindingInfo> controlCreationInfo)
{
    

    foreach (var ctrlInfo in controlCreationInfo)
    {
        Control dependentControl = GetPanelControlByName(ctrlInfo.ControlName);
        Control independentControl = GetPanelControlByName(ctrlInfo.FilterControl);

        if (independentControl != null)
        {
            if (independentControl is ComboBox)
            {
                // Attach to the SelectedIndexChanged event for ComboBox
                ((ComboBox)independentControl).SelectedIndexChanged += (sender, e) =>
                {
                    string value = null;
                    if (((ComboBox)independentControl).SelectedItem != null)
                    {
                        value = ((ComboBox)independentControl).SelectedItem.ToString();
                    }

                    // Handle the value change logic here
                };
            }
            else if (independentControl is TextBox)
            {
                // Attach to the TextChanged event for TextBox
                ((TextBox)independentControl).TextChanged += (sender, e) =>
                {
                    string value = ((TextBox)independentControl).Text;

                    // Handle the value change logic here
                };
            }
            else if (independentControl is DateTimePicker)
            {
                // Attach to the ValueChanged event for DateTimePicker
                ((DateTimePicker)independentControl).ValueChanged += (sender, e) =>
                {
                    string value = ((DateTimePicker)independentControl).Value.ToString();

                    // Handle the value change logic here
                };
            }
        }
    }
}


/*
private int PopulateCombo(Dictionary<string, string> MetadataContent)
{
    List<ControlCreationAndBindingInfo> controlCreationInfo = this.getNewControlCreationInfroFromMetaData(MetadataContent);
    return PopulateCombo(controlCreationInfo);
}
*/
private int PopulateCombo(List<ControlCreationAndBindingInfo> controlCreationInfo)
{
    int ret = 1;


List<Sp_Arg_and_Meta_Info> rptInfo = getReportInfoFromProcedures("Procedure_Name");
List<ReportParameterInfoFromComments>  reportParams = GetReportParameterInfoFromComments(rptInfo[0].MetadataContent);
List<ControlCreationAndBindingInfo> controlCreationInfo2 = this.getNewControlCreationInfroFromMetaData(rptInfo[0].MetadataContent);
    
    DataSetContainer dc =this.getDataSet(rptInfo[0]);

    /*
    List<ControlCreationAndBindingInfo> controlCreationInfo = this.getNewControlCreationInfroFromMetaData(metaData);
    for each contro 
        ReportInfo rinfo = getReportInfoFromProcedures("proc");
        this.getDataSet(rinfo)

            */
    return ret;
}

private int PopulateCombo(ComboBox combo, DataSet ds, string displayField)
{
    int ret = 1;  // success, 0 failure

    try
    {
        if (ds != null && ds.Tables.Count > 0)
        {
            combo.DataSource = ds.Tables[0];
            combo.DisplayMember = displayField;
            combo.ValueMember = displayField;  // assuming you want to use the same field for value, modify as needed
        }
        else
        {
            ret = 0;
        }
    }
    catch
    {
        ret = 0;  // On any exception, return failure
    }

    return ret;
}


private void addAdditionalControlOrUpdateExistingToPanel(Dictionary<string, string> metaData)
{
    List<ControlCreationAndBindingInfo> controlCreationInfo = this.getNewControlCreationInfroFromMetaData(metaData);
    // panelParameters is the Panel on the form where additional controls will be added.

    int yOffset = 10; // Starting offset
    int spacing = 10;
    int totalHeight = 0; // Total height of controls
    int ControlWidth = 200;
    // Create a dictionary to store existing controls by name
    Dictionary<string, Control> existingControls = new Dictionary<string, Control>();

    foreach (Control control in panelParameters.Controls)
    {
        if (control.Visible && (control is TextBox || control is DateTimePicker || control is ComboBox))
        {
            totalHeight += control.Height + spacing;

            // Add existing controls to the dictionary
            existingControls.Add(control.Name, control);
        }
    }

    // Subtract the last spacing value
    if (totalHeight > 0)
    {
        totalHeight -= spacing;
    }

    int bottomLocation = totalHeight;

    int i = 0; int height_tillLastControladded = bottomLocation - spacing;
    foreach (var controlInfo in controlCreationInfo)
    {
        i++;
        Control newControl = null;

        // Check if a control with the same name exists in the panel


        if (controlInfo.ControlType == ControlType.TEXT)
        {
            // Create a TextBox
            newControl = new TextBox();
        }
        else if (controlInfo.ControlType == ControlType.DATE)
        {
            // Create a DateTimePicker
            newControl = new DateTimePicker();
        }
        else if (controlInfo.ControlType == ControlType.COMBO)
        {
            // Create a ComboBox
            newControl = new ComboBox();
        }

        if (newControl != null)
        {
            if (existingControls.ContainsKey(controlInfo.ControlName))
            {
                Control existingControl = existingControls[controlInfo.ControlName];
                i--; // already exist so 
                // Check if the existing control type matches the desired type
                if ((controlInfo.ControlType == ControlType.TEXT && existingControl is TextBox) ||
                    (controlInfo.ControlType == ControlType.DATE && existingControl is DateTimePicker) ||
                    (controlInfo.ControlType == ControlType.COMBO && existingControl is ComboBox))
                {
                    i--;
                    // Control type matches, no need to add a new control, leave the existing one
                    continue;
                }
                else
                {
                    // Control type does not match, remove the existing control
                    // Set common properties for all controls
             //       newControl.Name = controlInfo.ControlName;
                    newControl.Top = existingControl.Top;
                    newControl.Left = existingControl.Left; // Adjust the left position as needed
                    newControl.Width = existingControl.Width; // Set the width as needed
                    newControl.Visible = existingControl.Visible;

                    panelParameters.Controls.Remove(existingControl);
                    newControl.Name = controlInfo.ControlName;
                }
            }else{

                Label lbl = new Label();
                this.panelParameters.Height += (newControl.Height + spacing);
                height_tillLastControladded += (newControl.Height + spacing);

                // Remove "@" and replace "_" with a space
                string friendlyArgName = controlInfo.ControlName.Replace("_"," ");
                lbl.Text = friendlyArgName;// +" (" + arg.Value + "):";
                lbl.Top = height_tillLastControladded;
                lbl.Left = 10;
                lbl.Width = 150;
                panelParameters.Controls.Add(lbl);

            // Set common properties for all controls
                newControl.Name = controlInfo.ControlName;
                newControl.Top = height_tillLastControladded;
                newControl.Left = lbl.Right + 10; ; // Adjust the left position as needed
                newControl.Width = ControlWidth; // Set the width as needed
                newControl.Visible = true;
            }

            // Add the control to the panel
            //this.panelParameters.Height -= spacing;
            panelParameters.BackColor = Color.LightGray; // Change to your desired lighter color

            panelParameters.Controls.Add(newControl);
            btnShowReport.Top =panelParameters.Top+ panelParameters.Height +  spacing;
            this.btnShowReport.Left = panelParameters.Width - this.btnShowReport.Width - spacing;

        }





    }
}



private void button2_Click(object sender, EventArgs e)
{

}




    }
}
