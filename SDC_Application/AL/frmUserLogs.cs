using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.LanguageManager;
using SDC_Application.BL;

namespace SDC_Application.AL
{
    public partial class frmUserLogs : Form
    {
        Classess.AutoComplete auto = new Classess.AutoComplete();
        LanguageConverter Lang = new LanguageConverter();
        Search Srch = new Search();
        Intiqal iq = new Intiqal();

        public frmUserLogs()
        {
            InitializeComponent();
        }

        private void frmUserLogs_Load(object sender, EventArgs e)
        {
            auto.FillCombo("Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString(), cmbMouza, "MozaNameUrdu", "MozaId");
        }

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

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                string PName = txtPersonaName.Text;
                string PTyep = "1";
                string MozaId = cmbMouza.SelectedValue.ToString(); ;
                DataTable dt = new DataTable();
                dt = Srch.GetSearchAfradListWithLogs(MozaId, PTyep, PName);
                GridViewPersons.DataSource = dt;
                GridViewPersons.Columns["PersonFullName"].HeaderText = "نام افراد";
                GridViewPersons.Columns["PersonId"].Visible = false;
                GridViewPersons.Columns["InsertUserId"].Visible = false;
                GridViewPersons.Columns["InsertLoginName"].Visible = false;
                GridViewPersons.Columns["InsertDate"].Visible = false;

                GridViewPersons.Columns["UpdateUserId"].Visible = false;
                GridViewPersons.Columns["UpdateLoginName"].Visible = false;
                GridViewPersons.Columns["UpdateDate"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void GridViewPersons_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.GridViewPersons.Rows.Count > 0)
                {
                    if (e.ColumnIndex == GridViewPersons.CurrentRow.Cells["ColSel"].ColumnIndex)
                    {
                        string UpdateDate = Convert.ToDateTime(GridViewPersons.SelectedRows[0].Cells["UpdateDate"].Value.ToString()) > Convert.ToDateTime("02/10/2016") ? GridViewPersons.SelectedRows[0].Cells["UpdateDate"].Value.ToString() : " ";
                        string InsertDate = Convert.ToDateTime(GridViewPersons.SelectedRows[0].Cells["InsertDate"].Value.ToString()) > Convert.ToDateTime("02/10/2016") ? GridViewPersons.SelectedRows[0].Cells["InsertDate"].Value.ToString() : "Service Provider Data";
                        string InsertLoginName = Convert.ToDateTime(GridViewPersons.SelectedRows[0].Cells["InsertDate"].Value.ToString()) > Convert.ToDateTime("02/10/2016") ? GridViewPersons.SelectedRows[0].Cells["InsertLoginName"].Value.ToString() : "Service Provider Data";
                        string UpdateLoginName = Convert.ToDateTime(GridViewPersons.SelectedRows[0].Cells["UpdateDate"].Value.ToString()) > Convert.ToDateTime("02/10/2016") ? GridViewPersons.SelectedRows[0].Cells["UpdateLoginName"].Value.ToString() : " ";

                        this.lblInsertLoginName.Text =InsertLoginName; //GridViewPersons.SelectedRows[0].Cells["InsertLoginName"].Value.ToString();
                        this.lblInsertDate.Text = InsertDate; //GridViewPersons.SelectedRows[0].Cells["InsertDate"].Value.ToString();
                        this.lblPersonName.Text = GridViewPersons.SelectedRows[0].Cells["PersonFullName"].Value.ToString();

                        this.lblUpdateLoginName.Text = UpdateLoginName; //GridViewPersons.SelectedRows[0].Cells["UpdateLoginName"].Value.ToString();
                        this.lblUpdateDate.Text = UpdateDate;

                        GridViewPersons.CurrentRow.Cells["ColSel"].Value = 1;
                        //this.lblUpdateLoginName.Text = GridViewPersons.SelectedRows[0].Cells["PersonFullName"].Value.ToString();
                    }
                    GridViewPersons.CurrentRow.Cells["ColSel"].Value = 0;
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbMouza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar((Keys.Back)))
            {

            }
            else
            {
                e.KeyChar = Lang.UrduChar(Convert.ToChar(e.KeyChar));
            }
        }

