using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDC_Application.DL;
using System.Data;

namespace SDC_Application.BL
{
    class Malikan_n_Khattajat
    {

        #region Class Variables

        Database ojbdb = new Database();

        #endregion

        #region Insert Update Voucher Person Detail

        public string InsertUpdateFardPersonDetail(string PVPersonRecId,string FPGId , string TehsilId, string TokenId, string PVPersonId, string PVPersonSeqNo, string PVPersonKhataNos, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_INSERT_SDC_FardPersonsDetail '" + PVPersonRecId + "','" + FPGId +"'," + TehsilId + "," +TokenId+ "," + PVPersonId + "," + PVPersonSeqNo + ",N'" + PVPersonKhataNos + "'," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
       

        #endregion

        #region Get Fard Operator Report

        public DataTable GetFardOperatorReport(string FPGid)
        {
            string spWithParams = "Proc_Get_SDC_FardPersonsGroup_Operator_Report " + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParams);
        }

        #endregion

        #region Insert Update Fard Person Group Detail

        public string InsertUpdatePersonGroupDetail(string FPGId, string TehsilId, string Total_Quantity, string FPG_Detail, string TokenId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_INSERT_SDC_FardPersonsGroup " + FPGId + "," + TehsilId + "," + Total_Quantity + ",N'" + FPG_Detail + "'," + TokenId + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public string InsertFardOperatorReport(string FPGId, string OperatorReport, string UpdateUserId, string UpdateLoginName)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_INSERT_SDC_FardPersonsGroup_Operator_Report " + FPGId +",N'"+OperatorReport+"'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        public string WEB_SP_INSERT_SDC_FardKhassrasDetail(string KhasaraRecid, string FPGId, string TokenId, string TehsilId, string KhasraSeq, string Khasraid, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_INSERT_SDC_FardKhassrasDetail '" + KhasaraRecid + "','" + FPGId + "'," + TokenId + "," + TehsilId + "," + KhasraSeq + "," + Khasraid + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        #endregion

        #region Insert Update Voucher Khattas Detail

        public string InsertUpdateFardKhattasDetail( string PVKhataRecId , string TehsilId ,string FGPD,string TokenId,string PVKhataSeqNo,string PVKhataId,string InsertUserId,string InsertLoginName , string UpdateUserId,string UpdateLoginName)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_INSERT_SDC_FardKhatasDetail " + PVKhataRecId + "," + TehsilId + "," + FGPD + "," + TokenId + "," + PVKhataSeqNo + "," + PVKhataId + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }


        #endregion
       
        #region Insert Update Methods for Transactional Fard

        public string SaveFardKhataRecord(string FardKhataRecId, string TokenId, string KhataId, string TehsilId, string InsertUserId, string InsertLoginName)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_INSERT_SDC_FardKhatajat " + FardKhataRecId + "," + TokenId + "," + KhataId + "," + TehsilId + "," + InsertUserId + ",'" + InsertLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public string SaveFardKhatooniRecord(string FardKhatooniRecId, string FardKhataRecId, string KhatooniId, string TokenId, string InsertUserId, string InsertLoginName)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_INSERT_SDC_FardKhatoonies " + FardKhatooniRecId + "," + FardKhataRecId  + "," + KhatooniId + "," + TokenId + "," + InsertUserId + ",'" + InsertLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        public string SaveFardMushteriFareeqRecord(string FardMushteriRecId, string MushteriFareeqId, string FardPersonId, string FardKhatooniRecId, string KhewatTypeId, string FardAreaPart, string FardKanal, string FardMarla, string FardSarsai, string FardFeet, string isTransactional, string InsertUserId, string InsertLoginName)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_INSERT_SDC_Fard_MushteriFareeqain " + FardMushteriRecId + "," + MushteriFareeqId + "," + FardPersonId + "," + FardKhatooniRecId + "," + KhewatTypeId + "," + FardAreaPart + "," + FardKanal + "," + FardMarla + "," + FardSarsai + "," + FardFeet + ",'" + isTransactional + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public string SaveFardKhewatFareeqRecord(string FardPersonRecId, string KhewatGroupFareeqId, string FardPersonId, string FardKhataRecId, string KhewatTypeId, string FardAreaPart, string FardKanal, string FardMarla, string FardSarsai, string FardFeet, string isTransactional, string InsertUserId, string InsertLoginName)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_INSERT_SDC_Fard_KhewatGroupFareeqain " + FardPersonRecId + "," + KhewatGroupFareeqId + "," + FardPersonId + "," + FardKhataRecId + "," + KhewatTypeId + "," + FardAreaPart + "," + FardKanal + "," + FardMarla + "," + FardSarsai + "," + FardFeet + ",'" + isTransactional + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        //WEB_SP_UPDATE_SDC_SDC_Fard_Status_Trans
        public void SaveFarddStatus(string TokenId, string task, string isConfirm, string UserId, string UserLoginName, string OperatorReport)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_UPDATE_SDC_Fard_Status_Trans " + TokenId + ",'" + task + "'," + isConfirm + "," + UserId + "," + UserLoginName + ",N'" + OperatorReport + "'";
             ojbdb.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        #endregion

        #region Get Fard Person Group Details
        public DataTable GetFardConfDetails(string TokenId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardConfDetails_ByTokenId " + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[Proc_Get_Fard_MalkanKhataJats]
        }

        public DataTable GetFardPersonGroupDetail(string TokenId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardPersonsGroupByTokenId " + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[Proc_Get_Fard_MalkanKhataJats]
        }
        public DataTable GetSavedKhasraDetails(string FPGid)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardKhassrasDetail_By_FPGId " + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[Proc_Get_Fard_MalkanKhataJats]
        }
        public DataTable GetFardMalkanKFardPersonsDetail(string FPGID)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardPersonsDetail " + FPGID;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }

