using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;

namespace SDC_Application
{
    public partial class frmUsersMachinesAccessControls : Form
    {
        public int TabIndex { get; set; }
        Users user = new Users();
        public frmUsersMachinesAccessControls()
        {
            InitializeComponent();
        }

        private void frmUsersMachinesAccessControls_Load(object sender, EventArgs e)
        {
            try 
	            {	        
		            tabControl1.SelectedIndex = TabIndex;
                    fillGridViewUsers();
                    fillGridViewMachines();
                       
	            }
	            catch (Exception ex)
	            {
		
		            MessageBox.Show(ex.Message);
	            }
            
        }
        private void fillGridViewUsers()
        {
            DataTable dtUsers = user.GetUsersForUserAccessControl(Classess.UsersManagments._Tehsilid.ToString());
            if (dtUsers != null)
            {
                if (dtUsers.Rows.Count > 0)
                {
                    grdExistingUsers.DataSource = dtUsers;
                    grdExistingUsers.Columns["UserId"].Visible = false;
                }
            }
        }
        private void fillGridViewMachines()
        {
            DataTable dt = user.GetSystemRegistrationLogs(Classess.UsersManagments._Tehsilid.ToString());

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    gridSystems.DataSource = dt;
                    gridSystems.Columns["RegId"].Visible = false;
                }
            }
        }
        private void gridSystems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridSystems.SelectedRows.Count > 0)
                {
                    dtpMachineLogin.Text = gridSystems.SelectedRows[0].Cells["LoginTime"].Value.ToString();
                    dtpMachineLogout.Text = gridSystems.SelectedRows[0].Cells["LogOutTime"].Value.ToString();
                    chkEnableSystemLogin.Checked = Convert.ToBoolean(gridSystems.SelectedRows[0].Cells["isAllowedToLogin"].Value);
                    chkMachineLoginOnWeekend.Checked = Convert.ToBoolean(gridSystems.SelectedRows[0].Cells["isAllowedOnWeekend"].Value);
                    txtRegId.Text = gridSystems.SelectedRows[0].Cells["RegId"].Value.ToString();
                }
                foreach (DataGridViewRow row in gridSystems.Rows)
                {
                    if (row.Selected)
                        row.Cells["ChkSelMachine"].Value = 1;
                    else
                        row.Cells["ChkSelMachine"].Value = 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grdExistingUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdExistingUsers.SelectedRows.Count > 0)
                {
                    dtpLogin.Text = grdExistingUsers.SelectedRows[0].Cells["LoginTime"].Value.ToString();
                    dtpLogout.Text = grdExistingUsers.SelectedRows[0].Cells["LogOutTime"].Value.ToString();
                    //chkLoginOnWeekend.Checked = Convert.ToBoolean(grdExistingUsers.SelectedRows[0].Cells["isAllowedToLogin"].Value);
                    chkLoginOnWeekend.Checked = Convert.ToBoolean(grdExistingUsers.SelectedRows[0].Cells["isAllowedOnWeekend"].Value);
                    txtUserId.Text = grdExistingUsers.SelectedRows[0].Cells["UserId"].Value.ToString();
                }
                foreach (DataGridViewRow row in grdExistingUsers.Rows)
                {
                    if (row.Selected)
                        row.Cells["ChkSelUser"].Value = 1;
                    else
                        row.Cells["ChkSelUser"].Value = 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text != "-1" && dtpLogin.MaskCompleted && dtpLogout.MaskCompleted)
            {
              string lastId=  user.UpdateUserAccessControl(txtUserId.Text, chkLoginOnWeekend.Checked ? "1" : "0", dtpLogin.Text, dtpLogout.Text);
              if (lastId != null)
              {
                  fillGridViewUsers();
              }

            }
            MessageBox.Show("Fill all  the required fields correctly before saving the record.");
        }

        private void btnSaveMachine_Click(object sender, EventArgs e)
        {
            if (txtRegId.Text != "-1" && dtpMachineLogin.MaskCompleted && dtpMachineLogout.MaskCompleted)
            {
                string lastId = user.UpdateMachineAccessControl(txtRegId.Text, chkEnableSystemLogin.Checked ? "1" : "0", chkMachineLoginOnWeekend.Checked?"1":"0",dtpMachineLogin.Text, dtpMachineLogout.Text);
                if (lastId != null)
                {
                    fillGridViewMachines();
                }
            }
            MessageBox.Show("Fill all  the required fields correctly before saving the record.");
        }
    }
}
