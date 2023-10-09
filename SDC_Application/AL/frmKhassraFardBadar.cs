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
    public partial class frmKhassraFardBadar : Form
    {

        #region Properties

        public string KhataId { get; set; }
        public string KhassraId { get; set; }
        public string KhassraDetailId { get; set; }
        public string  KhassraNo { get; set; }
        public string KhassraTypeId { get; set; }
        public string KhassraKanal { get; set; }
        public string  khassraMarla { get; set; }
        public string  khassraSarsai { get; set; }
        public string KhassraFeet { get; set; }
        public string KhatoniNo { get; set; }
        public string khatoniId { get; set; }

        bool btnClick = false;

        #endregion

        Intiqal inteq  = new Intiqal();

        public frmKhassraFardBadar()
        {
            InitializeComponent();
        }

        #region Save Intiqal Min Khasra Jat

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridViewKhassra.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == 1)
                {
                    this.KhassraId = row.Cells["KhassraId"].Value != null ? row.Cells["KhassraId"].Value.ToString() : "0";
                    this.KhassraDetailId = row.Cells["KhassraDetailId"].Value != null ? row.Cells["KhassraDetailId"].Value.ToString() : "0";
                    this.KhassraNo = row.Cells["KhassraNo"].Value != null ? row.Cells["KhassraNo"].Value.ToString() : "0";
                    this.KhatoniNo = row.Cells["KhatooniNo"].Value != null ? row.Cells["KhatooniNo"].Value.ToString() : "0";
                    this.khatoniId = row.Cells["KhatooniId"].Value != null ? row.Cells["KhatooniId"].Value.ToString() : "0";
                    string[] Raqba = row.Cells["Khassra_Area"].Value.ToString().Split('-');
                    this.KhassraTypeId = row.Cells["AreaTypeId"].Value.ToString();
                    this.KhassraKanal = Raqba[0].ToString();
                    this.khassraMarla = Raqba[1].ToString();
                    //string sarsai = Raqba[2].ToString();
                    this.khassraSarsai = Raqba[2].ToString();
                    this.KhassraFeet =Math.Round(Convert.ToDecimal((float.Parse(khassraSarsai) * (float)30.25))).ToString();
                    this.Close();
                 }              
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
