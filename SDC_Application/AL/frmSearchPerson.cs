
using System;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using System.Data;
using SDC_Application.BL;

namespace SDC_Application
{
    public partial class frmSearchPerson : Form
    {
        #region Class varialbes

       // ClientServiceClient client = new ClientServiceClient();
        LanguageConverter Lang = new LanguageConverter();
        Search Srch = new Search();
        Khatoonies kasht = new Khatoonies();
        DataView dvAfrad = new DataView();
        #endregion

        #region Properties
        public string MozaId { get; set; }
        public string PersonName { get; set; }
        public long PersonId { get; set; }
        public string QoamId { get; set; }
        public string CNIC { get; set; }
        public bool  isforShajraFb { get; set; }
        public string PersonNameForFB { get; set; }
        public int PersonFamilyStatusId { get; set; }


        public bool IsForKhata { get; set; }
        public string KhataId { get; set; }
        public int KhewatTypeId { get; set; }
        public string KhewatArea { get; set; }
        public string FardAreaPart { get; set; }
        public string FardBata { get; set; }
        public string  KhewatGroupFareeqId { get; set; }
        public string  khewatGroupId { get; set; }

        public bool isForKhatooni { get; set; }
        public string KhatooniId { get; set; }
        public string MushteriFareeqId { get; set; }
        //public string KhataId { get; set; }
        #endregion

        #region Default Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public frmSearchPerson()
        {
            InitializeComponent();
            this.IsForKhata = false;
        }
        #endregion
            
        #region Find Button Clicked
        /// <summary>
        /// filters the person list of moza for specied name and return all matching records by assigning 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            string PName = txtPersonaName.Text;
            string PCNIC = txtCNIC.Text;
            string PTyep="1";
            string MozaId = this.MozaId;
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            if (this.IsForKhata)
                {
                string KhataId = this.KhataId;
                dt = Srch.GetKhewatFareeqeinGroupByKhatta(KhataId);
                }
            else if (isForKhatooni)
            {
                dt = kasht.Get_MushtriFareeqein_By_KhatooniId(this.KhatooniId);
            }
            else if (isforShajraFb)
            {
                dt = Srch.GetSearchedAfardListFBShajra(MozaId, PName);
            }
            else
            {
                if (txtCNIC.Text.Trim().Length==0)
                {
                    dt = Srch.GetSearchAfradList(MozaId, PTyep, PName);
                }
                else
                {
                    dt = Srch.GetSearchAfradListByCNICSelf(MozaId, PTyep, PCNIC);
                }
            }
            dvAfrad = dt.AsDataView();

            if (this.IsForKhata)
                {
                    dt1 = dt.DefaultView.ToTable(true, "PersonId", "PersonName", "CNIC", "KhewatTypeId", "Khewat_Area", "FardAreaPart", "FardPart_Bata", "KhewatGroupFareeqId",
                        "KhewatGroupId");
                    dvAfrad = dt1.AsDataView();
                GridViewPersons.DataSource = dvAfrad;
                int count = GridViewPersons.Columns.Count;
                GridViewPersons.Columns["PersonName"].HeaderText = "نام افراد";
                GridViewPersons.Columns["Khewat_Area"].HeaderText = "رقبہ";
                GridViewPersons.Columns["KhewatTypeId"].Visible = false;
                GridViewPersons.Columns["FardAreaPart"].Visible = false;
                GridViewPersons.Columns["FardPart_Bata"].Visible = false;
                GridViewPersons.Columns["KhewatGroupFareeqId"].Visible = false;
                GridViewPersons.Columns["KhewatGroupId"].Visible = false;
                GridViewPersons.Columns["CNIC"].HeaderText = "شناختی کارڈ";
                }
            else if (isForKhatooni)
            {
                dt1 = dt.DefaultView.ToTable(true, "PersonId", "CompleteName", "KhewatTypeId", "Mushtri_Area_KMSqft", "FardAreaPart", "FardPart_Bata", "MushtriFareeqId");
                dvAfrad = dt1.AsDataView();
                GridViewPersons.DataSource = dvAfrad;
                int count = GridViewPersons.Columns.Count;
                GridViewPersons.Columns["CompleteName"].HeaderText = "نام افراد";
                GridViewPersons.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
                GridViewPersons.Columns["KhewatTypeId"].Visible = false;
                GridViewPersons.Columns["FardAreaPart"].HeaderText = "حصہ";
                GridViewPersons.Columns["FardPart_Bata"].Visible = false;
                GridViewPersons.Columns["MushtriFareeqId"].Visible = false;
            }
            else if (isforShajraFb)
            {
                GridViewPersons.DataSource = dvAfrad;
                GridViewPersons.Columns["PersonFullName"].HeaderText = "نام افراد";
                GridViewPersons.Columns["CNIC"].HeaderText = "شناختی کارڈ نمبر";
                GridViewPersons.Columns["QoamId"].Visible = false;
                GridViewPersons.Columns["PersonName"].Visible = false;
                GridViewPersons.Columns["FamilyNo"].HeaderText = "خاندان نمبر";
            }
            else
            {
                GridViewPersons.DataSource = dvAfrad;
                GridViewPersons.Columns["PersonFullName"].HeaderText = "نام افراد";
                GridViewPersons.Columns["CNIC"].HeaderText = "شناختی کارڈ نمبر";

            }
            GridViewPersons.Columns["PersonId"].Visible = false;
   
