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
        public bool bUsingForGeneralpurposeThisReport = false;
        public string MozaId { get; set; }
        public string TokenId { get; set; }
        public string tehsilid { get; set; }


        public FardForPersonalRecord_Cr()
        {
            InitializeComponent();
        }


        private void crystalReportViewer1_Load(object sender, EventArgs e)        
        {
            if (!bUsingForGeneralpurposeThisReport) loadReport(null);
        
        }


            public void LoadGenericReport(DataSet ds, Dictionary<string, string> ReportParameters, string ReportName)
            {
                ReportDocument cryRpt = new ReportDocument();
    
                // Load the report from the specified path
                string currentDirectory = Environment.CurrentDirectory;
                string fullPathToReport = currentDirectory + "\\" + ReportName;
                cryRpt.Load(fullPathToReport);



                // Set the main report's data source
                cryRpt.SetDataSource(ds.Tables[0]);

                // Set subreport data sources
                for (int i = 1; i < ds.Tables.Count; i++)
                {
                    cryRpt.Subreports[i - 1].SetDataSource(ds.Tables[i]);
                }


                // Set report parameters from the provided dictionary
                /*
                if (ReportParameters != null && ReportParameters.Count > 0)
                {
                    foreach (var parameter in ReportParameters)
                    {
                        // Assuming your report parameters are string and you want to set them as strings
                        cryRpt.SetParameterValue(parameter.Key, parameter.Value);
                    }
                }
                */

// Create a list to store missing parameters
List<string> missingParameters = new List<string>();

// Iterate through the report's parameters
foreach (var parameterField in cryRpt.ParameterFields)
{

    CrystalDecisions.Shared.ParameterField pf = (CrystalDecisions.Shared.ParameterField)parameterField;
    var parameterName = pf.Name;

    // Check if the parameter exists in the ReportParameters dictionary
    if (!ReportParameters.ContainsKey(parameterName))
    {
        // Add the missing parameter to the list
        missingParameters.Add(parameterName);
    }
}


        // Check if there are any missing parameters
if (missingParameters.Count > 0)
{
    // Create the message string
    string missingParams = string.Join(", ", missingParameters);
    string message = "The following parameters are missing in the report: " + missingParams;

    // Display a message box with the missing parameters
    //MessageBox.Show(message, "Missing Parameters", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    throw new Exception(message);
}
else
{

    List<string> parameterNames = new List<string>();
    //CrystalDecisions.Shared.ParameterFields     
    foreach (  CrystalDecisions.Shared.ParameterField parameterField in cryRpt.ParameterFields)
    {
        parameterNames.Add(parameterField.Name);
    }

        foreach (var parameter in ReportParameters)
        {
            // Check if the parameter exists in the report before setting its value
            if (parameterNames.Contains(parameter.Key))
            {
                cryRpt.SetParameterValue(parameter.Key, parameter.Value);
            }  
        }    
}



                try
                {
                    // Set the CrystalReportViewer's report source
                    crystalReportViewer1.ReportSource = cryRpt;

                    // Refresh and show the CrystalReportViewer
                    crystalReportViewer1.Refresh();
                    crystalReportViewer1.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
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

        private void FardForPersonalRecord_Cr_Load(object sender, EventArgs e)
        {

        }
    }
}
