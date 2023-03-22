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
using System.IO;
using System.Reflection;

namespace SDC_Application.AL
{
    public partial class FardForPersonalRecord_Cr : Form
    {

        public string MozaId { get; set; }
        public string TokenId { get; set; }
        public string tehsilid { get; set; }


        public FardForPersonalRecord_Cr()
        {
            InitializeComponent();
        }


        private void crystalReportViewer1_Load(object sender, EventArgs e)        
        {
            loadReport(null);
        
        }


        public void loadReport(DataSet dsA) 
        {

            tehsilid = Classess.UsersManagments._Tehsilid.ToString();
            /*
            MozaId = "15140";
            TokenId = "15202302130028";            
            tehsilid = "15";
            */

            string dsvr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
            string db = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
            string password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
            string connectionString = "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int employeeID = 0;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("FardForPersonalRecord_Fast_rdl", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@TokenId", TokenId));
                    command.Parameters.Add(new SqlParameter("@TehsilId", tehsilid));
                    command.Parameters.Add(new SqlParameter("@MozaId", MozaId));


                    command.CommandTimeout = 600;

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
                    string currentDirectory = Environment.CurrentDirectory;
                    string fullPathToReport = currentDirectory + @"\AL\FardForPersonalRecord_Cr.rpt";
                     fullPathToReport =  @"C:\Users\Shehzad\Documents\GitHub\SDC_Application_Centralized\SDC_Application\AL\FardForPersonalRecord_Cr.rpt";
                     cryRpt.Load(fullPathToReport);



                     cryRpt.SetDataSource(ds.Tables[0]);
                     cryRpt.Subreports["SoldRaqbaZereTajweez"].SetDataSource(ds.Tables[1]);
                     //cryRpt.Subreports["Fard_Beah_AreaTypes"].SetDataSource(ds.Tables[2]);
                     cryRpt.Subreports["FardAreaBeh2"].SetDataSource(ds.Tables[2]);

                     cryRpt.Subreports["FardKhanakashtKhatooniByKhata"].SetDataSource(ds.Tables[3]);
                     cryRpt.Subreports["FardKhanaKashtTotalRaqba"].SetDataSource(ds.Tables[4]);

                     cryRpt.Subreports["FardKhanaMalkiatKhatajat"].SetDataSource(ds.Tables[5]);

                     cryRpt.Subreports["FardKhanaMalkiatTotalRaqba"].SetDataSource(ds.Tables[6]);
                     cryRpt.Subreports["FardKhanaMalkiatBeahShudaKhanakasht"].SetDataSource(ds.Tables[7]);


                     //cryRpt.Subreports["Khatooni_ttx"].SetDataSource(ds.Tables[2]);
                     //cryRpt.Subreports["MalkanRpt01"].SetDataSource(ds.Tables[3]);
                     
                     
                     crystalReportViewer1.ReportSource = cryRpt;
                     crystalReportViewer1.Refresh();
                     crystalReportViewer1.Show();







                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            this.reportViewer1.RefreshReport();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadReport(null);
        }
    }
}
