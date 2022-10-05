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
using SDC_Application.AL;

namespace SDC_Application.BL
{
    class frmVoucher
    {
        DL.Database ojbdb = new Database();
        datagrid_controls objdatagrid = new datagrid_controls();
        

        //public DataTable fillDataTable(string b)
        //{
        //    return ojbdb.fillDataTable(b);
        //}
        public DataTable SaveVocherDetails(string VocherDetailId, string PVID,string SeqNo,string FGPId,string IntiqalId, string Notificationunitid,string costunitid,string Rsperpage,string txtquntity,string totalamount,string PVdetails, string UserId, string UserName, string UserId1, string UserName2)
        {
            string spam = "WEB_SP_INSERT_SDC_PaymentVoucherDetail '" + VocherDetailId + "','" + PVID + "','" + SeqNo + "'," + FGPId + ","+IntiqalId+"," + Notificationunitid + "," + costunitid + "," + Rsperpage + "," + txtquntity + "," + totalamount + ",N'" + PVdetails + "'," + UserId + ",'" + UserName + "'," + UserId1 + ",'" + UserName2 + "'";
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
        public void VoucherGrid(DataGridView grdVoucherDetails)
        {

            grdVoucherDetails.Columns["PVDetailSeqNo"].DisplayIndex = 0;
            grdVoucherDetails.Columns["SDCServiceName_Urdu"].DisplayIndex = 1;
            grdVoucherDetails.Columns["PVDetailRemarks"].DisplayIndex = 2;
            grdVoucherDetails.Columns["ServiceCostPerUnit"].DisplayIndex = 3;
            grdVoucherDetails.Columns["ServiceQuantity"].DisplayIndex = 4;
            grdVoucherDetails.Columns["ServiceCostAmount"].DisplayIndex = 5;


            grdVoucherDetails.Columns["PVDetailSeqNo"].Width = 60;
            grdVoucherDetails.Columns["SDCServiceName_Urdu"].Width = 80;
            grdVoucherDetails.Columns["PVDetailRemarks"].Width = 300;
            grdVoucherDetails.Columns["ServiceCostPerUnit"].Width = 40;
            grdVoucherDetails.Columns["ServiceQuantity"].Width = 40;
            grdVoucherDetails.Columns["ServiceCostAmount"].Width = 60;

            grdVoucherDetails.Columns["PVDetailSeqNo"].HeaderText = "نمبرشمار";
            grdVoucherDetails.Columns["SDCServiceName_Urdu"].HeaderText = "سہولت";
            grdVoucherDetails.Columns["PVDetailRemarks"].HeaderText = "تفصیل";
            grdVoucherDetails.Columns["ServiceCostPerUnit"].HeaderText = "قیمت فی صفحہ";
            grdVoucherDetails.Columns["ServiceQuantity"].HeaderText = "مقدار";
            grdVoucherDetails.Columns["ServiceCostAmount"].HeaderText = "رقم";

            grdVoucherDetails.Columns["SDCUnitName_Urdu"].Visible = false;
            grdVoucherDetails.Columns["PVId"].Visible = false;
            grdVoucherDetails.Columns["PVDetailId"].Visible = false;
           // grdVoucherDetails.Columns["SDCServiceId"].Visible = false;
            grdVoucherDetails.Columns["TaxNotificationDetailId"].Visible = false;
            grdVoucherDetails.Columns["SDCUnitId"].Visible = false;
            grdVoucherDetails.Columns["PaymentTypeId"].Visible = false;
            grdVoucherDetails.Columns["PaymentType_Urdu"].Visible = false;
          
            objdatagrid.colorrbackgrid(grdVoucherDetails);
            objdatagrid.gridControls(grdVoucherDetails);
            grdVoucherDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grdVoucherDetails.DefaultCellStyle.ForeColor = Color.Black;
         
            
        }
        public void VoucherGridAddtoTextFields(DataGridView grdVoucherDetails)
        {
         
            
        }
       
    }
}