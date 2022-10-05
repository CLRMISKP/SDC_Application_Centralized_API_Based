using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.BL;
using System.Configuration;
using System.Net.NetworkInformation;
using SDC_Application.LanguageManager;
using System.Net;
using System.Text.RegularExpressions;

namespace SDC_Application.DL
{
    public partial class Login : Form
    {


        #region Class Variables

        UserMangement usm = new UserMangement();
        Database objDb = new Database();
        AutoComplete auto = new AutoComplete();
        LanguageConverter lang = new LanguageConverter();


        #endregion
        public Login()
        {
            InitializeComponent();            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            auto.FillComboDist(cmbDist, "DistrictnameUrdu", "DistrictId");//FillCombo("Proc_Entry_DistrictsAll", cmbDist, "DistrictnameUrdu", "DistrictId");
            //UsersManagments._Tehsilid =Convert.ToInt32( ConfigurationSettings.AppSettings["Tehsil"]!=null?ConfigurationSettings.AppSettings["Tehsil"]:"0");
        }



        #region Button Save

        private void btnSaveLogin_Click_1(object sender, EventArgs e)
        {     
            try
            {
                string externalip = new WebClient().DownloadString("http://checkip.dyndns.org/");
                Match match = Regex.Match(externalip, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
                if(match.Success)
                {
                    externalip = match.Value;
                }
                string login = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string encPass = Crypto.getEncryptedCode(txtPassword.Text.Trim());
                DataTable usr = usm.Authenticated(login, encPass,cmbTehsil.SelectedValue.ToString(), externalip);


                if (usr != null)
                {
                    if (usr.Rows.Count > 0)
                    {
                        string RetMessage=usr.Rows[0]["ReturnMessage"].ToString();
                        if (RetMessage == "Login Successfully")
                        {

                            saveLoginInfo();
                           frmMain mdi = new frmMain();
                           mdi.labelUser.Text = UsersManagments._UserName;
                           mdi.Show();
                            
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("صارف نام یا پاسوارڈ غلط ہے - دوبارہ کوشش کریں۔", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
        #region Save Login Info after login successsful

        private void saveLoginInfo()
        {
          
            try
            {
              var  macAddr =
                                       (
                                           from nic in NetworkInterface.GetAllNetworkInterfaces()
                                           where nic.OperationalStatus == OperationalStatus.Up
                                           select nic.GetPhysicalAddress().ToString()
                                       ).FirstOrDefault();
                string lastId = objDb.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Login_Details " + UsersManagments.UserId + "," + UsersManagments._Tehsilid + ",'" + UsersManagments.UserName + "','" + macAddr.ToString() + "',1");
                UsersManagments.LoginRecId = lastId;
            }
            catch (Exception)
            {
                string lastId = objDb.ExecInsertUpdateStoredProcedure("WEB_SP_INSERT_Users_Login_Details " + UsersManagments.UserId + "," + UsersManagments._Tehsilid + ",'" + UsersManagments.UserName + "','undefined', 1");
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
        #region Combobox District Selection Change Event
        private void cmbDist_SelectionChangeCommitted(object sender, EventArgs e)
        {
            auto.FillComboTehsilByDist(cmbTehsil, "TehsilNameUrdu", "TehsilId", cmbDist.SelectedValue.ToString()); //auto.FillCombo("Proc_Entry_Tehsils "+cmbDist.SelectedValue.ToString(), cmbTehsil, "TehsilNameUrdu", "TehsilId");
        }

        #endregion

        #region Combobox Tehsil Selection Change Event
        private void cmbTehsil_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UsersManagments._Tehsilid = Convert.ToInt32(cmbTehsil.SelectedValue.ToString());
        }
        #endregion

        #region Key Press Event Auto Language Conversion
        private void txtMalikName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 22 && e.KeyChar != 24 && e.KeyChar != 3 && e.KeyChar != 1 && e.KeyChar != 13)
            {
                if (e.KeyChar == Convert.ToChar((Keys.Back)))
                {

                }
                else
                {
                    e.KeyChar = lang.UrduChar(Convert.ToChar(e.KeyChar));
                }
            }
            else if (e.KeyChar == 1)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }
        }
        #endregion
    }
}
