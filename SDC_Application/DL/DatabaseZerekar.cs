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
    class DatabaseZerekar
    {
        public static SqlConnection ConnectionZerekar=null;
        public static SqlDataReader drZerekar=null;
        public SqlCommand insertCommand;
        public SqlCommand Command;
        public SqlDataAdapter da=new SqlDataAdapter();

        static string dsZerekar = "172.16.100.11";//"175.107.62.190"; //System.Configuration.ConfigurationSettings.AppSettings["server"];
        static string dbZerekar = "CLRMIS_ScanJamabandi"; //ConfigurationSettings.AppSettings["db"];
        static string passwordZerekar = "$$#Un#hAbItAt@@2013##"; //ConfigurationSettings.AppSettings["allow"];
        
        //
//private static string mySqlConnectionStringZerekar = "Data Source=unh-pak-1860\\unhabitat1;Initial Catalog=Mardan_AmalDaramad; MultipleActiveResultSets=True;integrated security=true";
        private static string mySqlConnectionStringZerekar = "Data Source=" + dsZerekar + ";Initial Catalog=" + dbZerekar + ";user id=dlis; Password=" + passwordZerekar + ";MultipleActiveResultSets=True";
        
        #region  ConnectionZerekar Estiblishment
        public static void CloseConn()
        {
            if (ConnectionZerekar != null)
            {
                if (ConnectionZerekar.State == ConnectionState.Open)
                {
                    ConnectionZerekar.Close();
                }
                ConnectionZerekar.Dispose();

            }
        }
        public static SqlConnection CreateConn()
        {
            if (ConnectionZerekar == null)
            {
                ConnectionZerekar = new SqlConnection();
            }
            if (ConnectionZerekar.ConnectionString == string.Empty || ConnectionZerekar.ConnectionString == null)
            {
                try
                {
                    ConnectionZerekar.ConnectionString = "Min Pool Size=5;Max Pool Size=40;Connect Timeout=4;" + mySqlConnectionStringZerekar + ";";
                    ConnectionZerekar.Open();
                }
                catch (Exception)
                {
                    if (ConnectionZerekar.State != ConnectionState.Closed)
                    {
                        ConnectionZerekar.Close();
                    }
                    ConnectionZerekar.ConnectionString = "Pooling=false;Connect Timeout=45;" + mySqlConnectionStringZerekar + ";";
                    ConnectionZerekar.Open();
                }
                return ConnectionZerekar;
            }
            if (ConnectionZerekar.State != ConnectionState.Open)
            {
                try
                {
                    ConnectionZerekar.ConnectionString = "Min Pool Size=5;Max Pool Size=40;Connect Timeout=4;" + mySqlConnectionStringZerekar + ";";
                    ConnectionZerekar.Open();
                }
                catch (Exception)
                {
                    if (ConnectionZerekar.State != ConnectionState.Closed)
                    {
                        ConnectionZerekar.Close();
                    }
                    ConnectionZerekar.ConnectionString = "Pooling=false;Connect Timeout=45;" + mySqlConnectionStringZerekar + ";";
                    ConnectionZerekar.Open();
                }
            }
            return ConnectionZerekar;
        }
        #endregion ConnectionZerekar Closed

        /// <summary>
        /// selection_squery when Need data reader password or textbinding
        /// </summary>
        
        #region Selection_Query
        //public SqlDataReader selection_squery(string str)
        //{

        //    drZerekar = null;

        //    SqlCommand cmd = new SqlCommand(str,CreateConn());
        //    drZerekar = cmd.ExecuteReader();

        //    return drZerekar;
        //}


        public static bool drclose()
        {
            if (!drZerekar.IsClosed)
                drZerekar.Close();
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
            drZerekar = null;

            SqlCommand cmd = new SqlCommand(str, CreateConn());
            drZerekar = cmd.ExecuteReader();
            CloseConn();
            return drZerekar;

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
