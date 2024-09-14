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
        public int ForKhataKhatooni { get; set; }
        public string KhataKulHissay { get; set; }
        public string KhataKanal { get; set; }
        public string KhataMarla { get; set; }
        public string KhataSarsai { get; set; }
        public string KhataFeet { get; set; }
        Classess.AutoComplete objauto = new Classess.AutoComplete();
        Classess.CommanFunctions cmnFns = new Classess.CommanFunctions();
        #endregion


        public frmIntiqalMalkanManderjaKhata()
        {
            InitializeComponent();
        }

        private void frmIntiqalMalkanManderjaKhata_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            Fill_Khata_DropDown();
            if (ForKhataKhatooni == 1)
            {
                cbKhatooni.Visible = false;
                lbKhatooni.Visible = false;
            }
            else
            {
                cbKhatooni.Visible = true;
                lbKhatooni.Visible = true;
            }
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
        private void FillMalikanByKhatooniId()
        {
            try
            {

                this.malikan = null;
                int khatooniid = cbKhatooni.SelectedValue != null ? Convert.ToInt32(this.cbKhatooni.SelectedValue.ToString()) : 0;
                malikan = rhz.Proc_Get_MushtriFareeqeinBy_KhatooniId_Taqseem(khatooniid.ToString());
                this.GridViewMalikan.DataSource = malikan;
                this.GridViewMalikan.Columns["PersonName"].HeaderText = "نام مالک";
                this.GridViewMalikan.Columns["FardAreaPart"].HeaderText = "حصہ";
                this.GridViewMalikan.Columns["Khewat_Area"].HeaderText = "رقبہ";
                this.GridViewMalikan.Columns["PersonName"].DisplayIndex = 1;
                this.GridViewMalikan.Columns["PersonId"].Visible = false;
                this.GridViewMalikan.Columns["KhatooniId"].Visible = false;
                this.GridViewMalikan.Columns["MushtriFareeqId"].Visible = false;
                this.GridViewMalikan.Columns["Kanal"].Visible = false;
                this.GridViewMalikan.Columns["marla"].Visible = false;
                this.GridViewMalikan.Columns["sarsai"].Visible = false;
                this.GridViewMalikan.Columns["Feet"].Visible = false;
                this.GridViewMalikan.Columns["KhewatTypeId"].Visible = false;
                this.GridViewMalikan.Columns["KhewatType"].Visible = false;
                //this.GetMalikanbyKhataIdDataSource.DataSource = client.GetKhewatMalikanByKhataId(khataid);

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
            for (int k = 0; k <= GridViewMalikan.Rows.Count - 1; k++)
            {
                GridViewMalikan.Rows[k].Cells["col1"].Value = 0;
            }
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
                            if (ForKhataKhatooni == 1)
                            {
                                if (dtrow[0].ToString() == row.Cells["KhewatGroupFareeqId"].Value.ToString())
                                {
                                    malikanSel.ImportRow(dtrow);
                                }
                            }
                            else
                            {
                                if (dtrow[0].ToString() == row.Cells["MushtriFareeqId"].Value.ToString())
                                {
                                    malikanSel.ImportRow(dtrow);
                                }
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
            if (ForKhataKhatooni == 1)
            {
                SaveKhewatGroupFreqein();
            }
            else
            {
                SaveKhewatGroupFreqeinFromKhatooni();
            }
        }

        #region Save Khewat Group Freqein
        /// <summary>
        /// Method Saves Malikaan entry of a khata.
        /// </summary>
        private void SaveKhewatGroupFreqein()
        {
            DataTable KhataHissasArea = rhz.GetKhataHissasArea(KhataId);
            foreach (DataGridViewRow row in GridViewMalikanSelect.Rows)
            {
                string khewatgroupfreeqid = "-1";// Convert.ToInt32(this.txtKhewatFreeqainGroupId.Text.ToString());
                string khewatgroupid = "0";
                string personid =row.Cells["PersonId"].Value.ToString();
                string fardareapart =  row.Cells["FardAreaPart"].Value.ToString();// txtFardHissa.Text.Trim() != "" ? float.Parse(this.txtFardHissa.Text.ToString()) : 0;
                string[] area = cmnFns.CalculatedAreaFromHisa(float.Parse(KhataHissasArea.Rows[0]["TotalParts"].ToString()), float.Parse(fardareapart), Convert.ToInt32(KhataHissasArea.Rows[0]["Khata_Kanal"].ToString()), Convert.ToInt32(KhataHissasArea.Rows[0]["Khata_Marla"].ToString()), float.Parse(KhataHissasArea.Rows[0]["Khata_Sarsai"].ToString()), float.Parse(KhataHissasArea.Rows[0]["Khata_Feet"].ToString()));
                string fardkanal = area[0]!=null?area[0]:"0";// row.Cells["FardAreaPart"].Value.ToString();
                string fardmarla = area[1]!=null?area[1]:"0";// row.Cells["FardAreaPart"].Value.ToString();// following condition get sarsai for the area part
                float fardsarsai =float.Parse( area[2]!=null?area[2]:"0");// row.Cells["FardAreaPart"].Value.ToString() != "" ? float.Parse(row.Cells["FardAreaPart"].Value.ToString()) : 0;
                //MessageBox.Show(float.Parse("3.25"));
                float fardfeet = float.Parse(area[3]!=null?area[3]:"0");// fardsarsai > 0 ? fardsarsai * float.Parse("30.25") : float.Parse("0.0");
               
                string personPartBata=row.Cells["FardAreaPart"].Value.ToString();
                string khewattypeid = row.Cells["KhewatTypeId"].Value.ToString() ;
                string s = rhz.WEB_SP_INSERT_KhewatGroupFareeqein(khewatgroupfreeqid, khewatgroupid, personid, fardareapart, fardkanal, fardmarla, fardsarsai.ToString(), fardfeet.ToString(), khewattypeid, KhataId, UserId.ToString(), "0", "0", "0", "0", " ", "0").ToString();
                this.txtKhewatFreeqainGroupId.Text = s;
                //FillKhewatMalikanByKhataId();
                // KhataTotalRaqbaByKhataId();
            }

            this.Close();
        }
        private void SaveKhewatGroupFreqeinFromKhatooni()
        {
            foreach (DataGridViewRow row in GridViewMalikanSelect.Rows)
            {
                string khewatgroupfreeqid = "-1";// Convert.ToInt32(this.txtKhewatFreeqainGroupId.Text.ToString());
                string khewatgroupid = "0";
                string personid = row.Cells["PersonId"].Value.ToString();
                string fardsqft = (Math.Round(((float.Parse(row.Cells["kanal"].Value.ToString()) * 20 * 272.25) + (float.Parse(row.Cells["marla"].Value.ToString()) * 272.25) + (float.Parse(row.Cells["sarsai"].Value.ToString()) * 30.25)), 0).ToString());
                string Khatasqft = (Math.Round(((float.Parse(KhataKanal.ToString()) * 20 * 272.25) + (float.Parse(KhataMarla.ToString()) * 272.25) + (float.Parse(KhataSarsai.ToString()) * 30.25)), 0).ToString());
                string fardareapart = Math.Round((float.Parse(KhataKulHissay) / float.Parse(Khatasqft) * float.Parse(fardsqft)), 4).ToString();
                //string fardareapart = (Math.Round(float.Parse(row.Cells["FardAreaPart"].Value.ToString()) / float.Parse(row.Cells["Khatooni_Hissa"].Value.ToString()) * float.Parse(KhataKulHissay), 5)).ToString();
                string fardkanal = row.Cells["kanal"].Value.ToString();
                string fardmarla = row.Cells["marla"].Value.ToString();// following condition get sarsai for the area part
                string fardsarsai = row.Cells["sarsai"].Value.ToString() != "" ? row.Cells["sarsai"].Value.ToString() : "0";
                string fardfeet = row.Cells["feet"].Value.ToString() != "" ? row.Cells["feet"].Value.ToString() : "0";


                string personPartBata = row.Cells["FardAreaPart"].Value.ToString();
                string khewattypeid = row.Cells["KhewatTypeId"].Value.ToString();
                string s = rhz.WEB_SP_INSERT_KhewatGroupFareeqein_From_Khatooni_Taqseem(khewatgroupfreeqid, khewatgroupid, personid, fardareapart, fardkanal, fardmarla, fardsarsai.ToString(), fardfeet.ToString(), khewattypeid, KhataId, UserId.ToString(), "0", "0", "0", "0", " ", "0").ToString();
                this.txtKhewatFreeqainGroupId.Text = s;
                //FillKhewatMalikanByKhataId();
                // KhataTotalRaqbaByKhataId();
            }
        }
        #endregion

        private void cbKhatas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ForKhataKhatooni == 1)
            {
                FillKhewatMalikanByKhataId();
            }
            else
            {
                objauto.FillCombo("Proc_Get_KhatooniNos_List_By_KhataId "+Classess.UsersManagments._Tehsilid.ToString()+"," + cbKhatas.SelectedValue.ToString(), cbKhatooni, "KhatooniNo", "KhatooniId");
            }
        }
        private void txtsearchMalikan_TextChanged(object sender, EventArgs e)
        {
            if (this.GridViewMalikan.Rows.Count > 0)
            {

                for (int i = 0; i <= GridViewMalikan.Rows.Count - 1; i++)
                {

                    if (GridViewMalikan.Rows[i].Cells["PersonName"].Value.ToString().Contains(txtsearchMalikan.Text.Trim()))
                    {

                        GridViewMalikan.Rows[i].Visible = true;
                    }
                    else
                    {

                        CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[GridViewMalikan.DataSource];
                        currencyManager1.SuspendBinding();
                        GridViewMalikan.Rows[i].Visible = false;
                        currencyManager1.ResumeBinding();
                        GridViewMalikan.Rows[i].Visible = false;


                    }
                }


            }
        }

        private void txtsearchMalikan_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (e.KeyChar == 1)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }
        }

        private void cbKhatooni_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillMalikanByKhatooniId();
        }


    }
}
