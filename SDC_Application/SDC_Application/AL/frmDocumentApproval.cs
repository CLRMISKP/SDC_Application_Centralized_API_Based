using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using SDC_Application.BL;
using SDC_Application.Classess;
using SDC_Application.LanguageManager;

namespace SDC_Application.AL
{
    public partial class frmDocumentApproval : Form
    {
        #region class variable
        byte[] DeSerializee;
        DPFP.Template Template = new DPFP.Template();

        public string FPTempByte
        { get; set; }
        public bool Btn
        { get; set; }
        Image RetrunImgae1;
        DL.Database ObjDB = new DL.Database();
        DataTable dt;
        DocumentApproval docApp = new DocumentApproval();
        LanguageConverter lang = new LanguageConverter();
        #endregion

        public frmDocumentApproval()
        {
            InitializeComponent();
        }
        #region Set Tool Tip for the controls

        private void setToolTip()
        {
            toolTipDocApp.SetToolTip(btnApprove,"منظورکریں");
            toolTipDocApp.SetToolTip(btndisApprove, "نامنظورکریں");
            toolTipDocApp.SetToolTip(btnsearch,"تلاش کریں");
            toolTipDocApp.SetToolTip(cbdisAprove, "نامنظور");
            toolTipDocApp.SetToolTip(cbApprove,"منظور");
            toolTipDocApp.SetToolTip(cbprev,"گزشتہ دستاویزات");
            toolTipDocApp.SetToolTip(dtpFrom,"شروع تاریخ");
            toolTipDocApp.SetToolTip(dtpTo,"آخری تاریخ");

        }

