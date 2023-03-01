
using System;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using System.Data;
using SDC_Application.BL;
using SDC_Application.Classess;

namespace SDC_Application
{
    public partial class frmSearchPersonForNaqalIntiqal : Form
    {
        #region Class varialbes

       // ClientServiceClient client = new ClientServiceClient();
        LanguageConverter Lang = new LanguageConverter();
        Search Srch = new Search();
      
        #endregion

        #region Properties
        public string MozaId { get; set; }
        Intiqal intiq = new Intiqal();
        public string PersonName="";
        public string personId = "";

        public int CallForIntiqalBuyers = 0;

        public string IntiqalKhataRecId { get; set; }
        public string khewatTypeId { get; set; }
        public string KhatoniRecid { get; set; }
       
        #endregion

        #region Default Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public frmSearchPersonForNaqalIntiqal()
        {
            InitializeComponent();
            
        }
        #endregion

        

        #region Find Button Clicked
        /// <summary>
        /// filters the person list of moza for specied name and return all matching records by assigning 
   
        private void btnFind_Click(object sender, EventArgs e)
        {
            string PName = txtPersonaName.Text;
            string FName = txtFname.Text;
            string PCNIC = txtCNIC.Text;
            string PTyep="1";
            string MozaId = this.MozaId;
            DataTable dt = new DataTable();

                if (txtCNIC.Text.Trim().Length==0)
                {
                    //dt = Srch.GetSearchAfradList(MozaId, PTyep, PName);
                    dt = Srch.GetSearchAfradListSelf(MozaId, PTyep, PName, FName);
                }
                else
                {
                    dt = Srch.GetSearchAfradListByCNICSelf(MozaId, PTyep, PCNIC);
                }
            
                GridViewPersons.DataSource = dt;
                GridViewPersons.Columns["PersonFullName"].HeaderText = "نام افراد";
                GridViewPersons.Columns["CNIC"].HeaderText = "شناختی کارڈ نمبر";
                GridViewPersons.Columns["PersonId"].Visible = false;
                this.GridViewPersons.Columns["MozaId"].Visible = false;
                this.GridViewPersons.Columns["QoamId"].Visible = false;
                this.GridViewPersons.Columns["PersonName"].Visible = false;
                this.GridViewPersons.Columns["FatherName"].Visible = false;
   }
        #endregion


        private void txtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPersonaName.Clear();
            txtFname.Clear();
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
            toolTip1.SetToolTip(txtCNIC, "شناختی کارڈ نمبر سے تلاش کریں");
        
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

                if (CallForIntiqalBuyers == 0)
                {

                    for (int i = 0; i <= GridViewPersons.Rows.Count - 1; i++)
                    {
                        if (Convert.ToInt32(GridViewPersons.Rows[i].Cells["cbgrid"].Value) == 1)
                        {


                            personId += ';' + GridViewPersons.Rows[i].Cells["PersonId"].Value.ToString();

                            if (PersonName.Length == 0)
                            {
                                PersonName = GridViewPersons.Rows[i].Cells["PersonFullName"].Value.ToString();
                            }

                            else
                            {

                                PersonName += ',' + GridViewPersons.Rows[i].Cells["PersonFullName"].Value.ToString();
                            }

                        }
                    }
                }
                else
                {
                    bool buyerNotExists = true;
                    string FullName = "";

                    foreach (DataGridViewRow r in GridBuyersList.Rows)
                    {



                        foreach (DataGridViewRow r1 in GridViewPersons.Rows)
                        {

                            if (r1.Cells["PersonId"].Value.ToString() == r.Cells["IntiqalBuyerPersonId"].Value.ToString() && Convert.ToInt32(r1.Cells["cbgrid"].Value) == 1)
                            {
                                buyerNotExists = false;
                                FullName = r1.Cells["PersonFullName"].Value.ToString();
                            }
                        }
                    }

                    if (buyerNotExists)
                    {
                        for (int i = 0; i <= GridViewPersons.Rows.Count - 1; i++)
                        {
                            if (Convert.ToInt32(GridViewPersons.Rows[i].Cells["cbgrid"].Value) == 1)
                            {
                                string IntiqalBuyerRecId = "-1";
                                string IntiqalBuyerPersonId = GridViewPersons.Rows[i].Cells["PersonId"].Value.ToString();
                                string Buyer_Hissa = "0";
                                string Buyer_Kanal = "0";
                                string Buyer_Marla = "0";
                                string Buyer_Sarsai = "0";
                                string Buyer_Feet = "0";
                                string KhewatTypeId = this.khewatTypeId;
                                string s = intiq.SaveintiqalBuyers(IntiqalBuyerRecId, IntiqalKhataRecId, KhatoniRecid, IntiqalBuyerPersonId, Buyer_Hissa, Buyer_Kanal, Buyer_Marla, Buyer_Sarsai, Buyer_Feet, KhewatTypeId, "0", UsersManagments.UserId.ToString(), UsersManagments.UserName.ToString());
                            }
                        }
                    }
                    else
                    {
                        {
                            MessageBox.Show("یہ گرہندہ پہلے سے موجود ہے" + FullName);
                        }
                    }
                }

