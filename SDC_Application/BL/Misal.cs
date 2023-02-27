using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SDC_Application.DL;
using System.Data.SqlClient;

namespace SDC_Application.BL
{
    class Misal
    {
        Database dbobject = new Database();

        #region Save Misal Main

        public string SaveFardBadarMain(string FB_Id, int MozaId, string FbDocumentNo, string GardawarDate, string ConfirmationDate, string FardBadarDetail, int InsertUserId, string InsertLoginName, int isManualFb)
        {
            string retVal = "";
            string spWithParms = "WEB_SP_INSERT_FardBadar_Main_Misal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_Id + "," + MozaId.ToString() + ",'" + FbDocumentNo + "','" + DateTime.Now.ToShortDateString() + "','" + GardawarDate + "','" + ConfirmationDate + "',0,'" + DateTime.Now.ToShortDateString() + "',N'" + FardBadarDetail + "'," + InsertUserId.ToString() + ",'" + InsertLoginName + "',"+isManualFb.ToString();
            retVal=dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        #endregion
        # region Check khata No and Khassra No in moza
        public string CheckKhataInMoza(string MozaId, string KhataNo, string KhataId)
        {
            string ret = "0";
            string spWithParam = "Proc_Self_Check_KhatNo_in_Moza "+Classess.UsersManagments._Tehsilid.ToString()+"," + MozaId + ",'" + KhataNo + "'," + KhataId;
            ret = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            return ret;
        }


        public string CheckKhasraNoInMoza(string MozaId, string KhasraNo)
        {
            string ret = "0";
            string spWithParam = "Proc_Self_Check_KhasraNo_in_Moza " + Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ",'" + KhasraNo + "'";
            ret = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            return ret;
        }

        public string CheckKhasraNoInMozaKhatooni(string MozaId, string KhatooniId, string KhasraNo, string AreaType)
        {
            string ret = "0";
            string spWithParam = "Proc_Self_Check_KhasraNo_in_Moza_Khatooni " + Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + KhatooniId + ",'" + KhasraNo + "'," + AreaType;
            ret = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            return ret;
        }

        public string CheckKhasraDetailsInMoza(string MozaId, string KhasraNo, string KhassraDetailId, string AreaType)
        {
            string ret = "0";
            string spWithParam = "Proc_Self_Check_KhasraDetail_in_Moza " + Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ",'" + KhasraNo + "'," + KhassraDetailId + "," + AreaType;
            ret = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            return ret;
        }

        public string CheckFBKhataUsed(string Fbid, string KhataId)
        {
            string ret = "0";
            string spWithParam = "Proc_Self_Check_FB_Khata_Used " + Classess.UsersManagments._Tehsilid.ToString() + "," + Fbid + "," + KhataId;
            ret = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            return ret;
        }

        public string CheckParentKhata(string IntiqalId, string ParentKhataId)
        {
            string ret = "0";
            string spWithParam = "Proc_Self_Check_Khata_As_Parent " + Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + "," + ParentKhataId;
            ret = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            return ret;
        }

        #endregion

        #region Save Misal Khata

        public string SaveFBKhattaRecord(string FB_KhataId, string  FB_ID, string FB_RegisterHqDKhataId, string RegisterHaqdaranId, string KhataNo, string Tarf, 
                    string Pati, string TotalParts, string Khata_Kanal, string Khata_Marla, string Khata_Sarsai, string Khata_Feet, string Malia, string Kyfiat,
                    string InsertUserId, string InsertLoginName)
        {
            string retVal="";
            string spWithParms = "WEB_SP_INSERT_FB_Khatajat " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + FB_KhataId + "," + FB_ID + "," + FB_RegisterHqDKhataId + "," + RegisterHaqdaranId + ",'" + KhataNo + "',N'" + Tarf + "',N'" + Pati + "'," + TotalParts + "," + Khata_Kanal + "," + Khata_Marla + "," + Khata_Sarsai + "," + Khata_Feet + ",N'" + Malia + "',N'" + Kyfiat + "','" + DateTime.Now.ToShortDateString() + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }
      
        #endregion

        #region Get Misal Details by Misal No

        public DataTable GetFardBaderMainByDocNo(string FB_DocumentNo, int MozaId) 
        {
            string spWithParms = "Proc_Get_FardBadar_Main_By_DocumentNo  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + FB_DocumentNo + "'," + MozaId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }


        #endregion

        #region Get Misal Details by Khata Id

        public DataTable GetFardBaderMainByKhataId(string KhataId)
        {
            string spWithParms = "Proc_Get_FardBadar_By_Khatta  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get FBKhatajat by FBId
        public DataTable GetFbKhattajat(string fbId) 
        {
            string spWithParms = "Proc_Get_FB_Khattajat_Test "+fbId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Fb KhewFareeqain By FbId
        public DataTable GetKhewatGroupFarqeenByKhattaFB(string FbID)
        {
            string spWithParms = "Proc_Get_KhewatFareeqeinGroup_By_Khata_FB_Misal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FbID;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Fb KhewFareeqain By FbId
        public DataTable GetKhewatFarqeenGroupByKhatId_Misal( string FbID,string khataId)
        {
            string spWithParms = "Proc_Get_KhewatFareeqeinGroup_By_Khata_Misal " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + FbID + "," + khataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Fb Khatoonies by Khata Id
        public DataTable GetKhatonisByKhataIdFB(string fb_id, int KhattaId)
        {
            string spWithParms = "Proc_Get_Khatoonis_FB " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + fb_id + "," + KhattaId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Khewat Fareeqain Group By Khatta
        public DataTable  GetKhewatFareeqeinGroupByKhatta(int KhattaId)
        {
            string spWithParms = "Proc_Get_KhewatFareeqeinGroup_By_Khata_Misal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhattaId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Total Area By Khata
        public DataTable  GetTotalAreaByKhattaId(int khattaid)
        {
            string spWithParms = "Proc_Get_Khata_Total_Area  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + khattaid.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Register Haqdaran zameen Khattajat by Moza Id
        public DataTable GetKhatajatByMoza(int mozaId)
        {
            string spWithParms = "Proc_Get_Moza_Register_KhataJat  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + mozaId.ToString() + "," + "0";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }

        #endregion

        #region Get Area Types
        public DataTable  GetAreaTypesList()
        {
            string spWithParms = "Proc_Get_AreaTypes_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get RegisterNo by Moza
        public DataTable GetHaqdaraanRegistersByMoza(int Mozaid)
        {
            string spWithParms = "Proc_Get_Moza_HaqdaranRegisterNos  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + Mozaid.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Qoam List
        public DataTable  GetQoamList()
        {
            string spWithParms = "Proc_Get_Qoam_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Khatoonies Khassra Area Details by Khatooni Id
        public DataTable GetKhatoniKhassraAreaDetailFB(string fb_id, string KhatooniId)
        {
            string spWithParms = "Proc_Get_Khatooni_KhassraArea_Detail_FB  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fb_id + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Khatoonies Khassra Area Details by Khatooni Id
        public DataTable GetKhatoniKhassraAreaDetail(string KhatooniId)
        {
            string spWithParms = "Proc_Get_Khatooni_KhassraArea_Detail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Update Khewat Malikan Sequence Number
        public void updateMalkanSeqNo(string KhewatGroupFareeqId, string OldSeqno, string NewSeqno)
        {
            string spWithParms = "WEB_SP_KhewatFareeqein_Sequence_Update  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhewatGroupFareeqId + "," + OldSeqno + "," + NewSeqno;
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
            string spWithParms = "WEB_SP_INSERT_FB_KhatooniRegister  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_KhatooniId.ToString() + "," + FB_Id.ToString() + "," + KhatooniId.ToString() + ",'" + KhatooniNo + "'," + RegisterHqDKhataId.ToString() + ",N'" + KhatooniKashtkaranFullDetail_New + "',N'" + Wasail_e_Abpashi + "',N'" + KhatooniLagan + "'," + InsertUserId.ToString() + ",'" + InsertDate + "','" + InsertLoginName + "'";
             return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Get Khatoonies By KhataId
        public DataTable  GetKhatonisByKhataId(int KhattaId)
        {
            string spWithParms = "Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhattaId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get MisalMain List by Moza Id
        public DataTable GetFardBaderListByMozaId(string MozaId)
        {
            string spWithParms = "Proc_Get_FardBadar_Main_ByMozaId_Misal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId;
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
            string spWithParms = "WEB_SP_INSERT_FB_KhewatGroupFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_FareeqeinId.ToString() + "," + FB_Id.ToString() + "," + KhewatGroupFareeqId + "," + KhewatGroupId + ",'" + TransactionType + "'," + IntiqalId + "," + SeqNo.ToString() + "," + PersonId + "," + KhewatTypeId.ToString() + "," + FardAreaPart + "," + Farad_Kana.ToString() + "," + Fard_Marla.ToString() + "," + Fard_Sarsai.ToString() + "," + Fard_Feet.ToString() + "," + InsertUserId + ",'" + InsertLoginName + "'," + "0,0,0,0," + PersonNetPart + ",'" + FardPart_Bata + "'," + RegistHqDKhattaId.ToString();
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Save Fb Khassra Register Details
        public string SaveFBKhassraRegisterDetails(string FB_KhassraRegisterDetailId, string FB_Id, string KhassraDetailId, string KhatooniId, string KhasraNo, string AreaTypeId, string Kanal, string Marla, string Sarsai, string  Feet, string  InsertUserId, string InsertLoginName, string TransactionType)
        {
            string spWithParms = "WEB_SP_INSERT_FB_KhassraRegisterDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_KhassraRegisterDetailId + "," + FB_Id + "," + KhassraDetailId + "," + KhatooniId + ",'" + KhasraNo + "'," + AreaTypeId + "," + Kanal + "," + Marla + "," + Sarsai + "," + Feet + "," + InsertUserId+ ",'" + InsertLoginName + "','" + TransactionType + "'";
             return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Get Khatoonies Khassras Area Details FB
        public DataTable GetKhatoniKhassraAreaDetailFB(string fb_id, int KhatooniId)
        {
            string spWithParms = "Proc_Get_Khatooni_KhassraArea_Detail_FB  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fb_id + "," + KhatooniId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);

        }
        #endregion

        #region Get Khassras Count By KhatooniId
        public string GetKhatoniKhassraCount(string KhatooniId)
        {
            string spWithParms = "Proc_Get_Khatooni_Khassras_Count  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Save KhassraRegisterDetails Direct
        public string saveKhassraRegisterDirect(string KhassraDetailId, string MozaId, int KhatooniId, string KhassraNo, int AreaTypeId, int Kanal, int Marla, float Sarsai, float Feet, int InsertUserId, string insertLoginName)
        {
            string spWithParms = "WEB_SP_INSERT_KhassraRegisterDetail_Direct  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhassraDetailId.ToString() + "," + MozaId.ToString() + "," + KhatooniId.ToString() + ",'" + KhassraNo + "'," + AreaTypeId.ToString() + "," + Kanal.ToString() + "," + Marla.ToString() + "," + Sarsai.ToString() + "," + Feet.ToString() + "," + InsertUserId.ToString() + ",'" + insertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Save Fb Khassra Register
        public string SaveFBKhassraRegister(string FB_KhassraId, string FB_Id, string KhassraId, string MozaId, string KhassraNo, string InsertUserId, string InsertLoginName, string KhassraDetailId, string  KhatooniId, string  AreaTypeId, string Kanal, string Marla, string  Sarsai, string feet)
        {
            string spWithParms = "WEB_SP_INSERT_FB_KhassraRegister  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_KhassraId + "," + FB_Id+ "," + KhassraId + "," + MozaId + ",'" + KhassraNo + "'," + InsertUserId + ",'" + InsertLoginName + "'," + KhassraDetailId + "," + KhatooniId + "," + AreaTypeId + "," + Kanal+ "," + Marla + "," + Sarsai + "," + feet;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Delete Functions
        public void DeleteFbKhatta(string FbId, int Fb_RegKhattaId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_Khatajat  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FbId + "," + Fb_RegKhattaId.ToString();
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void DeleteFbKhewatGroupFareeq(string FbId, string FbKGFId)
        {
            //--NOT_IMPLEMENTED_TABLE_STRUCTURE some col not found
            string spWithParms = "WEB_SP_DELETE_FB_KhewatGroupFareeqein " + FbId + "," + FbKGFId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void DeleteKhatoniRegister(string FbId, string KhatooniId)
        {
            //--NOT_IMPLEMENTED_TABLE_STRUCTURE some col not found
            string spWithParms = "WEB_SP_DELETE_FB_KhatooniRegister " + FbId + "," + KhatooniId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void DeleteFbKhassra(string FbId, string KhassraDetailId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_Khassrajat " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + FbId + "," + KhassraDetailId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void DeleteKhewatGroupFard(string KhewatGroupFareeqId)
        {
            string spWithParms = "WEB_SP_DELETE_KhewatGroupFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhewatGroupFareeqId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void DeleteKhatoniRegister(string KhatooniId)
        {
            string spWithParms = "WEB_SP_DELETE_KhatooniRegister  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public void UpdateFardBaderMainConfirmationAmaldaramad(string FB_Id, string Action, string ConfirmationLoginName, string AmaldaramadLoginName)
        {
            string spWithParms = "WEB_SP_Update_FB_Confirmation_Amaldaramad " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + FB_Id + ", '" + Action + "','" + @ConfirmationLoginName + "','" + AmaldaramadLoginName + "'";
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }
        public void FardBaderAmaldaramadManualFb(string FB_Id, string AmalUserId, string AmaldaramadLoginName)
        {
            string spWithParms = "Proc_EFB_Amaldaramad_Manual_FB " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + FB_Id + ", " + AmalUserId + ",'" + AmaldaramadLoginName + "'";
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        #region Get Misal Details by Misal No

        public DataTable GetFardBaderMainByDocNoSDC(string FB_DocumentNo, int MozaId)
        {
            string spWithParms = "Proc_Get_FardBadar_Main_By_DocumentNo_SDC  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + FB_DocumentNo + "'," + MozaId.ToString();
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
