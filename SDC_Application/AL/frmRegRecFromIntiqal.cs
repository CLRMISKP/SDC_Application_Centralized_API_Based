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
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class frmRegRecFromIntiqal : Form
    {
        AutoComplete objauto = new AutoComplete();
        LanguageConverter Lang = new LanguageConverter();
        DocReceiving DocRc = new DocReceiving();
        datagrid_controls objdatagrid = new datagrid_controls();
        Intiqal Iq = new Intiqal();
        public string MozaId { get; set; }
        public frmRegRecFromIntiqal()
        {
            InitializeComponent();
        }

        private void frmRegRecFromIntiqal_Load(object sender, EventArgs e)
        {
            objauto.FillCombo("Proc_Get_Moza_List "+UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbRegMoza, "MozaNameUrdu", "MozaId");
            objauto.FillComboWithTopIndex("Proc_Self_Get_SR_List " + UsersManagments._Tehsilid.ToString(), cmbSR, "SRUrduName", "SRId");
            this.GetRegReceivedByDate(DateTime.Now.ToShortDateString());
            if(MozaId!="0")
            {
                cmbRegMoza.SelectedValue = this.MozaId;
            }
            else
            {
                cmbRegMoza.SelectedIndex = 0;
            }
        }

        #region Get Registry Received By Date

        private void GetRegReceivedByDate(string Date)
        {
            try
            {
                DataTable dt = DocRc.GetRegReceivedByDate(Date);
                this.grdvReg.DataSource = dt;
                if (dt != null) { 
                grdvReg.Columns["RegNo"].DisplayIndex = 0;
                grdvReg.Columns["JildNo"].DisplayIndex = 1;
                grdvReg.Columns["RegDate"].DisplayIndex = 2;
                grdvReg.Columns["MozaNameUrdu"].DisplayIndex = 3;
                grdvReg.Columns["SRUrduName"].DisplayIndex = 4;
                grdvReg.Columns["Seller"].DisplayIndex = 5;
                grdvReg.Columns["Buyer"].DisplayIndex = 6;
                grdvReg.Columns["status"].DisplayIndex = 7;
                grdvReg.Columns["Kafiyat"].DisplayIndex = 8;

                grdvReg.Columns["RegNo"].HeaderText = "رجسٹری نمبر";
                grdvReg.Columns["JildNo"].HeaderText = "جلد نمبر";
                grdvReg.Columns["RegDate"].HeaderText = "رجسٹری تاریخ";
                grdvReg.Columns["MozaNameUrdu"].HeaderText = "موضع";
                grdvReg.Columns["SRUrduName"].HeaderText = "سب رجسٹرار";
                grdvReg.Columns["Seller"].HeaderText = "بائع";
                grdvReg.Columns["Buyer"].HeaderText = "مشتری";

                grdvReg.Columns["status"].HeaderText = "حالت";
                grdvReg.Columns["Kafiyat"].HeaderText = "کیفیت";


                grdvReg.Columns["MozaId"].Visible = false;
                grdvReg.Columns["ReceivingId"].Visible = false;
                grdvReg.Columns["RecStatus"].Visible = false;
                grdvReg.Columns["SRId"].Visible = false;

                objdatagrid.colorrbackgrid(grdvReg);
                objdatagrid.gridControls(grdvReg);
                grdvReg.ColumnHeadersHeight = 20;
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Language Auto Conversion on Key Press Event

        private void ConvertLang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 22 && e.KeyChar != 24 && e.KeyChar != 3 && e.KeyChar != 1 && e.KeyChar != 13)
            {
                if (e.KeyChar == Convert.ToChar((Keys.Back)))
                {

                }
                else
                {
                    e.KeyChar = Lang.UrduChar(Convert.ToChar(e.KeyChar));
                }
            }
        }

        #endregion

        private void btnRegSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRegMoza.SelectedIndex == 0)
                {
                    MessageBox.Show("موضع سیلیکٹ کریں");
                    cmbRegMoza.Focus();
                    return;
                }

                else if (txtRegNo.Text.Trim() == "")
                {
                    MessageBox.Show("رجسٹری نمبر درج کریں");
                    txtRegNo.Focus();
                    return;
                }
                else if (dtReg.Value > DateTime.Now)
                {
                    MessageBox.Show("درست تاریخ وصولی درج کریں");
                    dtReg.Focus();
                    return;
                }


                //if (txtRegId.Text == "-1")
                //{
                string Reg = Iq.CheckRegAlreadyReceivedForRecvReg(txtRegNo.Text.Trim(), txtRegId.Text, dtReg.Value.Year, cmbRegMoza.SelectedValue.ToString(),cmbSR.SelectedValue.ToString());
                if (Reg != "-1")
                {

                    MessageBox.Show(" رجسٹری نمبر" + txtRegNo.Text + " کا اندراج سال" + dtReg.Value.Year.ToString() + " میں ہو چکا ہے۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;

                }
                //}

                else
                {
                    string retVal = DocRc.SaveRegReceiving(txtRegId.Text, UsersManagments._Tehsilid.ToString(), cmbRegMoza.SelectedValue.ToString(), dtReg.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()), txtRegNo.Text, txtJildNo.Text.Trim(), txtSeller.Text, txtBuyer.Text, txtKafiyat.Text.Trim(), UsersManagments.UserId.ToString(), UsersManagments.UserName, "1", cmbSR.SelectedValue.ToString());
                    if (retVal != "" && retVal != "Null")
                    {
                        // MessageBox.Show("دستویز محفوظ ہو گیا۔");
                        txtRegNo.Clear();
                        txtJildNo.Clear();
                        cmbRegMoza.SelectedIndex = 0;
                        txtKafiyat.Clear();
                        txtSeller.Clear();
                        txtBuyer.Clear();
                        dtReg.Value = Convert.ToDateTime(DateTime.Now);
                        txtRegId.Text = "-1";

                        this.GetRegReceivedByDate(DateTime.Now.ToShortDateString());

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


    }
}
