using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.BL;
using SDC_Application.AL;
using System.Configuration;
using System.Net.NetworkInformation;

namespace SDC_Application.DL
{
    public partial class Login : Form
    {


        #region Class Variables

        UserMangement usm = new UserMangement();
        Database objDb = new Database();
        public string ver =  "3.0.2.34";
        frmSelectTehsil mfrmSelectTehsil = new frmSelectTehsil();
        frmSystemRegistration mSystemRegistration = new frmSystemRegistration();
        DataTable SystemInfo = new DataTable();
        Users user = new Users();
        String mac = "";
        String visibleWifis = "";

        #endregion
        public Login()
        {
            InitializeComponent();
            this.Text = "سروس ڈیلیوری سنٹر سسٹم   " + "( Version "+ver+" )";
        }

        
        private void Login_Load(object sender, EventArgs e)
        {

            //visibleWifis = new WifiUtils().GetVisibleWifiSSIDs_CSV();

            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text; DataGridViewHelper.addHelpterToAllFormGridViews(this);
            mac = string.Join(",", mfrmSelectTehsil.getmacs().Cast<String>().Select(p => p.ToString()));
            usm.currentPcMacs = mac;
            SystemInfo = usm.GetSystemInfo(System.Environment.MachineName, mac);

            if (SystemInfo.Rows.Count > 0)
            {
               // MessageBox.Show(UsersManagments._Tehsilid.ToString());
                int v;
                if (Int32.TryParse(SystemInfo.Rows[0]["SiteId"].ToString(), out v))
                {
                    UsersManagments._Tehsilid = v;
                    UsersManagments._rptPort = SDC_Application.Classess.Crypto.Decrypt(ConfigurationSettings.AppSettings["rptport"]);
                    UsersManagments._LocationId = Convert.ToInt32(SystemInfo.Rows[0]["RegId"]);
                    UsersManagments.MAC = SystemInfo.Rows[0]["MacAddress"].ToString();
                    UsersManagments.MachineName = SystemInfo.Rows[0]["MachineName"].ToString();
                    UsersManagments.IpAddress = SystemInfo.Rows[0]["IPAddress"].ToString();
                }
            }
            else
            {
              //  MessageBox.Show("System is not registered");
                mSystemRegistration.ShowDialog(this);
                if (mSystemRegistration.DialogResult == System.Windows.Forms.DialogResult.Abort || mSystemRegistration.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    mfrmSelectTehsil.Dispose();
                    this.Dispose();
                    Application.Exit();
                    return;

                }
                else
                {
                    GetLogin(mSystemRegistration.txtUser.Text.ToString().Trim(), mSystemRegistration.txtPass.Text.ToString().Trim());
                    //this.Hide();
                    this.BeginInvoke(new MethodInvoker(this.Hide));
                   // Login mlogin = new Login();
                   // this.Hide();
                   // mlogin.Dispose();

                }
            }

            //UsersManagments._Tehsilid = Convert.ToInt32(ConfigurationSettings.AppSettings["Tehsil"] != null ? ConfigurationSettings.AppSettings["Tehsil"] : "0");

            //if (UsersManagments._Tehsilid == -1 || UsersManagments._Tehsilid==0)
            //{
            //    //frmSelectTehsil mfrmSelectTehsil = new frmSelectTehsil();
            //    mfrmSelectTehsil.ShowDialog(this);

            //    if (mfrmSelectTehsil.TehsilIdSelected == -1)
            //    {
            //        MessageBox.Show("Select Tehsil ", "Tehsil not selected/Invalid Tehsil", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        mfrmSelectTehsil.ShowDialog(this);
            //    }

            //    if (mfrmSelectTehsil.DialogResult == System.Windows.Forms.DialogResult.OK)
            //    {

            //        UsersManagments._Tehsilid = mfrmSelectTehsil.TehsilIdSelected;
            //    }
            //    else
            //    {
            //        System.Windows.Forms.Application.Exit();
            //    }

            //}

            
            
        }



        #region Button Save

        private void btnSaveLogin_Click_1(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = user.GetMachineAccessControl("", mac);
            if(dt!=null)
            {
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToBoolean(dt.Rows[0]["isAllowedToLogin"].ToString()) && Convert.ToDateTime(dt.Rows[0]["LogOutTime"].ToString()).TimeOfDay >= (DateTime.Now.TimeOfDay) && (DateTime.Now.TimeOfDay) >= Convert.ToDateTime(dt.Rows[0]["LoginTime"].ToString()).TimeOfDay)
                    {
                        GetLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                    }
                    else
                        MessageBox.Show("You are not allowed to login to CLRMIS before (" + Convert.ToDateTime(dt.Rows[0]["LoginTime"].ToString()).TimeOfDay + ") and after (" + Convert.ToDateTime(dt.Rows[0]["LogOutTime"].ToString()).TimeOfDay.ToString() + ")");
                }
                else
                    GetLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            }
            else
                GetLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            //try
            //{
            //    string login = txtUsername.Text.Trim();
            //    string password = txtPassword.Text.Trim();
            //    string encPass = Crypto.getEncryptedCode(txtPassword.Text.Trim());

