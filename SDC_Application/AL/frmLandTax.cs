using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmLandTax : Form
    {
        #region Class Variable declaration

        public string Personid { get; set; }
        BL.frmToken objbusines = new BL.frmToken();
        BL.frmVoucher objVoch = new BL.frmVoucher();
        DataTable dtTaxRecord = new DataTable();

        #endregion

        #region Default Constructor

        public frmLandTax()
        {
            InitializeComponent();
        }

        #endregion
         
        #region Form Load Event

        private void frmLandTax_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            DataTable dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_LandTaxDetails " + this.Personid); // NOT_IMPLEMENTED_SP
            if (dt == null) { this.Close(); return; }
           foreach (DataRow dr in dt.Rows)
           {
               txtMalikArea.Text = dr["TotalKanal"].ToString();
               txtNameMalik.Text = dr["PersonName"].ToString();
               txtRate.Text = dr["TaxRate"].ToString();
           }
           txtTotalTax.Text = ((Convert.ToInt32(txtMalikArea.Text.Trim()) * Convert.ToInt32(txtRate.Text.Trim())) - (Convert.ToInt32(txtRelief.Text.Trim()))).ToString();

            // Load existing collected tax record
           dtTaxRecord = objVoch.Get_AIT_Tax_By_PersonId(Personid);
           FillGridViewAIT(dtTaxRecord);
        }

        #endregion

        #region Key Press event for input validation

        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        #endregion

        #region TextBox Leave Events and Auto Calculation

        private void txtRate_Leave(object sender, EventArgs e)
        {
            txtTotalTax.Text = ((Convert.ToInt32(txtMalikArea.Text.Trim()) * Convert.ToInt32(txtRate.Text.Trim())) - (Convert.ToInt32(txtRelief.Text.Trim()))).ToString();
        }

        private void txtRelief_Leave(object sender, EventArgs e)
        {
            txtTotalTax.Text = ((Convert.ToInt32(txtMalikArea.Text.Trim()) * Convert.ToInt32(txtRate.Text.Trim())) - (Convert.ToInt32(txtRelief.Text.Trim()))).ToString();
        }

        #endregion

        #region Button Save Tax Clik Event
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            string retVal=objVoch.SaveAIT(txtAIT_RecId.Text, UsersManagments._Tehsilid.ToString(), Personid, DateTime.Now.Year.ToString(), txtMalikArea.Text.Trim(), "0", "0", txtRate.Text.Trim(), txtRelief.Text.Trim(), txtTotalTax.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
            dtTaxRecord = objVoch.Get_AIT_Tax_By_PersonId(Personid);
            FillGridViewAIT(dtTaxRecord);
        }

        #endregion

        #region Fill Gridview AIT Collected

        private void FillGridViewAIT(DataTable dt)
        {
            GridViewAIT.DataSource = dt;
            GridViewAIT.Columns["CompleteName"].HeaderText="نام مالک";
            GridViewAIT.Columns["Year"].HeaderText="سال";
            GridViewAIT.Columns["Kanal"].HeaderText="رقبہ-کنال";
            GridViewAIT.Columns["Rate"].HeaderText="ریٹ";
            GridViewAIT.Columns["Relief"].HeaderText="ریلیف";
            GridViewAIT.Columns["NetTax"].HeaderText = "کل ٹیکس";

            GridViewAIT.Columns["AIT_RecID"].Visible = false;
            GridViewAIT.Columns["PersonId"].Visible = false;
            GridViewAIT.Columns["Marla"].Visible = false;
            GridViewAIT.Columns["Sarsai"].Visible = false;
        }

        #endregion

        #region Print Land Tax Challan

        private void btnPrintChallan_Click(object sender, EventArgs e)
        {
            frmSDCReportingMain LandTaxReport = new frmSDCReportingMain();
            LandTaxReport.FardPersonId = this.Personid;
            UsersManagments.check = 22;
            LandTaxReport.ShowDialog();
        }

        #endregion

    }
}
