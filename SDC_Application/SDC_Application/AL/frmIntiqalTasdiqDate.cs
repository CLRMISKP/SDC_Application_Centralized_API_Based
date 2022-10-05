using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmIntiqalTasdiqDate : Form
    {
        #region Class Variables

        private BL.Intiqal intiqal = new BL.Intiqal();
        LanguageConverter lang = new LanguageConverter();
        BL.frmVoucher objbusines = new BL.frmVoucher();
        AutoComplete objauto = new AutoComplete();
        DataTable dtRecords = new DataTable();
        public bool isLoadByDate { get; set; }

        public string IntiqalId { get; set; }
        public string  IntiqalNo { get; set; }
        public string TokenId { get; set; }
        public string TokenNo { get; set; }
        public string MozaId { get; set; }
        public bool isloadFromIntiqal { get; set; }

        #endregion

        #region Form Intialization
    

        public frmIntiqalTasdiqDate()
        {
            InitializeComponent();
        }

        #endregion

        #region Button Save Click Event

        private void btnMasterSave_Click(object sender, EventArgs e)
        {
            try
            {
                string LastId = this.SaveTasdiqDate();
                if (LastId != "0")
                {
                    MessageBox.Show("ریکار محفوظ ہو گیا", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SetCotnrols();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
            
        }
        
        #endregion

        #region Save \ Update Tasdiq Date

        private string SaveTasdiqDate()
        {
            string VistingPlanId = txthdnVisPlanId.Text;
            string TehsilId = UsersManagments._Tehsilid.ToString();
            string TokenId = txthdnTokenId.Text.Trim();
            string UserId = cmbRO.SelectedValue.ToString();
            string vDateTime = dtpVdateTime.Value.ToString();
            string vStatus = chbStatus.Checked.ToString();
            string Remarks = txtRemarks.Text;
            string IntiqalId = txthdnIntiqalId.Text;
            string lastId = "0";
            lastId = intiqal.SaveIntiqalTasdiqDate(VistingPlanId, TehsilId, TokenId, UserId, IntiqalId, vDateTime, vStatus, Remarks, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
            return lastId;
        }
        
        #endregion

        #region Form Load Event


        private void frmIntiqalTasdiqDate_Load(object sender, EventArgs e)
        {
            
            this.txthdnVisPlanId.Text = "-1";
            this.FillCombos();
            if (this.isloadFromIntiqal != null)
            {
                if (this.isloadFromIntiqal)
                {
                    this.txthdnIntiqalId.Text = this.IntiqalId;
                    this.txthdnTokenId.Text = this.TokenId;
                    this.txthdnMozaId.Text = this.MozaId;
                    this.txtIntiqalNoNew.Text = this.IntiqalNo;
                    this.txtTokenNoNew.Text = this.TokenNo;
                }
            }
        }

        #endregion

        #region Fill Combo Booxes..

        private void FillCombos()
        {
            try
            {
                objauto.FillCombo("Proc_Get_Moza_List " + UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
                objauto.FillCombo("Proc_Get_Admin_Users_SDC", cmbRO, "CompleteName", "UserId");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fill DatagridView of Assigned Dates and Time for Intiqal Tasdiq

        private void FillGridviewAsignedDates(bool isDate)
        {
            
            if (isDate)
            {
                dtRecords = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_Intiqal_VisitingPlan_by_Date '" + dtpDateFilter.Value.ToShortDateString() + "'");
                isLoadByDate = true;
            }
            else
            {
                dtRecords = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_Intiqal_VisitingPlan "+UsersManagments._Tehsilid.ToString());
                isLoadByDate = false;
            }
            gridViewAssignedDates.DataSource = dtRecords;
            if(dtRecords!=null)
            SetGridView();

        }

        #endregion

        #region Rename and set Gridview Columns

        private void SetGridView()
        {
            if (dtRecords != null)
            {
                gridViewAssignedDates.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
                gridViewAssignedDates.Columns["FirstName"].HeaderText = "ریونیو افسر";
                gridViewAssignedDates.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                gridViewAssignedDates.Columns["VisitingDate"].HeaderText = "تاریخ تصدیق";
                gridViewAssignedDates.Columns["VisitingTime"].HeaderText = "وقت تصدیق";
                gridViewAssignedDates.Columns["VisitingStatus"].HeaderText = "موئثر";
                //gridViewAssignedDates.Columns["VisitingStatus"].
                gridViewAssignedDates.Columns["Remarks"].HeaderText = "تفصیل";
                gridViewAssignedDates.Columns["Remarks"].FillWeight = 200;
                gridViewAssignedDates.Columns["VisitingStatus"].FillWeight = 50;
                gridViewAssignedDates.Columns["TokenNo"].FillWeight = 50;
                gridViewAssignedDates.Columns["IntiqalNo"].FillWeight = 50;
                gridViewAssignedDates.Columns["VistingPlanId"].Visible = false;
                gridViewAssignedDates.Columns["TokenId"].Visible = false;
                gridViewAssignedDates.Columns["TehsilId"].Visible = false;
                gridViewAssignedDates.Columns["UserId"].Visible = false;
                gridViewAssignedDates.Columns["IntiqalId"].Visible = false;
                gridViewAssignedDates.Columns["VisitingDateTime"].Visible = false;
                gridViewAssignedDates.Columns["MozaId"].Visible = false;
            }
        }
        #endregion

        #region Key Press Event for Language Conversion to Urdu

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Button Search Click Event for Loading Token No

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmTokenPopulate Populate = new frmTokenPopulate();
            Populate.ServiceTypeId = GetServiceTypeIdByServiceName("Inteqal");
            Populate.FormClosed -= new FormClosedEventHandler(Populate_FormClosed);

            Populate.FormClosed += new FormClosedEventHandler(Populate_FormClosed);
            Populate.InteqalMain = true;
            Populate.ShowDialog();
        }

        #region Get ServiceTypeId by Service Name

        private string GetServiceTypeIdByServiceName(string ServiceNameEng)
        {
            string ServiceTypeId = "0";
            DataTable dtServiceTypes = new DataTable();
            dtServiceTypes = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_ServiceTypes_ByServiceTypeName '" + ServiceNameEng + "'");
            if (dtServiceTypes != null)
            {
                if (dtServiceTypes.Rows.Count > 0)
                    ServiceTypeId = dtServiceTypes.Rows[0][0].ToString();
            }
            return ServiceTypeId;
        }

        #endregion

        private void Populate_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTokenPopulate Populate = sender as frmTokenPopulate;
            this.txthdnTokenId.Text = Populate.TokenID;
            this.txtTokenNoNew.Text = Populate.TokenNo;
            this.txthdnMozaId.Text = (Populate.Mouzaid != null && Populate.Mouzaid != "") ? Populate.Mouzaid : "0";
            this.GetIntiqalByTokenId(this.txthdnMozaId.Text,this.txthdnTokenId.Text );
        }

        #endregion

        #region Get Intiqal By Token Id

        private void GetIntiqalByTokenId(string MozaId, string TokenId)
        {
            DataTable dtIntiqal = new DataTable();
            dtIntiqal = objbusines.filldatatable_from_storedProcedure("proc_Get_Intiqal_Main_By_MozaId_By_TokenId_SDC " + TokenId + "," + MozaId);
            if (dtIntiqal.Rows.Count > 0)
            {
                this.txthdnIntiqalId.Text = dtIntiqal.Rows[0]["IntiqalId"].ToString();
                this.txtIntiqalNoNew.Text = dtIntiqal.Rows[0]["IntiqalNo"].ToString();
            }
        }

        #endregion

        #region Data Time Picker Filter Value Changed Event

        private void dtpDateFilter_ValueChanged(object sender, EventArgs e)
        {
            this.FillGridviewAsignedDates(true);
        }

        #endregion

        #region Button Search Click Event
   
        private void btnSearchExistingRecord_Click(object sender, EventArgs e)
        {
            string mozaId=Convert.ToInt32(cmbMouza.SelectedValue)>0?cmbMouza.SelectedValue.ToString():"0";
            if (this.txtIntiqalNo.Text.Trim() != "" || this.txtTokenNO.Text.Trim() != "" || mozaId != "0")
            {
                if (isLoadByDate || dtRecords.Rows.Count<1)
                {
                    this.FillGridviewAsignedDates(false);
                }
            }
            if (this.txtIntiqalNo.Text.Trim() != "")
            {
                string intiqalNo = txtIntiqalNo.Text.Trim();
                this.fillgrid_byfilter("IntiqalNo like '%" + intiqalNo + "%'");
                SetGridView();
            }
            else if (this.txtTokenNO.Text.Trim() != "")
            {
                string TokenNo = txtTokenNO.Text.Trim();
                this.fillgrid_byfilter("TokenNo =" + TokenNo + "");
                SetGridView();
            }
            else
            {
                string MozaId = cmbMouza.SelectedValue.ToString();
                this.fillgrid_byfilter("MozaId=" + MozaId + "");
                SetGridView();
            }
        }

        #endregion

        #region Gridview Cell Click event

        private void gridViewAssignedDates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            foreach (DataGridViewRow row in g.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    row.Cells["colChk"].Value = true;
                }
                else
                {
                    row.Cells["colChk"].Value = false;
                }
            }
            txthdnVisPlanId.Text=g.Rows[e.RowIndex].Cells["VistingPlanId"].Value.ToString();
            txthdnTokenId.Text = g.Rows[e.RowIndex].Cells["TokenId"].Value.ToString();
            txthdnIntiqalId.Text = g.Rows[e.RowIndex].Cells["IntiqalId"].Value.ToString();
            txthdnMozaId.Text = g.Rows[e.RowIndex].Cells["MozaId"].Value.ToString();
            dtpVdateTime.Value =Convert.ToDateTime( g.Rows[e.RowIndex].Cells["VisitingDateTime"].Value.ToString());
            chbStatus.Checked =Convert.ToBoolean( g.Rows[e.RowIndex].Cells["VisitingStatus"].Value.ToString());
            txtRemarks.Text = g.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
            txtIntiqalNoNew.Text = g.Rows[e.RowIndex].Cells["IntiqalNo"].Value.ToString();
            txtTokenNoNew.Text = g.Rows[e.RowIndex].Cells["TokenNo"].Value.ToString();
            cmbRO.SelectedValue =Convert.ToInt32( g.Rows[e.RowIndex].Cells["UserId"].Value.ToString());
            
            
        }

        #endregion

        #region Filter Gridview on base of different Conditions

        public void fillgrid_byfilter(string Condition)
        {
            if (dtRecords != null)
            {
                DataView v = new DataView(dtRecords);
                v.RowFilter = Condition;
                gridViewAssignedDates.DataSource = v;
            }

        }

        #endregion

        #region Button New Click Event

        private void btnNewVoucher_Click(object sender, EventArgs e)
        {
            this.SetCotnrols();

        }

        #endregion

        #region Set Entry Controls

        private void SetCotnrols()
        {
            this.txthdnIntiqalId.Text = "-1";
            this.txthdnMozaId.Text = "-1";
            this.txthdnTokenId.Text = "-1";
            this.txthdnVisPlanId.Text = "-1";
            this.txtIntiqalNoNew.Clear();
            this.txtTokenNoNew.Clear();
            this.txtRemarks.Clear();
            this.cmbRO.SelectedValue = "0";
            this.dtpVdateTime.Value = DateTime.Now;
        }
        #endregion
    }
}