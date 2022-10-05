using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SDC_Application.DL;
using System.Data.SqlClient;

namespace SDC_Application.BL
{
    class Gardawri
    {
        Database dbobject = new Database();

        #region Save Misal Main
        
        #endregion

        public string SaveGardawri(string GardawriId, string MozaId, string FasalType, string GardawariDate, string GardawriYear, string KhassraId,string KashtkaranTafseel,string FasalDetail, string Kayfiat, int InsertUserId, string InsertLoginName)
        {
            string retVal = "0";
            string spWithParms = "WEB_SP_INSERT_Gardawari  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + GardawriId + "," + MozaId + ",N'" + FasalType + "','" + DateTime.Now.ToShortDateString() + "','" + GardawriYear + "','" + KhassraId + "',N'" + KashtkaranTafseel + "',N'" + FasalDetail + "',N'" + Kayfiat + "'," + InsertUserId.ToString() + ",'" + InsertLoginName + "'";
            retVal=dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }
       

        #region Delete Functions
        public string DeleteGardawri(string GardawriId)
        {//--NOT_IMPLEMENTED_ not in db
            string spWithParms = "WEB_SP_Delete_Gradawari " + GardawriId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Gardawri Confirmation / Attestation

        public void UpdateGardawriConfirmationAttestation(string Action, string AttestedUserId, string ConfirmationLoginName, string AttestedLoginName, string Year, string MozaId, string FasalType)
        {
            //--NOT_IMPLEMENTED_ not in db
            string spWithParms = "WEB_SP_Update_Gardawri_Confirmation_Amaldaramad  '" + Action + "'," + AttestedUserId + ",'" + ConfirmationLoginName + "','" + AttestedLoginName + "',"+Year+","+MozaId+",N'"+FasalType+"'";
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        #endregion

        #region Get Gardawri Details by Moza and Year and ByKhassra

        public DataTable GetGardawriByMouzaByYearByKhassra(string Year, string MozaId, string KhassraId)
        {
            string spWithParms = "Proc_Get_Gradawari  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + Year + "," + KhassraId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Admin User for Misal/Badar Attestation

        public DataTable GetAdminUserforMisalBadar(string TehsilId)
        {
            string spWithParms = "Proc_Get_Admin_User_for_MisalBadar '" + TehsilId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion
      

    }
}
