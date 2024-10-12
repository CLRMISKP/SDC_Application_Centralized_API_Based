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
using SDC_Application.Classess;
using SDC_Application.LanguageManager;
using Microsoft.Reporting.WinForms;
using System.Net;
using System.Configuration;
using System.Collections;


namespace SDC_Application.AL
    {
    public partial class frmBulkROCancellation : Form
    {
        #region Calss Variables
        byte[] DeSerializee;
        DPFP.Template Template = new DPFP.Template();
        Malikan_n_Khattajat MalikanKatajat = new Malikan_n_Khattajat();
        AutoComplete objauto = new AutoComplete();
        DL.Database objdb = new DL.Database();
        datagrid_controls objdatagrid = new datagrid_controls();
        DataTable dt = new DataTable();
        DataTable dtIntiqal = new DataTable();
        BindingSource bs = new BindingSource();
        int countSelectedIntiqalat = 0;
        int countAttestedIntiqalat = 0;

        public byte[] PersonFingerPrint { get; set; }
        Intiqal Iq = new Intiqal();
        LanguageManager.LanguageConverter lang = new LanguageManager.LanguageConverter();
       


        #endregion

        #region Default Construction

        public frmBulkROCancellation()
            {

            InitializeComponent();

            }

        #endregion

       

        #region Form Load
        private void frmStayOrder_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);
            //DataGridViewHelper.addHelpterToAllFormGridViews(this);

            tooltip();
            objauto.FillCombo("Proc_Self_Get_DawraDate_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbDawraDt, "dt", "dtVal");
            this.FillROsCombo();
            Image RetrunImgae = MStream(this.PersonFingerPrint);
            pictureBox1.Image = Resource1.FingerprintImage;
            
          
        }
        #endregion


        public Image MStream(byte[] img)
        {
            Image image = null;
            try
            {
                MemoryStream stream = new MemoryStream(img);

                image = Image.FromStream(stream);
            }
            catch (Exception ex)
            {

                //throw;
            }
            return image;

        }

        #region Fill RO Combo
        private void FillROsCombo()
        {
            dt = objdb.filldatatable_from_storedProcedure("Proc_Get_ROs " + Classess.UsersManagments._Tehsilid.ToString() + "," + SDC_Application.Classess.UsersManagments.SubSdcId.ToString());
            DataRow row = dt.NewRow();
            row["UserId"] = "0";
            row["CompleteName"] = "--انتخاب کریں--";
            dt.Rows.InsertAt(row, 0);
            cboROs.DataSource = dt;
            cboROs.DisplayMember = "CompleteName";
            cboROs.ValueMember = "UserId";
            cboROs.SelectedValue = 0;
        }
        #endregion

        #region Tooltip

        public void tooltip()
        {
            //toolTip.SetToolTip(txtMoza, "تلاش بزریعہ موضع");
            //toolTip.SetToolTip(txtIntiqalNo, "تلاش بزریعہ انتقال نمبر");
            //toolTip.SetToolTip(GridViewIntiqalat, "انتقال سیلیکٹ کرین");
           
        }

        #endregion

       

        private void GridViewIntiqalat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                GridViewIntiqalat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.ColumnIndex == GridViewIntiqalat.CurrentRow.Cells["cbgrid"].ColumnIndex)
                {
                    int b = Convert.ToInt32(GridViewIntiqalat.CurrentRow.Cells["cbgrid"].Value);

                    if (b == 1)
                    {
                        GridViewIntiqalat.CurrentRow.Cells["cbgrid"].Value = 0;
                        countSelectedIntiqalat -= 1;
                    }
                    else
                    {
                        GridViewIntiqalat.CurrentRow.Cells["cbgrid"].Value = 1;
                        countSelectedIntiqalat += 1;
                    }
                }
            }
        }

      

        private void rbIntiqal_CheckedChanged(object sender, EventArgs e)
        {
            GridViewIntiqalat.DataSource = null;
            if(rbIntiqal.Checked)
            {
                cmbDawraDt.Visible = true;
                lbDawraDt.Visible = true;
               
            }
            else if(rbRegistry.Checked)
            {
                lbDawraDt.Visible = false;
                cmbDawraDt.Visible = false;

                countSelectedIntiqalat = 0;


                dtIntiqal = Iq.GetIntiqalatForAttestation("-1");


                GridViewIntiqalat.DataSource = dtIntiqal;

                GridViewIntiqalat.Columns["SNo"].DisplayIndex = 1;
                GridViewIntiqalat.Columns["IntiqalNo"].DisplayIndex = 2;
                GridViewIntiqalat.Columns["MozaNameUrdu"].DisplayIndex = 3;
                GridViewIntiqalat.Columns["IntiqalInitiationType"].DisplayIndex = 4;

                GridViewIntiqalat.Columns["SNo"].HeaderText = "سیریل نمبر";
                GridViewIntiqalat.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                GridViewIntiqalat.Columns["MozaNameUrdu"].HeaderText = "موضع";
                GridViewIntiqalat.Columns["IntiqalInitiationType"].HeaderText = "قسم";

                GridViewIntiqalat.Columns["IntiqalId"].Visible = false;
               
                GridViewIntiqalat.Columns[0].Width = 80;
                GridViewIntiqalat.Columns[1].Width = 80;
            }
            else if (rbCourtDecrees.Checked)
            {
                lbDawraDt.Visible = false;
                cmbDawraDt.Visible = false;

                countSelectedIntiqalat = 0;


                dtIntiqal = Iq.GetIntiqalatForAttestation("3");


                GridViewIntiqalat.DataSource = dtIntiqal;
                if (dtIntiqal != null)
                {
                    GridViewIntiqalat.Columns["SNo"].DisplayIndex = 1;
                    GridViewIntiqalat.Columns["IntiqalNo"].DisplayIndex = 2;
                    GridViewIntiqalat.Columns["MozaNameUrdu"].DisplayIndex = 3;
                    GridViewIntiqalat.Columns["IntiqalInitiationType"].DisplayIndex = 4;

                    GridViewIntiqalat.Columns["SNo"].HeaderText = "سیریل نمبر";
                    GridViewIntiqalat.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                    GridViewIntiqalat.Columns["MozaNameUrdu"].HeaderText = "موضع";
                    GridViewIntiqalat.Columns["IntiqalInitiationType"].HeaderText = "قسم";

                    GridViewIntiqalat.Columns["IntiqalId"].Visible = false;

                    GridViewIntiqalat.Columns[0].Width = 80;
                    GridViewIntiqalat.Columns[1].Width = 80;
                }

            }
        }

        private void cmbDawraDt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cmbDawraDt.SelectedIndex>0)
            {
                countSelectedIntiqalat = 0;


                dtIntiqal = Iq.GetIntiqalatForAttestation(cmbDawraDt.SelectedValue.ToString());


                GridViewIntiqalat.DataSource = dtIntiqal;

                GridViewIntiqalat.Columns["SNo"].DisplayIndex = 1;
                GridViewIntiqalat.Columns["IntiqalNo"].DisplayIndex = 2;
                GridViewIntiqalat.Columns["MozaNameUrdu"].DisplayIndex = 3;
                GridViewIntiqalat.Columns["IntiqalInitiationType"].DisplayIndex = 4;

                GridViewIntiqalat.Columns["SNo"].HeaderText = "سیریل نمبر";
                GridViewIntiqalat.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                GridViewIntiqalat.Columns["MozaNameUrdu"].HeaderText = "موضع";
                GridViewIntiqalat.Columns["IntiqalInitiationType"].HeaderText = "قسم";

                GridViewIntiqalat.Columns["IntiqalId"].Visible = false;

                GridViewIntiqalat.Columns[0].Width = 80;
                GridViewIntiqalat.Columns[1].Width = 80;
            }
        }

        private void rbRegistry_CheckedChanged(object sender, EventArgs e)
        {
            GridViewIntiqalat.DataSource = null;
            if (rbIntiqal.Checked)
            {
                cmbDawraDt.Visible = true;
                lbDawraDt.Visible = true;
                cmbDawraDt.SelectedIndex = 0;

            }
            else if (rbRegistry.Checked)
            {
                lbDawraDt.Visible = false;
                cmbDawraDt.Visible = false;

                countSelectedIntiqalat = 0;


                dtIntiqal = Iq.GetIntiqalatForAttestation("-1");


                GridViewIntiqalat.DataSource = dtIntiqal;

                GridViewIntiqalat.Columns["SNo"].DisplayIndex = 1;
                GridViewIntiqalat.Columns["IntiqalNo"].DisplayIndex = 2;
                GridViewIntiqalat.Columns["MozaNameUrdu"].DisplayIndex = 3;
                GridViewIntiqalat.Columns["IntiqalInitiationType"].DisplayIndex = 4;

                GridViewIntiqalat.Columns["SNo"].HeaderText = "سیریل نمبر";
                GridViewIntiqalat.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                GridViewIntiqalat.Columns["MozaNameUrdu"].HeaderText = "موضع";
                GridViewIntiqalat.Columns["IntiqalInitiationType"].HeaderText = "قسم";

                GridViewIntiqalat.Columns["IntiqalId"].Visible = false;

                GridViewIntiqalat.Columns[0].Width = 80;
                GridViewIntiqalat.Columns[1].Width = 80;

            }
            else if (rbCourtDecrees.Checked)
            {
                lbDawraDt.Visible = false;
                cmbDawraDt.Visible = false;

                countSelectedIntiqalat = 0;


                dtIntiqal = Iq.GetIntiqalatForAttestation("3");


                GridViewIntiqalat.DataSource = dtIntiqal;
                if (dtIntiqal != null)
                {
                    GridViewIntiqalat.Columns["SNo"].DisplayIndex = 1;
                    GridViewIntiqalat.Columns["IntiqalNo"].DisplayIndex = 2;
                    GridViewIntiqalat.Columns["MozaNameUrdu"].DisplayIndex = 3;
                    GridViewIntiqalat.Columns["IntiqalInitiationType"].DisplayIndex = 4;

                    GridViewIntiqalat.Columns["SNo"].HeaderText = "سیریل نمبر";
                    GridViewIntiqalat.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                    GridViewIntiqalat.Columns["MozaNameUrdu"].HeaderText = "موضع";
                    GridViewIntiqalat.Columns["IntiqalInitiationType"].HeaderText = "قسم";

                    GridViewIntiqalat.Columns["IntiqalId"].Visible = false;

                    GridViewIntiqalat.Columns[0].Width = 80;
                    GridViewIntiqalat.Columns[1].Width = 80;
                }

            }
        }

        private void cboROs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;
            if (Convert.ToInt32(cboROs.SelectedValue != null ? cboROs.SelectedValue : 0) > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (cboROs.SelectedValue.ToString() == row["UserId"].ToString())
                    {
                        this.lblRoName.Text = row["CompleteName"].ToString();
                        pictureBox1.Image = Resource1.FingerprintImage;
                        this.PersonFingerPrint = (byte[])row["FingerPrintImage"];

                    }
                }
            }
            else
            {
                this.lblRoName.Text = "";
                pictureBox1.Image = null;
                this.PersonFingerPrint = null;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          
            if (countSelectedIntiqalat < 1)
            {
                MessageBox.Show("کم از کم ایک انتقال / فرد بدر سیلیکٹ کریں", "تصدیق انتقال / فرد بدر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (countSelectedIntiqalat > 5 && rbFBs.Checked)
            {
                MessageBox.Show("ایک ساتھ پانچ فرد بدرات سے زیادہ تصدیق نہیں کر سکتے۔ زیادہ فرد بدرات کے تصدیق سے عملدرامد میں حلل پڑ سکتاہے۔", "تصدیق فرد بدر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            countAttestedIntiqalat = 0;
            
           if (this.GridViewIntiqalat.Rows.Count > 0)
            {

                for (int i = 0; i <= GridViewIntiqalat.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(GridViewIntiqalat.Rows[i].Cells["cbgrid"].Value) == 1)
                    {
                        if (rbFBs.Checked)
                        {
                            string intiqalId = GridViewIntiqalat.Rows[i].Cells["FB_Id"].Value.ToString();

                            string lastId = Iq.Fb_Attestation_Amaldaramad(intiqalId, lblRoName.Text);
                            countAttestedIntiqalat += 1;
                        }
                        else
                        {
                            string intiqalId = GridViewIntiqalat.Rows[i].Cells["intiqalId"].Value.ToString();

                            string lastId = Iq.WEB_SP_Update_Intiqal_Verification(intiqalId, cboROs.SelectedValue.ToString(), this.PersonFingerPrint);
                            countAttestedIntiqalat += 1;
                        }
                    }
                }

              
            }

            string I = "";
           
            if (countAttestedIntiqalat == 1 && !rbFBs.Checked)
            {
                I = countAttestedIntiqalat.ToString() + " انتقال";
            }
            else if (countAttestedIntiqalat > 1 && !rbFBs.Checked)
            {
                I = countAttestedIntiqalat.ToString() + " انتقالات";
            }
            else if (rbFBs.Checked)
            {
                I = countAttestedIntiqalat.ToString() + " فرد بدرات";
            }


            MessageBox.Show(I +" " + "  تصدیق ہو گئے", " تصدیق انتقال/ فردبدر", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading | MessageBoxOptions.RightAlign);

            btnSave.Enabled = false;
            countAttestedIntiqalat = 0;
            countSelectedIntiqalat = 0;
            GridViewIntiqalat.DataSource = null;
            
            if (rbIntiqal.Checked)
            {

                cmbDawraDt_SelectionChangeCommitted(sender, e);
            }
            else if(rbRegistry.Checked)
            {
                rbRegistry_CheckedChanged(sender, e);
            }
            else if (rbCourtDecrees.Checked)
            {
                rbCourtDecrees_CheckedChanged(sender, e);
            }
            else if (rbFBs.Checked)
            {
                rbFBs_CheckedChanged(sender, e);
            }
            
        }

        private void verificationControl1_OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus EventHandlerStatus)
        {
            if (this.PersonFingerPrint != null)
            {
                this.DeSerializee = this.PersonFingerPrint;
                DPFP.Template template = new DPFP.Template();
                MemoryStream msDB = new MemoryStream(DeSerializee);
                template.DeSerialize(msDB);



                DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                Verificator.Verify(FeatureSet, template, ref result);
                if (result.Verified)
                {
                   // MessageBox.Show("Finger Print Matched to the Selected RO Finger Print, Click Ok to Proceed to Intiqal Verification Process.", "Finger Print is Valid...", MessageBoxButtons.OK); //MakeReport("The fingerprint was VERIFIED.\n" + dt.Rows[x][0].ToString());
                     btnSave.Enabled = true;
                  
                   
                }
                else
                {
                    MessageBox.Show("Finger Print Not Matched to the Selected RO Finger Print", "Unable to Verify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("مطلوبہ فنگر پرنٹ سسٹم میں محفوظ نہیں ہے۔۔۔", "Unable to Verify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
            }

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.GridViewIntiqalat.Rows.Count > 0)
            {
                countSelectedIntiqalat = 0;
                for (int i = 0; i <= GridViewIntiqalat.Rows.Count - 1; i++)
                {
                    // if (Convert.ToInt32(GridViewIntiqalat.Rows[i].Cells["cbgrid"].Value) == 1)
                    if (chkAll.Checked)
                    {
                        countSelectedIntiqalat++;
                        GridViewIntiqalat.Rows[i].Cells["cbgrid"].Value = true;

                    }
                    else
                    {
                        countSelectedIntiqalat = 0;
                        GridViewIntiqalat.Rows[i].Cells["cbgrid"].Value = false;
                    }
                }


            }
           
        }

        private void txtIntiqalNo_TextChanged(object sender, EventArgs e)
        {
            if (this.GridViewIntiqalat.Rows.Count > 0)
            {

                for (int i = 0; i <= GridViewIntiqalat.Rows.Count - 1; i++)
                {
                    if (rbFBs.Checked)
                    {
                        if (GridViewIntiqalat.Rows[i].Cells["FB_DocumentNo"].Value.ToString().Contains(txtIntiqalNo.Text.Trim()))
                        {

                            GridViewIntiqalat.Rows[i].Visible = true;
                        }
                        else
                        {

                            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[GridViewIntiqalat.DataSource];
                            currencyManager1.SuspendBinding();
                            GridViewIntiqalat.Rows[i].Visible = false;
                            currencyManager1.ResumeBinding();
                            GridViewIntiqalat.Rows[i].Visible = false;


                        }
                    }
                    else
                    {
                        if (GridViewIntiqalat.Rows[i].Cells["IntiqalNo"].Value.ToString().Contains(txtIntiqalNo.Text.Trim()))
                        {

                            GridViewIntiqalat.Rows[i].Visible = true;
                        }
                        else
                        {

                            CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[GridViewIntiqalat.DataSource];
                            currencyManager1.SuspendBinding();
                            GridViewIntiqalat.Rows[i].Visible = false;
                            currencyManager1.ResumeBinding();
                            GridViewIntiqalat.Rows[i].Visible = false;


                        }
                    }
                }


            }
           
        }

        private void btnFingerHysoon_Click(object sender, EventArgs e)
        {
            if (this.PersonFingerPrint.Length > 100)
            {
                frmIntiqalAttestHysoon frmattestation = new frmIntiqalAttestHysoon();
                frmattestation.FormClosed -= new FormClosedEventHandler(frmattestation_FormClosed);
                frmattestation.FormClosed += new FormClosedEventHandler(frmattestation_FormClosed);
                frmattestation.FPSaved = this.PersonFingerPrint;
                frmattestation.ShowDialog();
            }
            else
                MessageBox.Show("ریونیو افسر کا انتخاب کریں- اگر تحصیلدار کا فنگر پرنٹ رجسٹرڈ نہیں ہوا ہو تو فنگر پرنٹ رجسٹر کریں۔");
        }
        void frmattestation_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmIntiqalAttestHysoon frmAtts = sender as frmIntiqalAttestHysoon;
            if (frmAtts.IsVerified)
            {
                MessageBox.Show("Finger Print Matched to the Selected RO Finger Print, Click Ok to Proceed to Intiqal Attestation Process.", "Finger Print is Valid...", MessageBoxButtons.OK); //MakeReport("The fingerprint was VERIFIED.\n" + dt.Rows[x][0].ToString());
                btnSave.Enabled = true;
            }
        }

        private void rbCourtDecrees_CheckedChanged(object sender, EventArgs e)
        {
            GridViewIntiqalat.DataSource = null;
            if (rbIntiqal.Checked)
            {
                cmbDawraDt.Visible = true;
                lbDawraDt.Visible = true;
                cmbDawraDt.SelectedIndex = 0;

            }
            else if (rbRegistry.Checked)
            {
                lbDawraDt.Visible = false;
                cmbDawraDt.Visible = false;

                countSelectedIntiqalat = 0;


                dtIntiqal = Iq.GetIntiqalatForAttestation("-1");


                GridViewIntiqalat.DataSource = dtIntiqal;

                GridViewIntiqalat.Columns["SNo"].DisplayIndex = 1;
                GridViewIntiqalat.Columns["IntiqalNo"].DisplayIndex = 2;
                GridViewIntiqalat.Columns["MozaNameUrdu"].DisplayIndex = 3;
                GridViewIntiqalat.Columns["IntiqalInitiationType"].DisplayIndex = 4;

                GridViewIntiqalat.Columns["SNo"].HeaderText = "سیریل نمبر";
                GridViewIntiqalat.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                GridViewIntiqalat.Columns["MozaNameUrdu"].HeaderText = "موضع";
                GridViewIntiqalat.Columns["IntiqalInitiationType"].HeaderText = "قسم";

                GridViewIntiqalat.Columns["IntiqalId"].Visible = false;

                GridViewIntiqalat.Columns[0].Width = 80;
                GridViewIntiqalat.Columns[1].Width = 80;

            }
            else if (rbCourtDecrees.Checked)
            {
                lbDawraDt.Visible = false;
                cmbDawraDt.Visible = false;

                countSelectedIntiqalat = 0;


                dtIntiqal = Iq.GetIntiqalatForAttestation("3");


                GridViewIntiqalat.DataSource = dtIntiqal;
                if (dtIntiqal != null)
                {
                    GridViewIntiqalat.Columns["SNo"].DisplayIndex = 1;
                    GridViewIntiqalat.Columns["IntiqalNo"].DisplayIndex = 2;
                    GridViewIntiqalat.Columns["MozaNameUrdu"].DisplayIndex = 3;
                    GridViewIntiqalat.Columns["IntiqalInitiationType"].DisplayIndex = 4;

                    GridViewIntiqalat.Columns["SNo"].HeaderText = "سیریل نمبر";
                    GridViewIntiqalat.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                    GridViewIntiqalat.Columns["MozaNameUrdu"].HeaderText = "موضع";
                    GridViewIntiqalat.Columns["IntiqalInitiationType"].HeaderText = "قسم";

                    GridViewIntiqalat.Columns["IntiqalId"].Visible = false;

                    GridViewIntiqalat.Columns[0].Width = 80;
                    GridViewIntiqalat.Columns[1].Width = 80;
                }

            }
            else if (rbFBs.Checked)
            {
                lbDawraDt.Visible = false;
                cmbDawraDt.Visible = false;

                countSelectedIntiqalat = 0;


                dtIntiqal = Iq.GetFardBadratForVerification();


                GridViewIntiqalat.DataSource = dtIntiqal;
                if (dtIntiqal != null)
                {
                    GridViewIntiqalat.Columns["SNo"].DisplayIndex = 1;
                    GridViewIntiqalat.Columns["FB_DocumentNo"].DisplayIndex = 2;
                    GridViewIntiqalat.Columns["MozaNameUrdu"].DisplayIndex = 3;
                    

                    GridViewIntiqalat.Columns["SNo"].HeaderText = "سیریل نمبر";
                    GridViewIntiqalat.Columns["FB_DocumentNo"].HeaderText = "فرد بدر نمبر";
                    GridViewIntiqalat.Columns["MozaNameUrdu"].HeaderText = "موضع";

                    GridViewIntiqalat.Columns["FB_Id"].Visible = false;

                    GridViewIntiqalat.Columns[0].Width = 80;
                    GridViewIntiqalat.Columns[1].Width = 80;
                }

            }
        }

        private void rbFBs_CheckedChanged(object sender, EventArgs e)
        {
             if (rbFBs.Checked)
            {
                lbDawraDt.Visible = false;
                cmbDawraDt.Visible = false;

                countSelectedIntiqalat = 0;


                dtIntiqal = Iq.GetFardBadratForVerification();


                GridViewIntiqalat.DataSource = dtIntiqal;
                if (dtIntiqal != null)
                {
                    GridViewIntiqalat.Columns["SNo"].DisplayIndex = 1;
                    GridViewIntiqalat.Columns["FB_DocumentNo"].DisplayIndex = 2;
                    GridViewIntiqalat.Columns["MozaNameUrdu"].DisplayIndex = 3;
                    

                    GridViewIntiqalat.Columns["SNo"].HeaderText = "سیریل نمبر";
                    GridViewIntiqalat.Columns["FB_DocumentNo"].HeaderText = "فرد بدر نمبر";
                    GridViewIntiqalat.Columns["MozaNameUrdu"].HeaderText = "موضع";

                    GridViewIntiqalat.Columns["FB_Id"].Visible = false;

                    GridViewIntiqalat.Columns[0].Width = 80;
                    GridViewIntiqalat.Columns[1].Width = 80;
                }

            }
        }

     

     
    }
}