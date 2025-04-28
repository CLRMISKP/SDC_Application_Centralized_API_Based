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

namespace SDC_Application.AL
{
    public partial class frmKhassraNewKhassraAreaType : Form
    {
        #region Class Variables
        LanguageManager.LanguageConverter lang = new LanguageManager.LanguageConverter();
        public string KhataNo { get; set; }
        public string KhatooniNo { get; set; }
        public string  KhatooniId { get; set; }
        public string MozaId { get; set; }
        public string RHZ_ChangeId { get; set; }
        AutoComplete objAuto = new AutoComplete();
        DataTable dtKhassra = new DataTable();
        DataTable dtKhassraDetails = new DataTable();
        RhzSDC rhz = new RhzSDC();

        #endregion

        #region Default Constructor
        public frmKhassraNewKhassraAreaType()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load Event

        private void frmKhassraNewKhassraAreaType_Load(object sender, EventArgs e)
        {
            txtKhataNo.Text = KhataNo;
            txtKhatooniNo.Text = KhatooniNo;
            objAuto.FillCombo("Proc_Get_AreaTypes_List " + UsersManagments._Tehsilid.ToString(), cboAreaType, "AreaType", "AreaTypeId");
            dtKhassra = rhz.GetKhassraListByKhatooni(KhatooniId);
            FillKhassraComboNGridview();
            dtKhassraDetails = rhz.Proc_Get_KhatooniKhassraDetail(KhatooniId);
            FillKhassraDetailsGridview();

        }

        #endregion

        #region Fill Khassras Combo and Khassra GridView

        private void FillKhassraComboNGridview()
        {
            dgKhatooniKhassras.DataSource = dtKhassra;
            if (dgKhatooniKhassras.DataSource != null)
            {
                dgKhatooniKhassras.Columns["KhassraNo"].HeaderText = "نمبر خسرہ";
                dgKhatooniKhassras.Columns["KhatooniKhassraGroupId"].Visible = false;
                dgKhatooniKhassras.Columns["KhatooniId"].Visible = false;
                dgKhatooniKhassras.Columns["KhassraId"].Visible = false;

                cbKhassras.DataSource = dtKhassra;
                cbKhassras.DisplayMember = "KhassraNo";
                cbKhassras.ValueMember = "KhassraId";
            }
        }
        private void FillKhassraDetailsGridview()
        {
            dgKhassraDetails.DataSource = dtKhassraDetails;
            if (dgKhassraDetails.DataSource != null)
            {
                dgKhassraDetails.Columns["KhassraNo"].HeaderText = "نمبر خسرہ";
                dgKhassraDetails.Columns["Kanal"].HeaderText = "کنال";
                dgKhassraDetails.Columns["Marla"].HeaderText = "مرلہ";
                dgKhassraDetails.Columns["Sarsai"].HeaderText = "سرسائی";
                dgKhassraDetails.Columns["Feet"].HeaderText = "فٹ";
                dgKhassraDetails.Columns["AreaType"].HeaderText = "قسم زمین";
                dgKhassraDetails.Columns["KhassraDetailId"].Visible = false;
                dgKhassraDetails.Columns["KhatooniId"].Visible = false;
                dgKhassraDetails.Columns["KhassraId"].Visible = false;
                dgKhassraDetails.Columns["AreaTypeId"].Visible = false;
            }
        }
        #endregion

        #region Combo Khassra Selection Change Event

        private void cbKhassras_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Khassra Operations Button Clicks

        private void btnSaveKhassra_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKhassraNo.Text.Trim().Length > 0)
                {
                    string retVal=rhz.SaveKhassraRegister("-1", KhatooniId, MozaId, txtKhassraNo.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    if (retVal.Length > 5)
                    {
                        dtKhassra = rhz.GetKhassraListByKhatooni(KhatooniId);
                        FillKhassraComboNGridview();
                        resetKhassraFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnNewKhassra_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteKhassra_Click(object sender, EventArgs e)
        {

        }

        private void resetKhassraFields()
        {
            txtKhassraNo.Clear();
        }

        #endregion

        #region Khassra Details button click event

        private void btnSaveKhassraArea_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtKhassraSarsai.Text.Trim().Length > 0 && txtKhassraMarla.Text.Trim().Length > 0 && txtKhassraKanal.Text.Trim().Length > 0 && cboAreaType.SelectedValue.ToString().Length > 1 && cbKhassras.SelectedValue.ToString().Length > 5)
                {
                   string retval= rhz.SaveKhassraRegisterDetails("-1", cbKhassras.SelectedValue.ToString(), cboAreaType.SelectedValue.ToString(), txtKhassraKanal.Text.Trim(), txtKhassraMarla.Text.Trim(), txtKhassraSarsai.Text.Trim(), (float.Parse(txtKhassraSarsai.Text.Trim()) * 30.25).ToString(), UsersManagments.UserId.ToString());
                   if (retval.Length > 5)
                   {
                       dtKhassraDetails = rhz.Proc_Get_KhatooniKhassraDetail(KhatooniId);
                       FillKhassraDetailsGridview();
                       resetKhassraDetailFields();
                   }
                }
                else
                    MessageBox.Show("تمام کوائف پر کریں۔", "اندراج تفصیل خسرہ جات رقبہ و قسم زمین", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNewKhassraArea_Click(object sender, EventArgs e)
        {

        }

        private void btnDelKhassraArea_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(" کیا آپ انتخاب کردہ قسم زمین خسرہ  حذف کرنا چاہتے ہے؟", "حذف کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                   string retVal= rhz.DeleteKhassraRegisterDetail(txtKhassraDetailId.Text, RHZ_ChangeId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                   if (retVal.Length > 5)
                       FillKhassraDetailsGridview();
                   resetKhassraDetailFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void resetKhassraDetailFields()
        {
            txtKhassraDetailId.Text = "-1";
            txtKhassraKanal.Clear();
            txtKhassraMarla.Clear();
            txtKhassraSarsai.Clear();
            cboAreaType.SelectedValue = 0;
        }
        #endregion

        private void cboAreaType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dgKhassraDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
                foreach(DataGridViewRow row in g.Rows)
                {
                    if (row.Selected)
                    {
                        
                        txtKhassraKanal.Text= row .Cells["Kanal"].Value.ToString();
                        txtKhassraMarla.Text = row.Cells["Marla"].Value.ToString();//dgKhassraDetails.Columns["Marla"].HeaderText = "مرلہ";
                        txtKhassraSarsai.Text = row.Cells["Sarsai"].Value.ToString();//dgKhassraDetails.Columns["Sarsai"].HeaderText = "سرسائی";
                        txtKhassraDetailId.Text = row.Cells["KhassraDetailId"].Value.ToString();//dgKhassraDetails.Columns["Feet"].HeaderText = "فٹ";
                        cboAreaType.SelectedValue = row.Cells["AreaTypeId"].Value;//dgKhassraDetails.Columns["AreaType"].HeaderText = "قسم زمین";
                    }
                
            }
        }
    }
}
