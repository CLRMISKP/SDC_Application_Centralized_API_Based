using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using SDC_Application.LanguageManager;
using SDC_Application.BL;

namespace SDC_Application
{
    public partial class frmKhatooniMushteryanFromKhatooni : Form
    {
        #region Class Variables
       /// <summary>
       /// Class variables
       /// </summary>

        DataTable KhatajatByMoza = new DataTable();
        Intiqal Intiqal = new Intiqal();
        AutoComplete auto = new AutoComplete();
        DataTable KhatooniesByKhata = new DataTable();
        Khatoonies khatooni = new Khatoonies();
        DataTable MushteryanByKhatooni = new DataTable();
        DataTable MushteryanByKhatooniNew = new DataTable();

        LanguageConverter Lang = new LanguageConverter();

        #endregion

        #region Properties

        public int NewKhatooniId { get; set; }
        public string MozaId { get; set; }
        public string IntiqalId { get; set; }
        #endregion

        #region Default Constructor
        /// <summary>
        /// default Constructor
        /// </summary>

        public frmKhatooniMushteryanFromKhatooni()
        {
            InitializeComponent();
        }
        #endregion

        #region Form Load Event
        /// <summary>
        /// Form Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void frmFardbyMozaSearch_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            try
            {
                //this.KhatajatByMoza = Intiqal.GetKhataJatForintiqalByMozaId(this.MozaId);
                this.KhatajatByMoza = Intiqal.GetIntiqalKhataJaatListByIntiqalId(IntiqalId);
                DataRow row = this.KhatajatByMoza.NewRow();
                row["IntiqalKhataId"] = 0;
                row["KhataNo"] = "- انتخاب کریں -";
                this.KhatajatByMoza.Rows.InsertAt(row, 0);
                cbokhataNo.DataSource = this.KhatajatByMoza;
                cbokhataNo.DisplayMember = "KhataNo";
                cbokhataNo.ValueMember = "IntiqalKhataId";

                this.MushteryanByKhatooniNew = khatooni.Get_MushtriFareeqein_By_KhatooniId(NewKhatooniId.ToString());
                this.gridviewNewKhatooniMushteryan.DataSource = this.MushteryanByKhatooniNew;
                this.PopulateGrid(this.gridviewNewKhatooniMushteryan);
               
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        #endregion

        private void gridviewIntiqalKhata_DoubleClick(object sender, EventArgs e)
        {
           
            
        }

        private void btnAmaldaramad_Click(object sender, EventArgs e)
        {
            try
            {
                int OldKhatooniId = Convert.ToInt32(cboKhatoonies.SelectedValue.ToString());
                string lastMushtriId= Intiqal.SaveMushteriFareeqainFromKhatooniToNewKhatooni(this.NewKhatooniId.ToString(), OldKhatooniId.ToString());
                this.btnAmaldaramad.Enabled = false;
                this.MushteryanByKhatooniNew = khatooni.Get_MushtriFareeqein_By_KhatooniId(NewKhatooniId.ToString());
                this.gridviewNewKhatooniMushteryan.DataSource=this.MushteryanByKhatooniNew;
                this.PopulateGrid(this.gridviewNewKhatooniMushteryan);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int KhataId = Convert.ToInt32(cbokhataNo.SelectedValue.ToString());
                this.KhatooniesByKhata = khatooni.GetKhatooniNosListbyKhataId(KhataId.ToString());
                DataRow row = this.KhatooniesByKhata.NewRow();
                row["KhatooniId"] = 0;
                row["KhatooniNo"] = "- انتخاب کریں -";
                this.KhatooniesByKhata.Rows.InsertAt(row, 0);
                cboKhatoonies.DataSource = this.KhatooniesByKhata;
                cboKhatoonies.DisplayMember = "KhatooniNo";
                cboKhatoonies.ValueMember = "KhatooniId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboKhatoonies_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string khatooniId=cboKhatoonies.SelectedValue.ToString();
                this.MushteryanByKhatooni = khatooni.Get_MushtriFareeqein_By_KhatooniId(khatooniId);
                gridviewOldKhatooniMushteryan.DataSource = this.MushteryanByKhatooni;
                this.PopulateGrid(gridviewOldKhatooniMushteryan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void PopulateGrid(DataGridView g)
        {
            
            g.Columns["CompleteName"].HeaderText = "نام مشتری";
            g.Columns["KhewatType"].HeaderText = "قسم مالک";
            g.Columns["FardAreaPart"].HeaderText = "حصہ";
            g.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
            // Hide Columns
            g.Columns["MushtriFareeqId"].Visible = false;
            g.Columns["PersonId"].Visible = false;
            g.Columns["SeqNo"].Visible = false;
            g.Columns["KhatooniKhewatFareeqRecId"].Visible = false;
            g.Columns["KhatooniId"].Visible = false;
            g.Columns["TransactionType"].Visible = false;
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

        private void gridviewNewKhatooniMushteryan_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataGridView g =sender as DataGridView;
                if (g.SelectedRows.Count > 0)
                {
                    string mushterifareeqid = g.SelectedRows[0].Cells["MushtriFareeqId"].Value.ToString();
                    if (DialogResult.Yes == MessageBox.Show("کیا آپ " + g.SelectedRows[0].Cells["CompleteName"].Value.ToString() + "حذف کرنا چاہتے ہے۔ ؟", "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                    {
                        khatooni.DELETE_MushtriFareeqein(mushterifareeqid);
                        this.MushteryanByKhatooniNew.Clear();
                        this.MushteryanByKhatooniNew = khatooni.Get_MushtriFareeqein_By_KhatooniId(NewKhatooniId.ToString());
                        this.gridviewNewKhatooniMushteryan.DataSource = this.MushteryanByKhatooniNew;
                        this.PopulateGrid(this.gridviewNewKhatooniMushteryan);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDelMushteri_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("کیا آپ موجودہ کھتونی کے تمام مشتریان حذف کرنا چاہتے ہے۔ ؟", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                khatooni.DELETE_MushtriFareeqein_By_KhatooniId(NewKhatooniId.ToString());
                this.MushteryanByKhatooniNew.Clear();
                this.MushteryanByKhatooniNew = khatooni.Get_MushtriFareeqein_By_KhatooniId(NewKhatooniId.ToString());
                this.gridviewNewKhatooniMushteryan.DataSource = this.MushteryanByKhatooniNew;
                this.PopulateGrid(this.gridviewNewKhatooniMushteryan);
            }
        }
    }
}
