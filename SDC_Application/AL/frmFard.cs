using SDC_Application.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using Microsoft.Reporting.WinForms;
using SDC_Application.Classess;
using System.Net;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Collections;

using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using AForge.Video;
using AForge.Video.DirectShow;

using System.Drawing.Imaging;
using SDC_Application.DL;
using LandInfo.ControlsLib;
using System.Data.SqlClient;
using System.Diagnostics;

// this.tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
namespace SDC_Application.AL
    {
    public partial class frmFard : Form
    {
        #region Calss Variables
        private FilterInfoCollection captureDevices;
        private VideoCaptureDevice videoSource;
        Malikan_n_Khattajat MalikanKatajat = new Malikan_n_Khattajat();
        Search search = new Search();
        Persons person = new Persons();
        AutoComplete objauto = new AutoComplete();
        Malikan_n_Khattajat mnk = new Malikan_n_Khattajat();
        LanguageConverter lang = new LanguageConverter();
        TaqseemNewKhataJatMin khatas = new TaqseemNewKhataJatMin();
        AutoComplete auto = new AutoComplete();
        CommanFunctions common = new CommanFunctions();
        AL.frmToken objtoken = new AL.frmToken();
        BL.frmVoucher objVoucher = new BL.frmVoucher();
        Intiqal intiqal = new Intiqal();
        BL.frmToken objbusines = new BL.frmToken();
        BL.frmRecipt objfrmRecipt = new BL.frmRecipt();
        public byte[] imgDataFinger = null;
        public byte[] imgDataPerson = null;
        Persons Pr = new Persons();
        fileIndexing fi = new fileIndexing();
        DataTable dt = new DataTable();
        DataTable dtPayment = new DataTable();
        DataTable dtReceipt = new DataTable();
        DataTable dtGrd = new DataTable();
        DataTable dtKhassrasByKhata = new DataTable();

        public string ReportingFolder { get; set; }
        public string ReportinFolderLand { get; set; }
        public string MozaId { get; set; }
        public string savedKhataId { get; set; }
        public string remarks { get; set; }
        public string dtTokenInIntiqalSeller { get; set; }
        Intiqal Iq = new Intiqal();
        public string dtChkGainTax { get; set; }
        public DateTime tokenDate { get; set; }

        int countSelectedPics = 0;
        string picId;
        string[] files;


        string InsertUserId = UsersManagments.UserId != null ? UsersManagments.UserId.ToString() : "Null";
        string InsertLoginName = UsersManagments.UserName != null ? UsersManagments.UserName.ToString() : "Null";
        string UpdateUserId = UsersManagments.UserId != null ? UsersManagments.UserId.ToString() : "Null";
        string UpdateLoginName = UsersManagments.UserName != null ? UsersManagments.UserName.ToString() : "Null";

        DataTable khewatMalikanByFB = new DataTable();
        datagrid_controls objdatagird = new datagrid_controls();
        DataTable dtKhewatFareeqainByKhataId = new DataTable();
        DataTable dtMushteriFareeqainByKhatooniId = new DataTable();
        DataTable dtFardKhatas = new DataTable();

        public string MaalikType { get; set; }
        public string SelectedMozaId { get; set; }
        public string SelectedTokenId { get; set; }
        public string SelectedTokenNo { get; set; }
        public string SelectedPurposeTypeId { get; set; }

        public bool isConfirm { get; set; }
        int check;
        ArrayList list = new ArrayList();

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
                dtPayment.Clear();
                frmSearch searchToken = new frmSearch();
                searchToken.fromform = "1";
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
                btnNewKhata_Click(sender, e);
                btnNewKhatooni_Click(sender, e);
                btnNewKhewatFareeq_Click(sender, e);
                btnNewMushteri_Click(sender, e);
                frmSearch frm = sender as frmSearch;
                this.SelectedMozaId = frm.mouzaid;
                this.SelectedTokenId = frm.tokenID;
                this.SelectedTokenNo = frm.tokenno;
                this.SelectedPurposeTypeId = frm.tokenPurposeId;
                this.tokenDate = frm.tokenDate;
               
                cboKhataNoSaved.DataSource = null;
                cboKhatooniesByKhata.DataSource = null;


                    txtMoza.Text = frm.mouza;
                    txtReciptTokenID.Text = this.SelectedTokenNo;
                    txtFardType.Text = frm.service;
                    txtHiddenServiceTypeId.Text = frm.hiddenservvicetypeid;
                    FillKhataJaatByMoza();
                    //DataTable dt = mnk.GetFardKhatooniesFardNew(this.SelectedTokenId!=null?this.SelectedTokenId:"0");
                    //this.fillGridviewFardKhatoonies(dt);
                    this.filldgFardKhatas();


                    this.GetFardConfDetails(this.SelectedTokenId);

                    // ============  if Registry fard is 15 days older then cant be changed  ==========================

                    //if (Math.Floor((DateTime.Now - this.tokenDate).TotalDays) > 15 && this.SelectedPurposeTypeId=="19005")
                    if (this.SelectedMozaId != null)
                    {
                        if (mnk.GetFardChangeYesNo(this.tokenDate.ToString(), this.SelectedPurposeTypeId.ToString()) == "-1")
                        {
                            gbKhatajat.Enabled = false;
                            gbKhewatFareeqain.Enabled = false;
                            gbKhatooni.Enabled = false;
                            gbMushteriFareeqain.Enabled = false;
                            btnSaveImage.Enabled = false;
                        }
                        else
                        {
                            gbKhatajat.Enabled = true;
                            gbKhewatFareeqain.Enabled = true;
                            gbKhatooni.Enabled = true;
                            gbMushteriFareeqain.Enabled = true;
                            btnSaveImage.Enabled = true;
                        }
                    }
                    //================ end  =========================================================
                    if (isConfirm && UsersManagments._IsAdmin)
                    {
                        btnEnableFard.Visible = true;
                    }
                    else
                        btnEnableFard.Visible = false;
            this.tabControl1.SelectedIndex = 0;

            }

        #endregion

        #region Get Fard Conf Details
        private     void GetFardConfDetails(string TokenId)
        {
            if(TokenId!=null)
            {
                DataTable dt = mnk.GetFardConfDetails(TokenId);
                if(dt.Rows.Count>0)
                {
                    this.isConfirm= Convert.ToBoolean(dt.Rows[0]["isConfirmed"].ToString());
                    btnConfirm.Enabled =!Convert.ToBoolean(dt.Rows[0]["isConfirmed"].ToString());
                    btnUnConfirm.Enabled= Convert.ToBoolean(dt.Rows[0]["isConfirmed"].ToString());
                    txtOperatorReport.Text = dt.Rows[0]["OperatorReport"].ToString();
                    //--- Restrict Fard Printing ------////
                    if (UsersManagments.UserId.ToString() == dt.Rows[0]["InsertUserId"].ToString() || dt.Rows[0]["InsertUserId"].ToString()=="0")
                        rvIntiqalReport.ShowPrintButton = true;
                    else
                        rvIntiqalReport.ShowPrintButton = false;
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
                GridViewKhewatMalikaan.Columns["KhewatTypeId"].Visible = false;
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
                            string Intiqalat = intiqal.GetIntiqalatByKhewatGroupFareeqId(row.Cells["KhewatGroupFareeqId"].Value.ToString());
                            if (Intiqalat != "0")
                            {
                                MessageBox.Show("اپکا انتخاب کردہ مالک انتقال نمبر "+Intiqalat+ " سابقہ ہوچکاہے۔ ");
                            }
                                cboKhewatGroupFareeq.SelectedValue = row.Cells["KhewatGroupFareeqId"].Value;
                                //this.cboKhewatGroupFareeq_SelectionChangeCommitted(sender, e);
                                txtFardPersonRecId.Text = row.Cells["FardPersonRecId"].Value.ToString();
                                txtFardPersonId.Text = row.Cells["FardPersonId"].Value.ToString();
                                txtHissaMuntaqla.Text = row.Cells["FardAreaPart"].Value.ToString();
                                txtKanalMuntaqal.Text = row.Cells["FardKanal"].Value.ToString();
                                txtMarlaMuntaqla.Text = row.Cells["FardMarla"].Value.ToString();
                                txtSarsaiMuntaqla.Text = row.Cells["FardSarsai"].Value.ToString();
                                txtSFTmuntaqla.Text = row.Cells["FardFeet"].Value.ToString();
                                txtKhewatTypeId.Text = row.Cells["KhewatTypeId"].Value.ToString();
                                chkTransactional.Checked = Convert.ToBoolean(row.Cells["isTransactional"].Value);

                                //chkTransactional.Enabled = !chkTransactional.Checked;
                                //btnSaveKhewatFareeq.Enabled= !chkTransactional.Checked;
                                //btnDelKhewatFareeq.Enabled= !chkTransactional.Checked;

                                //============ For remaining are and hissa in case of updation
                                DataTable dtFareeqain = mnk.GetFardKhewatFareeqainRemainingAreaNewFard(cboKhewatGroupFareeq.SelectedValue.ToString());
                                double KulHissay = 0;
                                double KulKanal = 0;
                                double KulMarla = 0;
                                double KulSarsai = 0; ;
                                double KulFeet = 0; ;
                                if (chkTransactional.Checked == true)
                                {
                                    KulHissay = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Hissa"].ToString()) + Convert.ToDouble(row.Cells["FardAreaPart"].Value.ToString());
                                    KulKanal = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Kanal"].ToString()) + Convert.ToDouble(row.Cells["FardKanal"].Value.ToString());
                                    KulMarla = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Marla"].ToString()) + Convert.ToDouble(row.Cells["FardMarla"].Value.ToString());
                                    KulSarsai = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Sarsai"].ToString()) + Convert.ToDouble(row.Cells["FardSarsai"].Value.ToString());
                                    KulFeet = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Feet"].ToString()) + Convert.ToDouble(row.Cells["FardFeet"].Value.ToString());
                                }
                                else
                                {
                                    KulHissay = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Hissa"].ToString());
                                    KulKanal = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Kanal"].ToString());
                                    KulMarla = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Marla"].ToString());
                                    KulSarsai = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Sarsai"].ToString());
                                    KulFeet = Convert.ToDouble(dtFareeqain.Rows[0]["Rem_Feet"].ToString());
                                }

                                //================================= function for raqba calculate =============================

                                double PersonRaqba = ((KulKanal * 20 + KulMarla) * 272.25) + (KulSarsai > 0 ? KulSarsai * 30.25 : KulFeet);


                                if (PersonRaqba >= 272.25)
                                {
                                    KulFeet = PersonRaqba % 272.25;
                                    KulMarla = Convert.ToInt32((PersonRaqba - KulFeet) / 272.25);

                                    if (KulMarla >= 20)
                                    {
                                        KulKanal = (KulMarla - (KulMarla % 20)) / 20;
                                        KulMarla = KulMarla % 20;


                                    }
                                    else
                                    {
                                        KulKanal = 0;
                                    }

                                }
                                else
                                {
                                    KulMarla = 0;
                                    KulKanal = 0;

                                }
                                if (KulFeet > 0)
                                {
                                    KulSarsai = Math.Round(KulFeet / 30.25, 4);
                                }
                                else
                                {
                                    KulSarsai = 0;
                                }


                                //================================================================================================


                                txtKhewatFareeqHissa.Text = KulHissay.ToString();
                                txtKFkanal.Text = Math.Round(KulKanal, 0).ToString();
                                txtKFmarla.Text = Math.Round(KulMarla, 0).ToString();
                                txtKFsarsai.Text = Math.Round(KulSarsai, 4).ToString();
                                txtKFfeet.Text = Math.Round(KulFeet, 0).ToString();
                                txtKhewatFareeqRaqba.Text = txtKFkanal.Text + "-" + txtKFmarla.Text + "-" + txtKFfeet.Text;

                                btnDelKhewatFareeq.Enabled = true;
                                // ===============  END  =======================================
                            
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
                 this.dtTokenInIntiqalSeller = Iq.GetFardinIntiqalSellerStatus(this.SelectedTokenId);

                 if (this.dtTokenInIntiqalSeller != "0")
                 {
                     MessageBox.Show("یہ فرد انتقال نمبر " + dtTokenInIntiqalSeller.ToString() + " میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                 }
                 else
                 {
                     string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                     if (CancelCheck == "0")
                     {
                         MessageBox.Show("یہ فرد کینسل ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                     }
                     else
                     {
                         if (cbokhataNo.SelectedValue.ToString() != "0")
                         {
                             bool AllKhassras = false;
                             AllKhassras = chkAllKhassras.Checked ? true : false;
                             if ( txtFardKhataRecId.Text.ToString()!="-1" && intiqal.GetFardKhataUpdateValidity(txtFardKhataRecId.Text.ToString())=="0")
                             {
                                 MessageBox.Show("یہ کھاتہ فرد میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                                 
                             }
                             else
                             {
                                 string lastId = mnk.SaveFardKhataRecord(txtFardKhataRecId.Text, this.SelectedTokenId, cbokhataNo.SelectedValue.ToString(), UsersManagments._Tehsilid.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, AllKhassras.ToString());
                             }
                             //string lastId = mnk.SaveFardKhataRecord(txtFardKhataRecId.Text, this.SelectedTokenId, cbokhataNo.SelectedValue.ToString(), UsersManagments._Tehsilid.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName, AllKhassras.ToString());
                             this.filldgFardKhatas();
                             txtFardKhataRecId.Text = "-1";
                             if (cbokhataNo.Items.Count > 0)
                                 cbokhataNo.SelectedIndex = 0;
                         }
                     }
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
            chkAllKhassras.Checked = false;
            if (cbokhataNo.Items.Count > 0)
                cbokhataNo.SelectedIndex = 0;
        }

        private void btnDelKhata_Click(object sender, EventArgs e)
        {

            if (DialogResult.Yes == MessageBox.Show("آپ واقعی ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                     this.dtTokenInIntiqalSeller = Iq.GetFardinIntiqalSellerStatus(this.SelectedTokenId);

                     if (this.dtTokenInIntiqalSeller != "0")
                     {
                         MessageBox.Show("یہ فرد انتقال نمبر " + dtTokenInIntiqalSeller.ToString() + " میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                     }
                     else
                     {
                         string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                         if (CancelCheck == "0")
                         {
                             MessageBox.Show("یہ فرد کینسل ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                         }
                         else
                         {
                             mnk.DeleteFardKhataRecId(txtFardKhataRecId.Text);
                             this.txtFardKhataRecId.Text = "-1";
                             this.filldgFardKhatas();
                             if (cbokhataNo.Items.Count > 0)
                                 cbokhataNo.SelectedIndex = 0;
                         }
                     }
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
                chkAllKhassras.Checked = false;
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
                            chkAllKhassras.Checked = Convert.ToBoolean(row.Cells["AllKhassras"].Value.ToString());
                            cbokhataNo.SelectedValue = row.Cells["FardKhataId"].Value;
                            fillKhewatFareeqain(KhataId);
                            DataTable dt = mnk.GetFardKhewatFareeqainFardNew(txtFardKhataRecId.Text);
                            this.FillGridviewMalkan(dt);

                            cboKhataNoSaved.DataSource = null;
                            cboKhatooniesByKhata.DataSource = null;
                            GridFardKhatoonies.DataSource = null;
                            auto.FillCombo("proc_Self_Get_Fard_Khata_On_Selection  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId + "," + this.SelectedTokenId, cboKhataNoSaved, "KhataNo", "FardKhataId");
                            //auto.FillCombo("Proc_Get_KhassraJatByKhataId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId, cbKhassras, "KhassraNo", "KhassraId");
                           // FillKhassrasByKhataId(KhataId);
                            savedKhataId = KhataId;
                            DataTable dtKK = mnk.GetFardKhatooniesByTokenIdByKhataId(this.SelectedTokenId != null ? this.SelectedTokenId : "0", KhataId);
                            this.fillGridviewFardKhatoonies(dtKK);
                            fillDgKhassrajat();
                              
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

        #region FIll Khassras By Khata

        private void FillKhassrasByKhataId(string KhataId)
        {
            dtKhassrasByKhata = mnk.GetKhassrasByKhataId(KhataId);
            DataTable dtKhassra = dtKhassrasByKhata;
            DataRow row = dtKhassra.NewRow();
            row["KhassraId"] = "0";
            row["KhassraNo"] = "--خسرہ کا انتخاب کریں--";
            dtKhassra.Rows.InsertAt(row, 0);
            cbKhassras.DataSource = dtKhassra;
            cbKhassras.DisplayMember = "KhassraNo";
            cbKhassras.ValueMember = "KhassraId";
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
            this.dtFardKhatas = mnk.GetFardKhatajatFardNew(this.SelectedTokenId != null ? this.SelectedTokenId : "0");
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
                GridViewFardKhatajat.Columns["Kanal"].Visible = false;
                GridViewFardKhatajat.Columns["Marla"].Visible = false;
                GridViewFardKhatajat.Columns["Sarsai"].Visible = false;
                GridViewFardKhatajat.Columns["Khata_Total_Area"].Visible = false;
                GridViewFardKhatajat.Columns["AllKhassras"].Visible = false;
            }
            //FillFardKhataForKhanakasht(dtFardKhatas);
        }

        //private void FillFardKhataForKhanakasht(DataTable dt)
        //{
        //    if (dt != null)
        //    {
        //        DataTable dtfardkhatajat = new DataTable() ;
        //        dtfardkhatajat = dt.Copy();
        //        DataRow row = dtfardkhatajat.NewRow();
        //        row["FardKhataId"] = 0;
        //        row["KhataNo"] = "- کھاتہ چنِے -";
        //        dtfardkhatajat.Rows.InsertAt(row, 0);
        //        cboKhataNoSaved.DataSource = dtfardkhatajat;
        //        cboKhataNoSaved.DisplayMember = "KhataNo";
        //        cboKhataNoSaved.ValueMember = "FardKhataId";
        //        cboKhataNoSaved.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        cboKhataNoSaved.DataSource = null;
        //    }
        //}
        #endregion

        #region Combobox KhewatFareeqain Selection Change Event

        private void cboKhewatGroupFareeq_SelectionChangeCommitted(object sender, EventArgs e)
        {
             try
            {
                foreach (DataRow row in dtKhewatFareeqainByKhataId.Rows) //dtKhewatFareeqainByKhataId
                    
                {
                    
                    if(row["KhewatGroupFareeqId"].ToString()==cboKhewatGroupFareeq.SelectedValue.ToString())
                    {
                       
                        //---- Check for Already Recieived transactional Fard and if exists get remaining Area and Hissa ----- //
                       DataTable dtFareeqain = mnk.GetFardKhewatFareeqainRemainingAreaNewFard(cboKhewatGroupFareeq.SelectedValue.ToString());
                       if (row["CNIC"].ToString().Length < 5 && row["PersonFamilyStatusId"].ToString()=="2")
                       {

                           MessageBox.Show(" انتخاب کردہ مالک کے شناختی کارڈ نمبر کی اندراج کریں۔ آپ کے اسانی کے لئے رجسٹران حقداران زمین میں شناختی کارڈ اندراج کی سہولت دی گئی ہے۔ یا یہاں سے اندراج کر نے کے بعد کھاتہ نمبر پر کلک کر کے مالکان دوبارہ لوڈ کریں۔","اندراج شناختی کارڈ");
                           frmPersonUpdateCNIC ucnic = new frmPersonUpdateCNIC();
                           ucnic.lblPersonName.Text = row["PersonName"].ToString();
                           ucnic.PersonId = row["PersonId"].ToString();
                           ucnic.MozaId = this.SelectedMozaId;
                           ucnic.ShowDialog();
                           break;
                       }
                        
                        
                        txtKhewatTypeId.Text = row["KhewatTypeId"].ToString();
                        txtFardPersonId.Text = row["PersonId"].ToString();
                        txtFardPersonRecId.Text = "-1";
                        //txtKhewatFareeqHissa.Text = row["FardAreaPart"].ToString();
                        //txtHissaMuntaqla.Text = row["FardAreaPart"].ToString();
                        //txtKanalMuntaqal.Text = row["Farad_Kanal"].ToString();
                        //txtMarlaMuntaqla.Text = row["Fard_Marla"].ToString();
                        //txtSarsaiMuntaqla.Text = row["Fard_Sarsai"].ToString();
                        //txtSFTmuntaqla.Text = row["Fard_Feet"].ToString();
                        //txtKFkanal.Text= row["Farad_Kanal"].ToString();
                        //txtKFmarla.Text= row["Fard_Marla"].ToString();
                        //txtKFsarsai.Text= row["Fard_Sarsai"].ToString();
                        //txtKFfeet.Text= row["Fard_Feet"].ToString(); 
                        if (dtFareeqain.Rows.Count > 0)
                        {
                            if (dgKhassrajat.Rows.Count > 0)
                            {
                                int Kanal = 0, Marla = 0; float Sarsai = 0, Feet = 0, FardFeet = 0, KhataHissa = 0, FardHissa = 0;
                                KhataHissa = float.Parse(GridViewFardKhatajat.SelectedRows[0].Cells["TotalParts"].Value.ToString());
                                FardHissa = float.Parse(dtFareeqain.Rows[0]["Rem_Hissa"].ToString());
                                foreach (DataGridViewRow r in dgKhassrajat.Rows)
                                {
                                    Kanal = Kanal + Convert.ToInt32(r.Cells["Kanal"].Value);
                                    Marla = Marla + Convert.ToInt32(r.Cells["Marla"].Value);
                                    Sarsai = Sarsai + Convert.ToInt32(r.Cells["Sarsai"].Value);
                                }
                                Marla = Marla + (Kanal * 20);
                                Sarsai = Sarsai + (Marla * 9);
                                Feet = Sarsai * (float)30.25;
                                FardFeet = (Feet / KhataHissa) * FardHissa;
                                txtKhewatFareeqRaqba.Text = common.FeetToKMF((decimal)FardFeet);
                                string[] FardArea = common.FeetToKMF((decimal)FardFeet).Split('-');
                                txtKhewatFareeqHissa.Text = dtFareeqain.Rows[0]["Rem_Hissa"].ToString();
                                txtHissaMuntaqla.Text = dtFareeqain.Rows[0]["Rem_Hissa"].ToString();
                                txtKanalMuntaqal.Text = FardArea[0] != null ? FardArea[0] : "0";
                                txtMarlaMuntaqla.Text = FardArea[1] != null ? FardArea[1] : "0";
                                txtSarsaiMuntaqla.Text = FardArea[2] != null ? Math.Round((float.Parse(FardArea[2]) / 30.25), 5).ToString() : "0";
                                txtSFTmuntaqla.Text = FardArea[2] != null ? FardArea[2] : "0";
                                txtKFkanal.Text = FardArea[0] != null ? FardArea[0] : "0";
                                txtKFmarla.Text = FardArea[1] != null ? FardArea[1] : "0";
                                txtKFsarsai.Text = FardArea[2] != null ? Math.Round((float.Parse(FardArea[2]) / 30.25), 5).ToString() : "0";
                                txtKFfeet.Text = FardArea[2] != null ? FardArea[2] : "0";

                            }
                            else
                            {
                                txtKhewatFareeqRaqba.Text = dtFareeqain.Rows[0]["FardArea"].ToString();
                                txtKhewatFareeqHissa.Text = dtFareeqain.Rows[0]["Rem_Hissa"].ToString();
                                txtHissaMuntaqla.Text = dtFareeqain.Rows[0]["Rem_Hissa"].ToString();
                                txtKanalMuntaqal.Text = dtFareeqain.Rows[0]["Rem_Kanal"].ToString();
                                txtMarlaMuntaqla.Text = dtFareeqain.Rows[0]["Rem_Marla"].ToString();
                                txtSarsaiMuntaqla.Text = dtFareeqain.Rows[0]["Rem_Sarsai"].ToString();
                                txtSFTmuntaqla.Text = dtFareeqain.Rows[0]["Rem_Feet"].ToString();
                                txtKFkanal.Text = dtFareeqain.Rows[0]["Rem_Kanal"].ToString();
                                txtKFmarla.Text = dtFareeqain.Rows[0]["Rem_Marla"].ToString();
                                txtKFsarsai.Text = dtFareeqain.Rows[0]["Rem_Sarsai"].ToString();
                                txtKFfeet.Text = dtFareeqain.Rows[0]["Rem_Feet"].ToString();

                            }
                            DataTable dt = mnk.GetFardKhewatFareeqainFardNew(txtFardKhataRecId.Text);
                            this.FillGridviewMalkan(dt);
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion


        #region cboMushteroFareeqain_KeyPress
        private void cboMushteroFareeqain_KeyPress(object sender, KeyPressEventArgs e)
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

        #region texbox Hissa Muntaqla leave event

        private void txtHissaMuntaqla_Leave(object sender, EventArgs e)
        {
            if(txtHissaMuntaqla.Text.Trim()!="0" &&  txtHissaMuntaqla.Text.Trim()!="")
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
                this.dtTokenInIntiqalSeller = Iq.GetFardinIntiqalSellerStatus(this.SelectedTokenId);

                if (this.dtTokenInIntiqalSeller != "0")
                {
                    MessageBox.Show("یہ فرد انتقال نمبر "+dtTokenInIntiqalSeller.ToString()+" میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                }
                    
                else
                {
                    string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                    if (CancelCheck == "0")
                    {
                        MessageBox.Show("یہ فرد کینسل ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                    }
                    else
                    {
                        int skanal = Convert.ToInt32(txtKanalMuntaqal.Text);
                        int smarla = Convert.ToInt32(txtMarlaMuntaqla.Text);
                        float ssarsai = float.Parse(txtSarsaiMuntaqla.Text);
                        float sfeet = Math.Round(float.Parse(txtSFTmuntaqla.Text), 0) < Math.Round((float.Parse(txtSarsaiMuntaqla.Text) * (float)30.25), 0) ?(float)Math.Round((float.Parse(txtSarsaiMuntaqla.Text) * (float)30.25), 0) :(float)Math.Round(float.Parse(txtSFTmuntaqla.Text), 0);
                        float shissa = float.Parse(txtHissaMuntaqla.Text);
                        string[] totalArea=txtKhewatFareeqRaqba.Text.Split('-');
                        float Totalfeet= (float.Parse(totalArea[0])*20*(float)272.25)+(float.Parse(totalArea[1])*(float)272.25)+(float.Parse(totalArea[2])*(float)30.25);
                        float TransFeet=(float.Parse(skanal.ToString())*20*(float)272.25)+(float.Parse(smarla.ToString())*(float)272.25)+sfeet;
                        if (float.Parse(txtKhewatFareeqHissa.Text) < shissa)
                        {
                            MessageBox.Show("حصہ منتقلہ کل حصص سے زیادہ ہے۔", "حصہ منتقلہ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if(TransFeet>(Totalfeet+5))
                        {
                            MessageBox.Show("رقبہ منتقلہ کل رقبہ سے زیادہ ہے۔", "رقبہ منتقلہ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            string lastId = mnk.SaveFardKhewatFareeqRecord(txtFardPersonRecId.Text, cboKhewatGroupFareeq.SelectedValue.ToString(), txtFardPersonId.Text, txtFardKhataRecId.Text, txtKhewatTypeId.Text, shissa.ToString(), skanal.ToString(), smarla.ToString(), ssarsai.ToString(), sfeet.ToString(), chkTransactional.Checked.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                            DataTable dt = mnk.GetFardKhewatFareeqainFardNew(txtFardKhataRecId.Text);
                            this.FillGridviewMalkan(dt);
                            btnNewKhewatFareeq_Click(sender, e);
                        }
                    }
                }
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
            txtKhewatTypeId.Text = "-1";
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
            //chkTransactional.Checked = false;
            chkTransactional.Enabled = true;
            btnDelKhewatFareeq.Enabled = false;
            btnSaveKhewatFareeq.Enabled = true;
        }

        #endregion

        #region Button Delete Fard KhewatFareeq click event

        private void btnDelKhewatFareeq_Click(object sender, EventArgs e)
        {
            try
            {
                 this.dtTokenInIntiqalSeller = Iq.GetFardinIntiqalSellerStatus(this.SelectedTokenId);

                 if (this.dtTokenInIntiqalSeller != "0")
                 {
                     MessageBox.Show("یہ فرد انتقال نمبر " + dtTokenInIntiqalSeller.ToString() + " میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                 }
                 else
                 {
                     string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                     if (CancelCheck == "0")
                     {
                         MessageBox.Show("یہ فرد کینسل ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                     }
                     else
                     {
                         if (DialogResult.Yes == MessageBox.Show("آپ واقعی مالک کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                         {
                             mnk.DeleteFardKhewatFareeq(txtFardPersonRecId.Text);
                             DataTable dt = mnk.GetFardKhewatFareeqainFardNew(txtFardKhataRecId.Text);
                             this.FillGridviewMalkan(dt);
                             btnNewKhewatFareeq_Click(sender, e);
                         }
                     }
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
                savedKhataId = cboKhataNoSaved.SelectedValue.ToString();
                auto.FillCombo("Proc_Get_KhatooniNos_List_By_KhataId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cboKhataNoSaved.SelectedValue.ToString(), cboKhatooniesByKhata, "KhatooniNo", "KhatooniId");
                //DataTable dt = mnk.GetFardKhatooniesFardNew(this.SelectedTokenId);
                
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
             this.dtTokenInIntiqalSeller = Iq.GetFardinIntiqalSellerStatus(this.SelectedTokenId);

             if (this.dtTokenInIntiqalSeller != "0")
             {
                 MessageBox.Show("یہ فرد انتقال نمبر " + dtTokenInIntiqalSeller.ToString() + " میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
             }
             else
             {
                 string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                 if (CancelCheck == "0")
                 {
                     MessageBox.Show("یہ فرد کینسل ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                 }
                 else
                 {
                     if (cboKhatooniesByKhata.DataSource != null)
                     {
                         if (cboKhatooniesByKhata.SelectedValue.ToString() != "0")
                         {
                             if (txtFardKhataRecId.Text == "-1" || txtFardKhataRecId.Text == "0")
                             {
                                 MessageBox.Show("کھتونی محفوظ کرنے سے پہلے پچھلے ٹیب کے گریڈ سے کھاتے کا انتخاب کریں۔", "کھاتے کا انتخاب");
                             }
                             else
                             {
                                 if (txtFardKhatooniRecId.Text.ToString() != "-1" && intiqal.GetFardKhatooniUpdateValidity(txtFardKhatooniRecId.Text.ToString()) == "0")
                                 {
                                     MessageBox.Show("یہ کھتونی فرد میں استعمال ہوا ہے لھٰذا تبدیل نہیں ہو سکتا");

                                 }
                                 else
                                 {
                                     string lastId = mnk.SaveFardKhatooniRecord(txtFardKhatooniRecId.Text, txtFardKhataRecId.Text, cboKhatooniesByKhata.SelectedValue.ToString(), this.SelectedTokenId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                                 }
                                 //DataTable dt = mnk.GetFardKhatooniesFardNew(this.SelectedTokenId);
                                 DataTable dt = mnk.GetFardKhatooniesByTokenIdByKhataId(this.SelectedTokenId != null ? this.SelectedTokenId : "0", savedKhataId);
                                 fillGridviewFardKhatoonies(dt);
                             }
                         }
                     }
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
                        DataTable dtMushteryan = mnk.GetFardMushteriFareeqainRemainingAreaNewFard(cboMushteroFareeqain.SelectedValue.ToString());
                        txtFardPersonidMush.Text = row["PersonId"].ToString();
                        txtKhewatTypeIdMush.Text = row["KhewatTypeId"].ToString();
                        txtMushteriRecId.Text = "-1";
                        if (dtMushteryan.Rows.Count > 0)
                        {
                            //txtMushteriHissa.Text = row["FardAreaPart"].ToString();
                            //txtMushteriRaqba.Text = row["Fard_Area"].ToString();
                            //txtHissaMuntaqlamush.Text = row["FardAreaPart"].ToString();
                            //txtKanalMuntaqalMush.Text = row["Farad_Kanal"].ToString();
                            //txtMarlaMuntaqalMush.Text = row["Fard_Marla"].ToString();
                            //txtSarsaiMuntaqalMush.Text = row["Fard_Sarsai"].ToString();
                            //txtSFTmuntaqlaMush.Text = row["Fard_Feet"].ToString();
                            //txtKFkanalMush.Text = row["Farad_Kanal"].ToString();
                            //txtKFMarlaMush.Text = row["Fard_Marla"].ToString();
                            //txtKFSarsaiMush.Text = row["Fard_Sarsai"].ToString();
                            //txtKFfeetMush.Text = row["Fard_Feet"].ToString();

                            txtMushteriHissa.Text = dtMushteryan.Rows[0]["Rem_Hissa"].ToString();
                            txtMushteriRaqba.Text = dtMushteryan.Rows[0]["FardArea"].ToString();
                            txtHissaMuntaqlamush.Text = dtMushteryan.Rows[0]["Rem_Hissa"].ToString();
                            txtKanalMuntaqalMush.Text = dtMushteryan.Rows[0]["Rem_Kanal"].ToString();
                            txtMarlaMuntaqalMush.Text = dtMushteryan.Rows[0]["Rem_Marla"].ToString();
                            txtSarsaiMuntaqalMush.Text = dtMushteryan.Rows[0]["Rem_Sarsai"].ToString();
                            txtSFTmuntaqlaMush.Text = dtMushteryan.Rows[0]["Rem_Feet"].ToString();
                            txtKFkanalMush.Text = dtMushteryan.Rows[0]["Rem_Kanal"].ToString();
                            txtKFMarlaMush.Text = dtMushteryan.Rows[0]["Rem_Marla"].ToString();
                            txtKFSarsaiMush.Text = dtMushteryan.Rows[0]["Rem_Sarsai"].ToString();
                            txtKFfeetMush.Text = dtMushteryan.Rows[0]["Rem_Feet"].ToString();

                            DataTable dt = mnk.GetFardMushteriFareeqainFardNew(txtFardKhatooniRecId.Text);
                            FillGridviewMushteryan(dt);
                        }
                        
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
            txtKhewatTypeIdMush.Text = "-1";
            txtHissaMuntaqlamush.Text = "0";
            txtKanalMuntaqalMush.Text = "0";
            txtMarlaMuntaqalMush.Text = "0";
            txtSarsaiMuntaqalMush.Text = "0";
            txtSFTmuntaqlaMush.Text = "0";
            txtKFkanalMush.Text = "0";
            txtKFMarlaMush.Text = "0";
            txtKFSarsaiMush.Text = "0";
            txtKFfeetMush.Text = "0";
            //chkTransactionalMush.Checked = false;
            chkTransactionalMush.Enabled = true;
            btnsSaveMushteri.Enabled = true;
            btnDelMushteri.Enabled = false;
            if (cboMushteroFareeqain.DataSource != null)
                cboMushteroFareeqain.SelectedValue = 0;
        }

        #endregion

        #region Button Save Fard MushteriFareeq click event

        private void btnsSaveMushteri_Click(object sender, EventArgs e)
        {
            try
            {
                 this.dtTokenInIntiqalSeller = Iq.GetFardinIntiqalSellerStatus(this.SelectedTokenId);

                 if (this.dtTokenInIntiqalSeller != "0")
                 {
                     MessageBox.Show("یہ فرد انتقال نمبر " + dtTokenInIntiqalSeller.ToString() + " میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                 }
                 else
                 {
                     string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                     if (CancelCheck == "0")
                     {
                         MessageBox.Show("یہ فرد کینسل ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                     }
                     else
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
                GridViewFardMushteri.Columns["KhewatType"].Visible = false;
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
                this.dtTokenInIntiqalSeller = Iq.GetFardinIntiqalSellerStatus(this.SelectedTokenId);

                if (this.dtTokenInIntiqalSeller != "0")
                {
                    MessageBox.Show("یہ فرد انتقال نمبر " + dtTokenInIntiqalSeller.ToString() + " میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                }
                else
                {
                    string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                    if (CancelCheck == "0")
                    {
                        MessageBox.Show("یہ فرد کینسل ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("آپ واقعی مالک کا ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                        {
                            mnk.DeleteFardMsuhteriFareeq(txtMushteriRecId.Text);
                            DataTable dt = mnk.GetFardMushteriFareeqainFardNew(txtFardKhatooniRecId.Text);
                            this.FillGridviewMushteryan(dt);
                            btnNewMushteri_Click(sender, e);
                        }
                    }
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
                           // this.cboMushteroFareeqain_SelectionChangeCommitted(sender, e);
                            txtMushteriRecId.Text = row.Cells["FardMushteriRecId"].Value.ToString();
                            txtFardPersonidMush.Text = row.Cells["PersonId"].Value.ToString();
                            txtHissaMuntaqlamush.Text = row.Cells["FardAreaPart"].Value.ToString();
                            txtKanalMuntaqalMush.Text = row.Cells["FardKanal"].Value.ToString();
                            txtMarlaMuntaqalMush.Text = row.Cells["FardMarla"].Value.ToString();
                            txtSarsaiMuntaqalMush.Text = row.Cells["FardSarsai"].Value.ToString();
                            txtSFTmuntaqlaMush.Text = row.Cells["FardFeet"].Value.ToString();
                            txtKhewatTypeIdMush.Text = row.Cells["KhewatType"].Value.ToString();
                            chkTransactionalMush.Checked = Convert.ToBoolean(row.Cells["isTransactional"].Value);
                            //chkTransactionalMush.Enabled = !chkTransactionalMush.Checked;
                            //btnsSaveMushteri.Enabled= !chkTransactionalMush.Checked;
                            //btnDelMushteri.Enabled= !chkTransactionalMush.Checked;

                            //============ For remaining are and hissa in case of updation
                            DataTable dtMushteryan = mnk.GetFardMushteriFareeqainRemainingAreaNewFard(cboMushteroFareeqain.SelectedValue.ToString());
                            double KulHissay = 0;
                            double KulKanal = 0;
                            double KulMarla = 0;
                            double KulSarsai = 0; ;
                            double KulFeet = 0; ;
                            if (chkTransactionalMush.Checked == true)
                            {
                                KulHissay = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Hissa"].ToString()) + Convert.ToDouble(row.Cells["FardAreaPart"].Value.ToString());
                                KulKanal = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Kanal"].ToString()) + Convert.ToDouble(row.Cells["FardKanal"].Value.ToString());
                                KulMarla = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Marla"].ToString()) + Convert.ToDouble(row.Cells["FardMarla"].Value.ToString());
                                KulSarsai = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Sarsai"].ToString()) + Convert.ToDouble(row.Cells["FardSarsai"].Value.ToString());
                                KulFeet = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Feet"].ToString()) + Convert.ToDouble(row.Cells["FardFeet"].Value.ToString());
                            }
                            else
                            {
                                KulHissay = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Hissa"].ToString());
                                KulKanal = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Kanal"].ToString());
                                KulMarla = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Marla"].ToString());
                                KulSarsai = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Sarsai"].ToString());
                                KulFeet = Convert.ToDouble(dtMushteryan.Rows[0]["Rem_Feet"].ToString());
                            }

                            //================================= function for raqba calculate =============================

                            double PersonRaqba = ((KulKanal * 20 + KulMarla) * 272.25) + (KulSarsai > 0 ? KulSarsai * 30.25 : KulFeet);


                            if (PersonRaqba >= 272.25)
                            {
                                KulFeet = PersonRaqba % 272.25;
                                KulMarla = Convert.ToInt32((PersonRaqba - KulFeet) / 272.25);

                                if (KulMarla >= 20)
                                {
                                    KulKanal = (KulMarla - (KulMarla % 20)) / 20;
                                    KulMarla = KulMarla % 20;


                                }
                                else
                                {
                                    KulKanal = 0;
                                }

                            }
                            else
                            {
                                KulMarla = 0;
                                KulKanal = 0;

                            }
                            if (KulFeet > 0)
                            {
                                KulSarsai = Math.Round(KulFeet / 30.25, 4);
                            }
                            else
                            {
                                KulSarsai = 0;
                            }


                            //================================================================================================


                            txtMushteriHissa.Text = KulHissay.ToString();
                            txtKFkanalMush.Text = Math.Round(KulKanal, 0).ToString();
                            txtKFMarlaMush.Text = Math.Round(KulMarla, 0).ToString();
                            txtKFSarsaiMush.Text = Math.Round(KulSarsai, 4).ToString();
                            txtKFfeetMush.Text = Math.Round(KulFeet, 0).ToString();
                            txtMushteriRaqba.Text = txtKFkanalMush.Text + "-" + txtKFMarlaMush.Text + "-" + txtKFfeetMush.Text;

                           btnDelMushteri.Enabled = true;
                            // ===============  END  =======================================
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
            if (txtHissaMuntaqlamush.Text.Trim() != "0" && txtHissaMuntaqlamush.Text.Trim() != "")
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

        # region set credential 
        private void SetCredentials(string report, ReportParameter[] r, bool isSdcReports)
        {
            this.rvIntiqalReport.RefreshReport();
            string Server = "http://" + SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["rptserver"]) + UsersManagments._rptPort + "/ReportServer";//ReportServerTextBox.Text;
            string reportProject = "/" + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"] + "/";
            string reportProjectLand = "/" + System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"] + "/";
            string reportName = report; //"IntiqalMainPart_Baeh_ADC";
            rvIntiqalReport.ProcessingMode = ProcessingMode.Remote;
            ServerReport serverReport;
            serverReport = rvIntiqalReport.ServerReport;

            string usr = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["usr"]);
            string password = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["adpsreport"]);
            string domain = SDC_Application.Classess.Crypto.Decrypt(System.Configuration.ConfigurationSettings.AppSettings["domain"]);
            this.ReportingFolder = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolder"];
            this.ReportinFolderLand = System.Configuration.ConfigurationSettings.AppSettings["ReportingFolderLand"];
            //

            NetworkCredential myCred = new
                NetworkCredential(usr, password, domain);//"sdc2-psh-svr1");
            rvIntiqalReport.ServerReport.ReportServerCredentials.NetworkCredentials =
                myCred;
            //
            serverReport.ReportServerUrl = new Uri(Server);
            if (isSdcReports)
            {
                serverReport.ReportPath = reportProject + reportName; //FolderTextBox.Text + ReportNameTextBox1.Text;
            }
            else
            {
                serverReport.ReportPath = reportProjectLand + reportName;
            }

            //You can add Parameter if need
            ReportParameter[] rp = new ReportParameter[1];
            rp = r;
            if (UsersManagments.check != 7)
            {
                rvIntiqalReport.ServerReport.SetParameters(rp);
            }
            else
            {
                rvIntiqalReport.ShowParameterPrompts = true;
            }
            rvIntiqalReport.RefreshReport();
        }


        #endregion
        #region Button Print Fard Click Event

        private void btnPrintFard_Click(object sender, EventArgs e)
        {
            if(this.SelectedTokenId!=null && this.SelectedTokenId!="0")
            {
                if (rbShortFard.Checked)
                {
                    
                    ReportParameter[] rp = new ReportParameter[4];
                    rp[0] = new ReportParameter("MozaId", this.SelectedMozaId);
                    rp[1] = new ReportParameter("TokenId", this.SelectedTokenId);
                    rp[2] = new ReportParameter("currentUser", UsersManagments.UserId.ToString());
                    rp[3] = new ReportParameter("tehsilid", UsersManagments._Tehsilid.ToString());
                    this.SetCredentials("FardForPersonalRecordTrans", rp, false);
                }
                else
                {
                    FardMalikan_Report rptDetail = new FardMalikan_Report();
                    rptDetail.TokenID = this.SelectedTokenId;
                    rptDetail.isTrans = true;
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

       #region Get Stream from Image File

        /// <summary>
        /// Gets the image at the specified path, shrinks it, converts to JPG, and returns as a stream
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        private Stream GetImageStream(string imagePath)
        {
            var ms = new MemoryStream();
            using (var img = Image.FromFile(imagePath))
            {
                var jpegCodec = ImageCodecInfo.GetImageEncoders()
                    .Where(x => x.MimeType == "image/jpeg")
                    .FirstOrDefault();

                var encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)20);

                int dpi = 175;
                var thumb = img.GetThumbnailImage((int)(11.692 * dpi), (int)(8.267 * dpi), null, IntPtr.Zero);
                thumb.Save(ms, jpegCodec, encoderParams);
            }
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }

        #endregion
        #region saved Images
        public Image MStream(byte[] img)
        {
            MemoryStream stream = new MemoryStream(img);

            return Image.FromStream(stream);

        }
        public byte[] imageToByteArray(Image imageIn)
        {

            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        #endregion


        #region selection from Grid for Finger Capture
        private void grfIntiqalPersonSanps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pboxFingerPrint.Image = null;
            imgDataFinger = null;
            pboxPicture.Image = null;
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grfIntiqalPersonSanps.CurrentRow.Cells["Selection"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grfIntiqalPersonSanps.SelectedRows.Count > 0)
                    {

                        if (row.Selected)
                        {

                            row.Cells["Selection"].Value = 1;
                            if (Math.Floor((DateTime.Now - this.tokenDate).TotalDays) < 16)
                            {
                                btnSaveImage.Enabled = true;
                            }
                            this.txtName.Text = row.Cells["CompleteName"].Value.ToString();
                            this.txtpersonID.Text = row.Cells["PersonID"].Value.ToString();
                            if (row.Cells["FardRepRecId"].Value.ToString() != "0")
                            {
                                this.txtRepRecId.Text = row.Cells["FardRepRecId"].Value.ToString();
                                this.txtRepName.Text = row.Cells["Name"].Value.ToString();
                                this.txtRepFName.Text = row.Cells["FatherName"].Value.ToString();
                                this.txtRepCNIC.Text = row.Cells["CNIC"].Value.ToString();
                                this.btnRepDel.Enabled = true;
                            }
                            else
                            {
                                btnRepReset_Click(sender, e);
                            }
                            txtIntPersonImageid.Text = "-1";
                            // Get and Load if Person Pics are already saved... 
                            GetPersonFingerPrint(this.txtpersonID.Text, this.txtRepRecId.Text);



                        }
                        else
                        {
                            row.Cells["Selection"].Value = 0;
                            //grfIntiqalPersonSanps.Rows.Clear();
                        }
                    }
                }
            }
        }
        #endregion


        #region Get Person Finger Print and Image if Already saved..

        private void GetPersonFingerPrint(string PersonId, string FardRepRecId)
        {
           
            DataTable PersonPics = new System.Data.DataTable();
            PersonPics = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_Fard_PersonFingerPrint_By_PersonId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.SelectedTokenId + ",'" + PersonId + "','" + FardRepRecId + "'");
          
            if (PersonPics != null)
            {
                if (PersonPics.Rows.Count > 0)
                {
                    foreach (DataRow dr in PersonPics.Rows)
                    {

                        if(dr["PersonFingerPrint"].ToString().Length>10)
                            pboxFingerPrint.Image = (byte[])dr["PersonFingerPrint"] != null ? Resource1.FingerprintImage : null;
                        if (dr["PersonFingerPrint"].ToString().Length > 10)
                            imgDataFinger = (byte[])dr["PersonFingerPrint"];
                        txtIntPersonImageid.Text = dr["FardPersonFingerId"].ToString();
                        pboxPicture.Image = dr["PersonPic"] != DBNull.Value ? MStream((byte[])dr["PersonPic"]) : null;

                    }
                }
                else
                {

                    pboxFingerPrint.Image = null;
                    imgDataFinger = null;
                }



            }
        }

        #endregion


        #region Finger Prints
        public void grfFardPersonSanps()
        {
            if (grfIntiqalPersonSanps.DataSource != null)
            {
                grfIntiqalPersonSanps.Columns["Selection"].DisplayIndex = 0;
                grfIntiqalPersonSanps.Columns["CompleteName"].DisplayIndex = 1;
                grfIntiqalPersonSanps.Columns["MType"].DisplayIndex = 2;
                // grfIntiqalPersonSanps.Columns["PersonFingerPrint"].DisplayIndex = 2;
                grfIntiqalPersonSanps.Columns["CompleteName"].HeaderText = "فرد تفصیل";
                grfIntiqalPersonSanps.Columns["cnic"].HeaderText = "شناختی کارڈ";
                grfIntiqalPersonSanps.Columns["MType"].HeaderText = "قسم ملکیت";
                grfIntiqalPersonSanps.Columns["PersonID"].Visible = false;
                grfIntiqalPersonSanps.Columns["Name"].Visible = false;
                grfIntiqalPersonSanps.Columns["FatherName"].Visible = false;
                grfIntiqalPersonSanps.Columns["FardRepRecId"].Visible = false;
            }
             
             }
#endregion


        #region btnDelKhatooni_Click
        private void btnDelKhatooni_Click(object sender, EventArgs e)
        {
            try
            {
                 this.dtTokenInIntiqalSeller = Iq.GetFardinIntiqalSellerStatus(this.SelectedTokenId);

                 if (this.dtTokenInIntiqalSeller != "0")
                 {
                     MessageBox.Show("یہ فرد انتقال نمبر " + dtTokenInIntiqalSeller.ToString() + " میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                 }
                 else
                 {
                     string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                     if (CancelCheck == "0")
                     {
                         MessageBox.Show("یہ فرد کینسل ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                     }
                     else
                     {
                         if (DialogResult.Yes == MessageBox.Show("آپ واقعی ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                         {
                             mnk.DeleteFardKhatooniRecId(txtFardKhatooniRecId.Text);
                            // DataTable dt = mnk.GetFardKhatooniesFardNew(this.SelectedTokenId != null ? this.SelectedTokenId : "0");
                             DataTable dt = mnk.GetFardKhatooniesByTokenIdByKhataId(this.SelectedTokenId != null ? this.SelectedTokenId : "0", savedKhataId);
                             this.fillGridviewFardKhatoonies(dt);
                             btnNewKhatooni_Click(sender, e);
                         }
                     }
                 }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFingerPrint_Click(object sender, EventArgs e)
        {
            frmFingerPrint Populate = new frmFingerPrint();
            Populate.FormClosed -= new FormClosedEventHandler(Populate_FormClosed);
            Populate.FormClosed += new FormClosedEventHandler(Populate_FormClosed);
            Populate.ShowDialog();           
        }
        #endregion

        #region form close
        private void Populate_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFingerPrint Populate = sender as frmFingerPrint;

            if (Populate.Btn)
            {
                if (Populate.FPTempByte != null)
                {
                    imgDataFinger = Populate.FPTempByte;
                    pboxFingerPrint.Image = Resource1.FingerprintImage;
                }

            }

        }
        #endregion

        #region verify fingerprint
        private void btnVerifyFingerPrint_Click(object sender, EventArgs e)
        {
            
            frmVerificationFinger_old verifyFingerPrint = new frmVerificationFinger_old();
            verifyFingerPrint.PersonFingerPrint = imgDataFinger;
            verifyFingerPrint.ShowDialog();
        

        }
#endregion

        #region save finger
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            bool InsertionSuccesfull = false;

            if (txtName.Text != "")
            {
                string PersonFingerPrintId = this.txtIntPersonImageid.Text.Trim();
                string tokenId = this.SelectedTokenId;
                string PersonId = this.txtpersonID.Text;
                string FardRepRecId = null;
                if (txtRepRecId.Text.Trim() != "-1")
                {
                    FardRepRecId = this.txtRepRecId.Text;
                }
                Image imgfinger = pboxFingerPrint.Image;
                Image imgPerson = pboxPicture.Image;

                if (pboxPicture.Image != null)
                {
                    imgDataPerson = imageToByteArray(imgPerson);
                }


                try
                {
                    
                     this.dtTokenInIntiqalSeller = Iq.GetFardinIntiqalSellerStatus(this.SelectedTokenId);

                     if (this.dtTokenInIntiqalSeller != "0")
                     {
                         MessageBox.Show("یہ فرد انتقال نمبر " + dtTokenInIntiqalSeller.ToString() + " میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                     }
                     else
                     {
                         string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                         if (CancelCheck == "0")
                         {
                             MessageBox.Show("یہ فرد کینسل ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                         }
                         else
                         {
                             string DI = fi.saveFingerImageSelf(PersonFingerPrintId, tokenId, PersonId,FardRepRecId, imgDataPerson, imgDataFinger, InsertUserId, InsertLoginName, UpdateUserId, UpdateLoginName).ToString();

                             if (DI != null)
                             {
                                 //foreach (DataGridViewRow row in grfIntiqalPersonSanps.Rows)
                                 //{
                                 //    if (row.Cells["PersonPic"].Value != null)
                                 //    {
                                 //        row.Cells["PersonPic"].Value = null;
                                 //        row.Cells["PersonFingerPrint"].Value = null;
                                 //        row.Height = 30;
                                 //    }

                                 //}
                                 txtIntPersonImageid.Text = DI;
                                 InsertionSuccesfull = true;
                                 btnSaveImage.Enabled = false;

                                 pboxFingerPrint.Image = null;
                                 txtIntPersonImageid.Text = "-1";
                                 pboxPicture.Image = null;

                                 this.txtName.Clear();
                                 this.txtpersonID.Clear();

                                 btnRepReset_Click(sender, e);

                             }
                         }
                     }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("نام اور انگھوٹے کا انتخاب کیجیئے", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (InsertionSuccesfull)
            {
               
                grfIntiqalPersonSanps.CurrentRow.Selected = true;
            }


        }
        private void btnRepReset_Click(object sender, EventArgs e)
        {
            txtRepName.Clear();
            txtRepFName.Clear();
            txtRepCNIC.Clear();
            txtRepRecId.Text = "-1";
            btnRepDel.Enabled = false;
        }
        #endregion


        #region Tooltip

        public void tooltip()
        {
            tt.SetToolTip(btnCancelFard, "فرد کینسل کریں");
          
            tt.SetToolTip(dgvCancel, "دستاویزات دیکھنے کے لئے ڈل کلک کریں");
           
           
            tt.SetToolTip(btnPics, "دستاویزات سیلیکٹ کریں");
            tt.SetToolTip(btnSave, "محفوظ کریں");


        }

        #endregion



        #region Get_SDC_Services_For_PaymentVoucher
        public void Proc_Get_SDC_Services_For_PaymentVoucher()
        {

            objauto.FillCombo("Proc_Get_SDC_Services_For_PaymentVoucher  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + txtHiddenServiceTypeId.Text + "'", txtServiceName, "SDCServiceName_Urdu", "TaxNotificationDetailId");

        }

        #endregion

        #region save Master Payment
        private void btnMasterSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_PaymentVoucherMaster '"
                + "-1" + "','"
                + UsersManagments._Tehsilid.ToString() + "','"
                + "-1" + "','"
                + this.dtChallan.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "','"
                + this.SelectedTokenId.ToString() + "','"
                + this.MozaId + "','"
                 + "Generated" + "',N'" + this.txtMasterRemarks.Text.ToString() + "','"
                + UsersManagments.UserId.ToString() + "','"
                + UsersManagments.UserName.ToString() + "','',''");

                foreach (DataRow dr in dt.Rows)
                {
                    txtPVID.Text = dr[0].ToString();
                    this.txtPVNo.Text = dr[1].ToString();
                    this.txtVoucherNo.Text = dr[1].ToString();
                    if (txtPVID.Text != "")
                    {
                        btnMasterSave.Enabled = false;
                        btnSave.Enabled = true;
                        txtQuantity.Enabled = true;
                        //txtTotalRs.Enabled = true;
                        txtServiceName.Enabled = true;
                        Proc_Get_SDC_Services_For_PaymentVoucher();
                       
                    }
                }
            }
        }

        #endregion


        #region txtQuantity_TextChanged
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text.Trim().Length > 0)
            {
                double amount = 0;
                double q = Convert.ToDouble(this.txtQuantity.Text.ToString());
                if (q == 0)
                {

                }
                else if (q == 1)
                {
                    amount = 200;
                }
                else if (q > 1 && q < 6)
                {
                    amount = 200 + ((q - 1) * 100);
                }

                else if (q > 5)
                {
                    amount = 600 + ((q - 5) * 75);
                }

                txtTotalRs.Text = amount.ToString();

            }
            else
            {
                txtTotalRs.Clear();
            }
        }
#endregion

        #region Save data in details
        private void btnSave_Click(object sender, EventArgs e)
        {
             if (txtServiceName.SelectedIndex == 0 )
            {
                 MessageBox.Show("- سہولت کا انتخاب کریں","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                 return;
               
            }
            else if (txtQuantity.Text.Trim().Length==0)
             {
                MessageBox.Show("- صفحات کا اندراج کریں","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                 return;
            }

             else if (txtTotalRs.Text.Trim().Length == 0)
             {
                 MessageBox.Show("- رقم کا اندراج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }

             if (grdVoucherDetails.Rows.Count > 0 && txtVoucherDetailsLastID.Text == "-1")
             {
                 MessageBox.Show("ریکارڈ پہلے سے داخل ہے ", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Stop);

             }
             else
             {
                              
             if (Submit())
             {
                 txtVoucherDetailsLastID.Text = "-1";
                 txtSequenceID.Text = "-1";
                
                 txtServiceName.SelectedIndex = 0;
                 txtTotalRs.Clear();
                 txtQuantity.Clear();
                
             }

             }

           
        }
        public bool Submit()
        {

            try
            {
                if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   
                    insert_update();
                    return true;

                }
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return false;
            }
            return false;
        }

        public void insert_update()
        {

            try
            {
                if (txtPVID.Text != "")
                {
                    InsertioninVocherDetails();
                    foreach (DataRow dr in dt.Rows)
                    {
                      //  txtVoucherDetailsLastID.Text = dr["LastID"].ToString();
                    }

                   calldataGrid();
                }
                else
                {
                    //MessageBox.Show("can not inserted ,first generate voucher");
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        public void InsertioninVocherDetails()
        {
            string VocherDetailId = this.txtVoucherDetailsLastID.Text.ToString();
            string PVID = this.txtPVID.Text.ToString();
            string SeqNo = this.txtSequenceID.Text.ToString();
            string Notificationunitid = this.txtNotificationUnitID.Text.ToString();
            string costunitid = txtMasterCostunitID.Text.ToString();
            string txtquntity = txtQuantity.Text.ToString();
            string totalamount = txtTotalRs.Text.ToString();
            string PVdetails = txtPVDetatils.Text.ToString();

            if (txtVoucherDetailsLastID.Text.ToString() == "-1")
            {

                dt = objVoucher.SaveVocherDetails("-1", PVID, "-1", "NULL", "NULL", Notificationunitid, costunitid, "75.00", txtquntity, totalamount, PVdetails, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
           
            }
            else
            {
                dt = objVoucher.SaveVocherDetails(VocherDetailId, PVID, SeqNo, "NULL", "NULL", Notificationunitid, costunitid, "75.00", txtquntity, totalamount, PVdetails, UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
            }

            objtoken.errorNumeric.SetError(txtTotalRs, "");
            objtoken.errorNumeric.SetError(txtQuantity, "");
            objtoken.errorChar.SetError(txtTotalRs, "");
            objtoken.errorChar.SetError(txtQuantity, "");
        }

        private void txtServiceName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (txtServiceName.SelectedIndex == 0)
            {

            }

            else
            {

                dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_Service_Detail " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + this.txtServiceName.SelectedValue.ToString() + "'");
                foreach (DataRow dr in dt.Rows)
                {

                   
                    txtNotificationUnitID.Text = dr["TaxNotificationDetailId"].ToString();
                    txtMasterCostunitID.Text = dr["ServiceCostUnitId"].ToString();
                    txtUnit.Text = dr["SDCUnitName_Urdu"].ToString();
                    txtMasterCostunitID.Text = dr["ServiceCostUnitId"].ToString();

                }
            }
        }
        
        public void calldataGrid()
        {
           
            try
            {

                dtPayment = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtPVID.Text + "'");
              
                grdVoucherDetails.DataSource = dtPayment;
                objVoucher.VoucherGridSelf(grdVoucherDetails);
                grdVoucherDetails.Columns["ServiceCostAmount"].Width = 100;
                grdVoucherDetails.Columns["IntiqalTaxId"].Visible = false;

                if (grdVoucherDetails.Rows.Count > 0)
                {
                    objdatagird.SumDataGridColumn(grdVoucherDetails, txtTotalCostVoucher, "ServiceCostAmount");
                }

               
                grdVoucherDetails.ColumnHeadersHeight = 35;
            }
            catch (Exception ex)
            {
             
            }

        }
        private void grdVoucherDetails_DoubleClick(object sender, EventArgs e)
        {
            if (grdVoucherDetails.Rows.Count > 0)
            {
                txtVoucherDetailsLastID.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailId"].Value.ToString();
                txtSequenceID.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailSeqNo"].Value.ToString();
                txtQuantity.Text = grdVoucherDetails.CurrentRow.Cells["ServiceQuantity"].Value.ToString();

                txtTotalRs.Text = grdVoucherDetails.CurrentRow.Cells["ServiceCostAmount"].Value.ToString();
                txtServiceName.Text = grdVoucherDetails.CurrentRow.Cells["SDCServiceName_Urdu"].Value.ToString();
                txtPVDetatils.Text = grdVoucherDetails.CurrentRow.Cells["PVDetailRemarks"].Value.ToString();
                this.txtPVDetatils.SelectedText = this.txtPVDetatils.Text;
                objtoken.errorNumeric.SetError(txtQuantity, "Ok");
                objtoken.errorNumeric.SetError(txtTotalRs, "Ok");
                txtNotificationUnitID.Text = grdVoucherDetails.CurrentRow.Cells["TaxNotificationDetailId"].Value.ToString();
                txtMasterCostunitID.Text = grdVoucherDetails.CurrentRow.Cells["SDCUnitId"].Value.ToString();
                txtUnit.Text = grdVoucherDetails.CurrentRow.Cells["SDCUnitName_Urdu"].Value.ToString();
            }
        }
#endregion

        #region print 
        private void Print_Click(object sender, EventArgs e)
        {
            if (this.txtPVID.Text != "-1")
            {
                UsersManagments.check = 2;
                frmSDCReportingMain sdcReports = new frmSDCReportingMain();
                sdcReports.PVID = this.txtPVID.Text;
                sdcReports.MozaId = this.SelectedMozaId;
                sdcReports.TokenID = this.SelectedTokenId;
                sdcReports.Tehsilid = UsersManagments._Tehsilid.ToString();
                sdcReports.ShowDialog();
                
            }
        }
        #endregion  

        public void Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_ServiceTypeId()
        {
            objauto.FillCombo("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'"
                                + this.txtRPVID.Text.ToString() + "'", cmbRServices, "SDCServiceName_Urdu", "TaxNotificationDetailId");
           
           txtRAmounttoPay.Text  = "";
        }

        #region cancel fard button
        private void btnCancelFard_Click(object sender, EventArgs e)
        {
            if (grdScanedDocStatus.Rows.Count == 0)
            {
                MessageBox.Show("دستاویزات سیلیکٹ کریں", "کینسل فرد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(" کیا آپ فرد کینسل کرنا چاہتے ہیں:::::", "فرد کینسل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


                try
                {


                    string PageNos = "";

                    string ImageId = "-1";

                    using (var ms = new MemoryStream())
                    {
                        var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 0, 0, 0, 0);
                        iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                        document.Open();
                        for (int i = 0; i <= grdScanedDocStatus.Rows.Count - 1; i++)
                        {

                            PageNos = this.grdScanedDocStatus.Rows[i].Cells["PageNo"].Value.ToString();

                            string path = "";

                            if (grdScanedDocStatus.Rows[i].Cells["source"].Value != null)
                            {
                                path = grdScanedDocStatus.Rows[i].Cells["source"].Value.ToString();

                                var imgStream = GetImageStream(path);
                                var image = iTextSharp.text.Image.GetInstance(imgStream);
                                image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                                document.Add(image);

                            }


                            //ImageId = grdScanedDocStatus.Rows[i].Cells["ImageId"].Value.ToString();


                        }
                        document.Close();
                        byte[] array = ms.ToArray();

                        string picId = Iq.SaveCancelFardImages(ImageId, this.SelectedMozaId, array, PageNos, UsersManagments.UserId.ToString(), UsersManagments.UserName);



                        string CancelMessage = intiqal.FardCancel(this.SelectedTokenId, picId, UsersManagments.UserId.ToString(), UsersManagments.UserName);

                        if (CancelMessage == "فرد کینسل ہوگیا")
                        {
                        grdScanedDocStatus.Rows.Clear();
                        this.tabControl1.SelectedIndex = 0;
                        }
                        else
                        {
                            intiqal.DelCancelFardImage(picId);
                        }
                        MessageBox.Show(CancelMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion

        #region Payment Vouacher and Receipts loading
        

        public void Proc_Get_SDC_PaymentVoucherDetail_BY_VoucherId()
        {
            objauto.FillCombo("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'"
            + this.txtRPVID.Text.ToString() + "'", cmbRServices, "SDCServiceName_Urdu", "TaxNotificationDetailId");

            txtRAmounttoPay.Clear();
            cmbRPaymentofSource.SelectedIndex = 0;
            txtRAmountRecieve.Clear();
            txtRChalanFormNum.Clear();
            dtRChalanFormDate.Value = DateTime.Now;
        }

        public void call_Details_Recipt_Grd()
        {
            try
            {
                dtGrd = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_ReceiptVoucherDetail_By_RVId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtRVID.Text + "'");
               
                grdRecipt.DataSource = dtGrd;
               //======= fill grid=============

                grdRecipt.Columns["RVDetailSeqNo"].DisplayIndex = 0;
                grdRecipt.Columns["SDCServiceName_Urdu"].DisplayIndex = 1;
                grdRecipt.Columns["PaymentType_Urdu"].DisplayIndex = 2;
              
                grdRecipt.Columns["NetPayableAmount"].DisplayIndex = 3;
                grdRecipt.Columns["ReceivedAmount"].DisplayIndex = 4;

                grdRecipt.Columns["RVDetailSeqNo"].HeaderText = "نمبرشمار";
                grdRecipt.Columns["SDCServiceName_Urdu"].HeaderText = "سہولت";
                grdRecipt.Columns["PaymentType_Urdu"].HeaderText = "رقم کی ادائیگی بذریعہ";
            
                grdRecipt.Columns["NetPayableAmount"].HeaderText = "قابل ادا رقم";
                grdRecipt.Columns["ReceivedAmount"].HeaderText = "وصول کی گئی رقم";


                grdRecipt.Columns["BankAccountNo"].Visible = false;
                grdRecipt.Columns["BankName"].Visible = false;
                grdRecipt.Columns["PVDetailRemarks"].Visible = false;
                grdRecipt.Columns["BankBranchName"].Visible = false;
                grdRecipt.Columns["PaymentTypeId"].Visible = false;
                grdRecipt.Columns["RVDetailId"].Visible = false;
                grdRecipt.Columns["IntiqalTaxId"].Visible = false;
                grdRecipt.Columns["PVDetailId"].Visible = false;
              
                grdRecipt.Columns["RVId"].Visible = false;
                grdRecipt.Columns["ChallanNo"].Visible = false;
                grdRecipt.Columns["TaxNotificationDetailId"].Visible = false;
                grdRecipt.Columns["ChallanDate"].Visible = false;
             
                grdRecipt.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grdRecipt.DefaultCellStyle.ForeColor = Color.Black;


                //    =========== end====================
                if (grdRecipt.Rows.Count > 0)
                {
                    objdatagird.SumDataGridColumn(grdRecipt, txtTotPaymentRecived, "ReceivedAmount");
                    objdatagird.SumDataGridColumn(grdRecipt, this.txtNetAmountToPay, "NetPayableAmount");
                }
                else
                {
                    txtTotPaymentRecived.Clear();
                    txtNetAmountToPay.Clear();
                }
               
                DataGridViewColumn column = grdRecipt.Columns["RVDetailSeqNo"];
                column.Width = 70;
               
                for (int i = 0; i <= grdRecipt.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = grdRecipt.Rows[i];
                    row.Height = 35;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        # region Check Gain Tax

        private void btnChkGainTax_Click(object sender, EventArgs e)
        {
           if(txtReciptTokenID.Text.Length > 0)
            {
               
                    this.dtChkGainTax = Iq.CheckFardGainTax(this.SelectedTokenId);

                    if (this.dtChkGainTax.ToString() == "0")
                    {
                        MessageBox.Show("سسٹم کو گین ٹیکس کے بارے میں معلومات نہیں ملی", "گین ٹیکس", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                    else
                    {
                        MessageBox.Show(this.dtChkGainTax.ToString(), "گین ٹیکس", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);

                    }
                
               
            }
            else
            {
                MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tabControl1.SelectedIndex = 0;

            }

        }

        # endregion

        #region open pic dialogue
        private void btnPics_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;";
                    dlg.Multiselect = true;

                    dlg.Title = "تصویر کا انتخاب کریں";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        grdScanedDocStatus.Rows.Clear();
                        list.Clear();
                        string tempFolder = System.IO.Path.GetTempPath();
                        foreach (string fileName in dlg.FileNames)
                        {

                            list.Add(fileName);
                        }

                        int last = list.Count;
                        if (last != null)
                        {
                            
                        }
                        for (int i = 0; i <= last - 1; i++)
                        {
                            string filepath = list[i].ToString();
                            grdScanedDocStatus.Rows.Add();
                          
                            this.grdScanedDocStatus.Rows[i].Cells["ImageId"].Value = "-1";
                            this.grdScanedDocStatus.Rows[i].Cells["Source"].Value = list[i].ToString();
                           
                            byte[] image = System.IO.File.ReadAllBytes(filepath);
                            MemoryStream stream = new MemoryStream(image);
                            try
                            {
                                Image img = Image.FromStream(stream);

                             
                                ResizeImages.ResizeImage(img, img.Width, img.Height, false);
                                this.grdScanedDocStatus.Rows[i].Cells["PictureLoad"].Value = ResizeImages.ResizeImage(img, img.Width, img.Height, false);
                                this.grdScanedDocStatus.Rows[i].Cells["PageNo"].Value = i + 1;
                                grdScanedDocStatus.Rows[i].Height = 70;
                            }
                            catch (Exception ex)
                            {
                                this.grdScanedDocStatus.Rows[i].Cells["Image_Pic_DB"].Value = image;
                               
                                this.grdScanedDocStatus.Rows[i].Cells["PictureLoad"].Value = ResizeImages.ResizeImage(Resource1.pdf2, Resource1.pdf2.Width, Resource1.pdf2.Height, false);
                                this.grdScanedDocStatus.Rows[i].Cells["PageNo"].Value = i + 1;
                                grdScanedDocStatus.Rows[i].Height = 70;

                            }

                        }

                      
                    }


                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region dgvCancel_CellDoubleClick
        private void dgvCancel_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
            frmStayOrderDocs sod = new frmStayOrderDocs();
           // sod.txtDetails.Text = dgvLockKhata.Rows[e.RowIndex].Cells["تفصیل"].Value.ToString();
           
            sod.Text="فرد کینسل دستاویزات";
            sod.TokenId = this.SelectedTokenId.ToString();

            sod.ShowDialog();
        }

        #endregion
        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }
        #region Form Load
        private void frmFard_Load(object sender, EventArgs e)
        {

            if (SDC_Application.Classess.UsersManagments.UserName.ToUpper().Contains("ADMIN"))
            {
                btnLandTax.Visible = true;
            }
            else btnLandTax.Visible = false;
    
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);
          //  DataGridViewHelper.addHelpterToAllFormGridViews(this);

            tooltip();
            try
            {
                
                captureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (captureDevices.Count > 0)
                {
                    //cmbCamera.Items.Add("انتخاب کریں");
                    foreach (FilterInfo Device in captureDevices)
                    {
                        cmbCamera.Items.Add(Device.Name);
                    }

                    if (frmMain.cameraindex != -1)
                    {
                        cmbCamera.SelectedIndex = frmMain.cameraindex;
                        videoSource = new VideoCaptureDevice();
                        videoSource = new VideoCaptureDevice(captureDevices[frmMain.cameraindex].MonikerString);
                        videoSource.NewFrame += VideoSource_NewFrame;
                        videoSource.Start();
                        cmbCamera.Enabled = false;

                    }
                }

                else
                {
                    frmMain.cameraindex = -1;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Tabs Change events
        private void tabControl1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {

                case 2:
                    {
                        try
                        {

                            if (txtReciptTokenID.Text.Length > 0)
                            {

                                btnSaveImage.Enabled = false;

                                DataTable dt = new DataTable();
                                dt = intiqal.GetIntiqalPersonsListFardSelf(this.SelectedTokenId);
                                grfIntiqalPersonSanps.DataSource = dt;
                                grfFardPersonSanps();


                                objdatagird.gridControls(grfIntiqalPersonSanps);
                                objdatagird.colorrbackgrid(grfIntiqalPersonSanps);
                                if (grfIntiqalPersonSanps.Rows.Count > 0)
                                {
                                    grfIntiqalPersonSanps.Rows[0].Cells["Selection"].Value = 1;
                                    this.txtName.Text = grfIntiqalPersonSanps.Rows[0].Cells["CompleteName"].Value.ToString();
                                    this.txtpersonID.Text = grfIntiqalPersonSanps.Rows[0].Cells["PersonID"].Value.ToString();
                                    txtIntPersonImageid.Text = "-1";
                                }


                            }
                            else
                            {
                                MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.tabControl1.SelectedIndex = 0;
                                //this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }


                case 3:
                    {
                        try
                        {

                            if (txtReciptTokenID.Text.Length > 0)
                            {

                               

                            }
                            else
                            {
                                MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.tabControl1.SelectedIndex = 0;
                                //this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }

                case 4:
                    {
                        if (txtReciptTokenID.Text.Length > 0)
                        {

                            //string Rem = Pr.CheckFardPersonFingerPrintsSelf(SelectedTokenId);
                            //if (Rem != "1")
                            //{
                            //    MessageBox.Show(" براےَ مہربانی سائل کاانگوٹھا لگوایئں۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    this.tabControl1.SelectedIndex = 2;
                            //}
                        }
                        else
                        {
                            MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.tabControl1.SelectedIndex = 0;

                        }
                        break;
                    }

                case 5:
                    {
                        if (txtReciptTokenID.Text.Length > 0)
                        {
                            txtTotalRs.Clear();
                            txtQuantity.Clear();
                            txtVoucherDetailsLastID.Text = "-1";
                            txtTotalCostVoucher.Clear();

                            grdVoucherDetails.DataSource = null;
                            dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "'," + "P");


                            if (dtPayment.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtPayment.Rows)
                                {
                                    txtTokenNO.Text = dr["TokenNo"].ToString();
                                    dtTokenDate.Text = dr["TokenDate"].ToString();
                                    txtVisitorName.Text = dr["Visitor_Name"].ToString();
                                    txtFatherName.Text = dr["Visitor_FatherName"].ToString();
                                    txtMouza.Text = dr["MozaNameUrdu"].ToString();
                                    txtService.Text = dr["ServiceTypeName_Urdu"].ToString();
                                    TxtCNIC.Text = dr["Visitor_CNIC"].ToString();
                                    this.MozaId = dr["TokenService_For_MozaId"].ToString();
                                    txtMasterRemarks.Text = dr["PV_Remarks"].ToString();
                                    this.txtVoucherNo.Text = dr["PV_No"].ToString();
                                    dtChallan.Text = dr["PV_Date"].ToString();
                                    txtPVID.Text = dr["PVID"].ToString();
                                    txtPVNo.Text = dr["PV_No"].ToString();
                                    bool pvstatus = Convert.ToBoolean(dr["PV_Verified_Status"]);
                                    btnMasterSave.Enabled = false;
                                   
                                    txtQuantity.Enabled = true;
                                   
                                    txtServiceName.Enabled = true;
                                    Proc_Get_SDC_Services_For_PaymentVoucher();
                                    calldataGrid();

                                    if (pvstatus)
                                    {
                                       
                                        btnSave.Enabled = false;
                                        
                                        chkMasterVoucherUpdate.Checked = true;
                                        chkMasterVoucherUpdate.Enabled = false;
                                        lbPaymentTasdeeq.Text = "تصدیق شدہ";

                                    }
                                    else
                                    {
                                        btnSave.Enabled = true;
                                        chkMasterVoucherUpdate.Enabled = true;
                                       
                                        chkMasterVoucherUpdate.Checked = false;
                                        lbPaymentTasdeeq.Text = "تصدیق کریں";

                                    }

                                }
                            }

                            else
                            {
                                txtServiceName.DataSource = null;
                                txtServiceName.Items.Clear();
                                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_TokenList_For_PaymentVoucher_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "' ");

                                if (dtPayment.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtPayment.Rows)
                                    {
                                        txtTokenNO.Text = dr["TokenNo"].ToString();
                                        dtTokenDate.Text = dr["TokenDate"].ToString();
                                        txtVisitorName.Text = dr["Visitor_Name"].ToString();
                                        txtFatherName.Text = dr["Visitor_FatherName"].ToString();
                                        txtMouza.Text = dr["MozaNameUrdu"].ToString();
                                        txtService.Text = dr["ServiceTypeName_Urdu"].ToString();
                                        TxtCNIC.Text = dr["Visitor_CNIC"].ToString();
                                        this.MozaId = dr["TokenService_For_MozaId"].ToString();
                                        txtPVID.Text = "-1";
                                        txtPVNo.Text = "-1";
                                        this.txtVoucherNo.Clear();
                                        dtChallan.Value = DateTime.Now;
                                        txtMasterRemarks.Clear();
                                        btnSave.Enabled = false;
                                        txtQuantity.Enabled = false;
                                       
                                        txtServiceName.Enabled = false;
                                        btnMasterSave.Enabled = true;

                                        
                                        chkMasterVoucherUpdate.Enabled = true;
                                        chkMasterVoucherUpdate.Checked = false;
                                        lbPaymentTasdeeq.Text = "تصدیق کریں";


                                    }
                                }

                            }

                          
                        }
                        else
                        {
                            MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.tabControl1.SelectedIndex = 0;

                        }
                        break;
                    }


                    // ======== TAB Receipt ===================================================


                case 6:
                    {
                        if (txtReciptTokenID.Text.Length > 0)
                        {
                            txtRNo.Text = "-1";
                            txtRPVID.Clear();
                            txtPVDetailID.Clear();
                            txtRVID.Text="-1";

                            txtRChallanNo.Clear();
                            txtRCNIC.Clear();
                            txtReciptNo.Clear();
                            txtRFatherName.Clear();
                            txtRMouza.Clear();
                            txtRName.Clear();
                            txtRRemarks.Clear();
                            txtRService.Clear();
                            txtRTokenNo.Clear();

                            dtRChallanDate.Value = DateTime.Now;
                            dtReciptDate.Value = DateTime.Now;
                            dtRTokenDate.Value = DateTime.Now;

                            grdRecipt.DataSource = null;
                            txtTotPaymentRecived.Clear();
                            txtNetAmountToPay.Clear();

                            chkVerfiedReciptMaster.Enabled = true;
                            chkVerfiedReciptMaster.Checked = false;



                            objauto.FillCombo("Proc_Get_SDC_PaymentTypes_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbRPaymentofSource, "PaymentType_Urdu", "PaymentTypeId");
                            dtReceipt = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_ReceiptVoucherMaster_List_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "' ");


                            if (dtReceipt.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtReceipt.Rows)
                                {
                                      txtRTokenNo.Text = dr["TokenNo"].ToString();
                                      dtRTokenDate.Text = dr["TokenDate"].ToString();
                                      txtRService.Text = dr["ServiceTypeName_Urdu"].ToString();
                                      txtRName.Text = dr["Visitor_Name"].ToString();
                                      txtRFatherName.Text = dr["Visitor_FatherName"].ToString();
                                      txtRMouza.Text = dr["MozaNameUrdu"].ToString();
                                      txtRCNIC.Text = dr["Visitor_CNIC"].ToString();
                                      
                                      txtRRemarks.Text = dr["RVRemarks"].ToString();
                                      txtRChallanNo.Text = dr["PV_No"].ToString();
                                      dtRChallanDate.Text = dr["PV_Date"].ToString();
                                      txtReciptNo.Text = dr["RVNo"].ToString();
                                      txtRNo.Text = dr["RVNo"].ToString();
                                      dtReciptDate.Text = dr["RVDate"].ToString();
                                      txtRPVID.Text = dr["PVID"].ToString();
                                      txtRVID.Text = dr["RVID"].ToString();
                                      bool rvstatus = Convert.ToBoolean(dr["RV_VerifiedStatus"]);
                                      
                                      btnMasterReceiptSave.Enabled = false;
                                      btnRSaveDetails.Enabled = true;
                                      btnRClear.Enabled = true;
                                      cmbRServices.Enabled = true;


                                      if (rvstatus)
                                      {

                                          btnRSaveDetails.Enabled = false;
                                          btnRClear.Enabled = false;
                                          btnDelReceipt.Enabled = false;

                                          chkVerfiedReciptMaster.Checked = true;
                                          chkVerfiedReciptMaster.Enabled = false;
                                          lbReceiptTasdeeq.Text = "تصدیق شدہ";

                                      }
                                      else
                                      {
                                           btnRSaveDetails.Enabled = true;
                                          btnRClear.Enabled = true;
                                          btnDelReceipt.Enabled = true;

                                          chkVerfiedReciptMaster.Enabled = true;
                                          chkVerfiedReciptMaster.Checked = false;
                                          lbReceiptTasdeeq.Text = "تصدیق کریں";

                                      }

                                      Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_ServiceTypeId();
                                     call_Details_Recipt_Grd();
                                     btnRClear_Click(sender, e);

                                }
                            }

                            else
                            {
                                cmbRServices.DataSource = null;
                                cmbRServices.Items.Clear();
                                dtPayment = this.objbusines.filldatatable_from_storedProcedure("Proc_Self_Get_SDC_PaymentVoucherMaster_List_By_TokenId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.SelectedTokenId.ToString() + "'," + "R");

                                if (dtPayment.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtPayment.Rows)
                                    {
                                        txtRTokenNo.Text = dr["TokenNo"].ToString();
                                        dtRTokenDate.Text = dr["TokenDate"].ToString();
                                        txtRService.Text = dr["ServiceTypeName_Urdu"].ToString();
                                        txtRName.Text = dr["Visitor_Name"].ToString();
                                        txtRFatherName.Text = dr["Visitor_FatherName"].ToString();
                                        txtRMouza.Text = dr["MozaNameUrdu"].ToString();
                                        txtRCNIC.Text = dr["Visitor_CNIC"].ToString();

                                        txtRPVID.Text = dr["PVID"].ToString();
                                        txtRChallanNo.Text = dr["PV_No"].ToString();
                                        dtRChallanDate.Text = dr["PV_Date"].ToString();



                                        txtRNo.Text = "-1";
                                        txtRVID.Text = "-1";
                                        txtReciptNo.Clear();
                                        dtReciptDate.Value = DateTime.Now;
                                        txtRRemarks.Clear();

                                        btnMasterReceiptSave.Enabled = true;
                                        btnRSaveDetails.Enabled = false;
                                        btnRClear.Enabled = false;
                                        cmbRServices.Enabled = false;


                                        chkVerfiedReciptMaster.Enabled = true;
                                        chkVerfiedReciptMaster.Checked = false;
                                        lbReceiptTasdeeq.Text = "تصدیق کریں";

                                    }
                                }

                            }

                           
                        }
                        else
                        {
                            MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.tabControl1.SelectedIndex = 0;

                        }
                        break;
                    }



                    //=== END TAB Receipt =========================================================

                case 7:
                    {
                        try
                        {

                            if (txtReciptTokenID.Text.Length > 0)
                            {

                                // btnSaveImage.Enabled = false;

                                // string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                                //if(CancelCheck=="0")
                                //{
                                //    btnCancelFard.Enabled = false;
                                //    lbCancelStatus.Text = "فرد کینسل ہو چکا ہے";
                                //}
                                //else
                                //{
                                //    btnCancelFard.Enabled = true;
                                //    lbCancelStatus.Text = "";
                                //}

                                DataTable dtIntiqalat = new DataTable();
                                dtIntiqalat = intiqal.GetIntiqalatEnteredFardTokenId(this.SelectedTokenId);
                                dgvIntiqalatDetails.DataSource = dtIntiqalat;
                                dgvIntiqalatDetails.Columns["حصہ"].Visible = false;
                                //dgvIntiqalatDetails.Columns["نام"].Width = 130;
                                //dgvIntiqalatDetailsfill();



                                //objdatagird.gridControls(grfIntiqalPersonSanps);
                                //objdatagird.colorrbackgrid(grfIntiqalPersonSanps);
                                //if (grfIntiqalPersonSanps.Rows.Count > 0)
                                //{
                                //    grfIntiqalPersonSanps.Rows[0].Cells["Selection"].Value = 1;
                                //    this.txtName.Text = grfIntiqalPersonSanps.Rows[0].Cells["CompleteName"].Value.ToString();
                                //    this.txtpersonID.Text = grfIntiqalPersonSanps.Rows[0].Cells["PersonID"].Value.ToString();
                                //    txtIntPersonImageid.Text = "-1";
                                //}

                                DataTable dtRem = new DataTable();
                                dtRem = intiqal.GetRemainingFardTokenId(this.SelectedTokenId);
                                dgvRemaining.DataSource = dtRem;
                                dgvRemaining.Columns["حصہ"].Visible = false;
                                //dgvRemaining.Columns["نام"].Width = 130;


                                DataTable dtCancel = new DataTable();
                                dtCancel = intiqal.GetCancelFardTokenId(this.SelectedTokenId);
                                dgvCancel.DataSource = dtCancel;
                                dgvCancel.Columns["حصہ"].Visible = false;
                                dgvCancel.Columns["picId"].Visible = false;
                                //dgvCancel.Columns["نام"].Width = 130;



                            }
                            else
                            {
                                MessageBox.Show("فرد لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.tabControl1.SelectedIndex = 0;
                                //this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    }
                case 8:
                    {
                        if (GridViewFardKhatajat.DataSource != null)
                        {
                            if (GridViewFardKhatajat.SelectedRows.Count > 0)
                            {
                                FillKhassrasByKhataId(GridViewFardKhatajat.SelectedRows[0].Cells["FardKhataId"].Value.ToString());
                                fillDgKhassrajat();
                                //auto.FillCombo("Proc_Get_KhassraJatByKhataId " + UsersManagments._Tehsilid.ToString() + "," + GridViewFardKhatajat.SelectedRows[0].Cells["FardKhataId"].Value.ToString(), cbKhassras, "KhassraNo", "KhassraId");
                            }
                        }
                        break;
                    }
            }
        }

        #endregion

        private void btnMasterReceiptSave_Click(object sender, EventArgs e)
        {
            try
            {
                {
                   

                    if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_ReceiptVoucherMaster '" + this.txtRVID.Text.ToString() + "','" + this.txtRNo.Text.ToString() + "','" + UsersManagments._Tehsilid.ToString() + "','" + this.SelectedMozaId.ToString() + "','" + this.dtReciptDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString()) + "','" + this.SelectedTokenId.ToString() + "',N'" + txtMasterRemarks.Text.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "','" + UsersManagments.UserId.ToString() + "','" + UsersManagments.UserName.ToString() + "'");
                        if (dt != null)
                        {

                           
                            foreach (DataRow dr in dt.Rows)
                            {
                                this.txtReciptNo.Text = dr[1].ToString();
                                this.txtRVID.Text = dr[0].ToString();
                                this.txtRNo.Text = dr[1].ToString();

                            }
                            txtRvsequence.Text = "-1";
                            txtRVDetailid.Text = "-1";
                            btnMasterReceiptSave.Enabled = false;
                            btnRClear.Enabled = true;
                            btnRSaveDetails.Enabled = true;
                            cmbRServices.Enabled = true;
                            
                            chkVerfiedReciptMaster.Enabled = true;
                            chkVerfiedReciptMaster.Checked = false;
                           
                            Proc_Get_SDC_PaymentVoucherDetail_BY_VoucherId();

                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbRServices_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnRSaveDetails_Click(object sender, EventArgs e)
        {
            ArrayList Labels = new ArrayList();
            Labels.Add(lbl1.Text);
            Labels.Add(lbl2.Text);


            ArrayList collection = new ArrayList();
            string empty = null;
            collection.Add(this.cmbRServices.Text.ToString());
            collection.Add(this.txtRAmountRecieve.Text.ToString());


            for (int i = 0; i <= collection.Count - 1; i++)
            {
                if (Convert.ToString(collection[i]) == string.Empty || Convert.ToString(collection[i]) == "--انتخاب کریں--")
                {
                    empty += "," + Labels[i].ToString();

                }

            }
            bool isExists = false;
            if (grdRecipt.Rows.Count > 0 && txtRVDetailid.Text == "-1")
            {
                foreach (DataGridViewRow row in grdRecipt.Rows)
                {
                    if (this.cmbRServices.SelectedValue.ToString() == row.Cells["TaxNotificationDetailId"].Value.ToString())
                    {
                        isExists = true;
                        break;
                    }
                }

            }
            if (!isExists)
            {

                if (empty == null)
                {
                    WEB_SP_INSERT_SDC_ReceiptVoucherDetail();
                    objtoken.errorNumeric.SetError(txtRAmountRecieve, "");
                   
                    txtRVDetailid.Text = "-1";
                    txtRvsequence.Text = "-1";
                    cmbRServices.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(empty + "- کا اندراج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (txtRAmountRecieve.Text == "" || txtRAmountRecieve.Text == null || txtRAmountRecieve.Text == string.Empty)
                    {
                        objtoken.errorChar.SetError(txtRAmountRecieve, "Error");
                    }
                }

            }
            else
            {
                MessageBox.Show("ریکارڈ پہلے سے موجود ہے:::::", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        public void WEB_SP_INSERT_SDC_ReceiptVoucherDetail()
        {
          
            try
            {
                if (cmbRPaymentofSource.SelectedIndex == 1)
                {

                    dtRChalanFormDate.Text = dtRTokenDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                }
                if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string @RVDetailId = this.txtRVDetailid.Text.ToString();
                    string @RVId = this.txtRVID.Text.ToString();
                    string @PVDetailId = this.txtPVDetailID.Text.ToString();
                    string @RVDetailSeqNo = this.txtRvsequence.Text.ToString();
                    string @TaxNotificationDetailId = cmbRServices.SelectedValue.ToString();
                    string @NetPayableAmount = this.txtRAmounttoPay.Text.ToString();
                    string @PaymentTypeId = cmbRPaymentofSource.SelectedValue.ToString();
                    string @ReceivedAmountv = this.txtRAmountRecieve.Text.ToString();
                    string @ChallanNo = txtRChalanFormNum.Text.ToString();
                    string @ChallanDate = dtRChalanFormDate.Value.ToString(SDC_Application.frmMain.getShortDateFormateString());
                    string @BankAccountNo = txtRAccountNo.Text.ToString();
                    string @BankName = txtRBankName.Text.ToString();
                    string @BankBranchName = txtRBankBranch.Text.ToString();
                    string @InsertUserId = UsersManagments.UserId.ToString();
                    string @InsertLoginName = UsersManagments.UserName.ToString();
                    string @UpdateUserId = UsersManagments.UserId.ToString();
                    string @UpdateLoginName = UsersManagments.UserName.ToString();

                    dt = objfrmRecipt.SaveRecptDetails(@RVDetailId, @RVId, @PVDetailId, @RVDetailSeqNo, @TaxNotificationDetailId, @NetPayableAmount, @PaymentTypeId, @ReceivedAmountv, @ChallanNo, @ChallanDate, @BankAccountNo, @BankName, @BankBranchName, @InsertUserId, @InsertLoginName, @UpdateUserId, @UpdateLoginName);
                     if (dt != null)
                    {
                       
                        call_Details_Recipt_Grd();
                        objtoken.errorNumeric.SetError(txtRAmountRecieve, "");
                        objtoken.errorChar.SetError(txtRAmountRecieve, "");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

      
        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (this.txtRVID.Text.ToString() != "-1")
            {
                UsersManagments.check = 3;
                frmSDCReportingMain TokenReport = new frmSDCReportingMain();
               
                TokenReport.RVID = this.txtRVID.Text.ToString();
                TokenReport.Tehsilid = UsersManagments._Tehsilid.ToString();
                TokenReport.ShowDialog();
            }

        }

        private void btnDelReceipt_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ واقعی ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    
                            mnk.DeleteDetailedReceipt(txtRVDetailid.Text);
                            btnRClear_Click(sender, e);
                            call_Details_Recipt_Grd();
                       
                    }
                
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnPrintVoucher_Click(object sender, EventArgs e)
        {
            if (this.txtPVID.Text != "-1")
            {
                UsersManagments.check = 2;
                frmSDCReportingMain sdcReports = new frmSDCReportingMain();
                sdcReports.PVID = this.txtPVID.Text;
                sdcReports.MozaId = this.SelectedMozaId;
                sdcReports.TokenID = this.SelectedTokenId;
                sdcReports.Tehsilid = UsersManagments._Tehsilid.ToString();
                sdcReports.ShowDialog();

            }
        }

      
        private void chkMasterVoucherUpdate_Click(object sender, EventArgs e)
        {
            if (chkMasterVoucherUpdate.Checked && txtPVID.Text != "" && grdVoucherDetails.Rows.Count > 0)
            {
                try
                {
                    if (MessageBox.Show("کیا آپ تصدیق کرنا چاہتے ہیں:::::", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_PaymentVoucherMaster " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtPVID.Text + "','" + chkMasterVoucherUpdate.Checked + "','" + this.txtTotalCostVoucher.Text.ToString() + "'") != null)
                        {

                            chkMasterVoucherUpdate.Enabled = false;
                            btnSave.Enabled = false;
                            btnMasterSave.Enabled = false;

                            lbPaymentTasdeeq.Text = "تصدیق شدہ";
                        }
                    }
                    else
                    {
                        chkMasterVoucherUpdate.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("تصدیق کے لیے  ریکارڈز خالی ہیں", "تصدیق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkMasterVoucherUpdate.Checked = false;
            }
        }

        private void grdRecipt_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtRvsequence.Text = grdRecipt.CurrentRow.Cells["RVDetailSeqNo"].Value.ToString();
            this.txtRVID.Text = grdRecipt.CurrentRow.Cells["RVId"].Value.ToString();
            this.txtRVDetailid.Text = grdRecipt.CurrentRow.Cells["RVDetailId"].Value.ToString();
            this.txtPVDetailID.Text = grdRecipt.CurrentRow.Cells["PVDetailId"].Value.ToString();
            this.txtRAmounttoPay.Text = grdRecipt.CurrentRow.Cells["NetPayableAmount"].Value.ToString();
            this.txtRAmountRecieve.Text = grdRecipt.CurrentRow.Cells["ReceivedAmount"].Value.ToString();

            this.cmbRPaymentofSource.Text = grdRecipt.CurrentRow.Cells["PaymentType_Urdu"].Value.ToString();
            this.cmbRServices.Text = grdRecipt.CurrentRow.Cells["SDCServiceName_Urdu"].Value.ToString();
            this.txtRBankBranch.Text = grdRecipt.CurrentRow.Cells["BankBranchName"].Value.ToString();
            this.txtRBankName.Text = grdRecipt.CurrentRow.Cells["BankName"].Value.ToString();
            this.txtRAccountNo.Text = grdRecipt.CurrentRow.Cells["BankAccountNo"].Value.ToString();
            this.txtRChalanFormNum.Text = grdRecipt.CurrentRow.Cells["ChallanNo"].Value.ToString();
            
            //this.dtRChalanFormDate.Text = grdRecipt.CurrentRow.Cells["ChallanDate"].Value.ToString();
            DateTime challanDate = (DateTime)grdRecipt.CurrentRow.Cells["ChallanDate"].Value;
            string formattedDate = challanDate.ToString("dd MMM yyyy");
            this.dtRChalanFormDate.Text = formattedDate;



            objtoken.errorNumeric.SetError(txtRAmountRecieve, "Ok");
            if (this.txtRVDetailid.Text.Trim().Length > 5)
            {
                btnDelReceipt.Enabled = true;
            }
        }

        private void btnRClear_Click(object sender, EventArgs e)
        {
            this.txtRVDetailid.Text = "-1";
            btnDelReceipt.Enabled = false;
            cmbRPaymentofSource.SelectedIndex = 0;
            cmbRServices.SelectedIndex = 0;
            txtRAmounttoPay.Clear();
            txtRAmountRecieve.Clear();
            txtRChalanFormNum.Clear();
            dtRChalanFormDate.Value = DateTime.Now;
        }

        private void chkVerfiedReciptMaster_Click(object sender, EventArgs e)
        {
            if (txtTotPaymentRecived.Text != "" & txtNetAmountToPay.Text != "" && txtRVID.Text != "" && grdRecipt.Rows.Count > 0)
            {
                try
                {
                    if (MessageBox.Show("کیا آپ تصدیق کرنا چاہتے ہیں:::::", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_UPDATE_SDC_ReceiptVoucherMaster " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + txtRVID.Text + "','" + chkVerfiedReciptMaster.Checked + "',''");
                       
                        this.chkVerfiedReciptMaster.Enabled = false;
                        this.btnDelReceipt.Enabled = false;
                        this.btnRSaveDetails.Enabled = false;
                        this.btnRClear.Enabled = false;
                        lbReceiptTasdeeq.Text= "تصدیق شدہ";
                    }
                    else
                    {
                        chkVerfiedReciptMaster.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("تصدیق کے لیے  ریکارڈز خالی ہیں", "تصدیق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                chkVerfiedReciptMaster.Checked = false;
            }
        }

        #region Finger Print Hysoon

        private void btnFingerHysoon_Click(object sender, EventArgs e)
        {
            frmHysoon fphysoon = new frmHysoon();
            fphysoon.FPSaved = imgDataFinger;
            fphysoon.FormClosed -= new FormClosedEventHandler(fphysoon_FormClosed);
            fphysoon.FormClosed += new FormClosedEventHandler(fphysoon_FormClosed);
            fphysoon.ShowDialog();

        }
        void fphysoon_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmHysoon fphyasson = sender as frmHysoon;
            if (fphyasson.Status)
            {
                if (fphyasson.FPTempByte != null)
                {
                    imgDataFinger = fphyasson.FPTempByte;
                    //pboxFingerPrint.Image = Resource1.FingerprintImage;
                }

            }
        }

        #endregion

        private void btnLandTax_Click(object sender, EventArgs e)
        {

            if (this.txtFardPersonId.Text != null && this.txtFardPersonId.Text != "0" && this.txtFardPersonId.Text != "-1")
            {
                frmLandTax frmlandtax = new frmLandTax();
                frmlandtax.Personid = this.txtFardPersonId.Text;
                frmlandtax.ShowDialog();
                //frmSDCReportingMain LandTaxReport = new frmSDCReportingMain();
                //LandTaxReport.FardPersonId = this.txtFardPersonId.Text;
                //UsersManagments.check = 22;
                //LandTaxReport.ShowDialog();
            }
            else
            {
                MessageBox.Show("مالک کا انتخاب کریں");
            }
        }

        private void cmbRServices_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbRServices.SelectedIndex == 0)
            {

                txtRAmounttoPay.Text = "";
                txtRAccountNo.Text = "";
                txtRBankBranch.Text = "";
                txtRBankName.Text = "";
                txtRChalanFormNum.Text = "";
                txtRAmountRecieve.Text = "";
                cmbRPaymentofSource.SelectedIndex = 0;

            }
            else
            {

                dt = objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_PaymentVoucherDetail_BY_VoucerId_For_Recipt " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtRPVID.Text + "','" + this.cmbRServices.SelectedValue.ToString() + "'");
                foreach (DataRow dr in dt.Rows)
                {
                    this.txtRAmounttoPay.Text = dr["ServiceCostAmount"].ToString();
                    this.txtRAmountRecieve.Text = dr["ServiceCostAmount"].ToString();
                    this.txtPVDetailID.Text = dr["PVDetailId"].ToString();
                    this.cmbRPaymentofSource.Text = dr["PaymentType_Urdu"].ToString();
                }


            }
        }

        private void cbKhassras_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtKhatooniNo.Clear(); txtKhassraKanal.Clear(); txtKhassraMarla.Clear(); txtKhassraSarsai.Clear(); txtKhassraFeet.Clear();
            int Kanal=0; int Marla=0; float Sarsai=0; float Feet=0; string KhatooniNo="0";
            if (cbKhassras.SelectedValue.ToString() != "0")
            {
                foreach (DataRow row in dtKhassrasByKhata.Rows)
                {
                    if (row["KhassraId"].ToString() == cbKhassras.SelectedValue.ToString())
                    {
                        string[] Area=row["Khassra_Area"].ToString().Split('-');
                        Kanal = Kanal + int.Parse( Area[0]);
                        Marla=Marla+ int.Parse( Area[1]);
                        Sarsai=Sarsai+ float.Parse( Area[2]);
                        KhatooniNo=row["KhatooniNo"].ToString();
                        txtKhatooniId.Text = row["KhatooniId"].ToString();
                    }
                }
            }
            txtKhatooniNo.Text = KhatooniNo;
            txtKhassraKanal.Text = Kanal.ToString();
            txtKhassraMarla.Text = Marla.ToString();
            txtKhassraSarsai.Text = Sarsai.ToString();
            txtKhassraFeet.Text = Math.Round((Sarsai * 30.25), 0).ToString();
        }

        private void btnSaveKhassra_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridViewKhewatMalikaan.Rows.Count > 0)
                {
                    MessageBox.Show("انتخاب خسرہ سے پہلے مالکان محفوظ نہ کریں۔ محفوظ شدہ مالکان خذف کریں اور خسرہ محفوظ کرنے کے بعد مالکان محفوظ کریں۔ ", "انتخاب خسرہ و مالکان", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string khataId = GridViewFardKhatajat.SelectedRows[0].Cells["FardKhataId"].Value.ToString();
                    string retVal = mnk.SaveFardKhassras(txtKhassraRecId.Text, khataId, txtKhatooniId.Text, SelectedTokenId, "0", cbKhassras.SelectedValue.ToString(), txtKhassraKanal.Text, txtKhassraMarla.Text, txtKhassraSarsai.Text, txtKhassraFeet.Text, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                    if (retVal.Length > 5)
                    {
                        //MessageBox.Show("انتخاب کردہ خسرہ ریکارڈ محفوظ ہو گیا");
                        txtKhassraRecId.Text = "-1";
                        txtKhassraKanal.Clear();
                        txtKhassraMarla.Clear();
                        txtKhassraSarsai.Clear();
                        txtKhassraFeet.Clear();
                        cbKhassras.SelectedValue = 0;
                        fillDgKhassrajat();
                        btnNewKhassra_Click(sender, e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillDgKhassrajat()
        {
            if (GridViewFardKhatajat.DataSource != null)
            {
                if (GridViewFardKhatajat.SelectedRows.Count > 0)
                {
                    DataTable dtFardKhassras = mnk.GetFardKhassrajat(SelectedTokenId, GridViewFardKhatajat.SelectedRows[0].Cells["FardKhataId"].Value.ToString());
                    dgKhassrajat.DataSource = dtFardKhassras;
                    if (dtFardKhassras != null)
                    {
                        dgKhassrajat.Columns["KhassraNo"].HeaderText = "نمبر خسرہ";
                        dgKhassrajat.Columns["Area"].HeaderText = "رقبہ";
                        dgKhassrajat.Columns["PVKhassraRecId"].Visible = false;
                        dgKhassrajat.Columns["KhataId"].Visible = false;
                        dgKhassrajat.Columns["TokenId"].Visible = false;
                        dgKhassrajat.Columns["KhatooniId"].Visible = false;
                        dgKhassrajat.Columns["PVKhassraSeqNo"].Visible = false;
                        dgKhassrajat.Columns["PVKhassraId"].Visible = false;
                        dgKhassrajat.Columns["Kanal"].Visible = false;
                        dgKhassrajat.Columns["Marla"].Visible = false;
                        dgKhassrajat.Columns["Sarsai"].Visible = false;
                        dgKhassrajat.Columns["Feet"].Visible = false;
                    }
                }
            }
        }

        private void dgKhassrajat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            
            try
            {
                if (dgKhassrajat.DataSource != null)
                {
                    if (dgKhassrajat.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow row in g.Rows)
                        {
                            if (row.Selected)
                            {
                                row.Cells["ColSelKhassra"].Value = true;
                                cbKhassras.SelectedValue = row.Cells["PVKhassraId"].Value;
                                txtKhassraId.Text = row.Cells["PVKhassraId"].Value.ToString();
                                txtKhassraRecId.Text = row.Cells["PVKhassraRecId"].Value.ToString();
                                txtKhatooniId.Text = row.Cells["KhatooniId"].Value.ToString();
                            }
                            else
                                row.Cells["ColSelKhassra"].Value = true;
                        }
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
            cbKhassras.SelectedValue = 0;
            txtKhassraId.Text = "-1";
            txtKhassraRecId.Text = "-1";
            txtKhatooniId.Text = "-1";
            txtKhatooniNo.Text = "0";
            txtKhassraKanal.Clear();
            txtKhassraMarla.Clear();
            txtKhassraSarsai.Clear();
            txtKhassraFeet.Clear();
        }

        private void btnEnableFard_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ مطلوبہ فرد فعال کرنا چاہتے ہے؟", "فرد کی فعالی برائے تبدیلی", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                if (this.SelectedTokenId != null && this.SelectedTokenId != "0" && SelectedTokenId != "")
                {
                    mnk.SaveFarddStatus(this.SelectedTokenId, "unconfirmation", "0", UsersManagments.UserId.ToString(), UsersManagments.UserName, txtOperatorReport.Text.Trim());
                    this.GetFardConfDetails(this.SelectedTokenId);
                }
            }
        }

        private void btnDeleteKhassra_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("آپ مطلوبہ خسرہ خذف کرنا چاہتے ہے؟", "خذف کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                if (this.SelectedTokenId.Length>5 && txtKhassraRecId.Text.Length>5)
                {
                   string RetVal= mnk.DeleteFardKhassra(txtKhassraRecId.Text);
                   fillDgKhassrajat();
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLoadPicturefromFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = "Images (*.BMP;*.JPG;*.JPEG;*.GIF,*.PNG,*.TIFF,*.TIF)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG;*.TIFF;*.TIF;";
                    dlg.Multiselect = false;

                    dlg.Title = "تصویر کا انتخاب کریں";
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {

                        pboxPicture.Visible = true;
                        string path = dlg.FileName;
                        byte[] image = System.IO.File.ReadAllBytes(path);
                        DateTime createdTime = System.IO.File.GetCreationTime(path);
                        //if(createdTime.Date <DateTime.Now.Date)
                        //{
                        //    MessageBox.Show("آج کی تصویر سیلیکٹ کریں");
                        //    this.pboxPicture.Image = null;
                        //}
                        //else
                        //{
                        MemoryStream stream = new MemoryStream(image);
                        Image img = Image.FromStream(stream);
                        this.pboxPicture.Image = ResizeImages.ResizeImagePerson(img, img.Width, img.Height, false);
                        //}


                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnPictureReset_Click(object sender, EventArgs e)
        {
            this.pboxPicture.Image = null;
            // this.imgVideo.Visible = true;
            try
            {

                //cam.Stop();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
            {
                if (cmbCamera.Items.Count > 0)
                {
                    this.tabControl1.SelectedIndex = 9;
                }
                else
                {
                    MessageBox.Show("کیمرہ موجود نہیں ہے۔", "کیمرہ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("نام انتخاب کیجیئے", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbnRepSave_Click(object sender, EventArgs e)
        {
            if (txtRepCNIC.Text.Trim() == string.Empty || txtRepCNIC.Text.Trim().Length < 13)
            {
                MessageBox.Show("درست شناختی کارڈ نمبر درج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepCNIC.Focus();
                return;

            }
            else if (txtRepName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("نام درج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepName.Focus();
                return;

            }
            else if (txtRepFName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("والد کا نام درج کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepFName.Focus();
                return;

            }


            bool isExists = false;
            if (grfIntiqalPersonSanps.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in grfIntiqalPersonSanps.Rows)
                {

                    if (txtRepCNIC.Text.Replace("-", "") == row.Cells["cnic"].Value.ToString())
                    {
                        if (txtRepRecId.Text != row.Cells["FardRepRecId"].Value.ToString())
                        {
                            isExists = true;
                            MessageBox.Show("شناختی کارڈ نمبر " + row.Cells["cnic"].Value.ToString() + " کا ریکارڈ پہلے سے موجود ہے۔", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }

                    }


                }

            }
            if (isExists)
            {

                return;
            }


            //==================  End =========================================================


            string FardRepRecid = txtRepRecId.Text.ToString();
            string TokenId = this.SelectedTokenId;
            string usrId = UsersManagments.UserId.ToString();
            string UsrName = UsersManagments.UserName.ToString();
            string PersonName = txtRepName.Text.ToString();
            string FatherName = txtRepFName.Text.ToString();
            string CNIC = txtRepCNIC.Text.ToString();


            string LastId = mnk.SaveFardRepresentative(FardRepRecid, TokenId, PersonName, FatherName, CNIC, usrId, UsrName);
            txtRepRecId.Text = LastId;

            DataTable dt = new DataTable();
            dt = intiqal.GetIntiqalPersonsListFardSelf(this.SelectedTokenId);
            grfIntiqalPersonSanps.DataSource = dt;
            grfFardPersonSanps();
            objdatagird.gridControls(grfIntiqalPersonSanps);
            objdatagird.colorrbackgrid(grfIntiqalPersonSanps);
            btnRepReset_Click(sender, e);


            btnSaveImage.Enabled = false;


            pboxFingerPrint.Image = null;
            txtIntPersonImageid.Text = "-1";
            pboxPicture.Image = null;

            this.txtName.Clear();
            this.txtpersonID.Clear();

        }

        private void btnRepDel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آپ واقعی ریکارڈ خذف کرنا چاہتے ہے؟", "خذف کرنے کی تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                try
                {
                    this.dtTokenInIntiqalSeller = Iq.GetFardinIntiqalSellerStatus(this.SelectedTokenId);

                    if (this.dtTokenInIntiqalSeller != "0")
                    {
                        MessageBox.Show("یہ فرد انتقال نمبر " + dtTokenInIntiqalSeller.ToString() + " میں استعمال ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                    }
                    else
                    {
                        string CancelCheck = intiqal.FardCancelCheck(this.SelectedTokenId);
                        if (CancelCheck == "0")
                        {
                            MessageBox.Show("یہ فرد کینسل ہو چکا ہے لھٰذا تبدیل نہیں ہو سکتا");
                        }
                        else
                        {
                            mnk.DeleteFarRepresentative(txtRepRecId.Text);
                            this.txtRepRecId.Text = "-1";


                            DataTable dt = new DataTable();
                            dt = intiqal.GetIntiqalPersonsListFardSelf(this.SelectedTokenId);
                            grfIntiqalPersonSanps.DataSource = dt;
                            grfFardPersonSanps();
                            objdatagird.gridControls(grfIntiqalPersonSanps);
                            objdatagird.colorrbackgrid(grfIntiqalPersonSanps);
                            btnRepReset_Click(sender, e);


                            btnSaveImage.Enabled = false;


                            pboxFingerPrint.Image = null;
                            txtIntPersonImageid.Text = "-1";
                            pboxPicture.Image = null;

                            this.txtName.Clear();
                            this.txtpersonID.Clear();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bntCapture_Click(object sender, EventArgs e)
        {
            Image imm = (Bitmap)pictureBox1.Image.Clone();
            pboxPicture.Image = ResizeImages.ResizeImagePerson(imm, imm.Width, imm.Height, false); //imm; 
            videoSource.Stop();
            this.tabControl1.SelectedIndex = 2;
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 9)
            {
                this.tabControl1.SelectedIndex = 2;
            }
        }

        private void cmbCamera_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbCamera.Items.Count > 0)
            {
                frmMain.cameraindex = cmbCamera.SelectedIndex;
                videoSource = new VideoCaptureDevice();
                videoSource = new VideoCaptureDevice(captureDevices[frmMain.cameraindex].MonikerString);
                videoSource.NewFrame += VideoSource_NewFrame;
                videoSource.Start();
                cmbCamera.Enabled = false;
            }
        }


    }
}