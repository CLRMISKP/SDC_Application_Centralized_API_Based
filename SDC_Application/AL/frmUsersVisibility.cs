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
    public partial class frmUsersVisibility : Form
    {

        DataTable dt = new DataTable();
        Users ObjUser = new Users();
        public string Role { get; set; }
        public string UserIdMain { get; set; }
        public frmUsersVisibility()
        {
            InitializeComponent();
        }

        private void frmUsersTokenRole_Load(object sender, EventArgs e)
        {
            txtUserId.Text = "-1";
            UserIdMain = "-1";
            LoadExistingProfiles();
        }

        public void LoadExistingProfiles()
        {
            string TehsilId = UsersManagments._Tehsilid.ToString();
            dt = ObjUser.getUserVisibility(TehsilId);
            dgExistingUsers.DataSource=dt;

            dgExistingUsers.Columns["UserId"].Visible = false;
            dgExistingUsers.Columns["UserId_Visibility"].Visible = false;
           
        }

        
        private void dgExistingUsers_DoubleClick(object sender, EventArgs e)
        {
            txtUserId.Text = dgExistingUsers.CurrentRow.Cells["UserId_Visibility"].Value.ToString();
            UserIdMain = dgExistingUsers.CurrentRow.Cells["UserId"].Value.ToString();
            txtFirstName.Text = dgExistingUsers.CurrentRow.Cells["FirstName"].Value.ToString();
            txtLastName.Text = dgExistingUsers.CurrentRow.Cells["LastName"].Value.ToString();
            txtLoginId.Text = dgExistingUsers.CurrentRow.Cells["LoginName"].Value.ToString();

            if (dgExistingUsers.CurrentRow.Cells["TransFard"].Value.ToString() == "No" || dgExistingUsers.CurrentRow.Cells["TransFard"].Value.ToString() == "")
            {
                cbTransFard.Checked = false;
            }
            else
            {
                cbTransFard.Checked = true;
            }

            if (dgExistingUsers.CurrentRow.Cells["Intiqal"].Value.ToString() == "No" || dgExistingUsers.CurrentRow.Cells["Intiqal"].Value.ToString() == "")
            {
                cbIntiqal.Checked = false;
            }
            else
            {
                cbIntiqal.Checked = true;
            }

            if (dgExistingUsers.CurrentRow.Cells["Registry"].Value.ToString() == "No" || dgExistingUsers.CurrentRow.Cells["Registry"].Value.ToString() == "")
            {
                cbRegistry.Checked = false;
            }
            else
            {
                cbRegistry.Checked = true;
            }

            if (dgExistingUsers.CurrentRow.Cells["Misal"].Value.ToString() == "No" || dgExistingUsers.CurrentRow.Cells["Misal"].Value.ToString() == "")
            {
                cbMisal.Checked = false;
            }
            else
            {
                cbMisal.Checked = true;
            }

            if (dgExistingUsers.CurrentRow.Cells["Implementation"].Value.ToString() == "No" || dgExistingUsers.CurrentRow.Cells["Implementation"].Value.ToString() == "")
            {
                cbImplementation.Checked = false;
            }
            else
            {
                cbImplementation.Checked = true;
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

                    string TransFard = "";
                    string Intiqal = "";
                    string Registry = "";
                    string Misal = "";
                    string Implementation = "";


                    if (cbTransFard.Checked == true)
                    { TransFard = "1"; }
                    else
                    { TransFard = "0"; }

                    if (cbIntiqal.Checked == true)
                    { Intiqal = "1"; }
                    else
                    { Intiqal = "0"; }

                    if (cbRegistry.Checked == true)
                    { Registry = "1"; }
                    else
                    { Registry = "0"; }

                    if (cbMisal.Checked == true)
                    { Misal = "1"; }
                    else
                    { Misal = "0"; }

                    if (cbImplementation.Checked == true)
                    { Implementation = "1"; }
                    else
                    { Implementation = "0"; }


                    string LastId = ObjUser.WEB_Self_SP_Update_Users_Visibility(UserIdMain,UserId, TransFard, Intiqal, Registry, Misal, Implementation);
                    if (LastId != string.Empty)
                    {
                        MessageBox.Show("User has been Updated");
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
            UserIdMain = "-1";
            this.txtFirstName.Clear();
            this.txtLastName.Clear();
            this.txtLoginId.Clear();
           
            this.cbTransFard.Checked = false;
            this.cbIntiqal.Checked = false;
            this.cbRegistry.Checked = false;
            this.cbImplementation.Checked = false;
            this.cbMisal.Checked = false;
           
        }

        private void txtSerach_TextChanged(object sender, EventArgs e)
        {
            if (this.dgExistingUsers.Rows.Count > 0)
            {

                for (int i = 0; i <= dgExistingUsers.Rows.Count - 1; i++)
                {

                    if (dgExistingUsers.Rows[i].Cells["FirstName"].Value.ToString().Contains(txtSerach.Text.Trim()))
                    {

                        dgExistingUsers.Rows[i].Visible = true;
                    }
                    else
                    {

                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dgExistingUsers.DataSource];
                        currencyManager1.SuspendBinding();
                        dgExistingUsers.Rows[i].Visible = false;
                        currencyManager1.ResumeBinding();
                        dgExistingUsers.Rows[i].Visible = false;


                    }
                }


            }
        }

    }
}
