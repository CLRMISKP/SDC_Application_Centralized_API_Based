using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace SDC_Application.AL
{
    public partial class FardMalikan_Report_TTx : Form
    {
        public FardMalikan_Report_TTx()
        {
            InitializeComponent();
        }


        public long TokenId = -1;
        

        private void FardMalikan_Report_TTx_Load(object sender, EventArgs e)
            {
                TokenId = 43202301100001;

                string dsvr =SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
                string db =SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);            
                string password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
                string connectionString = "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    int employeeID = 0;
                    try
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("clrmis_Sp_FardMalakan_TTx", connection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@TokenId", TokenId));
                        command.CommandTimeout = 5;

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        /*
                                            this.cmbKhata.DataSource = ds.Tables[0];
                                            this.cmbKhata.DisplayMember = "KhataNo";
                                            this.cmbKhata.ValueMember = "RegisterHqDKhataId";
                        */
                        //command.ExecuteNonQuery();
                        this.dataGridView1.DataSource = ds.Tables[0];

                        ReportDocument cryRpt = new ReportDocument();
                        //cryRpt.Load("SDC_Application.AL.FardMalakan_TTx.rpt");
                        //cryRpt.Load("SDC_Application.AL.FardMalakan_TTx.rpt");
                        cryRpt.Load(@"AL\FardMalakan_TTx.rpt");
                        crystalReportViewer1.ReportSource = cryRpt;
                        crystalReportViewer1.Refresh();
                        crystalReportViewer1.Show();
                        crystalReportViewer1.ShowLastPage();
                        
                     

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


                this.reportViewer1.RefreshReport();
        }
    }
}
