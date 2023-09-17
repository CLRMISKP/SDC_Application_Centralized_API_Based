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

namespace SDC_Application.AL
{
    public partial class frmSubSdcs : Form
    {
        #region CLass Variables
        //public string TehsilId { get; set; }
        MasterDefinition def = new MasterDefinition();
        LanguageConverter lang = new LanguageConverter();
        DataTable dtSubSdcs = new DataTable();
        #endregion
        public frmSubSdcs()
        {
            InitializeComponent();
        }

        private void frmSubSdcs_Load(object sender, EventArgs e)
        {
            lblSubSdc.Text = "-";
            dtSubSdcs = def.GetSubSdcsList();
            GridViewSubSdcs.DataSource = dtSubSdcs;
            fillGridViewSubSdcs();
            fillGridVeiwUnassignedMozas();
            fillGridVeiwUnassignedUsers();

        }
        #region Fill Gridviews
        private void fillGridViewSubSdcs()
        {
            GridViewSubSdcs.Columns["SDCNameEng"].HeaderText = "زیلی ایس ڈی سی نام انگریزی";
            GridViewSubSdcs.Columns["SDCNameUrdu"].HeaderText = "زیلی ایس ڈی سی نام اردو";
            GridViewSubSdcs.Columns["SDCID"].Visible = false;
            // select SDCID, SDCNameEng, SDCNameUrdu from SubSDCs where TehsilId=@TehsilId  
        }
        private void fillGridVeiwUnassignedMozas()
        {
            DataTable dtUnassignedMozas = def.GetMozaListBySubSdcId("0");
            GridViewUnAssignedMozas.DataSource = dtUnassignedMozas;
            GridViewUnAssignedMozas.Columns["MozaNameEng"].HeaderText = "موضع نام انگریزی ";
            GridViewUnAssignedMozas.Columns["MozaNameUrdu"].HeaderText = "موضع نام اردو";
            GridViewUnAssignedMozas.Columns["HadBastNo"].HeaderText = "حدبست نمبر";
            GridViewUnAssignedMozas.Columns["MozaId"].Visible = false;
        }
        private void fillGridVeiwAssignedMozas()
        {
            DataTable dtAssignedMozas = def.GetMozaListBySubSdcId(txtSubSdcId.Text);
            GridViewAssignedMozas.DataSource = dtAssignedMozas;
            GridViewAssignedMozas.Columns["MozaNameEng"].HeaderText = "موضع نام انگریزی ";
            GridViewAssignedMozas.Columns["MozaNameUrdu"].HeaderText = "موضع نام اردو";
            GridViewAssignedMozas.Columns["HadBastNo"].HeaderText = "حدبست نمبر";
            GridViewAssignedMozas.Columns["MozaId"].Visible = false;
        }
        private void fillGridVeiwUnassignedUsers()
        {
            DataTable dtUnassignedUsers = def.GetUsersListBySubSdcId("0");
            GridViewUnAssignedUser.DataSource = dtUnassignedUsers;
            GridViewUnAssignedUser.Columns["FirstName"].HeaderText = "نام پہلا حصہ ";
            GridViewUnAssignedUser.Columns["LastName"].HeaderText = "نام دوسرا حصہ";
            GridViewUnAssignedUser.Columns["LoginName"].HeaderText = "لاگین نام";
            GridViewUnAssignedUser.Columns["UserId"].Visible = false;
        }
        private void fillGridVeiwAssignedUsers()
        {
            DataTable dtAssignedUsers = def.GetUsersListBySubSdcId(txtSubSdcId.Text);
            GridViewAssignedUser.DataSource = dtAssignedUsers;
            GridViewAssignedUser.Columns["FirstName"].HeaderText = "نام پہلا حصہ";
            GridViewAssignedUser.Columns["LastName"].HeaderText = "نام دوسرا حص";
            GridViewAssignedUser.Columns["LoginName"].HeaderText = "لاگین نام";
            GridViewAssignedUser.Columns["UserId"].Visible = false;
        }
        #endregion

        private void txtSubSdcNameUrdu_KeyPress(object sender, KeyPressEventArgs e)
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
        #region SDC entry buttons CLick evenets

