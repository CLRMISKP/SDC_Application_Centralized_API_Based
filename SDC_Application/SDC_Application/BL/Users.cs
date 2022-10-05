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
            string spWithParam = "WEB_SP_DELETE_AdminRoleDetail'" + Roledetailid + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable getProfile(string tehsilid)
        {
            string spWithParam = "Proc_Get_UserProfile '" + tehsilid+"'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable getRoleObjectdetails(string roleid)
        {
            string spWithParam = "Proc_Get_Admin_RolesDetail_SDC '" + roleid + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable getAllobjectsroles()
        {
            string spWithParam = "Proc_Get_Admin_Objects ";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable getRoleName(string tehsilid)
        {
            string spWithParam = "Proc_Get_Admin_Roles '" + tehsilid+"'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable getAdminRoleid(string userid)
        {
            string spWithParam = "Proc_Get_AdminUserRoleId '" + userid + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public string SaveUserRole(string AdminUserRoleId, string tehsilid, string userid, string roleid,string userinsertid,string loginname)
        {
            string spWithParam = "WEB_SP_INSERT_Admin_UserRoles " + AdminUserRoleId + "," + tehsilid + "," + userid + ",'" + roleid + "','" + userinsertid + "','" + loginname + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string SaveRole(string roleid,string tehsilid,string rolename,string allaccess)
        {
            string spWithParam = "WEB_SP_INSERT_Admin_Roles " + roleid + "," + tehsilid + ",'" + rolename + "','" + allaccess + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveObjectDetails(string RoleDetailId, string roleid, string roleobjectid)
        {
            string spWithParam = "WEB_SP_INSERT_Admin_RoleDetail " + RoleDetailId + "," + roleid + "," + roleobjectid + ",'True','True','True','True'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string UpdateUserPassword(string userId, string Password)
        {
            string spWithParam = "WEB_SP_Update_Users_Password " + userId + ",'" + Password + "'" ;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string WEB_SP_INSERT_Users_Profile(string UserId, string TehsilId, string FirstName, string LastName, string LoginName, string Password, string InsertUserId,bool recstatus, byte[] FingerPrint, bool isRO)
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
    }
}