            //    DataTable usr = usm.Authenticated(login, encPass, UsersManagments._Tehsilid.ToString(),ver);
                
            //    if (usr != null)
            //    {
            //        if (usr.Rows.Count > 0)
            //        {
            //            string RetMessage=usr.Rows[0]["ReturnMessage"].ToString();
            //            if (RetMessage == "Login Successfully")
            //            {

            //                saveLoginInfo();



            //               frmMain mdi = new frmMain();
            //               mdi.labelUser.Text = UsersManagments._UserName + "    :موجودہ صارف ";
            //               mdi.Show();
            //               UsersManagments.LoginAttempts = 0; 
            //                this.Hide();
            //            }
                           
            //            else if (RetMessage == "Invalid Version")
            //            {
            //                MessageBox.Show("ورژن " + UsersManagments._Ver + " استعمال کریں۔", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            else if (RetMessage == "RO")
            //            {
            //                MessageBox.Show("آپ مطوبہ سروسز کے لئے اھل نہیں ہیں", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            else
            //            {
            //                MessageBox.Show("صارف نام یا پاسوارڈ غلط ہے - دوبارہ کوشش کریں۔", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            UsersManagments.LoginAttempts += 1;
            //            //MessageBox.Show(UsersManagments.LoginAttempts.ToString());
            //        }
            //        else
            //        {
            //           MessageBox.Show(usr.Rows[0][0].ToString());
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            
        }
        #region Save Login Info after login successsful

        private void saveLoginInfo()
        {
          
            try
            {
                var macAddr = this.mac;
                                       /*(
                                           from nic in NetworkInterface.GetAllNetworkInterfaces()
                                           where nic.OperationalStatus == OperationalStatus.Up
                                           select nic.GetPhysicalAddress().ToString()
                                       ).FirstOrDefault();*/

              string lastId = objDb.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Login_Details_withWifis " + UsersManagments.UserId + "," + UsersManagments._Tehsilid + ",'" + UsersManagments.UserName + "','" + macAddr.ToString() + "',1"+",'"+this.visibleWifis + "'");
              UsersManagments.LoginRecId = lastId;
            }
            catch (Exception)
            {
                string lastId = objDb.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Login_Details_withWifis " + UsersManagments.UserId + "," + UsersManagments._Tehsilid + ",'" + UsersManagments.UserName + "','undefined', 1,NULL");
                UsersManagments.LoginRecId = lastId;
            }
           
            

        }

        #endregion


        #endregion Button Save
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (e.KeyChar == (char)13)
            {
                btnSaveLogin_Click_1(sender, e);
            }
        }

        public void GetLogin(String UserName,String Password)
        {
            try
            {

               // string login = txtUsername.Text.Trim();
               // string password = txtPassword.Text.Trim();
                string encPass = Crypto.getEncryptedCode(Password);


                DataTable usr = usm.Authenticated(UserName, encPass, UsersManagments._Tehsilid.ToString(), ver);

                if (usr != null)
                {
                    if (usr.Rows.Count > 0)
                    {
                        string RetMessage = usr.Rows[0]["ReturnMessage"].ToString();
                        if (RetMessage == "Login Successfully")
                        {

                            if (UsersManagments._Tehsilid == -1 || UsersManagments._Tehsilid == 0)
                            {
                                frmSelectTehsil mfrmSelectTehsil = new frmSelectTehsil();
                                mfrmSelectTehsil.ShowDialog(this);

                                if (mfrmSelectTehsil.TehsilIdSelected == -1)
                                {
                                    MessageBox.Show("Select Tehsil ", "Tehsil not selected/Invalid Tehsil", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    mfrmSelectTehsil.ShowDialog(this);
                                }

                                if (mfrmSelectTehsil.DialogResult == System.Windows.Forms.DialogResult.OK)
                                {

                                    UsersManagments._Tehsilid = mfrmSelectTehsil.TehsilIdSelected;
                                }
                                else
                                {
                                    System.Windows.Forms.Application.Exit();
                                }

                            }

                            saveLoginInfo();



                            frmMain mdi = new frmMain();
                            mdi.labelUser.Text = UsersManagments._UserName + "    :موجودہ صارف ";
                            mdi.Show();
                            UsersManagments.LoginAttempts = 0;
                            this.Hide();
                        }

                        else if (RetMessage == "Invalid Version")
                        {
                            MessageBox.Show("ورژن " + UsersManagments._Ver + " استعمال کریں۔", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (RetMessage == "RO")
                        {
                            MessageBox.Show("آپ مطوبہ سروسز کے لئے اھل نہیں ہیں", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("صارف نام یا پاسوارڈ غلط ہے - دوبارہ کوشش کریں۔", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        UsersManagments.LoginAttempts += 1;
                        //MessageBox.Show(UsersManagments.LoginAttempts.ToString());
                    }
                    else
                    {
                        MessageBox.Show(usr.Rows[0][0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
