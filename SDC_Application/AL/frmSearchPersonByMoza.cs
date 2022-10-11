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

namespace SDC_Application.AL
{
    public partial class frmSearchPersonByMoza : Form
    {
        #region Class Variables       
        Search searchPerson = new Search();      
        Malikan_n_Khattajat mnk = new Malikan_n_Khattajat();
        public string PVID { get; set; }
        public string PVDetailId { get; set; }
        public int NoOfPages { get; set; }
        public int TotalPages { get; set; }
        public string TokenId { get; set; }
        public string PersonKhattaDetail { get; set; }
        public string FPGid 
        { get; set; }
        public string FardMalikDetail { get; set; }
        public string PVPersonId { get; set; }
        public string MozaId { get; set; }
        public bool isPersonalRecord { get; set; }
        DataTable malikan = new DataTable();
        
        //public DateTime MyProperty { get; set; }

        LanguageManager.LanguageConverter lang = new LanguageManager.LanguageConverter();

        #endregion

        #region Default Contructor

        public frmSearchPersonByMoza()
        {
            InitializeComponent();

        }

        #endregion

        #region Form Load Event

        private void frmSearchPersonByMoza_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

           // 
            this.setToolTip();
            this.radKhatajat.Checked = true;
            if (this.txtMalikName.Text == string.Empty)
            {
                this.txtMalikName.Text = "Null";
                FillMalikanGrid();
                this.txtMalikName.Text = "";               
            }       
            DataTable FardPersonGroup = new DataTable();
            FardPersonGroup = mnk.GetFardPersonGroupDetail(TokenId);
            if (FardPersonGroup.Rows.Count > 0)
            {
                this.FPGid = FardPersonGroup.Rows[0]["FPGId"].ToString();
                GetMalikKhattasPersonDetails(FPGid);
                GetSavedKhasraDetails(FPGid);
                if (gridviewMalikan.Rows.Count > 0)
                {
                 
                }
            }
            int savedKhataNo = GridViewKhattajat_for_Token.Rows.Count;
            if (FPGid != null)
            {
                LoadSaveMalakan(FPGid);
            }
            else
            {
                LoadSaveMalakan("Null");
                
            }
            if (savedKhataNo == 0 && GridViewSaveMalikanName.Rows.Count > 0) //if malikan saveed and khata not save , then during loading load for saving
            {
                LoadSaveKhatajat(MozaId, FPGid);
            }
            else
            {
                LoadSaveKhatajat("Null", "Null");
            }
            
            if (GridViewKhattajat_for_Token.Rows.Count > 0)
            {
                btnSaveKhasraJat.Enabled = false;
            }
            if (grdShowSaveKhasraNo.Rows.Count > 0)
            {
                btnSave.Enabled = false;
            }

            
        }

        #endregion

        #region Load Fard Person Group Details on Token Id

        private void LoadFardGroupPersonDetails(string TokenId)
        {

        }

        #endregion

        #region Load Saved LoadSaveKhatajat && LaodSaveKhasraJat for Inserting intoDB