        private void btnLoadKhata_Click(object sender, EventArgs e)
        {
            auto.FillCombo("proc_Get_Moza_KhataJat_for_Intiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + cmbMouza.SelectedValue.ToString(), cmbKhataNo, "KhataNo", "RegisterHqDKhataId");
        }

        private void cmbKhataNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt=iq.GetKhataMalikanByKhataIdWithLogs(cmbKhataNo.SelectedValue.ToString());
                dgKhataMalkan.DataSource = dt;
                dgKhataMalkan.Columns["personname"].HeaderText = "نام مالک";
                dgKhataMalkan.Columns["FardAreaPart"].HeaderText = "حصہ";
                dgKhataMalkan.Columns["Fard_Area"].HeaderText = "رقبہ";
                dgKhataMalkan.Columns["InsertDate"].Visible = false;
                dgKhataMalkan.Columns["InsertLoginName"].Visible = false;
                dgKhataMalkan.Columns["InsertUserId"].Visible = false;
                dgKhataMalkan.Columns["UpdateDate"].Visible = false;
                dgKhataMalkan.Columns["UpdateUserId"].Visible = false;
                dgKhataMalkan.Columns["UpdateLoginName"].Visible = false;
                dgKhataMalkan.Columns["UpdateUserId"].Visible = false;
                dgKhataMalkan.Columns["KhewatGroupFareeqId"].Visible = false;
                dgKhataMalkan.Columns["PersonId"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgKhataMalkan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView g = sender as DataGridView;
                if (g.Rows.Count > 0)
                {
                    if (e.ColumnIndex == g.CurrentRow.Cells["ColSelKFG"].ColumnIndex)
                    {
                        string UpdateDate = Convert.ToDateTime(g.SelectedRows[0].Cells["UpdateDate"].Value.ToString()) > Convert.ToDateTime("02/10/2016") ? g.SelectedRows[0].Cells["UpdateDate"].Value.ToString() : " ";
                        string InsertDate = Convert.ToDateTime(g.SelectedRows[0].Cells["InsertDate"].Value.ToString()) > Convert.ToDateTime("02/10/2016") ? g.SelectedRows[0].Cells["InsertDate"].Value.ToString() : "Service Provider Data";
                        string InsertLoginName = Convert.ToDateTime(g.SelectedRows[0].Cells["InsertDate"].Value.ToString()) > Convert.ToDateTime("02/10/2016") ? g.SelectedRows[0].Cells["InsertLoginName"].Value.ToString() : "Service Provider Data";
                        string UpdateLoginName =g.SelectedRows[0].Cells["UpdateDate"].Value.ToString()!=""?  Convert.ToDateTime(g.SelectedRows[0].Cells["UpdateDate"].Value.ToString()) > Convert.ToDateTime("02/10/2016") ? g.SelectedRows[0].Cells["UpdateLoginName"].Value.ToString() : " ":"";

                        this.lblKFGinserloginName.Text = InsertLoginName; //GridViewPersons.SelectedRows[0].Cells["InsertLoginName"].Value.ToString();
                        this.lblKFGinsertDate.Text = InsertDate; //GridViewPersons.SelectedRows[0].Cells["InsertDate"].Value.ToString();
                        this.lblKhewatFareqName.Text = g.SelectedRows[0].Cells["personname"].Value.ToString();

                        this.lblKFGupdateLoginName.Text = UpdateLoginName; //GridViewPersons.SelectedRows[0].Cells["UpdateLoginName"].Value.ToString();
                        this.lblKFGupdatedate.Text = UpdateDate;

                        //g.CurrentRow.Cells["ColSel"].Value = 1;
                        //this.lblUpdateLoginName.Text = GridViewPersons.SelectedRows[0].Cells["PersonFullName"].Value.ToString();
                    }
                    //g.CurrentRow.Cells["ColSel"].Value = 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbMouza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.cmbKhataNo.DataSource = null;
            this.dgKhataMalkan.DataSource = null;
        }
    }
}
