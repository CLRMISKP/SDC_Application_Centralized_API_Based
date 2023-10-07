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

namespace SDC_Application
{
    public partial class frmPersonKhattaSearch : Form
    {
        #region Class Varialbes

        //ClientServiceClient client = new ClientServiceClient();
        Malikan_n_Khattajat MalikanKatajat = new Malikan_n_Khattajat();
        datagrid_controls datagridcontrols = new datagrid_controls();
        
        DataTable dt = new DataTable();
        public string PersonName { get; set; }
        public string MozaID { get; set; }
        public string PersonId { get; set; }

        #endregion
        public frmPersonKhattaSearch()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //   this.SearchedKhattaDataBinding.DataSource = client.GetKhattajatByPersonId(CurrentUser.MozaId.ToString(), this.PersonId).ToList();
        }

        private void frmPersonKhattaSearch_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            lblPersonName.Text = PersonName;
         
                Proc_Get_Person_KhataJats();
            
           
            this.lblTotalKhattajat.Text = CalculateTotalKhatta();
        }
        public void Proc_Get_Person_KhataJats()
        {
         
            dt = MalikanKatajat.GetPersonKhattajat(MozaID, PersonId);
            grdPersonKatajats.DataSource = dt;
            PopulateGird();
           

            
        }
        #region  DataGrid Filling
        public void PopulateGird()
        {
            this.grdPersonKatajats.Columns["KhataNo"].DisplayIndex = 0;
            grdPersonKatajats.Columns["Khata_Area"].DisplayIndex = 1;
            grdPersonKatajats.Columns["TotalParts"].DisplayIndex = 2;
            grdPersonKatajats.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
            grdPersonKatajats.Columns["Khata_Area"].HeaderText = "کل رقبہ";
            grdPersonKatajats.Columns["TotalParts"].HeaderText = "کل حصے";

            grdPersonKatajats.Columns["RegisterHaqdaranId"].Visible = false;
            grdPersonKatajats.Columns["RegisterHqDKhataId"].Visible = false;
            grdPersonKatajats.Columns["Kanal"].Visible = false;
            grdPersonKatajats.Columns["Marla"].Visible = false;
            grdPersonKatajats.Columns["sarsai"].Visible = false;

            grdPersonKatajats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grdPersonKatajats.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPersonKatajats.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdPersonKatajats.RowHeadersDefaultCellStyle.Font = new Font(Font, FontStyle.Bold);
            grdPersonKatajats.SelectionMode = DataGridViewSelectionMode.FullRowSelect;  
            datagridcontrols.colorrbackgrid(grdPersonKatajats);
        }
        private string CalculateTotalKhatta()
        {
                int NoOfKhattas = 0;

                foreach (DataGridViewRow row in grdPersonKatajats.Rows)
                {
                    NoOfKhattas = NoOfKhattas + 1;
                }
                return NoOfKhattas.ToString();
        }
        #endregion
        //}
    }
}
