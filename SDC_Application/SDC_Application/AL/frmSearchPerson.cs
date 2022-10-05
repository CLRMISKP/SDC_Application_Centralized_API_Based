
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
        #endregion

        #region Properties
        public string MozaId { get; set; }
        public string PersonName { get; set; }
        public string FatherName { get; set; }
        public int PersonId { get; set; }
        public string QoamId { get; set; }
        public string CNIC { get; set; }
        public bool  isforShajraFb { get; set; }
        public string PersonNameForFB { get; set; }


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
                dt = Srch.GetSearchAfradList(MozaId, PTyep, PName);
            }

            if (this.IsForKhata)
                {
                if (dt != null)
                {
                    dt1 = dt.DefaultView.ToTable(true, "PersonId", "PersonName", "CNIC", "KhewatTypeId", "Khewat_Area", "FardAreaPart", "FardPart_Bata", "KhewatGroupFareeqId",
                        "KhewatGroupId");
                    GridViewPersons.DataSource = dt1;
                    if (dt1 != null)
                    {
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
                }
                }
            else if (isForKhatooni)
            {
                if (dt != null)
                {
                    dt1 = dt.DefaultView.ToTable(true, "PersonId", "CompleteName", "KhewatTypeId", "Mushtri_Area_KMSqft", "FardAreaPart", "FardPart_Bata", "MushtriFareeqId");
                    GridViewPersons.DataSource = dt1;
                    if (dt1 != null)
                    {
                        int count = GridViewPersons.Columns.Count;
                        GridViewPersons.Columns["CompleteName"].HeaderText = "نام افراد";
                        GridViewPersons.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
                        GridViewPersons.Columns["KhewatTypeId"].Visible = false;
                        GridViewPersons.Columns["FardAreaPart"].HeaderText = "حصہ";
                        GridViewPersons.Columns["FardPart_Bata"].Visible = false;
                        GridViewPersons.Columns["MushtriFareeqId"].Visible = false;
                    }
                }
            }
            else if (isforShajraFb)
            {
                GridViewPersons.DataSource = dt;
                if (dt != null)
                {
                    GridViewPersons.Columns["PersonFullName"].HeaderText = "نام افراد";
                    GridViewPersons.Columns["CNIC"].HeaderText = "شناختی کارڈ نمبر";
                    GridViewPersons.Columns["QoamId"].Visible = false;
                    GridViewPersons.Columns["PersonName"].Visible = false;
                    GridViewPersons.Columns["Fathername"].Visible = false;
                }
            }
            else
            {
                GridViewPersons.DataSource = dt;
                if (dt != null)
                {
                    GridViewPersons.Columns["PersonFullName"].HeaderText = "نام افراد";
                }

            }
            if (dt != null)
            {
                GridViewPersons.Columns["PersonId"].Visible = false;
            }
   
            //this.procGetSearchedAfradListResultBindingSource.DataSource = client.GetAfraadListByMozaByTypeByPersonName(this.MozaId, this.PersonType, this.txtPersonaName.Text.ToString());
        }
        #endregion

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

                this.PersonId = Convert.ToInt32(GridViewPersons.SelectedRows[0].Cells["PersonId"].Value.ToString());
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
                   this.FatherName= GridViewPersons.SelectedRows[0].Cells["Fathername"].Value.ToString();
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

 
    }
}
