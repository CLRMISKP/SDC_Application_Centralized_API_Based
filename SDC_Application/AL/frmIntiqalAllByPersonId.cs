using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SDC_Application.AL
{
    public partial class frmIntiqalAllByPersonId : Form
    {
        #region Properties
        public string PersonName { get; set; }
        public string PersonId { get; set; }
        BL.Intiqal intiqal = new BL.Intiqal();
        DataView dv = new DataView();
        #endregion
        public frmIntiqalAllByPersonId()
        {
            InitializeComponent();
        }

        private void frmIntiqalAllByPersonId_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt= intiqal.GetAllIntiqalByPersonId(this.PersonId);
                dv = dt.AsDataView();
                dgvAllMutations.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       private void fillDataGrid()
        {
            if (dgvAllMutations.DataSource != null)
            {
                //dgvAllMutations.Columns[].Visible=false;
                dgvAllMutations.Columns[""].HeaderText="";

            }
        }
    }
}
