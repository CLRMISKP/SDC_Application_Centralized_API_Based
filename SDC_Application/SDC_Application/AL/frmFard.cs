using SDC_Application.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using SDC_Application.Classess;

namespace SDC_Application.AL
    {
    public partial class frmFard : Form
    {
        #region Calss Variables

        Search search = new Search();
        Persons person = new Persons();
        Malikan_n_Khattajat mnk = new Malikan_n_Khattajat();
        LanguageConverter lang = new LanguageConverter();
        TaqseemNewKhataJatMin khatas = new TaqseemNewKhataJatMin();
        AutoComplete auto = new AutoComplete();
        CommanFunctions common = new CommanFunctions();

        DataTable khewatMalikanByFB = new DataTable();
        DataView view;
        DataTable dtKhewatFareeqainByKhataId = new DataTable();
        DataTable dtMushteriFareeqainByKhatooniId = new DataTable();
        DataTable dtFardKhatas = new DataTable();

        public string MaalikType { get; set; }
        public string SelectedMozaId { get; set; }
        public string SelectedTokenId { get; set; }
        public string SelectedTokenNo { get; set; }
        public bool isConfirm { get; set; }

        #endregion

        #region Default Construction

        public frmFard()
            {

            InitializeComponent();

            }

        #endregion

        #region Search Token

        private void btnSearchToken_Click(object sender, EventArgs e)
            {
                this.txtFardPersonRecId.Text = "-1";
                frmSearch searchToken = new frmSearch();
                searchToken.FormClosed -= new FormClosedEventHandler(searchToken_FormClosed);
                searchToken.FormClosed += new FormClosedEventHandler(searchToken_FormClosed);
                searchToken.ShowDialog();
            }

        #endregion

        #region Load Token Click Evetn

        private void searchToken_FormClosed(object sender, FormClosedEventArgs e)
            {
                GridViewFardMushteri.DataSource = null;
                GridViewKhewatMalikaan.DataSource = null;
                GridFardKhatoonies.DataSource = null;
                btnNewKhewatFareeq_Click(sender, e);
                btnNewMushteri_Click(sender, e);
                frmSearch frm = sender as frmSearch;
                this.SelectedMozaId = frm.mouzaid;
                this.SelectedTokenId = frm.tokenID;
                this.SelectedTokenNo = frm.tokenno;
                //this.txtFardType.Text=frm.f
                txtReciptTokenID.Text = this.SelectedTokenNo;
                FillKhataJaatByMoza();
                DataTable dt = mnk.GetFardKhatooniesFardNew(this.SelectedTokenId!=null?this.SelectedTokenId:"0");
                this.fillGridviewFardKhatoonies(dt);
                this.filldgFardKhatas();
            this.GetFardConfDetails(this.SelectedTokenId);
            }

        #endregion

        #region Get Fard Conf Details
        private     void GetFardConfDetails(string TokenId)
        {
            if(TokenId!=null)
            {
                DataTable dt = mnk.GetFardConfDetails(TokenId);
                if(dt!=null)
                {
                    this.isConfirm= Convert.ToBoolean(dt.Rows[0]["isConfirmed"].ToString());
                    btnConfirm.Enabled =!Convert.ToBoolean(dt.Rows[0]["isConfirmed"].ToString());
                    btnUnConfirm.Enabled= Convert.ToBoolean(dt.Rows[0]["isConfirmed"].ToString());
                    txtOperatorReport.Text = dt.Rows[0]["OperatorReport"].ToString();
                    this.gbKhatajat.Enabled = !isConfirm;
                    gbKhatooni.Enabled = !isConfirm;
                    gbKhewatFareeqain.Enabled = !isConfirm;
                    gbMushteriFareeqain.Enabled = !isConfirm;
                    gbOperatorReport.Enabled = !isConfirm;

                }
                else
                {
                    btnUnConfirm.Enabled = false;
                    btnConfirm.Enabled = true;
                    txtOperatorReport.Clear();
                }
            }
        }
        #endregion

        #region Fill Khatajat Drop Dowm
        /// <summary>
        /// Fills khattas drop down with the event of moza selection.
        /// </summary>
        private void FillKhataJaatByMoza()
        {
            try
            {
                DataTable khattasByMoza = new DataTable();
                int mozaid = Convert.ToInt32(this.SelectedMozaId);
                if (mozaid != 0)
                {
                    khattasByMoza =mnk.GetMozaKhattajat(mozaid.ToString());
                    DataRow row = khattasByMoza.NewRow();
                    row["RegisterHqDKhataId"] = 0;
                    row["KhataNo"] = "- کھاتہ چنِے -";
                    khattasByMoza.Rows.InsertAt(row, 0);
                    //this.GetKhataJaatByMozaByRegisterBindingSource.DataSource = this.khattasByMoza;
                    cbokhataNo.DataSource = khattasByMoza;
                    cbokhataNo.DisplayMember = "KhataNo";
                    cbokhataNo.ValueMember = "RegisterHqDKhataId";
                    cbokhataNo.SelectedIndex = 0;
                }
                else
                {
                    cbokhataNo.DataSource = null;
                    khattasByMoza = null;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region Button Search Click Event

        private void btnFindMaalik_Click(object sender, EventArgs e)
            {
            if (string.IsNullOrEmpty(this.SelectedTokenId))
                {
                MessageBox.Show("پہلے ٹوکن کا انتخاب کرہں", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            
            try
                {
                if (string.IsNullOrEmpty(this.SelectedMozaId))
                    {
                    MessageBox.Show("اس ایکشن کے لیے موضع کا چننا ضروری ہے", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                    }
                }
            catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
                }
            }

        #endregion

        #region Gridview Malik Click Event

        private void dgMaalikan_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                //DataGridView g=sender as DataGridView;
                //foreach (DataGridViewRow row in g.Rows)
                //{
                //    if (row.Selected)
                //        row.Cells["chk"].Value = 1;
                //    else
                //        row.Cells["chk"].Value = 0;
                //}
                //if (dgMaalikan.SelectedRows.Count > 0)
                //{
                //string selectedPersonId = dgMaalikan.SelectedRows[0].Cells[1].Value.ToString();
                //string SelectedPersonFamilyId = dgMaalikan.SelectedRows[0].Cells["FamilyId"].Value.ToString();
                //this.FillGridViewMalikKhattas(this.SelectedMozaId, selectedPersonId);
                //this.LoadPersonFamily(SelectedPersonFamilyId);
                //}
                
            }

        #endregion

        #region Form Load Event

        private void frmFard_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Malik Name Auto Urdu Conversion

        private void txtMalikName_KeyPress(object sender, KeyPressEventArgs e)
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

        #region khata selection change event

        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //this.txtFardPersonRecId.Text = "-1";
                //if (this.cbokhataNo.SelectedValue.ToString() != "0")
                //{
                //    this.khewatMalikanByFB = null;
                //    int khataid = Convert.ToInt32(cbokhataNo.SelectedValue.ToString());
                //    this.khewatMalikanByFB = khatas.Proc_Get_KhewatFareeqeinByKhataId(khataid.ToString()); //.GetKhewatFarqeenGroupByKhatId_Misal(this.txtFbId.Text, khataid.ToString());
                //    this.view = new DataView(this.khewatMalikanByFB);
                //    FillGridviewMalkan(khewatMalikanByFB);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fill Gridview Malkan By Khata
        private void FillGridviewMalkan(DataTable dtMalkan)
        {
            if (dtMalkan != null)
            {
                GridViewKhewatMalikaan.DataSource = dtMalkan;
                GridViewKhewatMalikaan.Columns["FardAreaPart"].HeaderText = "حصہ";
                GridViewKhewatMalikaan.Columns["Fard_Area"].HeaderText = " رقبہ منتقلہ";
                GridViewKhewatMalikaan.Columns["Malik_Area"].HeaderText = "کل رقبہ";
                GridViewKhewatMalikaan.Columns["CompleteName"].HeaderText = "نام مالک";
                // GridViewKhewatMalikaan.Columns["CNIC"].HeaderText = "شناختی نمبر";
                //GridViewKhewatMalikaan.Columns["KhewatType"].HeaderText = "قسم مالک";
                GridViewKhewatMalikaan.Columns["isTransactional"].HeaderText = "منہائے ";
                //GridViewKhewatMalikaan.Columns["FardPart_Bata"].Visible = false;
                GridViewKhewatMalikaan.Columns["seqno"].HeaderText = "نمبر شمار";
                GridViewKhewatMalikaan.Columns["KhewatGroupFareeqId"].Visible = false;
                GridViewKhewatMalikaan.Columns["FardPersonRecId"].Visible = false;
                GridViewKhewatMalikaan.Columns["FardPersonId"].Visible = false;
                GridViewKhewatMalikaan.Columns["FardKhataRecId"].Visible = false;
                GridViewKhewatMalikaan.Columns["FardKanal"].Visible = false;
                GridViewKhewatMalikaan.Columns["FardMarla"].Visible = false;
                GridViewKhewatMalikaan.Columns["FardSarsai"].Visible = false;
                GridViewKhewatMalikaan.Columns["FardFeet"].Visible = false;
                GridViewKhewatMalikaan.Columns["CompleteName"].DisplayIndex = 2;
                GridViewKhewatMalikaan.Columns["FardAreaPart"].DisplayIndex = 3;
                GridViewKhewatMalikaan.Columns["seqno"].DisplayIndex = 1;
                GridViewKhewatMalikaan.Columns["CompleteName"].Width = 250;
                GridViewKhewatMalikaan.Columns["ColCheck"].Width = 80;
                GridViewKhewatMalikaan.Columns["seqno"].Width = 80;
            }
            else
                GridViewKhewatMalikaan.DataSource = null;
        }
        #endregion

        #region Gridview KhataMalkan cell click event

        private void GridViewKhewatMalikaan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtFardPersonRecId.Text = "-1";
                DataGridView g = sender as DataGridView;
                if (g.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (row.Selected)
                        {
                            row.Cells["ColCheck"].Value = 1;
                            cboKhewatGroupFareeq.SelectedValue = row.Cells["KhewatGroupFareeqId"].Value;
                            this.cboKhewatGroupFareeq_SelectionChangeCommitted(sender, e);
                            txtFardPersonRecId.Text= row.Cells["FardPersonRecId"].Value.ToString();
                            txtFardPersonId.Text = row.Cells["FardPersonId"].Value.ToString();
                            txtHissaMuntaqla.Text = row.Cells["FardAreaPart"].Value.ToString();
                            txtKanalMuntaqal.Text= row.Cells["FardKanal"].Value.ToString();
                            txtMarlaMuntaqla.Text= row.Cells["FardMarla"].Value.ToString();
                            txtSarsaiMuntaqla.Text= row.Cells["FardSarsai"].Value.ToString();
                            txtSFTmuntaqla.Text= row.Cells["FardFeet"].Value.ToString();
                            chkTransactional.Checked = Convert.ToBoolean(row.Cells["isTransactional"].Value);
                            //chkTransactional.Enabled = !chkTransactional.Checked;
                            //btnSaveKhewatFareeq.Enabled= !chkTransactional.Checked;
                            //btnDelKhewatFareeq.Enabled= !chkTransactional.Checked;
                        }
                        else
                            row.Cells["ColCheck"].Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fard Khata controls

        private void btnSaveKhata_Click(object sender, EventArgs e)
        {
            try
            {
                if(cbokhataNo.SelectedValue.ToString()!="0")
                {
                    string lastId= mnk.SaveFardKhataRecord(txtFardKhataRecId.Text, this.SelectedTokenId, cbokhataNo.SelectedValue.ToString(), UsersManagments._Tehsilid.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    this.filldgFardKhatas();
                    txtFardKhataRecId.Text = "-1";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnNewKhata_Click(object sender, EventArgs e)
        {
            txtFardKhataRecId.Text = "-1";
        }

        private void btnDelKhata_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ واقعی مالک کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                   mnk.DeleteFardKhataRecId(txtFardKhataRecId.Text);
                    this.txtFardKhataRecId.Text = "-1";
                    this.filldgFardKhatas();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GridViewFardKhatajat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnNewKhewatFareeq_Click(sender, e);
                DataGridView g = sender as DataGridView;
                if (g.SelectedRows.Count > 0)
                {
                    foreach(DataGridViewRow row in g.Rows)
                    {
                        if (row.Selected)
                        {
                            row.Cells["colCheckKhata"].Value = 1;
                            txtFardKhataRecId.Text = row.Cells["FardKhataRecId"].Value.ToString();
                            string KhataId= row.Cells["FardKhataId"].Value.ToString();
                            //auto.FillCombo("proc_Get_Intiqal_Khata_Malkan " + KhataId, cboKhewatGroupFareeq, "personname", "KhewatGroupFareeqId");
                            fillKhewatFareeqain(KhataId);
                            DataTable dt = mnk.GetFardKhewatFareeqainFardNew(txtFardKhataRecId.Text);
                            this.FillGridviewMalkan(dt);
                        }
                        else
                            row.Cells["colCheckKhata"].Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fill Khata KheatFareeqain By Khata Id
        private void fillKhewatFareeqain(string khataId)
        {
            try
            {
                this.dtKhewatFareeqainByKhataId = mnk.GetFardKhewatFareeqainByKhataId(khataId);
                if (this.dtKhewatFareeqainByKhataId != null)
                {
                    DataRow row = dtKhewatFareeqainByKhataId.NewRow();
                    row["KhewatGroupFareeqId"] = 0;
                    row["personname"] = "- کھاتہ مالک کا انتخاب کریں -";
                    this.dtKhewatFareeqainByKhataId.Rows.InsertAt(row, 0);
                    //this.GetKhataJaatByMozaByRegisterBindingSource.DataSource = this.khattasByMoza;
                    this.cboKhewatGroupFareeq.DataSource = this.dtKhewatFareeqainByKhataId;
                    this.cboKhewatGroupFareeq.DisplayMember = "personname";
                    this.cboKhewatGroupFareeq.ValueMember = "KhewatGroupFareeqId";
                    this.cboKhewatGroupFareeq.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fill Grid view Fard Khatajat
        private void filldgFardKhatas()
        {
            this.dtFardKhatas = mnk.GetFardMalkanKhataJats(this.SelectedTokenId!=null?this.SelectedTokenId:"0");
            GridViewFardKhatajat.DataSource = dtFardKhatas;
            if (GridViewFardKhatajat.DataSource != null)
            {
                GridViewFardKhatajat.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                GridViewFardKhatajat.Columns["RecordLockedDetails"].HeaderText = "تفصیل لاک";
                GridViewFardKhatajat.Columns["RecordLockingDate"].HeaderText = "تاریخ لاک";
                GridViewFardKhatajat.Columns["RecordLockedCon"].HeaderText = "لاک شدہ";
                GridViewFardKhatajat.Columns["FardKhataRecId"].Visible = false;
                GridViewFardKhatajat.Columns["FardKhataId"].Visible = false;
                GridViewFardKhatajat.Columns["TotalParts"].Visible = false;
                GridViewFardKhatajat.Columns["Khata_Total_Area"].Visible = false;
            }
            FillFardKhataForKhanakasht(dtFardKhatas);
        }

        private void FillFardKhataForKhanakasht(DataTable dt)
        {
            if (dt != null)
            {
                DataTable dtfardkhatajat = new DataTable() ;
                dtfardkhatajat = dt.Copy();
                DataRow row = dtfardkhatajat.NewRow();
                row["FardKhataId"] = 0;
                row["KhataNo"] = "- کھاتہ چنِے -";
                dtfardkhatajat.Rows.InsertAt(row, 0);
                cboKhataNoSaved.DataSource = dtfardkhatajat;
                cboKhataNoSaved.DisplayMember = "KhataNo";
                cboKhataNoSaved.ValueMember = "FardKhataId";
                cboKhataNoSaved.SelectedIndex = 0;
            }
            else
            {
                cboKhataNoSaved.DataSource = null;
            }
        }
        #endregion

        #region Combobox KhewatFareeqain Selection Change Event

        private void cboKhewatGroupFareeq_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow row in dtKhewatFareeqainByKhataId.Rows)
                {
                    if(row["KhewatGroupFareeqId"].ToString()==cboKhewatGroupFareeq.SelectedValue.ToString())
                    {
                        txtKhewatFareeqHissa.Text = row["FardAreaPart"].ToString();
                        txtKhewatFareeqRaqba.Text = row["Fard_Area"].ToString();
                        txtHissaMuntaqla.Text = row["FardAreaPart"].ToString();
                        txtKanalMuntaqal.Text = row["Farad_Kanal"].ToString();
                        txtMarlaMuntaqla.Text = row["Fard_Marla"].ToString();
                        txtSarsaiMuntaqla.Text = row["Fard_Sarsai"].ToString();
                        txtSFTmuntaqla.Text = row["Fard_Feet"].ToString();
                        txtKFkanal.Text= row["Farad_Kanal"].ToString();
                        txtKFmarla.Text= row["Fard_Marla"].ToString();
                        txtKFsarsai.Text= row["Fard_Sarsai"].ToString();
                        txtKFfeet.Text= row["Fard_Feet"].ToString();
                        txtFardPersonId.Text= row["PersonId"].ToString();
                        txtKhewatTypeId.Text= row["KhewatTypeId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region texbox Hissa Muntaqla leave event

        private void txtHissaMuntaqla_Leave(object sender, EventArgs e)
        {
            if(txtHissaMuntaqla.Text.Trim()!="0" && txtHissaMuntaqla.Text.Trim()!=txtKhewatFareeqHissa.Text.Trim())
            {
                float khissa = float.Parse(txtKhewatFareeqHissa.Text);
                int kkanal = Convert.ToInt32(txtKFkanal.Text);
                int kmarla = Convert.ToInt32(txtKFmarla.Text);
                float ksarsai = float.Parse(txtKFsarsai.Text);
                float kfeet = float.Parse(txtKFfeet.Text);
                string[] raqba = common.CalculatedAreaFromHisa(khissa,float.Parse( txtHissaMuntaqla.Text.Trim()), kkanal, kmarla, ksarsai, kfeet);
                txtKanalMuntaqal.Text = raqba[0];
                txtMarlaMuntaqla.Text = raqba[1];
                txtSarsaiMuntaqla.Text = raqba[2];
                txtSFTmuntaqla.Text = raqba[3];
            }
        }

        #endregion

        #region Keypress event for numeric input control 

        private void txtFrokhtSarsai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        #endregion

        #region Button Hissa Bamutabiq Raqba Click Event

        private void bthHissaBamutabiqRaqba_Click(object sender, EventArgs e)
        {

            try
            {
                float khissa = float.Parse(txtKhewatFareeqHissa.Text);
                int kkanal = Convert.ToInt32(txtKFkanal.Text);
                int kmarla = Convert.ToInt32(txtKFmarla.Text);
                float ksarsai = float.Parse(txtKFsarsai.Text);
                float kfeet = float.Parse(txtKFfeet.Text);
                int skanal = Convert.ToInt32(txtKanalMuntaqal.Text);
                int smarla = Convert.ToInt32(txtMarlaMuntaqla.Text);
                float ssarsai = float.Parse(txtSarsaiMuntaqla.Text);
                float sfeet = float.Parse(txtSFTmuntaqla.Text);
                txtHissaMuntaqla.Text = common.CalculatedHisaFromArea(khissa, (float)0, kkanal, kmarla, ksarsai, kfeet, skanal, smarla, ssarsai, sfeet).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Save Fard KhewatFareeq

        private void btnSaveKhewatFareeq_Click(object sender, EventArgs e)
        {
            try
            {
                int skanal = Convert.ToInt32(txtKanalMuntaqal.Text);
                int smarla = Convert.ToInt32(txtMarlaMuntaqla.Text);
                float ssarsai = float.Parse(txtSarsaiMuntaqla.Text);
                float sfeet = float.Parse(txtSFTmuntaqla.Text);
                float shissa = float.Parse(txtHissaMuntaqla.Text);
                string lastId = mnk.SaveFardKhewatFareeqRecord(txtFardPersonRecId.Text, cboKhewatGroupFareeq.SelectedValue.ToString(), txtFardPersonId.Text, txtFardKhataRecId.Text, txtKhewatTypeId.Text, shissa.ToString(), skanal.ToString(), smarla.ToString(), ssarsai.ToString(), sfeet.ToString(), chkTransactional.Checked.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                DataTable dt = mnk.GetFardKhewatFareeqainFardNew(txtFardKhataRecId.Text);
                this.FillGridviewMalkan(dt);
                btnNewKhewatFareeq_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Delete Fard KhewatFareeq

        private void btnNewKhewatFareeq_Click(object sender, EventArgs e)
        {
            txtFardPersonRecId.Text = "-1";
            txtFardPersonId.Text = "-1";
            if(cboKhewatGroupFareeq.DataSource!=null)
            {
                cboKhewatGroupFareeq.SelectedValue = 0;
            }
            txtKhewatFareeqHissa.Text = "0";
            txtKhewatFareeqRaqba.Text="0";
            txtHissaMuntaqla.Text = "0";
            txtKanalMuntaqal.Text = "0";
            txtMarlaMuntaqla.Text = "0";
            txtSarsaiMuntaqla.Text = "0";
            txtSFTmuntaqla.Text = "0";
            txtKFkanal.Text = "0";
            txtKFmarla.Text = "0";
            txtKFsarsai.Text = "0";
            txtKFfeet.Text = "0";
            chkTransactional.Checked = false;
            chkTransactional.Enabled = true;
            btnDelKhewatFareeq.Enabled = true;
            btnSaveKhewatFareeq.Enabled = true;
        }

        #endregion

        #region Button Delete Fard KhewatFareeq click event

        private void btnDelKhewatFareeq_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("آپ واقعی مالک کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    mnk.DeleteFardKhewatFareeq(txtFardPersonRecId.Text);
                    DataTable dt = mnk.GetFardKhewatFareeqainFardNew(txtFardKhataRecId.Text);
                    this.FillGridviewMalkan(dt);
                    btnNewKhewatFareeq_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Combobox Khata Selection Change Event

        private void cboKhataNoSaved_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cboKhataNoSaved.SelectedValue.ToString()!="0")
            {
                auto.FillCombo("Proc_Get_KhatooniNos_List_By_KhataId " + cboKhataNoSaved.SelectedValue.ToString(), cboKhatooniesByKhata, "KhatooniNo", "KhatooniId");
            }
        }

        #endregion

        #region Button New Fard Khatooni Click Event

        private void btnNewKhatooni_Click(object sender, EventArgs e)
        {
            this.txtFardKhatooniRecId.Text = "-1";
            if(cboKhatooniesByKhata.DataSource!=null)
            cboKhatooniesByKhata.SelectedValue = "0";
        }

        #endregion

        #region Button Save Khatooni Click Event

        private void btnSaveKhatooni_Click(object sender, EventArgs e)
        {
            if(cboKhatooniesByKhata.DataSource!=null)
            {
                if(cboKhatooniesByKhata.SelectedValue.ToString()!="0")
                {
                    string lastId = mnk.SaveFardKhatooniRecord(txtFardKhatooniRecId.Text, txtFardKhataRecId.Text, cboKhatooniesByKhata.SelectedValue.ToString(), this.SelectedTokenId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    DataTable dt = mnk.GetFardKhatooniesFardNew(this.SelectedTokenId);
                    fillGridviewFardKhatoonies(dt);
                }
            }
        }

        #endregion

        #region Fill Gridview Fard khatoonies
        private void fillGridviewFardKhatoonies(DataTable dt)
        {
            if (dt != null)
            {
                GridFardKhatoonies.DataSource = dt;
                GridFardKhatoonies.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                GridFardKhatoonies.Columns["Khatooni_Hissa"].HeaderText = "کل حصص";
                GridFardKhatoonies.Columns["Khatooni_Total_Area"].HeaderText = "کل رقبہ";
                GridFardKhatoonies.Columns["FardKhatooniRecId"].Visible = false;
                GridFardKhatoonies.Columns["FardKhatooniId"].Visible = false;
                GridFardKhatoonies.Columns["FardKhataRecId"].Visible = false;
                GridFardKhatoonies.Columns["FardKhataId"].Visible = false;
            }
        }
        #endregion

        #region Gridview Fard Khatoonies Click Event

        private void GridFardKhatoonies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnNewMushteri_Click(sender, e);
                DataGridView g = sender as DataGridView;
                if(g.SelectedRows.Count>0)
                {
                    foreach(DataGridViewRow row in g.Rows)
                    {
                        if (row.Selected)
                        {
                            row.Cells["colCheckKhatooni"].Value = 1;
                            txtFardKhatooniRecId.Text = row.Cells["FardKhatooniRecId"].Value.ToString();
                            txtFardKhatooniId.Text = row.Cells["FardKhatooniId"].Value.ToString();
                            this.fillMushteriFareeqain(txtFardKhatooniId.Text);
                            DataTable dt = mnk.GetFardMushteriFareeqainFardNew(txtFardKhatooniRecId.Text);
                            FillGridviewMushteryan(dt);
                        }
                        else
                            row.Cells["colCheckKhatooni"].Value = 0;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fill Khata KheatFareeqain By Khata Id
        private void fillMushteriFareeqain(string khatooniId)
        {
            try
            {
                this.dtMushteriFareeqainByKhatooniId = mnk.GetFardMushteriFareeqainByKhatooniId(khatooniId);
                if (this.dtMushteriFareeqainByKhatooniId != null)
                {
                    DataRow row = dtMushteriFareeqainByKhatooniId.NewRow();
                    row["MushtriFareeqId"] = 0;
                    row["personname"] = "- کھتونی مالک کا انتخاب کریں -";
                    this.dtMushteriFareeqainByKhatooniId.Rows.InsertAt(row, 0);
                    //this.GetKhataJaatByMozaByRegisterBindingSource.DataSource = this.khattasByMoza;
                    this.cboMushteroFareeqain.DataSource = this.dtMushteriFareeqainByKhatooniId;
                    this.cboMushteroFareeqain.DisplayMember = "personname";
                    this.cboMushteroFareeqain.ValueMember = "MushtriFareeqId";
                    this.cboMushteroFareeqain.SelectedIndex = 0;
                }
                else
                    this.cboMushteroFareeqain.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Combobox Khatooni Mushteryan selection change event

        private void cboMushteroFareeqain_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow row in dtMushteriFareeqainByKhatooniId.Rows)
                {
                    if (row["MushtriFareeqId"].ToString() == cboMushteroFareeqain.SelectedValue.ToString())
                    {
                        txtMushteriHissa.Text = row["FardAreaPart"].ToString();
                        txtMushteriRaqba.Text = row["Fard_Area"].ToString();
                        txtHissaMuntaqlamush.Text = row["FardAreaPart"].ToString();
                        txtKanalMuntaqalMush.Text = row["Farad_Kanal"].ToString();
                        txtMarlaMuntaqalMush.Text = row["Fard_Marla"].ToString();
                        txtSarsaiMuntaqalMush.Text = row["Fard_Sarsai"].ToString();
                        txtSFTmuntaqlaMush.Text = row["Fard_Feet"].ToString();
                        txtKFkanalMush.Text = row["Farad_Kanal"].ToString();
                        txtKFMarlaMush.Text = row["Fard_Marla"].ToString();
                        txtKFSarsaiMush.Text = row["Fard_Sarsai"].ToString();
                        txtKFfeetMush.Text = row["Fard_Feet"].ToString();
                        txtFardPersonidMush.Text = row["PersonId"].ToString();
                        txtKhewatTypeIdMush.Text= row["KhewatTypeId"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button New Mushteri Fareeq Click event

        private void btnNewMushteri_Click(object sender, EventArgs e)
        {
            txtMushteriHissa.Text = "0";
            txtMushteriRaqba.Text = "0";
            txtMushteriRecId.Text = "-1";
            txtFardPersonidMush.Text = "-1";
            txtHissaMuntaqlamush.Text = "0";
            txtKanalMuntaqalMush.Text = "0";
            txtMarlaMuntaqalMush.Text = "0";
            txtSarsaiMuntaqalMush.Text = "0";
            txtSFTmuntaqlaMush.Text = "0";
            txtKFkanalMush.Text = "0";
            txtKFMarlaMush.Text = "0";
            txtKFsarsai.Text = "0";
            txtKFfeetMush.Text = "0";
            chkTransactionalMush.Checked = false;
            chkTransactionalMush.Enabled = true;
            btnsSaveMushteri.Enabled = true;
            btnDelMushteri.Enabled = true;
            if (cboMushteroFareeqain.DataSource != null)
                cboMushteroFareeqain.SelectedValue = 0;
        }

        #endregion

        #region Button Save Fard MushteriFareeq click event

        private void btnsSaveMushteri_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMushteroFareeqain.DataSource != null)
                {
                    if (cboMushteroFareeqain.SelectedValue.ToString() != "0")
                    {
                        int skanal = Convert.ToInt32(txtKanalMuntaqalMush.Text);
                        int smarla = Convert.ToInt32(txtMarlaMuntaqalMush.Text);
                        float ssarsai = float.Parse(txtSarsaiMuntaqalMush.Text);
                        float sfeet = float.Parse(txtSFTmuntaqlaMush.Text);
                        float shissa = float.Parse(txtHissaMuntaqlamush.Text);
                        string lastId = mnk.SaveFardMushteriFareeqRecord(txtMushteriRecId.Text, cboMushteroFareeqain.SelectedValue.ToString(), txtFardPersonidMush.Text, txtFardKhatooniRecId.Text, txtKhewatTypeIdMush.Text, shissa.ToString(), skanal.ToString(), smarla.ToString(), ssarsai.ToString(), sfeet.ToString(), chkTransactionalMush.Checked.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                        DataTable dt = mnk.GetFardMushteriFareeqainFardNew(txtFardKhatooniRecId.Text);
                        FillGridviewMushteryan(dt);
                        btnNewMushteri_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fill Gridview Mushteryan By KhatooniRecId
        private void FillGridviewMushteryan(DataTable dtMalkan)
        {
            if (dtMalkan != null)
            {
                GridViewFardMushteri.DataSource = dtMalkan;
                GridViewFardMushteri.Columns["FardAreaPart"].HeaderText = "حصہ";
                GridViewFardMushteri.Columns["Fard_Area"].HeaderText = " رقبہ منتقلہ";
                GridViewFardMushteri.Columns["Malik_Area"].HeaderText = "کل رقبہ";
                GridViewFardMushteri.Columns["CompleteName"].HeaderText = "نام مالک";
                // GridViewKhewatMalikaan.Columns["CNIC"].HeaderText = "شناختی نمبر";
                //GridViewKhewatMalikaan.Columns["KhewatType"].HeaderText = "قسم مالک";
                GridViewFardMushteri.Columns["isTransactional"].HeaderText = "منہائے ";
                //GridViewKhewatMalikaan.Columns["FardPart_Bata"].Visible = false;
                GridViewFardMushteri.Columns["seqno"].HeaderText = "نمبر شمار";
                GridViewFardMushteri.Columns["MushteriFareeqId"].Visible = false;
                GridViewFardMushteri.Columns["FardMushteriRecId"].Visible = false;
                GridViewFardMushteri.Columns["PersonId"].Visible = false;
                GridViewFardMushteri.Columns["FardKhatooniRecId"].Visible = false;
                GridViewFardMushteri.Columns["FardKanal"].Visible = false;
                GridViewFardMushteri.Columns["FardMarla"].Visible = false;
                GridViewFardMushteri.Columns["FardSarsai"].Visible = false;
                GridViewFardMushteri.Columns["FardFeet"].Visible = false;
                GridViewFardMushteri.Columns["CompleteName"].DisplayIndex = 2;
                GridViewFardMushteri.Columns["FardAreaPart"].DisplayIndex = 3;
                GridViewFardMushteri.Columns["seqno"].DisplayIndex = 1;
                GridViewFardMushteri.Columns["CompleteName"].Width = 250;
                GridViewFardMushteri.Columns["ColCheckMush"].Width = 80;
                GridViewFardMushteri.Columns["seqno"].Width = 80;
            }
            else
                GridViewFardMushteri.DataSource = null;
        }
        #endregion

        #region Button Delete MsuhteriFareeq Click Event

        private void btnDelMushteri_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("آپ واقعی مالک کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    mnk.DeleteFardMsuhteriFareeq(txtMushteriRecId.Text);
                    DataTable dt = mnk.GetFardMushteriFareeqainFardNew(txtFardKhatooniRecId.Text);
                    this.FillGridviewMushteryan(dt);
                    btnNewMushteri_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Gridview Mushteryan Click Event

        private void GridViewFardMushteri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.txtMushteriRecId.Text = "-1";
                DataGridView g = sender as DataGridView;
                if (g.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (row.Selected)
                        {
                            row.Cells["ColCheckMush"].Value = 1;
                            if(cboMushteroFareeqain.DataSource!=null)
                            {
                                cboMushteroFareeqain.SelectedValue = row.Cells["MushteriFareeqId"].Value;
                            }
                            this.cboMushteroFareeqain_SelectionChangeCommitted(sender, e);
                            txtMushteriRecId.Text = row.Cells["FardMushteriRecId"].Value.ToString();
                            txtFardPersonidMush.Text = row.Cells["PersonId"].Value.ToString();
                            txtHissaMuntaqlamush.Text = row.Cells["FardAreaPart"].Value.ToString();
                            txtKanalMuntaqalMush.Text = row.Cells["FardKanal"].Value.ToString();
                            txtMarlaMuntaqalMush.Text = row.Cells["FardMarla"].Value.ToString();
                            txtSarsaiMuntaqla.Text = row.Cells["FardSarsai"].Value.ToString();
                            txtSFTmuntaqlaMush.Text = row.Cells["FardFeet"].Value.ToString();
                            chkTransactionalMush.Checked = Convert.ToBoolean(row.Cells["isTransactional"].Value);
                            //chkTransactionalMush.Enabled = !chkTransactionalMush.Checked;
                            //btnsSaveMushteri.Enabled= !chkTransactionalMush.Checked;
                            //btnDelMushteri.Enabled= !chkTransactionalMush.Checked;
                        }
                        else
                            row.Cells["ColCheckMush"].Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region textbox Hissa Muntaqla Mushteri leave event
        private void txtHissaMuntaqlamush_Leave(object sender, EventArgs e)
        {
            if (txtHissaMuntaqlamush.Text.Trim() != "0" && txtHissaMuntaqlamush.Text.Trim() != txtMushteriHissa.Text.Trim())
            {
                float khissa = float.Parse(txtMushteriHissa.Text);
                int kkanal = Convert.ToInt32(txtKFkanalMush.Text);
                int kmarla = Convert.ToInt32(txtKFMarlaMush.Text);
                float ksarsai = float.Parse(txtKFSarsaiMush.Text);
                float kfeet = float.Parse(txtKFfeetMush.Text);
                string[] raqba = common.CalculatedAreaFromHisa(khissa, float.Parse(txtHissaMuntaqlamush.Text.Trim()), kkanal, kmarla, ksarsai, kfeet);
                txtKanalMuntaqalMush.Text = raqba[0];
                txtMarlaMuntaqalMush.Text = raqba[1];
                txtSarsaiMuntaqalMush.Text = raqba[2];
                txtSFTmuntaqlaMush.Text = raqba[3];
            }
        }
        #endregion

        #region Button Hissa Bamutabiq Raqba Mushteri Click Event

        private void btnHissaBamutabiqRaqbaMush_Click(object sender, EventArgs e)
        {

            try
            {
                float khissa = float.Parse(txtMushteriHissa.Text);
                int kkanal = Convert.ToInt32(txtKFkanalMush.Text);
                int kmarla = Convert.ToInt32(txtKFMarlaMush.Text);
                float ksarsai = float.Parse(txtKFSarsaiMush.Text);
                float kfeet = float.Parse(txtKFfeetMush.Text);
                int skanal = Convert.ToInt32(txtKanalMuntaqalMush.Text);
                int smarla = Convert.ToInt32(txtMarlaMuntaqalMush.Text);
                float ssarsai = float.Parse(txtSarsaiMuntaqalMush.Text);
                float sfeet = float.Parse(txtSFTmuntaqlaMush.Text);
                txtHissaMuntaqlamush.Text = common.CalculatedHisaFromArea(khissa, (float)0, kkanal, kmarla, ksarsai, kfeet, skanal, smarla, ssarsai, sfeet).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Button Print Fard Click Event

        private void btnPrintFard_Click(object sender, EventArgs e)
        {
            if(this.SelectedTokenId!=null && this.SelectedTokenId!="0")
            {
                if (rbShortFard.Checked)
                {
                    UsersManagments.check = 19;
                    frmSDCReportingMain sdcReports = new frmSDCReportingMain();
                    sdcReports.MozaId = this.SelectedMozaId;
                    sdcReports.TokenID = this.SelectedTokenId;
                    sdcReports.Tehsilid = UsersManagments._Tehsilid.ToString();
                    sdcReports.ShowDialog();
                }
                else
                {
                    FardMalikan_Report rptDetail = new FardMalikan_Report();
                    rptDetail.TokenID = this.SelectedTokenId;
                    rptDetail.ShowDialog();
                }
            }
        }

        #endregion

        #region Button Save Operator Report for Fard and update fard status 

        private void btnSaveOperatorReport_Click(object sender, EventArgs e)
        {
            if (this.SelectedTokenId != null && this.SelectedTokenId != "0" && SelectedTokenId != "")
            {
                mnk.SaveFarddStatus(this.SelectedTokenId, "OperatorReport", "0", UsersManagments.UserId.ToString(), UsersManagments.UserName, txtOperatorReport.Text.Trim());
               
                MessageBox.Show("اپریٹر رپورٹ محفوظ ہو گیا ہے۔");
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ مطلوبہ فرد تصدیق کرنا چاہتے ہے؟", "فرد کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                if (this.SelectedTokenId != null && this.SelectedTokenId != "0" && SelectedTokenId != "")
                {
                    mnk.SaveFarddStatus(this.SelectedTokenId, "confirmation", "1", UsersManagments.UserId.ToString(), UsersManagments.UserName, txtOperatorReport.Text.Trim());
                    this.GetFardConfDetails(this.SelectedTokenId);
                }
            }
        }
       
        private void btnUnConfirm_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ مطلوبہ فرد تبدیلی موڈ میں لانا چاہتے ہے؟", "فرد کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {

                if (this.SelectedTokenId != null && this.SelectedTokenId != "0" && SelectedTokenId != "")
                {
                    frmFardBioMetricOperation fbmc = new frmFardBioMetricOperation();
                    fbmc.FormClosed -= Fbmc_FormClosed;
                    fbmc.FormClosed += Fbmc_FormClosed;
                    fbmc.ShowDialog();
                   // mnk.SaveFarddStatus(this.SelectedTokenId, "Confirmation", "1", UsersManagments.UserId.ToString(), UsersManagments.UserName, txtOperatorReport.Text.Trim());
                }
            }
        }

        private void Fbmc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFardBioMetricOperation fbmc = sender as frmFardBioMetricOperation;
            if(fbmc.AttStatus)
            {
                mnk.SaveFarddStatus(this.SelectedTokenId, "unconfirmation", "0", UsersManagments.UserId.ToString(), UsersManagments.UserName, txtOperatorReport.Text.Trim());
                this.GetFardConfDetails(this.SelectedTokenId);
            }
        }

        #endregion
    }
}