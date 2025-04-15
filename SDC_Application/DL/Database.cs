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
using SDC_Application.Classess;

namespace SDC_Application.DL
{
    class Database
    {
        public APIClient client = new APIClient();
//        public static SqlConnection Connection=null;
//        public static SqlDataReader dr=null;
//        public SqlCommand insertCommand;
//        public SqlCommand Command;
//        public SqlDataAdapter da=new SqlDataAdapter();

//        static string ds =SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["server"]);
//        static string db =SDC_Application.Classess.Crypto.Decrypt(ConfigurationSettings.AppSettings["db"]);
//        //static string password = ConfigurationSettings.AppSettings["allow"];
//        static string password = SDC_Application.Classess.Crypto.Decrypt(ConfigurationSettings.AppSettings["allow"]);
        
//        //
////private static string mySqlConnectionString = "Data Source=unh-pak-1860\\unhabitat1;Initial Catalog=Mardan_AmalDaramad; MultipleActiveResultSets=True;integrated security=true";
//        private static string mySqlConnectionString = "Data Source=" + ds + ";Initial Catalog=" + db + ";user id=dlis; Password="+password+";MultipleActiveResultSets=True";
        
        //#region  Connection Estiblishment
        //public static void CloseConn()
        //{
        //    if (Connection != null)
        //    {
        //        if (Connection.State == ConnectionState.Open)
        //        {
        //            Connection.Close();
        //        }
        //        Connection.Dispose();

        //    }
        //}
        //public static SqlConnection CreateConn()
        //{
        //    if (Connection == null)
        //    {
        //        Connection = new SqlConnection();
        //    }
        //    if (Connection.ConnectionString == string.Empty || Connection.ConnectionString == null)
        //    {
        //        try
        //        {
        //            Connection.ConnectionString = "Min Pool Size=5;Max Pool Size=100;Connect Timeout=600;" + mySqlConnectionString + ";";
        //            Connection.Open();
        //        }
        //        catch (Exception)
        //        {
        //            if (Connection.State != ConnectionState.Closed)
        //            {
        //                Connection.Close();
        //            }
        //            Connection.ConnectionString = "Pooling=false;Connect Timeout=600;" + mySqlConnectionString + ";";
        //            Connection.Open();
        //        }
        //        return Connection;
        //    }
        //    if (Connection.State != ConnectionState.Open)
        //    {
        //        try
        //        {
        //            Connection.ConnectionString = "Min Pool Size=5;Max Pool Size=100;Connect Timeout=600;" + mySqlConnectionString + ";";
        //            Connection.Open();
        //        }
        //        catch (Exception)
        //        {
        //            if (Connection.State != ConnectionState.Closed)
        //            {
        //                Connection.Close();
        //            }
        //            Connection.ConnectionString = "Pooling=false;Connect Timeout=600;" + mySqlConnectionString + ";";
        //            Connection.Open();
        //        }
        //    }
        //    return Connection;
        //}
        //#endregion Connection Closed

        /// <summary>
        /// filldatatable direct access to database table
        /// </summary>
        
        #region Datatable
        public DataTable fillDataTable(string query)
        {
            UserRequest request = new UserRequest();
            request.Query = query;
            request.TehsilId = UsersManagments._Tehsilid.ToString();
            DataTable dt = client.GetData(request, UsersManagments.userToken);
            return dt != null ? dt.Columns.Count > 0 ? dt : null : null;
        }

 
        /// <summary>
        /// filldatatable_from_storedProcedure used to insert/update and retrive result to users
        /// </summary>
       
        public DataTable filldatatable_from_storedProcedure(string spWithParams)
        {
            UserRequest request = new UserRequest();
            request.Query = spWithParams;
            request.TehsilId = UsersManagments._Tehsilid.ToString();
            DataTable dt = client.GetData(request, UsersManagments.userToken);
            return dt != null ? dt.Columns.Count > 0 ? dt : null : null;

        }

        public DataTable GetUserInfoForMachineReg(string spWithParams)
        {
            UserInfoForMachinReg request = new UserInfoForMachinReg();
            request.Query = spWithParams;
            request.TehsilId = UsersManagments._Tehsilid.ToString();
            DataTable dt = client.GetUserInfo(request);
            return dt != null ? dt.Columns.Count > 0 ? dt : null : null;

        }
        //public DataTable filldatatable_from_storedProcedure(string storedProcedureName, SqlParameter[] parameters)
        //{
        //    try
        //    {
        //        DataTable dt_storeProcedure = new DataTable();
        //        using (SqlConnection conn = CreateConn())
        //        {
        //            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.AddRange(parameters);

        //                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        //                {
        //                    da.Fill(dt_storeProcedure);
        //                }
        //            }
        //        }
        //        return dt_storeProcedure;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }
        //    finally
        //    {
        //        CloseConn();
        //    }
        //}

        //public DataTable filldatatable_from_storedProcedureWithReturnVals(string spWithParams , out int RetVal , out string ErrorMsg)
        //{
        //    CloseConn();
        //    RetVal = 0;
        //    ErrorMsg = "";

        //    try
        //    {

