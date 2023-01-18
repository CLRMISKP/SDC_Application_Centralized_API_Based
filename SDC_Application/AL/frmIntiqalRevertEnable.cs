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
    public partial class frmIntiqalRevertEnable : Form
    {
        #region Class Variables

        public string IntiqalId { get; set; }
        public bool IntiqalPending { get; set; }
        public bool IntiqalAmalDaramad { get; set; }
        public bool Amaldaramadkhata { get; set; }
        Intiqal intiqal = new Intiqal();
        DataTable dtSellersBeforeAmal = new DataTable();
        DataTable dtSellersBeforeAmalKK = new DataTable();
        DataTable dtSellersDependency = new DataTable();
        DataTable dtSellersAfterAmal = new DataTable();
        DataTable dtSellersAfterAmalKK = new DataTable();
        DataTable dtBuyersBeforeAmal = new DataTable();
        DataTable dtBuyersBeforeAmalKK = new DataTable();
        DataTable dtBuyersAfterAmal = new DataTable();
        DataTable dtBuyersAfterAmalKK = new DataTable();
        DataTable dtIntiqalKhatas = new DataTable();
        DataTable dtAllKhewatFareeqain = new DataTable();
        DataView view;
        public string IntiqalKhataId { get; set; }
        public string IntiqalKhataRecId { get; set; }
        public bool Khanakasht { get; set; }
        public bool KhanaMalkiat { get; set; }
        public bool MalkiatKasht { get; set; }
        public string IntiqalKhatoniRecid { get; set; }
        public string MozaId { get; set; }

        public bool isAttested { get; set; }
        public int Teh_Report;
        public string isGardawar { get; set; }

        LanguageConverter lang = new LanguageConverter();

        #endregion
        public frmIntiqalRevertEnable()
        {
            InitializeComponent();
        }

        #region Form Load Event
        
        #endregion
        private void frmIntiqalAmalDaramadByKhata_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            // Get Intiqal Khatajat and Fill Grid view
            if (this.IntiqalAmalDaramad)
            {
                //btnAmaldaramad.Enabled = false;
                lblMutStatus.Text = "عملدرامد شدہ";
                lblMutStatus.ForeColor = Color.Green;
            }
            else
            {
               // btnAmaldaramad.Enabled = true;
                lblMutStatus.Text = "زیر تجویز";
                lblMutStatus.ForeColor = Color.Red;
                //if (this.isAttested && this.isGardawar.ToString() != "0" && this.Teh_Report > 10)
                //{
                //    btnAmaldaramad.Enabled = true;
                //}
                //else
                //{
                //    btnAmaldaramad.Enabled = false;
                //}
            }
            this.Fill_InteqalKhataGrid();
            this.Fill_Khata_DropDown();
        }

        #region Custom Methods

        #region Fill Intiqal Khatajat Grid list

        public void Fill_InteqalKhataGrid()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = intiqal.GetIntiqalKhataJaatListByIntiqalId(IntiqalId);
                dgInteqalKhattas.DataSource = dt;
                dgInteqalKhattas.Columns["IntiqalId"].Visible = false;
                dgInteqalKhattas.Columns["IntiqalKhataId"].Visible = false;
                dgInteqalKhattas.Columns["IntiqalKhataRecId"].Visible = false;
                dgInteqalKhattas.Columns["AmaldaramadStatus"].Visible = false;
                dgInteqalKhattas.Columns["AmaldaramadDate"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Get Intiqal Khatoonies By Khata

         public void GetKhatoni(string IntiqalKhataId)
        {
            try
            {
                DataTable dt = new DataTable();
                //dt = intiqal.GetKhatoniDetails(IntiqalKhataId);
                //grdKhatoniDetails.DataSource = dt;
                //grdKhatoniDetails.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                //grdKhatoniDetails.Columns["KhatooniKashtkaranFullDetail_New"].HeaderText = "کھتونی نمبر";
                //grdKhatoniDetails.Columns["KhatooniKashtkaranFullDetail_New"].Visible = false;
                //grdKhatoniDetails.Columns["IntiqalKhatooniRecId"].Visible = false;
                //grdKhatoniDetails.Columns["KhatooniId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Populate Grid Seller List Before Amal

         public void PopulateGridSellersBeforeAmal()
         {
             try
             {
                 dgSellersBeforeAmal.Columns["PersonName"].DisplayIndex = 1;
                 dgSellersBeforeAmal.Columns["KhewatType"].DisplayIndex = 10;
                 dgSellersBeforeAmal.Columns["Seller_Total_Hissa"].DisplayIndex = 2;
                 dgSellersBeforeAmal.Columns["Seller_Total_Area"].DisplayIndex = 3;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Hissa"].DisplayIndex = 4;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Area"].DisplayIndex = 5;
                 dgSellersBeforeAmal.Columns["PersonName"].HeaderText = "نام مالک";
                 dgSellersBeforeAmal.Columns["Seller_Total_Hissa"].HeaderText = "کل حصہ";
                 dgSellersBeforeAmal.Columns["Seller_Total_Area"].HeaderText = "کل رقبہ";
                 dgSellersBeforeAmal.Columns["Seller_Sold_Hissa"].HeaderText = " حصہ منتقلہ";
                 dgSellersBeforeAmal.Columns["Seller_Sold_Area"].HeaderText = "رقبہ منتقلہ";
                 dgSellersBeforeAmal.Columns["IntiqalSellerRecId"].Visible = false;
                 dgSellersBeforeAmal.Columns["IntiqalKhataRecId"].Visible = false;
                 dgSellersBeforeAmal.Columns["IntiqalSellerPersonId"].Visible = false;
                 dgSellersBeforeAmal.Columns["SellerPersonDied"].Visible = false;
                 dgSellersBeforeAmal.Columns["SellerPersonDeathDate"].Visible = false;
                 dgSellersBeforeAmal.Columns["IntiqalKhatooniRecId"].Visible = false;
                 dgSellersBeforeAmal.Columns["MushtriFareeqId"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Total_Marla"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Total_Kanal"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Total_Sarsai"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Total_Feet"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Kanal"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Marla"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Sarsai"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Feet"].Visible = false;
                 dgSellersBeforeAmal.Columns["KhewatTypeId"].Visible = false;
                 dgSellersBeforeAmal.Columns["KhewatGroupFareeqId"].Visible = false;
                 dgSellersBeforeAmal.Columns["KhewatType"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Total_Hissa"].Width=60;
                 dgSellersBeforeAmal.Columns["Seller_Total_Area"].Width=60;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Hissa"].Width=60;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Area"].Width=80;
                 dgSellersBeforeAmal.Columns[0].Width = 80;
                 dgSellersBeforeAmal.Columns[0].DisplayIndex = 6;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }


         public void PopulateGridSellersBeforeAmalKK()
         {
             try
             {
                 dgSellersBeforeAmal.Columns["PersonName"].DisplayIndex = 1;
                 dgSellersBeforeAmal.Columns["KhatooniNo"].DisplayIndex = 2;
                 dgSellersBeforeAmal.Columns["KhewatType"].DisplayIndex = 10;
                 dgSellersBeforeAmal.Columns["Seller_Total_Hissa"].DisplayIndex = 3;
                 dgSellersBeforeAmal.Columns["Seller_Total_Area"].DisplayIndex = 4;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Hissa"].DisplayIndex = 5;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Area"].DisplayIndex = 6;
                 dgSellersBeforeAmal.Columns["PersonName"].HeaderText = "نام مالک";
                 dgSellersBeforeAmal.Columns["KhatooniNo"].HeaderText = "کھتونی";
                 dgSellersBeforeAmal.Columns["Seller_Total_Hissa"].HeaderText = "کل حصہ";
                 dgSellersBeforeAmal.Columns["Seller_Total_Area"].HeaderText = "کل رقبہ";
                 dgSellersBeforeAmal.Columns["Seller_Sold_Hissa"].HeaderText = " حصہ منتقلہ";
                 dgSellersBeforeAmal.Columns["Seller_Sold_Area"].HeaderText = "رقبہ منتقلہ";
                 dgSellersBeforeAmal.Columns["IntiqalSellerRecId"].Visible = false;
                 dgSellersBeforeAmal.Columns["IntiqalKhataRecId"].Visible = false;
                 dgSellersBeforeAmal.Columns["IntiqalSellerPersonId"].Visible = false;
                 dgSellersBeforeAmal.Columns["SellerPersonDied"].Visible = false;
                 dgSellersBeforeAmal.Columns["SellerPersonDeathDate"].Visible = false;
                 dgSellersBeforeAmal.Columns["IntiqalKhatooniRecId"].Visible = false;
                 dgSellersBeforeAmal.Columns["MushtriFareeqId"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Total_Marla"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Total_Kanal"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Total_Sarsai"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Total_Feet"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Kanal"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Marla"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Sarsai"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Feet"].Visible = false;
                 dgSellersBeforeAmal.Columns["KhewatTypeId"].Visible = false;
                 dgSellersBeforeAmal.Columns["KhewatGroupFareeqId"].Visible = false;
                 dgSellersBeforeAmal.Columns["KhewatType"].Visible = false;
                 dgSellersBeforeAmal.Columns["Seller_Total_Hissa"].Width = 60;
                 dgSellersBeforeAmal.Columns["Seller_Total_Area"].Width = 60;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Hissa"].Width = 60;
                 dgSellersBeforeAmal.Columns["Seller_Sold_Area"].Width = 80;
                 dgSellersBeforeAmal.Columns["KhatooniNo"].Width = 60;
                 dgSellersBeforeAmal.Columns[0].Width = 80;
                 dgSellersBeforeAmal.Columns[0].DisplayIndex = 6;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
         #endregion

        #region Fill Intiqal Seller List Before Amal
         public void FillGridIntiqalSellers(string IntiqalKhattaRecId, string IntiqalKhatooniRecId)
         {
             try
             {
                 string KhatooniRecId = IntiqalKhatooniRecId != null ? IntiqalKhatooniRecId : "-1";
                 dtSellersBeforeAmal = intiqal.GetintiqalSellersListByKhataRecId(IntiqalKhattaRecId, KhatooniRecId, KhanaMalkiat.ToString());
                 // dt = Intiqal.GetintiqalSellersListByKhataRecId(IntiqalKhataRecId);
                 if (dtSellersBeforeAmal != null)
                 {
                     dgSellersBeforeAmal.DataSource = dtSellersBeforeAmal;
                     PopulateGridSellersBeforeAmal();
                     foreach (DataGridViewRow dgrow in dgSellersBeforeAmal.Rows)
                     {
                         foreach(DataRow row in dtSellersDependency.Rows)
                         {                        
                             if (row["KhewatGroupFareeqId"].ToString() == dgrow.Cells["KhewatGroupFareeqId"].Value.ToString())
                             {
                                 dgrow.Cells["colDependency"].Value = row["IntiqalNo"].ToString();
                                 dgSellersBeforeAmal.Columns["colDependency"].Visible = true;
                             }
                         }
                     }

                 }
                 else
                 {
                     MessageBox.Show("کوئی ریکارڈ نہں ملا", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         public void FillGridIntiqalSellersKK(string IntiqalKhattaRecId)
         {
             try
             {
                 
                 dtSellersBeforeAmalKK = intiqal.GetintiqalSellersListByKhataRecIdKK(IntiqalKhattaRecId);
                 // dt = Intiqal.GetintiqalSellersListByKhataRecId(IntiqalKhataRecId);
                 if (dtSellersBeforeAmalKK != null)
                 {
                     dgSellersBeforeAmal.DataSource = dtSellersBeforeAmalKK;
                     PopulateGridSellersBeforeAmalKK();
                     

                 }
                 else
                 {
                     MessageBox.Show("کوئی ریکارڈ نہں ملا", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
         #endregion

         #region Check Intiqal Seller Dependency

         private void CheckIntiqalSellerDepedency(string intiqalKhataid, string intiqalKhataRecid, string intiqalid)
         {
             this.dtSellersDependency = intiqal.GetIntiqalSellersDependency(intiqalKhataid, intiqalKhataRecid, intiqalid);      
         }

         #endregion

         #region Fill Intiqal Seller List After Amal
         public void FillGridIntiqalSellersAfterAmal(string IntiqalKhattaRecId, string IntiqalKhatooniRecId)
         {
             try
             {
                 string KhatooniRecId = IntiqalKhatooniRecId != null ? IntiqalKhatooniRecId : "-1";
                 dtSellersAfterAmal = intiqal.GetintiqalSellersListAfterAmaldaramad(IntiqalKhattaRecId, KhatooniRecId, KhanaMalkiat.ToString());
                 // dt = Intiqal.GetintiqalSellersListByKhataRecId(IntiqalKhataRecId);
                 if (dtSellersAfterAmal != null)
                 {
                     dgSellersAfterAmal.DataSource = dtSellersAfterAmal;
                     PopulateGridSellersAfterAmal();
                 }
                 else
                 {
                     MessageBox.Show("کوئی ریکارڈ نہں ملا", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         public void FillGridIntiqalSellersAfterAmalKK(string IntiqalKhattaRecId)
         {
             try
             {
                 
                 dtSellersAfterAmalKK = intiqal.GetintiqalSellersListAfterAmaldaramadKK(IntiqalKhattaRecId);
                
                 if (dtSellersAfterAmalKK != null)
                 {
                     dgSellersAfterAmal.DataSource = dtSellersAfterAmalKK;
                     PopulateGridSellersAfterAmalKK();
                 }
                 else
                 {
                     MessageBox.Show("کوئی ریکارڈ نہں ملا", "ریکارڈ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         public void PopulateGridSellersAfterAmal()
         {
             try
             {
                 dgSellersAfterAmal.Columns["PersonName"].DisplayIndex = 1;
                 dgSellersAfterAmal.Columns["Fareeq_Hissa"].DisplayIndex = 2;
                 dgSellersAfterAmal.Columns["Fareeq_Area"].DisplayIndex = 3;
                 dgSellersAfterAmal.Columns["PersonName"].HeaderText = "نام مالک";
                 dgSellersAfterAmal.Columns["Fareeq_Hissa"].HeaderText = "حصہ";
                 dgSellersAfterAmal.Columns["Fareeq_Area"].HeaderText = "رقبہ";
                 dgSellersAfterAmal.Columns["RecStatus"].HeaderText = "حالت";
                 dgSellersAfterAmal.Columns["IntiqalSellerRecId"].Visible = false;
                 dgSellersAfterAmal.Columns["IntiqalKhataRecId"].Visible = false;
                 dgSellersAfterAmal.Columns["IntiqalSellerPersonId"].Visible = false;
                 dgSellersAfterAmal.Columns["IntiqalKhatooniRecId"].Visible = false;
                 dgSellersAfterAmal.Columns["MushtriFareeqId"].Visible = false;
                 dgSellersAfterAmal.Columns["KhewatGroupFareeqId"].Visible = false;
                 dgSellersAfterAmal.Columns["Fareeq_Hissa"].Width = 70;
                 dgSellersAfterAmal.Columns["Fareeq_Area"].Width=70;
                 dgSellersAfterAmal.Columns["RecStatus"].Width=70;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         public void PopulateGridSellersAfterAmalKK()
         {
             try
             {
                 dgSellersAfterAmal.Columns["PersonName"].DisplayIndex = 1;
                 dgSellersAfterAmal.Columns["KhatooniNo"].DisplayIndex = 2;
                 dgSellersAfterAmal.Columns["Fareeq_Hissa"].DisplayIndex = 3;
                 dgSellersAfterAmal.Columns["Fareeq_Area"].DisplayIndex = 4;
                 dgSellersAfterAmal.Columns["PersonName"].HeaderText = "نام مالک";
                 dgSellersAfterAmal.Columns["KhatooniNo"].HeaderText = "کھتونی";
                 dgSellersAfterAmal.Columns["Fareeq_Hissa"].HeaderText = "حصہ";
                 dgSellersAfterAmal.Columns["Fareeq_Area"].HeaderText = "رقبہ";
                 dgSellersAfterAmal.Columns["RecStatus"].HeaderText = "حالت";
                 dgSellersAfterAmal.Columns["IntiqalSellerRecId"].Visible = false;
                 dgSellersAfterAmal.Columns["IntiqalKhataRecId"].Visible = false;
                 dgSellersAfterAmal.Columns["IntiqalSellerPersonId"].Visible = false;
                 dgSellersAfterAmal.Columns["IntiqalKhatooniRecId"].Visible = false;
                 dgSellersAfterAmal.Columns["MushtriFareeqId"].Visible = false;
                 dgSellersAfterAmal.Columns["KhewatGroupFareeqId"].Visible = false;
                 dgSellersAfterAmal.Columns["Fareeq_Hissa"].Width = 70;
                 dgSellersAfterAmal.Columns["Fareeq_Area"].Width = 70;
                 dgSellersAfterAmal.Columns["RecStatus"].Width = 70;
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
         #endregion

         #region Fill Grid By Buyers List Before Amal

         public void FillgridByBuyerList()
         {
             try
             {
                 string IntiqalKhattaRecId = this.IntiqalKhataRecId;
                 string KhatooniRecId = this.IntiqalKhatoniRecid != null && this.IntiqalKhatoniRecid!="" ? this.IntiqalKhatoniRecid : "-1";
                 dtBuyersBeforeAmal = intiqal.GetIntiqalBuyersByIntiqalKhataRecId(IntiqalKhattaRecId, KhatooniRecId, KhanaMalkiat.ToString());
                 dgBuyersBeforeAmal.DataSource = dtBuyersBeforeAmal;
                 PopulateBuyerGrid();

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         public void FillgridByBuyerListKK()
         {
             try
             {
                 string IntiqalKhattaRecId = this.IntiqalKhataRecId;
                 
                 dtBuyersBeforeAmalKK = intiqal.GetIntiqalBuyersByIntiqalKhataRecIdKK(IntiqalKhattaRecId);
                 dgBuyersBeforeAmal.DataSource = dtBuyersBeforeAmalKK;
                 PopulateBuyerGridKK();

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         public void PopulateBuyerGrid()
         {
             dgBuyersBeforeAmal.Columns["IntiqalBuyerRecId"].Visible = false;
             dgBuyersBeforeAmal.Columns["IntiqalKhataRecId"].Visible = false;
             dgBuyersBeforeAmal.Columns["IntiqalBuyerPersonId"].Visible = false;
             dgBuyersBeforeAmal.Columns["Buyer_Hissa"].HeaderText = "حصہ";
             dgBuyersBeforeAmal.Columns["Buyer_Kanal"].Visible = false;
             dgBuyersBeforeAmal.Columns["Buyer_Marla"].Visible = false;
             dgBuyersBeforeAmal.Columns["Buyer_Sarsai"].Visible = false;
             dgBuyersBeforeAmal.Columns["Buyer_Feet"].Visible = false;
             dgBuyersBeforeAmal.Columns["IntiqalKhatooniRecId"].Visible = false;
             dgBuyersBeforeAmal.Columns["Buyer_Area"].HeaderText = "رقبہ";
             dgBuyersBeforeAmal.Columns["PersonName"].HeaderText = "نام";
             dgBuyersBeforeAmal.Columns["KhewatType"].Visible=false;
             dgBuyersBeforeAmal.Columns["Rishta"].Visible = false;
             dgBuyersBeforeAmal.Columns["RishtaId"].Visible = false;
             dgBuyersBeforeAmal.Columns["KhewatTypeId"].Visible = false;
             dgBuyersBeforeAmal.Columns["PersonName"].DisplayIndex = 0;
             dgBuyersBeforeAmal.Columns["Buyer_Hissa"].Width = 70;
             dgBuyersBeforeAmal.Columns["Buyer_Area"].Width = 90;
         }

         public void PopulateBuyerGridKK()
         {
             dgBuyersBeforeAmal.Columns["IntiqalBuyerRecId"].Visible = false;
             dgBuyersBeforeAmal.Columns["IntiqalKhataRecId"].Visible = false;
             dgBuyersBeforeAmal.Columns["IntiqalBuyerPersonId"].Visible = false;
             dgBuyersBeforeAmal.Columns["Buyer_Hissa"].HeaderText = "حصہ";
             dgBuyersBeforeAmal.Columns["Buyer_Kanal"].Visible = false;
             dgBuyersBeforeAmal.Columns["Buyer_Marla"].Visible = false;
             dgBuyersBeforeAmal.Columns["Buyer_Sarsai"].Visible = false;
             dgBuyersBeforeAmal.Columns["Buyer_Feet"].Visible = false;
             dgBuyersBeforeAmal.Columns["IntiqalKhatooniRecId"].Visible = false;
             dgBuyersBeforeAmal.Columns["Buyer_Area"].HeaderText = "رقبہ";
             dgBuyersBeforeAmal.Columns["PersonName"].HeaderText = "نام";
             dgBuyersBeforeAmal.Columns["KhatooniNo"].HeaderText = "کھتونی";
             dgBuyersBeforeAmal.Columns["KhewatType"].Visible = false;
             dgBuyersBeforeAmal.Columns["Rishta"].Visible = false;
             dgBuyersBeforeAmal.Columns["RishtaId"].Visible = false;
             dgBuyersBeforeAmal.Columns["KhewatTypeId"].Visible = false;
             dgBuyersBeforeAmal.Columns["PersonName"].DisplayIndex = 0;
             dgBuyersBeforeAmal.Columns["KhatooniNo"].DisplayIndex = 1;
             dgBuyersBeforeAmal.Columns["Buyer_Hissa"].Width = 70;
             dgBuyersBeforeAmal.Columns["Buyer_Area"].Width = 90;
         }

         #endregion

         #region Fill Grid By Buyers List After Amal

         public void FillgridByBuyerListAmaldaramad()
         {
             try
             {
                 string IntiqalKhattaRecId = this.IntiqalKhataRecId;
                 string KhatooniRecId = this.IntiqalKhatoniRecid != null && this.IntiqalKhatoniRecid != "" ? this.IntiqalKhatoniRecid : "-1";
                 dtBuyersAfterAmal = intiqal.GetIntiqalBuyersAmaldaramad(IntiqalKhattaRecId, KhatooniRecId, KhanaMalkiat.ToString());
                 dgBuyersAfterAmal.DataSource = dtBuyersAfterAmal;
                 PopulateBuyerGridAmaldaramad();

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         public void FillgridByBuyerListAmaldaramadKK()
         {
             try
             {
                 string IntiqalKhattaRecId = this.IntiqalKhataRecId;
                
                 dtBuyersAfterAmalKK = intiqal.GetIntiqalBuyersAmaldaramadKK(IntiqalKhattaRecId);
                 dgBuyersAfterAmal.DataSource = dtBuyersAfterAmalKK;
                 PopulateBuyerGridAmaldaramadKK();

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }
         public void PopulateBuyerGridAmaldaramad()
         {
             dgBuyersAfterAmal.Columns["Buyer_Hissa"].HeaderText = "حصہ";
             dgBuyersAfterAmal.Columns["Buyer_Area"].HeaderText = "رقبہ";
             dgBuyersAfterAmal.Columns["PersonName"].HeaderText = " نام مالک";
             dgBuyersAfterAmal.Columns["RecStatus"].HeaderText = "حالت";
             dgBuyersAfterAmal.Columns["PersonName"].DisplayIndex = 0;
             dgBuyersAfterAmal.Columns["Buyer_Hissa"].Width = 70;
             dgBuyersAfterAmal.Columns["Buyer_Area"].Width = 70;
             dgBuyersAfterAmal.Columns["RecStatus"].Width = 100;
             dgBuyersAfterAmal.Columns["PersonId"].Visible = false;
         }

         public void PopulateBuyerGridAmaldaramadKK()
         {
             dgBuyersAfterAmal.Columns["Buyer_Hissa"].HeaderText = "حصہ";
             dgBuyersAfterAmal.Columns["Buyer_Area"].HeaderText = "رقبہ";
             dgBuyersAfterAmal.Columns["PersonName"].HeaderText = " نام مالک";
             dgBuyersAfterAmal.Columns["KhatooniNo"].HeaderText = " کھتونی";
             dgBuyersAfterAmal.Columns["RecStatus"].HeaderText = "حالت";
             dgBuyersAfterAmal.Columns["PersonName"].DisplayIndex = 0;
             dgBuyersAfterAmal.Columns["KhatooniNo"].DisplayIndex = 1;
             dgBuyersAfterAmal.Columns["Buyer_Hissa"].Width = 70;
             dgBuyersAfterAmal.Columns["Buyer_Area"].Width = 70;
             dgBuyersAfterAmal.Columns["RecStatus"].Width = 100;
             dgBuyersAfterAmal.Columns["PersonId"].Visible = false;
         }

         #endregion

         #endregion

         #region Form Controls Events

         private void dgInteqalKhattas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                foreach (DataGridViewRow row in g.Rows)
                {
                    if (dgInteqalKhattas.SelectedRows.Count > 0)
                    {
                        if (row.Selected)
                        {
                            row.Cells["colChoose"].Value = 1;
                            this.IntiqalKhataRecId = row.Cells["IntiqalKhataRecId"].Value.ToString();
                            IntiqalKhataId = row.Cells["IntiqalKhataId"].Value.ToString();
                            if (IntiqalKhataId != string.Empty)
                            {
                                if (Khanakasht)
                                {
                                    this.FillGridIntiqalSellersKK(IntiqalKhataRecId);
                                    this.FillGridIntiqalSellersAfterAmalKK(IntiqalKhataRecId);
                                    FillgridByBuyerListKK();
                                    FillgridByBuyerListAmaldaramadKK();

                                    this.Amaldaramadkhata = Convert.ToBoolean(row.Cells["AmaldaramadStatus"].Value);
                                    DateTime AmaldaramadDate = Convert.ToDateTime(row.Cells["AmaldaramadDate"].Value);
                                    if (this.Amaldaramadkhata)
                                    {
                                        this.btnAmaldaramad.Enabled = false;
                                        this.lblMutStatus.Text = "عملدرامد شدہ۔" + AmaldaramadDate.ToShortDateString();
                                        this.lblMutStatus.ForeColor = Color.Green;
                                    }
                                    else
                                    {

                                        this.lblMutStatus.Text = "زیر تجویز۔";
                                        this.lblMutStatus.ForeColor = Color.Red;
                                        if (this.isAttested && this.isGardawar.ToString() != "0" && this.Teh_Report > 10)
                                        {
                                            btnAmaldaramad.Enabled = true;
                                        }
                                        else
                                        {
                                            btnAmaldaramad.Enabled = false;
                                        }
                                    }
                                }

                                if (KhanaMalkiat)
                                {
                                    this.CheckIntiqalSellerDepedency(IntiqalKhataId, IntiqalKhataRecId, this.IntiqalId);
                                    this.FillGridIntiqalSellers(IntiqalKhataRecId, IntiqalKhatoniRecid);
                                    this.FillGridIntiqalSellersAfterAmal(IntiqalKhataRecId, IntiqalKhatoniRecid);
                                    FillgridByBuyerList();
                                    FillgridByBuyerListAmaldaramad();
                                    this.Amaldaramadkhata = Convert.ToBoolean(row.Cells["AmaldaramadStatus"].Value);
                                    DateTime AmaldaramadDate =Convert.ToDateTime(row.Cells["AmaldaramadDate"].Value);
                                    if (this.Amaldaramadkhata)
                                    {
                                        this.btnAmaldaramad.Enabled = false;
                                        this.lblMutStatus.Text = "عملدرامد شدہ۔" + AmaldaramadDate.ToShortDateString();
                                        this.lblMutStatus.ForeColor = Color.Green;
                                    }
                                    else
                                    {
                                        
                                        this.lblMutStatus.Text = "زیر تجویز۔" ;
                                        this.lblMutStatus.ForeColor = Color.Red;
                                        if (this.isAttested && this.isGardawar.ToString() != "0" && this.Teh_Report > 10)
                                        {
                                            btnAmaldaramad.Enabled = true;
                                        }
                                        else
                                        {
                                            btnAmaldaramad.Enabled = false;
                                        }
                                    }
                                }
                            }
                           
                        }
                        else
                        {
                            row.Cells["colChoose"].Value = 0;
                            //this.cbJuzviKhata.Enabled = false;
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

         private void btnAmaldaramad_Click(object sender, EventArgs e)
         {
             if(dgBuyersBeforeAmal.RowCount==0 || dgSellersBeforeAmal.RowCount==0)
             {
                 MessageBox.Show(" بائع / مشتری موجود نہیں ہے:::::", "کھاتہ عمل درامد" , MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }
             if (MessageBox.Show(" کیا آپ انتخاب کردہ کھاتے پر عملدرامد کرنا چاہتے ہیں:::::", "کھاتہ عمل درامد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 string AmalMessage = intiqal.IntiqalAmalDaramadByKhataIdSingle(this.IntiqalId, this.IntiqalKhataId, UsersManagments.UserId.ToString(), UsersManagments.UserName);
                 MessageBox.Show(AmalMessage, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  DataGridViewCellEventArgs ea=new DataGridViewCellEventArgs(0,0);
                 this.dgInteqalKhattas_CellClick((object)dgInteqalKhattas,ea);
                 this.btnAmaldaramad.Enabled = false;
                 this.lblMutStatus.Text = "عملدرامد شدہ۔" + DateTime.Now.ToShortDateString();
                 this.lblMutStatus.ForeColor = Color.Green;
             }
         }

         #region Fill Grid view method

         public void Fill_Khata_DropDown()
         {
             try
             {
                 DataTable dtkj = new DataTable();
                dtkj = intiqal.GetKhataJatForintiqalByMozaId(this.MozaId);
                DataRow inteqKj = dtkj.NewRow();
                inteqKj["RegisterHqDKhataId"] = "0";
                inteqKj["KhataNo"] = " - کھاتہ نمبر چنیے - ";
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

         private void cbokhataNo_SelectionChangeCommitted(object sender, EventArgs e)
         {
             DataTable dtAllKhewatFareeqain = null; 
             dtAllKhewatFareeqain = intiqal.KhewatGroupFareeqainAll(cbokhataNo.SelectedValue.ToString());
             this.dgKhewatFareeqainAll.DataSource = dtAllKhewatFareeqain;
             view =new DataView(dtAllKhewatFareeqain);
             this.PopulateGridViewKhewatMalkanAll();
         }

         private void PopulateGridViewKhewatMalkanAll()
         {
             dgKhewatFareeqainAll.Columns["FardAreaPart"].HeaderText = "حصہ";
             dgKhewatFareeqainAll.Columns["Khewat_Area"].HeaderText = "رقبہ";
             dgKhewatFareeqainAll.Columns["PersonName"].HeaderText = "نام مالک";
             dgKhewatFareeqainAll.Columns["CNIC"].HeaderText = "شناختی نمبر";
             dgKhewatFareeqainAll.Columns["KhewatType"].HeaderText = "قسم مالک";
             dgKhewatFareeqainAll.Columns["FardPart_Bata"].Visible=false;
             dgKhewatFareeqainAll.Columns["seqno"].HeaderText = "نمبر شمار";
             dgKhewatFareeqainAll.Columns["KhewatGroupFareeqId"].Visible = false;
             dgKhewatFareeqainAll.Columns["KhewatGroupId"].Visible = false;
             dgKhewatFareeqainAll.Columns["PersonId"].Visible = false;
             dgKhewatFareeqainAll.Columns["KhewatTypeId"].Visible = false;
             dgKhewatFareeqainAll.Columns["RecStatus"].HeaderText = "حالت";
             dgKhewatFareeqainAll.Columns["PersonName"].DisplayIndex = 2;
             dgKhewatFareeqainAll.Columns["KhewatType"].DisplayIndex = 3;
             dgKhewatFareeqainAll.Columns["seqno"].DisplayIndex = 1;

         }


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
                             DataTable dtKhewatFareeqainByPerson = new DataTable();
                             dtKhewatFareeqainByPerson = intiqal.KhewatGroupFareeqByKhataIdPersonId(khataId, personId);
                             this.dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainByPerson;
                             PopulateGridviewKhewFareeqByPersonId();

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

         private void PopulateGridviewKhewFareeqByPersonId()
         {
             try
             {
             dgKhewatFreeqDetails.Columns["FardAreaPart"].HeaderText = "حصہ";
             dgKhewatFreeqDetails.Columns["Khewat_Area"].HeaderText = "رقبہ";
             dgKhewatFreeqDetails.Columns["PersonName"].HeaderText = "نام مالک";
             dgKhewatFreeqDetails.Columns["TransactionType"].HeaderText = "زریعہ";
             dgKhewatFreeqDetails.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
             dgKhewatFreeqDetails.Columns["IntiqalId"].Visible = false;
             dgKhewatFreeqDetails.Columns["CNIC"].HeaderText = "شناختی نمبر";
             dgKhewatFreeqDetails.Columns["SellerBuyer"].HeaderText = "حیثیت";
             dgKhewatFreeqDetails.Columns["KhewatType"].Visible = false;
             dgKhewatFreeqDetails.Columns["FardPart_Bata"].Visible = false;
             dgKhewatFreeqDetails.Columns["seqno"].HeaderText = "نمبر شمار";
             dgKhewatFreeqDetails.Columns["KhewatGroupFareeqId"].Visible = false;
             dgKhewatFreeqDetails.Columns["KhewatGroupId"].Visible = false;
             dgKhewatFreeqDetails.Columns["PersonId"].Visible = false;
             dgKhewatFreeqDetails.Columns["KhewatTypeId"].Visible = false;
             dgKhewatFreeqDetails.Columns["RecStatus"].HeaderText = "حالت";
             dgKhewatFreeqDetails.Columns["PersonName"].DisplayIndex = 2;
             dgKhewatFreeqDetails.Columns["TransactionType"].DisplayIndex = 3;
             dgKhewatFreeqDetails.Columns["seqno"].DisplayIndex = 1;

             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }

         private void txtSearchFromGrid_TextChanged(object sender, EventArgs e)
         {
             string filter = this.txtSearchFromGrid.Text.ToString();
             view.RowFilter = "PersonName LIKE '%" + filter + "%'";
             dgKhewatFareeqainAll.DataSource = view;
             this.PopulateGridViewKhewatMalkanAll();
         }

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
    }
}
