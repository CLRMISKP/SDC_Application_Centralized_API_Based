using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.BL;
using SDC_Application.DL;
using System.Collections;
namespace SDC_Application.AL

{
    public partial class Reports : Form
    {
        DL.Database ojbdb = new DL.Database();
        BL.Reports objbusines = new BL.Reports();
        public Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatetoDateToken rpt = new DatetoDateToken();
            try
            {
                DateTime fromdate = Convert.ToDateTime(this.dateTimePicker1.Text);
                DateTime todate = Convert.ToDateTime(dateTimePicker2.Text);
                if (fromdate > todate)
                {
                    MessageBox.Show("صیح تاریخ کی انتخاب کریں");
                }
                string query = "Proc_Get_SDCToken_Between_Dates" + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + this.dateTimePicker1.Text + "' , '" + this.dateTimePicker2.Text + "'";
               // MessageBox.Show(query);
                DataTable DatetoDateTokens = new DataTable();
                DatetoDateTokens = objbusines.filldatatable_from_storedProcedure(query);

                if (DatetoDateTokens != null)
                {

                    rpt.SetDataSource(DatetoDateTokens);
                    crystalReportViewer1.Visible = true;
                    crystalReportViewer1.ReportSource = rpt;
                    crystalReportViewer1.Refresh();
                }
            }
            catch(Exception ee)
            {}
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;
        }
    }
}
