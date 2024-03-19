using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDC_Application.AL
{
    public partial class frmPersonUpdateCNIC : Form
    {
        #region Class Variables
        public string PersonId { get; set; }
        public string MozaId { get; set; }
        public string retVal { get; set; }
        BL.frmToken objBusiness = new BL.frmToken();
        BL.Persons person=new BL.Persons();
        LanguageManager.LanguageConverter lang = new LanguageManager.LanguageConverter();
        #endregion
        public frmPersonUpdateCNIC()
        {
            InitializeComponent();
        }

        private void frmPersonUpdateCNIC_Load(object sender, EventArgs e)
        {
            GetPersonKhattas(this.PersonId);
        }

        private void txtCnic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            
        }

        #region Get Person Khattas

        private void GetPersonKhattas(string PersonId)
        {
            DataTable dtKhattas = new DataTable();
            //dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Get_Person_KhataJats_WithLocks " + this.MozaID + "," + PersonId);
            //self----------------------------------
            dtKhattas = objBusiness.filldatatable_from_storedProcedure("Proc_Self_Get_Person_KhataJats_WithLocks " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + this.MozaId + "," + PersonId);
            //---------------------------------------
            this.dgKhatajat.DataSource = dtKhattas; 
            if (dtKhattas.Rows.Count > 0)
            {
                dgKhatajat.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                dgKhatajat.Columns["TotalParts"].HeaderText = "کل حصے";
                dgKhatajat.Columns["Khata_Area"].HeaderText = "کل رقبہ";
                dgKhatajat.Columns["Malik_Area"].HeaderText = "مالک کا رقبہ";
                //dgKhatajat.Columns["Tran_Fard"].HeaderText = "ٹرانزیکشنل فرد";
                // dgKhatajat.Columns["Malik_Part"].HeaderText = "مالک کے حصے";
                dgKhatajat.Columns["RecordLockedCon"].HeaderText = "موجودہ حالت";
                dgKhatajat.Columns["RecordLockedDetails"].HeaderText = "لاک تفصیل";
                dgKhatajat.Columns["RecordLockingDate"].HeaderText = "تاریخ لاک";
                dgKhatajat.Columns["HissaDifference"].HeaderText = "حصص فرق";
                dgKhatajat.Columns["RegisterHaqdaranId"].Visible = false;
                dgKhatajat.Columns["RegisterHqDKhataId"].Visible = false;
                dgKhatajat.Columns["Kanal"].Visible = false;
                dgKhatajat.Columns["Marla"].Visible = false;
                dgKhatajat.Columns["sarsai"].Visible = false;
                dgKhatajat.Columns["RecordLocked"].Visible = false;
                dgKhatajat.Columns["PersonId"].Visible = false;
            }
            else
            {
                this.dgKhatajat.DataSource = null;
                this.dgKhatajat.ColumnCount = 1;
                this.dgKhatajat.Rows.Add("انتخاب کردہ مالک کا کوئی کھاتہ/ریکارڈ موجود نہیں");// this.dgKhatajat.Rows.Insert(0, "one", "two", "three", "four");
            }

        }

        #endregion

        #region Update CNIC
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!txtChkPassport.Checked)
            {
                if (txtCnic.Text.Length < 13)
                {
                    MessageBox.Show("13 ہندسوں پر مشتمل شناختی کارڈ نمبر کا اندراج کریں۔", "اندراج مالک شناختی کارڈ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    retVal = person.UpdatePersonCnic(this.MozaId, this.PersonId, txtCnic.Text, Classess.UsersManagments.UserId.ToString(), txtChkPassport.Checked.ToString(), txtPassportContry.Text);
                    if (retVal.Length > 5)
                    {
                        MessageBox.Show("شناختی کارڈ نمبر کا اندراج محفوظ ہوگیا۔", "اندراج مالک شناختی کارڈ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            else
            {
                if (txtPassportNo.Text.Trim().Length > 5 && txtChkPassport.Checked && txtPassportContry.Text.Trim().Length > 3)
                {
                    retVal = person.UpdatePersonCnic(this.MozaId, this.PersonId, txtPassportNo.Text, Classess.UsersManagments.UserId.ToString(), txtChkPassport.Checked.ToString(), txtPassportContry.Text);
                    if (retVal.Length > 5)
                    {
                        MessageBox.Show("پاسپورٹ نمبر کا اندراج محفوظ ہوگیا۔", "اندراج مالک پاسپورٹ نمبر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }                    
                }
                else
                {
                    MessageBox.Show("کم از کم 7 ہندسوں پر مشتمل پاسپورٹ نمبر اور جاری کنندہ ملک کی اندراج کریں۔", "اندراج مالک پاسپورٹ نمبر", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        private void txtPassportContry_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPassportNo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtChkPassport_CheckedChanged(object sender, EventArgs e)
        {
            if (txtChkPassport.Checked)
            {
                lblPassportCont.Visible = true;
                lblPassportNo.Visible = true;
                txtPassportContry.Visible = true;
                txtPassportNo.Visible = true;
                lblCNIC.Visible = false;
                txtCnic.Visible = false;
                btnSave.Location = new Point(212, 92);
            }
            else {
                lblPassportCont.Visible = false;
                lblPassportNo.Visible = false;
                txtPassportContry.Visible = false;
                txtPassportNo.Visible = false;
                lblCNIC.Visible = true;
                txtCnic.Visible = true;
                btnSave.Location = new Point(212, 40);//.X= 212;
            }
        }
    }
}
