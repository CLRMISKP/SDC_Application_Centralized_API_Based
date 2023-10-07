using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; // Import the necessary namespace
using System.Windows.Forms;

namespace SDC_Application
{
    public partial class TestGridCSV_Helpter : Form
    {


        string dsvr = "";//SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
        string db = "";//SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
        string password = "";//SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
        string connectionString = "";// "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";



        public TestGridCSV_Helpter()
        {
            InitializeComponent();
        }

        private void TestGridCSV_Helpter_Load(object sender, EventArgs e)
        {

            dsvr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
            db = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["db"]);
            password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["allow"]);
            connectionString = "Data Source=" + dsvr + ";Initial Catalog=" + db + ";user id=dlis; Password=" + password + ";MultipleActiveResultSets=True";



            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object for your stored procedure
                using (SqlCommand command = new SqlCommand("Del_test_proc", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters, including the output parameter for @Err_Msg
                    command.Parameters.Add("@Err_Msg", SqlDbType.VarChar, 100);
                    command.Parameters["@Err_Msg"].Direction = ParameterDirection.Output;

                    // Create a DataTable to hold the results
                    DataTable dataTable = new DataTable();

                    // Open the database connection
                    connection.Open();

                    // Execute the stored procedure and fill the DataTable with the results
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }

                    // Bind the DataGridView to the DataTable
                    dataGridView1.DataSource = dataTable;
                    this.dataGridView2.DataSource = dataTable;
                }
            }
        }
    }
}
