using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.Classess;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmRHZKhatoonies : Form
    {
        #region Class variables

        frmSearchPerson Fs = new frmSearchPerson();
        Khatoonies Khatoon = new Khatoonies();
        LanguageConverter lang = new LanguageConverter();
        Intiqal intiq=new Intiqal();
        public string Kanal;
        public string Marla;
        public string Feet;
        public string Sarsai;
        public string Personid;
        public string PersonName;
       // public string KhewatFariqId;
        public string RegisterHqdKhataId;
        #endregion

        #region defult constructor
        
       
        public frmRHZKhatoonies()
        {
            InitializeComponent();
        }

        #endregion

        #region Form load event
        
        

        private void frmRHZKhatoonies_Load(object sender, EventArgs e)
        {
            FillcbobyMozaList();
            //FillcbobyKhatoonies();
            //FillcbobyKhatajat();
            Fill_ComboKhewatTypes();
        }

        #endregion

        #region Combobox Moza fill Method
        
       
        public void FillcbobyMozaList()
        {
            DataTable dt = new DataTable();
            dt = Khatoon.Get_Moza_List(UsersManagments._Tehsilid.ToString());
            DataRow TypeRow = dt.NewRow();
            TypeRow["MozaId"] = "0";
            TypeRow["MozaNameUrdu"] = " - انتخاب موضع - ";
            dt.Rows.InsertAt(TypeRow, 0);
            cboMoza.DataSource = dt;
            cboMoza.DisplayMember = dt.Columns["MozaNameUrdu"].ToString();
            cboMoza.ValueMember = dt.Columns["MozaId"].ToString();

        }
        #endregion

        #region Combobox Khatajat Fill Method
        
       
        public void FillcbobyKhatajat()
        {
            DataTable dt = new DataTable();
            if (cboMoza.SelectedIndex > 0)
            {
                string MozaId = cboMoza.SelectedValue.ToString();
                string RegisterId = txtRegisterId.Text;
                dt = Khatoon.Get_KhataJatbyMozaId(MozaId, RegisterId);
                DataRow TypeRow = dt.NewRow();
                TypeRow["RegisterHaqdaranId"] = "0";
                TypeRow["KhataNo"] = " - انتخاب کھاتہ - ";
                dt.Rows.InsertAt(TypeRow, 0);
                cboKhattaNo.DataSource = dt;
                cboKhattaNo.DisplayMember = dt.Columns["KhataNo"].ToString();
                cboKhattaNo.ValueMember = dt.Columns["RegisterHaqdaranId"].ToString();
            }
        #endregion

            #region Combobox KhewatTypes Fill Method
            
           
        }
             public void Fill_ComboKhewatTypes()
        {
            DataTable dt = new DataTable();
            dt = intiq.GetKhewatTypes(UsersManagments._Tehsilid.ToString());
           
            DataRow TypeRow = dt.NewRow();
            TypeRow["KhewatTypeId"] = "0";
            TypeRow["KhewatType"] = " - انتخاب مالک - ";
            dt.Rows.InsertAt(TypeRow, 0);
            cboKhewatTypes.DataSource = dt;
            cboKhewatTypes.DisplayMember = "KhewatType";
            cboKhewatTypes.ValueMember = "KhewatTypeId";
            cboKhewatTypes.SelectedValue = 0;
        }
            #endregion


             #region Combobox Fill Method
             
            
             public void FillcbobyKhatoonies()
             {
                 DataTable dt = new DataTable();
                 if (cboKhattaNo.SelectedIndex > 0)
                 {
                     string KhatId = cboKhattaNo.SelectedValue.ToString();
                     dt = Khatoon.Get_KhatoonisbyKhataId(KhatId);
                     DataRow TypeRow = dt.NewRow();
                     TypeRow["KhatooniId"] = "0";
                     TypeRow["KhatooniNo"] = " - انتخاب کھتونی - ";
                     dt.Rows.InsertAt(TypeRow, 0);
                     cboKhatoooni.DataSource = dt;
                     cboKhatoooni.DisplayMember = dt.Columns["KhatooniNo"].ToString();
                     cboKhatoooni.ValueMember = dt.Columns["KhatooniId"].ToString();
                 }
             }
             #endregion


             #region Combobox Bayan Fill Method
             
            
             public void FillcbobyBayans()
        {
            DataTable dt = new DataTable();
            if (cboKhatoooni.SelectedIndex>0)
            {
                string KhatooniId = cboKhatoooni.SelectedValue.ToString();
                dt = Khatoon.Get_KhewatFareeqeinGroup_By_KhatooniId(KhatooniId);
                DataRow TypeRow = dt.NewRow();
                TypeRow["PersonId"] = "0";
                TypeRow["CompleteName"] = " - انتخاب مالک - ";
                dt.Rows.InsertAt(TypeRow, 0);
               cboBayan.DataSource=dt;
               cboBayan.DisplayMember = dt.Columns["CompleteName"].ToString();
               cboBayan.ValueMember = dt.Columns["PersonId"].ToString();
            }

        }
             #endregion


             #region Grid Bayan Fill Method
             
            

             public void FillgridBayan()
              {
                  DataTable dt = new DataTable();
                  if (cboKhatoooni.SelectedIndex > 0)
                  {
                      string KhatooniId = cboKhatoooni.SelectedValue.ToString();
                      dt = Khatoon.Get_KhewatFareeqeinGroup_By_KhatooniId(KhatooniId);
                      gridBayan.DataSource = dt;
                if (dt != null)
                {
                    gridBayan.Columns["CompleteName"].HeaderText = "بائعان";
                    gridBayan.Columns["KhewatFareeq_Total_Hissa"].Visible = false;
                    gridBayan.Columns["KhewatFareeq_Total_Kanal"].Visible = false;
                    gridBayan.Columns["KhewatFareeq_Total_Marla"].Visible = false;
                    gridBayan.Columns["KhewatFareeq_Total_Sarsai"].Visible = false;
                    gridBayan.Columns["KhewatFareeq_Total_Feet"].HeaderText = "کل مربع فٹ";
                    gridBayan.Columns["KhewatFareeq_Sold_Hissa"].HeaderText = "حصہ منتقلہ";
                    gridBayan.Columns["KhewatFareeq_Sold_Kanal"].HeaderText = "کنال منتقلہ";
                    gridBayan.Columns["KhewatFareeq_Sold_Marla"].HeaderText = "مرلہ منتقلہ";
                    gridBayan.Columns["KhewatFareeq_Sold_Sarsai"].Visible = false;
                    gridBayan.Columns["KhewatFareeq_Sold_Feet"].HeaderText = "مربع فٹ منتقلہ";
                    gridBayan.Columns["Khatooni_Area_KMSr"].HeaderText = "کنال- مرلہ- سرسائی";
                    gridBayan.Columns["Khatooni_Area_KMSqft"].HeaderText = "کنال- مرلہ- مربع فٹ";
                    gridBayan.Columns["KhatooniKhewatFareeqRecId"].Visible = false;
                    gridBayan.Columns["KhewatGroupFareeqId"].Visible = false;
                    gridBayan.Columns["PersonId"].Visible = false;
                    gridBayan.Columns["RegisterHqDKhataId"].Visible = false;
                    gridBayan.Columns["KhatooniId"].Visible = false;
                }
                   
                  }
              
              }
             #endregion

             #region grid Mushtryan fill Method
             
            
             public void Fillgridmushtryan()
              {
                  DataTable dt = new DataTable();
                  if (cboKhatoooni.SelectedIndex > 0)
                  {
                      string KhatooniId = cboKhatoooni.SelectedValue.ToString();
                      dt = Khatoon.Get_MushtriFareeqein_By_KhatooniId(KhatooniId);
                      gridMushtryan.DataSource = dt;
                if (dt != null)
                {
                    gridMushtryan.Columns["TransactionType"].Visible = false;
                    gridMushtryan.Columns["IntiqalId"].Visible = false;
                    gridMushtryan.Columns["SeqNo"].Visible = false;
                    gridMushtryan.Columns["PersonId"].Visible = false;
                    gridMushtryan.Columns["MurthinId"].Visible = false;
                    gridMushtryan.Columns["Fard_Marla"].Visible = false;
                    gridMushtryan.Columns["KhatooniId"].Visible = false;
                    gridMushtryan.Columns["KhatooniKhewatFareeqRecId"].Visible = false;
                    gridMushtryan.Columns["KhewatTypeId"].Visible = false;
                    gridMushtryan.Columns["Fard_Feet"].Visible = false;
                    gridMushtryan.Columns["KhewatTypeId"].Visible = false;
                    gridMushtryan.Columns["MushtriFareeqId"].Visible = false;

                    gridMushtryan.Columns["CompleteName"].HeaderText = "مشتری";
                    gridMushtryan.Columns["FardAreaPart"].HeaderText = "صافی حصہ";
                    gridMushtryan.Columns["FardPart_Bata"].HeaderText = "حصہ بٹہ";
                    gridMushtryan.Columns["Farad_Kanal"].HeaderText = "کنال";
                    gridMushtryan.Columns["Fard_Marla"].HeaderText = "مرلہ";
                    gridMushtryan.Columns["Fard_Sarsai"].HeaderText = "سرسائی";
                    gridMushtryan.Columns["Mushtri_Area_KMSr"].HeaderText = "کنال- مرلہ- سرسائی";
                    gridMushtryan.Columns["KhewatType"].HeaderText = "قسم مالک";
                    gridMushtryan.Columns["Mushtri_Area_KMSqft"].HeaderText = "کنال- مرلہ- مربع فٹ";
                }

                  }

              }
             #endregion

             #region Fill Khatooni Controls method
             
             
             public void FillKhatooniControls()
              { 
              
              
              
              }
         #endregion

             #region Combobox Moza Selected change event
             
            

             private void cboMoza_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (cboMoza.SelectedIndex > 0)
            {
                string MozaId = cboMoza.SelectedValue.ToString();
                dt = Khatoon.Get_Moza_HaqdaranRegisterNos(MozaId);
                string RegisterId = dt.Rows[0]["RegisterHaqdaranId"].ToString();
                txtRegisterId.Text = RegisterId;
                FillcbobyKhatajat();
            }
        }
             #endregion

             #region Combobox Khatajat Selected change event
             
             
             private void cboKhattaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillcbobyKhatoonies();
            //FillcbobyBayans();
        }
             #endregion

             #region combobox Khatooni Selected change event
             
            

             private void cboKhatoooni_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (cboKhatoooni.SelectedIndex >0)
            {
                string KhatooniId = cboKhatoooni.SelectedValue.ToString();
                dt = Khatoon.Get_Khatooni_BeahShud(KhatooniId);
                txtNameBayan.Text = dt.Rows[0]["NameBaya"].ToString();
                txtKhatooniHissa.Text = dt.Rows[0]["Khatooni_Hissa"].ToString();
                txtKhatooniKanal.Text = dt.Rows[0]["Khatooni_Kanal"].ToString();
                txtKhatooniMarla.Text = dt.Rows[0]["Khatooni_Marla"].ToString();
                txtKhatooniSarsai.Text = dt.Rows[0]["Khatooni_Sarsai"].ToString();
                FillcbobyBayans();
            //    string khataId = cboKhattaNo.SelectedValue.ToString();
            //    dt = Khatoon.Get_KhatoonisbyKhataId(khataId);
            //     RegisterHqdKhataId = dt.Rows[0]["RegisterHqDKhataId"].ToString();

            }
            FillgridBayan();
            Fillgridmushtryan();
        }
             #endregion

             #region Button Save Khatooni Click event
             
            
             private void btnSaveKhatooni_Click(object sender, EventArgs e)
        {
            if (cboKhatoooni.SelectedIndex > 0)
            {
                string KhatooniId = cboKhatoooni.SelectedValue.ToString();

                string KhatooniKashtkaranFullDetail_New = "null";
                string NameBayan = txtNameBayan.Text;
                string Khatooni_Hissa = txtKhatooniHissa.Text;
                string Khatooni_Kanal = txtKhatooniKanal.Text;
                string Khatooni_Marla = txtKhatooniMarla.Text;
                string Khatooni_Sarsai = txtKhatooniSarsai.Text;
                string Khatooni_Feet = Convert.ToString(decimal.Parse(Khatooni_Sarsai) * (decimal)30.5);


                bool BeahShud = true;
                
                string lastId = Khatoon.UPDATE_SDC_khatooniregister_BeahShud(KhatooniId, KhatooniKashtkaranFullDetail_New, NameBayan, BeahShud.ToString(), Khatooni_Hissa, Khatooni_Kanal, Khatooni_Marla, Khatooni_Sarsai, Khatooni_Feet);
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("کھتونی منتخب کریں");
            }
            }
             #endregion

             #region Textbox Name Bayan Key press event
             
            
             private void txtNameBayan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
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
            else if (e.KeyChar == 1)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }
        }
             #endregion

             #region Button save Khatooni khewat Fareeqin group click event
             
             
             private void btnSaveKhatooniKhewatFareeqingroup_Click(object sender, EventArgs e)
        {
            string KhatooniKhewatFareeqRecId = txtKhewatRecId.Text;
            string KhewatGroupFareeqId = txtKhewatgroupFareeqId.Text;
            string RegisterHqDKhataId = cboKhattaNo.SelectedValue.ToString();
            string KhatooniId = cboKhatoooni.SelectedValue.ToString();
            string PersonId = cboBayan.SelectedValue.ToString();
            string KhewatFareeq_Total_Hissa = txtKhewatFareeeqkulHissa.Text.Trim() != "" ? txtMushtriMarla.Text : "0";
            string KhewatFareeq_Total_Kanal = Kanal;
            string KhewatFareeq_Total_Marla = Marla;
            string KhewatFareeq_Total_Sarsai = Convert.ToString(float.Parse(Feet) / 30.25);
            string KhewatFareeq_Total_Feet = Feet;
            string KhewatFareeq_Sold_Hissa = txtKhewatHissaMuntaqila.Text.Trim() != "" ? txtKhewatHissaMuntaqila.Text : "0";
            string KhewatFareeq_Sold_Kanal = txtKhewatSoldkanal.Text.Trim() != "" ? txtKhewatSoldkanal.Text : "0";
            string KhewatFareeq_Sold_Marla = txtKhewatSoldMarla.Text.Trim() != "" ? txtKhewatSoldMarla.Text : "0";
            string KhewatFareeq_Sold_Sarsai = txtKhewatSoldSarsai.Text.Trim() != "" ? txtKhewatSoldSarsai.Text : "0";
            string KhewatFareeq_Sold_Feet = txtKhewatSoldFeet.Text.Trim() != "" ? txtKhewatSoldFeet.Text : "0";
           
            string InsertUserId = (UsersManagments.UserId != null && UsersManagments.UserId > 0) ? UsersManagments.UserId.ToString() : "NULL";
            string InsertLoginName = (UsersManagments.UserName != null && UsersManagments.UserName != "") ? UsersManagments.UserName.ToString() : "NULL";

            string lastId = Khatoon.SaveKhatooniKhewatGroupFareeqein(KhatooniKhewatFareeqRecId, KhewatGroupFareeqId, RegisterHqDKhataId, KhatooniId, PersonId, KhewatFareeq_Total_Hissa, KhewatFareeq_Total_Kanal, KhewatFareeq_Total_Marla, KhewatFareeq_Total_Sarsai, KhewatFareeq_Total_Feet, KhewatFareeq_Sold_Hissa, KhewatFareeq_Sold_Kanal, KhewatFareeq_Sold_Marla, KhewatFareeq_Sold_Sarsai, KhewatFareeq_Sold_Feet, InsertUserId, InsertLoginName, InsertUserId, InsertLoginName);
            MessageBox.Show("ok");
            FillgridBayan();
        }
             #endregion


             #region Button Save Mushti Fariqin click event
             
             
             private void btnSaveMushtriFariqain_Click(object sender, EventArgs e)
        {
            if (cboKhewatTypes.SelectedIndex > 0)
            {
                string MushtriFareeqId = txtMushtriFareeqId.Text;
                string KhatooniKhewatFareeqRecId = txtKhewatRecId.Text;
                string TransactionType = "";
                string IntiqalId = "0";
                string KhatooniId = cboKhatoooni.SelectedValue.ToString();
                string SeqNo = gridMushtryan.Rows.Count.ToString();
                string PersonId = txtMushtriPersonId.Text;
                string MurthinId="0";
                string KhewatTypeId = cboKhewatTypes.SelectedValue.ToString();
                string FardAreaPart = txtMushtriSafiHissa.Text.Trim() != "" ? txtMushtriSafiHissa.Text : "0";
                string FardPart_Bata = txtMushtriFareeqHissBatta.Text.Trim() != "" ? txtMushtriFareeqHissBatta.Text : "0";
                string Farad_Kanal = txtMushtriKanal.Text.Trim() != "" ? txtMushtriKanal.Text : "0";
                string Fard_Marla = txtMushtriMarla.Text.Trim() != "" ? txtMushtriMarla.Text : "0"; 
                string Fard_Sarsai = txtMushtriSarsai.Text.Trim() != "" ? txtMushtriSarsai.Text : "0";
                string Fard_Feet = txtMushtriFeet.Text.Trim() != "" ? txtMushtriFeet.Text : "0";
                string InsertUserId = (UsersManagments.UserId != null && UsersManagments.UserId > 0) ? UsersManagments.UserId.ToString() : "NULL";
                string InsertLoginName = (UsersManagments.UserName != null && UsersManagments.UserName != "") ? UsersManagments.UserName.ToString() : "NULL";

                string lastId = Khatoon.SaveMushtriFareeqein(MushtriFareeqId, KhatooniKhewatFareeqRecId, TransactionType, IntiqalId, KhatooniId, SeqNo, PersonId, MurthinId, KhewatTypeId, FardAreaPart, FardPart_Bata, Farad_Kanal, Fard_Marla, Fard_Sarsai, Fard_Feet, InsertUserId,InsertLoginName, InsertUserId, InsertLoginName);
                Fillgridmushtryan();
                MessageBox.Show("Success");
            }
                 }
             #endregion

             #region Combobox Bayan selected Index change event
             
             
             private void cboBayan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBayan.SelectedIndex > 0)
            {
                string KhatooniId = cboKhatoooni.SelectedValue.ToString();
                DataTable dt = new DataTable();
                dt = Khatoon.Get_KhewatFareeqeinGroup_By_KhatooniId(KhatooniId);
                if (dt.Rows.Count >0)
                {
                    txtKhewatFareeeqkulHissa.Text = dt.Rows[0]["KhewatFareeq_Total_Hissa"].ToString();
                    string KhewatArea = dt.Rows[0]["Khatooni_Area_KMSqft"].ToString();
                    txtKhewatgroupFareeqId.Text = dt.Rows[0]["KhewatGroupFareeqId"].ToString();
                    txtKewatKulArea.Text = KhewatArea;
                    string[] KanalMarlaFeet = KhewatArea.Split('-');
                    Kanal = KanalMarlaFeet[0].ToString();
                    Marla = KanalMarlaFeet[1].ToString();
                    Feet = KanalMarlaFeet[2].ToString();

                    
                }
            }
        }
             #endregion

             private void gridBayan_SelectionChanged(object sender, EventArgs e)
             { foreach (DataGridViewRow row in gridBayan.Rows)
            {
                if (row.Selected)
                {
                    row.Cells["chk1"].Value = true;
                    cboBayan.SelectedValue = row.Cells["PersonId"].Value.ToString();
                    txtKhewatFareeeqkulHissa.Text = row.Cells["KhewatFareeq_Total_Hissa"].Value.ToString();
                    Kanal=row.Cells["KhewatFareeq_Total_Kanal"].Value.ToString();
                  Marla=row.Cells["KhewatFareeq_Total_Marla"].Value.ToString();
                   Sarsai=row.Cells["KhewatFareeq_Total_Sarsai"].Value.ToString();
                   Feet = Convert.ToString(float.Parse(Sarsai) * 30.25);
                    //=row.Cells["KhewatFareeq_Total_Feet"].Value.ToString();
                    txtKhewatHissaMuntaqila.Text = row.Cells["KhewatFareeq_Sold_Hissa"].Value.ToString();
                    txtKhewatSoldkanal.Text = row.Cells["KhewatFareeq_Sold_Kanal"].Value.ToString();
                    txtKhewatSoldMarla.Text = row.Cells["KhewatFareeq_Sold_Marla"].Value.ToString();
                    txtKhewatSoldSarsai.Text = row.Cells["KhewatFareeq_Sold_Sarsai"].Value.ToString();
                    txtKhewatSoldFeet.Text = row.Cells["KhewatFareeq_Sold_Feet"].Value.ToString();
                    //row.Cells["Khatooni_Area_KMSr"].Value.ToString();
                    //row.Cells["Khatooni_Area_KMSqft"].Value.ToString();
                    txtKhewatRecId.Text = row.Cells["KhatooniKhewatFareeqRecId"].Value.ToString();
                    txtKhewatgroupFareeqId.Text=row.Cells["KhewatGroupFareeqId"].Value.ToString();
                    //row.Cells["PersonId"].Value.ToString();
                    //row.Cells["RegisterHqDKhataId"].Value.ToString();
                    //row.Cells["KhatooniId"].Value.ToString();
                }
                else
                {
                    row.Cells["chk1"].Value = false;
                }
                 
                 }
             }
    

        private void gridBayan_DoubleClick(object sender, EventArgs e)
        {
            
            //foreach (DataGridViewRow row in gridBayan.Rows)
            //{
            //    if (row.Selected)
            //    {
            //        row.Cells["chk1"].Value = true;
            //        cboBayan.SelectedValue = row.Cells["PersonId"].Value.ToString();
            //        txtKhewatFareeeqkulHissa.Text = row.Cells["KhewatFareeq_Total_Hissa"].Value.ToString();
            //        Kanal=row.Cells["KhewatFareeq_Total_Kanal"].Value.ToString();
            //      Marla=row.Cells["KhewatFareeq_Total_Marla"].Value.ToString();
            //       Sarsai=row.Cells["KhewatFareeq_Total_Sarsai"].Value.ToString();
            //       Feet = Convert.ToString(float.Parse(Sarsai) * 30.25);
            //        //=row.Cells["KhewatFareeq_Total_Feet"].Value.ToString();
            //        txtKhewatHissaMuntaqila.Text = row.Cells["KhewatFareeq_Sold_Hissa"].Value.ToString();
            //        txtKhewatSoldkanal.Text = row.Cells["KhewatFareeq_Sold_Kanal"].Value.ToString();
            //        txtKhewatSoldMarla.Text = row.Cells["KhewatFareeq_Sold_Marla"].Value.ToString();
            //        txtKhewatSoldSarsai.Text = row.Cells["KhewatFareeq_Sold_Sarsai"].Value.ToString();
            //        txtKhewatSoldFeet.Text = row.Cells["KhewatFareeq_Sold_Feet"].Value.ToString();
            //        //row.Cells["Khatooni_Area_KMSr"].Value.ToString();
            //        //row.Cells["Khatooni_Area_KMSqft"].Value.ToString();
            //        txtKhewatRecId.Text = row.Cells["KhatooniKhewatFareeqRecId"].Value.ToString();
            //        row.Cells["KhewatGroupFareeqId"].Value.ToString();
            //        //row.Cells["PersonId"].Value.ToString();
            //        //row.Cells["RegisterHqDKhataId"].Value.ToString();
            //        //row.Cells["KhatooniId"].Value.ToString();
            //    }
            //    else
            //    {
            //        row.Cells["chk1"].Value = false;
            //    }
        }

        private void btnSearchMushtri_Click(object sender, EventArgs e)
        {
           
            Fs.FormClosed -= new FormClosedEventHandler(FormSearchclosed);
            Fs.FormClosed += new FormClosedEventHandler(FormSearchclosed);
            Fs.MozaId = cboMoza.SelectedValue.ToString();
            Fs.PersonName = txtNameMushtri.Text;
            
            Fs.ShowDialog();
        }
        void FormSearchclosed(object sender,EventArgs e)
        {
            txtNameMushtri.Text = Fs.PersonName;
            txtMushtriPersonId.Text = Convert.ToString(Fs.PersonId);

        }

        private void gridMushtryan_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridMushtryan.Rows)
            {
                if (row.Selected)
                { 
                row.Cells["chk2"].Value=true;

               // row.Cells["TransactionType"].Value.ToString();
               // row.Cells["IntiqalId"].Value.ToString();
               // row.Cells["SeqNo"].Value.ToString();
              txtMushtriPersonId.Text = row.Cells["PersonId"].Value.ToString();
               // row.Cells["MurthinId"].Value.ToString();
               txtMushtriMarla.Text= row.Cells["Fard_Marla"].Value.ToString();
               // row.Cells["KhatooniId"].Value.ToString();
               txtKhewatRecId.Text= row.Cells["KhatooniKhewatFareeqRecId"].Value.ToString();
               cboKhewatTypes.SelectedValue =row.Cells["KhewatTypeId"].Value.ToString();
                txtMushtriFeet.Text=row.Cells["Fard_Feet"].Value.ToString();
                //row.Cells["KhewatTypeId"].Value.ToString();
              txtMushtriFareeqId.Text = row.Cells["MushtriFareeqId"].Value.ToString();

               txtNameMushtri.Text= row.Cells["CompleteName"].Value.ToString();
               txtMushtriSafiHissa.Text= row.Cells["FardAreaPart"].Value.ToString();
               txtMushtriFareeqHissBatta.Text= row.Cells["FardPart_Bata"].Value.ToString();
               txtMushtriKanal.Text= row.Cells["Farad_Kanal"].Value.ToString();
               txtMushtriMarla.Text= row.Cells["Fard_Marla"].Value.ToString();
                txtMushtriSarsai.Text=row.Cells["Fard_Sarsai"].Value.ToString();
                //row.Cells["Mushtri_Area_KMSr"].Value.ToString();
                //row.Cells["KhewatType"].Value.ToString();
                //row.Cells["Mushtri_Area_KMSqft"].Value.ToString();
                }
                else
                {
                
                row.Cells["chk2"].Value=false;
                
                }
            
            }
        }

        private void btndeleteKhewatgroupFareeq_Click(object sender, EventArgs e)
        {
            string KhatooniKhewatFareeqRecId = txtKhewatRecId.Text;
            string s = Khatoon.DELETE_KhatooniKhewatGroupFareeqein(KhatooniKhewatFareeqRecId);
            FillgridBayan();
        }

        private void btndeleteMushtrifareeq_Click(object sender, EventArgs e)
        {
            string MushtriFareeqId = txtMushtriFareeqId.Text;
            string s = Khatoon.DELETE_MushtriFareeqein(MushtriFareeqId);
            Fillgridmushtryan();
        }
       
             }
    }