        #endregion
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Approved();
        }
        public void Approved()
        {
            if (gridViewDocments.SelectedRows.Count > 0)
            {
                DataGridViewRow row = gridViewDocments.SelectedRows[0];
                string TokenId = row.Cells["TokenId"].Value.ToString();
                string Token_CurrentStatus = "منظور";
                //string Token_CurrentStatus_Timestamp = row.Cells["Token_CurrentStatus_Timestamp"].Value.ToString();
                docApp.UpdateDocumentApprovalStatusGardawar(TokenId, Token_CurrentStatus, "", UsersManagments.UserId.ToString());
                string datefrom = dtpFrom.Value.ToShortDateString();
                string dateTo = dtpTo.Value.ToShortDateString();
               // string dateTo = dtpTo.Value.ToShortDateString();
               // string abc = Convert.ToString(dateExact.Text);
                if (cbprev.Checked && cbApprove.Checked)
                {
                    this.FillDocAppGrid("Token_CurrentStatus='منظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                }
                else
                    if (cbprev.Checked && cbdisAprove.Checked)
                    {
                        this.FillDocAppGrid("Token_CurrentStatus='نامنظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");

                    }
                    else
                        if (cbprev.Checked && !cbdisAprove.Checked && !cbApprove.Checked)
                        {
                            this.FillDocAppGrid("Token_CurrentStatus<>''and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                        }
                        
                        else
                        {
                            this.FillDocAppGrid("Token_CurrentStatus=''");
                        }

            }
        }

        #region  Form Load event

       
        private void frmDocumentApproval_Load(object sender, EventArgs e)
        {
            setToolTip();
            this.FillDocAppGrid("Token_CurrentStatus=''");
            
        }
        #endregion

        #region Fill Document Approval Grid

        private void FillDocAppGrid(string Condition)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            dt = docApp.GetDocumentApprovalStatus();
            DataView v = new DataView(dt);
            v.RowFilter = Condition;
            gridViewDocments.DataSource = v;
            if (v != null)
            {
                gridViewDocments.Columns["TokenDateTime"].Visible = false;
                gridViewDocments.Columns["TokenDate"].HeaderText = "ٹوکن تاریخ";
                gridViewDocments.Columns["TokenId"].Visible = false;
                gridViewDocments.Columns["TokenNo"].HeaderText = "ٹوکن نمبر";
                gridViewDocments.Columns["Visitor_Name"].HeaderText = "سائل کانام";
                gridViewDocments.Columns["Visitor_FatherName"].Visible = false;
                gridViewDocments.Columns["Visitor_CNIC"].HeaderText = "سائل کا شناختی کارڈ نمبر";
                gridViewDocments.Columns["ServiceTypeId"].Visible = false;
                gridViewDocments.Columns["TokenService_For_MozaId"].Visible = false;
                gridViewDocments.Columns["MozaNameUrdu"].HeaderText = "موضع";
                gridViewDocments.Columns["ServiceTypeName_Urdu"].HeaderText = "سروس کی قسم کا نام";
                gridViewDocments.Columns["PVId"].Visible = false;
                gridViewDocments.Columns["GrossAmount"].HeaderText = "مجموعی رقم";
                gridViewDocments.Columns["RVID"].Visible = false;
                gridViewDocments.Columns["receivedAmount"].HeaderText = "رقم اصول";
                gridViewDocments.Columns["Token_CurrentStatus"].HeaderText = "ٹوکن کی موجودہ حیثیت";
                gridViewDocments.Columns["Token_CurrentStatus_Reason"].HeaderText = "وجہ نامنظوری ";
                gridViewDocments.Columns["Token_CurrentStatus_Timestamp"].Visible = false;
            }
        }

        #endregion


        #region Gridview cell content click
        
       
        private void gridViewDocments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex != 0 || e.RowIndex < 0)
                //return;
            if (e.ColumnIndex == 1)
            {
                frmRecordVarification ver = new frmRecordVarification();
                ver.TokenId = gridViewDocments.Rows[e.RowIndex].Cells["TokenId"].Value != null ? gridViewDocments.Rows[e.RowIndex].Cells["TokenId"].Value.ToString() : "0";
                ver.MozaId = gridViewDocments.Rows[e.RowIndex].Cells["TokenService_For_MozaId"].Value != null ? gridViewDocments.Rows[e.RowIndex].Cells["TokenService_For_MozaId"].Value.ToString() : "0";
                ver.TokenServiceId = gridViewDocments.Rows[e.RowIndex].Cells["ServiceTypeId"].Value != null ? gridViewDocments.Rows[e.RowIndex].Cells["ServiceTypeId"].Value.ToString() : "0"; 
                if (ver.TokenId != "0" && ver.MozaId != "0")
                {
                    ver.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Unable to Load Khattas for Verification", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ver.Dispose();
                }
            }
            DataGridView g = sender as DataGridView;
            foreach (DataGridViewRow row in g.Rows)
            {
                if (row.Index == e.RowIndex)
                {
                    row.Cells["gridcb"].Value = 1;
                }
                else
                {
                    row.Cells["gridcb"].Value = 0;
                }
            
            }
        }
        #endregion

        #region Button Approve click event
        
        
        private void btnApprove_Click(object sender, EventArgs e)
        {
            

        }
        #endregion

        #region Button Disapprove click event
        
       
        private void btndisApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewDocments.SelectedRows.Count > 0)
                {
                    string TokenId = gridViewDocments.SelectedRows[0].Cells["TokenId"].Value.ToString();

                    frmdisApprovedetail DisApprove = new frmdisApprovedetail();
                    DisApprove.TokenId = TokenId;
                    DisApprove.FormClosed -= new FormClosedEventHandler(DisApprove_FormClosed);
                    DisApprove.FormClosed += new FormClosedEventHandler(DisApprove_FormClosed);
                    DisApprove.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        
       
        }
        #endregion

