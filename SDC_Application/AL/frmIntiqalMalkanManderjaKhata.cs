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

namespace SDC_Application.AL
{
    public partial class frmIntiqalMalkanManderjaKhata : Form
    {

        #region Class Variables

        TaqseemNewKhataJatMin rhz=new TaqseemNewKhataJatMin();
        DataTable Khatajat = new DataTable();
        DataTable malikan = new DataTable(); //List<Proc_Get_KhewatFareeqeinByKhataId_Result>();
        DataTable malikanSel = new DataTable(); //List<Proc_Get_KhewatFareeqeinByKhataId_Result>();
        DataTable MozaFamilies = new DataTable(); //List<Proc_Get_Moza_Families_List_Result>();
        DataTable FamilyPersons = new DataTable(); // List<Proc_Get_FamilyPersons_List_Result>();
        int UserId = SDC_Application.Classess.UsersManagments.UserId;
        LanguageConverter Lang = new LanguageConverter();
        public string KhataId { get; set; }
        public string KhewatGroupId { get; set; }
        public int MozaId { get; set; }
        public int RegisterId { get; set; }

        #endregion


        public frmIntiqalMalkanManderjaKhata()
        {
            InitializeComponent();
        }

        private void frmIntiqalMalkanManderjaKhata_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            Fill_Khata_DropDown();
        }

        #region Fill Grid view method

        public void Fill_Khata_DropDown()
        {
            try
            {

                Khatajat = rhz.GetKhatajatAll(MozaId.ToString());
                DataRow inteqKj = Khatajat.NewRow();
                inteqKj["RegisterHqDKhataId"] = "0";
                inteqKj["KhataNo"] = "کھاتے کا انتخاب کریں";
                Khatajat.Rows.InsertAt(inteqKj, 0);
                cbKhatas.DataSource = Khatajat;
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

        #region Fill Khewat Malikan By Khatta Id
        /// <summary>
        /// Used for filling malikaan record of a specific khata into gridview khata malikan
        /// </summary>
        private void FillKhewatMalikanByKhataId()
        {
            try
            {

                this.malikan= null;
                int khataid = cbKhatas.SelectedValue != null ? Convert.ToInt32(this.cbKhatas.SelectedValue.ToString()) : 0;
                malikan = rhz.Proc_Get_KhewatFareeqeinBy_KhataId(khataid.ToString());
                this.GridViewMalikan.DataSource = malikan;
                this.GridViewMalikan.Columns["PersonName"].HeaderText="نام مالک";
                this.GridViewMalikan.Columns["FardAreaPart"].HeaderText="حصہ";
                this.GridViewMalikan.Columns["Khewat_Area"].HeaderText="رقبہ";
                this.GridViewMalikan.Columns["PersonName"].DisplayIndex = 1;
                this.GridViewMalikan.Columns["PersonId"].Visible=false;
                this.GridViewMalikan.Columns["KhewatGroupId"].Visible=false;
                this.GridViewMalikan.Columns["KhewatGroupFareeqId"].Visible=false;
                this.GridViewMalikan.Columns["Kanal"].Visible=false;
                this.GridViewMalikan.Columns["marla"].Visible=false;
                this.GridViewMalikan.Columns["sarsai"].Visible=false;
                this.GridViewMalikan.Columns["KhewatTypeId"].Visible=false;
                this.GridViewMalikan.Columns["KhewatType"].Visible=false;
                this.GridViewMalikan.Columns["RegisterHqDKhataId"].Visible=false;
                //this.GetMalikanbyKhataIdDataSource.DataSource = client.GetKhewatMalikanByKhataId(khataid);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Button Select All Malikan CLick Event

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in GridViewMalikan.Rows)
            {
                if (!row.IsNewRow)
                {
                    row.Cells[0].Value = !(Boolean)(row.Cells[0].Value != null ? row.Cells[0].Value : false);
                }
                btnSelect.Enabled = true;
            }
        }

        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.getMalikanSelected();
            this.btnSave.Enabled = true;
        }

        #region Funtion Get Selected Malikan from Prevoius Khata malikans
        /// <summary>
        /// select malkan from the previous khatta and a list is made to use in new khatta
        /// </summary>
        public void getMalikanSelected()
        {
            
            this.malikanSel.Clear();
            this.malikanSel=malikan.Clone();
            foreach (DataGridViewRow row in this.GridViewMalikan.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    foreach(DataRow dtrow in malikan.Rows)
                    {
                        if (Convert.ToInt32(row.Cells[0].Value) == 1)
                        {
                             //rowTD = dtrow[11].ToString();
                             //rowGV = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                            if (dtrow[0].ToString() == row.Cells["KhewatGroupFareeqId"].Value.ToString())
                            {
                                malikanSel.ImportRow(dtrow);
                            }
                        }
                    }
                }
            }
            this.GridViewMalikanSelect.DataSource = null;
            this.GridViewMalikanSelect.DataSource = this.malikanSel;
            this.GridViewMalikanSelect.Columns["PersonName"].HeaderText = "نام مالک";
            this.GridViewMalikanSelect.Columns["FardAreaPart"].HeaderText = "حصہ";
            this.GridViewMalikanSelect.Columns["Khewat_Area"].HeaderText = "رقبہ";
            this.GridViewMalikanSelect.Columns["PersonName"].DisplayIndex = 1;
            this.GridViewMalikanSelect.Columns["PersonId"].Visible = false;
            this.GridViewMalikanSelect.Columns["KhewatGroupId"].Visible = false;
            this.GridViewMalikanSelect.Columns["KhewatGroupFareeqId"].Visible = false;
            this.GridViewMalikanSelect.Columns["Kanal"].Visible = false;
            this.GridViewMalikanSelect.Columns["marla"].Visible = false;
            this.GridViewMalikanSelect.Columns["sarsai"].Visible = false;
            this.GridViewMalikanSelect.Columns["KhewatTypeId"].Visible = false;
            this.GridViewMalikanSelect.Columns["KhewatType"].Visible = false;
            this.GridViewMalikanSelect.Columns["RegisterHqDKhataId"].Visible = false;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveKhewatGroupFreqein();
        }

