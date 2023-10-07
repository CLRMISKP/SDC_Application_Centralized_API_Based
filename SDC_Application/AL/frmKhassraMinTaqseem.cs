using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.ServiceModel;
//using LandInfo.Client.AmalDaramdProxy;
//using LandInfo.Client.Classes;
using SDC_Application.Classess;
using SDC_Application.BL;


namespace SDC_Application.AL
{
    public partial class frmKhassraMinTaqseem : Form
    {

        #region Properties

        public int khattaId { get; set; }
        public string KhataId { get; set; }
        public string  IntiqalMinGroupId { get; set; }
        public string IntiqalId { get; set; }
        bool btnClick = false;

        #endregion

        Intiqal inteq  = new Intiqal();

        public frmKhassraMinTaqseem()
        {
            InitializeComponent();
        }

        #region Save Intiqal Min Khasra Jat

        private void btnSave_Click(object sender, EventArgs e)
        {

            int RecSel = 0;
            foreach (DataGridViewRow row in gridViewKhassra.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == 1)
                {
                
                    RecSel += 1; //for checking weather user select any row to insert.
                    string KhassraId = row.Cells["KhassraId"].Value != null ? row.Cells["KhassraId"].Value.ToString() : "0";
                    string KhassraNo = row.Cells["KhassraNo"].Value != null ? row.Cells["KhassraNo"].Value.ToString() : "0";
                    string KhatoniNo = row.Cells["KhatooniNo"].Value != null ? row.Cells["KhatooniNo"].Value.ToString() : "0";
                    string khatoniId = row.Cells["KhatooniId"].Value != null ? row.Cells["KhatooniId"].Value.ToString() : "0";
                    string[] Raqba = row.Cells["Khassra_Area"].Value.ToString().Split('-');
                    string AreaTypeId = row.Cells["AreaTypeId"].Value.ToString();
                    string kanal = Raqba[0].ToString();
                    string Marla = Raqba[1].ToString();
                    //string sarsai = Raqba[2].ToString();
                    float sarsai = float.Parse(Raqba[2]);
                    string OldKhassraDetailId = row.Cells["KhassraId"].Value.ToString();
                   string s = inteq.SaveIntiqalMinKhassra("-1", this.IntiqalId, this.IntiqalMinGroupId, this.KhataId, khatoniId, KhassraId, "-1", OldKhassraDetailId, "0", KhassraNo, KhatoniNo, AreaTypeId, "2", kanal, Marla, sarsai, sarsai * (float)30.25, "19001", "Admin", "19001", "Admin", "19001");                  
                }              
            }
            if (RecSel > 0)
            {
                MessageBox.Show(" ریکارڈ محفوظ ہو گیا", "خسرہ جات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("آپ نے کسی ریکارڈ کا انتخاب نہیں کیا","خسرہ جات",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        # region Fill Khasra Jat Grid

        public void FillKhasraGrid()
        {
            DataTable dt = new DataTable();
            dt = inteq.GetKhassraJatByKhattaId(this.KhataId);
            gridViewKhassra.DataSource = dt;
            gridViewKhassra.Columns["KhatooniNo"].HeaderText = "کھتونی نمبر";
            gridViewKhassra.Columns["KhassraNo"].HeaderText = "خسرہ نمبر";
            gridViewKhassra.Columns["AreaType"].HeaderText = "قسم رقبہ";
            gridViewKhassra.Columns["Khassra_Area"].HeaderText = "رقبہ";
            gridViewKhassra.Columns["RegisterHqDKhataId"].Visible = false;
            gridViewKhassra.Columns["KhassraId"].Visible = false;
            gridViewKhassra.Columns["KhassraDetailId"].Visible = false;
            gridViewKhassra.Columns["KhatooniId"].Visible = false;          
            gridViewKhassra.Columns["AreaTypeId"].Visible = false; 
        }

        #endregion

        private void frmKhassraMinTaqseem_Load(object sender, EventArgs e)
        {
            String showFormName = System.Configuration.ConfigurationSettings.AppSettings["showFormName"];
            if (showFormName != null && showFormName.ToUpper() == "TRUE") this.Text = this.Name + "|" + this.Text;DataGridViewHelper.addHelpterToAllFormGridViews(this);

           FillKhasraGrid();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {

            if (this.gridViewKhassra.Rows.Count > 0)
            {
                if (btnClick == false)
                {
                    foreach (DataGridViewRow row in gridViewKhassra.Rows)
                    {

                        row.Cells[0].Value = 1;

                    }
                    btnClick = true;
                }
                else
                {
                    foreach (DataGridViewRow row in gridViewKhassra.Rows)
                    {

                        row.Cells[0].Value = 0;

                    }
                    btnClick = false;
                }
            }
            
        }

        private void txtKhassraNo_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridViewKhassra.Rows)
            {
                if ((row.Cells[1].Value != null ? row.Cells[1].Value.ToString() : "").Contains(txtKhassraNo.Text.Trim()))
                {
                    row.Selected = true;
                    gridViewKhassra.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void gridViewKhassra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView g = sender as DataGridView;
            if (e.ColumnIndex == gridViewKhassra.CurrentRow.Cells["chk"].ColumnIndex)
            {

                if (Convert.ToInt32(gridViewKhassra.CurrentRow.Cells["chk"].Value) ==1)
                        {
                            gridViewKhassra.CurrentRow.Cells["chk"].Value = 0;
                          
                        }
                else
                {
                    gridViewKhassra.CurrentRow.Cells["chk"].Value = 1;
                }

            }
        }
    }
}
