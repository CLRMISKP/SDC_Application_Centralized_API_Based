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

        #region Insert / Save Functions

        #region Save Garsawri Main

        public string SaveGardawriMain(string GardawriId,string TehsilId ,string MozaId, string FasalType, string GardawriYear, string InsertUserId, string InsertLoginName)
        {
            string retVal = "0";
            string spWithParms = "WEB_SP_INSERT_Gardawari_Main " + GardawriId + ","+TehsilId+"," + MozaId +"," + GardawriYear +","+ InsertUserId + ",'" + InsertLoginName +"',N'" + FasalType +"'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }
        
        #endregion

        public string SaveGardawri(string GardawriId, string MozaId, string FasalType, string GardawariDate, string GardawriYear, string KhassraId, string AreaTypeId ,string KashtkaranTafseel,string FasalDetail, string Kayfiat, int InsertUserId, string InsertLoginName)
        {
            string retVal = "0";
            string spWithParms = "WEB_SP_INSERT_Gardawari " + GardawriId + "," + MozaId + ",N'" + FasalType + "','" + DateTime.Now.ToShortDateString() + "','" + GardawriYear + "','" + KhassraId + "','" + AreaTypeId + "',N'" + KashtkaranTafseel + "',N'" + FasalDetail + "',N'" + Kayfiat + "'," + InsertUserId.ToString() + ",'" + InsertLoginName + "'";
            retVal=dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        public string SaveGardawriKashtFasal(string GardawriKashtFasalId,string TehsilId ,string GardawariId, string KhatooniId, string KhassraId, string KhassraTypeId, string KhassraSubTypeId, string KashtkaranTafseel, string FasalDetail, string WasileAbpashi, string Kayfiat, string InsertLoginName, string InsertUserId)
        {
            string retVal = "0";
            string spWithParms = "WEB_SP_INSERT_GardawariKashtFasal '" + GardawriKashtFasalId + "','"+TehsilId+"','" + GardawariId + "','" + KhatooniId + "','" + KhassraId + "','" + KhassraTypeId + "','" + KhassraSubTypeId + "',N'" + KashtkaranTafseel + "',N'" + FasalDetail + "',N'" + WasileAbpashi + "',N'" + Kayfiat + "','" + InsertLoginName + "','" + InsertUserId.ToString() + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        public string SaveGardawriTaghairat(string GardawriKhassraDetailId,string TehsilId ,string GardawariId, string KhassraDetailId, string KhassraId, string AreaTypeId, string AreaTypeIdNew, string Kanal, string KanalNew, string Marla, string MarlaNew, string Sarsai, string SarsaiNew, string Feet, string FeetNew, string InsertLoginName, string InsertUserId)
        {
            string retVal = "0";
            string spWithParms = "WEB_SP_INSERT_GardawriKhassraDetail '" + GardawriKhassraDetailId + "','"+TehsilId+"','" + GardawariId + "','" + KhassraDetailId + "','" + KhassraId + "','" + AreaTypeId + "','" + AreaTypeIdNew + "','" + Kanal + "','" + KanalNew + "','" + Marla + "','" + MarlaNew + "','" + Sarsai + "','" + SarsaiNew + "','" + Feet + "','" + FeetNew + "','" + InsertLoginName + "','" + InsertUserId.ToString() + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        public string SaveKhassraRegisterDetail(string TehsilId ,string KhassraDetailId, string KhassraId, string AreaTypeId, string Kanal, string Marla, string Sarsai, string Feet, string InsertUserId)
        {
            string retVal = "0";
            string spWithParms = "WEB_SP_INSERT_KhassraRegisterDetail "+TehsilId+"," + KhassraDetailId + "," + KhassraId + "," + AreaTypeId +"," + Kanal + "," + Marla + "," + Sarsai + ","  + Feet  + ","  + InsertUserId.ToString();
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        #endregion

        #region Delete Functions
        public string DeleteGardawri(string GardawriId)
        {
            string spWithParms = "WEB_SP_Delete_Gradawari " + GardawriId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        public  string  DeleteGardawriKhassraDetail(string GardawriKhassraDetailId)
            {
                string spWithParms = "WEB_SP_DELETE_GardawriKhassraDetailsTaghairat " + GardawriKhassraDetailId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

        #region Gardawri Confirmation / Attestation

        public void UpdateGardawriConfirmationAttestation(string Action, string AttestedUserId, string ConfirmationLoginName, string AttestedLoginName, string GardawriId)
        {
            string spWithParms = "WEB_SP_Update_Gardawri_Confirmation_Amaldaramad  '" + Action + "'," + AttestedUserId + ",'" + ConfirmationLoginName + "','" + AttestedLoginName + "',"+GardawriId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        #endregion

        #region Get Gardawri Details 

        public DataTable GetGardawriByMouzaByYearByKhassra(string Year, string MozaId, string KhassraId)
        {
            string spWithParms = "Proc_Get_Gradawari " + MozaId + "," + Year+","+KhassraId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }

        public DataTable GetGardawriByGardawriKhatooniId(string GardwariId, string KhatoooniId)
        {
            string spWithParms = "Proc_Get_GradawariKashtFasal " + GardwariId + "," + KhatoooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }

        public DataTable GetGardawriTaghairat(string GardwariId, string KhatooniId)
        {
            string spWithParms = "Proc_Get_GradawariTaghairat " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + GardwariId + "," + KhatooniId;
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

        #region Get Khassra Details by ByKhassra

        public DataTable GetKhassraDetailsByKhassra(string TehsilId, string KhassraId)
        {
            string spWithParms = "Proc_Get_KhassraArea_Deatil "+TehsilId+"," + KhassraId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        public DataTable GetGardawriMain(string MozaId, string FasalType, string GardawriYear)
        {
            string spWithParms = "Proc_Get_Gradawari_Main " + MozaId+","+GardawriYear+",N'"+FasalType+"'";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }

    }
}
