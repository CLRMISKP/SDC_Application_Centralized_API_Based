using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SDC_Application
{
    public class UserRequest
    {
        public string Query { get; set; }
        public string TehsilId { get; set; }
    }
    public class UserRequestIwthPicBiometric
    {
        public string Query { get; set; }
        public string TehsilId { get; set; }
        public string IntialPersonImageId { get; set; }
        public string IntiqalId { get; set; }
        public string PersonId { get; set; }
        public string PersonPic { get; set; }
        public string PersonFingerPrint { get; set; }
        public string InsertUserId { get; set; }
        public string InsertLoginName { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdateLoginName { get; set; }

    }
    public class UserRequestBioFard
    {
        public string Query { get; set; }
        public string TehsilId { get; set; }
        public string PersonFingerPrintId { get; set; }
        public string tokenId { get; set; }
        public string FardRepRecId { get; set; }
        public string PersonId { get; set; }
        public string PersonPic { get; set; }
        public string PersonFingerPrint { get; set; }
        public string InsertUserId { get; set; }
        public string InsertLoginName { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdateLoginName { get; set; }

    }
    public class UserRequestUserProfile
    {
        public string Query { get; set; }
        public string TehsilId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string FingerPrint { get; set; }
        public string InsertUserId { get; set; }
        public string IsRevenueOfficer { get; set; }
        public string RecordStatus { get; set; }
        public string RoleId { get; set; }

    }
    public class UserInfoForMachinReg
    {
        public string TehsilId { get; set; }
        public string DistrictId { get; set; }
        public string Query { get; set; }
    }
}
