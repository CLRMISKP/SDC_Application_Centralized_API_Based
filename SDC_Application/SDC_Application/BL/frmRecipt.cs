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
using SDC_Application.DL;

namespace SDC_Application.BL
{
    class frmRecipt
    {
        DL.Database ojbdb = new Database();
        datagrid_controls objdatagrid = new datagrid_controls();
        //public DataTable fillDataTable(string b)
        //{
        //    return ojbdb.fillDataTable(b);
        //}
        public DataTable SaveRecptDetails(string @RVDetailId, string @RVId,string @PVDetailId, string @RVDetailSeqNo, string @TaxNotificationDetailId, string @NetPayableAmount, string @PaymentTypeId, string @ReceivedAmountv, string @ChallanNo, string @ChallanDate, string @BankAccountNo, string @BankName, string @BankBranchName, string @InsertUserId, string @InsertLoginName, string @UpdateUserId, string @UpdateLoginName)
        {
            string spam = "WEB_SP_INSERT_SDC_ReceiptVoucherDetail '" + @RVDetailId + "','" + @RVId + "','" + @PVDetailId + "'," + @RVDetailSeqNo + "," + @TaxNotificationDetailId + "," + @NetPayableAmount + ",'" + @PaymentTypeId + "'," + @ReceivedAmountv + ",'" + @ChallanNo + "','" + @ChallanDate + "','" + @BankAccountNo + "','" + @BankName + "','" + @BankBranchName + "'," + @InsertUserId + ",'" + @InsertLoginName + "'," + @UpdateUserId + ",'" + @UpdateLoginName + "'";
            return ojbdb.filldatatable_from_storedProcedure(spam);
        }
        public DataTable filldatatable_from_storedProcedure(string Query)
        {
            return ojbdb.filldatatable_from_storedProcedure(Query);
        }
        public DataTable viewGridData(string b)
        {
            return ojbdb.viewGridData(b);
        }
        public int Insert_StoreProcedure(string str)
        {
            return ojbdb.Insert_StoreProcedure(str);

        }
        public SqlDataReader fillDataReader(string str)
        {
            return ojbdb.fillDataReader(str);
        }
        public void VoucherGrid(DataGridView grdRecipt)
        {
            grdRecipt.Columns["RVDetailSeqNo"].DisplayIndex = 0;
            grdRecipt.Columns["SDCServiceName_Urdu"].DisplayIndex = 1;
            grdRecipt.Columns["PaymentType_Urdu"].DisplayIndex = 3;
            grdRecipt.Columns["PVDetailRemarks"].DisplayIndex = 2;
            grdRecipt.Columns["NetPayableAmount"].DisplayIndex = 4;
            grdRecipt.Columns["ReceivedAmount"].DisplayIndex = 5;

            grdRecipt.Columns["RVDetailSeqNo"].HeaderText = "نمبرشمار";
            grdRecipt.Columns["SDCServiceName_Urdu"].HeaderText = "سہولت";
            grdRecipt.Columns["PaymentType_Urdu"].HeaderText = "رقم کی ادائیگی بذریعہ";
            grdRecipt.Columns["PVDetailRemarks"].HeaderText = "تفصیل";
            grdRecipt.Columns["NetPayableAmount"].HeaderText = "قابل ادا رقم";
            grdRecipt.Columns["ReceivedAmount"].HeaderText = "وصول کیگئ رقم";


            grdRecipt.Columns["BankAccountNo"].Visible = false;
            grdRecipt.Columns["BankName"].Visible = false;
            grdRecipt.Columns["BankBranchName"].Visible = false;
            grdRecipt.Columns["PaymentTypeId"].Visible = false;
            grdRecipt.Columns["RVDetailId"].Visible = false;
            //grdRecipt.Columns["PVDetailRemarks"].Visible = false;
            grdRecipt.Columns["PVDetailId"].Visible = false;
           //  grdRecipt.Columns["SDCServiceId"].Visible = false;
            grdRecipt.Columns["RVId"].Visible = false;
            grdRecipt.Columns["ChallanNo"].Visible = false;
            grdRecipt.Columns["TaxNotificationDetailId"].Visible = false;
            grdRecipt.Columns["ChallanDate"].Visible = false;
            objdatagrid.colorrbackgrid(grdRecipt);
            objdatagrid.gridControls(grdRecipt);
            grdRecipt.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grdRecipt.DefaultCellStyle.ForeColor = Color.Black;
            
        }
    }
}
