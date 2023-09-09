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
        public static string _Ver;
        public static int _check;
        public static int _ServiceTypeId;
        public static int MozaId { get; set; }
        public static string MozaName { get; set; }
        public static string TehsilNameUrdu { get; set; }
        public static int UserId { get; set; }
        public static int NoPages { get; set; }
        public static string Personid { get; set; }
        public static string LoginRecId { get; set; }
        public static int LoginAttempts = 0;
        public static string _rptPort;
        public static string _RoleName;
        public static Boolean _IsAdmin;
        public static int _LocationId;

        public static string TransFard { get; set; }
        public static string Intiqal { get; set; }
        public static string Registry { get; set; }
        public static string Misal { get; set; }
        public static string Implementation { get; set; }
        public static int SubSdcId { get; set; }

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

        public String rptPort
        {
            get
            {
                return _rptPort;
            }
            set
            {
                _rptPort = value;
            }
        }

        public String roleName
        {
            get
            {
                return roleName;
            }
            set
            {
                _RoleName = value;
            }
        }

        public Boolean IsAdmin
        {
            get
            {
                return IsAdmin;
            }
            set
            {
                _IsAdmin = value;
            }
        }

        public int LocationId
        {
            get
            {
                return LocationId;
            }
            set
            {
                _LocationId = value;
            }
        }

        #endregion
    }
}
