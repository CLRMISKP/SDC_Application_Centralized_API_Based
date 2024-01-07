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
                        DataTable dt = user.GetSystemRegistrationLogs(Classess.UsersManagments._Tehsilid.ToString());
                        DataTable dtUsers = user.GetUsersForUserAccessControl(Classess.UsersManagments._Tehsilid.ToString());
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                gridSystems.DataSource = dt;
                                gridSystems.Columns["RegId"].Visible = false;
                            }
                        }
                        if (dtUsers != null)
                        {
                            if (dtUsers.Rows.Count > 0)
                            {
                                grdExistingUsers.DataSource = dtUsers;
                                grdExistingUsers.Columns["UserId"].Visible = false;
                            }
                        }
	            }
	            catch (Exception ex)
	            {
		
		            MessageBox.Show(ex.Message);
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
    }
}
