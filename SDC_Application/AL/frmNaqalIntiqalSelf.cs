using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.IO;
using System.Diagnostics;
using SDC_Application.LanguageManager;
using iTextSharp.text;
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class frmNaqalIntiqalSelf : Form
    {

        #region Class Variables and Properties

        LanguageConverter lang = new LanguageConverter();
        AutoComplete objauto = new AutoComplete();
        BL.frmToken objbusines = new BL.frmToken();
       
        public string MozaId { get; set; }

       
        public string SellerId = "";

        public string BuyerId = "";

        
        DataTable IntiqalList = new System.Data.DataTable();

        #endregion

        public frmNaqalIntiqalSelf()
        {
            InitializeComponent();
        }

        private void frmNaqalIntiqal_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
        }




        #region Search Intiqal Sellers


        private void btnSearchSeller_Click(object sender, EventArgs e)
        {
            if (cmbMouza.SelectedIndex > 0)
            {
                frmSearchPersonForNaqalIntiqal Sp = new frmSearchPersonForNaqalIntiqal();
                Sp.MozaId = this.MozaId;
                Sp.FormClosed -= new FormClosedEventHandler(Sp_FormClosed);
                Sp.FormClosed += new FormClosedEventHandler(Sp_FormClosed);
                Sp.ShowDialog();

            }
            else
            {
                MessageBox.Show("تلاش کرنے سے پہلے موضع کا انتخاب کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Sp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPersonForNaqalIntiqal ap = sender as frmSearchPersonForNaqalIntiqal;
           
            this.txtSellerName.Text += this.txtSellerName.Text.Length > 2 ? "," + ap.PersonName : ap.PersonName;

            if(SellerId.Length==0)
            {
                SellerId = ap.personId + ";";
            }
            else
            {
                SellerId = ap.personId + SellerId;
            }
            

        }

        #endregion

        #region Search Intiqal Buyers

        private void btnSearchBuyers_Click(object sender, EventArgs e)
        {
            if (cmbMouza.SelectedIndex > 0)
            {
                frmSearchPersonForNaqalIntiqal Buyer = new frmSearchPersonForNaqalIntiqal();
                Buyer.MozaId = this.MozaId;
                Buyer.FormClosed -= new FormClosedEventHandler(Buyer_FormClosed);
                Buyer.FormClosed += new FormClosedEventHandler(Buyer_FormClosed);
                Buyer.ShowDialog();
            }
            else
            {
                MessageBox.Show("تلاش کرنے سے پہلے موضع کا انتخاب  کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void Buyer_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSearchPersonForNaqalIntiqal ap = sender as frmSearchPersonForNaqalIntiqal;
           
            this.txtbuyerName.Text += this.txtbuyerName.Text.Length > 2 ? "," + ap.PersonName : ap.PersonName;

            if (BuyerId.Length == 0)
            {
                BuyerId = ap.personId + ";";
            }
            else
            {
                BuyerId = ap.personId + BuyerId;
            }
           
        }

        #endregion

        #region List Searched Intiqals

        private void btnListIntiqals_Click(object sender, EventArgs e)
        {
            if (this.MozaId != "")
            {


                IntiqalList = this.objbusines.filldatatable_from_storedProcedure("proc_Self_Get_Intiqal_List_For_Naqal " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + SellerId + "','" + BuyerId + "','" + this.MozaId + "'");
                
                if (IntiqalList != null)
                {
                    this.GridIntiqalList.DataSource = IntiqalList;
                 
                    if (IntiqalList != null)
                    {

                        GridIntiqalList.Columns["IntiqalId"].Visible = false;

                        GridIntiqalList.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                        GridIntiqalList.Columns["IntiqalAndrajDate"].HeaderText = "تاریخ اندراج انتقال";
                        GridIntiqalList.Columns["IntiqalAmaldramadDate"].HeaderText = "تاریخ انتقال عملدرامد";
                        GridIntiqalList.Columns["AmalDaramadStatus"].HeaderText = "کیفیت";
                        GridIntiqalList.Columns["IntiqalPendingRemakrs"].HeaderText = "ریمارکس";
             
                    }




                }
            }
            else
            {
                MessageBox.Show("تلاش کرنے سے پہلے ٹوکن لوڈ کریں", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

    
      
        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.MozaId = cmbMouza.SelectedValue.ToString();
            txtbuyerName.Clear();
            txtSellerName.Clear();
            SellerId = "";
            BuyerId = "";
            GridIntiqalList.DataSource = null;
        }

        private void cmbMouza_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (e.KeyChar == 1)
            {
                TextBox txt = sender as TextBox;
                txt.SelectAll();
            }
        }

        private void cmbMouza_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.MozaId = cmbMouza.SelectedValue.ToString();
            txtbuyerName.Clear();
            txtSellerName.Clear();
            SellerId = "";
            BuyerId = "";
            GridIntiqalList.DataSource = null;
        }

        private void GridIntiqalList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
