using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.DL;
using SDC_Application.Classess;
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class frmAssignRole : Form
    {
        public string  RoleName { get; set; }
        public string Roleid { get; set; }
        public string AdminUserRoleId { get; set; }
        public string userid{get;set;}
        public string userinsertedid { get; set; }
        public string LoginName { get; set; }
        public bool btn { get; set; }
        public bool bMultiple { get; set; }
        DL.Database obj = new Database();
        BL.Users objuserrole = new BL.Users();



        public frmAssignRole()
        {
            InitializeComponent();
            bMultiple = false;
        }

        private void frmAssignRole_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt = objuserrole.getRoleName(UsersManagments._Tehsilid.ToString());
            this.grdroles.DataSource = dt;
            grdroles.Columns["RoleStatus"].Visible = false;
            grdroles.Columns["RoleId"].Visible = false;
           
        }

        private void grdroles_DoubleClick(object sender, EventArgs e)
        {
            string last;
           
            userinsertedid = UsersManagments.UserId.ToString();
            this.Roleid=grdroles.CurrentRow.Cells["RoleId"].Value.ToString();
            this.RoleName = grdroles.CurrentRow.Cells["RoleName"].Value.ToString();
            if (AdminUserRoleId == null || AdminUserRoleId == string.Empty)
            {
                AdminUserRoleId = "-1";
            }

            if(bMultiple)
                last = objuserrole.SaveUserRoleMultiple(AdminUserRoleId, UsersManagments._Tehsilid.ToString(), userid, Roleid, userinsertedid, LoginName, bMultiple.ToString());
            else 
                last = objuserrole.SaveUserRole(AdminUserRoleId, UsersManagments._Tehsilid.ToString(), userid, Roleid, userinsertedid, LoginName , bMultiple.ToString());

            if (last != null)
            {
                btn = true;
                this.Close();
            }


        }

        private void grdroles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