        #region Form Disapprove closed event
        
        
        void DisApprove_FormClosed(object sender, FormClosedEventArgs e)
        {
            string datefrom = dtpFrom.Value.ToShortDateString();
            string dateTo = dtpTo.Value.ToShortDateString();
            if (cbprev.Checked && cbApprove.Checked)
            {
                this.FillDocAppGrid("Token_CurrentStatus='منظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
            }
            else
                if (cbprev.Checked && cbdisAprove.Checked)
                {
                    this.FillDocAppGrid("Token_CurrentStatus='نامنظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");

                }
                else
                    if (cbprev.Checked && !cbdisAprove.Checked && !cbApprove.Checked)
                    {
                        this.FillDocAppGrid("Token_CurrentStatus<>''and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                    }
                    else
                    {
                        this.FillDocAppGrid("Token_CurrentStatus=''");
                    }
        }
        #endregion

        #region checkBox previous check changed event
        
       
        private void cbprev_CheckedChanged(object sender, EventArgs e)
        {
            string datefrom = dtpFrom.Value.ToShortDateString();
            string dateTo = dtpTo.Value.ToShortDateString();
            
            
            if (cbprev.Checked )
            {
               
               
                this.FillDocAppGrid("Token_CurrentStatus<>'' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
               
                cbdisAprove.Visible = true;
                cbApprove.Visible = true;
                dtpTo.Visible = true;
                dtpFrom.Visible = true;
                lblFrom.Visible = true;
                lblTo.Visible = true;
                panel3.Visible =true;
                dateExact.Visible = false;


            }
            else

                if(!cbprev.Checked && cbdisAprove.Checked )
            {
                cbdisAprove.Checked = false;
                this.FillDocAppGrid("Token_CurrentStatus=''");
                cbdisAprove.Visible = false;
                cbApprove.Visible = false;
                dtpTo.Visible = false;
                dtpFrom.Visible = false;
                lblFrom.Visible = false;
                lblTo.Visible = false;
                panel3.Visible = false;
            }
            else
                    if (!cbprev.Checked && cbApprove.Checked)
                    {
                        cbApprove.Checked = false;
                        this.FillDocAppGrid("Token_CurrentStatus=''");
                        cbdisAprove.Visible = false;
                        cbApprove.Visible = false;
                        dtpTo.Visible = false;
                        dtpFrom.Visible = false;
                        lblFrom.Visible = false;
                        lblTo.Visible = false;
                        panel3.Visible = false;
                    }
            else
                        if (!cbdisAprove.Checked && !cbApprove.Checked && !cbprev.Checked)
                        {
                            this.FillDocAppGrid("Token_CurrentStatus=''");
                            cbdisAprove.Visible = false;
                            cbApprove.Visible = false;
                            dtpTo.Visible = false;
                            dtpFrom.Visible = false;
                            lblFrom.Visible = false;
                            lblTo.Visible = false;
                            panel3.Visible = false;
                            dateExact.Visible = true;
                        }
                        
        }
        #endregion

        #region checkBox Disapprove check changed event
        
        
        private void cbdisAprove_CheckedChanged(object sender, EventArgs e)
        {

            string datefrom = dtpFrom.Value.ToShortDateString();
            string dateTo = dtpTo.Value.ToShortDateString();

            
            if (cbdisAprove.Checked && cbApprove.Checked )
            {
                cbApprove.Checked = false;
                FillDocAppGrid("Token_CurrentStatus='نامنظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
              
            
            }
            else
                if (!cbdisAprove.Checked && !cbApprove.Checked )
                {
                   
                    FillDocAppGrid("Token_CurrentStatus<>'' and (TokenDate>='" + datefrom + "' and TokenDate <='" + dateTo + "')");

                }
            else
                    if(cbdisAprove.Checked && !cbApprove.Checked)
                    {
                        FillDocAppGrid("Token_CurrentStatus='نامنظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                    }
                
        }
        #endregion

        #region checkBox Approve check changed event
        
      
        private void cbApprove_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string datefrom = dtpFrom.Value.ToShortDateString();
                string dateTo = dtpTo.Value.ToShortDateString();

                if (cbApprove.Checked && cbdisAprove.Checked)
                {
                    cbdisAprove.Checked = false;

                    
                    FillDocAppGrid("Token_CurrentStatus='منظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                   
                }
                else
                    if (!cbApprove.Checked && !cbdisAprove.Checked )
                    {
                        FillDocAppGrid("Token_CurrentStatus<>'' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                    }
                else
                        if (cbApprove.Checked && !cbdisAprove.Checked)
                        {
                            FillDocAppGrid("Token_CurrentStatus='منظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                        }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            }
        #endregion

        #region Datetimepicker from value changed event
        
       
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            string datefrom = dtpFrom.Value.ToShortDateString();
            string dateTo = dtpTo.Value.ToShortDateString();
            if(cbApprove.Checked)
            {
               
                FillDocAppGrid("Token_CurrentStatus='منظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");

            }
            else
                if (cbdisAprove.Checked)
                {
                    FillDocAppGrid("Token_CurrentStatus='نامنظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                }
                else
                {
                    FillDocAppGrid("Token_CurrentStatus<>'' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                }
        }
        #endregion

        #region datetimepicker To value changed event
        
       
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            string datefrom = dtpFrom.Value.ToShortDateString();
            string dateTo = dtpTo.Value.ToShortDateString();
            if (cbApprove.Checked)
            {

                FillDocAppGrid("Token_CurrentStatus='منظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");

            }
            else
                if (cbdisAprove.Checked)
                {
                    FillDocAppGrid("Token_CurrentStatus='نامنظور' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                }
                else
                {
                    FillDocAppGrid("Token_CurrentStatus<>'' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                }
        }
        #endregion


        #region Gridview selection changed
        
       
        private void gridViewDocments_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView g = sender as DataGridView;
            
            
            foreach (DataGridViewRow row in g.Rows)
            {
                if (gridViewDocments.SelectedRows.Count > 0)
                {
                    if (row.Index == gridViewDocments.SelectedRows[0].Index)
                    {
                        row.Cells["gridcb"].Value = 1;
                    }
                    else
                    {
                        row.Cells["gridcb"].Value = 0;
                    }
                    if (gridViewDocments.SelectedRows[0].Cells["Token_CurrentStatus"].Value.ToString() == "منظور")
                    {
                        this.btnApprove.Enabled = false;
                        this.btndisApprove.Enabled = false;
                    }
                    else
                    {
                        this.btnApprove.Enabled = true;
                        this.btndisApprove.Enabled = true;
                    }
                }
            }
        }
        #endregion

        #region Button search click event
        
        
        private void btnsearch_Click(object sender, EventArgs e)
        {
            string Name = this.txtsearch.Text;
            string datefrom = dtpFrom.Value.ToShortDateString();
            string dateTo = dtpTo.Value.ToShortDateString();
            string abc = Convert.ToString(dateExact.Text);
            if(cbprev.Checked && !cbdisAprove.Checked && !cbApprove.Checked)
            {
                FillDocAppGrid(" Token_CurrentStatus<>'' and TokenNo='" + Name + "' or Visitor_Name like '%" + Name + "%'  and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
            }
            else
                if(cbApprove.Checked)
                {
                    FillDocAppGrid(" Token_CurrentStatus='منظور' and Visitor_Name like '%"+ Name +"%' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                }
            else
                    if (cbdisAprove.Checked)
                    {
                        FillDocAppGrid(" Token_CurrentStatus<>'نامنظور' and Visitor_Name like '%"+ Name + "%' and (TokenDate >= '" + datefrom + "' and TokenDate <='" + dateTo + "')");
                    }
                    else
                    {
                        
                        FillDocAppGrid("Token_CurrentStatus<>'' and TokenDate='"+abc+"' and TokenNo='" + Name + "' or Visitor_Name like '%" + Name + "%' ");
                    }


           


        }
        #endregion


        
        
        
        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
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

        private void verificationControl1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Loaded");
        }

        private void verificationControl1_OnComplete(object Control, DPFP.FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus EventHandlerStatus)
        {
            
            dt = ObjDB.filldatatable_from_storedProcedure("Proc_Get_FingerPrint_By_UserId " + UsersManagments.UserId.ToString() );
            int count = dt.Rows.Count;
            if (count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    this.DeSerializee = (byte[])row["FingerPrintImage"];
                }

                DPFP.Template template = new DPFP.Template();
                MemoryStream msDB = new MemoryStream(DeSerializee);
                template.DeSerialize(msDB);



                DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                Verificator.Verify(FeatureSet, template, ref result);
                if (result.Verified)
                {
                    this.txtsearch.Text=this.gridViewDocments.CurrentRow.Cells["TokenNo"].Value.ToString();
                    dateExact.Value=Convert.ToDateTime(this.gridViewDocments.CurrentRow.Cells["TokenDate"].Value);
                    dateExact.Value.ToShortDateString();
                    cbprev.Checked = false;
                    Approved();
                    
                    
                }
                else
                {
                    MessageBox.Show("Keep the Finger Stored In DB");
                }
            }
            //btnsearch_Click(sender, e);
        }
       
    }   
        }

       
    

