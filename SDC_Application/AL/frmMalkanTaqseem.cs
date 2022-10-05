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
        UserMangement currentUsers = new UserMangement();


        LanguageConverter Lang = new LanguageConverter();
        public string KhataId { get; set; }
        public string KhewatGroupId { get; set; }
        public string MozaId { get; set; }
        public string RegisterId { get; set; }
        public string IntiqalId { get; set; }
        public string MyProperty { get; set; }
        public string IntiqalMinGroupId { get; set; }
        public string MalikanType { get; set; }
        public string MinGroupNo { get; set; }
        public string OldKhatooniId { get; set; }
        public string KhatooniRecId { get; set; }
        public string MushteriFareeqId { get; set; }


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
            GridViewMalikanSelect.Columns.Add("FardAreaPart", "مالک کا نام");
            GridViewMalikanSelect.Columns["FardAreaPart"].Visible = false;
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
            //FillKhewatMalikanByKhataId();
            //this.txtKhewatGroupId.Text = this.KhewatGroupId;
            //this.txtKhewatKhataId.Text = this.KhataId;
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
                string KhataId = this.KhataId != "" ? this.KhataId : "0";
                malikan = inteq.GetIntiqalMinMalikanList(KhataId, this.MalikanType, this.IntiqalId); //client.GetKhewatMalikanByKhataId(khataid).ToList();
                GridViewMalikan.DataSource = malikan;
                GridViewMalikan.Columns["CompleteName"].HeaderText = "نام مالک"; 
                GridViewMalikan.Columns["PersonId"].Visible = false;
                GridViewMalikan.Columns["Kanal"].Visible = false;
                GridViewMalikan.Columns["marla"].Visible = false;
                GridViewMalikan.Columns["sarsai"].Visible = false;
                GridViewMalikan.Columns["Feet"].Visible = false;
                GridViewMalikan.Columns["Area"].Visible = false;
                GridViewMalikan.Columns["KhewatTypeId"].Visible = false;
                GridViewMalikan.Columns["KhewatType"].Visible = false;
                GridViewMalikan.Columns["PersonType"].Visible = false;
                GridViewMalikan.Columns["KhewatGroupFareeqId"].Visible = false;
                GridViewMalikan.Columns["FardAreaPart"].Visible = false;
                GridViewMalikan.Columns["KhewatGroupId"].Visible = false;
                GridViewMalikan.Columns["RegisterHqDKhataId"].Visible = false;
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
            foreach (DataGridViewRow row in this.GridViewMalikan.Rows)
            {

                if (row.Cells[0].Value != null)
                {
                    if ((Boolean)row.Cells[0].Value)
                    {
                        int rowcount = GridViewMalikanSelect.Rows.Count;

                        GridViewMalikanSelect.Rows.Add();
                        GridViewMalikanSelect.Rows[rowcount].Cells["PersonId"].Value = row.Cells["PersonId"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["CompleteName"].Value = row.Cells["CompleteName"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["Kanal"].Value = row.Cells["Kanal"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["marla"].Value = row.Cells["marla"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["sarsai"].Value = row.Cells["sarsai"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["Feet"].Value = row.Cells["Feet"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["Area"].Value = row.Cells["Area"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["KhewatTypeId"].Value = row.Cells["KhewatTypeId"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["KhewatType"].Value = row.Cells["KhewatType"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["PersonType"].Value = row.Cells["PersonType"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["KhewatGroupFareeqId"].Value = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["FardAreaPart"].Value = row.Cells["FardAreaPart"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["KhewatGroupId"].Value = row.Cells["KhewatGroupId"].Value.ToString();
                        GridViewMalikanSelect.Rows[rowcount].Cells["RegisterHqDKhataId"].Value = row.Cells["RegisterHqDKhataId"].Value.ToString();

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
                string khewatgroupfreeqid = "-1";
                int khewatgroupid = 0;
                int personid = Convert.ToInt32(row.Cells["PersonId"].Value);
                string khewatGroupFareeqId = row.Cells["KhewatGroupFareeqId"].Value.ToString();

                float fardareapart = row.Cells["FardAreaPart"].Value != null ? float.Parse(row.Cells["FardAreaPart"].Value.ToString()) : 0;
                int fardkanal = row.Cells["kanal"].Value != null ? Convert.ToInt32(row.Cells["kanal"].Value) : 0;
                int fardmarla = row.Cells["marla"].Value != null ? Convert.ToInt32(row.Cells["marla"].Value) : 0;
                float fardsarsai = row.Cells["sarsai"].Value != null ? float.Parse(row.Cells["sarsai"].Value.ToString()) : 0;
                string AreaPart = fardareapart.ToString();
                float fardfeet = fardsarsai * (float)30.25;
                int khewattypeid = Convert.ToInt32(row.Cells["KhewatTypeId"].Value != null ? row.Cells["KhewatTypeId"].Value.ToString() : "1");
                int khewatkhataid = Convert.ToInt32(this.txtKhewatKhataId.Text.ToString());
                this.OldKhatooniId = this.OldKhatooniId != null ? this.OldKhatooniId : "0";
                this.KhatooniRecId = this.KhatooniRecId != null ? this.KhatooniRecId : "0";
                this.MushteriFareeqId=this.MushteriFareeqId!=null?this.MushteriFareeqId:"0";
                string last = inteq.SaveIntiqalMinFareeqain("-1", IntiqalId,IntiqalMinGroupId, Convert.ToString(KhataId), khewatGroupFareeqId.ToString(),OldKhatooniId, KhatooniRecId, MushteriFareeqId, row.Index.ToString(), khewattypeid.ToString(), personid.ToString(), AreaPart, fardkanal.ToString(), fardmarla.ToString(), fardsarsai.ToString(), fardfeet.ToString(), "19001", "Admin", "19001", "Admin", "19001");
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
            if (IntiqalId != "-1" && GridViewMalikanSelect.Rows.Count >0)
            {
                SaveKhewatGroupFreqein();
            }
            else
            {
                MessageBox.Show("انتقال تقسیم سے من گروپ کا انتخاب کریں", "من گروپ", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            //this.cbFamily.Visible = this.checkBoxSearchByFamily.Checked;
            //if (this.checkBoxSearchByFamily.Checked)
            //{
            //    this.FillMozaFamaliesList();
            //}
        }

        private void cbFamily_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.FamilyPersons = client.GetFamilyPersonListByFamilyId(Convert.ToInt32(cbFamily.SelectedValue)).ToList().Where(p => p.familytypeId == 2).ToList();
            //this.GetMalikanbyKhataIdDataSource.DataSource = null;
            //this.malikan.Clear();
            //List<Proc_Get_KhewatTypes_Result> KhewatTypes=client.GetKhewatTypes(CurrentUser.TehsilId).ToList();
            //foreach (var q in FamilyPersons)
            //{
            //    Proc_Get_IntiqalMin_MalkanList_Result person = new Proc_Get_IntiqalMin_MalkanList_Result();
            //    person.KhewatTypeId = KhewatTypes.Count > 0 ? KhewatTypes.FirstOrDefault().KhewatTypeId : 0;
            //    person.PersonId = q.PersonId;
            //    person.CompleteName = q.FamilyName;
            //    person.FardAreaPart = 0;
            //    this.malikan.Add(person);
            //}
            //this.GetMalikanbyKhataIdDataSource.DataSource = this.malikan;
            //this.txtKhewatKhataId.Text = this.KhataId;
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
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            this.MalikanType = "RHZ";
            FillKhewatMalikanByKhataId();
            this.txtKhewatGroupId.Text = this.KhewatGroupId;
            this.txtKhewatKhataId.Text = this.KhataId;
            this.txtIntiqalMinGroupID.Text=this.IntiqalMinGroupId;
            this.txtIntiqalId.Text = this.IntiqalId;
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

    }
}
