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
    public partial class frmUsersTokenRole : Form
    {

        DataTable dt = new DataTable();
        Users ObjUser = new Users();
        public string Role { get; set; }
        public string Adminuserroldid { get; set; }
        public frmUsersTokenRole()
        {
            InitializeComponent();
        }

        private void frmUsersTokenRole_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            txtUserId.Text = "-1";
            LoadExistingProfiles();
        }

        public void LoadExistingProfiles()
        {
            string TehsilId = UsersManagments._Tehsilid.ToString();
            dt = ObjUser.getTokenRole(TehsilId);
            dgExistingUsers.DataSource=dt;

            dgExistingUsers.Columns["TokenRole"].Visible = false;

            dgExistingUsers.Columns["UserId"].Visible = false;
            
        }

        
        private void dgExistingUsers_DoubleClick(object sender, EventArgs e)
        {
            txtUserId.Text = dgExistingUsers.CurrentRow.Cells["UserId"].Value.ToString();
            txtFirstName.Text = dgExistingUsers.CurrentRow.Cells["FirstName"].Value.ToString();
            txtLastName.Text = dgExistingUsers.CurrentRow.Cells["LastName"].Value.ToString();
            txtLoginId.Text = dgExistingUsers.CurrentRow.Cells["LoginName"].Value.ToString();

            if (dgExistingUsers.CurrentRow.Cells["TokenRole"].Value.ToString() == "0")
            {
                cbFard.Checked = true;
                cbIntiqal.Checked = true;
                cbRegistry.Checked = true;

            }

            else if (dgExistingUsers.CurrentRow.Cells["TokenRole"].Value.ToString() == "1")
            {
                cbFard.Checked = true;
                cbIntiqal.Checked = false;
                cbRegistry.Checked = false;

            }

            else if (dgExistingUsers.CurrentRow.Cells["TokenRole"].Value.ToString() == "2")
            {
                cbFard.Checked = false;
                cbIntiqal.Checked = true;
                cbRegistry.Checked = false;

            }
            else if (dgExistingUsers.CurrentRow.Cells["TokenRole"].Value.ToString() == "3")
            {
                cbFard.Checked = false;
                cbIntiqal.Checked = false;
                cbRegistry.Checked = true;

            }
            else if (dgExistingUsers.CurrentRow.Cells["TokenRole"].Value.ToString() == "4")
            {
                cbFard.Checked = true;
                cbIntiqal.Checked = true;
                cbRegistry.Checked = false;

            }
            else if (dgExistingUsers.CurrentRow.Cells["TokenRole"].Value.ToString() == "5")
            {
                cbFard.Checked = true;
                cbIntiqal.Checked = false;
                cbRegistry.Checked = true;

            }
            else if (dgExistingUsers.CurrentRow.Cells["TokenRole"].Value.ToString() == "6")
            {
                cbFard.Checked = false;
                cbIntiqal.Checked = true;
                cbRegistry.Checked = true;

            }
            else if (dgExistingUsers.CurrentRow.Cells["TokenRole"].Value.ToString() == "-1")
            {
                cbFard.Checked = false;
                cbIntiqal.Checked = false;
                cbRegistry.Checked = false;

            }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            SaveTokenRole();
            this.ResetFields();
        }

        private void SaveTokenRole()
        {
            try
            {
               
                if (txtUserId.Text!= "-1")
                {

                    string UserId = txtUserId.Text.ToString();
                    string FirstName = txtFirstName.Text.ToString();
                    string LastName = txtLastName.Text.ToString();
                    string LoginId = txtLoginId.Text.ToString();
                   
                    string Insertuserid = UsersManagments.UserId.ToString();
                    string TehsilID = UsersManagments._Tehsilid.ToString();
                    string TokenRole = "";


                    if (cbFard.Checked == true && cbIntiqal.Checked == true && cbRegistry.Checked == true)
                    { TokenRole = "0"; }
                    else if (cbFard.Checked == true && cbIntiqal.Checked == false && cbRegistry.Checked == false)
                    { TokenRole = "1"; }
                    else if (cbFard.Checked == false && cbIntiqal.Checked == true && cbRegistry.Checked == false)
                    { TokenRole = "2"; }
                    else if (cbFard.Checked == false && cbIntiqal.Checked == false && cbRegistry.Checked == true)
                    { TokenRole = "3"; }
                    else if (cbFard.Checked == true && cbIntiqal.Checked == true && cbRegistry.Checked == false)
                    { TokenRole = "4"; }
                    else if (cbFard.Checked == true && cbIntiqal.Checked == false && cbRegistry.Checked == true)
                    { TokenRole = "5"; }
                    else if (cbFard.Checked == false && cbIntiqal.Checked == true && cbRegistry.Checked == true)
                    { TokenRole = "6"; }
                    else if (cbFard.Checked == false && cbIntiqal.Checked == false && cbRegistry.Checked == false)
                    { TokenRole = "-1"; }
                   


                    string LastId = ObjUser.WEB_Self_SP_Update_Users_TokenRole(Insertuserid, UserId,TokenRole);
                    if (LastId != string.Empty)
                    {
                        MessageBox.Show("User has been submitted");
                        txtUserId.Text = LastId;
                        LoadExistingProfiles();
                    }

                }
                else
                {
                    MessageBox.Show( "- صارف سیلیکٹ کریں", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ResetFields()
        {
            this.txtUserId.Text = "-1";
            this.txtFirstName.Clear();
            this.txtLastName.Clear();
            this.txtLoginId.Clear();
           
            this.cbFard.Checked = false;
            this.cbIntiqal.Checked = false;
            this.cbRegistry.Checked = false;
        }

    }
}