        //        DataSet ds = new DataSet();
        //        DataTable dt_storeProcedure = new DataTable();
        //        da = new SqlDataAdapter(spWithParams, CreateConn());
        //        //da.Fill(dt_storeProcedure);
        //        //return dt_storeProcedure;

        //        SqlConnection con = CreateConn();
        //        using (SqlCommand cmd = new SqlCommand(spWithParams, con))
        //        {
        //            cmd.CommandTimeout = 600;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            // set up the parameters                    
        //            SqlParameter errorMessage =  cmd.Parameters.Add("@ErrorMsg", SqlDbType.VarChar,1000);//.Direction = 
        //            errorMessage.Direction = ParameterDirection.Output;
        //            SqlParameter retVal = cmd.Parameters.Add("@ReturnValue", SqlDbType.Int);//.Direction = 
        //            retVal.Direction = ParameterDirection.ReturnValue;
        //            // open connection and execute stored procedure
        //           // con.Open();
        //            cmd.ExecuteNonQuery();

        //            da.SelectCommand = cmd;

        //            da.Fill(ds);

        //            return ds.Tables[0];
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        CloseConn();
        //        MessageBox.Show(ex.Message);
        //        return null;
        //    }

        //}

        #endregion

        /// <summary>
        /// Insert_StoreProcedure/update when only insertion needed 
        /// </summary>

        public void ExecuteNonQuery(string SpWithParams)
        {
            UserRequest request = new UserRequest();
            request.Query = SpWithParams;
            request.TehsilId = UsersManagments._Tehsilid.ToString();
            client.executeNonQuery(request, UsersManagments.userToken);

        }

        /// <summary>
        /// selection_squery when Need data for databinding
        /// </summary>

        /// <summary>
        /// Executes Inserts and Updates Stored Procedures and return last Id as string
        /// </summary>
        /// <param name="SpWithParams"></param>
        /// <returns>LastId</returns>
        public string ExecInsertUpdateStoredProcedure(string SpWithParams)
        {
            UserRequest request = new UserRequest();
            request.Query = SpWithParams;
            request.TehsilId = UsersManagments._Tehsilid.ToString();
            return client.exexuteScalar(request, UsersManagments.userToken);
            //try
            //{
            //    string lastId = "0";
            //    SqlCommand cmd = new SqlCommand(SpWithParams, CreateConn());
            //    cmd.CommandTimeout = 600;
            //    object retVal =cmd.ExecuteScalar();
            //    lastId = retVal != null ? retVal.ToString() : "0";
            //    CloseConn();
            //    return lastId;

            //}
            //catch (Exception ex)
            //{
            //    CloseConn();
            //    MessageBox.Show(ex.Message);
            //    return "0";
            //}
        }

        /// <summary>
        /// Executes Inserts and Updates Stored Procedures and return last Id as string
        /// </summary>
        /// <param name="SpWithParams"></param>
        /// <returns>LastId</returns>
        public string ExecStoredProcedure(string SpWithParams, SqlCommand c)
        {
            UserRequest request = new UserRequest();
            request.Query = SpWithParams;
            //request.cmd = c;
            request.TehsilId = UsersManagments._Tehsilid.ToString();
            return client.executeCommand(request, UsersManagments.userToken);
        }
        public List<FardPersonImages> execGetFardPersonImages(string TehsilId,string TokenId, string PersonId, string FardPersonRecId, string Token)
        {
            return client.GetFardlPersonImages(TehsilId,TokenId, PersonId, FardPersonRecId, Token);
        }
        public string ExecStoredProcedure(string SpWithParams, UserRequestIwthPicBiometric userRequest)
        {
            //UserRequest request = new UserRequest();
            //request.Query = SpWithParams;
            ////request.cmd = c;
            //request.TehsilId = UsersManagments._Tehsilid.ToString();
            return client.exexuteScalarWithPicBio(userRequest, UsersManagments.userToken);
        }
        public string ExecStoredProcedure(string SpWithParams, UserRequestBioFard userRequest)
        {
            //UserRequest request = new UserRequest();
            //request.Query = SpWithParams;
            ////request.cmd = c;
            //request.TehsilId = UsersManagments._Tehsilid.ToString();
            return client.exexuteScalarWithPicBio(userRequest, UsersManagments.userToken);
        }
        public string ExecStoredProcedure(string SpWithParams, UserRequestUserProfile userRequest)
        {
            //UserRequest request = new UserRequest();
            //request.Query = SpWithParams;
            ////request.cmd = c;
            //request.TehsilId = UsersManagments._Tehsilid.ToString();
            return client.exexuteScalarWithPicBio(userRequest, UsersManagments.userToken);
        }

        /// <summary>
        /// Executes Inserts and Updates Stored Procedures and return last Id as string
        /// </summary>
        /// <param name="SpWithParams"></param>
        /// <returns>LastId</returns>
        public void ExecUpdateStoredProcedureWithNoRet(string SpWithParams)
        {
            UserRequest request = new UserRequest();
            request.Query = SpWithParams;
            request.TehsilId = UsersManagments._Tehsilid.ToString();
            client.exexuteScalar(request, UsersManagments.userToken);

        }
      
    }
}
