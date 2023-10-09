using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using SDC_Application.Classess;
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class frmKhanakashtBayanMushteryan : Form
    {
        #region Class Variables
        LanguageConverter lang = new LanguageConverter();
        AutoComplete objauto = new AutoComplete();
        Search Srch = new Search();
        Intiqal intiqal = new Intiqal();
        public int MozaId { get; set; }
        #endregion

        public frmKhanakashtBayanMushteryan()
        {
            InitializeComponent();
        }

        private void frmKhanakashtBayanMushteryan_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

            objauto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+UsersManagments.SubSdcId.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
        }

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                MozaId = Convert.ToInt32(cmbMouza.SelectedValue.ToString());
                if (MozaId > 0)
                {
                    this.tabControl1.Enabled = true;
                }
                else
                {
                    this.tabControl1.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtVisitorName_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnPopulate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = Srch.GetSearchAfradList(MozaId.ToString(), "1", txtBayaName.Text.Trim());
                dgPerson.DataSource = dt;
                dgPerson.Columns["PersonFullName"].HeaderText="نام افراد";
                dgPerson.Columns["PersonId"].Visible=false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;

                if (g.CurrentCell == g.CurrentRow.Cells["ColSel"])
                {
                    foreach (DataGridViewRow row in g.Rows)
                    {
                        row.Cells["ColSel"].Value = 0;
                    }
                    g.CurrentCell.Value = g.CurrentCell.Value != null ? (g.CurrentCell.Value.ToString() == "1" ? 0 : 1) : 1;

                    string PersonId = g.CurrentRow.Cells["PersonId"].Value.ToString();
                    this.LoadBayaKhataKhatooni(PersonId);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadBayaKhataKhatooni(string PersonId)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = intiqal.GetKhatooniKhanakashtBayaRaqbaByPersonId(PersonId);
                dgBayanKhataKhatooni.DataSource = dt;
                dgBayanKhataKhatooni.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                dgBayanKhataKhatooni.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                dgBayanKhataKhatooni.Columns["BeahShudaRaqba"].HeaderText = "بیع شدہ رقبہ";
                dgBayanKhataKhatooni.Columns["PersonId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchUnsaveBaya_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = intiqal.GetKhatooniKhanakashtBayaByNameSearch(this.MozaId.ToString(), txtBayaNameUnsave.Text.Trim());
                dgUnsavBayanKhataKhatooni.DataSource = dt;
                dgUnsavBayanKhataKhatooni.Columns["KhataNo"].HeaderText = "کھاتہ نمبر";
                dgUnsavBayanKhataKhatooni.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
                dgUnsavBayanKhataKhatooni.Columns["KhataStatus"].HeaderText = "حالت کھاتہ";
                dgUnsavBayanKhataKhatooni.Columns["NameBaya"].HeaderText = "تفصیل بائعان";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
