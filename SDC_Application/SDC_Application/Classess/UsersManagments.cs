using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDC_Application.Classess
{
    class UsersManagments
    {
        #region Variables GetSet Properties
        
        public static string _UserName;
        public static string _Password;
        public static int _Districid;
        public static int _Tehsilid;
        public static int _check;
        public static int _ServiceTypeId;
        public static string UserToken { get; set; }
        public static  int MozaId { get; set; }
        public static string MozaName { get; set; }
        public static int  UserId { get; set; }
        public static int NoPages { get; set; }
        public static string Personid { get; set; }
        public static string  LoginRecId { get; set; }

        public static int ServiceTypeId
        {
            get { return _ServiceTypeId; }

            set { _ServiceTypeId = value; }
        }


        public static string UserName
        {
            get { return _UserName; }

            set { _UserName = value; }
        }

        public static int check
        {
            get { return _check; }

            set { _check = value; }
        }

        public static string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }

    
        public int Districtid
        {
            get
            {
                return _Districid;
            }
            set
            {
                _Districid = value;
            }
        }
       
        public int Tehislid
        {
            get
            {
                return _Tehsilid;
            }
            set
            {
                _Tehsilid = value;
            }
        }
       

        #endregion
    }
}
