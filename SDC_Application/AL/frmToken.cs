using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.BL;
using SDC_Application.DL;
using System.Collections;
using SDC_Application.LanguageManager;
//using Classess.Validations;
namespace SDC_Application.AL
{
    public partial class frmToken : Form
    {


        #region variables
        datagrid_controls objdatagrid = new datagrid_controls();
        AutoComplete objauto = new AutoComplete();
        DL.Database ojbdb = new DL.Database();
        BL.frmToken objbusines = new BL.frmToken();
        BL.Search search = new Search();

        DataTable dt = new DataTable();
        static bool btnload = false;
        SqlDataReader dr = null;
        string TokenVerified = "False";
        string TokenDuplicate = "False";
        string datetoken;
        
       
        BindingSource bs = new BindingSource();
        LanguageConverter lang = new LanguageConverter();
        bool ServiceTypeId = false;
        int check;


        #endregion
        #region Load Form
        public frmToken()
        {

            //  this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();

            // Add event handlers for the buttons
            btnAddPic.Click += new EventHandler(btnAddPic_Click);
            btnDeletePic.Click += new EventHandler(btnDeletePic_Click);
        }

        private byte[] personPic;

        private void btnAddPic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    personPic = System.IO.File.ReadAllBytes(filePath);

                    using (var originalImage = Image.FromFile(filePath))
                    {
                        var scaledImage = ScaleImage(originalImage, pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.Image = scaledImage;
                    }
                }
            }
        }


        private void btnDeletePic_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            personPic = null;
        }

        private Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
            {
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return newImage;
        }

        private void frmToken_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            TooltipToken();
            timer2.Start();

            try
            {            
                Fill_ListBoxes();
                loadTokenNo();            

            }
            catch (Exception ex) { throw; }
        }

       public void Fill_ListBoxes()
        {
                          //objauto.FillCombo("Proc_Get_ServiceTypes_All", cmbServiceId, "ServiceTypeName_Urdu", "ServiceTypeId");

                        // for users with tokenrole
            objauto.FillCombo("Proc_Self_Get_ServiceTypes_All   " + UsersManagments._Tehsilid.ToString() + "," + UsersManagments.UserId, cmbServiceId, "ServiceTypeName_Urdu", "ServiceTypeId");
      
                         // objauto.FillCombo("Proc_Get_SDC_TokenPurpose", cmbPurpose, "TokenPurpose_Urdu", "TokenPurposeId");
                          objauto.FillCombo("Proc_Get_Moza_List " + UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
       }
       public void loadTokenNo()
       {

           dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_Token_Detail_Last " + UsersManagments._Tehsilid.ToString() );
           if (dt != null)
           {
               this.labeltimetoken.Visible = true;
               label1.Visible = true;
               foreach (DataRow dr in dt.Rows)
               {

                   this.txtStatus.Text = dr["Token_CurrentStatus"].ToString();
                   this.label12.Text = dr["TokenNo"].ToString();
                   txtVisitorName.Text = dr["Visitor_Name"].ToString();
                   txtCNCI.Text = dr["Visitor_CNIC"].ToString();
                   txtVisitorContactNo.Text = dr["VisitorContactNo"].ToString();
                   txtFatherHusband.Text = dr["Visitor_FatherName"].ToString();
                   txtTempAddress.Text = dr["Visitor_TempAddress"].ToString();
                   cmbMouza.Text = dr["MozaNameUrdu"].ToString();
                   txtParAdress.Text = dr["Visitor_PermAddress"].ToString();
                   cmbServiceId.Text = dr["ServiceTypeName_Urdu"].ToString();
                   cmbPurpose.Text = dr["TokenPurpose_Urdu"].ToString();
                   txtDate.Text = dr["TokenDate"].ToString();
                   this.txttokenid.Text = dr["TokenId"].ToString();
                   this.txtToken.Text = dr["TokenNo"].ToString();
                   this.labeltimetoken.Text = dr["TokenTime"].ToString();
                   string PrintDuplicateStatus = dr["Token_DuplicatePrint"].ToString();
                   cbRelation.Text = dr["Relation"].ToString(); 
                   btnPrint.Enabled = true;

                   btnload = false;

                   label13.Visible = true;
                   chkverified.Visible = true;

                   if (txtStatus.Text == "تصدیق شدہ" || txtStatus.Text == " منظور" || txtStatus.Text == " نا منظور")
                   {

                       if (PrintDuplicateStatus == "True")
                       {
                           
                           txtStatus.Text = "True";
                           label13.Text = "تصدیق شدہ";
                       }
                       else
                       {
                           label13.Text = "تصدیق شدہ";
                           txtStatus.Text = "تصدیق شدہ";
                       }
                           this.chkverified.Checked = true;
                           this.chkverified.Enabled = false;
                           btnSave.Enabled = false;
                          
                       }
                       if (txtStatus.Text == "محفوظ شدہ")
                       {

                           btnSave.Enabled = true;
                           txtStatus.Text = "محفوظ شدہ";
                           label13.Text = "تصدیق کریں";
                       }
                       if (txtStatus.Text == "منسوخ شدہ")
                       {
                           txtStatus.Text = "منسوخ شدہ";
                           label13.Text = "منسوخ شدہ";
                           btnSave.Enabled = false;
                           btnCancel.Enabled = false;
                           this.chkverified.Checked = false;
                           this.chkverified.Checked = true;
                           this.chkverified.Enabled = false;
                          
                       }


                   
               }
           }
       }
        #endregion

        #region Validation keypree event
       private void txtCNCI_Leave(object sender, EventArgs e)
       {
           txtCNCI.Text.Trim();
           if (txtCNCI.TextLength == 15)
           {

               errorChar.SetError(txtCNCI, "");
               this.errorNumeric.SetError(txtCNCI, "set");
           }
           else
           {
               this.errorNumeric.SetError(txtCNCI, "");
               errorChar.SetError(txtCNCI, "Error");
           }
       }

       private void txtVisitorName_Leave(object sender, EventArgs e)
       {
           txtVisitorName.Text.Trim();
           if (txtVisitorName.TextLength > 0)
           {
               errorChar.SetError(txtVisitorName, "");
               this.errorNumeric.SetError(txtVisitorName, "set");
           }
           else
           {
               this.errorNumeric.SetError(txtVisitorName, "");
               errorChar.SetError(txtVisitorName, "Error");
           }
       }
       private void txtFatherHusband_Leave(object sender, EventArgs e)
       {
           txtFatherHusband.Text.Trim();
           if (txtFatherHusband.TextLength > 0)
           {
               errorChar.SetError(txtFatherHusband, "");
               this.errorNumeric.SetError(txtFatherHusband, "set");
           }
           else
           {
               this.errorNumeric.SetError(txtFatherHusband, "");
               errorChar.SetError(txtFatherHusband, "Error");
           }
       }
       private void txtTempAddress_Leave(object sender, EventArgs e)
       {
           txtTempAddress.Text.Trim();
           if (txtTempAddress.TextLength > 0)
           {
               errorChar.SetError(txtTempAddress, "");
               this.errorNumeric.SetError(txtTempAddress, "set");
           }
           else
           {
               this.errorNumeric.SetError(txtTempAddress, "");
               errorChar.SetError(txtTempAddress, "Error");
           }
           txtParAdress.Text = txtTempAddress.Text.Trim(); ;
       }

       private void txtVisitorName_KeyPress_1(object sender, KeyPressEventArgs e)
       {
           txtVisitorName.Text.Trim();
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
        private void txtFatherHusband_KeyPress(object sender, KeyPressEventArgs e)
        {
            check = 1;
            Validations.errorprovider(e, txtFatherHusband, errorChar, errorNumeric, check);
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
            else if (e.KeyChar == 13)
                e.Handled = true;

        }
        private void txtVisitorName_KeyPress(object sender, KeyPressEventArgs e)
        {

            check = 1;
            Validations.errorprovider(e, txtVisitorName, errorChar, errorNumeric, check);
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
            else if (e.KeyChar == 13)
                e.Handled = true;


        }
        private void txtCNCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            check = 2;
          // Validations.errorprovider(e, txtCNCI, errorChar, errorNumeric, check);

            if (this.txtCNCI.Text.Length == 5)
            {
                this.txtCNCI.Text = this.txtCNCI.Text + "-";
                txtCNCI.SelectionStart = 6;


            }
            if (this.txtCNCI.Text.Length == 13)
            {
                this.txtCNCI.Text = this.txtCNCI.Text + "-";
                txtCNCI.SelectionStart = 14;


            }
        }

        #endregion

        #region  Saved Token

        private void btnSave_Click(object sender, EventArgs e)
        
        {
            DateTime date =txtDate.Value;              
            string month = date.Month.ToString();
            string day = date.Day.ToString();
            string year = date.Year.ToString();
            datetoken=month+"/"+day+"/"+year;
            //MessageBox.Show(datetoken);

            
            ArrayList Labels = new ArrayList();
            Labels.Add(lbl1.Text);
            Labels.Add(lbl2.Text);
            Labels.Add(lbl3.Text);
            //Labels.Add(lbl4.Text);
            Labels.Add(lbl5.Text);
            Labels.Add(lbl6.Text);
            Labels.Add(lbl7.Text);
            
            ArrayList collection = new ArrayList();
            string empty = null;
            collection.Add(this.cmbMouza.Text.Trim().ToString());
            collection.Add(this.txtVisitorName.Text.Trim().ToString());
            collection.Add(this.txtFatherHusband.Text.Trim().ToString());
           // collection.Add(this.txtCNCI.Text.Trim().ToString());
            collection.Add(this.txtTempAddress.Text.Trim().ToString());
            collection.Add(this.cmbServiceId.Text.Trim().ToString());
            collection.Add(this.cmbPurpose.Text.Trim().ToString());
            
            for (int i = 0; i <= collection.Count-1; i++)
            {
                if (Convert.ToString(collection[i]) ==string.Empty || Convert.ToString(collection[i]) == "--انتخاب کریں--")
                {
                    empty+="-"+Labels[i].ToString();                   

                }
                
            }
            //string CNIC = .ToString();
            if (txtCNCI.Text.Length != 15)
            {
                empty += " شناختی کارڈ نمبر";
            }
            if (empty==null)//this.cmbMouza.SelectedIndex != 0 && this.txtFatherHusband.Text != string.Empty && this.txtVisitorName.Text != string.Empty && this.txtTempAddress.Text != string.Empty && cmbPurpose.SelectedIndex != 0 && cmbServiceId.SelectedIndex != 0 && txtCNCI.TextLength == 15)
                {
                    if (cbRelation.Text.Trim().Length > 0)
                    {
                        if (Submit())
                        {

                            this.labeltimetoken.Visible = true;
                            label1.Visible = true;
                            txtStatus.Text = status1.Text.ToString();
                            //  MessageBox.Show("ریکارڈ محفوظ ھوچکا ہے", "محفوظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            label13.Text = "تصدیق کریں";
                            this.btnPrint.Enabled = true;
                            this.chkverified.Enabled = true;
                            this.chkverified.Checked = false;
                            this.btnSave.Enabled = true;
                            chkverified.Visible = true;
                            btnCancel.Enabled = true;
                            label13.Visible = true;
                            chkduplicate.Enabled = true;
                            loadTokenNo();
                        }
                    }
                    else
                        MessageBox.Show("درخواست دہندہ کا دلدیت یا زوجیت (رشتہ) منتخب کریں۔", "انتخاب رشتہ",MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                else
                {
                    
                    MessageBox.Show(empty +" کا اندراج کریں ","",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }


            }

        

        public bool Submit()
        {
            try
            {
                if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TokenVerified = "False";
                    TokenDuplicate = "False";
                    WEB_SP_INSERT_SDC_Tokens(UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), TokenVerified, txttokenid, txtToken, status1, TokenDuplicate, cbRelation.Text);
                    return true;
                }
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "ٹوکن نمبر موجود ہے", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return false;
            }
            return false;
        }

        public bool SubmitWithPic()
        {
            try
            {
                if (MessageBox.Show("کیا آپ محفوظ کرنا چاہتے ہیں:::::", "محفوظ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TokenVerified = "False";
                    TokenDuplicate = "False";
                    WEB_SP_INSERT_SDC_Tokens_withPic(UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), TokenVerified, txttokenid, txtToken, status1, TokenDuplicate, cbRelation.Text, personPic);
                    return true;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message, "ٹوکن نمبر موجود ہے", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                return false;
            }
            return false;
        }


        #endregion

        #region  verified for print

        private void chkverified_CheckedChanged(object sender, EventArgs e)
        {
            if (chkverified.Enabled == true)
            {

                try
                {

                    if (MessageBox.Show("کیا آپ ٹوکن کی تصدیق کرنا چاہتے ہیں:::'" + this.txtToken.Text + "'", "تصدیق", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        == DialogResult.Yes)
                    {

                        TokenVerified = "True";
                        TokenDuplicate = "False";
                        // txtLoad.Text = "";                          
                        WEB_SP_INSERT_SDC_Tokens(UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), TokenVerified, txttokenid, txtToken, status2, TokenDuplicate, cbRelation.Text);
                      // MessageBox.Show("ریکارڈ کی تصدیق ھوچکی ھے", "تصدیق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtStatus.Text = status2.Text.ToString();
                        btnSave.Enabled = false;
                        btnPrint.Enabled = true;
                        chkverified.Checked = true;
                        chkverified.Enabled = false;
                        label13.Text = "تصدیق شدہ";
                        chkduplicate.Enabled = true;
                    }
                    else
                    {
                        chkverified.Checked = false;
                    }

                    
                }

                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "ٹوکن", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    // return false;
                }


            }
            else
            {

                //MessageBox.Show("kindly make token");
            }

        }

        public void WEB_SP_INSERT_SDC_Tokens(string username, string UserID, string tokenverified, TextBox tokenid, TextBox tokenno, TextBox status,string TokenDuplicate, string Relation)
        {



                                    dt = objbusines.filldatatable_from_storedProcedure(
                                    "WEB_SP_INSERT_SDC_Tokens '" + tokenid.Text.ToString() + "'," + UsersManagments._Tehsilid + "," + UsersManagments._LocationId + ",'"
                                    + datetoken + "','" 
                                    + tokenno.Text.ToString() + "',N'"
                                    + txtVisitorName.Text.Trim().ToString() + "',N'"
                                    + txtFatherHusband.Text.Trim().ToString() + "','"
                                    + this.txtCNCI.Text.Trim().ToString()+ "','"
                                    + this.txtVisitorContactNo.Text.Trim()+ "',N'"
                                    + this.txtTempAddress.Text.ToString() + "',N'"
                                    + this.txtParAdress.Text.ToString() + "','"
                                    + this.cmbServiceId.SelectedValue.ToString() + "','"
                                    + this.cmbMouza.SelectedValue.ToString() + "','" 
                                    + this.cmbPurpose.SelectedValue.ToString() + "','" 
                                    + TokenVerified + "','"
                                    +TokenDuplicate+"',N'" 
                                    + status.Text.ToString() +
                                    "','" + UserID + "','"
                                    + username + "','" + UserID + "','" + username + "',N'"+Relation+"'");
     



            foreach (DataRow dr in dt.Rows)
            {
                txttokenid.Text = (dr[0].ToString());
                txtToken.Text = (dr[1].ToString());
                this.label12.Text = dr[1].ToString();
            }



        }


        public void WEB_SP_INSERT_SDC_Tokens_withPic(string username, string UserID, string tokenverified, TextBox tokenid, TextBox tokenno, TextBox status, string TokenDuplicate, string Relation, byte[] personPic)
        {
           // string datetoken = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Assuming current date time for token date

            SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TokenId", SqlDbType.VarChar) { Value = tokenid.Text.ToString() },
                    new SqlParameter("@TehsilId", SqlDbType.Int) { Value = UsersManagments._Tehsilid },
                    new SqlParameter("@LocationId", SqlDbType.Int) { Value = UsersManagments._LocationId },
                    new SqlParameter("@TokenDate", SqlDbType.DateTime) { Value = datetoken },
                    new SqlParameter("@TokenNo", SqlDbType.Int) { Value = Convert.ToInt32(tokenno.Text.ToString()) },
                    new SqlParameter("@Visitor_Name", SqlDbType.NVarChar) { Value = txtVisitorName.Text.Trim().ToString() },
                    new SqlParameter("@Visitor_FatherName", SqlDbType.NVarChar) { Value = txtFatherHusband.Text.Trim().ToString() },
                    new SqlParameter("@Visitor_CNIC", SqlDbType.VarChar) { Value = this.txtCNCI.Text.Trim().ToString() },
                    new SqlParameter("@Visitor_ContactNo", SqlDbType.VarChar) { Value = this.txtVisitorContactNo.Text.Trim().ToString() },
                    new SqlParameter("@Visitor_TempAddress", SqlDbType.NVarChar) { Value = this.txtTempAddress.Text.ToString() },
                    new SqlParameter("@Visitor_PermAddress", SqlDbType.NVarChar) { Value = this.txtParAdress.Text.ToString() },
                    new SqlParameter("@ServiceTypeId", SqlDbType.VarChar) { Value = this.cmbServiceId.SelectedValue.ToString() },
                    new SqlParameter("@TokenService_For_MozaId", SqlDbType.Int) { Value = Convert.ToInt32(this.cmbMouza.SelectedValue.ToString()) },
                    new SqlParameter("@TokenPurposeId", SqlDbType.VarChar) { Value = this.cmbPurpose.SelectedValue.ToString() },
                    new SqlParameter("@Token_Verified", SqlDbType.Bit) { Value = Convert.ToBoolean(tokenverified) },
                    new SqlParameter("@Token_DuplicatePrint", SqlDbType.Bit) { Value = Convert.ToBoolean(TokenDuplicate) },
                    new SqlParameter("@Token_CurrentStatus", SqlDbType.NVarChar) { Value = status.Text.ToString() },
                    new SqlParameter("@InsertUserId", SqlDbType.Int) { Value = Convert.ToInt32(UserID) },
                    new SqlParameter("@InsertLoginName", SqlDbType.NVarChar) { Value = username },
                    new SqlParameter("@UpdateUserId", SqlDbType.Int) { Value = Convert.ToInt32(UserID) },
                    new SqlParameter("@UpdateLoginName", SqlDbType.NVarChar) { Value = username },
                    new SqlParameter("@Relation", SqlDbType.NVarChar) { Value = Relation },
                    new SqlParameter("@personPic", SqlDbType.VarBinary) { Value = personPic }
                };

            dt = objbusines.filldatatable_from_storedProcedure("WEB_SP_INSERT_SDC_Tokens_withPic", parameters);

            foreach (DataRow dr in dt.Rows)
            {
                txttokenid.Text = dr[0].ToString();
                txtToken.Text = dr[1].ToString();
                this.label12.Text = dr[1].ToString();
            }
        }



        #endregion

        #region To Take print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text == "منسوخ شدہ")
            {
                MessageBox.Show("یہ ٹوکن منسوخ ہوا ہے،نیا ٹوکن بنائیے", "منسوخ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              
            }
            else if (txtStatus.Text=="")
            {
                MessageBox.Show(" ٹوکن کا انتخاب کریں", "منسوخ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else if (txtStatus.Text == "True" && chkduplicate.Checked==true)
            {
                MessageBox.Show("نقل پرنٹ");
            }
            else
            {

                    UsersManagments.check = 1;
                   // SDCReports TokenReport = new SDCReports();
                    frmSDCReportingMain TokenReport = new frmSDCReportingMain();
                    TokenReport.FormClosed -= new FormClosedEventHandler(TokenReport_FormClosed);
                    TokenReport.FormClosed += new FormClosedEventHandler(TokenReport_FormClosed);
                    TokenReport.TokenID = this.txttokenid.Text;
                    TokenReport.ShowDialog();
                

                }
        }

        private void TokenReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSDCReportingMain Populate = sender as frmSDCReportingMain;
        }
        #endregion

        #region Cancelled verifed or Saved Token
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //when just saved the token then want to cancell the status
            if (this.chkverified.Checked==false && txtStatus.Text=="محفوظ شدہ")
            {

                TokenVerified = "False";
                TokenDuplicate = "False";
                if (MessageBox.Show("کیا آپ منسوخ کرنا چاہتے ہیں:::::", "منسوخ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    WEB_SP_INSERT_SDC_Tokens(UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), TokenVerified, txttokenid, txtToken, status3, TokenDuplicate, cbRelation.Text);
                   // MessageBox.Show("ٹوکن منسوخ ہوا", "منسوخ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    txtStatus.Text = status3.Text.ToString();
                    clearTextFields();
                    this.chkverified.Checked = true;
                    this.chkverified.Enabled = false;
                    this.chkverified.Visible = true;
                    this.label13.Text = "منسوخ شدہ";
                    this.label13.Visible = true;
                }
            }
            else
            {
                this.txttokenid.Text = "-1";
                this.txtToken.Text = "-1";
                clearTextFields();
            }

        }


        public void clearTextFields()
        {
           
            this.chkverified.Enabled = false;
            this.chkverified.Checked = false;
          
            this.btnPrint.Enabled = true;
            this.btnSave.Enabled = true;
            this.txttokenid.Text = "-1";
            this.txtToken.Text = "-1";
            txtStatus.Text = "";
            this.txtDate.Text = DateTime.Today.ToString();
            //this.cmbPurpose.SelectedIndex=0;
            this.txtParAdress.Text = "";
            this.txtTempAddress.Text = "";
            this.cmbServiceId.SelectedIndex = 0;
            this.txtVisitorName.Text = "";
            this.txtFatherHusband.Text = "";
            this.txtCNCI.Text = "";
            this.txtVisitorContactNo.Clear();
            this.label12.Text = "";
           // this.cmbPurpose.SelectedIndex = 0;
            this.cmbServiceId.SelectedIndex = 0;
            this.cmbMouza.SelectedIndex = 0;
            chkduplicate.Checked = false;
            chkduplicate.Enabled = false;
            errorNumeric.Clear();
            errorChar.Clear();
            label13.Visible = false;
            chkverified.Visible = false;
            cbRelation.Text = "";
        }
        #endregion      

        #region populate Token
        private void btnPopulate_Click(object sender, EventArgs e)
        {
            frmTokenPopulate Populate = new frmTokenPopulate();
            Populate.FormClosed -= new FormClosedEventHandler(Populate_FormClosed);
            Populate.FormClosed += new FormClosedEventHandler(Populate_FormClosed);
            Populate.ShowDialog();
        }
        public void ErrorProvider()
        {
            this.errorNumeric.SetError(txtVisitorName, "set");
            this.errorNumeric.SetError(this.txtCNCI, "set");
            this.errorNumeric.SetError(this.txtFatherHusband, "set");
            this.errorNumeric.SetError(this.txtTempAddress, "set");
            
        }
        private void Populate_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTokenPopulate Populate = sender as frmTokenPopulate;
            if (Populate.btn)
            {

                // Set pictureBox1.Image to picSelected.Image if picSelected.Image is not null
                if (Populate.picSelected.Image != null)
                {
                    var scaledImage = ScaleImage(Populate.picSelected.Image, pictureBox1.Width, pictureBox1.Height);
                        pictureBox1.Image = scaledImage;
                }
                else
                {
                    this.pictureBox1.Image = null; // Clear pictureBox1 if picSelected.Image is null
                }


                this.cmbMouza.Text = Populate.Mouza;
                this.txtToken.Text = Populate.TokenNo;
                this.txtVisitorName.Text = Populate.NameVisitor;
                this.txtFatherHusband.Text = Populate.FatherName;
                this.txtCNCI.Text = Populate.CNIC;
                this.txtVisitorContactNo.Text = Populate.VisitorContactNo;
                this.txtTempAddress.Text = Populate.TempAdd;
                this.txtParAdress.Text = Populate.PerAdd;
                this.cmbServiceId.Text = Populate.ServiceName;
                this.cmbPurpose.Text = Populate.PurposeName;
                cbRelation.Text = Populate.Relation;
                this.txtStatus.Text = Populate.TokenStatus;
                this.txtToken.Text = Populate.TokenNo;
                this.txttokenid.Text = Populate.TokenID;
                this.txtDate.Text = Populate.Tokendate;
                this.label12.Text = Populate.TokenNo;
                string PrintDuplicateStatus = Populate.DuplicatePRint;
                this.labeltimetoken.Text = Populate.tokentime;
                this.cmbPurpose.Visible = true;
                this.lbl7.Visible = true;
                ErrorProvider();
                chkduplicate.Checked = false;
                if (this.txtStatus.Text == "تصدیق شدہ" || this.txtStatus.Text == "منظور" || this.txtStatus.Text == "نا منظور")
                {                    
                    this.txtStatus.Text = "تصدیق شدہ";
                    this.chkverified.Checked = true;
                    this.chkverified.Enabled = false;
                    btnPrint.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = true;
                   
                    this.chkverified.Visible = true;
                    this.label13.Visible = true;
                    this.label13.Text = "تصدیق شدہ";
                    if (PrintDuplicateStatus == "True")
                    {
                       
                        this.txtStatus.Text = "True";
                    }
                    else
                    {
                       
                        //this.txtStatus.Text = Populate.TokenStatus;
                    }
                   
                }
                if (this.txtStatus.Text == "منسوخ شدہ")
                {
                    this.txtStatus.Text = Populate.TokenStatus;
                    chkverified.Enabled = false;
                    chkverified.Checked = false;
                    this.label13.Text = "منسوخ شدہ";
                    btnPrint.Enabled = true;
                    btnSave.Enabled = false;
                    btnCancel.Enabled = false;
                    this.chkverified.Visible = true;
                    this.chkverified.Checked = true;
                    this.label13.Visible = true;
                }
                if (this.txtStatus.Text == "محفوظ شدہ")
                {
                    this.txtStatus.Text = Populate.TokenStatus;
                    chkverified.Enabled =true;
                    chkverified.Checked = false;
                    this.label13.Text = "تصدیق کریں";
                    btnPrint.Enabled = true;
                    btnCancel.Enabled = true;
                    btnSave.Enabled = true;
                    this.chkverified.Visible = true;
                    this.label13.Visible = true;
                }
            }
            
        }
        #endregion

        #region Tooltip
        public void TooltipToken()
        {
            toolTip.SetToolTip(txtBackground,"");
            toolTip.SetToolTip(txtCNCI,"شناختی کارڈ نمبر");
            toolTip.SetToolTip(txtDate,"تاریخ");
            toolTip.SetToolTip(txtLoad,"لوڈ");
            toolTip.SetToolTip(txtParAdress,"مستقل پتہ");
            toolTip.SetToolTip(txtStatus,"حیثیت");
            toolTip.SetToolTip(txtTempAddress,"عارضی پتہ");
            toolTip.SetToolTip(txtToken,"ٹوکن");
            toolTip.SetToolTip(txttokenid,"");
            toolTip.SetToolTip(txtVisitorName,"ٹوکن ای ڈی");
            toolTip.SetToolTip(btnCancel,"منسوخ کریں");
            toolTip.SetToolTip(btnSave, "ٹوکن محفوظ کریں");
            toolTip.SetToolTip(btnLoadandUpd, "آخری ٹوکن لوڈ کریں");
            toolTip.SetToolTip(btnNewToken, "نئے ٹوکن کا اندراج کریں");
            toolTip.SetToolTip(btnPopulate,"محفوظ شدہ ٹوکن تلاش کریں");
            toolTip.SetToolTip(btnPrint,"ٹوکن کا پرنٹ نکالیں");
            toolTip.SetToolTip(btnSave,"ٹوکن محفوظ کریں");
           
        }
        #endregion

        #region duplicatePrint
        private void chkduplicate_Click(object sender, EventArgs e)
        {
            if (this.chkduplicate.Checked)
            {
                if (txtStatus.Text == "منسوخ شدہ" || txtStatus.Text == "محفوظ شدہ" || txtStatus.Text == string.Empty)
                {
                    if (txtStatus.Text == string.Empty)
                    {
                        MessageBox.Show(" تصدیق شدہ ٹوکن کی نقل  ملے گی", "تصدیق شدہ ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("منسوخ شدہ/محفوظ شدہ ٹوکن کی نقل نہیں ملے گی", "منسوخ شدہ/محفوظ شدہ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    chkduplicate.Checked = false;
                }
                else
                {
                    try
                    {

                        if (MessageBox.Show("کیا آپ ٹوکن کی نقل کرنا چاہتے ہیں:::'" + this.txtToken.Text + "'", "نقل", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            == DialogResult.Yes)
                        {

                            TokenVerified = "True";
                            TokenDuplicate = "True";
                            if (txtStatus.Text == "True")
                            {
                            }
                            else
                            {
                                WEB_SP_INSERT_SDC_Tokens(UsersManagments.UserName.ToString(), UsersManagments.UserId.ToString(), TokenVerified, txttokenid, txtToken, status2, TokenDuplicate, cbRelation.Text);
                                //MessageBox.Show("اب آپ نقل کی کاپی لے سکتے ہیں", "نقل کی کاپی", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //  MessageBox.Show("ریکاڈ کی تصدیق ھوچکی ھے", "تصدیق", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                            txtStatus.Text = "True";
                            btnSave.Enabled = false;
                            btnPrint.Enabled = true;
                            chkverified.Checked = true;                           
                            chkverified.Enabled = false;
                        }
                        else
                        {
                            this.chkduplicate.Checked = false;
                        }
                    }

                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.Message, "ٹوکن نمبر میں غلطی ہے", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                        // return false;
                    }


                }
            }
            else
            {
               
                chkduplicate.Checked = false;

            }

        }
        #endregion      

        #region LoadlastToken ClearAll  timer
        private void btnLoadandUpd_Click(object sender, EventArgs e)
        {
            btnload = true;
            loadTokenNo();

        }

        private void btnNewToken_Click(object sender, EventArgs e)
        {
            clearTextFields();
            this.labeltimetoken.Visible = false;
            label1.Visible = false;
            this.cmbPurpose.Visible = false;
            this.lbl7.Visible = false;

            // Clear the picture box
            pictureBox1.Image = null;

            // Clear the byte array
            personPic = null; // Or new byte[0] if you prefer an empty array

            // Additional reset actions if needed
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = System.DateTime.Now.ToLongTimeString();
        }
        #endregion

        private void cmbServiceId_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbServiceId.SelectedIndex > 0)
            {
                this.cmbPurpose.Visible = true;
                lbl7.Visible = true;
               
                if (cmbServiceId.Text == "فرد")
                {
                    objauto.FillCombo("Proc_Get_SDC_TokenPurpose_Fard " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbPurpose, "TokenPurpose_Urdu", "TokenPurposeId");
                }
                else if (cmbServiceId.Text.Contains("بدر"))
                {
                    objauto.FillCombo("Proc_Get_SDC_TokenPurpose_FB " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbPurpose, "TokenPurpose_Urdu", "TokenPurposeId");
                }
                else
                {
                    objauto.FillCombo("Proc_Get_SDC_TokenPurpose_Intiqal " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbPurpose, "TokenPurpose_Urdu", "TokenPurposeId");
                }
               
                        
            }
            else
            {
               
                this.cmbPurpose.Visible = false;
                lbl7.Visible = false;
            }
        }

        private void txtTempAddress_Leave_1(object sender, EventArgs e)
        {
            if (txtVisitorName.Text== "" || txtVisitorName.TextLength>0)
            {
                errorNumeric.SetError(txtVisitorName,"");
                errorChar.SetError(txtVisitorName,"");
            }
            if (this.txtFatherHusband.Text == "" || txtFatherHusband.TextLength > 0)
            {
                errorNumeric.SetError(txtFatherHusband, "");
                errorChar.SetError(txtFatherHusband, "");
            }
                     

            if (this.txtTempAddress.Text == "" || txtTempAddress.TextLength > 0)
            {
                errorNumeric.SetError(txtTempAddress, "");
                errorChar.SetError(txtTempAddress, "");
            }
            
            
        }

        private void txtCNCI_Leave_1(object sender, EventArgs e)
        {
            if (txtCNCI.TextLength < 15)
            {

                errorChar.SetError(txtCNCI, "Error");
            }
        }

        private void txtTempAddress_TextChanged(object sender, EventArgs e)
        {
            txtParAdress.Text = txtTempAddress.Text.ToString();
        }

        private void cmbMouza_KeyPress(object sender, KeyPressEventArgs e)
        {
            check = 1;
            Validations.errorprovider(e, txtVisitorName, errorChar, errorNumeric, check);
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

        private void cmbPurpose_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSave_Click(sender,e);
            }

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

        private void txtVisitorContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        //private void chkduplicate_CheckedChanged(object sender, EventArgs e)
        //{

        //}

        private bool isNumeric()
        {
            bool isnumeric = false;
            return isnumeric;
        }

        private void btnSearchByNIC_Click(object sender, EventArgs e)
        {
            dt = this.objbusines.filldatatable_from_storedProcedure("Proc_Get_SDC_Token_Detail_By_NIC " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + this.txtCNCI.Text.Trim() + "'");
      
            if (dt != null)
            {
               
                foreach (DataRow dr in dt.Rows)
                {

                    //this.txtStatus.Text = dr["Token_CurrentStatus"].ToString();
                    //this.label12.Text = dr["TokenNo"].ToString();
                    txtVisitorName.Text = dr["Visitor_Name"].ToString();
                    txtCNCI.Text = dr["Visitor_CNIC"].ToString();
                    txtVisitorContactNo.Text = dr["VisitorContactNo"].ToString();
                    txtFatherHusband.Text = dr["Visitor_FatherName"].ToString();
                    txtTempAddress.Text = dr["Visitor_TempAddress"].ToString();
                    cmbMouza.SelectedValue = dr["TokenService_For_MozaId"];
                    txtParAdress.Text = dr["Visitor_PermAddress"].ToString();
                    cmbPurpose.SelectedValue = dr["TokenPurposeId"].ToString();
                    cmbServiceId.SelectedValue = dr["ServiceTypeId"].ToString();
                    //txtDate.Text = dr["TokenDate"].ToString();
                    //this.txttokenid.Text = dr["TokenId"].ToString();
                    //this.txtToken.Text = dr["TokenNo"].ToString();
                   // this.labeltimetoken.Text = dr["TokenTime"].ToString();
                   // string PrintDuplicateStatus = dr["Token_DuplicatePrint"].ToString();
                   

                    }

                }

            DataTable dtTokens = new DataTable();
            dtTokens = search.GetTokenDetailByPersonCNIC(this.txtCNCI.Text.Trim());
            dgPersonTokenDetails.DataSource = dtTokens;
            dgPersonTokenDetails.Columns["Visitor_Name"].HeaderText="نام";
            dgPersonTokenDetails.Columns["Visitor_FatherName"].HeaderText="ولدیت/شوہر";
            dgPersonTokenDetails.Columns["TokenDate"].HeaderText="بتاریخ";
            dgPersonTokenDetails.Columns["TokenPurpose_Urdu"].HeaderText="قسم سہولت";
            dgPersonTokenDetails.Columns["MozaNameUrdu"].HeaderText="برائے موضع";
            //dgPersonTokenDetails.Columns["VoucherNo"].HeaderText = "چالان نمبر و تاریخ";
            //dgPersonTokenDetails.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
            }



      
        }
    }


    
               

