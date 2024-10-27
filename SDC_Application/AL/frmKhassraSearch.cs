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
    public partial class frmKhassraSearch : Form
    {
        #region Class Variables

        AutoComplete objauto = new AutoComplete();
        Misal misalBl = new Misal();
        BL.frmToken objBusiness = new BL.frmToken();
        LanguageConverter lang = new LanguageConverter();
       // public string  MozaId { get; set; }
        DataTable Khassras = new DataTable();
        Intiqal intiqal = new Intiqal();
        public string MozaId = "-1";
        public string KhataId = "-1";
        public int CallFor;

        #endregion

        public frmKhassraSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Khassras = intiqal.SearchKhassraByKhassraNoMozaId(txtKhassraNo.Text.Trim(), this.MozaId);
            this.GridViewKhassras.DataSource = this.Khassras;
            GridViewKhassras.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
            GridViewKhassras.Columns["RecStatus"].HeaderText = "حالت";
            GridViewKhassras.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
            GridViewKhassras.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
            GridViewKhassras.Columns["KhatooniId"].Visible = false;
            GridViewKhassras.Columns["KhassraId"].Visible = false;
            GridViewKhassras.Columns["RegisterHqDKhataId"].Visible = false;
        }

        private void cmbMouza_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MozaId = cmbMouza.SelectedValue.ToString();

        }

        private void frmKhassraSearch_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            if (MozaId != "-1")
            {
                cmbMouza.SelectedValue = MozaId;
                //this.Fill_Khata_DropDown();
            }
          
        }

        private void GridViewKhassras_DoubleClick(object sender, EventArgs e)
        {
            if (GridViewKhassras.Rows.Count > 0 && CallFor == 1)
            {
                KhataId = GridViewKhassras.CurrentRow.Cells["RegisterHqDKhataId"].Value.ToString();
                if (KhataId != "-1")
                {
                    this.Close();
                }

            }
  
        }
    }
}
