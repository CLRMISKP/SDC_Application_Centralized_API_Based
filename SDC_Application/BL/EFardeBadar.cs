using SDC_Application.DL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SDC_Application.BL
{
    class EFardeBadar
    {
        Database dbobject = new Database();

        #region Save New Name through Fard e Badar to FB_AfardRegister
        public string SaveProposedNameToShajarah(
            string FB_Personid,
            string FB_ID,
            string PersonId,
            string QoamId,
            string PersonName,
            string CNIC,
            string ProposedName,
            string PersonExtraDetails,
            string PersonKhataDetails)
        {
            string retVal = "";
            string spWithParms = "WEB_SP_INSERT_FB_AfradRegister_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_Personid + "," + FB_ID + "," + PersonId + "," + QoamId + ",N'" + PersonName + "'," + CNIC + ",N'" + ProposedName + "',N'" + PersonExtraDetails + "','" + PersonKhataDetails + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }
        #endregion

        #region Save E Fard e Badar Main

        public string SaveFardBadarMain(string FB_Id, int MozaId, string FbDocumentNo, string GardawarDate, string ConfirmationDate, string FardBadarDetail, int InsertUserId, string InsertLoginName)
        {
            string retVal = "";
            string spWithParms = "WEB_SP_INSERT_FardBadar_Main_EFB  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_Id + "," + MozaId.ToString() + ",'" + FbDocumentNo + "','" + DateTime.Now.ToShortDateString() + "','" + GardawarDate + "','" + ConfirmationDate + "',0,'" + DateTime.Now.ToShortDateString() + "',N'" + FardBadarDetail + "'," + InsertUserId.ToString() + ",'" + InsertLoginName + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }
        public string DeleteFbKhatooniBaya(string BayaRecId)
        {
            string retVal = "";
            string spWithParms = "WEB_SP_Delete_KhatooniBaya  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," +BayaRecId;
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }
        #endregion
        #region Revert  Fard e Badar 

        public string RevertFardBadar(string FB_Id, int InsertUserId, string InsertLoginName)
        {
            string retVal = "";
            string spWithParms = "Proc_EFB_Amal_Revert  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_Id + "," + InsertUserId.ToString() + ",'" + InsertLoginName + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }

        #endregion

        #region Get Afrad list under proposed in Fard e Badar
        public DataTable GetFBAfradListProposed(string MozaId, string FBId)
        {
            string spWithParms = "Proc_Get_Moza_AfradList_All_Types_FB_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ",'" + FBId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Misal Details by Fard e Badar No

        public DataTable GetFardBaderMainByDocNoSDC(string FB_DocumentNo, int MozaId)
        {
            string spWithParms = "Proc_Get_FardBadar_Main_By_DocumentNo_EFB  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + FB_DocumentNo + "'," + MozaId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        public DataTable GetFbKhatooniKhewatGroupFareeqain(string KhatooniId)
        {
            string spWithParms = "Proc_Get_Fb_KhatooniKhewatGroupFareeqain  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+"," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion
        public string WEB_SP_INSERT_FB_Khatooni_KhewatGroupFareeqein(string bayaRecId, string KhatooniKhewatGroupFareeqId, string KhewatGroupFareeqId, string RegisterHqDKhataId, string KhatooniId, string PersonId, string KhewatFareeq_Sold_Hissa_Prop, string KhewatFareeq_Sold_Kanal_Prop, string KhewatFareeq_Sold_Marla_Prop,  string KhewatFareeq_Sold_Sarsai_Prop, string KhewatFareeq_Sold_Feet_Prop, string InsertUserId, string InsertLoginName, string Fb_Id)
        {
            string spWithParam = "WEB_SP_INSERT_FB_KhatooniKhewatGroupFareeqein " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + bayaRecId + "," + KhatooniKhewatGroupFareeqId + ",'" + KhewatGroupFareeqId + "'," + RegisterHqDKhataId + "," + KhatooniId + "," + PersonId + "," + KhewatFareeq_Sold_Hissa_Prop +
                 "," + KhewatFareeq_Sold_Kanal_Prop  + "," + KhewatFareeq_Sold_Marla_Prop  + "," + KhewatFareeq_Sold_Sarsai_Prop + "," + KhewatFareeq_Sold_Feet_Prop + "," + InsertUserId + ",'" + InsertLoginName + "'," + Fb_Id;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        #region Get FBKhatajat by FBId
        public DataTable GetFbKhattajatProposed(
            string fbId)
        {
            string spWithParms = "Proc_Get_FB_KhataJat_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fbId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Save FB_Khattajat Proposed
        public string SaveFBKhattajatProposed(
            string FB_KhataId,
            string FB_ID,
            int FB_RegisterHqDKhataId,
            string TotalParts,
            string TotalParts_Proposed,
            string Khata_Kanal,
            string Khata_Kanal_Proposed,
            string Khata_Marla,
            string Khata_Marla_Proposed,
            string Khata_Sarsai,
            string Khata_Sarsai_Proposed,
            string Khata_Feet,
            string Khata_Feet_Proposed,
            string isApplicableForMeezan,
            int InsertUserId,
            string InsertLoginName
            )
        {
            string retVal = "";
            string spWithParms = "WEB_SP_INSERT_FB_Khatajat_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_KhataId + "," + FB_ID + "," + FB_RegisterHqDKhataId + "," + TotalParts + "," + TotalParts_Proposed + "," +
                                Khata_Kanal + "," + Khata_Kanal_Proposed + "," + Khata_Marla + "," + Khata_Marla_Proposed + "," + Khata_Sarsai + "," + Khata_Sarsai_Proposed + ","
                                + Khata_Feet + "," + Khata_Feet_Proposed + "," + isApplicableForMeezan + ",'" + DateTime.Now + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }
        #endregion

        #region Save Khewat Group Fareeq Proposed FB
        public string SaveFBKhewatGroupFarqeenProposed(
                   string FB_FareeqeinId,
                   string FB_Id,
                   string KhewatGroupFareeqId,
                   string KhewatGroupId,
                   string TransactionType,
                   string IntiqalId,
                   string SeqNo,
                   string PersonId,
                   string PersonId_Proposed,
                   string KhewatTypeId,
                   string KhewatTypeId_Proposed,
                   string FardAreaPart,
                   string FardAreaPart_Proposed,
                   string Farad_Kanal,
                   string Farad_Kanal_Proposed,
                   string Fard_Marla,
                   string Fard_Marla_Proposed,
                   string Fard_Sarsai,
                   string Fard_Sarsai_Proposed,
                   string Fard_Feet,
                   string Fard_Feet_Proposed,
                   string InsertUserId,
                   string InsertLoginName,
                   string FardPart_Bata,
                   string FardPart_Bata_Proposed,
                   string RegisterHqDKhataId)
        {
            string spWithParms = "WEB_SP_INSERT_FB_KhewatGroupFareeqein_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," +
            FB_FareeqeinId + "," +
            FB_Id + "," +
            KhewatGroupFareeqId + "," +
            KhewatGroupId + ",'" +
            TransactionType + "'," +
            IntiqalId + "," +
            SeqNo + "," +
            PersonId + "," +
            PersonId_Proposed + "," +
            KhewatTypeId + "," +
            KhewatTypeId_Proposed + ",'" +
            FardAreaPart + "','" +
            FardAreaPart_Proposed + "'," +
            Farad_Kanal + "," +
            Farad_Kanal_Proposed + "," +
            Fard_Marla + "," +
            Fard_Marla_Proposed + "," +
            Fard_Sarsai + "," +
            Fard_Sarsai_Proposed + "," +
            Fard_Feet + "," +
            Fard_Feet_Proposed + "," +
            InsertUserId + ",'" +
            InsertLoginName + "','" +
            FardPart_Bata + "','" +
            FardPart_Bata_Proposed + "'," +
            RegisterHqDKhataId;

            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Save Khewat Group Fareeq Proposed FB
        public string SaveFBKhassraRegister(
                   string FB_KhassraId,
                   string FB_KhassraDetailId,
                   string FB_Id,
                   string KhassraId,
                   string MozaId,
                   string KhassraNo,
                   string KhassraNo_Proposed,
                   string KhassraDetailId,
                   string KhatooniId,
                   string AreaTypeId,
                    string AreaTypeIdProp,
                   string Kanal,
                   string Kanal_Proposed,
                   string Marla,
                   string Marla_Proposed,
                   string Sarsai,
                   string Sarsai_Proposed,
                   string Feet,
                   string Feet_Proposed,
                   string InsertUserId,
                   string InsertLoginName
                  )
        {
            string spWithParms = "WEB_SP_INSERT_FB_KhassraRegister_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," +
            FB_KhassraId + "," +
            FB_KhassraDetailId + "," +
            FB_Id + "," +
            KhassraId + "," +
            MozaId + ",N'" +
            KhassraNo + "',N'" +
            KhassraNo_Proposed + "'," +
            KhassraDetailId + "," +
            KhatooniId + "," +
            AreaTypeId + "," +
            AreaTypeIdProp + "," +
            Kanal + ",'" +
            Kanal_Proposed + "','" +
            Marla + "'," +
            Marla_Proposed + "," +
            Sarsai + "," +
            Sarsai_Proposed + "," +
            Feet + "," +
            Feet_Proposed + "," +
            InsertUserId + ",'" +
            InsertLoginName + "'";

            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        #region Save Khatooni Register Proposed

        public string SaveFbKhatooniRegisterProposed(string FB_KhatooniId, string FB_ID, string KhatooniId, string KhataId, string KhatooniNo,
            string KhatooniHissa, string KhatooniHissa_Proposed, string Kanal, string Kanal_Proposed, string Marla, string Marla_Proposed,
            string Sarsai, string Sarsai_Proposed, string InsertUserId, string InsertLoginName, string isKhatooniMeezanChange)
        {
            string spWithParam = "WEB_SP_INSERT_FB_KhatooniRegister_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_KhatooniId + "," + FB_ID + "," + KhatooniId + "," + KhataId + ",'" + KhatooniNo + "'," +
                                                                             KhatooniHissa + "," + KhatooniHissa_Proposed
                                                                     + "," + Kanal + ",'" + Kanal_Proposed + "'," + Marla + "," + Marla_Proposed
                                                                     + "," + Sarsai + "," + Sarsai_Proposed + "," + InsertUserId + ",'" + InsertLoginName + "', " + isKhatooniMeezanChange;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        #endregion   //

        #region Delete Khatooni Register Proposed

        public string DeleteFbKhatooniRegisterProposed(string FB_ID, string FB_KhatooniId)
        {
            string spWithParam = "WEB_SP_DELETE_FB_Khatooni_Proposed " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + FB_ID + "," + FB_KhatooniId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        #endregion

        #region Save FB Mushteri Fareeq

        public string SaveFbMushteriFareeain(string FB_MushteriFareeqId, string FB_ID, string MushtriFareeqId, string KhatooniId, string PersonId, string PersonId_Proposed,
            string KhewatTypeId, string KhewatTypeIdProposed, string FardAreaPart, string FardAreaPart_Proposed, string FardPart_Bata_Proposed, string Farad_Kanal_Proposed, string Fard_Marla_Proposed,
            string Fard_Sarsai_Proposed, string Fard_Feet_Proposed, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_FB_MushteriFareeqain  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_MushteriFareeqId + "," + FB_ID + "," + MushtriFareeqId + "," + KhatooniId + "," + PersonId + "," + PersonId_Proposed + "," + KhewatTypeId + "," + KhewatTypeIdProposed
                                                                    + "," + FardAreaPart_Proposed + ",'" + FardPart_Bata_Proposed + "'," + Farad_Kanal_Proposed + "," + Fard_Marla_Proposed
                                                                    + "," + Fard_Sarsai_Proposed + "," + Fard_Feet_Proposed + "," + InsertUserId + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        #endregion

        #region Save Gardawar or Tehsildar Report
        //WEB_SP_INSERT_EFB_Reports
        public string SaveFardeBadarReport(
            string Fb_Id,
            string ReportFor,
            string GardawarReport,
            string TehsildarReport
            )
        {
            string retVal = "";
            string spWithParms = "WEB_SP_INSERT_EFB_Reports " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + Fb_Id + ",'" + ReportFor + "',N'" + GardawarReport + "',N'" + TehsildarReport + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }
        #endregion

        #region Attest and Implement Fade Bader

        public string AttestImplementFB(string Fb_Id, string AttestedBy)
        {
            string spWithParam = "Proc_EFB_Amaldaramad " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + Fb_Id + ",'" + AttestedBy + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        #endregion

        #region Get FB Khewat Group Fareeqein by KhataId
        public DataTable GetKhewatGroupFareeqeinByKhataIdByFbId(string fbId, string KhataId)
        {
            string spWithParms = "Proc_Get_KhewatFareeqeinGroup_By_Khata_FB_Proposed " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + fbId + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Fardat and Intiqalat by KhewatGrpupFareeqId
        public DataTable GetFardatIntiqalatOnKhewatGrpupFareeqId(string KhewatGroupFareeqId)
        {
            string spWithParms = " Proc_Get_KhewatFareeqein_to_check_ByFard_ByIntiqal_for_FB  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhewatGroupFareeqId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get FB Khassrajat by Fb
        public DataTable GetKhassrajatDetailByFbId(string fbId, string fbKhataId)
        {
            string spWithParms = "Proc_Get_KhassraArea_Detail_FB_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fbId + "," + fbKhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get FB Khatooni Register by Fb, KhataId
        public DataTable GetFBKhatooniRegisterProposed(string fbId, string KhataId)
        {
            string spWithParms = "Proc_Get_Khatoonis_FB_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fbId + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get FB MushteriFareeqain by Fb
        public DataTable GetFBMushteriFareeqainByFbId(string fbId)
        {
            string spWithParms = "Proc_Get_MushtriFareeqeinFB_By_FB_Id  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fbId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Delete Fard badar Malik

        public string DeleteFbKhewatGroupFareeq(string FbFareeqainId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_KhewatGroupFareeqein_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FbFareeqainId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

        #region Delete Fard badar Khassra

        public string DeleteFbKhassraDetail(string FB_Id, string FbKhassraDetailId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_Khassrajat_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FB_Id + "," + FbKhassraDetailId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

        #region Delete Fard badar Mushteri Fareeq

        public string DeleteFbMushteriFareeq(string FbMushteriFareeqId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_MushtriFareeqein " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + FbMushteriFareeqId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

        #region Delete Fard badar Fard from Shajra FB

        public string DeleteFbFard(string FbPersonId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_AfradRegister_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FbPersonId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

        #region Delete Fard badar Khata

        public string DeleteFbKhata(string Fb_Id, string FB_KhataId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_Khatajat_Proposed  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + Fb_Id + "," + FB_KhataId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

    }
}
