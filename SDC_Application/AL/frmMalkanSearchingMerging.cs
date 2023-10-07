using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.BL;
using SDC_Application.LanguageManager;
namespace SDC_Application.AL
{
    public partial class frmMalkanSearchingMerging : Form
    {
        #region Class Variables

        Intiqal intiqal = new Intiqal();
        AutoComplete objauto = new AutoComplete();
        DataTable dtAllKhewatFareeqain = new DataTable();
        DataTable dtMushteriFareeqain = new DataTable();
        DataTable dtMushteriFareeqainSel = new DataTable();
        TaqseemNewKhataJatMin khatas = new TaqseemNewKhataJatMin();
        Khatoonies khatooni = new Khatoonies();
        DataView dtvKhewatFareeqainByPerson = new DataView();
        DataView view;
        DataView viewKhanakasht;
        public string MozaId { get; set; }
        LanguageConverter lang = new LanguageConverter();
        CommanFunctions cfs = new CommanFunctions();
        public float KulHissay { get; set; }
        public string KulRaqba { get; set; }
        public float KulHissayKhanakasht { get; set; }
        public string KulRaqbaKhanakasht { get; set; }
        public string khewatgroupFareeqid { get; set; }
        public string  MushteriFareeqid { get; set; }
        #endregion

        #region Default Constructor

        public frmMalkanSearchingMerging()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load Event


        private void frmIntiqalAmalDaramadByKhata_Load(object sender, EventArgs e)
        {
            // Get  Mouza List and Fill Mouza Drop down
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMozaKhanakasht, "MozaNameUrdu", "MozaId");
        }


        #endregion

        #region Fill Grid view method

