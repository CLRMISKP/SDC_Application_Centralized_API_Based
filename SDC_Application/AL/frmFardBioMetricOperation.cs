using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP.Gui;

namespace SDC_Application.AL
{
    public partial class frmFardBioMetricOperation : Form
    {
        #region Class Veriables
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
        #endregion

        #region Default Constructor

        public frmFardBioMetricOperation()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load Event

        private void frmFardBioMetricOperation_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);
           // DataGridViewHelper.addHelpterToAllFormGridViews(this);

            this.FillROsCombo();
            Image RetrunImgae = MStream(this.PersonFingerPrint);
            pictureBox1.Image = Resource1.FingerprintImage;
            this.AttStatus = false;
        }

        #endregion

        #region Fill Ro Combo

        private void FillROsCombo()
        {
            dt = ObjDB.filldatatable_from_storedProcedure("Proc_Get_Admin_User_for_MisalBadar " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+"," + Classess.UsersManagments._Tehsilid.ToString());
            if (dt != null)
            {
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

        #endregion

        #region Image Stream Contructor

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

        #endregion

        #region Verification Complete Event

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

        #endregion

        #region Combo RO Selection Change Event

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
                        this.PersonFingerPrint = Encoding.ASCII.GetBytes(row["FingerPrintImage"].ToString());// (byte[])row["FingerPrintImage"];

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

        #endregion

        #region Button Save Click Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.AttStatus = true;
            this.Close();
        }

        #endregion

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
                MessageBox.Show("Finger Print Matched to the Selected RO Finger Print, Click Ok to Proceed to Fard Badar Attestation Process.", "Finger Print is Valid...", MessageBoxButtons.OK); //MakeReport("The fingerprint was VERIFIED.\n" + dt.Rows[x][0].ToString());
                btnSave.Enabled = true;
            }
        }
    }
    
}
