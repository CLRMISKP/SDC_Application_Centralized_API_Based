using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.AL;
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

        static string ds =SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
        static string db =SDC_Application.Classess.Crypto.Decrypt(ConfigurationSettings.AppSettings["db"]);
        //static string password = ConfigurationSettings.AppSettings["allow"];
        static string password = SDC_Application.Classess.Crypto.Decrypt(ConfigurationSettings.AppSettings["allow"]);
        
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
                    Connection.ConnectionString = "Min Pool Size=5;Max Pool Size=40;Connect Timeout=300;" + mySqlConnectionString + ";";
                    Connection.Open();
                }
                catch (Exception)
                {
                    if (Connection.State != ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                    Connection.ConnectionString = "Pooling=false;Connect Timeout=300;" + mySqlConnectionString + ";";
                    Connection.Open();
                }
                return Connection;
            }
            if (Connection.State != ConnectionState.Open)
            {
                try
                {
                    Connection.ConnectionString = "Min Pool Size=5;Max Pool Size=40;Connect Timeout=300;" + mySqlConnectionString + ";";
                    Connection.Open();
                }
                catch (Exception)
                {
                    if (Connection.State != ConnectionState.Closed)
                    {
                        Connection.Close();
                    }
                    Connection.ConnectionString = "Pooling=false;Connect Timeout=300;" + mySqlConnectionString + ";";
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
        /// <summary>
        /// filldatatable direct access to database table
        /// </summary>
        
        #region Datatable
        public DataTable fillDataTable(string query)
        {
            try
            {
             DataTable dtt = new DataTable();
             da= new SqlDataAdapter(query,CreateConn());
             da.Fill(dtt);
             CloseConn();
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
            da = new SqlDataAdapter(spWithParams, CreateConn());
            da.Fill(dt_storeProcedure);
            CloseConn();
            return dt_storeProcedure;

            }
            catch (Exception ex)
            {
                CloseConn();
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public DataTable filldatatable_from_storedProcedureWithReturnVals(string spWithParams , out int RetVal , out string ErrorMsg)
        {
            CloseConn();
            RetVal = 0;
            ErrorMsg = "";

            try
            {

                DataSet ds = new DataSet();
                DataTable dt_storeProcedure = new DataTable();
                da = new SqlDataAdapter(spWithParams, CreateConn());
                //da.Fill(dt_storeProcedure);
                //return dt_storeProcedure;

                SqlConnection con = CreateConn();
                using (SqlCommand cmd = new SqlCommand(spWithParams, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // set up the parameters                    
                    SqlParameter errorMessage =  cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar,1000);//.Direction = 
                    errorMessage.Direction = ParameterDirection.Output;
                    SqlParameter retVal = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);//.Direction = 
                    retVal.Direction = ParameterDirection.ReturnValue;
                    // open connection and execute stored procedure
                   // con.Open();
                    cmd.ExecuteNonQuery();

                    da.SelectCommand = cmd;

                    da.Fill(ds);

                    return ds.Tables[0];
                }

            }
            catch (Exception ex)
            {
                CloseConn();
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
                SqlCommand cmd = new SqlCommand(SpWithParams, CreateConn());
                object retVal =cmd.ExecuteScalar();
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
                SqlCommand cmd = new SqlCommand(SpWithParams, CreateConn());
                int row = cmd.ExecuteNonQuery();
                CloseConn();
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
