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
    public partial class frmIntiqalMinhayeIntiqal : Form
    {
        #region Class Variables

        DataTable Intiqals  = new DataTable();
        DataTable MinhayeIntiqals = new DataTable();
        public int IntiqalId { get; set; }
        public int MozaId { get; set; }
        Intiqal Iq = new Intiqal();

        #endregion

        #region Default Constructor

        public frmIntiqalMinhayeIntiqal()
        {
            InitializeComponent();
        }

        #endregion

        #region Button Save Click Event


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbIntialListForMinhayeIntiqal.SelectedValue.ToString() != "0")
                {
                    if (this.IntiqalId != Convert.ToInt32(cmbIntialListForMinhayeIntiqal.SelectedValue))
                    {
                        string LastId = Iq.SaveIntiqalMinhayeIntiqal(this.IntiqalId.ToString(), cmbIntialListForMinhayeIntiqal.SelectedValue.ToString());
                        this.FilldgMinhayeIntiqal();
                    }
                    else
                    {
                        MessageBox.Show("انتقال ہذا منہائے انتقال نہیں ہو سکتا۔","منہائے انتقال", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region Form Load Event

        private void frmIntiqalMinhayeIntiqal_Load(object sender, EventArgs e)
        {
            this.fillIntiqalListForMinhayeIntiqal(this.MozaId.ToString());
            this.FilldgMinhayeIntiqal();
        }

        #endregion

        #region Get Intiqal list for Minhaye Intiqal

        private void fillIntiqalListForMinhayeIntiqal(string MozaIdForIntiqalList)
        {
            try
            {
                this.Intiqals = Iq.GetintiqalNoListByMozaId(MozaIdForIntiqalList);
                DataRow IntiqalType = Intiqals.NewRow();
                IntiqalType["IntiqalId"] = "0";
                IntiqalType["IntiqalNo"] = " - انتقال کا انتخاب کریں - ";
                Intiqals.Rows.InsertAt(IntiqalType, 0);
                cmbIntialListForMinhayeIntiqal.DataSource = Intiqals;
                cmbIntialListForMinhayeIntiqal.DisplayMember = "IntiqalNo";
                cmbIntialListForMinhayeIntiqal.ValueMember = "IntiqalId";
                cmbIntialListForMinhayeIntiqal.SelectedValue = 0;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
            
        }

        #endregion

        #region Fill GridView Minhaye Intiqals

        private void FilldgMinhayeIntiqal()
        {
            try
            {
                MinhayeIntiqals = Iq.GetIntiqalMinhayeIntiqals(this.IntiqalId.ToString());
                dgMinhayeIntiqal.DataSource = MinhayeIntiqals;
                // Set Columns 
                if(MinhayeIntiqals!=null)
                {
                dgMinhayeIntiqal.Columns["IntiqalNo"].HeaderText = "بعد از منہائے انتقال نمبر";
                dgMinhayeIntiqal.Columns["AmalDaramadStatus"].HeaderText = "موجودہ حالت عملدرامد";
                dgMinhayeIntiqal.Columns["MinhayeIntiqalId"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        #endregion

        #region dgMinhayeIntiqalCell Click Event

        private void dgMinhayeIntiqal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            try
            {
                if (g.CurrentCell == g.CurrentRow.Cells["ColSel"])
                {
                    if (MessageBox.Show(" انتخاب کردہ ریکارڈ خذف کرنا چاہتے ہو؟", "خذف کریں", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Iq.DeleteIntiqalMinhayeIntiqals(g.CurrentRow.Cells["MinhayeIntiqalId"].Value.ToString());
                        this.FilldgMinhayeIntiqal();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
