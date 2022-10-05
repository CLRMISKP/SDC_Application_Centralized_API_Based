using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.DL;

namespace SDC_Application.BL
{
    class DocumentApproval
    {
        #region Class Variables

        Database ojbdb = new Database();

        #endregion

        #region Get Documents Approval Status

        public DataTable GetDocumentApprovalStatus()
        {
            string spWithParams = "Proc_Get_SDC_DocumentsApprovalStatus";
            return  ojbdb.filldatatable_from_storedProcedure(spWithParams);
        }

        #endregion

        #region  update Documents Approval Status
        public void UpdateDocumentApprovalStatus(string TokenId, string Token_CurrentStatus, string Token_CurrentStatus_Reason)
        {
            string spWithParams = "WEB_SP_UPDATE_SDC_TokenStatus "+TokenId+",N'"+Token_CurrentStatus+"',N'"+Token_CurrentStatus_Reason+"'";
            ojbdb.ExecUpdateStoredProcedureWithNoRet(spWithParams);
        }

        public void UpdateDocumentApprovalStatusGardawar(string TokenId, string Token_CurrentStatus, string Token_CurrentStatus_Reason, string GardawarId)
        {
            string spWithParams = "WEB_SP_UPDATE_SDC_TokenStatus_Gardawar " + TokenId + ",N'" + Token_CurrentStatus + "',N'" + Token_CurrentStatus_Reason + "', "+GardawarId;
            ojbdb.ExecUpdateStoredProcedureWithNoRet(spWithParams);
        }
        #endregion

    }
}