        public DataTable GetFardMalkanKhataJats(string TokenId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardKhatasByTokenId_NewFard " + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }
        public DataTable GetFardKhewatFareeqainByKhataId(string KhataId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "proc_Get_Intiqal_Khata_Malkan " + KhataId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }
        public DataTable GetFardMushteriFareeqainByKhatooniId(string KhatooniId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "proc_Get_Intiqal_KhanaKashtKhatooni_Malkan " + KhatooniId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }
        #endregion

        #region Get Methods for Transactional Fard
        public DataTable GetFardKhatajatFardNew(string TokenId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardKhatasByTokenId_NewFard " + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }

        public DataTable GetFardKhatooniesFardNew(string TokenId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardKhatooniesByTokenId_NewFard " + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }

        public DataTable GetFardKhewatFareeqainFardNew(string FardKhataRecId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_Fard_KhewatFareeqain_NewFard " + FardKhataRecId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }

        public DataTable GetFardMushteriFareeqainFardNew(string FardKhatooniRecId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_Fard_MushteriFareeqain_NewFard " + FardKhatooniRecId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }

        #endregion

        #region Delete Methods for transactional Fard
        public string DeleteFardKhataRecId(string FardKhataRecId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_DELETE_SDC_FardKhata_FardNew " + FardKhataRecId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }
        public string DeleteFardKhatooniRecId(string FardKhatooniRecId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_DELETE_SDC_FardKhatooni_FardNew " + FardKhatooniRecId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }
        public string DeleteFardKhewatFareeq(string FardPersonRecRecId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_DELETE_SDC_FardKhewatFareeq_FardNew " + FardPersonRecRecId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }
        public string DeleteFardMsuhteriFareeq(string FardMushteriRecId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "WEB_SP_DELETE_SDC_FardMushteriFareeq_FardNew " + FardMushteriRecId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[]
        }
        #endregion

        #region Get Fard Persons / Malikan

        public DataTable GetFardPersons(string FPGid)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardPersonsDetail " + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);GetFardPersons
        }
        public DataTable GetFardPersonsKhatajat(string MozaID,string FPGid)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_Person_KhataJats_SDC " + MozaID + "," + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);GetFardPersons
        }
        public DataTable GetFardPersonsKhatajat_Khankashat(string MozaID, string FPGid)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_Person_KhataJats_KhanaKasht_sdc " + MozaID + "," + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);GetFardPersons
        }
        public DataTable GetFardPersonsKhasraJajat(string MozaID, string FPGid)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardKhassraJat_By_Malkan " + MozaID + "," + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);GetFardPersons
        }
        #endregion

        #region Get Fard Person Khattajat Details

        public DataTable GetFardPersonKhattajat(string PersonRecId)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardKhatasDetail " + PersonRecId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public DataTable GetPersonKhattajat(String MozaId,String PersonID )
        {


           //return ojbdb.filldatatable_from_storedProcedure("Proc_Get_Person_KhataJats'" + MozaId + "','" + PersonID + "'");
            string spWithParam = "Proc_Get_Person_KhataJatsforWerasath " + MozaId + "," + PersonID;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
           
        }

        public DataTable GetMozaKhattajat(String MozaId)
        {
            string spWithParms = "Proc_Get_Moza_Register_KhataJat " + MozaId + "," + "0";
            return ojbdb.filldatatable_from_storedProcedure(spWithParms);

        }

        public DataTable KhataJatDelete(string FGID, string Personrecid)
        {


            return ojbdb.filldatatable_from_storedProcedure("WEB_SP_DELETE_SDC_FardKhatasDetail_And_Person " + FGID + "," + Personrecid + "");

        }
        #endregion

        #region Set Register Haqdaran Khatajat Locking stats

        public void setKhataLock(string KhataId, string KhataLockStat, string LockRemarks, string ShowForCorrection, string UserIdforCorrection)
        {
            string spWithParms = "Proc_Set_Khata_Lock " + KhataId + "," + KhataLockStat + ",N'" + LockRemarks + "',"+ShowForCorrection+","+UserIdforCorrection;
            ojbdb.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        #endregion

        #region Set Khewat Group Fareeqain Hissa Zero stats

        public string ResetKhewatFareeqainHisas(string KhataId)
        {
            string spWithParms = "WEB_SP_INSERT_KhewatGroupFareeqain_KhataCorrection " + KhataId;
            return  ojbdb.ExecInsertUpdateStoredProcedure(spWithParms).ToString();
        }

        #endregion
    }
}
