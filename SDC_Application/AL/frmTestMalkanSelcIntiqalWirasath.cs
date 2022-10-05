using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using SDC_Application.BL;
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmTestMalkanSelcIntiqalWirasath : Form
    {

        #region Class Variables
    
        //ClientServiceClient client = new ClientServiceClient();
        //List<Proc_Get_KhewatFareeqeinByKhataId_Result> malikan = new List<Proc_Get_KhewatFareeqeinByKhataId_Result>();
        //List<Proc_Get_KhewatFareeqeinByKhataId_Result> malikanSel = new List<Proc_Get_KhewatFareeqeinByKhataId_Result>();
        //List<Proc_Get_Moza_Families_List_Result> MozaFamilies = new List<Proc_Get_Moza_Families_List_Result>();
        //List<Proc_Get_FamilyPersons_List_Result> FamilyPersons = new List<Proc_Get_FamilyPersons_List_Result>();
        //int UserId = Classes.CurrentUser.UserId;
        Intiqal intiq = new Intiqal();
        LanguageConverter Lang = new LanguageConverter();
        public string KhataId { get; set; }
        public string KhewatGroupId { get; set; }
        public string MozaId { get; set; }
        public int RegisterId { get; set; }
        public string IntiqalKhataRecId { get; set; }
        public string khewatTypeId { get; set; }
        public string IntiqalBuyerRecId { get; set; }
        bool selected;
        int i;

        public string KhatoniRecid { get; set; }
        
        
        #endregion

        public frmTestMalkanSelcIntiqalWirasath()
        {
            InitializeComponent();
        }

        #region Form Load Event
       
        private void frmTestMalkanSelcIntiqalWirasath_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            GridViewMalikanSelect.Columns.Add("FamilyName", "افراد خاندان");
            GridViewMalikanSelect.Columns["FamilyName"].DisplayIndex = 0;
            GridViewMalikanSelect.Columns.Add("PersonId","");
            GridViewMalikanSelect.Columns["PersonId"].Visible = false;
            //GridViewMalikanSelect.Columns["colRemove"].DisplayIndex = 0;
            //GridViewMalikanSelect.Columns.Add("FmailyNo", "FmailyNo");
            FillMozaFamaliesList();
            selected = true;
        }
        public void gridfill()
        {
            foreach (DataGridViewRow row in this.GridViewMalikan.Rows)
            {

                if (row.Cells[0].Value != null)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        int i = GridViewMalikanSelect.Rows.Count;
                        //int rowcount = GridViewMalikanSelect.Rows.Count;

                        GridViewMalikanSelect.Rows.Add();
                        GridViewMalikanSelect.Rows[i].Cells["FamilyName"].Value = row.Cells["FamilyName"].Value.ToString();
                        GridViewMalikanSelect.Rows[i].Cells["PersonId"].Value = row.Cells["PersonId"].Value.ToString();
                        
                    }
                }

            }
            removeFromGridDuplicate(GridViewMalikanSelect);
        }
       

        #endregion

        #region Populate Moza Family List

        public void FillMozaFamaliesList()
        {
            DataTable MozaFamilies = new DataTable();
            MozaFamilies = intiq.GetMozaFamilyListByMozaId(MozaId);
            DataRow row = MozaFamilies.NewRow();
            row["FamilyName"] = " - فیملی کا انتخاب کریں - ";
            row["FmailyNo"] = "0";
            MozaFamilies.Rows.InsertAt(row,0);
            this.cbFamily.DataSource = MozaFamilies;
            this.cbFamily.DisplayMember = "FamilyName";
            this.cbFamily.ValueMember = "FmailyNo";
        }
        public void FillGridByFamilyPersons(string FamilyId)
        {
           
            DataTable dt = new DataTable();
            dt = intiq.GetMozaFamilyListByFamilyId(FamilyId);
            GridViewMalikan.DataSource = dt;
            GridViewMalikan.Columns["FamilyName"].HeaderText = "افراد خاندان";
            GridViewMalikan.Columns["PersonId"].Visible = false;
            GridViewMalikan.Columns["familyType"].Visible = false;
            GridViewMalikan.Columns["familytypeId"].Visible = false;
            foreach (DataGridViewRow row in GridViewMalikan.Rows)
            {
                if (row.Selected)
                {
                    row.Selected = false;
                    btnSelect.Enabled = false;
                
                }
            }
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
               
                //this.GetMalikanbyKhataIdDataSource.DataSource = null;
                //int khataid =cbKhatas.SelectedValue!=null? Convert.ToInt32(this.cbKhatas.SelectedValue.ToString()):0;
                //malikan = client.GetKhewatMalikanByKhataId(khataid).ToList();
                //this.GetMalikanbyKhataIdDataSource.DataSource = malikan; 
                ////this.GetMalikanbyKhataIdDataSource.DataSource = client.GetKhewatMalikanByKhataId(khataid);

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
            if(GridViewMalikanSelect.SelectedRows.Count>0)
            {
            this.btnSave.Enabled = true;
            }
        }

        #endregion


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
        #region Funtion Get Selected Malikan from Prevoius Khata malikans
        /// <summary>
        /// select malkan from the previous khatta and a list is made to use in new khatta
        /// </summary>
        public void getMalikanSelected()
        {
            
          
            foreach (DataGridViewRow row in this.GridViewMalikan.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    if ((Boolean)row.Cells[0].Value)
                        //this.malikanSel.Add(this.malikan.Where(p => p.PersonId.ToString() == (row.Cells[8].Value.ToString()) && p.FardAreaPart.ToString() == row.Cells[2].Value.ToString()).FirstOrDefault());
                        this.GridViewMalikanSelect.Rows.Add();
                }
            }
            //this.GetMalikanSelectedDataSource.DataSource = null;
            //this.GetMalikanSelectedDataSource.DataSource = this.malikanSel;
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
                string IntiqalBuyerRecId="-1";
                //string IntiqalKhataRecId = "190010004";
                string IntiqalBuyerPersonId =row.Cells["PersonId"].Value.ToString();
                string Buyer_Hissa="0";
                string Buyer_Kanal="0";
                string Buyer_Marla  ="0";
                string Buyer_Sarsai="0";
                string Buyer_Feet ="0";
                string KhewatTypeId = this.khewatTypeId;
                string s = intiq.SaveintiqalBuyers(IntiqalBuyerRecId, IntiqalKhataRecId, KhatoniRecid, IntiqalBuyerPersonId, Buyer_Hissa, Buyer_Kanal, Buyer_Marla, Buyer_Sarsai, Buyer_Feet, KhewatTypeId, "0", UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
            }

            this.Close();
        }
        
        /// <summary>
        /// saves khewat group farqain as khewat malkan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveKhewatGroupFreqein();
        }

        #endregion

        #region Gridview Malikan all cell click event
        /// <summary>
        /// make selection of malkna on basis of check box provided in the gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridViewMalikan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // //int count = 0;
           //// btnSelect.Enabled = true;
           // DataGridView g = sender as DataGridView;
           // foreach (DataGridViewRow row in g.Rows)
           // {
           //     if (Convert.ToBoolean(row.Cells["col1"].Value)==true)
           //     {
           //         //row.Selected = true;
           //         btnSelect.Enabled = true;
           //     }
           //     else
           //     {
           //         //row.Selected = false;
           //     }
           // } 
        }
           
        
        #endregion

        #region Button Check All Click event

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            
            foreach (DataGridViewRow row in GridViewMalikan.Rows)
            {

                if (selected)
                {
                    row.Cells["col1"].Value = 1;
                    i = 1;
                }
               else
                {
                    row.Cells["col1"].Value = 0;
                    i = 0;
                }
               
            }
            if (i == 0)
            {
                selected = true;
                this.btnSelect.Enabled = false;
            }
            if (i == 1)
            {
                selected = false;
                this.btnSelect.Enabled = true;
            }
            
        }

        #endregion

        private void checkBoxSearchByFamily_CheckedChanged(object sender, EventArgs e)
        {
            this.cbFamily.Visible = this.checkBoxSearchByFamily.Checked;
            if (this.checkBoxSearchByFamily.Checked)
            {
                this.FillMozaFamaliesList();
            }
        }

        private void cbFamily_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //this.FamilyPersons = client.GetFamilyPersonListByFamilyId(Convert.ToInt32(cbFamily.SelectedValue)).ToList().Where(p => p.familytypeId == 2).ToList();
            //this.GetMalikanbyKhataIdDataSource.DataSource = null;
            //this.malikan.Clear();
            //List<Proc_Get_KhewatTypes_Result> KhewatTypes=client.GetKhewatTypes(CurrentUser.TehsilId).ToList();
            //foreach (var q in FamilyPersons)
            //{
            //    Proc_Get_KhewatFareeqeinByKhataId_Result person = new Proc_Get_KhewatFareeqeinByKhataId_Result();
            //    person.KhewatTypeId = KhewatTypes.Count > 0 ? KhewatTypes.FirstOrDefault().KhewatTypeId : 0;
            //    person.PersonId = q.PersonId;
            //    person.PersonName = q.FamilyName;
            //    person.Khewat_Area = "0";
            //    this.malikan.Add(person);
            //}
            //this.GetMalikanbyKhataIdDataSource.DataSource = this.malikan;
            //this.txtKhewatKhataId.Text = this.KhataId;
            if (cbFamily.SelectedIndex > 0)
            {
                string Familyid = cbFamily.SelectedValue.ToString();
                FillGridByFamilyPersons(Familyid);
            }
        }

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

        private void cbFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFamily.SelectedIndex>0)
            {
            string Familyid = cbFamily.SelectedValue.ToString();
            FillGridByFamilyPersons(Familyid);
            }
        }

        

       
    }
}
