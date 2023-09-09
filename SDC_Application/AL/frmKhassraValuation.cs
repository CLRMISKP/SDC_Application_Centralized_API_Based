using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.BL;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmKhassraValuation : Form
    {
        #region Class Vderialbes

        AutoComplete objauto = new AutoComplete();
        TaqseemNewKhataJatMin khatas = new TaqseemNewKhataJatMin();
        Khatoonies Khatooni = new Khatoonies();
        DataTable dtkj = new DataTable();
        LanguageConverter lang = new LanguageConverter();

        #endregion

        #region Default Constructor

        public frmKhassraValuation()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load Event

        private void frmKhassraValuation_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_Intiqal_PlotTypes_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() , cboKhassraType, "PlotType_Urdu", "PlotTypeId");
        }

        #endregion

        #region Combobox Mouza Change Event

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbMouza.SelectedValue.ToString() != "-1")
            {
                this.cboYear.Enabled = true;

            }
            else
                this.cboYear.Enabled = false;

            objauto.FillCombo("Proc_Get_Moza_Khassra_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cmbMouza.SelectedValue.ToString(), cboKhassraList, "KhassraNo", "KhassraId");
        }

        #endregion

        #region Dropdown Selection Change Event

        private void cboYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.FillGridViewKhassraValuation();
        }

        #endregion

        #region Dropdown Khassra List Seelction Change Event

        private void cboKhassraList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            objauto.FillCombo("Proc_Get_KhassraArea_Deatil  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cboKhassraList.SelectedValue.ToString(), cboKhassraDetailList, "AreaType", "KhassraDetailId");
        }

        #endregion

        #region Button Save Valuation Click Event

        private void btnSaveKhata_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKhassraValue.Text.Trim() != "" && cboKhassraDetailList.SelectedValue.ToString() != "-1" && cboKhassraList.SelectedValue.ToString() != "-1" && cboKhassraType.SelectedValue.ToString() != "-1" && cboYear.Text.Trim() != "")
                {
                    string lastId= Khatooni.SaveKhassraValuation(txtValuationId.Text, cmbMouza.SelectedValue.ToString(),cboKhassraDetailList.SelectedValue.ToString(), cboKhassraList.SelectedValue.ToString(), cboYear.Text.Trim(), cboKhassraType.SelectedValue.ToString(), txtKhassraValue.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    if (lastId.ToUpper() != "NULL")
                    {
                        this.txtKhassraValue.Clear();
                        cboKhassraType.SelectedValue = "-1";
                        cboKhassraDetailList.SelectedValue = "-1";
                        this.txtValuationId.Text = "-1";
                        this.FillGridViewKhassraValuation();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button New Click Event

        private void btnNewKhata_Click(object sender, EventArgs e)
        {
            this.txtKhassraValue.Clear();
            cboKhassraType.SelectedValue = "-1";
            cboKhassraDetailList.SelectedValue = "-1";
            this.txtValuationId.Text = "-1";
        }

        #endregion

        #region Get Khassra Valuation By Moza By Year

        private void FillGridViewKhassraValuation()
        {
            if (cboYear.Text.Trim() != "" && cmbMouza.SelectedValue.ToString() != "-1")
            {
                DataTable dt = Khatooni.GetKhassraRegisterValuationByMozaByYear(cmbMouza.SelectedValue.ToString(), cboYear.Text.Trim());
                GridViewKhassraValueation.DataSource = dt;
                GridViewKhassraValueation.Columns["KhassraNo"].HeaderText = "نمبر خسرہ";
                GridViewKhassraValueation.Columns["AreaType"].HeaderText = "قسم زمین";
                GridViewKhassraValueation.Columns["Year"].HeaderText = "برائے سال";
                GridViewKhassraValueation.Columns["PlotType_Urdu"].HeaderText = "قسم نمبر خسرہ";
                GridViewKhassraValueation.Columns["LandValue"].HeaderText = "تعین شدہ قیمت";
                GridViewKhassraValueation.Columns["ValuationId"].Visible = false;
                GridViewKhassraValueation.Columns["KhassraId"].Visible = false;
                GridViewKhassraValueation.Columns["KhassraDetailId"].Visible = false;
                GridViewKhassraValueation.Columns["PlotTypeId"].Visible = false;
            }
        }

        #endregion
    }
}
