using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.Configuration;

namespace SDC_Application.DL
{
    class Database
    {
        public static SqlConnection Connection=null;
        public static SqlDataReader dr=null;
        public SqlCommand insertCommand;
        public SqlCommand Command;
        public SqlDataAdapter da=new SqlDataAdapter();

        static string ds =System.Configuration.ConfigurationSettings.AppSettings["server"];
        static string db =ConfigurationSettings.AppSettings["db"];
        static string password = ConfigurationSettings.AppSettings["allow"];
        
        //
//private static string mySqlConnectionString = "Data Source=unh-pak-1860\\unhabitat1;Initial Catalog=Mardan_AmalDaramad; MultipleActiveResultSets=True;integrated security=true";
        private static string mySqlConnectionString = "Data Source=" + ds + ";Initial Catalog=" + db + ";user id=dlis; Password="+password+";MultipleActiveResultSets=True";
        
        #region  Connection Estiblishment
        public static void CloseConn()
        {
            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
                Connection.Dispose();

            }
        }
        public static SqlConnection CreateConn()
        {
            if (Connection == null)
            {
                Connection = new SqlConnection();
            }
            if (Connection.ConnectionString == string.Empty || Connection.ConnectionString == null)
            {
                try
                {
                    Connection.ConnectionString = "Min Pool Size=5;Max Pool Size=40;Connect Timeout=4;" + mySqlConnectionString + ";";
                    Connection.Open();
                }
                catch (Exception)
                {
                    if (Connection.State != ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                    Connection.ConnectionString = "Pooling=false;Connect Timeout=45;" + mySqlConnectionString + ";";
                    Connection.Open();
                }
                return Connection;
            }
            if (Connection.State != ConnectionState.Open)
            {
                try
                {
                    Connection.ConnectionString = "Min Pool Size=5;Max Pool Size=40;Connect Timeout=4;" + mySqlConnectionString + ";";
                    Connection.Open();
                }
                catch (Exception)
                {
                    if (Connection.State != ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                    Connection.ConnectionString = "Pooling=false;Connect Timeout=45;" + mySqlConnectionString + ";";
                    Connection.Open();
                }
            }
            return Connection;
        }
        #endregion Connection Closed

        /// <summary>
        /// selection_squery when Need data reader password or textbinding
        /// </summary>
        
        #region Selection_Query
        //public SqlDataReader selection_squery(string str)
        //{

        //    dr = null;

        //    SqlCommand cmd = new SqlCommand(str,CreateConn());
        //    dr = cmd.ExecuteReader();

        //    return dr;
        //}


        public static bool drclose()
        {
            if (!dr.IsClosed)
                dr.Close();
            return true;
        }

        #endregion

        #region User Athentication
        public DataTable AthenticateUser(string query, string TehsilId, string IP)
        {
            try
            {
                DataTable dtt = new DataTable();
                //da= new SqlDataAdapter(query,CreateConn());
                //da.Fill(dtt);
                //CloseConn();
                APIClient client = new APIClient();
                UserRequestLogin request = new UserRequestLogin()
                {
                    Query = query, TehsilId=TehsilId, IP=IP
                };
                dtt = client.UserAuthentication(request);
                return dtt;


            }
            catch (Exception ex)
            {
                CloseConn();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public void UserLogout(string query, string TehsilId, string token)
        {
            try
            {
                DataTable dtt = new DataTable();
                //da= new SqlDataAdapter(query,CreateConn());
                //da.Fill(dtt);
                //CloseConn();
                APIClient client = new APIClient();
                UserRequest request = new UserRequest()
                {
                    Query = query,
                    TehsilId = TehsilId
                };
               client.UserLogout(request, token);


            }
            catch (Exception ex)
            {
                CloseConn();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        /// <summary>
        /// filldatatable direct access to database table
        /// </summary>

        #region Datatable
        public DataTable fillDataTable(string query)
        {
            try
            {
             DataTable dtt = new DataTable();
                //da= new SqlDataAdapter(query,CreateConn());
                //da.Fill(dtt);
                //CloseConn();
                APIClient client = new APIClient();
                UserRequest request = new UserRequest()
                {
                    Query = query, TehsilId=UsersManagments._Tehsilid.ToString()
                };
                dtt = client.GetData(request, UsersManagments.UserToken);
                return dtt;

             
            }
            catch (Exception ex)
            {
                CloseConn();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// viewgriddata Fill  gridview by Storeprocedure
        /// </summary>
       
        public DataTable viewGridData(string query)
        {
            try
            {

            DataTable dt_storeProcedure = new DataTable();
            SqlCommand cmd = new SqlCommand(query, CreateConn());
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(dt_storeProcedure);
            return dt_storeProcedure;

            }
            catch (Exception ex)
            {
                 CloseConn();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// filldatatable_from_storedProcedure used to insert/update and retrive result to users
        /// </summary>
       
        public DataTable filldatatable_from_storedProcedure(string spWithParams)
        {
            try
            {
            DataTable dt_storeProcedure = new DataTable();
                //da = new SqlDataAdapter(spWithParams, CreateConn());
                //da.Fill(dt_storeProcedure);
                //CloseConn();
                APIClient client = new APIClient();
                UserRequest request = new UserRequest()
                {
                    Query = spWithParams, TehsilId=UsersManagments._Tehsilid.ToString()
                };
                dt_storeProcedure = client.GetData(request,UsersManagments.UserToken);
                return dt_storeProcedure;

            }
            catch (Exception ex)
            {
                //CloseConn();
                MessageBox.Show(ex.Message);
                return null;
            }

        }
        #endregion

        /// <summary>
        /// Insert_StoreProcedure/update when only insertion needed 
        /// </summary>
        
        public int Insert_StoreProcedure(string str)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(str, CreateConn());
                int retVal=cmd.ExecuteNonQuery();
                CloseConn();
                return retVal;

            }
            catch (Exception ex)
            {
                CloseConn();
                MessageBox.Show(ex.Message);
                return 0;
            }

        }

        /// <summary>
        /// selection_squery when Need data for databinding
        /// </summary>
        public SqlDataReader fillDataReader(string str)
        {
            try
            {
            dr = null;

            SqlCommand cmd = new SqlCommand(str, CreateConn());
            dr = cmd.ExecuteReader();
            CloseConn();
            return dr;

            }
            catch (Exception ex)
            {
                CloseConn();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Executes Inserts and Updates Stored Procedures and return last Id as string
        /// </summary>
        /// <param name="SpWithParams"></param>
        /// <returns>LastId</returns>
        public string ExecInsertUpdateStoredProcedure(string SpWithParams)
        {
            try
            {
                string lastId = "0";
                //SqlCommand cmd = new SqlCommand(SpWithParams, CreateConn());
                //object retVal = cmd.ExecuteScalar();
                //lastId = retVal != null ? retVal.ToString() : "0";
                //CloseConn();

                // Replaced By APIs

                APIClient client = new APIClient();
                UserRequest request = new UserRequest()
                {
                    Query = SpWithParams, TehsilId=UsersManagments._Tehsilid.ToString()
                };
                lastId = client.exexuteScalar(request,UsersManagments.UserToken);
                //return dt_storeProcedure;
                return lastId;
                
            }
            catch (Exception ex)
            {
                CloseConn();
                MessageBox.Show(ex.Message);
                return "0";
            }
        }

        /// <summary>
        /// Executes Inserts and Updates Stored Procedures and return last Id as string
        /// </summary>
        /// <param name="SpWithParams"></param>
        /// <returns>LastId</returns>
        public string ExecStoredProcedure(string SpWithParams, SqlCommand c)
        {
            try
            {
                string lastId = "0";
                SqlCommand cmd = c as SqlCommand;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = CreateConn();
                cmd.CommandText = SpWithParams;
                object retVal = cmd.ExecuteScalar();
                lastId = retVal != null ? retVal.ToString() : "0";
                CloseConn();
                return lastId;
               
            }
            catch (Exception ex)
            {
                CloseConn();
                MessageBox.Show(ex.Message);
                return "0";
            }
        }

        /// <summary>
        /// Executes Inserts and Updates Stored Procedures and return last Id as string
        /// </summary>
        /// <param name="SpWithParams"></param>
        /// <returns>LastId</returns>
        public void ExecUpdateStoredProcedureWithNoRet(string SpWithParams)
        {
            try
            {
                //SqlCommand cmd = new SqlCommand(SpWithParams, CreateConn());
                //int row = cmd.ExecuteNonQuery();
                //CloseConn();
                APIClient client = new APIClient();
                UserRequest request = new UserRequest()
                {
                    Query = SpWithParams, TehsilId=UsersManagments._Tehsilid.ToString()
                };
                client.executeNonQuery(request,UsersManagments.UserToken);

            }
            catch (Exception ex)
            {
                CloseConn();
                MessageBox.Show(ex.Message);
                //return null;
            }

        }
      
    }
}
