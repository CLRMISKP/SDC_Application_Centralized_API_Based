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

        public string SaveDocReceiving(string Rc_Id, string TehsilId, string MozaId, string RcDate, string DocumentNo, string DocType, string Title, string NoOfPages, string RcDetail, string InsertUserId, string InsertLoginName, string ActivityStatus)
        {
            string retVal = "";
            string spWithParms = "WEB_SP_INSERT_FilesReceiving " + Rc_Id + "," +TehsilId+ "," + MozaId +",'"+ RcDate+ "',N'" + DocumentNo + "'," + DocType + ",N'" + Title + "'," + NoOfPages + ",N'" + RcDetail + "'," + InsertUserId.ToString() + ",'" + InsertLoginName + "',"+ActivityStatus;
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        #endregion

        #region Save Registries

        public string SaveRegReceiving(string RegId, string TehsilId, string MozaId, string RegDate, string RegNo, string JildNo, string Seller, string Buyer, string Kafiyat, string InsertUserId, string InsertLoginName, string ActivityStatus)
        {
            string retVal = "";
            string spWithParms = "WEB_Self_SP_INSERT_RegReceiving " + RegId + "," + TehsilId + "," + MozaId + ",'" + RegDate + "','" + RegNo + "','" + JildNo + "',N'" + Seller + "',N'" + Buyer + "',N'" + Kafiyat + "'," + InsertUserId.ToString() + ",'" + InsertLoginName + "'," + ActivityStatus;
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        #endregion

        #region Save Covid19 Booking

        public string SaveCovid19Booking(string BookingId, string TehsilId, string MozaId, string ServiceTypeId, string PurposeTypeId, string Name, string FName, string CNIC, string ContactNo, string Remarks, string dtToken, string TokenTime,  string InsertUserId, string InsertLoginName)
        {
            string retVal = "";//--NOT_IMPLEMENTED_hardcoded
            string spWithParms = "Covid19_WEB_Self_SP_INSERT_Booking " + BookingId + "," + TehsilId + "," + MozaId + ",'" + ServiceTypeId + "','" + PurposeTypeId + "',N'" + Name + "',N'" + FName + "','" + CNIC + "','" + ContactNo + "',N'" + Remarks + "','"+ dtToken +"','"+ TokenTime +"'," +InsertUserId +",'"+  InsertLoginName + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        #endregion

        #region Get Booking Details by Date

        public DataTable GetCovid19BookingByDate(string Date)
        {
            string spWithParms = "Covid19_proc_Self_Get_Booking_By_Date '" + Date + "'";//--NOT_IMPLEMENTED_
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }

        public string CheckBookingCovid19(string Date, string Service)
        {
            string retVal = "";//--NOT_IMPLEMENTED_hardcoded
            string spWithParms = "Covid19_proc_Self_Get_Booking_Complete_YesNo '" + Date + "'," + Service;//--NOT_IMPLEMENTED_
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        #endregion

        #region Get Doc Details by Date

        public DataTable GetDocReceivedByDate(string Date)
        {
            string spWithParms = "proc_Get_File_Received_By_Date " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + Date + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Registries Details by Date

        public DataTable GetRegReceivedByDate(string Date)
        {
            string spWithParms = "proc_Self_Get_Reg_Received_By_Date " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + Date + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Doc Details by Date, Mouza, Doc No

        public DataTable GetDocReceivedByDateMozaDocNo(string DocNo, string sDate, string eDate, string MozaId, string Title)
        {
            string spWithParms = "proc_Get_File_Received_By_Diff_Params  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",N'" + DocNo + "','" + sDate + "','" + eDate + "'," + MozaId + ",N'" + Title + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Registry Details by Date, Mouza, Doc No

        public DataTable GetRegReceivedByDateMozaDocNo(string DocNo, string sDate, string eDate, string MozaId)
        {
            string spWithParms = "proc_Self_Get_Registry_Received_By_Diff_Params  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + DocNo + "','" + sDate + "','" + eDate + "'," + MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Update Doc Status

        //public string UpdateDocStatus(string Rc_Id, string ActivityStatus)
        //{
        //    string retVal = "";
        //    string spWithParms = "WEB_SP_UPDATE_File_Receiving_Status " + Rc_Id + "," + ActivityStatus;
        //    retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        //    return retVal;
        //}

        public string UpdateDocStatus(string Rc_Id,  string MozaId, string RcDate, string DocumentNo, string DocType, string Title, string NoOfPages, string RcDetail, string InsertUserId,  string ActivityStatus, string IntiqalNo)
        {
            string retVal = "";
            string spWithParms = "WEB_SP_UPDATE_File_Receiving_Status  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + Rc_Id + "," + MozaId + ",'" + RcDate + "',N'" + DocumentNo + "'," + DocType + ",N'" + Title + "'," + NoOfPages + ",N'" + RcDetail + "'," + InsertUserId.ToString() + "," + ActivityStatus + ",'" + IntiqalNo + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        #endregion
    }
}