        private void LoadSaveKhatajat(string MozaId,string FPGid)
        {
            gridViewMalakan_For_Token.Refresh();
            if (radKhanaMalkiat.Checked == true)
            {
                malikan = mnk.GetFardPersonsKhatajat(MozaId, FPGid);
            }
            else
            {
               malikan=mnk.GetFardPersonsKhatajat_Khankashat(MozaId, FPGid);
            }
            if (radKhanaMalkiat.Checked)
            {
                this.gridViewMalakan_For_Token.DataSource = malikan;
                this.gridViewMalakan_For_Token.Columns["KhataNo"].HeaderText = "کھاتہ نمبرز";
                this.gridViewMalakan_For_Token.Columns["TotalParts"].HeaderText = "کل حصے";
                this.gridViewMalakan_For_Token.Columns["HissaDifference"].HeaderText = "حصص فرق";
                this.gridViewMalakan_For_Token.Columns["RecordLockedCon"].HeaderText = "حالت لاک";
                this.gridViewMalakan_For_Token.Columns["RecordLockedDetails"].HeaderText = "تفصیل لاک";
                this.gridViewMalakan_For_Token.Columns["RecordLockingDate"].HeaderText = "تاریخ لاک";
                this.gridViewMalakan_For_Token.Columns["RegisterHaqdaranId"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["RecordLocked"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["chk2"].Visible = true;
                this.gridViewMalakan_For_Token.Columns["RegisterHqDKhataId"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["TotalParts"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["Khata_Area"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["sarsai"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["Marla"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["Kanal"].Visible = false;
                //this.gridViewMalakan_For_Token.Columns["KhasraNo"].Visible=false;
                //this.gridViewMalakan_For_Token.Columns["Area"].Visible=false;
                //this.gridViewMalakan_For_Token.Columns["KhatoniNo"].Visible = false;
                gridViewMalakan_For_Token.ColumnHeadersDefaultCellStyle.Font = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
            }
            else if (RadKhanKashat.Checked)
            {
                this.gridViewMalakan_For_Token.DataSource = malikan;
                this.gridViewMalakan_For_Token.Columns["KhataNo"].HeaderText = "کھاتہ نمبرز";
                this.gridViewMalakan_For_Token.Columns["TotalParts"].HeaderText = "کل حصے";
                this.gridViewMalakan_For_Token.Columns["RegisterHaqdaranId"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["chk2"].Visible = true;
                this.gridViewMalakan_For_Token.Columns["RegisterHqDKhataId"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["TotalParts"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["Khata_Area"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["sarsai"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["Marla"].Visible = false;
                this.gridViewMalakan_For_Token.Columns["Kanal"].Visible = false;
                //this.gridViewMalakan_For_Token.Columns["KhasraNo"].Visible=false;
                //this.gridViewMalakan_For_Token.Columns["Area"].Visible=false;
                //this.gridViewMalakan_For_Token.Columns["KhatoniNo"].Visible = false;
                gridViewMalakan_For_Token.ColumnHeadersDefaultCellStyle.Font = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
            }
         
        }
        private void LoadSavedKhasra(string MozaId, string FPGid)
        {
            
            DataTable khasrajat = new DataTable();
            khasrajat = mnk.GetFardPersonsKhasraJajat(MozaId, FPGid);
            this.grdKhasraJat.DataSource = khasrajat;
            this.grdKhasraJat.Columns["chkKhasra"].DisplayIndex = 0;
            this.grdKhasraJat.Columns["KhataNo"].DisplayIndex = 1;
            this.grdKhasraJat.Columns["KhassraNo"].DisplayIndex = 2;
            this.grdKhasraJat.Columns["KhatooniNo"].DisplayIndex = 3;
            this.grdKhasraJat.Columns["Area"].DisplayIndex = 4;
            this.grdKhasraJat.Columns["KhataNo"].HeaderText = "کھاتہ نمبرز";
            this.grdKhasraJat.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
            this.grdKhasraJat.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
            this.grdKhasraJat.Columns["Area"].HeaderText = "کل رقبہ";
            this.grdKhasraJat.Columns["RegisterHqDKhataId"].Visible = false;
            this.grdKhasraJat.Columns["KhatooniId"].Visible = false;
            this.grdKhasraJat.Columns["Khassraid"].Visible = false;
            grdKhasraJat.ColumnHeadersDefaultCellStyle.Font = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
                    }

        #endregion

        #region Load Saved LoadSaveMalakan Aftersaveing Malikan Names

        private void LoadSaveMalakan(string fpgid)
        {
                 DataTable Khattass=new DataTable();
               //this.PVPersonId=row.Cells["PVPersonRecId"].Value.ToString();
                 Khattass = mnk.GetFardMalkanKFardPersonsDetail(fpgid);              
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                //col.HeaderText = "انتخاب کریں";
                //col.TrueValue = 1;
                //col.FalseValue = 0;
                //col.IndeterminateValue = 2;
                //col.FillWeight = 25;
                //col.Selected = false;
                //col.Name = "chk";
                ////col.CellType=chk;
                //this.GridViewKhattajat.Columns.Add(col);

                this.GridViewSaveMalikanName.DataSource = Khattass;
                this.GridViewSaveMalikanName.Columns["DeleteMalikName"].DisplayIndex = 2;
                this.GridViewSaveMalikanName.Columns["CompleteName"].DisplayIndex = 1;
                this.GridViewSaveMalikanName.Columns["CompleteName"].HeaderText = "نام مالکان";
                this.GridViewSaveMalikanName.Columns["PVPersonRecId"].Visible = false;
                this.GridViewSaveMalikanName.Columns["TehsilId"].Visible = false;
                this.GridViewSaveMalikanName.Columns["PVPersonId"].Visible = false;
                this.GridViewSaveMalikanName.Columns["PVPersonSeqNo"].Visible = false;
                this.GridViewSaveMalikanName.Columns["FPGId"].Visible = false;
                this.GridViewSaveMalikanName.Columns["PVPersonKhataNos"].Visible = false;
                GridViewSaveMalikanName.ColumnHeadersDefaultCellStyle.Font = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
                //DataGridView g = sender as DataGridView;


        }

        #endregion

        #region Set Tool Tip for the controls

        private void setToolTip()
        {
            toolTipSearchMalik.SetToolTip(btnFind, "مالک تلاش کریں");
            toolTipSearchMalik.SetToolTip(btnCheckAll, "تمام منتخب کریں");
            toolTipSearchMalik.SetToolTip(btnSave, " انتخاب کردہ مالک اور کھاتہ جات محفوظ کریں");
            toolTipSearchMalik.SetToolTip(btnShowKhattaReport, "فرد کے صفحات کی تعداد دیکھئیے");
        }

        #endregion

        #region Search Button Click Event

        private void btnFind_Click(object sender, EventArgs e)
        {
            string call_proce = null;
            try
            {
                if (radKhanaMalkiat.Checked == true)
                {
                    call_proce = "Malkiat";
                }
                else
                {
                    call_proce = "Khanakashat";
                }
                this.FillMalikanGrid();
                this.btnSave.Enabled = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fill Searched Afrad Grid View

        private void FillMalikanGrid()
        {
            gridviewMalikan.DataSource = null;         
            DataTable SearchedAfradLis = new DataTable();
            
            // SearchedAfradLis = searchPerson.GetSearchedAfradList(this.MozaId, txtMalikName.Text);
             SearchedAfradLis = searchPerson.GetSearchedAfradListSelf(this.MozaId, txtMalikName.Text, txtFatherName.Text.Trim());

           
            this.gridviewMalikan.DataSource = SearchedAfradLis;
            this.gridviewMalikan.Columns["PersonFullName"].HeaderText = "نام مالک";
            this.gridviewMalikan.Columns["FamilyId"].Visible = false;
            this.gridviewMalikan.Columns["ParentId"].Visible = false;
            this.gridviewMalikan.Columns["PersonId"].Visible = false;
            gridviewMalikan.ColumnHeadersDefaultCellStyle.Font = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
            // this.gridviewMalikan.Columns[""].HeaderText = "";
        }

        #endregion

        #region GridView Malkan Cell Content Click Event

        private void gridviewMalikan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    if (e.ColumnIndex != 0 || e.RowIndex < 0)
                        return;

                    DataGridView g = sender as DataGridView;
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (row.Index == e.RowIndex)
                        {
                           
                                row.Cells["chk"].Value = Convert.ToInt32(row.Cells["chk"].Value) == 1 ? 0 : 1;
                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //try
                //{
                //    if (e.ColumnIndex != 0 || e.RowIndex < 0)
                //        return;

                //    DataGridView g = sender as DataGridView;
                //    foreach (DataGridViewRow row in g.Rows)
                //    {
                //        if (row.Index == e.RowIndex)
                //        {
                //            row.Cells["chk"].Value = 1;
                //        }
                //        else
                //        {
                //            row.Cells["chk"].Value = 0;
                //        }
                //    }
                //    if (Convert.ToBoolean(g.SelectedRows[0].Cells["chk"].Value) == true)
                //    {
                //        string familyId = g.SelectedRows[0].Cells["FamilyId"].Value.ToString();
                //        string PersonId = g.SelectedRows[0].Cells["PersonId"].Value.ToString();
                //        this.txtPersonId.Text = PersonId;
                // this.FillPersonFamilyGridView(familyId);
                //        this.FillGridViewMalikKhattas(this.MozaId, PersonId);
                //    }
                //    else
                //    {
                //        this.GridViewFamily.DataSource = null;
                //    }


                //}
                //catch (Exception ex)
                //{

                //    MessageBox.Show(ex.Message);
                //}
            }
        }
        #endregion

        #region Fill Malik Khatta Gridview

        private void FillGridViewMalikKhattas(string MozaId, String PersonId)
        {
            try
            {
                this.GridViewSaveMalikanName.DataSource = null;
                if (GridViewSaveMalikanName.Columns.Count > 0)
                {
                    GridViewSaveMalikanName.Columns.Remove("chk");
                }
                DataTable PersonKhattas = new DataTable();
                PersonKhattas = searchPerson.GetMalikKhattas(PersonId, MozaId);
                // Add Checkbox column
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
                col.HeaderText = "انتخاب کریں";
                col.TrueValue = 1;
                col.FalseValue = 0;
                col.IndeterminateValue = 2;
                col.FillWeight = 25;
                col.Selected = false;
                col.Name = "chk";
                this.GridViewSaveMalikanName.Columns.Add(col);               
                this.GridViewSaveMalikanName.DataSource = PersonKhattas;
                this.GridViewSaveMalikanName.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                this.GridViewSaveMalikanName.Columns["TotalParts"].HeaderText = "کل حصے";
                this.GridViewSaveMalikanName.Columns["Khata_Area"].HeaderText = "کل رقبہ";
                GridViewSaveMalikanName.Columns["RecordLockedCon"].HeaderText = "موجودہ حالت";
                GridViewSaveMalikanName.Columns["RecordLockedDetails"].HeaderText = "موجودہ حالت";
                GridViewSaveMalikanName.Columns["HissaDifference"].HeaderText = "حصص فرق";
                this.GridViewSaveMalikanName.Columns["RegisterHaqdaranId"].Visible = false;
                this.GridViewSaveMalikanName.Columns["RegisterHqDKhataId"].Visible = false;
                this.GridViewSaveMalikanName.Columns["Kanal"].Visible = false;
                this.GridViewSaveMalikanName.Columns["Marla"].Visible = false;
                this.GridViewSaveMalikanName.Columns["sarsai"].Visible = false;
                GridViewSaveMalikanName.Columns["RecordLocked"].Visible = false;
                GridViewSaveMalikanName.Columns["RecordLockingDate"].Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        #region Get KhataNos and KhasraNo AfterSaving Khatajats and KhasraJats

        public void GetMalikKhattasPersonDetails(string FGID)
        {
                DataTable PersonKhattas = new DataTable();
                PersonKhattas = searchPerson.GetMalikKhattasPersonDetails(FGID);
                this.GridViewKhattajat_for_Token.DataSource = PersonKhattas;
                DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
               
                this.GridViewKhattajat_for_Token.Columns["KhataNo"].DisplayIndex = 1;
                this.GridViewKhattajat_for_Token.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                this.GridViewKhattajat_for_Token.Columns["PVKhataRecId"].Visible = false;
                this.GridViewKhattajat_for_Token.Columns["TehsilId"].Visible = false;
                this.GridViewKhattajat_for_Token.Columns["PVPersonRecId"].Visible = false;
                this.GridViewKhattajat_for_Token.Columns["PVKhataSeqNo"].Visible = false;
                this.GridViewKhattajat_for_Token.Columns["PVKhataId"].Visible = false;              
                this.GridViewKhattajat_for_Token.Columns["TotalParts"].Visible = false;               
                this.GridViewKhattajat_for_Token.Columns["Khata_Total_Area"].Visible = false;
                GridViewKhattajat_for_Token.ColumnHeadersDefaultCellStyle.Font = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
    }

        public void GetSavedKhasraDetails(string FGID)
        {
            DataTable KhasraDetails = new DataTable();
            KhasraDetails = mnk.GetSavedKhasraDetails(FGID);
            this.grdShowSaveKhasraNo.DataSource = KhasraDetails;
            this.grdShowSaveKhasraNo.Columns["KhassraNo"].DisplayIndex = 0;
            this.grdShowSaveKhasraNo.Columns["KhatooniNo"].DisplayIndex = 2;
            this.grdShowSaveKhasraNo.Columns["KhataNo"].DisplayIndex = 1;
            this.grdShowSaveKhasraNo.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
            this.grdShowSaveKhasraNo.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
            this.grdShowSaveKhasraNo.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
            this.grdShowSaveKhasraNo.Columns["FPGId"].Visible = false;
            this.grdShowSaveKhasraNo.Columns["PVKhassraRecId"].Visible = false;
            this.grdShowSaveKhasraNo.Columns["TokenId"].Visible = false;
            this.grdShowSaveKhasraNo.Columns["KhataId"].Visible = false;
           
            this.grdShowSaveKhasraNo.Columns["KhatooniId"].Visible = false;
            
            this.grdShowSaveKhasraNo.Columns["PVKhassraSeqNo"].Visible = false;
            this.grdShowSaveKhasraNo.Columns["PVKhassraId"].Visible = false;
            grdShowSaveKhasraNo.ColumnHeadersDefaultCellStyle.Font = new Font("Alvi Nastaleeq", 14, GraphicsUnit.Point);
        }

        #endregion

        #endregion

        #region Fill Family Grid View

        private void FillPersonFamilyGridView(string familyId)
        {
            try
            {
                this.GridViewFamily.DataSource = searchPerson.GetPersonFamilyMembers(familyId);
                this.GridViewFamily.Columns["FamilyName"].HeaderText = "نام فرد";
                this.GridViewFamily.Columns["PersonId"].Visible = false;
                this.GridViewFamily.Columns["familyType"].Visible = false;
                this.GridViewFamily.Columns["familytypeId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        #endregion

        #region Button Save All Khatas Click Event

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool duplication = false;
            bool isAllow = true; // Temporarily prevention of Record saving in case of Lock is diables
            //foreach (DataGridViewRow row in gridViewMalakan_For_Token.Rows)
            //{
            //    if (Convert.ToInt32(row.Cells[0].Value) == 1)
            //    {
            //        bool isLocked=Convert.ToBoolean(row.Cells["RecordLocked"]);
            //        if (isPersonalRecord)
            //        {
            //            isAllow = true;
            //        }
            //        else if (isLocked && !isPersonalRecord)
            //        {
            //            isAllow = false;
            //                break;
            //        }
            //    }
            //}
            try
            {
                if (isAllow)
                {
                    foreach (DataGridViewRow row in gridViewMalakan_For_Token.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) == 1)
                        {
                            if (GridViewKhattajat_for_Token.Rows.Count > 0)
                            {
                                for (int k = 0; k < GridViewKhattajat_for_Token.Rows.Count; k++)
                                {
                                    string allredaysaved = GridViewKhattajat_for_Token.Rows[k].Cells["PVKhataId"].Value.ToString();
                                    string NewtobeSaved = row.Cells["RegisterHqDKhataId"].Value.ToString();
                                    if (allredaysaved == NewtobeSaved)
                                    {
                                        duplication = false;
                                        break;
                                    }
                                    else
                                    {

                                        duplication = true;
                                    }
                                }
                                if (duplication)
                                {

                                    string khattaId = row.Cells["RegisterHqDKhataId"].Value.ToString();
                                    string lastId = mnk.InsertUpdateFardKhattasDetail("-1", UsersManagments._Tehsilid.ToString(), FPGid, TokenId, "0", khattaId, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                                }
                            }
                            else
                            {

                                string khattaId = row.Cells["RegisterHqDKhataId"].Value.ToString();
                                string lastId = mnk.InsertUpdateFardKhattasDetail("-1", UsersManagments._Tehsilid.ToString(), FPGid, TokenId, "0", khattaId, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                            }
                        }
                    }

                    GetMalikKhattasPersonDetails(FPGid);
                    chkViewFamilyList.Checked = false;
                    btnSaveKhasraJat.Enabled = false;
                }
                else
                {
                    MessageBox.Show("لاک شدہ کھاتہ اس فرد میں شامل نہیں کر سکتے۔", "فرد کھاتہ لاک شدہ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
}
        private void btnSaveKhasraJat_Click(object sender, EventArgs e)
        {
            bool duplication = false;

            try
            {

                foreach (DataGridViewRow row in grdKhasraJat.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value) == 1)
                    {
                        if (GridViewKhattajat_for_Token.Rows.Count > 0)
                        {
                            for (int k = 0; k < grdShowSaveKhasraNo.Rows.Count; k++)
                            {
                                string allredaysaved = grdShowSaveKhasraNo.Rows[k].Cells["KhataId"].Value.ToString();
                                string NewtobeSaved = row.Cells["RegisterHqDKhataId"].Value.ToString();
                                if (allredaysaved == NewtobeSaved)
                                {
                                    duplication = false;
                                    break;
                                }
                                else
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication)
                            {
                                string KhasraId = row.Cells["Khassraid"].Value.ToString();
                                string PVKhassraRecId = mnk.WEB_SP_INSERT_SDC_FardKhassrasDetail("-1", FPGid, TokenId, UsersManagments._Tehsilid.ToString(), "0", KhasraId, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                            }
                        }
                        else
                        {

                            string KhasraId = row.Cells["Khassraid"].Value.ToString();
                            string PVKhassraRecId = mnk.WEB_SP_INSERT_SDC_FardKhassrasDetail("-1", FPGid, TokenId, UsersManagments._Tehsilid.ToString(), "0", KhasraId, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                        }
                    }
                }

                GetSavedKhasraDetails(FPGid);
                chkViewFamilyList.Checked = false;
                btnSave.Enabled = false;
                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
        

        #endregion

        #region Get Fard Pages

        private void GetFardPages()
        {
            frmGetNoOfPagesForFard pagesForFard = new frmGetNoOfPagesForFard();
            pagesForFard.FormClosed -= new FormClosedEventHandler(pagesForFard_FormClosed);
            pagesForFard.FormClosed += new FormClosedEventHandler(pagesForFard_FormClosed);
            pagesForFard.ShowDialog();
        }

        void pagesForFard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGetNoOfPagesForFard p=sender as frmGetNoOfPagesForFard;
            this.NoOfPages = p.NoOfPages;
        }

        #endregion

        #region Check Khatta Selection

        private int CheckSelectedKhattas()
        {
            int sKhatta = 0;
            foreach (DataGridViewRow row in GridViewSaveMalikanName.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == 1)
                {

                    sKhatta = sKhatta + 1;
                }
            }
            return sKhatta;

        }

        #endregion

        #region Voucher malikan Save Method

        private string SaveVoucherMalikan(string FPGId)
        {
            string lastId = "";
            try
            {
                int seqNo = 1;
                string PersonId = this.txtPersonId.Text;
                string khattaNos = this.GetKhattaNoCantcatString();
                lastId = mnk.InsertUpdateFardPersonDetail("-1", FPGId, UsersManagments._Tehsilid.ToString(), this.TokenId, PersonId, seqNo.ToString(), khattaNos, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return lastId;
        }

        #endregion

        #region Button Check All Click Event

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            // Check All Record in Khatta 
            foreach (DataGridViewRow row in GridViewSaveMalikanName.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells[0].Value = !(Boolean)(row.Cells[0].Value != null ? row.Cells[0].Value : false);
                }
                //bt.Enabled = true;
            }
        }

        #endregion

        #region Get Khatta Nos Cancatinated String

        private string GetKhattaNoCantcatString()
        {
            string khattaNos = "";
            foreach (DataGridViewRow row in GridViewSaveMalikanName.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == 1)
                {
                    khattaNos = khattaNos + row.Cells["KhataNo"].Value.ToString() + ",";
                }
            }
            return khattaNos;
        }

        #endregion

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

        private void frmSearchPersonByMoza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.NoOfPages > 0)
            {

            }
            else if ((this.NoOfPages <= 0 || this.NoOfPages != null) || PersonKhattaDetail!=null)
            {
                this.GetFardPages();
            }
        }

        #region Select All Malikan Names Checkbox click
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (this.chkCheckAll.Checked)
            {
                // Check All Record in Khatta 
                foreach (DataGridViewRow row in this.gridviewMalikan.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.Cells[0].Value = true;
                    }
                    //bt.Enabled = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in gridviewMalikan.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.Cells[0].Value = false;
                    }
                    //bt.Enabled = true;
                }
            }
        }

        #endregion
        #region //Save Malikan Names and Khatas from Search Option
        private void btnSaveMalikan_Click(object sender, EventArgs e)
        {
            bool duplication = true;
            try
            {
                string NoOfPages = "0";
                if (FPGid == null)               {

                    FPGid = mnk.InsertUpdatePersonGroupDetail("-1", UsersManagments._Tehsilid.ToString(), NoOfPages.ToString(), "", this.TokenId, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                }
                for (int i = 0; i < gridviewMalikan.Rows.Count; i++)
                {
                    string PersonId = gridviewMalikan.Rows[i].Cells["PersonId"].Value.ToString();
                    string khattaNos = "Null";
                    int seqNo = i + 1;
                    if (Convert.ToInt32(gridviewMalikan.Rows[i].Cells["chk"].Value) == 1)
                    {
                        if (GridViewSaveMalikanName.Rows.Count > 0)
                        {
                            for (int k = 0; k < GridViewSaveMalikanName.Rows.Count; k++)
                            {
                                string allredaysaved = GridViewSaveMalikanName.Rows[k].Cells["PVPersonId"].Value.ToString();
                                string NewtobeSaved = gridviewMalikan.Rows[i].Cells["PersonId"].Value.ToString();
                                if (allredaysaved == NewtobeSaved)
                                {
                                    duplication = false;
                                    break;
                                }
                                else
                                {
                                    duplication = true;
                                }
                            }
                            if (duplication)
                            {
                               // duplication = true;
                                string lastId = mnk.InsertUpdateFardPersonDetail("-1", FPGid, UsersManagments._Tehsilid.ToString(), this.TokenId, PersonId, seqNo.ToString(), khattaNos, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                               // btnSave.Enabled = true;
                            }
                        }
                        else
                        {

                            string lastId = mnk.InsertUpdateFardPersonDetail("-1", FPGid, UsersManagments._Tehsilid.ToString(), this.TokenId, PersonId, seqNo.ToString(), khattaNos, UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                           // btnSave.Enabled = true;
                        }
                        gridviewMalikan.Rows[i].Cells["chk"].Value = false;
                    }
                   
                }
                LoadSaveMalakan(FPGid);//load save malikan names for Deletion Process

                if (radKhatajat.Checked)
                {
                    
                    LoadSaveKhatajat(MozaId, FPGid);//Load Khatajat for Inseration
                }
                else
                {
                    LoadSavedKhasra(MozaId, FPGid);//Load Khasrajat for Insertion
                }

                GetMalikKhattasPersonDetails(FPGid);

                chkCheckAll.Checked = false;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);
            }
           // btnSaveMalikan.Enabled = false;
        }
        #endregion
        #region GridviewMalakan KhataNo Save Check Box Events
        private void gridViewMalakan_For_Token_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    if (e.ColumnIndex != 0 || e.RowIndex < 0)
                        return;

                    DataGridView g = sender as DataGridView;
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        if (row.Index == e.RowIndex)
                        {
                            //if (!Convert.ToBoolean(g.Columns.Contains("RecordLocked") ? row.Cells["RecordLocked"].Value : false))
                            //{
                                row.Cells["chk2"].Value = Convert.ToInt32(row.Cells["chk2"].Value) == 1 ? 0 : 1;
                           // }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        #endregion
        #region Select All Khatas CheckBox Click
        private void chkViewFamilyList_Click(object sender, EventArgs e)
        {
            if (radKhatajat.Checked)
            {
                if (gridViewMalakan_For_Token.Rows.Count > 0)
                {
                    if (chkViewFamilyList.Checked)
                    {
                        foreach (DataGridViewRow row in gridViewMalakan_For_Token.Rows)
                        {

                            row.Cells["chk2"].Value = 1;
                        }
                    }

                    else
                    {
                        foreach (DataGridViewRow row in gridViewMalakan_For_Token.Rows)
                        {

                            row.Cells["chk2"].Value = 0;

                        }
                    }
                }
            }
            else
            {
                if (grdKhasraJat.Rows.Count > 0)
                {
                    if (chkViewFamilyList.Checked)
                    {
                        foreach (DataGridViewRow row in grdKhasraJat.Rows)
                        {

                            row.Cells["chkKhasra"].Value = 1;
                        }
                    }

                    else
                    {
                        foreach (DataGridViewRow row in grdKhasraJat.Rows)
                        {

                            row.Cells["chkKhasra"].Value = 0;

                        }
                    }
                }
            }
            }
        
        #endregion

        #region DeleteMalkan
        private void GridViewSaveMalikanName_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    DataGridView g = sender as DataGridView;
                    if (e.ColumnIndex == this.GridViewSaveMalikanName.CurrentRow.Cells["DeleteMalikName"].ColumnIndex)
                    {


                       this.GridViewSaveMalikanName.CurrentRow.Cells["chk1"].Value = 1;
                    
                            string personrecid = this.GridViewSaveMalikanName.CurrentRow.Cells["PVPersonRecId"].Value.ToString();


                            if (mnk.KhataJatDelete(FPGid, personrecid) != null)
                            {
                              //  btnSave.Enabled = false;
                                LoadSaveMalakan(FPGid);
                                LoadSaveKhatajat(MozaId, FPGid);
                                GetMalikKhattasPersonDetails(FPGid);
                                LoadSavedKhasra(MozaId, FPGid);
                                GetSavedKhasraDetails(FPGid);
                            }



                        //}

                    }

                   // DataGridView g = sender as DataGridView;
                    if (e.ColumnIndex == GridViewSaveMalikanName.CurrentRow.Cells["chk1"].ColumnIndex)
                    {
                        txtPPersonidAIT.Text = this.GridViewSaveMalikanName.CurrentRow.Cells["PVPersonId"].Value.ToString();
                        foreach (DataGridViewRow row in g.Rows)
                        {
                            if (GridViewSaveMalikanName.SelectedRows.Count > 0)
                            {
                               
                                if (row.Selected)
                                {
                                    row.Cells["chk1"].Value = 1;
                                   
                                }
                                else
                                {
                                    row.Cells["chk1"].Value = 0;
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message);

                }
            }
        }
        #endregion

        #region Delete all Save Malikan
        private void chkDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkDelete.Checked)
                {
                    if (GridViewSaveMalikanName.Rows.Count > 0)
                    {               
                        foreach (DataGridViewRow row in GridViewSaveMalikanName.Rows)
                        {

                            row.Cells["chk1"].Value = 1;
                        }
                        if (MessageBox.Show("کیا آپ تمام ریکارڈز حذف کرنا چاہتے ہیں", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            for (int i = 0; i <GridViewSaveMalikanName.Rows.Count; i++)
                            {
                                string personid = this.GridViewSaveMalikanName.Rows[i].Cells["PVPersonRecId"].Value.ToString();
                               // string savepersonid = this.GridViewSaveMalikanName.Rows[i].Cells["PVPersonId"].Value.ToString();
                                if (mnk.KhataJatDelete(FPGid, personid) != null)
                                {

                                }
                            }
                            chkDelete.Checked = false;
                          //  btnSave.Enabled = false;
                            LoadSaveMalakan(FPGid);
                            LoadSaveKhatajat(MozaId, FPGid);
                            GetMalikKhattasPersonDetails(FPGid);
                        }
                    }
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        #endregion

        #region Radio Buttons
        private void radKhasrajat_CheckedChanged(object sender, EventArgs e)
        {
            if (radKhasrajat.Checked)
            {
                chkViewFamilyList.Checked = false;
                this.gridViewMalakan_For_Token.Visible = false;
                grdKhasraJat.Visible = true;
                grdKhasraJat.Dock = DockStyle.Top;
                GridViewKhattajat_for_Token.Visible = false;
                grdShowSaveKhasraNo.Visible = true;
                grdShowSaveKhasraNo.Dock = DockStyle.Fill;
                LoadSavedKhasra(MozaId, FPGid);
                GetSavedKhasraDetails(FPGid);
                btnSave.Visible = false;
                btnSaveKhasraJat.Visible = true;
                groupBox4.Text = "خسراجات";
                groupBox5.Text = "محفوظشدہ خسراجات";
            }
            
        }

        private void radKhatajat_CheckedChanged(object sender, EventArgs e)
        {
            if (radKhatajat.Checked)
            {
                chkViewFamilyList.Checked = false;
                grdKhasraJat.Visible = false;
                this.gridViewMalakan_For_Token.Visible = true;              
                this.gridViewMalakan_For_Token.Dock = DockStyle.Top;
                GridViewKhattajat_for_Token.Visible = true;
                grdShowSaveKhasraNo.Visible = false;
                GridViewKhattajat_for_Token.Dock = DockStyle.Fill;
                if (FPGid!=null)
                {
                    this.LoadSaveKhatajat(MozaId, FPGid);
                }
                btnSave.Visible = true;
                btnSaveKhasraJat.Visible =false;
                groupBox4.Text = "کھاتہ جات";
                groupBox5.Text = "محفوظشدہ کھاتہ جات";
            }
        }
        #endregion



        private void grdKhasraJat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == grdKhasraJat.CurrentRow.Cells["chkKhasra"].ColumnIndex)
                {
                    if (Convert.ToInt32(grdKhasraJat.CurrentRow.Cells["chkKhasra"].Value) == 1)
                    {
                        grdKhasraJat.CurrentRow.Cells["chkKhasra"].Value = 0;
                    }
                    else
                    {
                        grdKhasraJat.CurrentRow.Cells["chkKhasra"].Value = 1;
                    }
                }
            }
        }

        private void btnShowKhattaReport_Click(object sender, EventArgs e)
        {
            FardMalikan_Report Fard = new FardMalikan_Report();
       
            Fard.FormClosed -= new FormClosedEventHandler(Fard_FormClosed);
            Fard.FormClosed += new FormClosedEventHandler(Fard_FormClosed);
            Fard.TokenID = TokenId;
            Fard.ShowDialog();
        }

        private void Fard_FormClosed(object sender, FormClosedEventArgs e)
        {
            FardMalikan_Report Populate = sender as FardMalikan_Report;
        }

        private void RadKhanKashat_CheckedChanged(object sender, EventArgs e)
        {
            if (RadKhanKashat.Checked == true)
            {
                LoadSaveKhatajat(MozaId, FPGid);
               
            }
            else
            {
                LoadSaveKhatajat(MozaId, FPGid);               
            }
        }

        private void btnOperatorReport_Click(object sender, EventArgs e)
        {
            if (FPGid != "-1" && FPGid != "0")
            {

                frmFardOperatorReport operatorReport = new frmFardOperatorReport();
                operatorReport.FPG_ID = this.FPGid;
                operatorReport.ShowDialog();
            }
            else
            {
                MessageBox.Show("پہلے فرد کے مالکان اور کھاتہ جات محفوظ کر لے۔");
            }
        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
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

        #region AIT Voucher

        private void btnLandTax_Click(object sender, EventArgs e)
        {
            if (this.txtPPersonidAIT.Text != null && this.txtPPersonidAIT.Text != "0" && this.txtPPersonidAIT.Text != "-1")
            {
                frmLandTax frmlandtax = new frmLandTax();
                frmlandtax.Personid = this.txtPPersonidAIT.Text;
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

        #endregion


    }
        }

       
    

