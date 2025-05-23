﻿using System;
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
    public partial class frmUserManagement : Form
    {

        public byte[] imgDataFinger=null;
        DataTable dt = new DataTable();
        Users ObjUser = new Users();
        AutoComplete auto = new AutoComplete();
        public string Role { get; set; }
        public string Adminuserroldid { get; set; }
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private bool SaveUserPrifile()
        {
            bool resetFields = true;
            try
            {
                ArrayList Labels = new ArrayList();
                Labels.Add(lbl1.Text);
                Labels.Add(lbl2.Text);
                ArrayList collection = new ArrayList();
                string empty = null;
                collection.Add(this.txtFirstName.Text.ToString());
                collection.Add(this.txtLastName.Text.ToString());

                for (int i = 0; i <= collection.Count - 1; i++)
                {
                    if (Convert.ToString(collection[i]) == string.Empty || Convert.ToString(collection[i]) == "0")
                    {
                        empty += "," + Labels[i].ToString();
                    }
                }

                if (empty == null)
                {

                    string UserId = txtUserId.Text.ToString();
                    string FirstName = txtFirstName.Text.ToString();
                    string LastName = txtLastName.Text.ToString();
                    string LoginId = txtLoginId.Text.ToString();
                    string Password =Crypto.getEncryptedCode(txtPassword.Text.ToString());
                    string ConfirmPassword =Crypto.getEncryptedCode(txtConfPassword.Text.ToString());
                    if (Password != ConfirmPassword)
                    {
                        MessageBox.Show("Password will be unchanged as it does not matched with Confirmed");
                        Password = "";
                    }
                    string userid = UsersManagments.UserId.ToString();
                    string TehsilID =UsersManagments._Tehsilid.ToString();
                    bool isRO = chbIsRO.Checked;
                    string Status;
                    if (rbUserAcive.Checked)
                    { Status = "1"; }
                    else
                    { Status = "0"; }
                    bool recstatus=false;
                    if (rbUserAcive.Checked)
                    {
                        recstatus = true;
                    }
                    int iSelectedValue = -1;
                    if (this.cbUserRoles.SelectedIndex >= 0)
                    {
                        DataRowView drv = (DataRowView)this.cbUserRoles.SelectedItem;
                        int.TryParse(drv["RoleId"].ToString(), out iSelectedValue);
                    }
                    //imgDataFinger=
                    string Err_Msg = "";
                    string LastId = ObjUser.WEB_SP_INSERT_Users_Profile_withRoleId(UserId, TehsilID, FirstName, LastName, LoginId, Password, userid, recstatus, imgDataFinger, isRO, ((DataRowView)this.cbUserRoles.SelectedItem)["RoleId"].ToString(), out Err_Msg);
                    if(Err_Msg!=null){
                        string [] ar = Err_Msg.Split('|');
                        MessageBox.Show(ar[0]);
                        if (ar.Length > 1 && ar[1] == "INVALID_PASS") this.txtConfPassword.Focus();
                        resetFields = false;

                    }else if (LastId != string.Empty)
                    {                            
                        txtUserId.Text = LastId;
                        LoadExistingProfiles();
                        MessageBox.Show("User has been submitted");
                    }
                    
                }
                else
                {
                    MessageBox.Show(empty + "- کا اندراج کریں", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                 
            }
                return resetFields ;
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (SaveUserPrifile()) this.ResetFields();            
        }

        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            frmFingerPrint Populate = new frmFingerPrint();
            Populate.FormClosed -= new FormClosedEventHandler(Populate_FormClosed);
            Populate.FormClosed += new FormClosedEventHandler(Populate_FormClosed);
            Populate.ShowDialog();  
        }

        private void Populate_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFingerPrint Populate = sender as frmFingerPrint;

            if (Populate.Btn)
            {
                if (Populate.FPTempByte != null)
                {
                    imgDataFinger = Populate.FPTempByte;
                }
            }
        }

        private void rbUserAcive_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAssignRole_Click(object sender, EventArgs e)
        {
            string last;

            string userinsertedid = UsersManagments.UserId.ToString();
            string Roleid = cbUserRoles.SelectedValue.ToString();
            if (Roleid.Length > 2)
            {
                last = ObjUser.SaveUserRole(txtUserRoleId.Text, UsersManagments._Tehsilid.ToString(), txtUserId.Text, Roleid, userinsertedid, txtLoginId.Text, "0");
                LoadRoleid(Roleid);
                LoadExistingProfiles();
            }
            else
                MessageBox.Show(" پہلے رول کا انتخاب کریں۔");
            //frmAssignRole Populatee = new frmAssignRole();
            //Populatee.FormClosed -= new FormClosedEventHandler(Populatee_FormClosed);
            //Populatee.FormClosed += new FormClosedEventHandler(Populatee_FormClosed);
            //Populatee.LoginName = txtLoginId.Text;
            //Populatee.userid = txtUserId.Text;
            //Populatee.AdminUserRoleId = Adminuserroldid;
            //Populatee.ShowDialog(); 
        }


        private void btnInsRole_Click(object sender, EventArgs e)
        {
            //frmAssignRole Populatee = new frmAssignRole();
            //Populatee.FormClosed -= new FormClosedEventHandler(Populatee_FormClosed);
            //Populatee.FormClosed += new FormClosedEventHandler(Populatee_FormClosed);
            //Populatee.LoginName = txtLoginId.Text;
            //Populatee.bMultiple = true;
            //Populatee.userid = txtUserId.Text;
            //Populatee.AdminUserRoleId = Adminuserroldid;
            //Populatee.ShowDialog();

            //BL.Users objuserrole = new BL.Users();  
            //DataTable dt = objuserrole.getAdminRoleid(txtUserId.Text);
            //StringBuilder sb = new StringBuilder();
            //string[] columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            //List<string> Rols = dt.AsEnumerable().Select(r => r.Field<int>("RoleID").ToString()).ToList<string>();
            //string joined = string.Join(",", Rols);

            //String anyFirstRoleName = "";
            //try
            //{
            //     anyFirstRoleName = dt.Rows[0].Field<String>("RoleName");
            //}
            //catch (Exception) { }            
            //this.txtRole.Text = anyFirstRoleName ;
            //LoadRoleid(joined);

        }

        private void btnDelRole_Click(object sender, EventArgs e)
        {
            BL.Users objuserrole = new BL.Users();            
            objuserrole.DeleteAdmin_UserRoles(txtUserId.Text, txtRole.Text);

            DataTable dt = objuserrole.getAdminRoleid(txtUserId.Text);

            // update txtRole ------------------------------ start
            String anyFirstRoleName = "";
            try
            {
                anyFirstRoleName = dt.Rows[0].Field<String>("RoleName");
            }
            catch (Exception) { }
            this.txtRole.Text = anyFirstRoleName;
            // update txtRole ------------------------------- end

            // -- load admin objects -------------------------------- start
            StringBuilder sb = new StringBuilder();
            string[] columnNames = dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
            List<string> Rols =  dt.AsEnumerable().Select(r=> r.Field<int>("RoleID").ToString()).ToList<string>();
            string joined = string.Join(",", Rols);
            LoadRoleid(joined);
            // -- load admin objects -------------------------------- end
        }

        //private void Populatee_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    //frmAssignRole Populate = sender as frmAssignRole;
        //    //if (Populate.btn)
        //    //{
        //    //    txtRole.Text = Populate.RoleName;
        //    //    LoadRoleid(Populate.Roleid);
                
        //    //}

        //}


        public void LoadRoleid(string roleid)
        {
         DataTable d = new DataTable();
                dt = ObjUser.getRoleObjectdetails(roleid);
                grdUserRoles.DataSource = dt;
            if (dt != null)
            {
                grdUserRoles.Columns["ObjectId"].Visible = false;
                grdUserRoles.Columns["RoleDetailId"].Visible = false;
                grdUserRoles.Columns["ObjectId"].Visible = false;
                grdUserRoles.Columns["ObjectActualName"].Visible = false;
                grdUserRoles.Columns["RoleId"].Visible = false;
            }
        }
        private void frmUserManagement_Load(object sender, EventArgs e)
        {

            LoadExistingProfiles();
            auto.FillCombo("Proc_Get_Admin_Roles " + UsersManagments._Tehsilid.ToString(), cbUserRoles, "RoleName", "RoleId");
            
          

        }

        public void LoadExistingProfiles()
        {
            string TehsilId = UsersManagments._Tehsilid.ToString();
            dt = ObjUser.getProfile(TehsilId);
            grdExistingUsers.DataSource = dt;
            if (dt != null)
            {
                grdExistingUsers.Columns["RecStatus"].HeaderText = "Active";
                grdExistingUsers.Columns["UserId"].Visible = false;
                grdExistingUsers.Columns["Password"].Visible = false;
                grdExistingUsers.Columns["BiometricCaptured"].Visible = false;
            }
        }

        private void grdExistingUsers_Click(object sender, EventArgs e)
        {
            grdExistingUsers_DoubleClick(sender, e);
        }

        private void SelectItemByValueMember(string targetValueMember)
        {
            foreach (var item in cbUserRoles.Items)
            {
                DataRowView rowView = item as DataRowView;

                //string currentValueMember = Convert.ToInt32(rowView[0]);
                string currentValueMember = rowView[0].ToString();

                if (currentValueMember == targetValueMember)
                {
                    cbUserRoles.SelectedItem = item;
                    return;
                }
            }
            cbUserRoles.SelectedIndex = -1;
        }


        private void grdExistingUsers_DoubleClick(object sender, EventArgs e)
        {
            
            txtUserId.Text = grdExistingUsers.CurrentRow.Cells["UserId"].Value.ToString();
            txtFirstName.Text = grdExistingUsers.CurrentRow.Cells["FirstName"].Value.ToString();
            txtLastName.Text = grdExistingUsers.CurrentRow.Cells["LastName"].Value.ToString();
            txtPassword.Text = grdExistingUsers.CurrentRow.Cells["Password"].Value.ToString();
            txtLoginId.Text = grdExistingUsers.CurrentRow.Cells["LoginName"].Value.ToString();
            string RoleId = grdExistingUsers.CurrentRow.Cells["RoleId"].Value.ToString();
            btnFingerPrint.Enabled = grdExistingUsers.CurrentRow.Cells["BiometricCaptured"].Value.ToString() == "1" ? false : true;
            btnFingerHysoon.Enabled = grdExistingUsers.CurrentRow.Cells["BiometricCaptured"].Value.ToString() == "1" ? false : true;
            if (grdExistingUsers.CurrentRow.Cells["RecStatus"].Value != null)
            {
                bool status = true;
                if (status == Convert.ToBoolean(grdExistingUsers.CurrentRow.Cells["RecStatus"].Value))
                {
                    rbUserAcive.Checked = true;
                }
                else
                {
                    rbUserInActive.Checked = true;
                }
            }
            this.chbIsRO.Checked = Convert.ToBoolean(grdExistingUsers.CurrentRow.Cells["isRO"].Value);
            //cbUserRoles.SelectedValue=
            /*
            DataTable dt = new DataTable();
            dt=ObjUser.getAdminRoleid(txtUserId.Text);
            if (dt != null)
            {
                String iRole = null;
                foreach (DataRow row in dt.Rows)
                {
                    iRole = ((iRole==null) ? "": iRole+"," ) +row["RoleId"].ToString();
                    txtRole.Text = row["RoleName"].ToString();
                    Adminuserroldid = row["AdminUserRoleId"].ToString();

                    cbUserRoles.SelectedValue = row["RoleId"];
                }
                Role = iRole;
                LoadRoleid(Role);
            }
            */
            SelectItemByValueMember(RoleId);
     LoadRoleid(RoleId);
  
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            this.ResetFields();
        }

        private void ResetFields()
        {
            this.txtUserId.Text = "-1";
            this.txtFirstName.Clear();
            this.txtLastName.Clear();
            this.txtLoginId.Clear();
            this.txtPassword.Clear();
            this.txtConfPassword.Clear();
            rbUserAcive.Checked = true;
            this.txtRole.Clear();
            this.grdUserRoles.DataSource = null;
            this.imgDataFinger = null;
            this.chbIsRO.Checked = false;
        }

        private void btnFingerHysoon_Click(object sender, EventArgs e)
        {
            frmHysoon fphysoon = new frmHysoon();
            fphysoon.FPSaved = imgDataFinger;
            fphysoon.FormClosed -= new FormClosedEventHandler(fphysoon_FormClosed);
            fphysoon.FormClosed += new FormClosedEventHandler(fphysoon_FormClosed);
            fphysoon.ShowDialog();
        }
        void fphysoon_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmHysoon fphyasson = sender as frmHysoon;
            if (fphyasson.Status)
            {
                if (fphyasson.FPTempByte != null)
                {
                    imgDataFinger = fphyasson.FPTempByte;
                    //pboxFingerPrint.Image = Resource1.FingerprintImage;
                }

            }
        }

        int i = 0;
        private void lblCycleRoles_Click(object sender, EventArgs e)
        {
            i=++i;
            BL.Users objuserrole = new BL.Users();
            DataTable dt = objuserrole.getAdminRoleid(txtUserId.Text);
            if (dt.Rows.Count <= i) i = 0;

            String anyFirstRoleName = "";
            try
            {
                anyFirstRoleName = dt.Rows[i].Field<String>("RoleName");
            }
            catch (Exception) { }
            this.txtRole.Text = anyFirstRoleName;

        }

        private void cbUserRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected in the ComboBox
            if (cbUserRoles.SelectedItem != null)
            {
                // Assuming the value member is in a column named "YourColumnName"
                DataRow selectedRow = ((DataRowView)cbUserRoles.SelectedItem).Row;

                // Extract the value from the desired column
                int valueMember = Convert.ToInt32(selectedRow[0]);

                // Call the LoadRoleid method with the selected value member
                LoadRoleid(valueMember.ToString());
            }
        }






    }
}
