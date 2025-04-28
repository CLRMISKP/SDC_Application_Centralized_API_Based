using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.LanguageManager;
using SDC_Application.Classess;
using System.Collections;

namespace SDC_Application.AL
{
    public partial class frmAfradRegister : Form
    {
        AutoComplete objauto = new AutoComplete();
        Persons ObjPerson = new Persons();
        DataTable dtcbpc = new DataTable();
        DataTable dtcbpq = new DataTable();
        DataTable dtgridFH = new DataTable();
        DataTable dtgridOrg = new DataTable();
        DataTable dtMoza = new DataTable();
        DataTable dtFard = new DataTable();
        DataTable dtMurtahin = new DataTable();
        LanguageConverter lang = new LanguageConverter();
        BindingSource bs = new BindingSource();
        BindingSource bsFH = new BindingSource();
        BindingSource bsR = new BindingSource();
        BindingSource bsFamilyFard = new BindingSource();

        Persons Pr = new Persons();

        public string FamilyId
        {
            get;
            set;
        }

        public string MozaId { get; set; }
        public string PersonFamilyStatus { get; set; }

        public frmAfradRegister()
        {
            InitializeComponent();
        }

        #region Form Load Event

        private void frmAfradRegister_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);
            //DataGridViewHelper.addHelpterToAllFormGridViews(this);
            //-----------------------------------------
            txtFamilyHeadId.Text = "-1";
            btnSaveFamilyHead.Enabled = true;
            btnDelFamilyHead.Enabled = true;
            fillPersonCatergory(UsersManagments._Tehsilid.ToString());
            fillPersonQoam(UsersManagments._Tehsilid.ToString());
            fillPersonCatergoryFard(UsersManagments._Tehsilid.ToString());
            fillPersonQoamFard(UsersManagments._Tehsilid.ToString());
            grpFamilyHeadTop.Enabled = false;
            PersonFamilyStatus = "1";
            fillFardMoza();

        }

        #endregion

        #region Key Press Event for Language


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

        #endregion

        private void cboFardMauza_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
    			{
                FamilyId = "-1";// Reset the current family id selected
                if (cboFardMauza.DataSource != null)
                {
                    if (cboFardMauza.SelectedIndex > 0)
                    {
                        grpFamilyHeadTop.Enabled = true;
                        //FillFamilyHeadGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus);
                        //FillFardForFHGrid(cboFardMauza.SelectedValue.ToString(), "1");
                        //FillFardGrid(txtFardFamilyId.Text.ToString());
                        FillOrgGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus, "");
                        //FillRahinGrid(cboFardMauza.SelectedValue.ToString());
                        //FillMurtahinGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus);
                        grpFardTop.Enabled = false;
                        grpFardMiddle.Enabled = false;
                        grpFardBottom.Enabled = false;
                        MozaId = cboFardMauza.SelectedValue.ToString();
                        //grpMurtahinTop.Enabled = false;
                        //grpMurtahinMiddle.Enabled = false;
                        //grpMurtahinBottom.Enabled = false;
                    }
                }
                else
                {
                    grpFamilyHeadTop.Enabled = false;

                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Tab Selection Change Event

        private void tabControlFard_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFardMauza.DataSource != null)
            {
                if (tabControlFard.SelectedIndex == 0)
                {
                    rbFamilyHead.Checked = true;
                    rbFard.Checked = false;
                    rbOrg.Checked = false;
                    rbMurtahin.Checked = false;
                    PersonFamilyStatus = "1";
                }
                else if (tabControlFard.SelectedIndex == 1)
                {
                    rbFamilyHead.Checked = false;
                    rbFard.Checked = true;
                    rbOrg.Checked = false;
                    rbMurtahin.Checked = false;
                    PersonFamilyStatus = "2";
                    //FillFardForFHGrid(cboFardMauza.SelectedValue.ToString(), "1");
                    //FillFardGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus);
                    grpFardTop.Enabled = false;
                    grpFardMiddle.Enabled = false;
                    grpFardBottom.Enabled = false;
                }
                else if (tabControlFard.SelectedIndex == 2)
                {
                    rbFamilyHead.Checked = false;
                    rbFard.Checked = false;
                    rbOrg.Checked = true;
                    rbMurtahin.Checked = false;
                    PersonFamilyStatus = "3";
                    FillOrgGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus, "");
                    txtOrgName.Enabled = false;
                    btnSaveOrg.Enabled = true;
                    btnDelOrg.Enabled = true;
                }
                else if (tabControlFard.SelectedIndex == 3)
                {
                    rbFamilyHead.Checked = false;
                    rbFard.Checked = false;
                    rbOrg.Checked = false;
                    rbMurtahin.Checked = true;
                    PersonFamilyStatus = "4";
                    //FillRahinGrid(cboFardMauza.SelectedValue.ToString());
                    FillMurtahinGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus, "");
                    //grpMurtahinTop.Enabled = false;
                    //grpMurtahinMiddle.Enabled = false;
                    //grpMurtahinBottom.Enabled = false;
                }
            }
        }
        # endregion

        #region Code for Tab Family Head

        #region KeyPress Events

        private void txtFamilyHeadCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (this.txtFamilyHeadCNIC.Text.Length == 5)
            //{
            //    this.txtFamilyHeadCNIC.Text = this.txtFamilyHeadCNIC.Text + "-";
            //    txtFamilyHeadCNIC.SelectionStart = 6;
            //}
            //if (this.txtFamilyHeadCNIC.Text.Length == 13)
            //{
            //    this.txtFamilyHeadCNIC.Text = this.txtFamilyHeadCNIC.Text + "-";
            //    txtFamilyHeadCNIC.SelectionStart = 14;
            //}
        }

        #endregion

        #region Record Insertion members

        private void SaveFamilyHead()
        {
        try
        {
       ArrayList Labels = new ArrayList();
            Labels.Add(lbl1.Text);
            Labels.Add(lbl8.Text);
            ArrayList collection = new ArrayList();
            string empty = null;
            collection.Add(this.txtFamilyHeadName.Text.ToString());
            collection.Add(this.cboFamilyHeadCaste.SelectedIndex.ToString());
          
            for (int i = 0; i <= collection.Count - 1; i++)
            {
                if (Convert.ToString(collection[i]) == string.Empty || Convert.ToString(collection[i]) == "0")
                {
                    empty += "," + Labels[i].ToString();
                }
            }

            if (empty == null)
            {
                if ((txtFamilyHeadCNIC.Text.Trim().Length == 13 || txtFamilyHeadCNIC.Text.Trim().Length == 0 || txtFamilyHeadCNIC.Text.Trim().Length == 1 ) && cboFamilyHeadCaste.SelectedValue.ToString().Length>2)
                {
                
                    string PersonId = txtFamilyHeadId.Text.ToString();
                    string PersonTypeId = "1";
                    string FamilyId = txtFHFamilyId.Text.ToString();
                    string QoamId = cboFamilyHeadCaste.SelectedValue.ToString();
                    string FamilyHead;
                    if (rbFamilyHead.Checked) { FamilyHead = "1"; } else { FamilyHead = "0"; }
                    string ParentId = txtFHParentId.Text.ToString();
                    string FamilyLevel = ParentId=="-1"?"10": ObjPerson.GetFamilyLevel(ParentId);
                    string PersonName = txtFamilyHeadName.Text.ToString();
                    string Relation = cboFamilyHeadRelation.Text.ToString();
                    string FatherName = txtFamilyHeadFatherName.Text.ToString();
                    string MotherName = txtFamilyHeadMotherName.Text.ToString();
                    string Gender = cboFamilyHeadGender.Text.ToString().Length<3?"مرد":cboFamilyHeadGender.Text;
                    string mozaId = cboFardMauza.SelectedValue.ToString();
                    string CNIC = txtFamilyHeadCNIC.Text.Length==13 ? txtFamilyHeadCNIC.Text.ToString() : "NULL";
                    string DOB = "NULL";
                    string Sakna = txtFamilyHeadSakna.Text.ToString();
                    string Address = txtFamilyHeadFullAddress.Text.ToString();
                    string PersonDied;
                    if (rbFHDeadYes.Checked)
                    { PersonDied = "1"; }
                    else
                    { PersonDied = "0"; }
                     string PersonCategoryId = cboFamilyHeadPersonCategroy.SelectedIndex > 0 ? cboFamilyHeadPersonCategroy.SelectedValue.ToString(): "1";
                    string UsrId = UsersManagments.UserId.ToString();

                    if (txtFamilyHeadId.Text == "-1")
                    {
                        string R_CNIC = Pr.CheckCNICAlreadyEntered(PersonTypeId, mozaId, CNIC);
                        if (R_CNIC != "-1")
                        {
                            MessageBox.Show(" اس موضع میں شناختی کارڈ نمبر" + CNIC + " کا اندراج پہلے سے ہو چکا ہے۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    string serialNoHead = txtSrNoParent.Text != "" ? txtSrNoParent.Text : "0";
                    string LastId = ObjPerson.SaveInteqalAfradRegister(PersonId, PersonTypeId, FamilyId, QoamId, FamilyHead, FamilyLevel, ParentId, PersonName, Relation, FatherName, MotherName, Gender, mozaId, CNIC, DOB, Sakna, Address, PersonDied, PersonCategoryId, UsrId, PersonFamilyStatus, UsersManagments.UserName.ToString(), serialNoHead);
                    txtFamilyHeadId.Text = LastId;
                    //MessageBox.Show("سربراہ کا اندراج ہوگیاہے۔");
                    btnSaveFamilyHead.Enabled = true;
                    this.ClearFormControls(grpFamilyHeadTop);
                    txtFamilyHeadId.Text = "-1";
                    txtFHFamilyId.Text = "-1";
                    txtFHParentId.Text = "-1";
                }
                  else
                  {
                      MessageBox.Show(empty + "-   درست شناختی کارڈ نمبر کا اندراج کریں یا قوم کا انتخاب کریں", " شناختی کارڈ نمبر اور قوم  ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
               
            }
            else
            {
                MessageBox.Show(empty + "- کا اندراج کریں", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                }
         catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Load Combo Box Methods

        private void fillPersonCatergory(string TehsilId)
        {
            try
    			{
            this.dtcbpc = ObjPerson.GetPersonCategory(TehsilId);
                if (dtcbpc != null)
                {
                    DataRow PersonCategory = dtcbpc.NewRow();
                    PersonCategory["PersonCategoryId"] = "0";
                    PersonCategory["PersonCategory"] = " -  قسم افراد چنیے - ";
                    dtcbpc.Rows.InsertAt(PersonCategory, 0);
                    cboFamilyHeadPersonCategroy.DataSource = dtcbpc;
                    cboFamilyHeadPersonCategroy.DisplayMember = "PersonCategory";
                    cboFamilyHeadPersonCategroy.ValueMember = "PersonCategoryId";
                    cboFamilyHeadPersonCategroy.SelectedValue = 0;
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillFardMoza()
        {
            try
    			{
            this.dtMoza = ObjPerson.GetMozaList();
                if (dtMoza != null)
                {
                    DataRow MozaList = dtMoza.NewRow();
                    MozaList["MozaId"] = "0";
                    MozaList["MozaNameUrdu"] = " -  موضع چنیے - ";
                    dtMoza.Rows.InsertAt(MozaList, 0);
                    cboFardMauza.DataSource = dtMoza;
                    cboFardMauza.DisplayMember = "MozaNameUrdu";
                    cboFardMauza.ValueMember = "MozaId";
                }
            
            if (MozaId==null)
            {
                
                cboFardMauza.SelectedValue = 0;
            }
            else
            {
                cboFardMauza.SelectedValue = MozaId;
            }
            }
 			catch (Exception ex)
             {
             MessageBox.Show(ex.Message);
             }
        }

        private void fillPersonQoam(string TehsilId)
        {
            try
            {
            this.dtcbpq = ObjPerson.GetQoam(TehsilId);
                if (dtcbpq != null)
                {
                    DataRow PersonQoam = dtcbpq.NewRow();
                    PersonQoam["QoamId"] = "0";
                    PersonQoam["Qoam"] = " -  قوم چنیے - ";
                    dtcbpq.Rows.InsertAt(PersonQoam, 0);
                    cboFamilyHeadCaste.DataSource = dtcbpq;
                    cboFamilyHeadCaste.DisplayMember = "Qoam";
                    cboFamilyHeadCaste.ValueMember = "QoamId";
                    cboFamilyHeadCaste.SelectedValue = 0;
                }
            }
 			catch (Exception ex)
            {
             MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region GridView Fill Methods

        public void FillFamilyHeadGrid(string mozId, string familyStatusId, string FamilyHeadName)
        {
            try
    			{
            dtgridFH = ObjPerson.GetMozaAfradListByTypeId(mozId, familyStatusId, FamilyHeadName);
            if (dtgridFH != null)
            {
                bsFH.DataSource = dtgridFH;
                grdFamilyHead.DataSource = bsFH;
                 grdFamilyHead.DataSource = dtgridFH;
                if (dtgridFH != null)
                {
                   // grdFamilyHead.DataSource = dtgridFH;
                    grdFamilyHead.Columns["PersonId"].Visible = false;
                    grdFamilyHead.Columns["PersonTypeId"].Visible = false;
                    grdFamilyHead.Columns["FamilyHead"].Visible = false;
                    grdFamilyHead.Columns["FamilyLevel"].Visible = false;
                    grdFamilyHead.Columns["ParentId"].Visible = false;
                    grdFamilyHead.Columns["Relation"].Visible = false;
                    grdFamilyHead.Columns["Fathername"].Visible = false;
                    grdFamilyHead.Columns["MotherName"].Visible = false;
                    grdFamilyHead.Columns["Gender"].Visible = false;
                    grdFamilyHead.Columns["PersonDied"].Visible = false;
                    grdFamilyHead.Columns["PersonCategoryId"].Visible = false;
                    grdFamilyHead.Columns["MozaId"].Visible = false;
                    grdFamilyHead.Columns["CNIC"].Visible = false;
                    grdFamilyHead.Columns["DateOfBirth"].Visible = false;
                    grdFamilyHead.Columns["Sakna"].Visible = false;
                    grdFamilyHead.Columns["Age"].Visible = false;
                    grdFamilyHead.Columns["QoamId"].Visible = false;
                    grdFamilyHead.Columns["FmailyNo"].Visible = false;
                    grdFamilyHead.Columns["familyType"].Visible = false;
                    grdFamilyHead.Columns["familytypeId"].Visible = false;
                    grdFamilyHead.Columns["PersonName"].Visible = false;
                    grdFamilyHead.Columns["FamilyName"].HeaderText = "نام";
                    grdFamilyHead.Columns["Address"].HeaderText = "پتہ ";
                    grdFamilyHead.Columns["SeqNo"].HeaderText = "نمبر شمار ";
                    grdFamilyHead.Columns["FamilyNo"].HeaderText = "خاندان نمبر ";
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchFH_TextChanged(object sender, EventArgs e)
        {
            if (bsFH != null)
            {
                bsFH.Filter = string.Format("FamilyName LIKE '%{0}%' ", txtSearchFH.Text);
            }
        }

        #endregion

        private void tabControlFard_TabIndexChanged(object sender, EventArgs e)
        {
           
        }   

        #region Button Click Event Members

        private void btnSaveFamilyHead_Click(object sender, EventArgs e)
        {
            string personName = txtFamilyHeadName.Text;
            SaveFamilyHead();
            FillFamilyHeadGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus, personName);
        }

        private void btnNewFamilyHead_Click(object sender, EventArgs e)
        {
            btnSaveFamilyHead.Enabled = true;
            btnDelFamilyHead.Enabled = true;
            this.ClearFormControls(grpFamilyHeadTop);
            txtFamilyHeadId.Text = "-1";
            txtFHFamilyId.Text = "-1";
            txtFHParentId.Text = "-1";
            txtFamilyHeadName.Focus();
        }
        #endregion

        #region Clear Form Controls

        private void ClearFormControls(GroupBox gBox)
        {
            foreach (Control ctl in gBox.Controls)
            {
                if (ctl.GetType() == typeof(TextBox))
                {
                    TextBox t = ctl as TextBox;
                    t.Clear();
                }
                else if (ctl.GetType() == typeof(ComboBox))
                {
                    ComboBox b = ctl as ComboBox;
                    b.SelectedValue = 0;
                }
                else if (ctl.GetType() == typeof(CheckBox))
                {
                    CheckBox chk = ctl as CheckBox;
                    chk.Checked = false;
                }
                else if (ctl.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker dt = ctl as DateTimePicker;
                    dt.Value = DateTime.Today;
                }
            }

        }
        #endregion

        #region Gridview Click Events

        private void grdFamilyHead_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
    			{
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdFamilyHead.CurrentRow.Cells["colChooseFH"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdFamilyHead.SelectedRows.Count > 0)
                    {
                        btnDelFamilyHead.Enabled = true;
                        btnSaveFamilyHead.Enabled = true;
                        if (row.Selected)
                        {
                            row.Cells["colChooseFH"].Value = 1;
                            txtFamilyHeadId.Text = row.Cells["PersonId"].Value.ToString();
                            txtFHFamilyId.Text = row.Cells["FmailyNo"].Value.ToString();
                            txtFHParentId.Text = row.Cells["ParentId"].Value.ToString();
                            txtFamilyHeadName.Text = row.Cells["PersonName"].Value.ToString();
                            cboFamilyHeadRelation.Text = row.Cells["Relation"].Value.ToString();
                            txtFamilyHeadFatherName.Text = row.Cells["Fathername"].Value.ToString();
                            txtFamilyHeadMotherName.Text = row.Cells["MotherName"].Value.ToString();
                            cboFamilyHeadGender.Text = row.Cells["Gender"].Value.ToString();
                            fillPersonCatergory(UsersManagments._Tehsilid.ToString());
                            cboFamilyHeadPersonCategroy.SelectedValue = row.Cells["PersonCategoryId"].Value.ToString();
                            txtFamilyHeadCNIC.Text = row.Cells["CNIC"].Value.ToString();
                            string IsDead = row.Cells["PersonDied"].Value.ToString();
                            if (IsDead == "True") { rbFHDeadYes.Checked = true; } else { rbFHDeadNo.Checked = true; }
                            fillPersonQoam(UsersManagments._Tehsilid.ToString());
                            cboFamilyHeadCaste.SelectedValue = row.Cells["QoamId"].Value.ToString();
                            txtFamilyHeadSakna.Text = row.Cells["Sakna"].Value.ToString();
                            txtFamilyHeadFullAddress.Text = row.Cells["Address"].Value.ToString();
                            cboFardMauza.SelectedValue = row.Cells["MozaId"].Value.ToString();
                            txtSrNoParent.Text = row.Cells["SeqNo"].Value.ToString();
                        }
                        else
                        {
                            row.Cells["colChooseFH"].Value = 0;
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

        #region Record Delete Members

        private void btnDelFamilyHead_Click(object sender, EventArgs e)
        {
            try
            {
            if (txtFamilyHeadId.Text != "-1")
            {
                if (MessageBox.Show("کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    string personName = txtFamilyHeadName.Text;
                        ObjPerson.DeleteAfradRegister(txtFamilyHeadId.Text.ToString());
                    MessageBox.Show("ریکارڈ حذف ہوگیا ہے۔");
                    FillFamilyHeadGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus, personName);
                    btnSaveFamilyHead.Enabled = true;
                    btnDelFamilyHead.Enabled = true;
                    this.ClearFormControls(grpFamilyHeadTop);
                    txtFamilyHeadId.Text = "-1";
                    txtFHFamilyId.Text = "-1";
                    txtFHParentId.Text = "-1";

                }
                else
                {

                    btnSaveFamilyHead.Enabled = true;
                    btnDelFamilyHead.Enabled = true;
                    this.ClearFormControls(grpFamilyHeadTop);
                    txtFamilyHeadId.Text = "-1";
                    txtFHFamilyId.Text = "-1";
                    txtFHParentId.Text = "-1";
                }
            }
            else
            {
                MessageBox.Show("سربراہ لوڈ کریں", "سربراہ لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            }
 			catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
        }

        #endregion

        #endregion

        #region Code for Tab Organization

        #region Button Click Events

        private void btnNewOrg_Click(object sender, EventArgs e)
        {
            btnSaveOrg.Enabled = true;
            btnDelOrg.Enabled = true;
            this.ClearFormControls(grpTopOrg);
            txtOrgName.Enabled = true;
            txtOrgId.Text = "-1";
            txtOrgFamilyId.Text = "-1";
            txtOrgParentId.Text = "-1";
            txtOrgName.Focus();
        }

        private void btnSaveOrg_Click(object sender, EventArgs e)
        {
            SaveOrg();
            FillOrgGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus, "");
        }

        #endregion

        #region Record Insertion members

        private void SaveOrg()
        {
            if (txtOrgName.Text != "")
            {
                try
                {
                    string PersonId = txtOrgId.Text.ToString();
                    string PersonTypeId = "1";
                    string FamilyId = txtOrgFamilyId.Text.ToString();
                    string QoamId = "NULL";
                    string FamilyHead = "0";
                    string ParentId = txtOrgParentId.Text.ToString();
                    string FamilyLevel = "0";
                    string PersonName = txtOrgName.Text.ToString();
                    string Relation = "";
                    string FatherName = "";
                    string MotherName = "";
                    string Gender = "NULL";
                    string mozaId = cboFardMauza.SelectedValue.ToString();
                    string CNIC = "NULL";
                    string DOB = "NULL";
                    string Sakna = "NULL";
                    string Address = "NULL";
                    string PersonDied = "0";
                    string PersonCategoryId = "NULL";
                    string UsrId = UsersManagments.UserId.ToString();
                    string LastId = ObjPerson.SaveInteqalAfradRegister(PersonId, PersonTypeId, FamilyId, QoamId, FamilyHead, FamilyLevel, ParentId, PersonName, Relation, FatherName, MotherName, Gender, mozaId, CNIC, DOB, Sakna, Address, PersonDied, PersonCategoryId, UsrId, PersonFamilyStatus, UsersManagments.UserName.ToString(), "1");
                    txtOrgId.Text = LastId;
                    MessageBox.Show("اداراہ کا اندراج ہوگیاہے۔");
                    btnSaveOrg.Enabled = true;
                    this.ClearFormControls(grpTopOrg);
                    txtOrgId.Text = "-1";
                    txtOrgFamilyId.Text = "-1";
                    txtOrgParentId.Text = "-1";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else 
            {
                MessageBox.Show("اداراہ کا اندراج کریں۔","", MessageBoxButtons.OK,MessageBoxIcon.Stop);
                txtOrgName.Focus();
            }
        }

        #endregion

        #region GridView Fill Methods

        public void FillOrgGrid(string mozId, string familyStatusId, string PersonName)
        {            
			try
    			{
            dtgridOrg = ObjPerson.GetMozaAfradListByTypeId(mozId, familyStatusId, PersonName);
            if (dtgridOrg != null)
            {
                grdOrganization.DataSource = dtgridOrg;
                grdOrganization.Columns["PersonId"].Visible = false;
                grdOrganization.Columns["PersonTypeId"].Visible = false;
                grdOrganization.Columns["FamilyHead"].Visible = false;
                grdOrganization.Columns["FamilyLevel"].Visible = false;
                grdOrganization.Columns["ParentId"].Visible = false;
                grdOrganization.Columns["Relation"].Visible = false;
                grdOrganization.Columns["Fathername"].Visible = false;
                grdOrganization.Columns["MotherName"].Visible = false;
                grdOrganization.Columns["Gender"].Visible = false;
                grdOrganization.Columns["PersonDied"].Visible = false;
                grdOrganization.Columns["PersonCategoryId"].Visible = false;
                grdOrganization.Columns["MozaId"].Visible = false;
                grdOrganization.Columns["CNIC"].Visible = false;
                grdOrganization.Columns["DateOfBirth"].Visible = false;
                grdOrganization.Columns["Sakna"].Visible = false;
                grdOrganization.Columns["Age"].Visible = false;
                grdOrganization.Columns["QoamId"].Visible = false;
                grdOrganization.Columns["FmailyNo"].Visible = false;
                grdOrganization.Columns["familyType"].Visible = false;
                grdOrganization.Columns["familytypeId"].Visible = false;
                grdOrganization.Columns["PersonName"].Visible = false;
                grdOrganization.Columns["Address"].Visible = false;
                grdOrganization.Columns["FamilyName"].HeaderText = "نام";
                grdOrganization.Columns["FamilyNo"].Visible = false;
            
            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #endregion

        #region Gridviw Click Event

        private void grdOrganization_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
    			{
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdOrganization.CurrentRow.Cells["colChooseOrg"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdOrganization.SelectedRows.Count > 0)
                    {
                        btnDelOrg.Enabled = true;
                        btnSaveOrg.Enabled = true;
                        if (row.Selected)
                        {
                            row.Cells["colChooseOrg"].Value = 1;
                            txtOrgId.Text = row.Cells["PersonId"].Value.ToString();
                            txtOrgFamilyId.Text = row.Cells["FmailyNo"].Value.ToString();
                            txtOrgParentId.Text = row.Cells["ParentId"].Value.ToString();
                            txtOrgName.Text = row.Cells["PersonName"].Value.ToString();
                            cboFardMauza.SelectedValue = row.Cells["MozaId"].Value.ToString();
                        }
                        else
                        {
                            row.Cells["colChooseOrg"].Value = 0;
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

        #region Record Deletion Events

        private void btnDelOrg_Click(object sender, EventArgs e)
        {
            try
    			{
            if (txtOrgId.Text != "-1")
            {
                if (MessageBox.Show("کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {

                    ObjPerson.DeleteAfradRegister(txtOrgId.Text.ToString());
                    MessageBox.Show("ریکارڈ حذف ہوگیا ہے۔");
                    FillOrgGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus, "");
                    btnSaveOrg.Enabled = true;
                    btnDelOrg.Enabled = true;
                    this.ClearFormControls(grpTopOrg);
                    txtOrgId.Text = "-1";
                    txtOrgFamilyId.Text = "-1";
                    txtOrgParentId.Text = "-1";

                }
                else
                {
                    btnSaveOrg.Enabled = true;
                    btnDelOrg.Enabled = true;
                    this.ClearFormControls(grpTopOrg);
                    txtOrgId.Text = "-1";
                    txtOrgFamilyId.Text = "-1";
                    txtOrgParentId.Text = "-1";
                }
            }
            else
            {
                MessageBox.Show("ادارہ لوڈ کریں", "ادارہ لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #endregion

        #region Code for Tab Fard

        #region Button Click Events

        private void btnNewFard_Click(object sender, EventArgs e)
        {
            btnSaveFard.Enabled = true;
            btnDelFard.Enabled = true;
            //this.ClearFormControls(grpFamilyHeadTop);
            this.ClearFormControls(grpFardTop);
            txtFardId.Text = "-1";
            int count = grdFard.Rows.Count;
            txtSrNoChild.Text = (count + 1).ToString();
            cboFardCaste.SelectedValue = grdFardForFH.SelectedRows[0].Cells["QoamId"].Value;
        }
        
        /*
        private void btnSaveFard_Click(object sender, EventArgs e)
        {
            if ((txtFardCNIC.Text.Trim().Length == 13 || txtFardCNIC.Text.Trim().Length == 0 || txtFardCNIC.Text.Trim().Length == 1) && txtFardName.Text.Trim().Length > 0 && cboFardParent.SelectedValue.ToString().Length > 2 &&
                cboFardRelation.Text.Length > 2 && cboFardGender.Text.Length > 2 && cboFardAfradType.SelectedValue.ToString() != "0" && cboFardCaste.SelectedValue.ToString() != "0" && txtSrNoChild.Text.Length > 0 && cboFardCaste.SelectedValue.ToString().Length>3)
            {
                SaveFard();
                FillFardGrid(txtFardFamilyId.Text.ToString(), cboFardMauza.SelectedValue.ToString());
                int count = grdFard.Rows.Count;
                txtSrNoChild.Text = (count + 1).ToString();
                cboFardCaste.SelectedValue = grdFardForFH.SelectedRows[0].Cells["QoamId"].Value;
            }
            else
                MessageBox.Show("فرد خاندان کے تمام کوائف مکمل کریں", "نا مکمل کوائف", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        */

        private void btnSaveFard_Click(object sender, EventArgs e)
        {
            // Check if cboFardCaste.SelectedValue is null and if so, set it to the default value
            if (cboFardAfradType.SelectedValue == null)
            {
                MessageBox.Show("قسم فرد کی انتخاب کریں۔");
            }
            else
            {
                if (cboFardCaste.SelectedValue == null)
                {

                    // Assuming you want to set it to the first item in the combo box
                    if (cboFardCaste.Items.Count > 0)
                    {
                        cboFardCaste.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("There are no items in the Caste combo box.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Exit the event handler as there is nothing to select
                    }
                }

                // The rest of your checks can now safely assume cboFardCaste.SelectedValue is not null
                if ((txtFardCNIC.Text.Trim().Length == 13 || txtFardCNIC.Text.Trim().Length == 0 || txtFardCNIC.Text.Trim().Length == 1) &&
                    txtFardName.Text.Trim().Length > 0 &&
                    cboFardParent.SelectedValue.ToString().Length > 2 &&
                    cboFardRelation.Text.Length > 2 &&
                    cboFardGender.Text.Length > 2 &&
                    cboFardAfradType.SelectedValue.ToString() != "0" &&
                    cboFardCaste.SelectedValue.ToString() != "0" &&
                    txtSrNoChild.Text.Length > 0 &&
                    cboFardCaste.SelectedValue.ToString().Length > 1)
                {
                    SaveFard();
                    FillFardGrid(txtFardFamilyId.Text.ToString(), cboFardMauza.SelectedValue.ToString());
                    int count = grdFard.Rows.Count;
                    txtSrNoChild.Text = (count + 1).ToString();
                    cboFardCaste.SelectedValue = grdFardForFH.SelectedRows[0].Cells["QoamId"].Value;
                }
                else
                {
                    MessageBox.Show("فرد خاندان کے تمام کوائف مکمل کریں", "نا مکمل کوائف", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }


        #endregion

        #region Load Combo Box Members

        private void fillFardParent(string muzaId, string familyId)
        {
            try
    			{
            this.dtFard = ObjPerson.GetMozaParentsList(muzaId, familyId);
                if (this.dtFard != null)
                {
                    DataRow FardPrnt = dtFard.NewRow();
                    FardPrnt["PersonId"] = "0";
                    FardPrnt["FamilyName"] = " -  سربراہ چنیے - ";
                    dtFard.Rows.InsertAt(FardPrnt, 0);
                    cboFardParent.DataSource = dtFard;
                    cboFardParent.DisplayMember = "FamilyName";
                    cboFardParent.ValueMember = "PersonId";
                    cboFardParent.SelectedValue = 0;
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fillPersonCatergoryFard(string TehsilId)
        {
            try
            {
                DataTable dtPersonCategory = new DataTable();
            dtPersonCategory = ObjPerson.GetPersonCategory(TehsilId);
                if (dtPersonCategory != null)
                {

                    DataRow Category = dtPersonCategory.NewRow();
                    Category["PersonCategoryId"] = "0";
                    Category["PersonCategory"] = " -  قسم افراد چنیے - ";
                    dtPersonCategory.Rows.InsertAt(Category, 0);
                    cboFardAfradType.DataSource = dtPersonCategory;
                    cboFardAfradType.DisplayMember = "PersonCategory";
                    cboFardAfradType.ValueMember = "PersonCategoryId";
                    cboFardAfradType.SelectedValue = 0;
                }
            }
 			catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
        }

        private void fillPersonQoamFard(string TehsilId)
        {
            try
    			{
                DataTable dtPersonQoam = new DataTable();
            dtPersonQoam = ObjPerson.GetQoam(TehsilId);
                if (dtPersonQoam != null)
                {
                    DataRow PersonQoam = dtPersonQoam.NewRow();
                    PersonQoam["QoamId"] = "0";
                    PersonQoam["Qoam"] = " -  قوم چنیے - ";
                    dtPersonQoam.Rows.InsertAt(PersonQoam, 0);
                    cboFardCaste.DataSource = dtPersonQoam;
                    cboFardCaste.DisplayMember = "Qoam";
                    cboFardCaste.ValueMember = "QoamId";
                    cboFardCaste.SelectedValue = 0;
                }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region GridView Fill Methods

        public void FillFardForFHGrid(string mozId, string familyStatusId, string PersonName)
        {
            try
            {
            dtgridFH = ObjPerson.GetMozaAfradListByTypeId(mozId, familyStatusId, PersonName);
            if (dtgridFH != null)
            {
                bs.DataSource = dtgridFH;
                grdFardForFH.DataSource = bs;
                grdFardForFH.DataSource = dtgridFH;
                if (dtgridFH != null)
                {
                    //grdFardForFH.DataSource = dtgridFH;
                    grdFardForFH.Columns["PersonId"].Visible = false;
                    grdFardForFH.Columns["PersonTypeId"].Visible = false;
                    grdFardForFH.Columns["FamilyHead"].Visible = false;
                    grdFardForFH.Columns["FamilyLevel"].Visible = false;
                    grdFardForFH.Columns["ParentId"].Visible = false;
                    grdFardForFH.Columns["Relation"].Visible = false;
                    grdFardForFH.Columns["Fathername"].Visible = false;
                    grdFardForFH.Columns["MotherName"].Visible = false;
                    grdFardForFH.Columns["Gender"].Visible = false;
                    grdFardForFH.Columns["PersonDied"].Visible = false;
                    grdFardForFH.Columns["PersonCategoryId"].Visible = false;
                    grdFardForFH.Columns["MozaId"].Visible = false;
                    grdFardForFH.Columns["CNIC"].Visible = false;
                    grdFardForFH.Columns["DateOfBirth"].Visible = false;
                    grdFardForFH.Columns["Sakna"].Visible = false;
                    grdFardForFH.Columns["Age"].Visible = false;
                    grdFardForFH.Columns["QoamId"].Visible = false;
                    grdFardForFH.Columns["FmailyNo"].Visible = false;
                    grdFardForFH.Columns["familyType"].Visible = false;
                    grdFardForFH.Columns["familytypeId"].Visible = false;
                    grdFardForFH.Columns["PersonName"].Visible = false;
                    grdFardForFH.Columns["FamilyName"].HeaderText = "نام";
                    grdFardForFH.Columns["Address"].Visible = false;
                    grdFardForFH.Columns["SeqNo"].Visible = false;
                    grdFardForFH.Columns["FamilyNo"].HeaderText = "خاندان نمبر ";
                }
            }
             }
 			catch (Exception ex)
             {
                MessageBox.Show(ex.Message);
             }
        }

        private void txtSearchFHFard_TextChanged(object sender, EventArgs e)
        {
            if (bs != null)
            {
                bs.Filter = string.Format("FamilyName LIKE '%{0}%' ", txtSearchFHFard.Text);
            }
        }

        public void FillFardGrid(string famlyId, string mouzaId)
        {
            try
    			{
            dtFard = ObjPerson.GetFamilyPersonsListByMozaId(famlyId, mouzaId);
            bsFamilyFard.DataSource = dtFard;
            grdFard.DataSource = null;
            if (dtFard != null)
            {
                    grdFard.DataSource = bsFamilyFard.DataSource;
                    grdFard.Columns["PersonId"].Visible = false;
                    grdFard.Columns["PersonTypeId"].Visible = false;
                    grdFard.Columns["FamilyHead"].Visible = false;
                    grdFard.Columns["ParentId"].Visible = false;
                    grdFard.Columns["Relation"].Visible = false;
                    grdFard.Columns["Fathername"].Visible = false;
                    grdFard.Columns["MotherName"].Visible = false;
                    grdFard.Columns["Gender"].Visible = false;
                    grdFard.Columns["PersonDied"].Visible = false;
                    grdFard.Columns["PersonCategoryId"].Visible = false;
                    grdFard.Columns["MozaId"].Visible = false;
                    grdFard.Columns["CNIC"].Visible = false;
                    grdFard.Columns["DateOfBirth"].Visible = false;
                    grdFard.Columns["Sakna"].Visible = false;
                    grdFard.Columns["Age"].Visible = false;
                    grdFard.Columns["QoamId"].Visible = false;
                    grdFard.Columns["FmailyNo"].Visible = false;
                    grdFard.Columns["FamilyLevel"].Visible = false;
                    grdFard.Columns["familyType"].Visible = false;
                    grdFard.Columns["familytypeId"].Visible = false;
                    grdFard.Columns["PersonName"].Visible = false;
                    grdFard.Columns["FamilyName"].HeaderText = "فرد کا نام";
                    grdFard.Columns["Address"].HeaderText = "پتہ ";
                    grdFard.Columns["SeqNo"].HeaderText = "نمبر شمار ";
            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region KeyPress Events

        private void txtFardCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (this.txtFardCNIC.Text.Length == 5)
            //{
            //    this.txtFardCNIC.Text = this.txtFardCNIC.Text + "-";
            //    txtFardCNIC.SelectionStart = 6;
            //}
            //if (this.txtFardCNIC.Text.Length == 13)
            //{
            //    this.txtFardCNIC.Text = this.txtFardCNIC.Text + "-";
            //    txtFardCNIC.SelectionStart = 14;
            //}
        }

        #endregion

        #region Record Insertion members

        private void SaveFard()
        {
              try
                {
             ArrayList Labels = new ArrayList();
            Labels.Add(lblf1.Text);
            Labels.Add(lblf2.Text);
            Labels.Add(lblf4.Text);
            Labels.Add(lblf6.Text);
            Labels.Add(lblf8.Text);
            ArrayList collection = new ArrayList();
            string empty = null;
            collection.Add(this.txtFardName.Text.ToString());
            collection.Add(this.cboFardParent.SelectedIndex.ToString());
            collection.Add(this.cboFardGender.Text.ToString());
            collection.Add(this.cboFardRelation.Text.ToString());
            collection.Add(this.cboFardCaste.SelectedIndex.ToString());
          
            for (int i = 0; i <= collection.Count - 1; i++)
            {
                if (Convert.ToString(collection[i]) == string.Empty || Convert.ToString(collection[i]) == "0")
                {
                    empty += "," + Labels[i].ToString();
                }
            }

            if (empty == null)
            {
                if (txtFardCNIC.Text.Trim().Length == 13 || txtFardCNIC.Text.Trim().Length == 0 || txtFardCNIC.Text.Trim().Length == 1)
                {
                    string PersonId = txtFardId.Text.ToString();
                    string PersonTypeId = "1";
                    string FamilyId = txtFardFamilyId.Text.ToString();
                    string QoamId = cboFardCaste.SelectedValue.ToString();
                    string FamilyHead;
                    if (rbFamilyHead.Checked) { FamilyHead = "1"; } else { FamilyHead = "0"; }
                    string ParentId = cboFardParent.SelectedValue.ToString();
                    string FamilyLevel = ObjPerson.GetFamilyLevel(ParentId);
                    string PersonName = txtFardName.Text.ToString();
                    string Relation = cboFardRelation.Text.ToString();
                    string FatherName = cboFardParent.Text.ToString();
                   string MotherName =cbMother.DataSource!=null? cbMother.SelectedValue.ToString():"0";
                    string Gender = cboFardGender.Text.ToString();
                    string mozaId = cboFardMauza.SelectedValue.ToString();
                    string CNIC = txtFardCNIC.Text.Length==13 ? txtFardCNIC.Text.ToString() : "NULL";
                    string DOB = "NULL";
                    string Sakna = txtfardSakna.Text.ToString();
                    string Address = txtFardCompleteAddress.Text.ToString();
                    string FardDied;
                    if (rbFardDeadYes.Checked)
                    { FardDied = "1"; }
                    else
                    { FardDied = "0"; }
                    string PersonCategoryId = cboFardAfradType.SelectedIndex > 0 ? cboFardAfradType.SelectedValue.ToString() : "1901";
                    string UsrId = UsersManagments.UserId.ToString();
                    if (PersonId == "-1")
                    {
                        string R_CNIC = Pr.CheckCNICAlreadyEntered(PersonTypeId, mozaId, CNIC);
                        if (R_CNIC != "-1")
                        {
                            MessageBox.Show(" اس موضع میں شناختی کارڈ نمبر" + CNIC + " کا اندراج پہلے سے ہو چکا ہے۔ ", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    string SerialNoFard = txtSrNoChild.Text != "" ? txtSrNoChild.Text : "1";
                    string LastId = ObjPerson.SaveInteqalAfradRegister(PersonId, PersonTypeId, FamilyId, QoamId, FamilyHead, FamilyLevel, ParentId, PersonName, Relation, FatherName, MotherName, Gender, mozaId, CNIC, DOB, Sakna, Address, FardDied, PersonCategoryId, UsrId, PersonFamilyStatus, UsersManagments.UserName.ToString(), SerialNoFard);
                    txtFardId.Text = LastId;
                    //MessageBox.Show("فرد کا اندراج ہوگیاہے۔");
                    btnSaveFard.Enabled = true;
                    this.ClearFormControls(grpFardTop);
                    txtFardId.Text = "-1";
                    cboFardRelation.SelectedIndex = 0;
                    cboFardGender.SelectedIndex = 0;
                }
               else
               {
                   MessageBox.Show(empty + "-  درست شناختی کارڈ نمبر کا اندراج کریں", " شناختی کارڈ نمبر  ", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
                
            }
            else
            {
               
                MessageBox.Show(empty + "- کا اندراج کریں", "   ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message);
              }
        }
        #endregion

        #region GridView CellClick Events

        private void grdFardForFH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdFardForFH.CurrentRow.Cells["colChooseFardFH"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdFardForFH.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells["colChooseFardFH"].Value = 1;
                            grpFardTop.Enabled = true;
                            grpFardMiddle.Enabled = true;
                            btnDelFard.Enabled = true;
                            btnSaveFard.Enabled = true;
                            grpFardBottom.Enabled = true;
                         fillFardParent(cboFardMauza.SelectedValue.ToString(), row.Cells["FmailyNo"].Value.ToString());
                         txtFardFamilyId.Text = row.Cells["FmailyNo"].Value.ToString();
                         cboFardCaste.SelectedValue = row.Cells["QoamId"].Value.ToString();
                         FillFardGrid(txtFardFamilyId.Text.ToString(), cboFardMauza.SelectedValue.ToString());
                         int count = grdFard.Rows.Count;
                         txtSrNoChild.Text = (count + 1).ToString();
                        }
                        else
                        {
                            row.Cells["colChooseFardFH"].Value = 0;
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

        private void grdFard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
    			{
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdFard.CurrentRow.Cells["colChooseFard"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdFard.SelectedRows.Count > 0)
                    {

                        btnDelFard.Enabled = true;
                        btnSaveFard.Enabled = true;

                        if (row.Selected)
                        {
                            row.Cells["colChooseFard"].Value = 1;
                            txtFardId.Text = row.Cells["PersonId"].Value.ToString();
                            txtFardFamilyId.Text = row.Cells["FmailyNo"].Value.ToString();
                            txtFardParentId.Text = row.Cells["ParentId"].Value.ToString();
                            txtFardName.Text = row.Cells["PersonName"].Value.ToString();
                            cboFardRelation.Text = row.Cells["Relation"].Value.ToString();
                            cboFardParent.SelectedValue = row.Cells["ParentId"].Value.ToString();
                            if (cbMother.DataSource != null)
                            {
                                if(cbMother.Items.Count > 1)
                                        cbMother.SelectedValue = row.Cells["MotherName"].Value != null ? row.Cells["MotherName"].Value.ToString() : "0";
                            }
                            cboFardGender.Text = row.Cells["Gender"].Value.ToString();
                            fillPersonCatergoryFard(UsersManagments._Tehsilid.ToString());
                            cboFardAfradType.SelectedValue = row.Cells["PersonCategoryId"].Value.ToString();
                            txtFardCNIC.Text = row.Cells["CNIC"].Value.ToString();
                            string IsFardDead = row.Cells["PersonDied"].Value.ToString();
                            if (IsFardDead == "True") { rbFardDeadYes.Checked = true; } else { rbFardDeadNo.Checked = true; }
                            fillPersonQoamFard(UsersManagments._Tehsilid.ToString());
                            cboFardCaste.SelectedValue = row.Cells["QoamId"].Value.ToString();
                            txtfardSakna.Text = row.Cells["Sakna"].Value.ToString();
                            txtFardCompleteAddress.Text = row.Cells["Address"].Value.ToString();
                            txtSrNoChild.Text = row.Cells["SeqNo"].Value.ToString();
                            //cboFardMauza.SelectedValue = row.Cells["MozaId"].Value.ToString();
                        }
                        else
                        {
                            row.Cells["colChooseFard"].Value = 0;
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

        #region Record Deletion Event


        private void btnDelFard_Click(object sender, EventArgs e)
        {
            try
            {
            if (txtFardId.Text != "-1")
            {
                if (MessageBox.Show("کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    ObjPerson.DeleteAfradRegister(txtFardId.Text.ToString());
                    MessageBox.Show("ریکارڈ حذف ہوگیا ہے۔");
                    FillFardGrid(txtFardFamilyId.Text.ToString(), cboFardMauza.SelectedValue.ToString());
                    btnSaveFard.Enabled = true;
                    btnDelFard.Enabled = true;
                    //this.ClearFormControls(grpFamilyHeadTop);
                    this.ClearFormControls(grpFardTop);
                    txtFardId.Text = "-1";
                    int count = grdFard.Rows.Count;
                    txtSrNoChild.Text = (count + 1).ToString();
                    cboFardCaste.SelectedValue = grdFardForFH.SelectedRows[0].Cells["QoamId"].Value;
                }
                else
                {
                    btnSaveFard.Enabled = true;
                    btnDelFard.Enabled = true;
                    this.ClearFormControls(grpFardTop);
                    txtFardId.Text = "-1";
                }
            }
            else
            {
                MessageBox.Show("فرد لوڈ کریں", "فرد لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        #endregion

        #endregion

        #region Code for Tab Murtahin

        #region GridView Fill Methods

        public void FillRahinGrid(string mozaId, string personName)
        {
            try
    			{
            dtMurtahin = ObjPerson.GetMozaAfradListAllTypes(mozaId,  personName );
            if (dtMurtahin != null)
            {
                bsR.DataSource = dtMurtahin;
                grdRahin.DataSource = bsR;
                grdRahin.DataSource = dtMurtahin;
                if (dtMurtahin != null)
                {
                    //grdRahin.DataSource = dtMurtahin;
                    grdRahin.Columns["PersonId"].Visible = false;
                    grdRahin.Columns["QoamId"].Visible = false;
                    grdRahin.Columns["FmailyNo"].Visible = false;
                    grdRahin.Columns["familyType"].Visible = false;
                    grdRahin.Columns["familytypeId"].Visible = false;
                    grdRahin.Columns["FamilyName"].HeaderText = "نام";
                }
            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchRahin_TextChanged(object sender, EventArgs e)
        {
            if (bsR != null)
            {
                bsR.Filter = string.Format("FamilyName LIKE '%{0}%' ", txtSearchRahin.Text);
            }
        }

        public void FillMurtahinGrid(string mozId, string familyStatusId, string personName)
        {
            try
            {
            dtMurtahin = ObjPerson.GetMozaAfradListByTypeId(mozId, familyStatusId, personName);
            if (dtMurtahin != null)
            {
                grdMurtahin.DataSource = dtMurtahin;
                grdMurtahin.Columns["PersonId"].Visible = false;
                grdMurtahin.Columns["PersonTypeId"].Visible = false;
                grdMurtahin.Columns["FamilyHead"].Visible = false;
                grdMurtahin.Columns["FamilyLevel"].Visible = false;
                grdMurtahin.Columns["ParentId"].Visible = false;
                grdMurtahin.Columns["Relation"].Visible = false;
                grdMurtahin.Columns["Fathername"].Visible = false;
                grdMurtahin.Columns["MotherName"].Visible = false;
                grdMurtahin.Columns["Gender"].Visible = false;
                grdMurtahin.Columns["PersonDied"].Visible = false;
                grdMurtahin.Columns["PersonCategoryId"].Visible = false;
                grdMurtahin.Columns["MozaId"].Visible = false;
                grdMurtahin.Columns["CNIC"].Visible = false;
                grdMurtahin.Columns["DateOfBirth"].Visible = false;
                grdMurtahin.Columns["Sakna"].Visible = false;
                grdMurtahin.Columns["Age"].Visible = false;
                grdMurtahin.Columns["QoamId"].Visible = false;
                grdMurtahin.Columns["FmailyNo"].Visible = false;
                grdMurtahin.Columns["familyType"].Visible = false;
                grdMurtahin.Columns["familytypeId"].Visible = false;
                grdMurtahin.Columns["PersonName"].Visible = false;
                grdMurtahin.Columns["Address"].Visible = false;
                grdMurtahin.Columns["FamilyName"].HeaderText = "نام";
                grdMurtahin.Columns["FamilyNo"].Visible = false;

            }
            }
 			catch (Exception ex)
             {
               MessageBox.Show(ex.Message);
             }
        }

        #endregion

        #region GidView Click Members

        private void grdRahin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
    			{
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdRahin.CurrentRow.Cells["colChooseRahin"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdRahin.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells["colChooseRahin"].Value = 1;
                            //grpMurtahinTop.Enabled = true;
                            //grpMurtahinMiddle.Enabled = true;
                            //grpMurtahinBottom.Enabled = true;
                            btnNewMurtahin.Enabled = true;
                            txtMurtahinParentId.Text = row.Cells["PersonId"].Value.ToString();
                        }
                        else
                        {
                            row.Cells["colChooseRahin"].Value = 0;
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

        private void grdMurtahin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == grdMurtahin.CurrentRow.Cells["colChooseMurtahin"].ColumnIndex)
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (grdMurtahin.SelectedRows.Count > 0)
                    {
                        btnDelMurtahin.Enabled = true;
                        btnSaveMurtahin.Enabled = true;
                        if (row.Selected)
                        {
                            row.Cells["colChooseMurtahin"].Value = 1;
                            txtMurtahinId.Text = row.Cells["PersonId"].Value.ToString();
                            txtMurtahinFamilyId.Text = row.Cells["FmailyNo"].Value.ToString();
                            txtMurtahinParentId.Text = row.Cells["ParentId"].Value.ToString();
                            txtMurtahinName.Text = row.Cells["PersonName"].Value.ToString();
                           // txtSearchRahin.Text = row.Cells["PersonName"].Value.ToString();
                            //cboFardMauza.SelectedValue = row.Cells["MozaId"].Value.ToString();
                            for (int i = 0; i <= grdRahin.Rows.Count; i++)
                            {
                                if (grdRahin.Rows[i].Cells["PersonId"].Value.ToString() == row.Cells["PersonId"].Value.ToString())
                                {
                                    FillRahinGrid(cboFardMauza.SelectedValue.ToString(), row.Cells["PersonName"].Value.ToString() );
                                    grdRahin.Rows[i].Cells["colChooseRahin"].Value = 1;
                                    grdRahin.Rows[i].Selected = true;
                                    grdRahin.CurrentCell = grdRahin.Rows[i].Cells["colChooseRahin"];
                                    break;
                                }
                            }
                         
                     
                        }
                        else
                        {
                            row.Cells["colChooseMurtahin"].Value = 0;
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

        #region Record Insertion members

        private void SaveMurtahin()
        {
            if (txtMurtahinParentId.Text != "-1")
            {
                if (txtMurtahinName.Text != "")
                {
                    try
                    {
                        string PersonId = txtMurtahinId.Text.ToString();
                        string PersonTypeId = "1";
                        string FamilyId = txtMurtahinFamilyId.Text.ToString();
                        string QoamId = "NULL";
                        string FamilyHead = "0";
                        string ParentId = txtMurtahinParentId.Text.ToString();
                        string FamilyLevel = "0";
                        string PersonName = txtMurtahinName.Text.ToString();
                        string Relation = "";
                        string FatherName = "";
                        string MotherName = "";
                        string Gender = "NULL";
                        string mozaId = cboFardMauza.SelectedValue.ToString();
                        string CNIC = "NULL";
                        string DOB = "NULL";
                        string Sakna = "NULL";
                        string Address = "NULL";
                        string PersonDied = "0";
                        string PersonCategoryId = "NULL";
                        string UsrId = UsersManagments.UserId.ToString();
                        string LastId = ObjPerson.SaveInteqalAfradRegister(PersonId, PersonTypeId, FamilyId, QoamId, FamilyHead, FamilyLevel, ParentId, PersonName, Relation, FatherName, MotherName, Gender, mozaId, CNIC, DOB, Sakna, Address, PersonDied, PersonCategoryId, UsrId, PersonFamilyStatus, UsersManagments.UserName.ToString(), "1");
                        txtMurtahinId.Text = LastId;
                        MessageBox.Show("مرتہن کا اندراج ہوگیاہے۔");
                        btnSaveMurtahin.Enabled = true;
                        this.ClearFormControls(grpMurtahinTop);
                        txtMurtahinId.Text = "-1";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("مرتہن کا اندراج کیجئیے۔");
                    txtMurtahinName.Focus();
                }
            }
            else
            {
                MessageBox.Show("راہن کاانتخاب کیجئیے۔");
                grdRahin.Focus();
            }
        }

        #endregion

        #region Button Click Events

        private void btnNewMurtahin_Click(object sender, EventArgs e)
        {
            btnSaveMurtahin.Enabled = true;
            btnDelMurtahin.Enabled = true;
            txtMurtahinId.Text = "-1";
        }
        private void btnSaveMurtahin_Click(object sender, EventArgs e)
        {
            SaveMurtahin();
            FillMurtahinGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus, "");
        }

        #endregion

        #region Record Delete Events

        private void btnDelMurtahin_Click(object sender, EventArgs e)
        {
            try
    			{
            if (txtMurtahinId.Text != "-1")
            {
                if (MessageBox.Show("کیا آپ حذف کرنا چاہتے ہیں:::::", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {

                    ObjPerson.DeleteAfradRegister(txtMurtahinId.Text.ToString());
                    MessageBox.Show("ریکارڈ حذف ہوگیا ہے۔");
                    FillMurtahinGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus, "");
                    txtMurtahinName.Clear();
                    btnSaveMurtahin.Enabled = true;
                    btnDelMurtahin.Enabled = true;
                    txtMurtahinId.Text = "-1";

                }
                else
                {
                    btnSaveMurtahin.Enabled = true;
                    btnDelMurtahin.Enabled = true;
                    txtMurtahinName.Clear();
                    txtMurtahinId.Text = "-1";
                }
            }
            else
            {
                MessageBox.Show("مرتہن لوڈ کریں", "مرتہن لوڈ کریں", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        #endregion

        private void txtFamilyHeadId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFHParentId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFHFamilyId_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnafradlist_Click(object sender, EventArgs e)
        {
            frmSearchinAfradRegister frmSearch = new frmSearchinAfradRegister();
            if (cboFardMauza.SelectedIndex > 0)
            {
                frmSearch.FormClosed -= new FormClosedEventHandler(frmSearch_FormClosed);
                frmSearch.FormClosed += new FormClosedEventHandler(frmSearch_FormClosed);
                frmSearch.mozaid = MozaId.ToString();

                frmSearch.ShowDialog();
            }
            else
            {
               // MessageBox.Show("موصع ");
            }
        }
        private void frmSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearch frmSearch = sender as frmSearch;
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtFHFamilyId.Text.Length > 5)
            {
                System.Diagnostics.Process.Start("http://175.107.63.31:9181/Shajra/Window_app_shajra/" + txtFHFamilyId.Text);
            }
        }


        private void btnLoadShajra_Click(object sender, EventArgs e)
        {
            ObjPerson.UpdateShajraStructure(MozaId, FamilyId);
        }

        struct NodeData
        {
            public bool Parent; public long PersonId; public long FamilyID; public String PersonName; public long ParentId; public int FamilyNo;
            public NodeData(bool cParent, long cPersonId, long cFamilyID, String sPersonName, long cParentId, int cFamilyNo)
            {
                Parent = cParent; PersonId = cPersonId; FamilyID = cFamilyID; PersonName = sPersonName; FamilyNo = cFamilyNo; ParentId = cParentId;
            }
        }
        NodeData SelectedFardNodeData, SelectedFamilyNodeData;

        private DataTable dtAfradRegister = null;
        private void btrnFardSearch_Click(object sender, EventArgs e)
        {
            treeViewCurrentFamily.Nodes.Clear();
            treeViewAllFamilies.Nodes.Clear();
            txtFardSearch.Text = txtFardSearch.Text.Trim();
            String searchi = txtFardSearch.Text.Replace(" ", "").Replace(" ", "");


            dtAfradRegister = ObjPerson.getAfradRegister(txtFardSearch.Text, MozaId);
            //treeViewCurrentFamily.DataSource = dtAfradRegister;
            int iMozaId = -1;
            Int32.TryParse(MozaId, out iMozaId);

            dtAfradRegister.AsEnumerable()
                .Where(Row => Row.Field<int>("PersonFamilyStatusId") == 1 && Row.Field<int>("MozaId") == iMozaId)
                .OrderBy(x => x.Field<string>("PersonName"))
                // .Select(datarow => new { key = datarow.Field<int>("FamilyId"), val = datarow.Field<string>("PersonName") })
                .Select(datarow => new NodeData(true, datarow.Field<long>("PersonId"), datarow.Field<long>("FamilyId"), datarow.Field<String>("PersonName"), datarow.Field<long>("ParentId"), datarow.Field<int>("FamilyNo")))
                //.GroupBy(p => p.key).ToDictionary(t => t.Key, t => t.First().val.ToString());
                .GroupBy(p => p.PersonId).ToDictionary(t => t.Key, t => t.First())
                .ToList().TrueForAll(
                x =>
                {
                    TreeNode n = new TreeNode();
                    n.Text = x.Value.PersonName;
                    n.Tag = x.Value;
                    treeViewAllFamilies.Nodes.Add(n);
                    return true;
                }
                );

            dtAfradRegister.AsEnumerable()
        .Where(Row => Row.Field<int>("PersonFamilyStatusId") == 1 && Row.Field<int>("MozaId") == iMozaId)
        .OrderBy(x => x.Field<string>("PersonName"))
        .Select(datarow => new NodeData(true, datarow.Field<long>("PersonId"), datarow.Field<long>("FamilyId"), datarow.Field<String>("PersonName"), datarow.Field<long>("ParentId"), datarow.Field<int>("FamilyNo")))
                //.GroupBy(p => p.key).ToDictionary(t => t.Key, t => t.First().val.ToString());
        .GroupBy(p => p.FamilyID).ToDictionary(t => t.Key, t => t.First())
        .ToList().TrueForAll(
        x =>
        {//bool Parent; int PersonId;int FamilyID; String PersonName
            TreeNode n = new TreeNode();
            n.Text = x.Value.PersonName;
            n.Tag = x.Value;
            treeViewCurrentFamily.Nodes.Add(n);
            bool NoFardFound = true;
            dtAfradRegister.AsEnumerable()
                            .Where(Row1 => Row1.Field<int>("PersonFamilyStatusId") == 2 && Row1.Field<int>("MozaId") == iMozaId && Row1.Field<long>("FamilyId") == x.Key && (searchi == "" || Row1.Field<string>("PersonName").Replace(" ", "").Replace(" ", "").Contains(searchi)))
                            .OrderBy(x1 => x1.Field<string>("PersonName"))
                //  .Select(datarow1 => new { PersonId = datarow1.Field<int>("PersonId"), PersonName = datarow1.Field<string>("PersonName") , FamilyId = datarow1.Field<string>("FamilyId") })
                            .Select(datarow1 => new NodeData(false, datarow1.Field<long>("PersonId"), datarow1.Field<long>("FamilyId"), datarow1.Field<String>("PersonName"), datarow1.Field<long>("ParentId"), datarow1.Field<int>("FamilyNo")))
                            .ToDictionary(t1 => t1.PersonId, t1 => t1)
                            .ToList().TrueForAll(y =>
                            {
                                TreeNode nc = new TreeNode();
                                nc.Text = y.Value.PersonName;
                                nc.Tag = y.Value;
                                try { n.Nodes.Add(nc); }
                                catch (Exception) { }
                                NoFardFound = false;
                                return true;

                            });
            if (NoFardFound) treeViewCurrentFamily.Nodes.Remove(n);
            return true;
        }
        );
            //treeViewCurrentFamily.Nodes.Add();


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeViewCurrentFamily_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void treeViewCurrentFamily_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            NodeData data = (NodeData)e.Node.Tag;
            if (data.Parent)
            {
                e.Cancel = true;
                return;
            }
            SelectedFardNodeData = data;

            txtSelFard.Text = data.PersonName;
            txtSelFardId.Text = data.PersonId.ToString();
            txtSelFamilyId.Text = data.FamilyNo.ToString();
            NodeData parentNodedata = (NodeData)e.Node.Parent.Tag;
            txtSelFamily.Text = parentNodedata.PersonName;

        }

        private void btnRectifyFamily_Click(object sender, EventArgs e)
        {
            if (SelectedFardNodeData.PersonName == null || SelectedFamilyNodeData.PersonName == null)
            {
                MessageBox.Show("براے مھربانی فرد اور خاندان کا انتخاب کریں");
                return;
            }
            else
            {
                ObjPerson.ChangeFamily(SelectedFardNodeData.PersonId, SelectedFamilyNodeData.FamilyID, SelectedFamilyNodeData.FamilyNo, SelectedFamilyNodeData.ParentId, MozaId);
                txtFardSearch.Text = SelectedFardNodeData.PersonName;
                btrnFardSearch_Click(null, null);
            }

        }

        private void treeViewAllFamilies_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            NodeData data = (NodeData)e.Node.Tag;
            SelectedFamilyNodeData = data;
            txtFamilyRectification.Text = data.PersonName;
            txtFamilyRectificationId.Text = data.FamilyNo.ToString();
        }

        private void cboFardParent_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbMother.DataSource = null;
            objauto.FillCombo("Proc_Get_Fard_Zowja_List " + cboFardParent.SelectedValue.ToString(), cbMother, "PersonName", "PersonId");
            if (cbMother.DataSource != null)
                cbMother.SelectedValue = "0";
        }

        private void txtSearchFamilyFardName_TextChanged(object sender, EventArgs e)
        {
            if (bsFamilyFard != null)
            {
                bsFamilyFard.Filter = string.Format("PersonName LIKE '%{0}%' ", txtSearchFamilyFardName.Text);
            }
        }

        private void btnSearchH_Click(object sender, EventArgs e)
        {
            if(txtSearchFH.Text.Trim().Length > 1)
            FillFamilyHeadGrid(cboFardMauza.SelectedValue.ToString(), PersonFamilyStatus, txtSearchFHFard.Text.Trim());
            else
                MessageBox.Show("براے مھربانی سربراہ کے نام کا اندراج کریں");
        }

        private void btnSearchHP_Click(object sender, EventArgs e)
        {
            if(txtSearchFHFard.Text.Trim().Length > 1)
                FillFardForFHGrid(cboFardMauza.SelectedValue.ToString(), "1", txtSearchFHFard.Text.Trim());
            else
                MessageBox.Show("براے مھربانی سربراہ کے نام کا اندراج کریں");
        }

        private void btnSearchM_Click(object sender, EventArgs e)
        {
            if(txtSearchRahin.Text.Trim().Length > 1)
                FillRahinGrid(cboFardMauza.SelectedValue.ToString(), txtSearchRahin.Text.Trim());
            else
                MessageBox.Show("براے مھربانی راہن کے نام کا اندراج کریں");
        }

        private void txtSearchFamilyFardCNIC_TextChanged(object sender, EventArgs e)
        {
            if (bsFamilyFard != null)
            {
                bsFamilyFard.Filter = string.Format("CNIC LIKE '%{0}%' ", Convert.ToInt64(txtSearchFamilyFardCNIC.Text));
            }
        }
    }
}
