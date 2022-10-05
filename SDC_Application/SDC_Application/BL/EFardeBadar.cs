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
            string ProposedFatherName,
            string PersonExtraDetails,
            string PersonKhataDetails)
            {
            string retVal = "";
            string spWithParms = "WEB_SP_INSERT_FB_AfradRegister_Proposed " + FB_Personid + "," + FB_ID + "," + PersonId + "," + QoamId + ",N'" + PersonName + "',"+CNIC + ",N'" + ProposedName + "',N'" + ProposedFatherName + "',N'"+PersonExtraDetails+"','"+PersonKhataDetails+"'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
            }
        #endregion

        #region Save E Fard e Badar Main

        public string SaveFardBadarMain(string FB_Id, int MozaId, string FbDocumentNo, string GardawarDate, string ConfirmationDate, string FardBadarDetail, int InsertUserId, string InsertLoginName)
        {
            string retVal = "";
            string spWithParms = "WEB_SP_INSERT_FardBadar_Main_EFB " + FB_Id + "," + MozaId.ToString() + ",'" + FbDocumentNo + "','" + DateTime.Now.ToShortDateString() + "','" + GardawarDate + "','" + ConfirmationDate + "',0,'" + DateTime.Now.ToShortDateString() + "',N'" + FardBadarDetail + "'," + InsertUserId.ToString() + ",'" + InsertLoginName + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }
        
        #endregion

        #region Get Afrad list under proposed in Fard e Badar
        public DataTable GetFBAfradListProposed(string MozaId, string FBId)
            {
            string spWithParms = "Proc_Get_Moza_AfradList_All_Types_FB_Proposed " + MozaId + ",'" + FBId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
            }
        #endregion

        #region Get Misal Details by Fard e Badar No

        public DataTable GetFardBaderMainByDocNoSDC(string FB_DocumentNo, int MozaId)
            {
            string spWithParms = "Proc_Get_FardBadar_Main_By_DocumentNo_EFB '" + FB_DocumentNo + "'," + MozaId.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
            }
        #endregion

        #region Get FBKhatajat by FBId
        public DataTable GetFbKhattajatProposed(
            string fbId)
            {
            string spWithParms = "Proc_Get_FB_KhataJat_Proposed " + fbId;
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
            string spWithParms = "WEB_SP_INSERT_FB_Khatajat_Proposed " + FB_KhataId + "," + FB_ID + "," + FB_RegisterHqDKhataId + "," + TotalParts + "," + TotalParts_Proposed + "," +
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
            string spWithParms = "WEB_SP_INSERT_FB_KhewatGroupFareeqein_Proposed " +
                FB_FareeqeinId + "," +
                FB_Id + "," +
                KhewatGroupFareeqId + "," +
                KhewatGroupId + ",'" +
                TransactionType + "'," +
                IntiqalId + "," +
                SeqNo + "," +
                PersonId + "," +
                PersonId_Proposed + "," +
                KhewatTypeId + ",'" +
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
                string spWithParms = "WEB_SP_INSERT_FB_KhassraRegister_Proposed " +
                FB_KhassraId + "," +
                FB_KhassraDetailId +","+
                FB_Id + "," +
                KhassraId + "," +
                MozaId + ",'" +
                KhassraNo + "','" +
                KhassraNo_Proposed + "'," +
                KhassraDetailId + "," +
                KhatooniId + "," +
                AreaTypeId + "," +
                Kanal + ",'" +
                Kanal_Proposed + "','" +
                Marla + "'," +
                Marla_Proposed + "," +
                Sarsai + "," +
                Sarsai_Proposed + "," +
                Feet + "," +
                Feet_Proposed + "," +
                InsertUserId + ",'" +
                InsertLoginName+"'";

            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            }
        #endregion

        #region Save FB Mushteri Fareeq 

        public string SaveFbMushteriFareeain(string FB_MushteriFareeqId, string FB_ID, string MushtriFareeqId, string KhatooniId, string PersonId, string PersonId_Proposed,
            string KhewatTypeId, string FardAreaPart, string FardAreaPart_Proposed, string FardPart_Bata_Proposed, string Farad_Kanal_Proposed, string Fard_Marla_Proposed,
            string Fard_Sarsai_Proposed, string Fard_Feet_Proposed, string InsertUserId, string InsertLoginName)
        {
           string spWithParam="WEB_SP_INSERT_FB_MushteriFareeqain "+FB_MushteriFareeqId+","+FB_ID+","+MushtriFareeqId+","+KhatooniId+","+PersonId+","+PersonId_Proposed+","+KhewatTypeId+","+FardAreaPart			
                                                                    +","+FardAreaPart_Proposed+",'"+FardPart_Bata_Proposed+"',"+Farad_Kanal_Proposed+","+Fard_Marla_Proposed	
                                                                    +","+Fard_Sarsai_Proposed+","+Fard_Feet_Proposed+","+  InsertUserId	+",'"+InsertLoginName+"'";
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
            string spWithParms = "WEB_SP_INSERT_EFB_Reports " + Fb_Id + ",'" + ReportFor + "',N'" + GardawarReport + "',N'" + TehsildarReport + "'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
            }
        #endregion

        #region Attest and Implement Fade Bader

        public string AttestImplementFB(string Fb_Id, string AttestedBy)
        {
            string spWithParam = "Proc_EFB_Amaldaramad "+Fb_Id+",'"+AttestedBy+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        #endregion

        #region Get FB Khewat Group Fareeqein by KhataId
        public DataTable GetKhewatGroupFareeqeinByKhataIdByFbId(string fbId, string KhataId)
            {
            string spWithParms = "Proc_Get_KhewatFareeqeinGroup_By_Khata_FB_Proposed " + fbId+","+KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
            }
        #endregion

        #region Get FB Khassrajat by Fb
        public DataTable GetKhassrajatDetailByFbId(string fbId)
        {
            string spWithParms = "Proc_Get_KhassraArea_Detail_FB_Proposed " + fbId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get FB MushteriFareeqain by Fb
        public DataTable GetFBMushteriFareeqainByFbId(string fbId)
        {
            string spWithParms = "Proc_Get_MushtriFareeqeinFB_By_FB_Id " + fbId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Delete Fard badar Malik

        public string DeleteFbKhewatGroupFareeq(string FbFareeqainId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_KhewatGroupFareeqein_Proposed " +FbFareeqainId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

            #endregion

        #region Delete Fard badar Khassra

        public string DeleteFbKhassraDetail(string FB_Id, string FbKhassraDetailId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_Khassrajat_Proposed " + FB_Id + "," + FbKhassraDetailId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

        #region Delete Fard badar Mushteri Fareeq

        public string DeleteFbMushteriFareeq(string FbMushteriFareeqId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_MushtriFareeqein " + FbMushteriFareeqId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

        #region Delete Fard badar Fard from Shajra FB

        public string DeleteFbFard(string FbPersonId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_AfradRegister_Proposed " + FbPersonId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

        #region Delete Fard badar Khata

        public string DeleteFbKhata(string Fb_Id, string FB_KhataId)
        {
            string spWithParms = "WEB_SP_DELETE_FB_Khatajat_Proposed "+Fb_Id+"," + FB_KhataId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }

        #endregion

        }
    }
