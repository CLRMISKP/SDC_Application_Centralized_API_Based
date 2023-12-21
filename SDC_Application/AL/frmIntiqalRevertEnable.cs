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
    public partial class frmIntiqalRevertEnable : Form
    {
        #region Class Variables

        public string IntiqalId { get; set; }
        public bool IntiqalPending { get; set; }
        public bool IntiqalAmalDaramad { get; set; }
        public bool Amaldaramadkhata { get; set; }
        public bool Canceled { get; set; }
        Intiqal intiqal = new Intiqal();
        DataTable dtSellersBeforeAmal = new DataTable();
        DataTable dtSellersBeforeAmalKK = new DataTable();
        DataTable dtSellersDependency = new DataTable();
        DataTable dtSellersAfterAmal = new DataTable();
        DataTable dtSellersAfterAmalKK = new DataTable();
        DataTable dtBuyersBeforeAmal = new DataTable();
        DataTable dtBuyersBeforeAmalKK = new DataTable();
        DataTable dtBuyersAfterAmal = new DataTable();
        DataTable dtBuyersAfterAmalKK = new DataTable();
        DataTable dtIntiqalKhatas = new DataTable();
        DataTable dtAllKhewatFareeqain = new DataTable();
        DataView view;
        public string IntiqalKhataId { get; set; }
        public string IntiqalKhataRecId { get; set; }
        public bool Khanakasht { get; set; }
        public bool KhanaMalkiat { get; set; }
        public bool MalkiatKasht { get; set; }
        public string IntiqalKhatoniRecid { get; set; }
        public string MozaId { get; set; }

        public bool isAttested { get; set; }
        public int Teh_Report;
        public string isGardawar { get; set; }
        public string TokenId { get; set; }

        LanguageConverter lang = new LanguageConverter();

        #endregion
        public frmIntiqalRevertEnable()
        {
            InitializeComponent();
        }

        #region Form Load Event

        private void frmIntiqalAmalDaramadByKhata_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text; DataGridViewHelper.addHelpterToAllFormGridViews(this);
            btnIntiqalAmal.Enabled = !IntiqalAmalDaramad;
            btnIntiqalEnable.Enabled = IntiqalAmalDaramad;
            btnIntiqalEnableAttested.Enabled = isAttested;
            btnIntiqalDisableAttested.Enabled = !isAttested;
            btnIntiqalEnableRevert.Enabled = IntiqalAmalDaramad;
            // Get Intiqal Khatajat and Fill Grid view
            if (this.TokenId != "0")
            {
                //gbAttestationEnableDisable.Enabled = true;
                //gbAmalEnableDisable.Enabled = false;
                //btnAmaldaramad.Enabled = false;
                //lblMutStatus.Text = "عملدرامد شدہ";
                //lblMutStatus.ForeColor = Color.Green;
            }
            else
            {
                //gbAttestationEnableDisable.Enabled = false;
                //gbAmalEnableDisable.Enabled = true;
                // btnAmaldaramad.Enabled = true;
                //lblMutStatus.Text = "زیر تجویز";
                //lblMutStatus.ForeColor = Color.Red;
                //if (this.isAttested && this.isGardawar.ToString() != "0" && this.Teh_Report > 10)
                //{
                //    btnAmaldaramad.Enabled = true;
                //}
                //else
                //{
                //    btnAmaldaramad.Enabled = false;
                //}
            }
            this.Fill_InteqalKhataGrid();
            if (this.Canceled)
            {
                lblCS.Text = "کینسل شدہ";
                btnCancel.Enabled = false;
                btnPending.Enabled = true;
            }
            else
            {
                lblCS.Text = "غیر کینسل شدہ";
                btnCancel.Enabled = true;
                btnPending.Enabled = false;
            }
            //this.Fill_Khata_DropDown();
        }

        #endregion 

        #region Custom Methods

        #region Fill Intiqal Khatajat Grid list

        public void Fill_InteqalKhataGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = intiqal.GetIntiqalKhataJaatListByIntiqalId(IntiqalId);
                dgInteqalKhattas.DataSource = dt;
                dgInteqalKhattas.Columns["IntiqalId"].Visible = false;
                dgInteqalKhattas.Columns["IntiqalKhataId"].Visible = false;
                dgInteqalKhattas.Columns["IntiqalKhataRecId"].Visible = false;
                dgInteqalKhattas.Columns["AmaldaramadStatus"].HeaderText = "موجودہ نوعیت عمل";
                dgInteqalKhattas.Columns["AmaldaramadDate"].Visible = false;
                dgInteqalKhattas.Columns["IsJuzviKhatta"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

         #region Check Intiqal Seller Dependency

         private void CheckIntiqalSellerDepedency(string intiqalKhataid, string intiqalKhataRecid, string intiqalid)
         {
             this.dtSellersDependency = intiqal.GetIntiqalSellersDependency(intiqalKhataid, intiqalKhataRecid, intiqalid);      
         }

         #endregion

         #endregion

         #region Form Controls Events

         private void dgInteqalKhattas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                
                    if (dgInteqalKhattas.SelectedRows.Count > 0)
                    {
                        if ((bool)dgInteqalKhattas.SelectedRows[0].Cells["AmaldaramadStatus"].Value)
                        {
                            btnRevertKhata.Enabled = true;
                            btnIntiqalEnableRevert.Enabled = false;
                            lblKhataRevert.Text = "انتخاب کردہ کھاتہ ریورٹ ہو سکتاہے۔";

                        }
                        else 
                        {
                            btnRevertKhata.Enabled = false;
                            lblKhataRevert.Text = "انتخاب کردہ کھاتہ عمل شدہ نہیں ہے۔";
                        }
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        row.Cells["ColSel"].Value = row.Selected;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

         private void btnAmaldaramad_Click(object sender, EventArgs e)
         {
             //if(dgBuyersBeforeAmal.RowCount==0 || dgSellersBeforeAmal.RowCount==0)
             //{
             //    MessageBox.Show(" بائع / مشتری موجود نہیں ہے:::::", "کھاتہ عمل درامد" , MessageBoxButtons.OK, MessageBoxIcon.Error);
             //    return;
             //}
             if (MessageBox.Show(" کیا آپ انتخاب کردہ کھاتے پر عملدرامد کرنا چاہتے ہیں:::::", "کھاتہ عمل درامد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 string AmalMessage = intiqal.IntiqalAmalDaramadByKhataIdSingle(this.IntiqalId, this.IntiqalKhataId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                 MessageBox.Show(AmalMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  DataGridViewCellEventArgs ea=new DataGridViewCellEventArgs(0,0);
                 //this.dgInteqalKhattas_CellClick((object)dgInteqalKhattas,ea);
                 //this.btnAmaldaramad.Enabled = false;
                 //this.lblMutStatus.Text = "عملدرامد شدہ۔" + DateTime.Now.ToShortDateString();
                 //this.lblMutStatus.ForeColor = Color.Green;
             }
         }


         private void btnIntiqalEnableAttested_Click(object sender, EventArgs e)
         {
             try
             {
                 string retVal=intiqal.IntiqalEnableDisable(this.IntiqalId, "enable", "attestation", txtComments.Text);
                 if (retVal == "1")
                 {
                     MessageBox.Show("مطلوبہ انتقال فعال ہو چکا ہے۔");
                     btnIntiqalEnableAttested.Enabled = false;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         public void LanguageCheckUrdu(object sender, KeyPressEventArgs e)
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

         private void btnIntiqalEnable_Click(object sender, EventArgs e)
         {
             try
             {
                 string retVal = intiqal.IntiqalEnableDisable(this.IntiqalId, "enable", "amal", txtCommentsAmal.Text);
                 if (retVal == "1")
                 {
                     MessageBox.Show("مطلوبہ انتقال فعال ہو چکا ہے۔");
                     btnIntiqalEnable.Enabled = false;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void btnIntiqalAmal_Click(object sender, EventArgs e)
         {
             try
             {
                 string retVal = intiqal.IntiqalEnableDisable(this.IntiqalId, "Disable", "amal", txtCommentsAmal.Text);
                 if (retVal == "1")
                 {
                     MessageBox.Show("مطلوبہ انتقال غیر فعال ہو چکا ہے۔");
                     btnIntiqalAmal.Enabled = false;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void btnIntiqalDisableAttested_Click(object sender, EventArgs e)
         {
             try
             {
                 string retVal = intiqal.IntiqalEnableDisable(this.IntiqalId, "Disable", "attestation", txtComments.Text);
                 if (retVal == "1")
                 {
                     MessageBox.Show("مطلوبہ انتقال فعال ہو چکا ہے۔");
                     btnIntiqalDisableAttested.Enabled = false;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void btnRevertKhata_Click(object sender, EventArgs e)
         {
             try
             {
                 if (DialogResult.Yes == MessageBox.Show("کیا آپ انتخاب کردہ کھاتہ کو ترمیم کیلئے فعال کرنا چاہتے ہے؟", "ترمیم انتقال کھاتہ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                  {
                       try
                           {
                                string IntiqalKhataRecId ="0";
                               IntiqalKhataRecId = dgInteqalKhattas.SelectedRows[0].Cells["IntiqalKhataRecId"].Value.ToString();
                               string dependentIntiqal = intiqal.GetIntiqalSellerBuyerDependencyByKhata(IntiqalId, IntiqalKhataRecId);
                               if (dependentIntiqal.Length > 0 && dependentIntiqal != "0")
                               {
                                   MessageBox.Show(" یہ کھاتہ ریورٹ نہیں ہو سکتا، موجودہ انتقال کے بعد انتقال نمبر "+dependentIntiqal+" کا اندراج کیا گیا ہے۔ ");
                               }
                               else
                               {
                                   string retVal = intiqal.IntiqalRevertByKhata(IntiqalId, IntiqalKhataRecId, txtCommentsRevert.Text.Trim());
                                   if (retVal == IntiqalId)
                                   {
                                       MessageBox.Show("انتخاب کردہ کھاتہ عمل ریورٹ ہو چکا ہے۔");
                                   }
                               }
                              }
                           catch (Exception ex)
                               {
                                        MessageBox.Show(ex.Message);
                              }
                            }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void btnIntiqalEnableRevert_Click(object sender, EventArgs e)
         {
             try
             {
                 if (DialogResult.Yes == MessageBox.Show("کیا آپ موجودہ انتقال  کو ترمیم کیلئے فعال اور ریورٹ کرنا چاہتے ہے؟", "انتقال ریورٹ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                 {
                     try
                     {
                         //string IntiqalKhataRecId = "0";
                         //IntiqalKhataRecId = dgInteqalKhattas.SelectedRows[0].Cells["IntiqalKhataRecId"].Value.ToString();
                         string dependentIntiqal = intiqal.CheckIntiqalDependencyBeforeRevert(IntiqalId);
                         if (dependentIntiqal.Length > 0 && dependentIntiqal != "0")
                         {
                             MessageBox.Show(" یہ انتقال ریورٹ نہیں ہو سکتا، موجودہ انتقال کے بعد انتقال نمبر " + dependentIntiqal + " کا اندراج کیا گیا ہے۔ ");
                         }
                         else
                         {
                             string retVal = intiqal.RevertIntiqal(IntiqalId, "0", txtCommentsRevert.Text.Trim());
                             if (retVal == IntiqalId)
                             {
                                 MessageBox.Show("انتخاب کردہ انتقال کا عمل ریورٹ ہو چکا ہے۔");
                             }
                         }
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.Message);
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void btnCancel_Click(object sender, EventArgs e)
         {
             intiqal.IntiqalMarkCancelNonCancel(IntiqalId, "1", UsersManagments.UserId.ToString());
             btnPending.Enabled = true;
             btnCancel.Enabled = false;
             lblCS.Text = "کینسل شدہ";
         }

         private void btnPending_Click(object sender, EventArgs e)
         {
             intiqal.IntiqalMarkCancelNonCancel(IntiqalId, "0", UsersManagments.UserId.ToString());
             btnPending.Enabled = false;
             btnCancel.Enabled = true;
             lblCS.Text = "غیر کینسل شدہ";
         }

    }
}
