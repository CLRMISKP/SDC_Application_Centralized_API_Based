using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDC_Application.DL;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.Classess;

namespace SDC_Application.BL
{
    class UserMangement
    {
        #region Class Variables

        Database ojbdb = new Database();

        #endregion

        /// <summary>
        /// autheticate user naem and password and return false or true on basis of authetication
        /// </summary>
        /// <param name="Login">User Name</param>
        /// <param name="Password">Password</param>
        /// <returns></returns>
        public DataTable Authenticated(string Login, string Password, string tehsilId,string ver)
        {

            try
            {
                DataTable users = new DataTable();
                users = AuthenticateUser(Login, Password, tehsilId,ver);
                    //new List<User_SP_AuthenticateUser_Result>();
                if (users.Rows.Count>0)
                {
                    string retMessage = users.Rows[0]["ReturnMessage"].ToString();
                    if (retMessage == "Login Successfully")
                    {
                        //result = true;
                        foreach (DataRow row in users.Rows)
                        {
                            string a = row["UserId"].ToString();
                            UsersManagments.UserId = Convert.ToInt32(a);
                            UsersManagments.UserName = row["LoginName"].ToString();
                           // UsersManagments._Districid = Convert.ToInt32(row["DistrictId"]);
                            UsersManagments._Tehsilid = Convert.ToInt32(row["TehsilId"]);
                            UsersManagments.Password = row["Password"].ToString();
                            UsersManagments._Ver = row["ver"].ToString();
                            UsersManagments._RoleName = row["RoleName"].ToString();
                            UsersManagments._IsAdmin = Convert.ToBoolean(row["IsAdmin"]);
                            UsersManagments.TransFard = row["TransFard"].ToString();
                            UsersManagments.Intiqal = row["Intiqal"].ToString();
                            UsersManagments.Registry = row["Registry"].ToString();
                            UsersManagments.Misal = row["Misal"].ToString();
                            UsersManagments.Implementation = row["Implementation"].ToString();
                            UsersManagments.SubSdcId = Convert.ToInt32(row["SubSDCId"].ToString().Length > 0 && row["SubSDCId"].ToString()!="null"? row["SubSDCId"].ToString() : "0");
                            //UsersManagments = row["DistrictNameUrdu"];
                            // = row["tehsilNameUrdu"];
                            //CurrentUser.UserName =  row["username"];
                            //CurrentUser.serverId=data.se
                            //CurrentUser.FirstName = data.FirstNam;
                            //CurrentUser.LastName = data.LastName;
                            //CurrentUser.RoleId = Convert.ToInt32(data.RoleId);
                            //CurrentUser.RoleName = data.RoleName;
                        }
                    }
                    else
                    {
                        //result = true;
                        foreach (DataRow row in users.Rows)
                        {
                           
                            UsersManagments._Ver = row["ver"].ToString();
                           
                        }
                    }
                }
                else
                {
                    //////
                }
                return users;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Un-able to connect to the server! Please check your network connectivity and make sure that server is running");
                return null;
            }
        }

        public DataTable AuthenticateUser(string Login, string Password, string  tehsilId, string ver)
            {
                string spWithParam = "CLRMIS_AthunticateUser '" + Login + "', '" + ver + "', '" + Password + "'," + tehsilId;
                return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            }

        #region Insert User Profile

        //public string SaveUserProfile(string UserId, string TehsilId, string  FirstName, string  LastName, string   LoginName, string   Password, byte[] FingerPrint, string InsertUserId)
        //{
        //    object[] ParamsList = { UserId, TehsilId, "N'" + FirstName + "'", "N'" + LastName + "'", "N'" + LoginName + "'", "N'" + Password + "'", FingerPrint, InsertUserId };
        //  //  return ojbdb.ExecInsertUpdateStoredProcedureWithParams("WEB_SP_INSERT_Users_Profile", ParamsList);  
        //}                                       

        #endregion  

        #region Get User Profiles

        public DataTable GetUserProfiles(string TehsilId)
        {
            string spWithParam = "Proc_Get_Admin_Users_By_Tehsil "+ TehsilId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }

        #endregion
        #region Get User Profiles from DLRR USER MANAGEMENT DB

        public DataTable GetUserProfilesFromDLRR_User_Management(string TehsilId)
        {
            string spWithParam = "Proc_Get_Admin_Users_By_Tehsil_DE_Zerekar " + TehsilId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }

        #endregion

        public DataTable GetSystemInfo(String MachineName, String mac)
        {
            String spWithParam = "CLRMIS_SystemRegistrationLog_get '" + MachineName + "','" + mac + "'";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetUserInfo(String UserName, String Pass)
        {
            String spWithParam = "CLRMIS_getAdminUserInfo '" + UserName + "','" + Pass + "'";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetUserInfo2(String UserName, String Pass ,out string error , out int ret)
        {
            String spWithParam = "CLRMIS_getAdminUserInfo '" + UserName + "','" + Pass + "'";
            error = null;
            ret = 0;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //return ojbdb.filldatatable_from_storedProcedureWithReturnVals(spWithParam,out ret,out error);
        }


    }                                       
}                                           