               // MessageBox.Show(personId);
                this.Close();
            }
            else
                this.Close();
        }
        #region Fill Grid By Buyers List

        public void FillgridBuyerListByKhataRecId()
        {
            try
            {

                DataTable dt = new DataTable();
                string IntiqalKhattaRecId = this.IntiqalKhataRecId;
                string KhatoniRecid = this.KhatoniRecid;
                if (KhatoniRecid == "0")
                {
                    dt = intiq.GetIntiqalBuyersByIntiqalKhataRecId(IntiqalKhattaRecId, "-1", "0");
                }
                else
                {
                    dt = intiq.GetIntiqalBuyersByIntiqalKhataRecId(IntiqalKhattaRecId, KhatoniRecid, "0");
                }

                if (dt != null)
                {

                    GridBuyersList.DataSource = dt;
                    BuyerGrid();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BuyerGrid()
        {
            GridBuyersList.Columns["IntiqalBuyerRecId"].Visible = false;
            GridBuyersList.Columns["IntiqalKhataRecId"].Visible = false;
            GridBuyersList.Columns["IntiqalBuyerPersonId"].Visible = false;
            GridBuyersList.Columns["Buyer_Hissa"].HeaderText = "حصے";
            GridBuyersList.Columns["Buyer_Kanal"].Visible = false;
            GridBuyersList.Columns["Buyer_Marla"].Visible = false;
            GridBuyersList.Columns["Buyer_Sarsai"].Visible = false;
            GridBuyersList.Columns["Buyer_Feet"].Visible = false;
            GridBuyersList.Columns["IntiqalKhatooniRecId"].Visible = false;
            GridBuyersList.Columns["Buyer_Area"].HeaderText = "رقبہ";
            GridBuyersList.Columns["PersonName"].HeaderText = "نام";
            GridBuyersList.Columns["KhewatType"].HeaderText = "قسم ملکیت";

            GridBuyersList.Columns["Rishta"].Visible = false;

            GridBuyersList.Columns["KhewatTypeId"].Visible = false;
            GridBuyersList.Columns["RishtaId"].Visible = false;
            GridBuyersList.Columns["chk1"].DisplayIndex = 0;
            GridBuyersList.Columns["chk1"].Width = 100;
            GridBuyersList.Columns["Buyer_Hissa"].Width = 100;
            GridBuyersList.Columns["Buyer_Area"].Width = 100;


        }
        #endregion
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
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            this.txtPersonaName.Focus();
            Tooltip();
            if (CallForIntiqalBuyers != 0)
            {
                FillgridBuyerListByKhataRecId();
            }
        }

        private void txtPersonaName_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnFind;
        }
        private void GridViewPersons_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (CallForIntiqalBuyers == 0)
            {
                btnAccept_Click(sender, e);
            }
            //btnAccept_Click(sender, e);
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

        private void GridViewPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.RowIndex != -1)
            {
                GridViewPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.ColumnIndex == GridViewPersons.CurrentRow.Cells["cbgrid"].ColumnIndex)
                {
                    int b = Convert.ToInt32(GridViewPersons.CurrentRow.Cells["cbgrid"].Value);

                    if (b == 1)
                    {
                        GridViewPersons.CurrentRow.Cells["cbgrid"].Value = 0;
                    }
                    else
                    {
                        GridViewPersons.CurrentRow.Cells["cbgrid"].Value = 1; ;
                    }
                }
           }
        }

        private void txtFname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtFname_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnFind;
        }

      
 
    }
}
