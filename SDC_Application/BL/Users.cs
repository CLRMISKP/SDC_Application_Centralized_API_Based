using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.DL;

namespace SDC_Application.BL
{
    class Users
    {
        DL.Database dbobject = new Database();
        //Database ojbdb = new Database();
        //Proc_Get_Admin_Roles
        //[]
         
        public DataTable DeleteRoleDetail(string Roledetailid)
        {
            string spWithParam = "WEB_SP_DELETE_AdminRoleDetail " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + Roledetailid + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable DeleteAdmin_UserRoles(string UserId,string RoleName)
        {
            string spWithParam = "WEB_SP_DELETE_AdminRoleDetail_byUserId_and_RoleId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + UserId + "','" + RoleName + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable getProfile(string tehsilid)
        {
            string spWithParam = "Proc_Get_UserProfile '" + tehsilid+"'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable getTokenRole(string tehsilid)
        {
            string spWithParam = "Proc_Self_Get_UserProfile '" + tehsilid + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }


        // SDC_Application.AL.UsersManagments.UserId.ToString();
        public bool isObjectExists(int UserID, int Object)
        {
            String Info = "";            
            string spWithParam = "isObjectExists  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + UserID.ToString() + "," + Object.ToString() + ",'" + Info+"'";
            String Err_Msg; int RetVal;
             dbobject.filldatatable_from_storedProcedureWithReturnVals(spWithParam,out RetVal,out Err_Msg);
             return RetVal == 0 ? false : true;
        }
          

        public DataTable getRoleObjectdetails(string roleid)
        {
            string spWithParam = "Proc_Get_Admin_RolesDetail_SDC  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + roleid + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable getAllobjectsroles()
        {
            string spWithParam = "Proc_Get_Admin_Objects  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable getRoleName(string tehsilid)
        {
            string spWithParam = "Proc_Get_Admin_Roles '" + tehsilid+"'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable getAdminRoleid(string userid)
        {
            string spWithParam = "Proc_Get_AdminUserRoleId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + userid + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public string SaveUserRole(string AdminUserRoleId, string tehsilid, string userid, string roleid,string userinsertid,string loginname, string bMultiple)
        {
            string spWithParam = "WEB_SP_INSERT_Admin_UserRoles " + AdminUserRoleId + "," + tehsilid + "," + userid + ",'" + roleid + "','" + userinsertid + "','" + loginname +"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string SaveUserRoleMultiple(string AdminUserRoleId, string tehsilid, string userid, string roleid, string userinsertid, string loginname, string bMultiple)
        {
            string spWithParam = "WEB_SP_INSERT_Admin_UserRolesMultiple " + AdminUserRoleId + "," + tehsilid + "," + userid + ",'" + roleid + "','" + userinsertid + "','" + loginname + "','" + bMultiple + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveRole(string roleid,string tehsilid,string rolename,string allaccess)
        {
            string spWithParam = "WEB_SP_INSERT_Admin_Roles " + roleid + "," + tehsilid + ",'" + rolename + "','" + allaccess + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveObjectDetails(string RoleDetailId, string roleid, string roleobjectid)
        {
            string spWithParam = "WEB_SP_INSERT_Admin_RoleDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + RoleDetailId + "," + roleid + "," + roleobjectid + ",'True','True','True','True'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string UpdateUserPassword(string userId, string Password)
        {
            string spWithParam = "WEB_SP_Update_Users_Password  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + userId + ",'" + Password + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string WEB_SP_INSERT_Users_Profile(string UserId, string TehsilId, string FirstName, string LastName, string LoginName, string Password, string InsertUserId, bool recstatus, byte[] FingerPrint, bool isRO)
        {
            string lastId = "";
            SqlCommand mycomm = new SqlCommand();
            
            mycomm.Parameters.AddWithValue("@UserId", UserId);
            mycomm.Parameters.AddWithValue("@TehsilId", TehsilId);
            mycomm.Parameters.AddWithValue("@FirstName", FirstName);
            mycomm.Parameters.AddWithValue("@LastName", LastName);
            mycomm.Parameters.AddWithValue("@LoginName", LoginName);
            mycomm.Parameters.AddWithValue("@Password", Password);
            mycomm.Parameters.AddWithValue("@InsertUserId", InsertUserId);          
            mycomm.Parameters.AddWithValue("@FingerPrint", (FingerPrint == null) ? (object)DBNull.Value : FingerPrint).SqlDbType = SqlDbType.Image;            
            mycomm.Parameters.AddWithValue("@RecordStatus", recstatus);
            mycomm.Parameters.AddWithValue("@IsRevenueOfficer", isRO);
   
            try
            {
                lastId = dbobject.ExecStoredProcedure("WEB_SP_INSERT_Users_Profile", mycomm);

            }
            catch (Exception e)
            {
                throw e;
            }
            return lastId;
        }

        public string WEB_Self_SP_Update_Users_TokenRole(string InsertUserId, string UserId, string TokenRole)
        {
            string lastId = "";
            SqlCommand mycomm = new SqlCommand();

            mycomm.Parameters.AddWithValue("@Tehsilid", SDC_Application.Classess.UsersManagments._Tehsilid.ToString());
            mycomm.Parameters.AddWithValue("@InsertUserId", InsertUserId);
            mycomm.Parameters.AddWithValue("@UserId", UserId);
            mycomm.Parameters.AddWithValue("@TokenRole", TokenRole);

            try
            {
                lastId = dbobject.ExecStoredProcedure("WEB_Self_SP_Update_Users_TokenRole " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",", mycomm);

            }
            catch (Exception e)
            {
                throw e;
            }
            return lastId;
        }
        public DataTable getUserVisibility(string TehsilId)
        {
            string spWithParam = "Proc_Self_Get_UserVisibility  " + TehsilId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public string WEB_Self_SP_Update_Users_Visibility(string UserIdMain,string UserId, string TransFard,string  intiqal, string Registry, string  misal, string  Implementation)
        {
            string spWithParam = "WEB_Self_SP_Update_Users_Visibility  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + UserIdMain + "," + UserId + "," + TransFard + "," + intiqal + "," + Registry + "," + misal + "," + Implementation;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

        }
    }
}