        private void btnNewSubSdc_Click(object sender, EventArgs e)
        {
            txtSubSdcNameUrdu.Clear();
            txtSubSdcNameEng.Clear();
            txtSubSdcId.Text = "-1";
            lblSubSdc.Text = "-";
            GridViewAssignedMozas.DataSource = null;
            GridViewAssignedUser.DataSource = null;
        }

        private void btnSaveSubSdc_Click(object sender, EventArgs e)
        {
            if (txtSubSdcNameEng.Text.Length > 1 && txtSubSdcNameUrdu.Text.Length > 1)
            {
                string lastId = def.SaveSubSdc(txtSubSdcId.Text, txtSubSdcNameEng.Text, txtSubSdcNameUrdu.Text, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                if (lastId.Length > 3)
                {
                    dtSubSdcs = def.GetSubSdcsList();
                    GridViewSubSdcs.DataSource = dtSubSdcs;
                    fillGridViewSubSdcs();
                    txtSubSdcNameUrdu.Clear();
                    txtSubSdcNameEng.Clear();
                    txtSubSdcId.Text = "-1";
                    lblSubSdc.Text = "-";
                    GridViewAssignedMozas.DataSource = null;
                    GridViewAssignedUser.DataSource = null;
                }
            }
            else
                MessageBox.Show("ذیلی ایس ڈی سی کا نام درج کریں");
        }

        private void btnDelSubSdc_Click(object sender, EventArgs e)
        {

        }


        private void GridViewSubSdcs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            foreach (DataGridViewRow row in g.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["ColCheck"].Value = 1;
                    txtSubSdcId.Text = row.Cells["SDCID"].Value.ToString();
                    txtSubSdcNameEng.Text = row.Cells["SDCNameEng"].Value.ToString();
                    txtSubSdcNameUrdu.Text = row.Cells["SDCNameUrdu"].Value.ToString();
                    lblSubSdc.Text = row.Cells["SDCNameUrdu"].Value.ToString();
                    fillGridVeiwAssignedMozas();
                    fillGridVeiwAssignedUsers();
                }
                else
                    row.Cells["ColCheck"].Value = 0;
            }

        }

        #endregion

        private void GridViewUnAssignedMozas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            foreach (DataGridViewRow row in g.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["ColChkUnAssignedMozas"].Value = 1;
                    string lastId = def.UpdateMozaForSubSdc(txtSubSdcId.Text, row.Cells["MozaId"].Value.ToString());
                    GridViewUnAssignedMozas.Rows.RemoveAt(row.Index);
                    fillGridVeiwAssignedMozas();
                }
                else
                    row.Cells["ColChkUnAssignedMozas"].Value = 0;
            }
        }

        private void GridViewAssignedMozas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            foreach (DataGridViewRow row in g.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["ColChkAssignedMozas"].Value = 1;
                    string lastId = def.UpdateMozaForSubSdc("0", row.Cells["MozaId"].Value.ToString());
                    GridViewAssignedMozas.Rows.RemoveAt(row.Index);
                    fillGridVeiwUnassignedMozas();
                }
                else
                    row.Cells["ColChkAssignedMozas"].Value = 0;
            }
        }

        private void GridViewUnAssignedUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            foreach (DataGridViewRow row in g.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["ColChkUnAsigendUser"].Value = 1;
                    string lastId = def.UpdateUserForSubSdc(txtSubSdcId.Text, row.Cells["UserId"].Value.ToString());
                    GridViewUnAssignedUser.Rows.RemoveAt(row.Index);
                    fillGridVeiwAssignedUsers();
                }
                else
                    row.Cells["ColChkUnAsigendUser"].Value = 0;
            }
        }

        private void GridViewAssignedUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            foreach (DataGridViewRow row in g.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["ColChkAsigendUser"].Value = 1;
                    string lastId = def.UpdateUserForSubSdc("0", row.Cells["UserId"].Value.ToString());
                    GridViewAssignedUser.Rows.RemoveAt(row.Index);
                    fillGridVeiwUnassignedUsers();
                }
                else
                    row.Cells["ColChkAsigendUser"].Value = 0;
            }
        }
    }
}
