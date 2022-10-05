using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.BL;
using SDC_Application.DL;
using System.Collections;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmIntiqalTaxes : Form
    {
        #region Class Variables
        DL.Database ojbdb = new DL.Database();
        AutoComplete objauto = new AutoComplete();
        Validations objvalid = new Validations();
        BL.Taxes objbusines = new BL.Taxes();
        datagrid_controls objdatagrid = new datagrid_controls();
        BindingSource bs = new BindingSource();
        LanguageConverter lang = new LanguageConverter();
        DataTable dt = new DataTable();
        DataTable dtGrd = new DataTable();
        static bool btnload = false;
        SqlDataReader dr = null;
        string tokenverifed = "False";
        string userid = "123";
        string username = "afzal";
        string useridupdate = "";
        string usernameupdate = "";
        string tehsilid = "19";
        string duplicate;
        float Amount;
        public string Intiqal_Id
        {
            get;
            set;
        }




        #endregion
        public frmIntiqalTaxes()
        {
            InitializeComponent();
        }

        private void frmIntiqalTaxes_Load(object sender, EventArgs e)
        {
            //this.Intiqal_Id = "190010001";
            userid = UsersManagments.UserId.ToString();
            username = UsersManagments.UserName;
            tehsilid = UsersManagments._Tehsilid.ToString();

            LoadNotificationDetails();
            grdNotificationdetails_Setting();
            ToolTip toolTip1 = new ToolTip();

            
            //toolTip1.AutoPopDelay = 5000;
            //toolTip1.InitialDelay = 1000;
            //toolTip1.ReshowDelay = 500;
            
            toolTip1.ShowAlways = true;

           
            toolTip1.SetToolTip(this.btngaintax, "گین ٹیکس");
            toolTip1.SetToolTip(this.btnUpdate, "محفوظ");
            toolTip1.SetToolTip(this.btnDel, "حذف");
          //  toolTip1.SetToolTip(this.btnUpdate, "محفوظ");
        }

        /// Load tax details

        #region
        public void LoadNotificationDetails()
        {
            dt = objbusines.GetIntiqalTaxesDetails(Intiqal_Id);
            grdNotificationdetails.DataSource = dt;


        }
        public void grdNotificationdetails_Setting()
        {
            try
            {
                if (grdNotificationdetails.DataSource != null)
                {
                    grdNotificationdetails.Columns["TaxName_Urdu"].DisplayIndex = 1;
                    grdNotificationdetails.Columns["SDCUnitName_Urdu"].DisplayIndex = 2;
                    grdNotificationdetails.Columns["TaxRate"].DisplayIndex = 3;
                    grdNotificationdetails.Columns["TaxableQuantity"].DisplayIndex = 3;
                    grdNotificationdetails.Columns["TaxAmount"].DisplayIndex = 4;
                    grdNotificationdetails.Columns["TaxName_Urdu"].HeaderText = "ٹیکس تفصیل";
                    grdNotificationdetails.Columns["SDCUnitName_Urdu"].HeaderText = "اکائی";
                    grdNotificationdetails.Columns["Percentage"].HeaderText = "ریٹ";
                    grdNotificationdetails.Columns["TaxableQuantity"].HeaderText = "رقبہ/قیمت";
                    grdNotificationdetails.Columns["TaxAmount"].HeaderText = "کل رقم";
                    grdNotificationdetails.Columns["TaxRate"].Visible = false;
                    grdNotificationdetails.Columns["IntiqalTaxId"].Visible = false;
                    grdNotificationdetails.Columns["Intiqalid"].Visible = false;
                    grdNotificationdetails.Columns["TaxId"].Visible = false;
                    grdNotificationdetails.Columns["TaxNotificationId"].Visible = false;
                    grdNotificationdetails.Columns["TaxNotificationNo"].Visible = false;
                    grdNotificationdetails.Columns["SDCUnitId"].Visible = false;
                    grdNotificationdetails.Columns["SeqNo"].Visible = false;
                    grdNotificationdetails.Columns["TaxNotificationDetailId"].Visible = false;

                    objdatagrid.colorrbackgrid(grdNotificationdetails);
                    objdatagrid.gridControls(grdNotificationdetails);

                    grdNotificationdetails.Columns["TaxName_Urdu"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    grdNotificationdetails.Columns["TaxAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grdNotificationdetails.Columns["TaxRate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        #endregion



        /// Load Form Notification form Event

        #region

        private void taxNotification_FormClosed(object sender, FormClosedEventArgs e)
        {

            frmTaxNotificationDetails taxNotification = sender as frmTaxNotificationDetails;
            if (taxNotification.btn)
            {
                LoadNotificationDetails();
                grdNotificationdetails_Setting();
            }
        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {

            frmTaxNotificationDetails taxNotification = new frmTaxNotificationDetails();
            taxNotification.FormClosed -= new FormClosedEventHandler(taxNotification_FormClosed);
            taxNotification.FormClosed += new FormClosedEventHandler(taxNotification_FormClosed);
            taxNotification.Intiqal_Id = Intiqal_Id;
            taxNotification.ShowDialog();
        }
        #endregion

        /// Update txt notification data

        #region
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            string IntiqalTaxId = this.hdntxtInteqalID.Text.ToString();
            string TaxNotificationDetailId = this.hdntxtNotificationDetailID.Text.ToString();
            string TaxRate = this.txtRate.Text.ToString();
            string TaxAmount = this.txtAmount.Text.ToString();
            string TaxableQuantity = this.txtRaqba.Text.ToString();
            if (Amount != null)
            {
                string Query = "" + IntiqalTaxId + "," + TaxNotificationDetailId + "," + TaxRate + "," + TaxableQuantity + "," + Amount.ToString() + "," + UsersManagments.UserId.ToString() + ",'" + UsersManagments.UserName.ToString() + "'";
                try
                {
                    if (MessageBox.Show("کیا آپ درستگی کرنا چاہتے ہیں:::::", "درستگی ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dt = objbusines.UpdateIntiqalTaxesDetails(Query);
                        if (dt != null)
                        {
                            LoadNotificationDetails();

                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //frmIntiqalPersonSnaps abc = new frmIntiqalPersonSnaps();
            //abc.Show();
        }
        #endregion

        /// grdNotificationdetails double click ,fill textBoxes

        #region
        private void grdNotificationdetails_DoubleClick(object sender, EventArgs e)
        {
            txtAmount.Text = grdNotificationdetails.CurrentRow.Cells["TaxAmount"].Value.ToString();
            txtRaqba.Text = grdNotificationdetails.CurrentRow.Cells["TaxableQuantity"].Value.ToString();
            txtRate.Text = grdNotificationdetails.CurrentRow.Cells["TaxRate"].Value.ToString();
            hdntxtInteqalID.Text = grdNotificationdetails.CurrentRow.Cells["IntiqalTaxId"].Value.ToString();
            this.hdntxtNotificationDetailID.Text = grdNotificationdetails.CurrentRow.Cells["TaxNotificationDetailId"].Value.ToString();
        }
        #endregion

        /// Validations

        #region
        private void txtRate_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != '.')
            {
                e.Handled = true;

            }
        }

        private void txtRaqba_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != '.')
            {
                e.Handled = true;

            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != '.')
            {
                e.Handled = true;

            }
            char c = e.KeyChar;
            if (e.KeyChar == (char)13)
            {

                btnUpdate_Click(sender, e);
            }
        }


        #endregion

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void grdNotificationdetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridView g = sender as DataGridView;
                    if (e.ColumnIndex == this.grdNotificationdetails.CurrentRow.Cells["chk"].ColumnIndex)
                    {
                        foreach (DataGridViewRow row in g.Rows)
                        {
                            if (grdNotificationdetails.SelectedRows.Count > 0)
                            {

                                if (row.Selected)
                                {

                                    row.Cells["chk"].Value = 1;
                                    txtAmount.Text = grdNotificationdetails.CurrentRow.Cells["TaxAmount"].Value.ToString();
                                    txtRaqba.Text = grdNotificationdetails.CurrentRow.Cells["TaxableQuantity"].Value.ToString();
                                    txtRate.Text = grdNotificationdetails.CurrentRow.Cells["TaxRate"].Value.ToString();
                                    txtRateInPercentage.Text = grdNotificationdetails.CurrentRow.Cells["Percentage"].Value.ToString();
                                    hdntxtInteqalID.Text = grdNotificationdetails.CurrentRow.Cells["IntiqalTaxId"].Value.ToString();
                                    this.hdntxtNotificationDetailID.Text = grdNotificationdetails.CurrentRow.Cells["TaxNotificationDetailId"].Value.ToString();
                                    txtRate.Focus();
                                }
                                else
                                {
                                    row.Cells["chk"].Value = 0;

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtRaqba_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtRate.Text.Trim() != string.Empty && txtRaqba.Text.Trim() != string.Empty)
                {
                    Amount = float.Parse(txtRate.Text) * float.Parse(txtRaqba.Text);
                    txtAmount.Text = Amount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.hdntxtInteqalID.Text.Trim() != "" && this.hdntxtInteqalID.Text.Trim() != "-1")
            {
                objbusines.DeleteIntiqalTaxDetails(this.hdntxtInteqalID.Text.Trim());
                LoadNotificationDetails();
            }
        }

        private void btngaintax_Click(object sender, EventArgs e)
        {
            frmGainTax gaintax = new frmGainTax();
            gaintax.FormClosed -= new FormClosedEventHandler(gaintax_FormClosed);
            gaintax.FormClosed += new FormClosedEventHandler(gaintax_FormClosed);
            gaintax.ShowDialog();
        }

        public void gaintax_FormClosed(object sender, FormClosedEventArgs e)
        {

            frmGainTax taxNotification = sender as frmGainTax;
            
        }
    }
}
