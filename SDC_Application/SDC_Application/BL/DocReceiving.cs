using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDC_Application.DL;
using System.Data;

namespace SDC_Application.BL
{
    class DocReceiving
    {
        Database dbobject = new Database();

        #region Save Misal Main

        public string SaveDocReceiving(string Rc_Id, string TehsilId, string MozaId, string RcDate, string DocumentNo, string DocType,string NoOfRecords, string NoOfPages, string RcDetail, string InsertUserId, string InsertLoginName, string ActivityStatus)
        {
            string retVal = "";
            string spWithParms = "WEB_SP_INSERT_FilesReceiving " + Rc_Id + "," +TehsilId+ "," + MozaId +",'"+ RcDate+ "',N'" + DocumentNo + "'," + DocType + "," + NoOfRecords + "," + NoOfPages + ",N'" + RcDetail + "'," + InsertUserId.ToString() + ",'" + InsertLoginName + "',"+ActivityStatus;
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        #endregion

        #region Get Doc Details by Date

        public DataTable GetDocReceivedByDate(string Date)
        {
            string spWithParms = "proc_Get_File_Received_By_Date '" + Date+"'";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Doc Details by Date, Mouza, Doc No

        public DataTable GetDocReceivedByDateMozaDocNo(string DocNo, string sDate, string eDate, string MozaId)
        {
            string spWithParms = "proc_Get_File_Received_By_Diff_Params N'" + DocNo + "','" + sDate + "','" + eDate + "'," + MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Update Doc Status

        public string UpdateDocStatus(string Rc_Id, string ActivityStatus)
        {
            string retVal = "";
            string spWithParms = "WEB_SP_UPDATE_File_Receiving_Status " + Rc_Id + "," + ActivityStatus;
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        #endregion
    }
}
