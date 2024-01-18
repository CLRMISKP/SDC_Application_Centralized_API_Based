using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DPFP.Gui;
using DPFP.Processing;
using DPFP.Verification;
using System.IO;
using DPFP.Gui.Enrollment;
using DPFP.Capture;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
namespace SDC_Application.AL
{
    public partial class frmMisalBadarCacel : Form
    {
        byte[] DeSerializee; 
        DPFP.Template Template = new DPFP.Template();
       
        public string FPTempByte
        { get; set; }
        public bool Btn 
        { get; set; }

        public bool isE_FB { get; set; }

        Image RetrunImgae1;
        DL.Database ObjDB = new DL.Database();
        DataTable dt;
        BL.Misal Misal = new BL.Misal();
        BL.EFardeBadar fardbaderBL = new BL.EFardeBadar();

        public byte[] PersonFingerPrint { get; set; }

        public string FB_Id { get; set; }
        public bool AttStatus { get; set; }


        public frmMisalBadarCacel()
        {
            InitializeComponent();
        }

        private void frmVerificationFinger_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);


            this.FillROsCombo();
            Image RetrunImgae = MStream(this.PersonFingerPrint);
            pictureBox1.Image = Resource1.FingerprintImage;
        }

        private void FillROsCombo()
        {
            if (isE_FB)
            {
                dt = ObjDB.filldatatable_from_storedProcedure("Proc_Get_ROs " + Classess.UsersManagments._Tehsilid.ToString());
                DataRow row = dt.NewRow();
                row["UserId"] = "0";
                row["CompleteName"] = "--انتخاب کریں--";
                dt.Rows.InsertAt(row, 0);
                cboROs.DataSource = dt;
                cboROs.DisplayMember = "CompleteName";
                cboROs.ValueMember = "UserId";
                cboROs.SelectedValue = 0;
            }
            else
            {
                dt = ObjDB.filldatatable_from_storedProcedure("Proc_Get_Admin_User_for_MisalBadar " + Classess.UsersManagments._Tehsilid.ToString());
                DataRow row = dt.NewRow();
                row["UserId"] = "0";
                row["CompleteName"] = "--انتخاب کریں--";
                dt.Rows.InsertAt(row, 0);
                cboROs.DataSource = dt;
                cboROs.DisplayMember = "CompleteName";
                cboROs.ValueMember = "UserId";
                cboROs.SelectedValue = 0;
            }
        }

        public Image MStream(byte[] img)
        {
            Image image=null;
            try
            {
                MemoryStream stream = new MemoryStream(img);

                image= Image.FromStream(stream);
            }
            catch (Exception ex)
            {
                
                //throw;
            }
            return image;

        }

        private void verificationControl1_OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref EventHandlerStatus EventHandlerStatus)
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
                    MessageBox.Show("Finger Print Matched to the Selected RO Finger Print, Click Ok to Proceed to Intiqal Verification Process.", "Finger Print is Valid...", MessageBoxButtons.OK); //MakeReport("The fingerprint was VERIFIED.\n" + dt.Rows[x][0].ToString());
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

        private void cboROs_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.btnSave.Enabled = false;
            if (Convert.ToInt32(cboROs.SelectedValue!=null?cboROs.SelectedValue:0) > 0)
            {
                foreach(DataRow row in dt.Rows)
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
            //if (isE_FB)
            //{
                //Misal.UpdateFardBaderMainConfirmationAmaldaramad(this.FB_Id, "Amaldaramad", " ", Classess.UsersManagments.UserName);
                //ObjDB.ExecUpdateStoredProcedureWithNoRet("WEB_SP_Update_Verify_Intiqal_ByRO " + this.intiqalId.ToString() + "," + cboROs.SelectedValue.ToString()+","+this.PersonFingerPrint+"");
                 Misal.UpdateFardBaderMainConfirmationAmaldaramad(this.FB_Id, "Cancel", cboROs.SelectedValue.ToString(), cboROs.SelectedValue.ToString());
                //ObjDB.ExecUpdateStoredProcedureWithNoRet("WEB_SP_Update_Verify_Intiqal_ByRO " + this.intiqalId.ToString() + "," + cboROs.SelectedValue.ToString()+","+this.PersonFingerPrint+"");
                this.Close();
            //}
            //else
            //{
            //    Misal.UpdateFardBaderMainConfirmationAmaldaramad(this.FB_Id, "Amaldaramad", " ", Classess.UsersManagments.UserName);
            //    //ObjDB.ExecUpdateStoredProcedureWithNoRet("WEB_SP_Update_Verify_Intiqal_ByRO " + this.intiqalId.ToString() + "," + cboROs.SelectedValue.ToString()+","+this.PersonFingerPrint+"");
            //    this.Close();
            //}
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
                MessageBox.Show("ریونیو افسر کا انتخاب کریں- اگر ریونیو کا فنگر پرنٹ رجسٹرڈ نہیں ہوا ہو تو فنگر پرنٹ رجسٹر کریں۔");
        }
        void frmattestation_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmIntiqalAttestHysoon frmAtts = sender as frmIntiqalAttestHysoon;
            if (frmAtts.IsVerified)
            {
                MessageBox.Show("مزکورہ فرد بدر بیئو مٹرکلی تصدیق کر دیا گیا۔ اگے جا کر محفوظ بٹن کلک کریں۔", "Finger Print is Valid...", MessageBoxButtons.OK); //MakeReport("The fingerprint was VERIFIED.\n" + dt.Rows[x][0].ToString());
                btnSave.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
       
    }
   
}
