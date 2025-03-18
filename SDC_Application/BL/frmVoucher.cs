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
using Microsoft.VisualBasic.ApplicationServices;
using Org.BouncyCastle.Asn1.Cmp;

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
            string spam = "WEB_SP_INSERT_SDC_PaymentVoucherDetail " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + VocherDetailId + "','" + PVID + "','" + SeqNo + "'," + FGPId + "," + IntiqalId + "," + Notificationunitid + "," + costunitid + "," + Rsperpage + "," + txtquntity + "," + totalamount + ",N'" + PVdetails + "'," + UserId + ",'" + UserName + "'," + UserId1 + ",'" + UserName2 + "'";
            return ojbdb. filldatatable_from_storedProcedure(spam);
        }
        public DataTable SaveVocherDetailsForOtherDistTehsils(string TehsilId, string VocherDetailId, string PVID, string SeqNo, string FGPId, string IntiqalId, string Notificationunitid, string costunitid, string Rsperpage, string txtquntity, string totalamount, string PVdetails, string UserId, string UserName, string UserId1, string UserName2)
        {
            string spam = "WEB_SP_INSERT_SDC_PaymentVoucherDetail " + TehsilId + ",'" + VocherDetailId + "','" + PVID + "','" + SeqNo + "'," + FGPId + "," + IntiqalId + "," + Notificationunitid + "," + costunitid + "," + Rsperpage + "," + txtquntity + "," + totalamount + ",N'" + PVdetails + "'," + UserId + ",'" + UserName + "'," + UserId1 + ",'" + UserName2 + "'";
            return ojbdb.filldatatable_from_storedProcedure(spam);
        }

        public DataTable SaveVocherDetailsSelf(string VocherDetailId, string PVID, string SeqNo, string FGPId, string IntiqalId, string Notificationunitid, string costunitid, string Rsperpage, string txtquntity, string totalamount, string PVdetails, string UserId, string UserName, string UserId1, string UserName2,string TaxId)
        {
            string spam = "WEB_SP_INSERT_SDC_PaymentVoucherDetail " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + VocherDetailId + "','" + PVID + "','" + SeqNo + "'," + FGPId + "," + IntiqalId + "," + Notificationunitid + "," + costunitid + "," + Rsperpage + "," + txtquntity + "," + totalamount + ",N'" + PVdetails + "'," + UserId + ",'" + UserName + "'," + UserId1 + ",'" + UserName2 + "','" + TaxId + "'";
            return ojbdb.filldatatable_from_storedProcedure(spam);
        }
        public DataTable SaveVocherDetailsSelfForOtherDistTehsils(string TehsilId, string VocherDetailId, string PVID, string SeqNo, string FGPId, string IntiqalId, string Notificationunitid, string costunitid, string Rsperpage, string txtquntity, string totalamount, string PVdetails, string UserId, string UserName, string UserId1, string UserName2, string TaxId)
        {
            string spam = "WEB_SP_INSERT_SDC_PaymentVoucherDetail " + TehsilId + ",'" + VocherDetailId + "','" + PVID + "','" + SeqNo + "'," + FGPId + "," + IntiqalId + "," + Notificationunitid + "," + costunitid + "," + Rsperpage + "," + txtquntity + "," + totalamount + ",N'" + PVdetails + "'," + UserId + ",'" + UserName + "'," + UserId1 + ",'" + UserName2 + "','" + TaxId + "'";
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

        public void VoucherGridSelf(DataGridView grdVoucherDetails)
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
            grdVoucherDetails.Columns["ServiceQuantity"].HeaderText = "صفحات";
            grdVoucherDetails.Columns["ServiceCostAmount"].HeaderText = "رقم";

            grdVoucherDetails.Columns["SDCUnitName_Urdu"].Visible = false;
            grdVoucherDetails.Columns["PVId"].Visible = false;
            grdVoucherDetails.Columns["PVDetailRemarks"].Visible = false;
            grdVoucherDetails.Columns["ServiceCostPerUnit"].Visible = false;
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

        public void VoucherGridSelfIntiqal(DataGridView grdVoucherDetails)
        {

            grdVoucherDetails.Columns["PVDetailSeqNo"].DisplayIndex = 0;
            grdVoucherDetails.Columns["SDCServiceName_Urdu"].DisplayIndex = 1;
            grdVoucherDetails.Columns["SDCUnitName_Urdu"].DisplayIndex = 2;
            grdVoucherDetails.Columns["ServiceCostPerUnit"].DisplayIndex = 3;
            grdVoucherDetails.Columns["ServiceQuantity"].DisplayIndex = 4;
            grdVoucherDetails.Columns["ServiceCostAmount"].DisplayIndex = 5;


            grdVoucherDetails.Columns["PVDetailSeqNo"].Width = 40;
            grdVoucherDetails.Columns["SDCServiceName_Urdu"].Width = 100;
            grdVoucherDetails.Columns["SDCUnitName_Urdu"].Width = 60;
            grdVoucherDetails.Columns["ServiceCostPerUnit"].Width = 60;
            grdVoucherDetails.Columns["ServiceQuantity"].Width = 100;
            grdVoucherDetails.Columns["ServiceCostAmount"].Width = 100;

            grdVoucherDetails.Columns["PVDetailSeqNo"].HeaderText = "نمبرشمار";
            grdVoucherDetails.Columns["SDCServiceName_Urdu"].HeaderText = "سہولت";
            grdVoucherDetails.Columns["SDCUnitName_Urdu"].HeaderText = "اکائی";
            grdVoucherDetails.Columns["ServiceCostPerUnit"].HeaderText = "شرح فی اکائی";
            grdVoucherDetails.Columns["ServiceQuantity"].HeaderText = "تعداد /قیمت";
            grdVoucherDetails.Columns["ServiceCostAmount"].HeaderText = "رقم";

           // grdVoucherDetails.Columns["SDCUnitName_Urdu"].Visible = false;
            grdVoucherDetails.Columns["PVId"].Visible = false;
            grdVoucherDetails.Columns["PVDetailRemarks"].Visible = false;
            //grdVoucherDetails.Columns["ServiceCostPerUnit"].Visible = false;
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
        public DataTable GetPaymirDetailForRequestPosting(string PvDetailId)
        {
            string spam = "Proc_Get_PyamirDetailForRequestPosting '" + PvDetailId + "'";
            return ojbdb.filldatatable_from_storedProcedure(spam);
        }
        public void UpdatePaymirRequestResponse(string PVDetailId, string PaymirRequest, string PaymirResponse)
        {
            string spWithParams = "Web_Sp_Update_Payment_Request_Response '" + PVDetailId + "','" + PaymirRequest + "','" + PaymirResponse + "'";
            ojbdb.ExecUpdateStoredProcedureWithNoRet(spWithParams);

        }

        #region Save Land Tax Entry

        public string SaveAIT(string AIT_RecId, string TehsilId, string PersonId, string Year, string Kanal, string Marla, string Sarsai, string Rate, string Relief, string NetTax, string UserId, string UserName)
        {
            string qry = "WEB_SP_INSERT_AIT_RECORD " + AIT_RecId +","+ TehsilId + "," + PersonId + "," + Year + "," + Kanal + "," + Marla + "," + Sarsai + "," + Rate + "," + Relief + "," + NetTax +"," + UserId + ",'" + UserName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(qry);
        }

        #endregion

        #region Get Tax Collected from Malik
        public DataTable Get_AIT_Tax_By_PersonId(string PersonId)
        {
            return ojbdb.filldatatable_from_storedProcedure("proc_Get_AIT_Record  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PersonId);
        }
        #endregion
    }
}