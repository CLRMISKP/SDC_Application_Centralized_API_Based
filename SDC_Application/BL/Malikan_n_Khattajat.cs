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
           
            string spWithParam = "WEB_SP_INSERT_SDC_FardPersonsDetail '" + PVPersonRecId + "','" + FPGId +"'," + TehsilId + "," +TokenId+ "," + PVPersonId + "," + PVPersonSeqNo + ",N'" + PVPersonKhataNos + "'," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
       

        #endregion

        #region Get Fard Operator Report

        public DataTable GetFardOperatorReport(string FPGid)
        {
            string spWithParams = "Proc_Get_SDC_FardPersonsGroup_Operator_Report  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParams);
        }

        public DataTable GetDetailedFardOperatorReport(string TokenId)
        {
            string spWithParams = "Proc_Self_Get_SDC_DetailedFard_Operator_Report  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParams);
        }

        #endregion

        #region Insert Update Fard Person Group Detail

        public string InsertUpdatePersonGroupDetail(string FPGId, string TehsilId, string Total_Quantity, string FPG_Detail, string TokenId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {

            string spWithParam = "WEB_SP_INSERT_SDC_FardPersonsGroup  " + FPGId + "," + TehsilId + "," + Total_Quantity + ",N'" + FPG_Detail + "'," + TokenId + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public string InsertFardOperatorReport(string FPGId, string OperatorReport, string UpdateUserId, string UpdateLoginName)
        {

            string spWithParam = "WEB_SP_INSERT_SDC_FardPersonsGroup_Operator_Report  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FPGId + ",N'" + OperatorReport + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public string WEB_SP_INSERT_SDC_FardKhassrasDetail(string KhasaraRecid, string FPGId, string TokenId, string TehsilId, string KhasraSeq, string Khasraid, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {

            string spWithParam = "WEB_SP_INSERT_SDC_FardKhassrasDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + KhasaraRecid + "','" + FPGId + "'," + TokenId + "," + TehsilId + "," + KhasraSeq + "," + Khasraid + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public string SaveDetailedFardKhatoni(string KhatooniRecId, string FardTokenId, string KhataRecId,  string KhatoniId, string UserID, string UserName)
        {
            string spWithParam = "WEB_Self_SP_INSERT_DetailedFard_KhanaKasht_Khatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + KhatooniRecId + "'," + FardTokenId + "," + KhataRecId + "," + KhatoniId + "," + UserID + ",'" + UserName + "'," + UserID + ",'" + UserName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable GetDetailedFardKhatonies(string KhataRecId)
        {
            string spWithParam = "proc_Self_Get_Detailed_Khatoonies_List_By_KhattaRecId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataRecId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }

        #endregion

        #region Insert Update Voucher Khattas Detail

        public string InsertUpdateFardKhattasDetail( string PVKhataRecId , string TehsilId ,string FGPD,string TokenId,string PVKhataSeqNo,string PVKhataId,string InsertUserId,string InsertLoginName , string UpdateUserId,string UpdateLoginName)
        {

            string spWithParam = "WEB_SP_INSERT_SDC_FardKhatasDetail "  + PVKhataRecId + "," + TehsilId + "," + FGPD + "," + TokenId + "," + PVKhataSeqNo + "," + PVKhataId + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
      

        #endregion

        #region Insert Update Methods for Detail Fard

        public string InsertUpdateDetailedFardKhattas(string PVKhataRecId, string TehsilId,  string TokenId, string PVKhataSeqNo, string PVKhataId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {

            string spWithParam = "WEB_SP_INSERT_Self_SDC_DetailedFardKhatas  "  + PVKhataRecId + "," + TehsilId + "," + TokenId + "," + PVKhataSeqNo + "," + PVKhataId + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public string GetDetailedFardKhatooniParts(string KhatooniId)
        {

            string spWithParam = "Proc_Self_Get_KhatooniParts  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public void DeleteDetailedFardKhatooni(string KhatooniRecId)
        {
            string spWithParam = "WEB_Self_SP_DELETE_DetailedFard_Khatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniRecId + "";
            ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }
      
        #endregion

        #region Insert Update Methods for Transactional Fard

        public string SaveFardKhataRecord(string FardKhataRecId, string TokenId, string KhataId, string TehsilId, string InsertUserId, string InsertLoginName, string AllKhassras)
        {

            string spWithParam = "WEB_SP_INSERT_SDC_FardKhatajat  " + FardKhataRecId + "," + TokenId + "," + KhataId + "," + TehsilId + "," + InsertUserId + ",'" + InsertLoginName + "', " + AllKhassras;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public string SaveFardKhatooniRecord(string FardKhatooniRecId, string FardKhataRecId, string KhatooniId, string TokenId, string InsertUserId, string InsertLoginName)
        {

            string spWithParam = "WEB_SP_INSERT_SDC_FardKhatoonies  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FardKhatooniRecId + "," + FardKhataRecId + "," + KhatooniId + "," + TokenId + "," + InsertUserId + ",'" + InsertLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        public string SaveFardMushteriFareeqRecord(string FardMushteriRecId, string MushteriFareeqId, string FardPersonId, string FardKhatooniRecId, string KhewatTypeId, string FardAreaPart, string FardKanal, string FardMarla, string FardSarsai, string FardFeet, string isTransactional, string InsertUserId, string InsertLoginName)
        {

            string spWithParam = "WEB_SP_INSERT_SDC_Fard_MushteriFareeqain  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FardMushteriRecId + "," + MushteriFareeqId + "," + FardPersonId + "," + FardKhatooniRecId + "," + KhewatTypeId + "," + FardAreaPart + "," + FardKanal + "," + FardMarla + "," + FardSarsai + "," + FardFeet + ",'" + isTransactional + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public string SaveFardKhewatFareeqRecord(string FardPersonRecId, string KhewatGroupFareeqId, string FardPersonId, string FardKhataRecId, string KhewatTypeId, string FardAreaPart, string FardKanal, string FardMarla, string FardSarsai, string FardFeet, string isTransactional, string InsertUserId, string InsertLoginName)
        {

            string spWithParam = "WEB_SP_INSERT_SDC_Fard_KhewatGroupFareeqain  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FardPersonRecId + "," + KhewatGroupFareeqId + "," + FardPersonId + "," + FardKhataRecId + "," + KhewatTypeId + "," + FardAreaPart + "," + FardKanal + "," + FardMarla + "," + FardSarsai + "," + FardFeet + ",'" + isTransactional + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        //WEB_SP_UPDATE_SDC_SDC_Fard_Status_Trans
        public void SaveFarddStatus(string TokenId, string task, string isConfirm, string UserId, string UserLoginName, string OperatorReport)
        {

            string spWithParam = "WEB_SP_UPDATE_SDC_Fard_Status_Trans  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId + ",'" + task + "'," + isConfirm + "," + UserId + ",'" + UserLoginName + "',N'" + OperatorReport + "'";
            ojbdb.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        //WEB_SP_UPDATE_SDC_SDC_Fard_Status_Trans
        public string SaveFardKhassras(string KhassraRecId, string KhataId, string KhatooniId, string TokenId, string SeqNo, string KhassraId,string Kanal, string Marla, string Sarsai, string Feet, string UserId, string UserLoginName)
        {

            string spWithParam = "WEB_SP_INSERT_SDC_FardKhassrasDetail  "+KhassraRecId+","+KhataId+","+KhatooniId+","+TokenId+"," + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + SeqNo + "," + KhassraId+","+Kanal+","+Marla+","+Sarsai+","+Feet + "," + UserId + ",'" + UserLoginName + "'";
             return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        public string DeleteFardKhassra(string KhassraRecId)
        {

            string spWithParam = "WEB_SP_DELETE_SDC_FardKhassra  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhassraRecId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        #endregion

        #region Get Fard Person Group Details

        public DataTable GetFardConfDetails(string TokenId)
        {

            string spWithParam = "Proc_Get_SDC_FardConfDetails_ByTokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[Proc_Get_Fard_MalkanKhataJats]
        }

        public DataTable GetFardPersonGroupDetail(string TokenId)
        {

            string spWithParam = "Proc_Get_SDC_FardPersonsGroupByTokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[Proc_Get_Fard_MalkanKhataJats]
        }
        public DataTable GetSavedKhasraDetails(string FPGid)
        {

            string spWithParam = "Proc_Get_SDC_FardKhassrasDetail_By_FPGId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);[Proc_Get_Fard_MalkanKhataJats]
        }
        public DataTable GetFardMalkanKFardPersonsDetail(string FPGID)
        {

            string spWithParam = "Proc_Get_SDC_FardPersonsDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FPGID;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }

        public DataTable GetFardMalkanKhataJats(string TokenId)
        {

            string spWithParam = "Proc_Get_Fard_MalkanKhataJats " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }
        public DataTable GetFardKhewatFareeqainByKhataId(string KhataId)
        {

            string spWithParam = "proc_Get_Intiqal_Khata_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }
        public DataTable GetFardMushteriFareeqainByKhatooniId(string KhatooniId)
        {

            string spWithParam = "proc_Get_Intiqal_KhanaKashtKhatooni_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }
        #endregion

        #region Get Fard Persons / Malikan

        public DataTable GetFardPersons(string FPGid)
        {

            string spWithParam = "Proc_Get_SDC_FardPersonsDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);GetFardPersons
        }
        public DataTable GetFardPersonsKhatajat(string MozaID,string FPGid)
        {

            string spWithParam = "Proc_Get_Person_KhataJats_SDC  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaID + "," + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);GetFardPersons
        }
        public DataTable GetFardPersonsKhatajat_Khankashat(string MozaID, string FPGid)
        {

            string spWithParam = "Proc_Get_Person_KhataJats_KhanaKasht_sdc  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaID + "," + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);GetFardPersons
        }
        public DataTable GetFardPersonsKhasraJajat(string MozaID, string FPGid)
        {

            string spWithParam = "Proc_Get_SDC_FardKhassraJat_By_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaID + "," + FPGid;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);GetFardPersons
        }
        #endregion

        #region Get Fard Person Khattajat Details

        public DataTable GetFardPersonKhattajat(string PersonRecId)
        {

            string spWithParam = "Proc_Get_SDC_FardKhatasDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PersonRecId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        public DataTable GetFardKhassrajat(string TokenId, string KhataId)
        {

            string spWithParam = "Proc_Get_SDC_FardKhassrasDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId+","+KhataId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        public DataTable GetPersonKhattajat(String MozaId,String PersonID )
        {


           //return ojbdb.filldatatable_from_storedProcedure("Proc_Get_Person_KhataJats'" + MozaId + "','" + PersonID + "'");
            string spWithParam = "Proc_Get_Person_KhataJatsforWerasath  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + PersonID;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
           
        }
        public DataTable GetMozaKhattajat(String MozaId)
        {
            string spWithParms = "Proc_Get_Moza_Register_KhataJat  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + "0";
            return ojbdb.filldatatable_from_storedProcedure(spWithParms);

        }

        public DataTable KhataJatDelete(string FGID, string Personrecid)
        {


            return ojbdb.filldatatable_from_storedProcedure("WEB_SP_DELETE_SDC_FardKhatasDetail_And_Person " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + FGID + "," + Personrecid + "");

        }
        #endregion

        #region Set Register Haqdaran Khatajat Locking stats

        public void setKhataLock(string KhataId, string KhataLockStat, string LockRemarks, string ShowForCorrection, string UserIdforCorrection, string InsertUpdateUserId)
        {
            string spWithParms = "Proc_Set_Khata_Lock  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId + "," + KhataLockStat + ",N'" + LockRemarks + "'," + ShowForCorrection + "," + UserIdforCorrection + "," + InsertUpdateUserId;
            ojbdb.ExecUpdateStoredProcedureWithNoRet(spWithParms);
        }

        public string insertKhataLockDetail(string KhataId, string KhataLockStat, string PrevLockDetails, string CurrLockDetails, string PicId, string InsertUserid, string InsertLoginName, string val)
        {
            string spWithParms = "Proc_Self_INSERT_KhataLockDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId + "," + KhataLockStat + ",N'" + PrevLockDetails + "',N'" + CurrLockDetails + "'," + PicId + "," + InsertUserid + ",'" + InsertLoginName + "'," + val;
            //return ojbdb.ExecUpdateStoredProcedureWithNoRet(spWithParms);
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

        #region Set Khewat Group Fareeqain Hissa Zero stats

        public string ResetKhewatFareeqainHisas(string KhataId)
        {// NOT_EXISTS
            string spWithParms = "WEB_SP_INSERT_KhewatGroupFareeqain_KhataCorrection " + KhataId;
            return  ojbdb.ExecInsertUpdateStoredProcedure(spWithParms).ToString();
        }

        #endregion

        #region Get and delete Khatajat of Detailed Fard
        public DataTable GetDetailedFardKhatajat(string TokenId)
        {

            string spWithParam = "Proc_Self_Get_SDC_DetailedFardKhatasByTokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }



        public string DeleteDetailedFardKhataRecId(string PVKhataRecId)
        {

            string spWithParam = "WEB_Self_SP_DELETE_SDC_DetailedFardKhata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PVKhataRecId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            
        }

        public string InsertDetailedFardOperatorReport(string TokenId, string OperatorReport, string UpdateUserId, string UpdateLoginName)
        {

            string spWithParam = "WEB_Self_SP_INSERT_SDC_DetailedFard_Operator_Report  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId + ",N'" + OperatorReport + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        public string InsertDetailedFardOperatorReportForOtherDistTehsils(string TehsilId,string TokenId, string OperatorReport, string UpdateUserId, string UpdateLoginName)
        {

            string spWithParam = "WEB_Self_SP_INSERT_SDC_DetailedFard_Operator_Report  " + TehsilId + "," + TokenId + ",N'" + OperatorReport + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        #endregion

        #region Get Methods for Transactional Fard
        public DataTable GetFardKhatajatFardNew(string TokenId)
        {

            string spWithParam = "Proc_Get_SDC_FardKhatasByTokenId_NewFard  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }

        public DataTable GetFardKhatooniesFardNew(string TokenId)
        {

            string spWithParam = "Proc_Get_SDC_FardKhatooniesByTokenId_NewFard  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }

        public DataTable GetFardKhatooniesByTokenIdByKhataId(string TokenId, string khataId)
        {

            string spWithParam = "Proc_Self_Get_SDC_FardKhatoonies_ByTokenId_ByKhataId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + TokenId + "," + khataId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }
        public DataTable GetKhassrasByKhataId(string khataId)
        {

            string spWithParam = "Proc_Get_KhassraJatByKhataId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + khataId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetFardKhewatFareeqainFardNew(string FardKhataRecId)
        {

            string spWithParam = "Proc_Get_SDC_Fard_KhewatFareeqain_NewFard  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FardKhataRecId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }

        public DataTable GetFardKhewatFareeqainRemainingAreaNewFard(string KhewatGroupFareeqId)
        {


            string spWithParam = "Proc_Self_Get_SDC_Remaining_Area_KhewatGroupFareeq " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhewatGroupFareeqId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }

        public DataTable GetFardKhewatFareeqainRemainingAreaRegistryIntiqal(string KhewatGroupFareeqId,string fardTokenId)
        {

            string spWithParam = "Proc_Self_Get_SDC_Remaining_Area_KhewatGroupFareeq_For_RegistryIntiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhewatGroupFareeqId + "," + fardTokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }

        public DataTable GetFardMushtriFareeqainRemainingAreaRegistryIntiqal(string MushtriFareeqId, string fardTokenId)
        {

            string spWithParam = "Proc_Self_Get_SDC_Remaining_Area_MushtriFareeq_For_RegistryIntiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MushtriFareeqId + "," + fardTokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }

        public DataTable GetFardKhewatFareeqainRemainingAreaofFard(string KhewatGroupFareeqId, string PersonId, string fardTokenId)
        {

            string spWithParam = "Proc_Self_Get_SDC_Remaining_Area_KhewatGroupFareeq_of_Fard  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhewatGroupFareeqId + "," + PersonId + "," + fardTokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }

        public DataTable GetFardMushtriFareeqainRemainingAreaofFard(string MushtriFareeqId, string PersonId, string fardTokenId)
        {

            string spWithParam = "Proc_Self_Get_SDC_Remaining_Area_MushtriFareeq_of_Fard  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MushtriFareeqId + "," + PersonId + "," + fardTokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }

        public DataTable GetFardMushteriFareeqainFardNew(string FardKhatooniRecId)
        {

            string spWithParam = "Proc_Get_SDC_Fard_MushteriFareeqain_NewFard  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FardKhatooniRecId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
           
        }

        public DataTable GetFardMushteriFareeqainRemainingAreaNewFard(string MushteriFareeqId)
        {

            string spWithParam = "Proc_Self_Get_SDC_Remaining_Area_MushteriFareeq  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MushteriFareeqId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
           
        }

        public string GetFardChangeYesNo(string dt, string purposeId)
        {
          
            string spWithParam = "proc_Self_Get_Trans_Fard_Change_YesNo '" + dt +"',"+ purposeId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
           
        }

        #endregion

        #region Delete Methods for transactional Fard
        public string DeleteFardKhataRecId(string FardKhataRecId)
        {

            string spWithParam = "WEB_SP_DELETE_SDC_FardKhata_FardNew  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FardKhataRecId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            
        }
        public string DeleteFardKhatooniRecId(string FardKhatooniRecId)
        {

            string spWithParam = "WEB_SP_DELETE_SDC_FardKhatooni_FardNew  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FardKhatooniRecId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            
        }
        public string DeleteFardKhewatFareeq(string FardPersonRecRecId)
        {

            string spWithParam = "WEB_SP_DELETE_SDC_FardKhewatFareeq_FardNew  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FardPersonRecRecId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            
        }
        public string DeleteFardMsuhteriFareeq(string FardMushteriRecId)
        {

            string spWithParam = "WEB_SP_DELETE_SDC_FardMushteriFareeq_FardNew  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FardMushteriRecId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            
        }

        public string DeleteDetailedReceipt(string RVDetailId)
        {

            string spWithParam = "WEB_Self_SP_DELETE_SDC_ReceiptVoucherDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + RVDetailId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
            
        }

        public string DeleteDetailedPayment(string PVDetailId)
        {

            string spWithParam = "WEB_Self_SP_DELETE_SDC_PaymentVoucherDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PVDetailId;
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);

        }
        #endregion

        #region Fardat Disptach to Registrar
        public string SaveRegFardatDispatchDetails(string TokenId, string DispatchId, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_Self_SP_INSERT_Reg_Fard_Dispatch_Detail "+Classess.UsersManagments._Tehsilid.ToString()+"," + TokenId + "," + DispatchId + "," + InsertUserId + ",'" + InsertLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public void DeleteSavedFardat(string TokenId)
        {
            string spWithParam = "WEB_Self_SP_DELETE_Reg_Fard_Dispatch " + TokenId;
            ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetRegistrarFardatStatus(string DispatchId)
        {

            string spWithParam = "Proc_Self_Get_SDC_Registrar_Dispatch_Status "+Classess.UsersManagments._Tehsilid.ToString()+"," + DispatchId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        public bool ConfirmRegistryFardat(string DispatchId)
        {
            string spWithParam = "WEB_Self_SP_Update_Registrar_Fardat_Confirm " + Classess.UsersManagments._Tehsilid.ToString() + "," + DispatchId;
            return Convert.ToBoolean(ojbdb.ExecInsertUpdateStoredProcedure(spWithParam));
        }


        #endregion

        #region Registries Disptach to Registrar

        public string SaveRegistriesDispatchDetails(string ReceivingId, string DispatchId, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_Self_SP_INSERT_Registries_Dispatch_Detail " + Classess.UsersManagments._Tehsilid.ToString() + "," + ReceivingId + "," + DispatchId + "," + InsertUserId + ",'" + InsertLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public void DeleteSavedRegistries(string ReceivingId)
        {
            string spWithParam = "WEB_Self_SP_DELETE_Registries_Dispatch " + ReceivingId;
            ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }
        #endregion

        #region Insert Registry Fard Dispatch for Registrar

        public string SaveFardDispatchToRegistrar(string FR, string DispatchDate, string InsertUserId, string InsertLoginName)
        {

            string spWithParam = "WEB_Self_SP_INSERT_Reg_Fard_Dispatch_Main "+Classess.UsersManagments._Tehsilid.ToString()+",'" + FR + "','" + DispatchDate + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        #endregion
    }
}
