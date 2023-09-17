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
    public partial class frmMalkiatHistoryDetails : Form
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

        #region Default Constructor

        public frmMalkiatHistoryDetails()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Load Event


        private void frmIntiqalAmalDaramadByKhata_Load(object sender, EventArgs e)
        {
            // Get  Mouza List and Fill Mouza Drop down
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouzaKhanakasht, "MozaNameUrdu", "MozaId");
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

         #region Fill Grid view method

         public void Fill_KhataKhanakasht_DropDown()
         {
             try
             {
                 DataTable dtkj = new DataTable();
                 dtkj = intiqal.GetKhataJatForintiqalByMozaId(cmbMouzaKhanakasht.SelectedValue.ToString());
                 DataRow inteqKj = dtkj.NewRow();
                 inteqKj["RegisterHqDKhataId"] = "0";
                 inteqKj["KhataNo"] = " - کھاتہ نمبر کا انتخاب کرِیں - ";
                 dtkj.Rows.InsertAt(inteqKj, 0);
                 cboKhataKhanakasht.DataSource = dtkj;
                 cboKhataKhanakasht.DisplayMember = "KhataNo";
                 cboKhataKhanakasht.ValueMember = "RegisterHqDKhataId";
                 cboKhataKhanakasht.SelectedValue = 0;

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
             dtAllKhewatFareeqain = intiqal.KhewatGroupFareeqainAll(cbokhataNo.SelectedValue.ToString());
             this.dgKhewatFareeqainAll.DataSource = dtAllKhewatFareeqain;
             view =new DataView(dtAllKhewatFareeqain);
             this.PopulateGridViewKhewatMalkanAll();
         }

         #endregion

         #region Khata Khanakasht  Selection Change event

         private void cbokhataNoKhanakasht_SelectionChangeCommitted(object sender, EventArgs e)
         {
             objauto.FillCombo("Proc_Get_KhatooniNos_List_By_KhataId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cboKhataKhanakasht.SelectedValue.ToString(), cmbKhatooniNo, "KhatooniNo", "KhatooniId");
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

         #endregion

         #region Fill Gridview Mushteryan by Khata

         private void PopulateGridViewMushteryanAll()
         {
             dgMushteriFareeqainAll.Columns["FardAreaPart"].HeaderText = "حصہ";
             dgMushteriFareeqainAll.Columns["Mushtri_Area_KMSqft"].HeaderText = "رقبہ";
             dgMushteriFareeqainAll.Columns["CompleteName"].HeaderText = "نام مالک";
             dgMushteriFareeqainAll.Columns["KhewatType"].HeaderText = "قسم مالک";
             dgMushteriFareeqainAll.Columns["FardPart_Bata"].Visible = false;
             dgMushteriFareeqainAll.Columns["seqno"].HeaderText = "نمبر شمار";
             dgMushteriFareeqainAll.Columns["MushtriFareeqId"].Visible = false;
             dgMushteriFareeqainAll.Columns["KhatooniId"].Visible = false;
             dgMushteriFareeqainAll.Columns["PersonId"].Visible = false;
             dgMushteriFareeqainAll.Columns["KhewatTypeId"].Visible = false;
             dgMushteriFareeqainAll.Columns["RecStatus"].HeaderText = "حالت";
             dgMushteriFareeqainAll.Columns["CompleteName"].DisplayIndex = 2;
             dgMushteriFareeqainAll.Columns["KhewatType"].DisplayIndex = 3;
             dgMushteriFareeqainAll.Columns["seqno"].DisplayIndex = 1;

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

         #region Fill Gridview Mushteryan by Person Id for Single Malk History and Details

         private void PopulateGridviewMushteriFareeqByPersonId()
         {
             try
             {
                 dgMushteriFareeqainDetails.Columns["FardAreaPart"].HeaderText = "حصہ";
                 dgMushteriFareeqainDetails.Columns["Khewat_Area"].HeaderText = "رقبہ";
                 dgMushteriFareeqainDetails.Columns["PersonName"].HeaderText = "نام مالک";
                 dgMushteriFareeqainDetails.Columns["TransactionType"].HeaderText = "زریعہ";
                 dgMushteriFareeqainDetails.Columns["IntiqalNo"].HeaderText = "انتقال نمبر";
                 dgMushteriFareeqainDetails.Columns["IntiqalId"].Visible = false;
                 dgMushteriFareeqainDetails.Columns["CNIC"].HeaderText = "شناختی نمبر";
                 dgMushteriFareeqainDetails.Columns["SellerBuyer"].HeaderText = "حیثیت";
                 dgMushteriFareeqainDetails.Columns["KhewatType"].Visible = false;
                 dgMushteriFareeqainDetails.Columns["FardPart_Bata"].Visible = false;
                 dgMushteriFareeqainDetails.Columns["seqno"].HeaderText = "نمبر شمار";
                 dgMushteriFareeqainDetails.Columns["MushtriFareeqId"].Visible = false;
                 dgMushteriFareeqainDetails.Columns["KhatooniId"].Visible = false;
                 dgMushteriFareeqainDetails.Columns["PersonId"].Visible = false;
                 dgMushteriFareeqainDetails.Columns["KhewatTypeId"].Visible = false;
                 dgMushteriFareeqainDetails.Columns["RecStatus"].HeaderText = "حالت";
                 dgMushteriFareeqainDetails.Columns["PersonName"].DisplayIndex = 2;
                 dgMushteriFareeqainDetails.Columns["TransactionType"].DisplayIndex = 3;
                 dgMushteriFareeqainDetails.Columns["seqno"].DisplayIndex = 1;

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

         #region Moza Khanakasht Selection Change Event

         private void cmbMouzaKhanakasht_SelectionChangeCommitted(object sender, EventArgs e)
         {
             this.Fill_KhataKhanakasht_DropDown();
         }

         #endregion

         #region Khatooni Dropdown Selection Chenge Event

         private void cmbKhatooniNo_SelectionChangeCommitted(object sender, EventArgs e)
         {
             DataTable dtAllMushteriFareeqain = null;
             dtAllMushteriFareeqain =khatooni.Get_MushtriFareeqein_By_Khatooni_All_Status(cmbKhatooniNo.SelectedValue.ToString());
             this.dgMushteriFareeqainAll.DataSource = dtAllMushteriFareeqain;
             viewMF = new DataView(dtAllMushteriFareeqain);
             this.PopulateGridViewMushteryanAll();
         }

         #endregion

         #region Gridview MushteriFareeqainALL cell click event
      
         private void dgMushteriFareeqainAll_CellClick(object sender, DataGridViewCellEventArgs e)
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
                             string KhatooniId = row.Cells["KhatooniId"].Value.ToString();
                             DataTable dtMushteriFareeqainByPerson = new DataTable();
                             dtMushteriFareeqainByPerson = khatooni.MushteriFareeqByKhatooniIdPersonId(KhatooniId, personId);
                             this.dgMushteriFareeqainDetails.DataSource = dtMushteriFareeqainByPerson;
                             PopulateGridviewMushteriFareeqByPersonId();

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

         private void txtSearchKhanakasht_TextChanged(object sender, EventArgs e)
         {
             string filter = this.txtSearchKhanakasht.Text.ToString();
             viewMF.RowFilter = "CompleteName LIKE '%" + filter + "%'";
             this.dgMushteriFareeqainAll.DataSource =  viewMF;
             this.PopulateGridViewMushteryanAll();
         }
    }
}