        #region Save Khewat Group Freqein
        /// <summary>
        /// Method Saves Malikaan entry of a khata.
        /// </summary>
        private void SaveKhewatGroupFreqein()
        {
            foreach (DataGridViewRow row in GridViewMalikanSelect.Rows)
            {
                string khewatgroupfreeqid = "-1";// Convert.ToInt32(this.txtKhewatFreeqainGroupId.Text.ToString());
                string khewatgroupid = "0";
                string personid =row.Cells["PersonId"].Value.ToString();
                string fardareapart = "0";// row.Cells["FardAreaPart"].Value.ToString();// txtFardHissa.Text.Trim() != "" ? float.Parse(this.txtFardHissa.Text.ToString()) : 0;
                string fardkanal = "0";// row.Cells["FardAreaPart"].Value.ToString();
                string fardmarla = "0";// row.Cells["FardAreaPart"].Value.ToString();// following condition get sarsai for the area part
                float fardsarsai = 0;// row.Cells["FardAreaPart"].Value.ToString() != "" ? float.Parse(row.Cells["FardAreaPart"].Value.ToString()) : 0;
                //MessageBox.Show(float.Parse("3.25"));
                float fardfeet = 0;// fardsarsai > 0 ? fardsarsai * float.Parse("30.25") : float.Parse("0.0");
               
                string personPartBata=row.Cells["FardAreaPart"].Value.ToString();
                string khewattypeid = row.Cells["KhewatTypeId"].Value.ToString() ;
                string s = rhz.WEB_SP_INSERT_KhewatGroupFareeqein(khewatgroupfreeqid, khewatgroupid, personid, fardareapart, fardkanal, fardmarla, fardsarsai.ToString(), fardfeet.ToString(), khewattypeid, KhataId, UserId.ToString(), "0", "0", "0", "0", " ", "0").ToString();
                this.txtKhewatFreeqainGroupId.Text = s;
                //FillKhewatMalikanByKhataId();
                // KhataTotalRaqbaByKhataId();
            }

            this.Close();
        }
        #endregion

        private void cbKhatas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillKhewatMalikanByKhataId();
        }


    }
}
