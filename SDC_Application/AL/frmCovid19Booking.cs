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
    public partial class frmCovid19Booking : Form
    {
        #region Class Variables

        AutoComplete objauto = new AutoComplete();
        LanguageConverter Lang = new LanguageConverter();
        DocReceiving DocRc = new DocReceiving();
        LanguageConverter lang = new LanguageConverter();
        datagrid_controls objdatagrid = new datagrid_controls();
        Intiqal Iq = new Intiqal();
        #endregion

        #region Default Constructor

        public frmCovid19Booking()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load Event

        private void frmDocReceiving_Load(object sender, EventArgs e)
        {
            // Load Mouza List 
          
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbRegMoza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Covid19_Proc_Get_ServiceTypes_All", cmbServiceId, "ServiceTypeName_Urdu", "ServiceTypeId");//--NOT_IMPLEMENTED_
          
           // dtToken.Value = DateTime.Now.AddDays(1);
            dtToken.Value = Convert.ToDateTime(DateTime.Now);
            this.GetBookingByDate(dtToken.Value.ToShortDateString());
            
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

        #region Key press restriction numeric only

        private void txtNumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        #endregion

     

     

        #region Get Registry Received By Date

        private void GetBookingByDate(string Date)
        {
            try
            {
                DataTable dt = DocRc.GetCovid19BookingByDate(Date);
                this.grdvBooking.DataSource = dt;

                grdvBooking.Columns["نام"].DisplayIndex = 0;
                grdvBooking.Columns["والد کا نام"].DisplayIndex = 1;
                grdvBooking.Columns["ٹوکن نمبر"].DisplayIndex = 2;
                grdvBooking.Columns["ٹوکن ٹائم"].DisplayIndex = 3;
                //grdvBooking.Columns["تاریخ ٹوکن"].DisplayIndex = 4;
                //grdvBooking.Columns["سہولت"].DisplayIndex = 4;
                grdvBooking.Columns["مقصد"].DisplayIndex = 4;
                grdvBooking.Columns["موضع"].DisplayIndex = 5;
             
                grdvBooking.Columns["شناختی کارڈ نمبر"].DisplayIndex = 6;
                grdvBooking.Columns["رابطہ نمبر"].DisplayIndex = 7;
                grdvBooking.Columns["ریمارکس"].DisplayIndex = 8;


                grdvBooking.Columns["MozaId"].Visible = false;
                grdvBooking.Columns["BookingId"].Visible = false;
                grdvBooking.Columns["ServiceTypeId"].Visible = false;
                grdvBooking.Columns["PurposeTypeId"].Visible = false;
               // grdvBooking.Columns["ٹوکن نمبر"].Visible = false;
                grdvBooking.Columns["سہولت"].Visible = false;
                grdvBooking.Columns["تاریخ ٹوکن"].Visible = false;
                grdvBooking.Columns["TokenNo"].Visible = false;
              

                objdatagrid.colorrbackgrid(grdvBooking);
                objdatagrid.gridControls(grdvBooking);
                grdvBooking.ColumnHeadersHeight = 20;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

    



      
 

      

        #region Button Save Registry
        private void btnRegSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRegMoza.SelectedIndex == 0)
                {
                    MessageBox.Show(" موضع کا انتخاب کریں۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbRegMoza.Focus();
                    return;
                }

                if (cmbServiceId.SelectedIndex == 0)
                {
                    MessageBox.Show(" سہولت کا انتخاب کریں۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbServiceId.Focus();
                    return;
                }

                if (cmbPurpose.SelectedIndex == 0)
                {
                    MessageBox.Show(" مقصد کا انتخاب کریں۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbPurpose.Focus();
                    return;
                }
                if (txtName.Text.Trim()=="")
                {
                    MessageBox.Show(" نام درج کریں۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtName.Focus();
                    return;
                }
                if (txtFatherName.Text.Trim() == "")
                {
                    MessageBox.Show(" والد نام درج کریں۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFatherName.Focus();
                    return;
                }

                if (txtContactNo.Text.Trim().Length <11)
                {
                    MessageBox.Show(" صحیح رابطہ نمبر درج کریں۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtContactNo.Focus();
                    return;
                }

                if (txtCNIC.Text.Trim().Length < 13)
                {
                    MessageBox.Show(" صحیح شناختی کارڈ نمبر درج کریں۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCNIC.Focus();
                    return;
                }

                if (TokenTime.Value.ToString("h:mm") == DateTime.Now.ToString("h:mm"))
                {
                    MessageBox.Show(" ٹوکن کا وقت درج کریں۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TokenTime.Focus();
                    return;
                }

                if (TokenTime.Value < Convert.ToDateTime("09:00:00 AM") || TokenTime.Value > Convert.ToDateTime("05:00:00 PM"))
                {
                    MessageBox.Show(" ٹوکن کادرست وقت درج کریں۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TokenTime.Focus();
                    return;
                }
                
                if (txtBookingId.Text=="-1" &&  DocRc.CheckBookingCovid19(dtToken.Value.ToShortDateString(), cmbServiceId.SelectedValue.ToString()) == "-1")
                {
                    MessageBox.Show(" مطلوبہ سروس کی بکنگ پوری ہو چکی ہے۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return;
                }
                string retVal = DocRc.SaveCovid19Booking(txtBookingId.Text, UsersManagments._Tehsilid.ToString(), cmbRegMoza.SelectedValue.ToString(),  cmbServiceId.SelectedValue.ToString(), cmbPurpose.SelectedValue.ToString(), txtName.Text, txtFatherName.Text, txtCNIC.Text, txtContactNo.Text,txtKafiyat.Text,dtToken.Value.ToShortDateString(), TokenTime.Value.ToShortTimeString(), UsersManagments.UserId.ToString(), UsersManagments.UserName);
                if (retVal != "" && retVal != "Null")
                {
                    MessageBox.Show("ٹوکن محفوظ ہو گیا۔");
                   
                    txtBookingId.Text = "-1";
                    btnRegNew_Click(sender, e);
                    this.GetBookingByDate(dtToken.Value.ToShortDateString());
                }
                   
                }
           
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

     
            private void btnRegNew_Click(object sender, EventArgs e)
            {
               
                txtFatherName.Clear();
                txtName.Clear();
                txtKafiyat.Clear();
                txtCNIC.Clear();
                txtContactNo.Clear();
                cmbRegMoza.SelectedIndex = 0;
                cmbServiceId.SelectedIndex = 0;
                cmbPurpose.DataSource = null;

                //dtToken.Value = DateTime.Now.AddDays(1);
                dtToken.Value = Convert.ToDateTime(DateTime.Now);
                TokenTime.Value = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
                cmbRegMoza.SelectedIndex = 0;
                txtBookingId.Text = "-1";
            }

         

       

        

            private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

            private void cmbPurpose_KeyPress(object sender, KeyPressEventArgs e)
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
            }

            private void cmbServiceId_KeyPress(object sender, KeyPressEventArgs e)
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
            }

            private void cmbServiceId_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmbServiceId.SelectedIndex > 0)
                {
                    this.cmbPurpose.Enabled = true;
                   

                    if (cmbServiceId.Text == "فرد")
                    {
                        objauto.FillCombo("Covid19_Proc_Get_SDC_TokenPurpose_Fard", cmbPurpose, "TokenPurpose_Urdu", "TokenPurposeId");//--NOT_IMPLEMENTED_
                    }
                    else
                    {
                        objauto.FillCombo("Proc_Get_SDC_TokenPurpose_Intiqal " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbPurpose, "TokenPurpose_Urdu", "TokenPurposeId");
                    }


                }
                else
                {
                    this.cmbPurpose.DataSource = null;
                    this.cmbPurpose.Enabled = false;
                   
                }
            }

          
            private void btnSearchBookingForUpdate_Click(object sender, EventArgs e)
            {
                this.GetBookingByDate(dtToken.Value.ToShortDateString());
            }

            private void grdvBooking_DoubleClick(object sender, EventArgs e)
            {
                try
                {
                    DataGridView g = sender as DataGridView;
                    if (g.SelectedRows.Count > 0)
                    {
                        cmbRegMoza.SelectedValue = g.SelectedRows[0].Cells["Mozaid"].Value.ToString();
                        cmbServiceId.SelectedValue = g.SelectedRows[0].Cells["ServiceTypeId"].Value.ToString();
                        cmbPurpose.SelectedValue = g.SelectedRows[0].Cells["PurposeTypeId"].Value.ToString();
                        txtName.Text = g.SelectedRows[0].Cells["نام"].Value.ToString();
                        txtFatherName.Text = g.SelectedRows[0].Cells["والد کا نام"].Value.ToString();
                        txtContactNo.Text = g.SelectedRows[0].Cells["رابطہ نمبر"].Value.ToString();
                        txtKafiyat.Text = g.SelectedRows[0].Cells["ریمارکس"].Value.ToString();
                        txtCNIC.Text = g.SelectedRows[0].Cells["شناختی کارڈ نمبر"].Value.ToString();
                        //cboDocType.SelectedValue = Convert.ToInt32(g.SelectedRows[0].Cells["DocumentTypeId"].Value.ToString());
                        dtToken.Value = DateTime.ParseExact(g.SelectedRows[0].Cells["تاریخ ٹوکن"].Value.ToString(), "dd-MM-yyyy", null);
                        TokenTime.Text = g.SelectedRows[0].Cells["ٹوکن ٹائم"].Value.ToString();

                        cmbRegMoza.SelectedValue = Convert.ToInt32(g.SelectedRows[0].Cells["MozaId"].Value.ToString());

                        txtBookingId.Text = g.SelectedRows[0].Cells["BookingId"].Value.ToString();
                        if (g.SelectedRows[0].Cells["TokenNo"].Value.ToString() != "0")
                        {
                            btnRegSave.Enabled = false;
                        }
                        else
                        {
                            btnRegSave.Enabled = true;
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            private void btnPrint_Click(object sender, EventArgs e)
            {
                if (grdvBooking.RowCount==0)
                {
                    MessageBox.Show("ریکارڈ خالی ہے۔", "بکنگ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
               
                else
                {

                    UsersManagments.check = 15;
                    frmSDCReportingMain sdcReports = new frmSDCReportingMain();
                    sdcReports.TokenDate = dtToken.Value.ToString();
                   
                    sdcReports.ShowDialog();

                }
            }

           
          
    }
}
