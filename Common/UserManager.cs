using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandInfo.Common
{
    public static class UserManager
    {
        /// <summary>
        /// Get or Set  User Id
        /// </summary>
        public static int UserId { get; set; }
        /// <summary>
        /// Get or Set User Login
        /// </summary>
        public static string UserLogin { get; set; }
        /// <summary>
        /// Get or Set Use first Name
        /// </summary>
        public static string FirstName { get; set; }
        /// <summary>
        /// Get or Set Last Name
        /// </summary>
        public static string LastName { get; set; }
        /// <summary>
        /// Get or Set Role Id
        /// </summary>
        public static int RoleId { get; set; }
        /// <summary>
        /// Get or Set Role Name
        /// </summary>
        public static string RoleName { get; set; }

        public static bool Authenticated(string Login,string Password)
        {
            bool result;
            if ( Login == "admin" && Password == "admin" )
            {
                result = true;
                UserId = 1;
                UserLogin = Login;
                FirstName = Login;
                LastName = Login;
                RoleId = 1;
                RoleName = Login;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
