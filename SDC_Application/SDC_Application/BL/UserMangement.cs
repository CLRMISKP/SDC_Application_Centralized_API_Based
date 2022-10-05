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
        public DataTable Authenticated(string Login, string Password, string tehsilId, string IP)
        {

            try
            {
                DataTable users = new DataTable();
                users = ojbdb.AthenticateUser("WEB_SP_AdminAthunticateUser '" + Login + "', '" + Password + "'," + tehsilId, tehsilId, IP); //AuthenticateUser(Login, Password, tehsilId);
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
                            UsersManagments._Districid = Convert.ToInt32(row["DistrictId"]);
                            UsersManagments._Tehsilid = Convert.ToInt32(row["TehsilId"]);
                            UsersManagments.Password = row["Password"].ToString();
                            UsersManagments.UserToken= row["Token"].ToString();
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

        public DataTable AuthenticateUser(string Login, string Password, string  tehsilId)
            {
            string spWithParam = "WEB_SP_AdminAthunticateUser '"+Login+"', '"+Password+"'," + tehsilId;
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
    }                                       
}                                           