            //this.procGetSearchedAfradListResultBindingSource.DataSource = client.GetAfraadListByMozaByTypeByPersonName(this.MozaId, this.PersonType, this.txtPersonaName.Text.ToString());
        }
        #endregion

        private void txtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPersonaName.Clear();
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;

            }
        }

        #region Tooltip


        public void Tooltip()
        {
            toolTip1.SetToolTip(btnAccept, "منتخب شدہ فرد کا اندراج کریں");
            toolTip1.SetToolTip(btnCancel, "   واپس جائیں");
            toolTip1.SetToolTip(btnFind, "نام لکھ کر تلاش کریں");
        
        }
        #endregion

        #region Form Closing Button Actions
        /// <summary>
        /// assign selected person id and name to concerned properties and closes this form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (this.GridViewPersons.Rows.Count > 0)
            {

                this.PersonId = long.Parse(GridViewPersons.SelectedRows[0].Cells["PersonId"].Value.ToString());
                this.PersonName = GridViewPersons.SelectedRows[0].Cells[1].Value.ToString();
                
               if(IsForKhata)
                    {
                    this.KhewatArea = GridViewPersons.SelectedRows[0].Cells[2].Value.ToString();
                    this.KhewatTypeId = Convert.ToInt32(GridViewPersons.SelectedRows[0].Cells[3].Value);
                    this.FardAreaPart = GridViewPersons.SelectedRows[0].Cells[5].Value.ToString();
                    this.FardBata = GridViewPersons.SelectedRows[0].Cells[6].Value.ToString();
                    this.KhewatGroupFareeqId = GridViewPersons.SelectedRows[0].Cells["KhewatGroupFareeqId"].Value.ToString();
                    this.khewatGroupId = GridViewPersons.SelectedRows[0].Cells["KhewatGroupId"].Value.ToString();
                    }
                else if (isForKhatooni)
                {
                    this.KhewatArea = GridViewPersons.SelectedRows[0].Cells["Mushtri_Area_KMSqft"].Value.ToString();
                    this.KhewatTypeId = Convert.ToInt32(GridViewPersons.SelectedRows[0].Cells["KhewatTypeId"].Value);
                    this.FardAreaPart = GridViewPersons.SelectedRows[0].Cells["FardAreaPart"].Value.ToString();
                    this.FardBata = GridViewPersons.SelectedRows[0].Cells["FardPart_Bata"].Value.ToString();
                    this.MushteriFareeqId = GridViewPersons.SelectedRows[0].Cells["MushtriFareeqId"].Value.ToString();
                    //this.khewatGroupId = GridViewPersons.SelectedRows[0].Cells["KhewatGroupId"].Value.ToString();
                }
               else if (isforShajraFb)
               {
                   this.QoamId = GridViewPersons.SelectedRows[0].Cells["QoamId"].Value.ToString();
                   this.CNIC = GridViewPersons.SelectedRows[0].Cells["CNIC"].Value.ToString();
                   this.PersonNameForFB = GridViewPersons.SelectedRows[0].Cells["PersonName"].Value.ToString();
               }
                
                this.Close();
            }
            else
                this.Close();
        }

        /// <summary>
        /// close this form without any search result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        /// <summary>
        /// translate name form english to urdu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPersonaName_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtCNIC.Clear();
            if (e.KeyChar == Convert.ToChar((Keys.Back)))
            {

            }
            else
            {
                e.KeyChar = Lang.UrduChar(Convert.ToChar(e.KeyChar));
            }
        }

        private void frmSearchPerson_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);
           
            this.txtPersonaName.Focus();
            Tooltip();
        }

        private void txtPersonaName_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnFind;
        }
        private void GridViewPersons_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnAccept_Click(sender, e);
        }

        private void btnAndarajAfrad_Click(object sender, EventArgs e)
        {
            AL.frmAfradRegister afr = new AL.frmAfradRegister();
           // frmMain M = new frmMain();

            afr.MozaId = this.MozaId.ToString();
            afr.ShowDialog();

           //afr.MdiParent = M;
           //afr.WindowState = this.WindowState;
           //afr.Show();
            
           
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            string filter = this.txtSearchByName.Text;
            if (this.IsForKhata)
                {
                    dvAfrad.RowFilter = "PersonName LIKE '%" + filter + "%'";
                    GridViewPersons.DataSource = dvAfrad;

                }
            else if (isForKhatooni)
            {
                dvAfrad.RowFilter = "CompleteName LIKE '%" + filter + "%'";
                GridViewPersons.DataSource = dvAfrad;
            }
            else if (isforShajraFb)
            {
                dvAfrad.RowFilter = "PersonFullName LIKE '%" + filter + "%'";
                GridViewPersons.DataSource = dvAfrad;
            }
            else
            {
                dvAfrad.RowFilter = "PersonFullName LIKE '%" + filter + "%'";
                GridViewPersons.DataSource = dvAfrad;

            }
            
        }

      
 
    }
}
