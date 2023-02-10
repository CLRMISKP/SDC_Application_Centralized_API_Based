using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmMISC : Form
    {
        public frmMISC()
        {
            InitializeComponent();
        }

        System.Windows.Forms.CheckBox[] chkWeekDays = new CheckBox[5];

        private void frmMISC_Load(object sender, EventArgs e)
        {
            chkWeekDays[0] = this.checkBox1;
            chkWeekDays[1] = this.checkBox2;
            chkWeekDays[2] = this.checkBox3;
            chkWeekDays[3] = this.checkBox4;
            chkWeekDays[4] = this.checkBox5;
        }
        private void chkWeekDays_CheckedChanged(object sender, EventArgs e)
        {
            /*
            CheckBox selectedCheckBox = (CheckBox)sender;

            if (selectedCheckBox.Name == "Monday")
            {
                if (selectedCheckBox.Checked)
                {
                    MessageBox.Show("Monday checkbox is checked");
                }
                else
                {
                    MessageBox.Show("Monday checkbox is unchecked");
                }
            }
            else if (selectedCheckBox.Name == "Tuesday")
            {
                if (selectedCheckBox.Checked)
                {
                    MessageBox.Show("Tuesday checkbox is checked");
                }
                else
                {
                    MessageBox.Show("Tuesday checkbox is unchecked");
                }
            }
            */

                int Tehsilid= UsersManagments._Tehsilid;
                if (Tehsilid == -1 || Tehsilid == 0) return;

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
/*
                if (!Int32.TryParse(this.txtTehsilid.Text, out Tehsilid))
                {
                    MessageBox.Show(this.txtTehsilid.Text + " is not tehsil id");
                }*/

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


        }
    }
}
