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

                //loadReport();
        }

        public void loadReport(DataSet dsA){

            DataSet ds = dsA;


                int Tehsilid = SDC_Application.Classess.UsersManagments._Tehsilid;
                TokenId = 43202301100001;
                Tehsilid = 43;

                string dsvr =SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
                string db =SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);            
                string password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
                string connectionString = "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";
                connectionString = "Min Pool Size=5;Max Pool Size=40;Connect Timeout=45;" + connectionString;

                if (ds == null)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        int employeeID = 0;
                        try
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand("clrmis_Sp_FardMalakan_TTx", connection);
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add(new SqlParameter("@TehsilId", Tehsilid));
                            command.Parameters.Add(new SqlParameter("@TokenId", TokenId));

                            command.CommandTimeout = 0;

                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            ds = new DataSet();
                            adapter.Fill(ds);
                            ds.WriteXml("clrmis_Sp_FardMalakan_TTx", XmlWriteMode.WriteSchema);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                    }

                }

                try
                {
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
                    //cryRpt.Load(@"AL\FardMalakan_TTx.rpt");
                    cryRpt.Load(@"C:\Users\Shehzad\Documents\GitHub\SDC_Application_Centralized\SDC_Application\AL\FardMalakan_TTx.rpt");
                    cryRpt.SetDataSource(ds.Tables[0]);
                    cryRpt.Subreports["FardMalakan_TTx_Kafiat"].SetDataSource(ds.Tables[1]);
                    cryRpt.Subreports["Khatooni_ttx"].SetDataSource(ds.Tables[2]);

                    cryRpt.Subreports["MalkanRpt01"].SetDataSource(ds.Tables[3]);
                    //cryRpt.Subreports["Subreport2"].SetDataSource(ds.Tables[3]);
                    /*
                    cryRpt.Subreports[0].SetDataSource(ds.Tables[1]);
                    cryRpt.Subreports[1].SetDataSource(ds.Tables[2]);
                    cryRpt.Subreports[2].SetDataSource(ds.Tables[3]);                       
                    */

                    crystalReportViewer1.ReportSource = cryRpt;
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();
                //crystalReportViewer1.ShowLastPage();
                //crystalReportViewer1.ShowNthPage(2);
                //crystalReportViewer1.ShowNextPage();
                }
                catch (Exception ex)
                {
                    
                    MessageBox.Show(ex.Message);
                }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml("clrmis_Sp_FardMalakan_TTx");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                ds = null;
            }
            
            loadReport(ds);
        }

    }
}
