using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SDC_Application.DL;
using System.Data.SqlClient;

namespace SDC_Application.BL
{
    class RhzZerekar
    {
        DatabaseZerekar dbobject = new DatabaseZerekar();

        #region Get Fb KhewFareeqain By FbId
        public DataTable GetKhewatGroupFarqeenByKhattaFB(string FbID)
        {
            string spWithParms = "Proc_Get_KhewatFareeqeinGroup_By_Khata_FB_Misal " + FbID;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Fb KhewFareeqain By FbId
        public DataTable GetKhewatFarqeenGroupByKhatId_Misal( string FbID,string khataId)
        {
            string spWithParms = "Proc_Get_KhewatFareeqeinGroup_By_Khata_Misal " + FbID+","+khataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Fb Khatoonies by Khata Id
        public DataTable GetKhatonisByKhataIdFB(string fb_id, int KhattaId)
        {
            string spWithParms="Proc_Get_Khatoonis_FB "+fb_id+","+KhattaId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Khewat Fareeqain Group By Khatta
        public DataTable  GetKhewatFareeqeinGroupByKhatta(int KhattaId)
        {
            string spWithParms = "Proc_Get_KhewatFareeqeinGroup_By_Khata_Misal " +KhattaId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Total Area By Khata
        public DataTable  GetTotalAreaByKhattaId(int khattaid)
        {
            string spWithParms = "Proc_Get_Khata_Total_Area " + khattaid.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Register Haqdaran zameen Khattajat by Moza Id
        public DataTable GetKhatajatByMoza(int mozaId)
        {
            string spWithParms = "Proc_Get_Moza_Register_KhataJat " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + mozaId.ToString() + "," + "0";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }

        #endregion

        #region Get Area Types
        public DataTable  GetAreaTypesList()
        {
            string spWithParms = "Proc_Get_AreaTypes_List ";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get RegisterNo by Moza
        public DataTable GetHaqdaraanRegistersByMoza(int Mozaid)
        {
            string spWithParms = "Proc_Get_Moza_HaqdaranRegisterNos "+Mozaid.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Qoam List
        public DataTable  GetQoamList()
        {
            string spWithParms = "Proc_Get_Qoam_List ";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Khatoonies Khassra Area Details by Khatooni Id
        public DataTable GetKhatoniKhassraAreaDetailFB(string fb_id, string KhatooniId)
        {
            string spWithParms = "Proc_Get_Khatooni_KhassraArea_Detail_FB "+fb_id+","+KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Khatoonies Khassra Area Details by Khatooni Id
        public DataTable GetKhatoniKhassraAreaDetail(string KhatooniId)
        {
            string spWithParms = "Proc_Get_Khatooni_KhassraArea_Detail "+ KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Update Khewat Malikan Sequence Number
        public void updateMalkanSeqNo(string KhewatGroupFareeqId, string OldSeqno, string NewSeqno)
        {
            string spWithParms = "WEB_SP_KhewatFareeqein_Sequence_Update " + KhewatGroupFareeqId + "," + OldSeqno + "," + NewSeqno;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        #endregion

        #region Get Khewat Types
        public DataTable GetKhewatTypes(int tehsilId)
        {
            string spWithParms = "Proc_Get_KhewatTypes " + tehsilId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Save KhatooniRegister FB
        public string SaveFBKhatoniRegister(long FB_KhatooniId, long FB_Id, int KhatooniId, string KhatooniNo, int RegisterHqDKhataId, string KhatooniKashtkaranFullDetail_New, string Wasail_e_Abpashi, string KhatooniLagan, int InsertUserId, System.DateTime InsertDate, string InsertLoginName)
        {
             string spWithParms="WEB_SP_INSERT_FB_KhatooniRegister "+ FB_KhatooniId.ToString()+","+ FB_Id.ToString()+","+ KhatooniId.ToString()+",'"+ KhatooniNo+"',"+ RegisterHqDKhataId.ToString()+",N'"+ KhatooniKashtkaranFullDetail_New+"',N'"+ Wasail_e_Abpashi+"',N'"+ KhatooniLagan+"',"+ InsertUserId.ToString()+",'"+ InsertDate+"','"+ InsertLoginName+"'";
             return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Get Khatoonies By KhataId
        public DataTable  GetKhatonisByKhataId(int KhattaId)
        {
            string spWithParms = "Proc_Get_Khatoonis "+KhattaId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get MisalMain List by Moza Id
        public DataTable GetFardBaderListByMozaId(string MozaId)
        {
            string spWithParms = "Proc_Get_FardBadar_Main_ByMozaId_Misal "+MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Save Khewat Group Fareeq FB
        public string SaveFBKhewatGroupFarqeen(
                   long FB_FareeqeinId,
                   long FB_Id,
                   string KhewatGroupFareeqId,
                   string KhewatGroupId,
                   string TransactionType,
                   string IntiqalId,
                   int SeqNo,
                   string PersonId,
                   int KhewatTypeId,
                   string FardAreaPart,
                   int Farad_Kana,
                   int Fard_Marla,
                   float Fard_Sarsai,
                   float Fard_Feet,
                   int InsertUserId,
                   string InsertLoginName,
                   int PersonNetPart,
                   string FardPart_Bata,
                   int RegistHqDKhattaId)
        {
            string spWithParms="WEB_SP_INSERT_FB_KhewatGroupFareeqein "+ FB_FareeqeinId.ToString()+","+ FB_Id.ToString()+","+ KhewatGroupFareeqId+","+ KhewatGroupId+",'"+ TransactionType+"',"+IntiqalId+","+ SeqNo.ToString()+","+ PersonId+","+ KhewatTypeId.ToString()+","+ FardAreaPart+","+ Farad_Kana.ToString()+","+ Fard_Marla.ToString()+","+ Fard_Sarsai.ToString()+","+ Fard_Feet.ToString()+","+ InsertUserId+",'"+ InsertLoginName+"',"+"0,0,0,0,"+PersonNetPart+",'"+ FardPart_Bata+"',"+ RegistHqDKhattaId.ToString();
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Save Fb Khassra Register Details
        public string SaveFBKhassraRegisterDetails(long FB_KhassraRegisterDetailId, long FB_Id, long KhassraDetailId, int KhatooniId, string KhasraNo, int AreaTypeId, int Kanal, int Marla, float Sarsai, float Feet, int InsertUserId, string InsertLoginName, string TransactionType)
        {
             string spWithParms="WEB_SP_INSERT_FB_KhassraRegisterDetail "+FB_KhassraRegisterDetailId+","+ FB_Id.ToString()+","+ KhassraDetailId.ToString()+","+ KhatooniId.ToString()+",'"+ KhasraNo+"',"+ AreaTypeId.ToString()+","+ Kanal.ToString()+","+ Marla.ToString()+","+ Sarsai.ToString()+","+ Feet.ToString()+","+ InsertUserId.ToString()+",'"+ InsertLoginName+"','"+ TransactionType+"'";
             return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Get Khatoonies Khassras Area Details FB
        public DataTable GetKhatoniKhassraAreaDetailFB(string fb_id, int KhatooniId)
        {
            string spWithParms = "Proc_Get_Khatooni_KhassraArea_Detail_FB " + fb_id + "," + KhatooniId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);

        }
        #endregion

        #region Get Khassras Count By KhatooniId
        public string GetKhatoniKhassraCount(string KhatooniId)
        {
            string spWithParms = "Proc_Get_Khatooni_Khassras_Count " +KhatooniId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Save KhassraRegisterDetails Direct
        public string saveKhassraRegisterDirect(int KhassraDetailId, string MozaId, int KhatooniId, string KhassraNo, int AreaTypeId, int Kanal, int Marla, float Sarsai, float Feet, int InsertUserId, string insertLoginName)
        {
            string spWithParms="WEB_SP_INSERT_KhassraRegisterDetail_Direct "+ KhassraDetailId.ToString()+","+ MozaId.ToString()+","+ KhatooniId.ToString()+",'"+ KhassraNo+"',"+ AreaTypeId.ToString()+","+ Kanal.ToString()+","+ Marla.ToString()+","+ Sarsai.ToString()+","+ Feet.ToString()+","+ InsertUserId.ToString()+",'"+ insertLoginName+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Save Fb Khassra Register
        public string SaveFBKhassraRegister(long FB_KhassraId, long FB_Id, int KhassraId, string MozaId, string KhassraNo, int InsertUserId, string InsertLoginName, int KhassraDetailId, int KhatooniId, int AreaTypeId, int Kanal, int Marla, float Sarsai, float feet)
        {
            string spWithParms="WEB_SP_INSERT_FB_KhassraRegister "+ FB_KhassraId.ToString()+","+ FB_Id.ToString()+","+ KhassraId.ToString()+","+ MozaId+",'"+ KhassraNo+"',"+ InsertUserId.ToString()+",'"+ InsertLoginName+"',"+ KhassraDetailId.ToString()+","+ KhatooniId.ToString()+","+ AreaTypeId.ToString()+","+ Kanal.ToString()+","+ Marla.ToString()+","+ Sarsai.ToString()+","+ feet.ToString();
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Delete Functions
        public void DeleteFbKhatta(string FbId, int Fb_RegKhattaId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_Khatajat " + FbId + "," + Fb_RegKhattaId.ToString();
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void DeleteFbKhewatGroupFareeq(string FbId, string FbKGFId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_KhewatGroupFareeqein " + FbId + "," + FbKGFId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void DeleteKhatoniRegister(string FbId, string KhatooniId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_KhatooniRegister " + FbId + "," + KhatooniId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void DeleteFbKhassra(string FbId, string KhassraDetailId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_Khassrajat " + FbId + "," + KhassraDetailId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void DeleteKhewatGroupFard(string KhewatGroupFareeqId)
        {
            string spWithParms = "WEB_SP_DELETE_KhewatGroupFareeqein " + KhewatGroupFareeqId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void DeleteKhatoniRegister(string KhatooniId)
        {
            string spWithParms = "WEB_SP_DELETE_KhatooniRegister " + KhatooniId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void UpdateFardBaderMainConfirmationAmaldaramad(string FB_Id, string Action, string ConfirmationLoginName, string AmaldaramadLoginName)
        {
            string spWithParms = "WEB_SP_Update_FB_Confirmation_Amaldaramad " + FB_Id + ", '" + Action + "','" + @ConfirmationLoginName + "','" + AmaldaramadLoginName+"'";
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        #region Get Misal Details by Misal No

        public DataTable GetFardBaderMainByDocNoSDC(string FB_DocumentNo, int MozaId)
        {
            string spWithParms = "Proc_Get_FardBadar_Main_By_DocumentNo_SDC '" + FB_DocumentNo + "'," + MozaId.ToString();
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
        #endregion
    }
}
