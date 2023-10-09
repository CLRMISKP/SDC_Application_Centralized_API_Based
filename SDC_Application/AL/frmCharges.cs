using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
//using Classess.Validations;
namespace SDC_Application
{
    public partial class frmCharges : Form
    {
        // Validations valid = new Validations();

        DL.Database ojbdb = new DL.Database();
        BL.frmToken obj = new BL.frmToken();
        datagrid_controls obj_datagrid = new datagrid_controls();
        Validations objvalid = new Validations();
        DataTable dtt = new DataTable();
        int check;
        static Double fee = 0;
        public frmCharges()
        {

            InitializeComponent();
        }
        #region LoadForm

        private void frmCharges_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);
           // DataGridViewHelper.addHelpterToAllFormGridViews(this);

            this.button2.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.None;
            try
            {

                grdtoken.DataSource = obj.filldatatable_from_storedProcedure("select tokenid,name,date from token where Tehsilid="+ SDC_Application.Classess.UsersManagments._Tehsilid.ToString() );
                grdtoken.Columns[0].HeaderText = "ٹوکن نمبر";
                grdtoken.Columns[1].HeaderText = "ںام";
                grdtoken.Columns[2].HeaderText = "تاریخ";
                obj_datagrid.gridControls(grdtoken);
              
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
        #region add row
        private void button2_Click(object sender, EventArgs e)
        {
           // grdfee.RowHeadersVisible = true;
          //  obj_datagrid.addRow(grdfee);
            

            //dtt = obj.filldatatable("select * from from ProductName");
            //dataGridView1.Columns[0].HeaderText = "ProductID";
            //dataGridView1.Columns[1].HeaderText = "ProductName";
            //DataGridViewComboBoxCell bc = new DataGridViewComboBoxCell();
            //bc.Items.AddRange(dtt);
            //foreach (DataRow dr in dtt.Rows)
            //{ bc.Items.Add(dr[0].ToString()); }
            //DataGridViewColumn cc = new DataGridViewColumn(bc);
            //dataGridView1.Columns.Add(cc);
            //dataGridView1.Columns[2].HeaderText = "Check";
            //dataGridView1.Columns["ProductID"].Visible = false;
        }
        #endregion
        #region Calculate Fee from Datagrid
        private void grdfee_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


            int columnIndex = grdfee.CurrentCell.ColumnIndex;
            if (columnIndex == 0)
            {
                //  MessageBox.Show(dataGridViewforBill.CurrentRow.Cells[4].ColumnIndex.ToString());
                if (grdfee.CurrentRow.Cells[0].Value.ToString().Trim() == "" || grdfee.CurrentRow.Cells[0].Value.ToString().Trim() == null)
                {
                    MessageBox.Show("رقم داخل کیجے");
                }

                else
                {

                    string quantity = grdfee.CurrentRow.Cells[0].Value.ToString().Trim();
                    Double last = Convert.ToDouble(quantity);
                    fee = fee + last;
                    this.txtCost.Text = fee.ToString();

                }
            }

        }
        #endregion
        #region add token number to Vocher
        private void grdtoken_DoubleClick(object sender, EventArgs e)
        {
            txtTokenNo.Text = this.grdtoken.CurrentRow.Cells[0].Value.ToString();
            this.button2.Enabled = true;
        }
        #endregion
        #region Validation of DataGrid
        private void grdfee_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
            
        }

        private void Column1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdfee.CurrentCell.ColumnIndex == 0)
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
             else if (grdfee.CurrentCell.ColumnIndex == 1)
            {
                if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if (grdfee.CurrentCell.ColumnIndex == 2)
            {
                if (!char.IsLetter(e.KeyChar)
                   )
                {
                    e.Handled = true;
                }
            }
        }

        #endregion
        #region delete row from token
        private void btnDelete_Click(object sender, EventArgs e)
        {          //  obj_datagrid.deleteRow(grdfee);
                    }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTokenNo.Text!= string.Empty && txtCost.Text != string.Empty)
            {
          
                if (Submit())
                {
                    MessageBox.Show("Saved");
                }
            }

            else
            {
                MessageBox.Show("Empty TextBoxes");

            }
        }

        public bool Submit()
        {
                try
                {
                    if (MessageBox.Show("Do you want to Save:::", "New Token", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string service=grdfee.Rows[0].Cells[3].Value.ToString();
                        string Des = grdfee.Rows[0].Cells[2].Value.ToString();
                        string Pge = grdfee.Rows[0].Cells[0].Value.ToString();
                        MessageBox.Show("insert into token values('" + txtReciptDate.Text + "','" + txtTokenNo.Text + "','" + service + "',N'" + Des + "','" + Pge + "','" + txtCost.Text + "')");
                        
                        //obj.Insert("insert into token values('" + txtReciptDate.Text.ToString() + "','" + txtTokenNo.Text.ToString() + "',N'" + service + "',N'" + Des + "','" + Pge + "','" + txtCost + "',)");
                        //return true;
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message, "Error or Wrong Registration No", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
                    return false;
                }
              return false;
                 }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
       
}

