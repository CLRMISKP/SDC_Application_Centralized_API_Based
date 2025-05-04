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
                    string validationResult = ValidatePassword(txtUserNewPassword.Text);

                    if (validationResult == "Password is valid")
                    {
                        string lastId = ObjUser.UpdateUserPassword(UsersManagments.UserId.ToString(), newPasswrd);
                        if (lastId != null)
                        {
                            MessageBox.Show("پاسوارڈ تبدیل ہو گیاہے۔۔۔", "Change Password Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    else
                        {
                        MessageBox.Show(validationResult, "Invalid Password",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUserNewPassword.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("نیا اور پرانا پاسوارڈ نہیں ملتے۔", "Password Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(" پرانا پاسوارڈ غلط ہے۔", "Old Password Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmUserChangePassword_Load(object sender, EventArgs e)
        {
            this.txtUserLoginName.Text = UsersManagments.UserName;
            this.txtUserId.Text = UsersManagments.UserId.ToString();
        }
        public  string ValidatePassword(string password)
        {
            // Minimum length check
            if (password.Length < 8)
                return "Password must be at least 8 characters long";

            // Check for at least one uppercase letter
            if (!password.Any(char.IsUpper))
                return "Password must contain at least one uppercase letter";

            // Check for at least one lowercase letter
            if (!password.Any(char.IsLower))
                return "Password must contain at least one lowercase letter";

            // Check for at least one number
            if (!password.Any(char.IsDigit))
                return "Password must contain at least one number";

            // Check for at least one special character
            if (!password.Any(c => !char.IsLetterOrDigit(c)))
                return "Password must contain at least one special character";

            // Check for common passwords
            string[] commonPasswords = { "password", "123456", "qwerty", "letmein", "admin" };
            if (commonPasswords.Contains(password.ToLower()))
                return "Password is too common, please choose a stronger one";

            // All checks passed
            return "Password is valid";
        }
        private int CalculatePasswordStrength(string password)
        {
            int strength = 0;

            // Length contributes up to 3 points
            strength += Math.Min(3, password.Length / 4);

            // Add points for complexity
            if (password.Any(char.IsUpper)) strength++;
            if (password.Any(char.IsLower)) strength++;
            if (password.Any(char.IsDigit)) strength++;
            if (password.Any(c => !char.IsLetterOrDigit(c))) strength++;

            return Math.Min(5, strength); // Cap at 5 for simplicity
        }

        private void txtUserNewPassword_TextChanged(object sender, EventArgs e)
        {
            int strength = CalculatePasswordStrength(txtUserNewPassword.Text);

            switch (strength)
            {
                case 0:
                case 1:
                    lblStrength.Text = "Very Weak";
                    lblStrength.ForeColor = Color.Red;
                    break;
                case 2:
                    lblStrength.Text = "Weak";
                    lblStrength.ForeColor = Color.OrangeRed;
                    break;
                case 3:
                    lblStrength.Text = "Medium";
                    lblStrength.ForeColor = Color.Orange;
                    break;
                case 4:
                    lblStrength.Text = "Strong";
                    lblStrength.ForeColor = Color.Green;
                    break;
                case 5:
                    lblStrength.Text = "Very Strong";
                    lblStrength.ForeColor = Color.DarkGreen;
                    break;
            }
        }

        private void txtUserNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtUserConfPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