        public void Fill_Khata_DropDown()
        {
            try
            {
                DataTable dtkj = new DataTable();
                dtkj = intiqal.GetKhataJatForintiqalByMozaId(cmbMouza.SelectedValue.ToString());
                DataRow inteqKj = dtkj.NewRow();
                inteqKj["RegisterHqDKhataId"] = "0";
                inteqKj["KhataNo"] = " - کھاتہ نمبر کا انتخاب کرِیں - ";
                dtkj.Rows.InsertAt(inteqKj, 0);
                cbokhataNo.DataSource = dtkj;
                cbokhataNo.DisplayMember = "KhataNo";
                cbokhataNo.ValueMember = "RegisterHqDKhataId";
                cbokhataNo.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Khata No Selection Change event

        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DataTable dtAllKhewatFareeqain = null;
            this.dgKhewatFreeqDetails.Rows.Clear();
            dtAllKhewatFareeqain = khatas.Proc_Get_KhewatFareeqeinByKhataId(cbokhataNo.SelectedValue.ToString());
            this.dgKhewatFareeqainAll.DataSource = dtAllKhewatFareeqain;
            view = new DataView(dtAllKhewatFareeqain);
            this.PopulateGridViewKhewatMalkanAll();
        }

        #endregion

        #region Fill Gridview Malkan by Khata

        private void PopulateGridViewKhewatMalkanAll()
        {
            dgKhewatFareeqainAll.Columns["FardAreaPart"].HeaderText = "حصہ";
            dgKhewatFareeqainAll.Columns["Khewat_Area"].HeaderText = "رقبہ";
            dgKhewatFareeqainAll.Columns["PersonName"].HeaderText = "نام مالک";
            dgKhewatFareeqainAll.Columns["CNIC"].HeaderText = "شناختی نمبر";
            dgKhewatFareeqainAll.Columns["KhewatType"].HeaderText = "قسم مالک";
            dgKhewatFareeqainAll.Columns["FardPart_Bata"].Visible = false;
            dgKhewatFareeqainAll.Columns["seqno"].HeaderText = "نمبر شمار";
            dgKhewatFareeqainAll.Columns["KhewatGroupFareeqId"].Visible = false;
            dgKhewatFareeqainAll.Columns["KhewatGroupId"].Visible = false;
            dgKhewatFareeqainAll.Columns["PersonId"].Visible = false;
            dgKhewatFareeqainAll.Columns["darno"].Visible = false;
            dgKhewatFareeqainAll.Columns["TotalDarPart"].Visible = false;
            dgKhewatFareeqainAll.Columns["PersonDarPart"].Visible = false;
            dgKhewatFareeqainAll.Columns["OfDarPart"].Visible = false;
            dgKhewatFareeqainAll.Columns["PersonNetPart"].Visible = false;
            dgKhewatFareeqainAll.Columns["KhewatTypeId"].Visible = false;
            dgKhewatFareeqainAll.Columns["PersonName"].DisplayIndex = 2;
            dgKhewatFareeqainAll.Columns["KhewatType"].DisplayIndex = 3;
            dgKhewatFareeqainAll.Columns["seqno"].DisplayIndex = 1;

        }

        #endregion

        #region Gridview Khewat group fareeqain Cell Click Event

        private void dgKhewatFareeqainAll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (dgKhewatFareeqainAll.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells[0].Value = 1;
                            string personId = row.Cells["PersonId"].Value.ToString();
                            string khataId = cbokhataNo.SelectedValue.ToString();
                            if (this.dgKhewatFreeqDetails.Columns.Count < 1)
                            {
                                foreach (DataGridViewColumn col in g.Columns)
                                {
                                    this.dgKhewatFreeqDetails.Columns.Add(col.Name, col.HeaderText);
                                    // this.dgKhewatFreeqDetails.Columns[col.Name] = DataGridViewCheckBoxCell;
                                    //this.dgKhewatFreeqDetails.Columns.Add(col);

                                }
                                this.dgKhewatFreeqDetails.Columns.Insert(g.ColumnCount, new DataGridViewButtonColumn());
                                this.dgKhewatFreeqDetails.Columns[g.ColumnCount].HeaderText = "خذف کریں";
                                this.dgKhewatFreeqDetails.Columns[g.ColumnCount].Name = "ColDel";
                                this.dgKhewatFreeqDetails.Columns.Insert(g.ColumnCount, new DataGridViewCheckBoxColumn());
                                this.dgKhewatFreeqDetails.Columns[g.ColumnCount].HeaderText = "انتخاب برائے یکجا";
                                this.dgKhewatFreeqDetails.Columns[g.ColumnCount].Name = "ColSel";

                            }
                            //this.dgKhewatFreeqDetails.Columns.Add().Add();
                            int i = dgKhewatFreeqDetails.Rows.Count;
                            bool exists = false;
                            if (dgKhewatFreeqDetails.Rows.Count > 0)
                            {
                                foreach (DataGridViewRow r in dgKhewatFreeqDetails.Rows)
                                {
                                    if (r.Cells["KhewatGroupFareeqId"].Value.ToString() == row.Cells["KhewatGroupFareeqId"].Value.ToString())
                                    {
                                        MessageBox.Show("مالک پہلے سے موجود ہے", "مالک پہلے سے موجود ہے", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        exists = true;
                                        break;
                                    }

                                }

                            }
                            if (!exists)
                            {
                                this.dgKhewatFreeqDetails.Rows.Add();
                                foreach (DataGridViewColumn col in g.Columns)
                                {

                                    this.dgKhewatFreeqDetails.Rows[i].Cells[col.Name].Value = row.Cells[col.Name].Value.ToString();


                                }
                                PopulateGridviewKhewFareeqByPersonId();
                            }


                        }
                        else
                        {
                            row.Cells[0].Value = 0;
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

        #region Fill Gridview Malkan by Person Id for Single Malk History and Details

        private void PopulateGridviewKhewFareeqByPersonId()
        {
            try
            {
                dgKhewatFreeqDetails.Columns["FardAreaPart"].HeaderText = "حصہ";
                dgKhewatFreeqDetails.Columns["Khewat_Area"].HeaderText = "رقبہ";
                dgKhewatFreeqDetails.Columns["PersonName"].HeaderText = "نام مالک";
                dgKhewatFreeqDetails.Columns["CNIC"].HeaderText = "شناختی نمبر";
                dgKhewatFreeqDetails.Columns["KhewatType"].HeaderText = "قسم مالک";
                dgKhewatFreeqDetails.Columns["FardPart_Bata"].Visible = false;
                dgKhewatFreeqDetails.Columns["seqno"].HeaderText = "نمبر شمار";
                dgKhewatFreeqDetails.Columns["KhewatGroupFareeqId"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatGroupId"].Visible = false;
                dgKhewatFreeqDetails.Columns["PersonId"].Visible = false;
                dgKhewatFreeqDetails.Columns["darno"].Visible = false;
                dgKhewatFreeqDetails.Columns["TotalDarPart"].Visible = false;
                dgKhewatFreeqDetails.Columns["PersonDarPart"].Visible = false;
                dgKhewatFreeqDetails.Columns["OfDarPart"].Visible = false;
                dgKhewatFreeqDetails.Columns["PersonNetPart"].Visible = false;
                dgKhewatFreeqDetails.Columns["KhewatTypeId"].Visible = false;
                dgKhewatFreeqDetails.Columns["PersonName"].DisplayIndex = 2;
                dgKhewatFreeqDetails.Columns["KhewatType"].DisplayIndex = 3;
                dgKhewatFreeqDetails.Columns["seqno"].DisplayIndex = 1;
                dgKhewatFreeqDetails.Columns["ColSelection"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Textbox Search from Grid Text Changed event

        private void txtSearchFromGrid_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchFromGrid.Text.ToString();
            view.RowFilter = "PersonName LIKE '%" + filter + "%'";
            dgKhewatFareeqainAll.DataSource = view;
            this.PopulateGridViewKhewatMalkanAll();
        }

        #endregion

        #region Textbox Search from Grid Key press event for auto eng to Urdu Conversion

        private void txtSearchFromGrid_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion

        #region Moza Selection Change Event

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Fill_Khata_DropDown();
        }

        #endregion

        #region Gridview Khana Malkiat details


        private void dgKhewatFreeqDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            if (g.CurrentCell == g.CurrentRow.Cells["ColSel"])
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    row.Cells["ColSel"].Value = 0;
                }
                g.CurrentCell.Value = g.CurrentCell.Value != null ? (g.CurrentCell.Value.ToString() == "1" ? 0 : 1) : 1;

                MergData();

            }
            else if (g.CurrentCell == g.CurrentRow.Cells["ColDel"])
            {
                if (MessageBox.Show(" انتخاب کردہ ریکارڈ خذف کرنا چاہتے ہو؟", "خذف کریں", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    g.Rows.RemoveAt(g.CurrentRow.Index);

                }
            }
        }

        private void btnMergRecords_Click(object sender, EventArgs e)
        {

            if (dgKhewatFreeqDetails.Rows.Count >= 2)
            {
                bool doMerg = false;
                foreach (DataGridViewRow r in dgKhewatFreeqDetails.Rows)
                {

                    if ((r.Cells["ColSel"].Value != null ? r.Cells["ColSel"].Value.ToString() : "0") == "1")
                    {
                        doMerg = true;
                        break;
                    }

                }
                if (doMerg)
                {
                    if (MessageBox.Show(" انتخاب کردہ ریکارڈ یکجا کرنا چاہتے ہے؟", "یکجا کریں", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // do Merg
                        foreach (DataGridViewRow r in dgKhewatFreeqDetails.Rows)
                        {

                            if ((r.Cells["ColSel"].Value != null ? r.Cells["ColSel"].Value.ToString() : "0") == "1")
                            {
                                string kgfId = r.Cells["KhewatGroupFareeqId"].Value.ToString();
                                string personId = r.Cells["PersonId"].Value.ToString();
                                string KhewatGroupId = r.Cells["KhewatGroupId"].Value.ToString();
                                string FardAreaPart = this.KulHissay.ToString();
                                string khewatTypeId = r.Cells["KhewatTypeId"].Value.ToString();
                                string KhattaId = r.Cells["KhewatGroupId"].Value.ToString();
                                string[] raqba = this.KulRaqba.Split('-');
                                string kanal = raqba[0];
                                string Marla = raqba[1];
                                string sft = raqba[2];
                                string Sarsai = (float.Parse(sft) / (float)30.25).ToString();
                                string lastId = intiqal.SaveKhewatGrouFreeqein(kgfId, KhewatGroupId, personId, FardAreaPart, kanal, Marla, Sarsai, sft, khewatTypeId, KhattaId, UsersManagments.UserId.ToString(), "0", "0", "0", "0", UsersManagments.UserName, "0");
                                string MerginId = intiqal.SaveKhewatMalkanMerginRecord(kgfId, kgfId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                            }
                            else
                            {
                                string kgfId = r.Cells["KhewatGroupFareeqId"].Value.ToString();
                                string lastId = intiqal.DeleteKhewatGroupFareeq(kgfId);
                                string MerginId = intiqal.SaveKhewatMalkanMerginRecord(this.khewatgroupFareeqid, kgfId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                            }

                        }
                        MessageBox.Show("ملکان ریکارڈ یکجا ہو گیا۔");
                        this.dgKhewatFreeqDetails.Rows.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("یکجا کرنے کیلئے کسی ایک ریکارڈ جسمیں باقی یکجا کرنا چاہتے ہو، کا انتخاب کریں", "یکجا کرنا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("یکجا کرنے کیلئے کم از کم دو ریکارڈ کا انتخاب کریں", "یکجا کرنا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MergData()
        {
            this.KulHissay = 0;
            this.KulRaqba = "0-0-0";
            string khewatMalikName = "";
            this.khewatgroupFareeqid = "0";
            float KulHissa = 0;
            int KulKanal = 0;
            int KulMarla = 0;
            float KulSarsai = 0;
            float KulSft = 0;

            foreach (DataGridViewRow row in dgKhewatFreeqDetails.Rows)
            {
                KulHissa += float.Parse(row.Cells["FardAreaPart"].Value.ToString());
                string[] Raqba = (row.Cells["Khewat_Area"].Value.ToString().Split('-'));
                KulKanal += Convert.ToInt32(Raqba[0]);
                KulMarla += Convert.ToInt32(Raqba[1]);
                KulSft += float.Parse(Raqba[2]);

                if (row.Cells["ColSel"].Value.ToString() == "1")
                {
                    khewatMalikName = row.Cells["PersonName"].Value.ToString();
                    khewatgroupFareeqid = row.Cells["KhewatGroupFareeqId"].Value.ToString();
                }

            }
            KulSarsai += KulSft / float.Parse("30.25");
            this.lblMalkName.Text = khewatMalikName;
            this.lblTotalHissa.Text = KulHissa.ToString();
            this.KulHissay = KulHissa;
            this.lblTotalRqba.Text = cfs.SFTtoRqba(KulKanal, KulMarla, Convert.ToDecimal(KulSarsai));
            this.KulRaqba = lblTotalRqba.Text;


        }


        #endregion

        #region Khanakasht Merging and Searchin


        private void cmbMozaKhanakasht_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Fill_Khata_DropDownKhanakasht();
        }

        #region Fill Khatas for Khanakasht drop dowm method

        public void Fill_Khata_DropDownKhanakasht()
        {
            try
            {
                DataTable dtkj = new DataTable();
                dtkj = intiqal.GetKhataJatForintiqalByMozaId(cmbMozaKhanakasht.SelectedValue.ToString());
                DataRow inteqKj = dtkj.NewRow();
                inteqKj["RegisterHqDKhataId"] = "0";
                inteqKj["KhataNo"] = " - کھاتہ نمبر کا انتخاب کرِیں - ";
                dtkj.Rows.InsertAt(inteqKj, 0);
                cmbKhataNoKhanakasht.DataSource = dtkj;
                cmbKhataNoKhanakasht.DisplayMember = "KhataNo";
                cmbKhataNoKhanakasht.ValueMember = "RegisterHqDKhataId";
                cmbKhataNoKhanakasht.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void cmbKhataNoKhanakasht_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable dtkj = new DataTable();
                dtkj = khatooni.Get_KhatoonisbyKhataId(cmbKhataNoKhanakasht.SelectedValue.ToString());
                DataRow inteqKj = dtkj.NewRow();
                inteqKj["KhatooniId"] = "0";
                inteqKj["KhatooniNo"] = " - کھتونی کا انتخاب کرِیں - ";
                dtkj.Rows.InsertAt(inteqKj, 0);
                cmbKhatooniNo.DataSource = dtkj;
                cmbKhatooniNo.DisplayMember = "KhatooniNo";
                cmbKhatooniNo.ValueMember = "KhatooniId";
                cmbKhatooniNo.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbKhatooniNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dtMushteriFareeqain = null;
                //this.dgMushteryanKhatooni.Rows.Clear();
                dtMushteriFareeqain = khatooni.Get_MushtriFareeqein_By_KhatooniId(cmbKhatooniNo.SelectedValue.ToString());
                this.dgMushteryanKhatooni.DataSource = dtMushteriFareeqain;
                viewKhanakasht = new DataView(dtMushteriFareeqain);
                this.PopulateGridViewMushteryan(dgMushteryanKhatooni);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void PopulateGridViewMushteryan(DataGridView g)
        {
            g.Columns["SeqNo"].HeaderText = "نمبر شمار";
            g.Columns["CompleteName"].HeaderText = "نام مشتری";
            g.Columns["KhewatType"].HeaderText = "قسم مالک";
            g.Columns["FardAreaPart"].HeaderText = "حصہ";
            g.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
            //g.Columns["TransactionType"].HeaderText = "بذرئعہ";
            // Hide Columns
            g.Columns["MushtriFareeqId"].Visible = false;
            g.Columns["TransactionType"].Visible = false;
            g.Columns["PersonId"].Visible = false;
            g.Columns["KhatooniKhewatFareeqRecId"].Visible = false;
            g.Columns["KhatooniId"].Visible = false;
            g.Columns["IntiqalId"].Visible = false;
            g.Columns["MurthinId"].Visible = false;
            g.Columns["KhewatTypeId"].Visible = false;
            g.Columns["FardPart_Bata"].Visible = false;
            g.Columns["Farad_Kanal"].Visible = false;
            g.Columns["Fard_Marla"].Visible = false;
            g.Columns["Fard_Sarsai"].Visible = false;
            g.Columns["Fard_Feet"].Visible = false;
            g.Columns["Mushtri_Area_KMSr"].Visible = false;
        }

        private void dgMushteryanKhatooni_CellClick(object sender, DataGridViewCellEventArgs e)
         {
              try
             {
                 DataGridView g = sender as DataGridView;
                 foreach (DataGridViewRow row in g.Rows)
                 {
                     if (g.SelectedRows.Count > 0)
                     {
                         if (row.Selected)
                         {
                             row.Cells[0].Value = 1;
                             string personId = row.Cells["PersonId"].Value.ToString();
                             string khatooniId = cmbKhatooniNo.SelectedValue.ToString();
                             if (this.dgMushteryanSel.Columns.Count < 1)
                             {
                                 foreach (DataGridViewColumn col in g.Columns)
                                 {
                                     this.dgMushteryanSel.Columns.Add(col.Name, col.HeaderText);
                                     // this.dgKhewatFreeqDetails.Columns[col.Name] = DataGridViewCheckBoxCell;
                                     //this.dgKhewatFreeqDetails.Columns.Add(col);
                                     
                                 }
                                 this.dgMushteryanSel.Columns.Insert(g.ColumnCount, new DataGridViewButtonColumn());
                                 this.dgMushteryanSel.Columns[g.ColumnCount].HeaderText = "خذف کریں";
                                 this.dgMushteryanSel.Columns[g.ColumnCount].Name = "ColDel";
                                 this.dgMushteryanSel.Columns.Insert(g.ColumnCount, new DataGridViewCheckBoxColumn());
                                 this.dgMushteryanSel.Columns[g.ColumnCount].HeaderText = "انتخاب برائے یکجا";
                                 this.dgMushteryanSel.Columns[g.ColumnCount].Name = "ColSel";
                                 
                             }
                             //this.dgKhewatFreeqDetails.Columns.Add().Add();
                             int i = dgMushteryanSel.Rows.Count;
                             bool exists = false;
                             if (dgMushteryanSel.Rows.Count > 0)
                             {
                                 foreach (DataGridViewRow r in dgMushteryanSel.Rows)
                                 {
                                     if (r.Cells["MushtriFareeqId"].Value.ToString() == row.Cells["MushtriFareeqId"].Value.ToString())
                                     {
                                         MessageBox.Show("مشتری پہلے سے موجود ہے", "مشتری پہلے سے موجود ہے", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         exists = true;
                                         break;
                                     }
                                     
                                 }
                                
                             }
                             if (!exists)
                             {
                                 this.dgMushteryanSel.Rows.Add();
                                 foreach (DataGridViewColumn col in g.Columns)
                                 {

                                     this.dgMushteryanSel.Rows[i].Cells[col.Name].Value = row.Cells[col.Name].Value.ToString();


                                 }
                                 PopulateGridViewMushteryan(dgMushteryanSel);
                             }
                            
                             
                         }
                         else
                         {
                             row.Cells[0].Value = 0;
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

        private void dgMushteryanSel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
            if (g.CurrentCell == g.CurrentRow.Cells["ColSel"])
            {
                foreach (DataGridViewRow row in g.Rows)
                {
                    row.Cells["ColSel"].Value = 0;
                }
                g.CurrentCell.Value = g.CurrentCell.Value != null ? (g.CurrentCell.Value.ToString() == "1" ? 0 : 1) : 1;

                MergDataKhanaKasht();

            }
            else if (g.CurrentCell == g.CurrentRow.Cells["ColDel"])
            {
                if (MessageBox.Show(" انتخاب کردہ ریکارڈ خذف کرنا چاہتے ہو؟", "خذف کریں", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    g.Rows.RemoveAt(g.CurrentRow.Index);

                }
            }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
        }
        private void MergDataKhanaKasht()
        {
            this.KulHissay = 0;
            this.KulRaqba = "0-0-0";
            string khewatMalikName = "";
            this.MushteriFareeqid = "0";
            float KulHissa = 0;
            int KulKanal = 0;
            int KulMarla = 0;
            float KulSarsai = 0;
            float KulSft = 0;

            foreach (DataGridViewRow row in dgMushteryanSel.Rows)
            {
                KulHissa += float.Parse(row.Cells["FardAreaPart"].Value.ToString());
                string[] Raqba = (row.Cells["Mushtri_Area_KMSqft"].Value.ToString().Split('-'));
                KulKanal += Convert.ToInt32(Raqba[0]);
                KulMarla += Convert.ToInt32(Raqba[1]);
                KulSft += float.Parse(Raqba[2]);

                if (row.Cells["ColSel"].Value.ToString() == "1")
                {
                    khewatMalikName = row.Cells["CompleteName"].Value.ToString();
                    MushteriFareeqid = row.Cells["MushtriFareeqId"].Value.ToString();
                }

            }
            KulSarsai += KulSft / float.Parse("30.25");
            this.lblMushteriName.Text = khewatMalikName;
            this.lblMushteriHisa.Text = KulHissa.ToString();
            this.KulHissayKhanakasht = KulHissa;
            this.lblMushteriRaqba.Text = cfs.SFTtoRqba(KulKanal, KulMarla, Convert.ToDecimal(KulSarsai));
            this.KulRaqbaKhanakasht = lblMushteriRaqba.Text;


        }

        private void btnSaveKhanakasht_Click(object sender, EventArgs e)
        {
            if (dgMushteryanSel.Rows.Count >= 2)
            {
                bool doMerg = false;
                foreach (DataGridViewRow r in dgMushteryanSel.Rows)
                {

                    if ((r.Cells["ColSel"].Value != null ? r.Cells["ColSel"].Value.ToString() : "0") == "1")
                    {
                        doMerg = true;
                        break;
                    }

                }
                if (doMerg)
                {
                    if (MessageBox.Show(" انتخاب کردہ ریکارڈ یکجا کرنا چاہتے ہے؟", "یکجا کریں", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // do Merg
                        foreach (DataGridViewRow r in dgMushteryanSel.Rows)
                        {

                            if ((r.Cells["ColSel"].Value != null ? r.Cells["ColSel"].Value.ToString() : "0") == "1")
                            {
                                string kgfId = r.Cells["MushtriFareeqId"].Value.ToString();
                                string personId = r.Cells["PersonId"].Value.ToString();
                                string KhatooniId = r.Cells["KhatooniId"].Value.ToString();
                                string FardAreaPart = this.KulHissayKhanakasht.ToString();
                                string khewatTypeId = r.Cells["KhewatTypeId"].Value.ToString();
                                string TransactionType = r.Cells["TransactionType"].Value.ToString();
                                string SeqNo = r.Cells["SeqNo"].Value.ToString();
                                string IntiqalId = r.Cells["IntiqalId"].Value.ToString();
                                string[] raqba = this.KulRaqbaKhanakasht.Split('-');
                                string kanal = raqba[0];
                                string Marla = raqba[1];
                                string sft = raqba[2];
                                string Sarsai = (float.Parse(sft) / (float)30.25).ToString();
                                string lastId = khatooni.SaveMushtriFareeqein(kgfId, "0",TransactionType,IntiqalId,KhatooniId, SeqNo, personId,"0", khewatTypeId,  FardAreaPart,"0", kanal, Marla, Sarsai, sft,  UsersManagments.UserId.ToString(), UsersManagments.UserName, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                                string MerginId = intiqal.SaveMushteryanMerginRecord(kgfId, kgfId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                            }
                            else
                            {
                                string kgfId = r.Cells["MushtriFareeqId"].Value.ToString();
                                string lastId = khatooni.DELETE_MushtriFareeqein(kgfId);
                                string MerginId = intiqal.SaveMushteryanMerginRecord(this.MushteriFareeqid, kgfId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                            }

                        }
                        MessageBox.Show("ملکان ریکارڈ یکجا ہو گیا۔");
                        this.dgMushteryanSel.Rows.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("یکجا کرنے کیلئے کسی ایک ریکارڈ جسمیں باقی یکجا کرنا چاہتے ہو، کا انتخاب کریں", "یکجا کرنا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("یکجا کرنے کیلئے کم از کم دو ریکارڈ کا انتخاب کریں", "یکجا کرنا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
