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
    public partial class frmSelfPersonDetails : Form
    {
        #region Class Variables

        Intiqal intiqal = new Intiqal();
        Khatoonies khatooni = new Khatoonies();
        AutoComplete objauto = new AutoComplete();
        DataTable dtAllKhewatFareeqain = new DataTable();
        DataView view;
        DataTable dtAllMushteriFareeqain = new DataTable();
        DataView viewMF;
        public string MozaId { get; set; }
        LanguageConverter lang = new LanguageConverter();

        #endregion

        public string pID = "";
        public string kID = "";
        #region Default Constructor

        public frmSelfPersonDetails(string personId, string khataId)
        {
            InitializeComponent();
            pID=personId;
            kID = khataId;
        }

       
        #endregion

        #region Form Load Event


        private void frmIntiqalAmalDaramadByKhata_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            DataTable dtKhewatFareeqainByPerson = new DataTable();
            dtKhewatFareeqainByPerson = intiqal.KhewatGroupFareeqByKhataIdPersonId(kID, pID);
            this.dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainByPerson;
            PopulateGridviewKhewFareeqByPersonId();
        }

                
        #endregion

        
       
        

       

        
     

         #region Gridview Khewat group fareeqain Cell Click Event

         //private void dgKhewatFareeqainAll_CellClick(object sender, DataGridViewCellEventArgs e)
         //{
             
         //    try
         //    {
         //        DataGridView g = sender as DataGridView;
         //        foreach (DataGridViewRow row in g.Rows)
         //        {
         //            if (dgKhewatFareeqainAll.SelectedRows.Count > 0)
         //            {
         //                if (row.Selected)
         //                {
         //                    row.Cells[0].Value = 1;
         //                    string personId = row.Cells["PersonId"].Value.ToString();
         //                    string khataId = cbokhataNo.SelectedValue.ToString();
         //                    DataTable dtKhewatFareeqainByPerson = new DataTable();
         //                    dtKhewatFareeqainByPerson = intiqal.KhewatGroupFareeqByKhataIdPersonId(khataId, personId);
         //                    this.dgKhewatFreeqDetails.DataSource = dtKhewatFareeqainByPerson;
         //                    PopulateGridviewKhewFareeqByPersonId();

         //                }
         //                else
         //                {
         //                    row.Cells[0].Value = 0;
         //                }
         //            }
                    
         //        }
         //    }
         //    catch (Exception ex)
         //    {
         //        MessageBox.Show(ex.Message);
         //    }
         //}

         #endregion

         #region Fill Gridview Malkan by Person Id for Single Malk History and Details

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

       
         #region languaage for keypress
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

         private void cmbMouzaKhanakasht_KeyPress(object sender, KeyPressEventArgs e)
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
         #endregion

      
    }
}
