using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.LanguageManager;
using SDC_Application.Classess;
using SDC_Application.BL;
using System.Collections;

namespace SDC_Application.AL
{
    public partial class frmUserChangePassword : Form
    {

        DataTable dt = new DataTable();
        Users ObjUser = new Users();
       
        public frmUserChangePassword()
        {
            InitializeComponent();
        }

       

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            string oldPasswrd = Crypto.getEncryptedCode(txtUserOldPassword.Text);
            string newPasswrd = Crypto.getEncryptedCode(txtUserNewPassword.Text);
            if (UsersManagments.Password == oldPasswrd)
            {
                if (txtUserConfPassword.Text == txtUserNewPassword.Text)
                {
                    string lastId = ObjUser.UpdateUserPassword(UsersManagments.UserId.ToString(), newPasswrd);
                    if (lastId != null)
                    {
                        MessageBox.Show("Password Sucessfully Updated..", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("New Password and Cconfirm password not match", "Password Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Old Password not match", "Password Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUserChangePassword_Load(object sender, EventArgs e)
        {
            this.txtUserLoginName.Text = UsersManagments.UserName;
            this.txtUserId.Text = UsersManagments.UserId.ToString();
        }

    }
}
