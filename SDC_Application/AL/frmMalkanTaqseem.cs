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
    public partial class frmMalkanTaqseem : Form
    {
        #region Class Variables
    
        //ClientServiceClient client = new ClientServiceClient();
        //List<Proc_Get_IntiqalMin_MalkanList_Result> malikan = new List<Proc_Get_IntiqalMin_MalkanList_Result>();
        //List<Proc_Get_IntiqalMin_MalkanList_Result> malikanSel = new List<Proc_Get_IntiqalMin_MalkanList_Result>();
        //List<Proc_Get_Moza_Families_List_Result> MozaFamilies = new List<Proc_Get_Moza_Families_List_Result>();
        //List<Proc_Get_FamilyPersons_List_Result> FamilyPersons = new List<Proc_Get_FamilyPersons_List_Result>();
        //int UserId = Classes.CurrentUser.UserId;
       
        Intiqal inteq = new Intiqal();
        DataTable malikan = new DataTable();
        DataTable malikanSel = new DataTable();
        DataTable MozaFamilies = new DataTable();
        DataTable FamilyPersons = new DataTable();
        DataTable dtkj = new DataTable();
        UserMangement currentUsers = new UserMangement();
        AutoComplete auto = new AutoComplete();
        CommanFunctions cfn = new CommanFunctions();
        Misal misal = new Misal();
        LanguageConverter Lang = new LanguageConverter();
        RhzSDC rhz = new RhzSDC();
        public string KhataId { get; set; }
        public string KhewatGroupId { get; set; }
        public string MozaId { get; set; }
        public string RegisterId { get; set; }
        public string IntiqalId { get; set; }
        public string KhewatTypeId { get; set; }
        public string IntiqalMinGroupId { get; set; }
        public string MalikanType { get; set; }
        public string MinGroupNo { get; set; }
        public string OldKhatooniId { get; set; }
        public string KhatooniRecId { get; set; }
        public string MushteriFareeqId { get; set; }
        public string RHZ_ChangeId { get; set; }
        public string KhataHissa { get; set; }
        public string Khata_Area { get; set; }


        #endregion

        #region Form Load Event
        /// <summary>
        /// default constructor
        /// </summary>
        public frmMalkanTaqseem()
        {
            InitializeComponent();
           // this.GetKhatajatDataSource.DataSource = client.GetAllKhatasByMozaIdByRegisterId(this.MozaId, this.RegisterId);
            GridViewMalikanSelect.Columns.Add("CompleteName", "مالک کا نام");
            GridViewMalikanSelect.Columns["CompleteName"].DisplayIndex = 1;
            GridViewMalikanSelect.Columns["colRemove"].DisplayIndex = 0;
            GridViewMalikanSelect.Columns.Add("PersonId", "PersonId");
            GridViewMalikanSelect.Columns["PersonId"].Visible =false;
            GridViewMalikanSelect.Columns.Add("Kanal", "مالک کا نام");
            GridViewMalikanSelect.Columns["Kanal"].Visible = false;
            GridViewMalikanSelect.Columns.Add("marla", "مالک کا نام");
            GridViewMalikanSelect.Columns["marla"].Visible = false;
            GridViewMalikanSelect.Columns.Add("sarsai", "مالک کا نام");
            GridViewMalikanSelect.Columns["sarsai"].Visible = false;
            GridViewMalikanSelect.Columns.Add("Feet", "مالک کا نام");
            GridViewMalikanSelect.Columns["Feet"].Visible = false;
            GridViewMalikanSelect.Columns.Add("Area", "مالک کا نام");
            GridViewMalikanSelect.Columns["Area"].Visible = false;
            GridViewMalikanSelect.Columns.Add("KhewatTypeId", "مالک کا نام");
            GridViewMalikanSelect.Columns["KhewatTypeId"].Visible = false;
            GridViewMalikanSelect.Columns.Add("KhewatType", "مالک کا نام");
            GridViewMalikanSelect.Columns["KhewatType"].Visible = false;
            GridViewMalikanSelect.Columns.Add("PersonType", "مالک کا نام");
            GridViewMalikanSelect.Columns["PersonType"].Visible = false;
            GridViewMalikanSelect.Columns.Add("KhewatGroupFareeqId", "مالک کا نام");
            GridViewMalikanSelect.Columns["KhewatGroupFareeqId"].Visible = false;
            GridViewMalikanSelect.Columns.Add("FardAreaPart", "حصہ تبدیلی کے لئے حصہ کلک کریں");
            GridViewMalikanSelect.Columns.Add("KhewatGroupId", "مالک کا نام");
            GridViewMalikanSelect.Columns["KhewatGroupId"].Visible = false;
            GridViewMalikanSelect.Columns.Add("RegisterHqDKhataId", "مالک کا نام");
            GridViewMalikanSelect.Columns["RegisterHqDKhataId"].Visible = false;
        }
        /// <summary>
        /// select owners and add it to selected list
        /// </summary>
        /// <param name="Khataid">Khatta id</param>
        /// <param name="kgroupid">khatta group id</param>
        /// <param name="mozaid">Moza id</param>
        /// <param name="regid">Register Number</param>
        public frmMalkanTaqseem(string Khataid, string kgroupid, string mozaid, string regid)
        {
            InitializeComponent();
            this.KhataId = Khataid;
            this.KhewatGroupId = kgroupid;
            this.MozaId = mozaid;
            this.RegisterId = regid;
            //this.GetKhatajatDataSource.DataSource = client.GetKhattajaatByUser(CurrentUser.MozaId, CurrentUser.UserId).ToList(); //client.GetAllKhatasByMozaIdByRegisterId(this.MozaId, this.RegisterId);

        }

        #endregion

        #region Populate Moza Family List

        private void FillMozaFamaliesList()
        {
            auto.FillCombo("Proc_Get_Moza_Families_List " + UsersManagments._Tehsilid.ToString() + "," + MozaId, cbFamily, "FamilyName", "FmailyNo");
            //MozaFamilies = client.GetMozaFamilyListByMozaId(CurrentUser.MozaId).ToList();
            //Proc_Get_Moza_Families_List_Result SelFamily = new Proc_Get_Moza_Families_List_Result();
            //SelFamily.FamilyName = " - فیملی کا انتخاب کریں - ";
            //SelFamily.FmailyNo = 0;
            //MozaFamilies.Insert(0, SelFamily);
            //this.cbFamily.DataSource = MozaFamilies;
            //this.cbFamily.DisplayMember = "FamilyName";
            //this.cbFamily.ValueMember = "FmailyNo";
        }


        #endregion

        #region Drop Down List Khatajat selection change event
        /// <summary>
        /// calls method for filling khatta malkan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbKhatas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillKhewatMalikanByKhataId();
            this.txtKhewatGroupId.Text = this.KhewatGroupId;
            this.txtKhewatKhataId.Text = this.KhataId;
        }

        #endregion

        #region Fill Khewat Malikan By Khatta Id
        /// <summary>
        /// Used for filling malikaan record of a specific khata into gridview khata malikan
        /// </summary>
        private void FillKhewatMalikanByKhataId()
        {
            try
            {
                //string KhataId = this.KhataId != "" ? this.KhataId : "0";
                malikan = inteq.GetIntiqalKhataMalikanByKhataId(cbKhatas.SelectedValue.ToString()); //client.GetKhewatMalikanByKhataId(khataid).ToList();
                GridViewMalikan.DataSource = malikan;
                GridViewMalikan.Columns["personname"].HeaderText = "نام مالک"; 
                GridViewMalikan.Columns["PersonId"].Visible = false;
                GridViewMalikan.Columns["Farad_Kanal"].Visible = false;
                GridViewMalikan.Columns["Fard_Marla"].Visible = false;
                GridViewMalikan.Columns["Fard_Sarsai"].Visible = false;
                GridViewMalikan.Columns["Fard_Feet"].Visible = false;
                GridViewMalikan.Columns["Fard_Area"].Visible = false;
                GridViewMalikan.Columns["KhewatTypeId"].Visible = false;
                GridViewMalikan.Columns["KhewatType"].Visible = false;
                //GridViewMalikan.Columns["PersonType"].Visible = false;
                GridViewMalikan.Columns["KhewatGroupFareeqId"].Visible = false;
                GridViewMalikan.Columns["FardAreaPart"].Visible = false;
                GridViewMalikan.Columns["KhewatGroupId"].Visible = false;
                GridViewMalikan.Columns["RegisterHqDKhataId"].Visible = false;
                GridViewMalikan.Columns["KhataNo"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Button Select Malikan Click Event
        /// <summary>
        /// Call method for getting selected malkan list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {

            GridViewMalikanSelect.Rows.Clear();
            gridfill();
            if (GridViewMalikanSelect.Rows.Count > 0)
            {
                this.btnSave.Enabled = true;
            }
                       
                    }
        #region Fill MalikanSelected

        public void gridfill()
        {
            if (checkBoxSearchByFamily.Checked)
            {
                foreach (DataGridViewRow row in this.GridViewMalikan.Rows)
                {

                    if (row.Cells[0].Value != null)
                    {
                        if ((Boolean)row.Cells[0].Value)
                        {
                            int rowcount = GridViewMalikanSelect.Rows.Count;

                            GridViewMalikanSelect.Rows.Add();
                            GridViewMalikanSelect.Rows[rowcount].Cells["PersonId"].Value = row.Cells["PersonId"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["CompleteName"].Value = row.Cells["FamilyName"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["FardAreaPart"].Value = "0";
                        }
                    }

                }
            }
            else
            {
                foreach (DataGridViewRow row in this.GridViewMalikan.Rows)
                {

                    if (row.Cells[0].Value != null)
                    {
                        if ((Boolean)row.Cells[0].Value)
                        {
                            int rowcount = GridViewMalikanSelect.Rows.Count;

                            GridViewMalikanSelect.Rows.Add();
                            GridViewMalikanSelect.Rows[rowcount].Cells["PersonId"].Value = row.Cells["PersonId"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["CompleteName"].Value = row.Cells["personname"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["Kanal"].Value = row.Cells["Farad_Kanal"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["marla"].Value = row.Cells["Fard_Marla"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["sarsai"].Value = row.Cells["Fard_Sarsai"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["Feet"].Value = row.Cells["Fard_Feet"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["Area"].Value = row.Cells["Fard_Area"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["KhewatTypeId"].Value = row.Cells["KhewatTypeId"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["KhewatType"].Value = row.Cells["KhewatType"].Value.ToString();
                            //GridViewMalikanSelect.Rows[rowcount].Cells["PersonType"].Value = row.Cells["PersonType"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["KhewatGroupFareeqId"].Value = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["FardAreaPart"].Value = row.Cells["FardAreaPart"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["KhewatGroupId"].Value = row.Cells["KhewatGroupId"].Value.ToString();
                            GridViewMalikanSelect.Rows[rowcount].Cells["RegisterHqDKhataId"].Value = row.Cells["RegisterHqDKhataId"].Value.ToString();

                        }
                    }

                }
            }

            removeFromGridDuplicate(GridViewMalikanSelect);
        }
        public void removeFromGridDuplicate(DataGridView grv)
        {
            for (int currentRow = 0; currentRow < grv.Rows.Count - 1; currentRow++)
            {
                DataGridViewRow rowToCompare = grv.Rows[currentRow];

                for (int otherRow = currentRow + 1; otherRow < grv.Rows.Count; otherRow++)
                {
                    DataGridViewRow row = grv.Rows[otherRow];

                    bool duplicateRow = true;

                    for (int cellIndex = 0; cellIndex < row.Cells.Count; cellIndex++)
                    {
                        if (!rowToCompare.Cells["PersonId"].Value.Equals(row.Cells["PersonId"].Value))
                        {
                            duplicateRow = false;
                            break;
                        }
                    }

                    if (duplicateRow)
                    {
                        grv.Rows.Remove(row);
                        otherRow--;
                    }
                }
            }

        
        }

        //GridViewFillMalikanSelect();
        #endregion

        #endregion

        #region Funtion Get Selected Malikan from Prevoius Khata malikans
        /// <summary>
        /// select malkan from the previous khatta and a list is made to use in new khatta
        /// </summary>
        public void getMalikanSelected()
        {
            //this.malikanSel.Clear();
            //foreach (DataGridViewRow row in this.GridViewMalikan.Rows)
            //{
            //    if (row.Cells[0].Value != null)
            //    {
            //        if ((Boolean)row.Cells[0].Value)
            //            this.malikanSel.Add(this.malikan.Where(p => p.PersonId.ToString() == (row.Cells[7].Value.ToString()) && p.FardAreaPart.ToString() == row.Cells[2].Value.ToString()).FirstOrDefault());

            //    }
            //}
            //this.GetMInMalkanSelectedDataSource.DataSource = null;
            //this.GetMInMalkanSelectedDataSource.DataSource = this.malikanSel;
        }
        #endregion

        #region Save Khewat Group Freqein
        /// <summary>
        /// Method Saves Malikaan entry of a khata.
        /// </summary>
        private void SaveKhewatGroupFreqein()
        {
            foreach (DataGridViewRow row in GridViewMalikanSelect.Rows)
            {
                string personid = row.Cells["PersonId"].Value.ToString();
                
                    string khewatgroupfreeqid = "-1";
                    float fardareapart = row.Cells["FardAreaPart"].Value != null ? float.Parse(row.Cells["FardAreaPart"].Value.ToString()) : 0;
                    string[] KhataArea=Khata_Area.Split('-');
                    string[] Area = cfn.CalculatedAreaFromHisa(float.Parse(KhataHissa), fardareapart,Convert.ToInt32(KhataArea[0]),Convert.ToInt32( KhataArea[1]),float.Parse(KhataArea[2]), float.Parse(KhataArea[3]));
                    string fardkanal = Area[0]!=null?Area[0] : "0";
                    string fardmarla = Area[1] != null ? Area[1] : "0"; ;
                    string fardsarsai = Area[2] != null ? Area[2] : "0";
                    string AreaPart = fardareapart.ToString();
                    string fardfeet = Area[3] != null ? Area[3] : "0";
                    //string khewattypeid = row.Cells["KhewatTypeId"].Value != null ? row.Cells["KhewatTypeId"].Value.ToString() : "1";
                    //int khewatkhataid = Convert.ToInt32(this.txtKhewatKhataId.Text.ToString());
                    //this.OldKhatooniId = this.OldKhatooniId != null ? this.OldKhatooniId : "0";
                    //this.KhatooniRecId = this.KhatooniRecId != null ? this.KhatooniRecId : "0";
                    //this.MushteriFareeqId = this.MushteriFareeqId != null ? this.MushteriFareeqId : "0";
                    string last =rhz.WEB_SP_INSERT_KhewatGroupFareeqeinWithRecStatus("-1","0", personid, "0", "0", "0", "0", "0", KhewatTypeId ,KhataId, UsersManagments.UserId.ToString(), UsersManagments.UserName, "0", "Data Entry", "0");
                    khewatgroupfreeqid = last;
                    string retVal = rhz.WEB_SP_INSERT_KhewatGroupFareeqeinEdit("-1", khewatgroupfreeqid, "0", personid, personid, "0", fardareapart.ToString(), "0", fardkanal, "0", fardmarla, "0", fardsarsai, "0", fardfeet, KhewatTypeId, KhewatTypeId, KhataId, UsersManagments.UserId.ToString(), UsersManagments.UserName, "0", "0", "Data Etnry", "0", RHZ_ChangeId, "Insert");
                    this.txtKhewatFreeqainGroupId.Text = last;
                    if (last != string.Empty)
                    {
                    }
                
            }
            MessageBox.Show("مالکان محفوظ ہوگئے", "من گروپ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //frmIntiqalTaqseem frmIntiqalTaqseem = new frmIntiqalTaqseem();
            //frmIntiqalTaqseem.FormClosed -= new FormClosedEventHandler(frmIntiqalTaqseem_FormClosed);
            //frmIntiqalTaqseem.FormClosed += new FormClosedEventHandler(frmIntiqalTaqseem_FormClosed);
            //frmIntiqalTaqseem.IntiqalId = IntiqalId;
            //frmIntiqalTaqseem.IntiqalMinGroupId = IntiqalMinGroupId;
            //frmIntiqalTaqseem.MinGroupNo = MinGroupNo;
            //frmIntiqalTaqseem.ShowDialog();
            this.Close();
        }
        //public void frmIntiqalTaqseem_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    frmIntiqalTaqseem frmIntiqalTaqseem = sender as frmIntiqalTaqseem;
        //}
        /// <summary>
        /// saves khewat group farqain as khewat malkan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            KhataId=KhataId !=null?KhataId:"0";
            if (KhataId.Length>5 && GridViewMalikanSelect.Rows.Count >0)
            {
                float kulHissa = 0;
                foreach (DataGridViewRow row in GridViewMalikanSelect.Rows)
                {
                    kulHissa = kulHissa + float.Parse(row.Cells["FardAreaPart"].Value.ToString().Length > 0 ? row.Cells["FardAreaPart"].Value.ToString() : "0");
                }
                if (float.Parse(KhataHissa) < Math.Round( kulHissa, 0))
                {
                    if (DialogResult.Yes == MessageBox.Show("آپ کا درج کردہ مالکان حصے ، کھاتہ کے کل حصے سے زیادہ ہیں۔حصے میں " +(float.Parse(KhataHissa)- Math.Round( kulHissa, 0)).ToString() + "   فرق ہے۔ کیا آپ یہ ریکارڈ محفوظ کرنا چاہتے ہیں؟", "حصے کم زیادہ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        SaveKhewatGroupFreqein();
                    }
                }
                else
                    SaveKhewatGroupFreqein();
            }
            else
            {
                MessageBox.Show("کھاتہ اور مالک کا انتخاب کریں", "محفوظ نہیں ہو سکتا", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        #endregion

        #region Gridview Malikan all cell click event
        /// <summary>
        /// make selection of malkna on basis of check box provided in the gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        public void GridViewFillMalikanSelect()
        {

            try
            {
                DataTable dtMain = new DataTable();
                //copy the schema of source table
                DataTable dtClone = dtMain.Clone();
                foreach (DataGridViewRow gv in GridViewMalikan.SelectedRows)
                {
                    string personId = gv.Cells["PersonId"].Value.ToString();
                    if (personId != null)
                    {
                        //get only the rows you want
                        DataRow[] results = malikan.Select("PersonId=" + personId + "");
                        //populate new destination table
                        foreach (DataRow dr in results)
                        {
                            dtClone.ImportRow(dr);
                        }
                    }
                    GridViewMalikanSelect.DataSource = dtClone;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GridViewMalikan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        #endregion

        #region Button Check All Click event

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GridViewMalikan.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells[0].Value = !(Boolean)(row.Cells[0].Value!=null?row.Cells[0].Value:false);
                }
                btnSelect.Enabled = true;
            }
        }

        #endregion

        #region Unused Code

        private void checkBoxSearchByFamily_CheckedChanged(object sender, EventArgs e)
        {
            GridViewMalikan.DataSource = null;
            this.cbFamily.Visible = this.checkBoxSearchByFamily.Checked;
            if (this.checkBoxSearchByFamily.Checked)
            {
                //GridViewMalikan.DataSource = null;
                this.FillMozaFamaliesList();
            }
        }

        private void cbFamily_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
            try
            {
                //string KhataId = this.KhataId != "" ? this.KhataId : "0";
                this.FamilyPersons =  inteq.GetMozaFamilyListByFamilyId(cbFamily.SelectedValue.ToString());
                GridViewMalikan.DataSource = FamilyPersons;
                GridViewMalikan.Columns["FamilyName"].HeaderText = "نام مالک";
                GridViewMalikan.Columns["PersonId"].Visible = false;
                GridViewMalikan.Columns["familyType"].Visible = false;
                GridViewMalikan.Columns["familytypeId"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Fill Khata Dropdown

        public void Fill_Khata_DropDown()
        {
            try
            {

                dtkj = misal.GetAllKhatajatByMoza(Convert.ToInt32(MozaId));
                DataRow inteqKj = dtkj.NewRow();
                inteqKj["RegisterHqDKhataId"] = "0";
                inteqKj["KhataNo"] = " - کھاتہ نمبر کا انتخاب کرِیں - ";
                dtkj.Rows.InsertAt(inteqKj, 0);
                cbKhatas.DataSource = dtkj;
                cbKhatas.DisplayMember = "KhataNo";
                cbKhatas.ValueMember = "RegisterHqDKhataId";
                cbKhatas.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region KeyPress Event

        private void cbFamily_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar((Keys.Back)))
            {

            }
            else
            {
                e.KeyChar = Lang.UrduChar(Convert.ToChar(e.KeyChar));
            }
        }

        #endregion

        private void frmTestMalkanSelc_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);
            Fill_Khata_DropDown();
            //this.MalikanType = "RHZ";
            //FillKhewatMalikanByKhataId();
            //this.txtKhewatGroupId.Text = this.KhewatGroupId;
            //this.txtKhewatKhataId.Text = this.KhataId;
            //this.txtIntiqalMinGroupID.Text=this.IntiqalMinGroupId;
            //this.txtIntiqalId.Text = this.IntiqalId;
            btnSelect.Enabled = true;
        }

        #region Change Events

        private void rbMushteryan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMushteryan.Checked)
            {
                this.MalikanType = "Mushtryan";
                FillKhewatMalikanByKhataId();
                ClearSelection_ChangeRadioButton();

            }
        }
        public void ClearSelection_ChangeRadioButton()
        {
                  if (GridViewMalikanSelect.Rows.Count > 0)
                   {
                    for (int i = 0; i <= GridViewMalikanSelect.Rows.Count - 1; i++)
                    {
                        GridViewMalikanSelect.Rows[i].Selected = true;
                       
                    }
                    foreach (DataGridViewRow item in this.GridViewMalikanSelect.SelectedRows)
                    {
                        GridViewMalikanSelect.Rows.RemoveAt(item.Index);
                    }

                }
}
        private void rbBayan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBayan.Checked)
            {
                this.MalikanType = "Bayan";
                FillKhewatMalikanByKhataId();
            }
        }

        private void rbBayanMushteryan_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBayanMushteryan.Checked)
            {
                this.MalikanType = "BayanMushtryan";
                FillKhewatMalikanByKhataId();
            }
        }

        private void rbRHZ_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRHZ.Checked)
            {
                this.MalikanType = "RHZ";
                FillKhewatMalikanByKhataId();
            }
        }

        #endregion

        private void GridViewMalikan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            gridfill();
        }

        private void GridViewMalikanSelect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GridViewMalikanSelect.Columns["colRemove"].Index)
            {
                GridViewMalikanSelect.CurrentRow.Cells["colRemove"].Value = true;
                if ((Boolean)GridViewMalikanSelect.CurrentRow.Cells["colRemove"].Value)
                {
                    int index = Convert.ToInt32(GridViewMalikanSelect.CurrentRow.Index.ToString());
                    GridViewMalikanSelect.Rows.RemoveAt(index);
                }
            }
        }

        private void GridViewMalikanSelect_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridView dg =sender as DataGridView;
            if (e.ColumnIndex == dg.Columns["FardAreaPart"].Index) // 1 should be your column index
            {
                float i;

                if (!float.TryParse(Convert.ToString(e.FormattedValue), out i))
                {
                    e.Cancel = true;
                    MessageBox.Show( "صرف ہندسہ اور اعشاریہ لکھے جا سکتے ہے۔");
                }
                else
                {
                    // the input is numeric 
                }
            }
        }

    }
}
