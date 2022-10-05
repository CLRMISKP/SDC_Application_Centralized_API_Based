using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using SDC_Application.BL;
using SDC_Application.Classess;

namespace SDC_Application.AL
{
    public partial class frmMozaSelection : Form
    {
        #region Class Variables

        DataTable PatwarCircles = new DataTable();
        DataTable Mozas = new DataTable();
        AreaProfile area = new AreaProfile();

        #endregion

        #region Default Constructor

        public frmMozaSelection()
        {
            InitializeComponent();
        }

        #endregion

        #region form Load Event

        private void frmMozaSelection_Load(object sender, EventArgs e)
        {
            TT_for_MozaSelection();
            btnSave.Enabled = false;
            try
            {
                PatwarCircles = area.GetPatwarCircle(UsersManagments._Tehsilid.ToString());
                DataRow pcRow = PatwarCircles.NewRow();
                pcRow["PatwarCircleNameUrdu"] = " - پٹوار سرکل کا انتخاب - ";
                pcRow["PatwarCircleId"] = "0";
                PatwarCircles.Rows.InsertAt(pcRow, 0);
                
                cboPC.DataSource = PatwarCircles;
                cboPC.DisplayMember = "PatwarCircleNameUrdu";
                cboPC.ValueMember = "PatwarCircleId";
                cboPC.SelectedValue = 0;
           
            }
            catch (Exception)
            {

            }
        }

        #endregion

        #region Drop Down Patwar Circle selection change event
    
        private void cboPC_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                int pcId = Convert.ToInt32(cboPC.SelectedValue);
                Mozas = area.GetMozaByPatwarCircle(UsersManagments._Tehsilid.ToString(), pcId.ToString());
                DataRow MozaRow = Mozas.NewRow();
                MozaRow["MozaId"]="0";
                MozaRow["MozaNameUrdu"] = " - موضع چنیے - ";
                Mozas.Rows.InsertAt(MozaRow,0);
                cboMoza.DataSource = Mozas;
                cboMoza.DisplayMember = "MozaNameUrdu";
                cboMoza.ValueMember = "MozaId";
                cboMoza.SelectedValue = 0;

            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        #endregion

        private void cboMoza_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboPC.SelectedValue.ToString() != "0" && cboMoza.SelectedValue.ToString() != "0")
            {
                this.btnSave.Enabled = true;
            }
            else
                this.btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int mozaid = Convert.ToInt32(cboMoza.SelectedValue);
                UsersManagments.MozaId = mozaid;
                UsersManagments.MozaName = cboMoza.Text;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void TT_for_MozaSelection()
        {
            TTMozaSelection.SetToolTip(cboMoza,"موضع منتخب کریں");
            TTMozaSelection.SetToolTip(cboPC,"پٹوار سرکل منتخب کریں");
            TTMozaSelection.SetToolTip(btnSave,"آگے بڑھیٰے");

        
        }

    }
}
