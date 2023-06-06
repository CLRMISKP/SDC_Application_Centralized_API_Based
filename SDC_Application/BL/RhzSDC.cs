using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SDC_Application.DL;
using System.Data.SqlClient;

namespace SDC_Application.BL
{
    class RhzSDC
    {
        DL.Database dbobject = new Database();
       // Proc_Get_Gaintax

            public DataTable Proc_Get_Gaintax(string personid)
        {
            string spWithParam = "Proc_Get_Gaintax " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + personid + "";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

            public DataTable GetKhatajatAll(string  MozaId)
            {
                string spWithParam = "Proc_Get_Moza_Register_KhataJat_All_Status " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

            }

        public DataTable WEB_SP_DELETE_KhatooniRegister(string khatooniid)
        {
            string spWithParam = "WEB_SP_DELETE_KhatooniRegister  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + khatooniid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable WEB_SP_DELETE_KhassraRegisterDetail_Direct(string khasradetailid)
        {
            string spWithParam = "WEB_SP_DELETE_KhassraRegisterDetail_Direct  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + khasradetailid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public string WEB_SP_INSERT_KhassraRegistert(string KhassraId, string MozaId, string KhassraCode, string KhassraNo, string KhassraCreation_Date, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegister  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhassraId + "," + MozaId + "," + KhassraCode + ",N'" + KhassraNo + "','" + KhassraCreation_Date + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string WEB_SP_INSERT_KhassraRegisterDetail(string KhassraDetailId,string KhassraId , string AreaTypeId ,string Kanal  ,string Marla,string Sarsai,string Feet ,string InsertUserId   ) 
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegisterDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhassraDetailId + "," + KhassraId + "," + AreaTypeId + "," + Kanal + "," + Marla + "," + Sarsai + "," + Feet + "," + InsertUserId + "";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string WEB_SP_INSERT_KhassraRegister_Intiqal_Taqseem(string khasraid,string khatoniid,string userid,string loginname)
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegister_Intiqal_Taqseem  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + khasraid + "'," + khatoniid + "," + userid + ",'" + loginname + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveRHZChangeDetails(string RHZ_ChangeId, string MozaId, string SrNo, string ChangeDetails)
        {
            string spWithParam = "WEB_SP_INSERT_RHZ_Change_Record  "+RHZ_ChangeId+"," + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId + ", " + SrNo + ", N'" + ChangeDetails + "', " + Classess.UsersManagments.UserId + ", '" + Classess.UsersManagments.UserName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string DeleteRHZChangeDetails(string RHZ_ChangeId)
        {
            string spWithParam = "WEB_SP_DELETE_RHZ_Change_Record  " + RHZ_ChangeId + "," + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + Classess.UsersManagments.UserId + ", '" + Classess.UsersManagments.UserName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string DeleteHaqdaranZameenKhatajatEdit(string KhataId,string RHZ_ChangeId)
        {
            string spWithParam = "WEB_SP_DELETE_HaqdaranZameenKhatajat_Edit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhataId + "," + RHZ_ChangeId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string GetMaxSrNoRHZChangeBYMozaId(string MozaId)
        {
            string spWithParam = "Proc_Get_Max_SrNo_RHZ_Change_By_Moza  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable GetRHZChangeDetailsListBYMozaId(string MozaId)
        {
            string spWithParam = "Proc_Get_RHZ_Change_Details_List_By_MozaId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public string UpdateKhataRecStatus(string KhataId, string Status)
        {
            string spWithParam = "Web_Sp_Update_Khata_RecStatus  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhataId + "," + Status;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable GetRHZChangeSummary()
        {
            string spWithParam = "Proc_Get_RHZ_Change_List_All  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public DataTable GetRHZChangeDetailsByMoza(string MozaId)
        {
            string spWithParam = "Proc_Get_RHZ_Change_List  " + MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetRHZChangePendingAllMouzas()
        {
            string spWithParam = "Proc_Get_RHZ_Change_List_Pending_All_Mozas  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public DataTable GetMushteriFareeqainEdit(string KhatooniId)
        {
            string spWithParam = "Proc_Get_MushteriFareeqain_Edit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public string SaveNewKhata(string RegisterHqDKhataId, string RegisterHaqdaranId, string KhataNo, string Taraf, string Patai, string TotalParts, string Kanal, string Maral, string Sarsai, string feet, string malia, string kefiat, string insertuserid, string InsertLoginName, string RecStatus, string MozaId)
        {
            string spWithParam = "WEB_SP_INSERT_HaqdaranZameenKhatajat  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + RegisterHqDKhataId + ", " + RegisterHaqdaranId + ", '" + KhataNo + "', '" + Taraf + "', '" + Patai + "', " + TotalParts + ", " + Kanal + ", " + Maral + ", " + Sarsai + ", " + feet + ", N'" + malia + "', N'" + kefiat + "', " + insertuserid + ", '" + InsertLoginName + "',"+RecStatus+","+MozaId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        #region Save New Name through AfardRegister_Edit
        public string SaveProposedNameToShajra(string PersonRecId, string RHZ_ChangeId,string PersonId,string QoamIdProp,string CNICProp,string ProposedName,string  EditMode, string UserId, string LoginName)
        {
            string retVal = "";
            string spWithParms = "WEB_SP_INSERT_AfradRegister_Edit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+PersonRecId + "," + RHZ_ChangeId + "," +  PersonId + "," + QoamIdProp + "," + CNICProp+ ",N'" + ProposedName + "','" + EditMode + "'," + UserId + ",'"+LoginName+"'";
            retVal = dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
            return retVal;
        }
        #endregion
        #region Get Afrad list Edited
        public DataTable GetAfradListProposed(string RHZ_ChangeId)
        {
            string spWithParms = "Proc_Get_Moza_AfradList_Edit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + RHZ_ChangeId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion
        #region Get Afrad list proposed 
        public DataTable GetAfradListEdit(string RHZ_ChangeId)
        {
            string spWithParms = "Proc_Get_Moza_AfradList_Edit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + RHZ_ChangeId ;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion
        #region Get Intiqalat By Person Id
        public DataTable GetIntiqalatByPersonId(string PersonId)
        {
            string spWithParms = "Proc_Get_Intiqalat_By_PersonId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PersonId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion
        #region Get Fard Badrat By Person Id
        public DataTable GetFardBadratByPersonId(string PersonId)
        {
            string spWithParms = "Proc_Get_FardBadrat_By_PersonId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PersonId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion
        #region Get Fardats By Person Id
        public DataTable GetFardatsByPersonId(string PersonId)
        {
            string spWithParms = "Proc_Get_Fardats_By_PersonId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PersonId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion
        #region Get Fardats By Person Id
        public DataTable GetKhatajatStringByPersonId(string PersonId)
        {
            string spWithParms = "Proc_Get_KhatajatString_By_PersonId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PersonId;
            return dbobject.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion
        public string SaveKhataDetails(string KhataRecId,string RHZ_ChangeId, string KhataId, string RegisterId, string KhataNo, string KhataNoProp,string KhataHissas, string KhataHissasProp ,string Kanal, string KanalProp, string Marla, string MarlaProp, string Sarsai, string SarsaiProp, string Sft, string SftProp, string Kyfiat, string UserId, string LoginName, string KyfiatProp, string EditingMode, string KhataStatus)
        {
            string spWithParam = "WEB_SP_INSERT_HaqdaranZameenKhatajatEdit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataRecId +","+RHZ_ChangeId+ ",'" + KhataId + "'," + RegisterId + ",'" + KhataNo + "','" + KhataNoProp + "'," + KhataHissas + "," + KhataHissasProp + ","+ Kanal + "," + KanalProp + "," + Marla + "," + MarlaProp + "," + Sarsai + "," + SarsaiProp + "," + Sft + "," + SftProp + "," + UserId + ",'" + LoginName + "',N'" + Kyfiat + "',N'" + KyfiatProp + "','"+EditingMode+"',"+KhataStatus;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable GetKhatajatEditedByRHZ_ChangeId(string MozaId, string RHZ_ChangeId)
        {
            string spWithParam = "Proc_Get_Moza_Register_KhataJat_Edit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId + "," + RHZ_ChangeId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetIntiqalPendingMissingAll()
        {
            string spWithParam = "Proc_Get_Intiqal_Pending_Missing  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString();
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public string RHZ_ChangeImplementation(string RHZ_ChangeId)
        {
            string spWithParam = "Proc_RHZ_Change_Implementation  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + RHZ_ChangeId  + "," + Classess.UsersManagments.UserId.ToString() + ",'" + Classess.UsersManagments.UserName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }


        #region Save Khassra Register Details 
        public string SaveKhassraRegisterEdit(
                   string KhassraRecId,
                   string KhassraDetailRecId,
                   string KhassraId,
                   string MozaId,
                   string KhassraNo,
                   string KhassraNo_Proposed,
                   string KhassraDetailId,
                   string KhatooniId,
                   string AreaTypeId,
                   string AreaTypeIdProposed,
                   string Kanal,
                   string Kanal_Proposed,
                   string Marla,
                   string Marla_Proposed,
                   string Sarsai,
                   string Sarsai_Proposed,
                   string Feet,
                   string Feet_Proposed,
                   string InsertUserId,
                   string InsertLoginName,
                    string ChangeMode,
                    string RHZ_ChangeId
                  )
        {
            string spWithParms = "WEB_SP_INSERT_KhassraRegister_Edit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," +
            KhassraRecId + "," +
            KhassraDetailRecId + "," +
            KhassraId + "," +
            MozaId + ",N'" +
            KhassraNo + "',N'" +
            KhassraNo_Proposed + "'," +
            KhassraDetailId + "," +
            KhatooniId + "," +
            AreaTypeId + "," + AreaTypeIdProposed + "," +
            Kanal + "," +
            Kanal_Proposed + "," +
            Marla + "," +
            Marla_Proposed + "," +
            Sarsai + "," +
            Sarsai_Proposed + "," +
            Feet + "," +
            Feet_Proposed + "," +
            InsertUserId + ",'" +
            InsertLoginName + "','"+ChangeMode+"',"+RHZ_ChangeId;

            return dbobject.ExecInsertUpdateStoredProcedure(spWithParms);
        }
        #endregion

        public DataTable Proc_Get_Max_Khatooni_No_By_Moza(string mozaid)
        {
            string spWithParam = "Proc_Get_Max_Khatooni_No_By_Moza  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + mozaid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_Max_Khata_No_By_Moza(string mozaid)
        {
            string spWithParam = "Proc_Get_Max_Khata_No_By_Moza  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + mozaid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public string WEB_SP_INSERT_KhatooniRegister(string KhatooniId, string KhatooniNo, string KhatooniKashtkaranFullDetail_New, string RegisterHqDKhataId, string Wasail_e_Abpashi, string KhatooniLagan,string insertuserid, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_KhatooniRegister " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhatooniId + ",'" + KhatooniNo + "',N'" + KhatooniKashtkaranFullDetail_New + "'," + RegisterHqDKhataId + ",N'" + Wasail_e_Abpashi + "',N'" + KhatooniLagan + "'," + insertuserid + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string WEB_SP_INSERT_KhatooniRegisterEdit(string KhatooniRecId, string KhatooniId, string KhatooniNo, string KhatooniNoProp, string KhatooniKashtkaranFullDetail_New, string KhatooniKashtkaranFullDetail_NewProp, string RegisterHqDKhataId, string Wasail_e_Abpashi, string Wasail_e_AbpashiProp, string KhatooniLagan, string KhatooniLaganProp, string BeahShud,
			string BeahShudProp,string Khatooni_Hissa, string Khatooni_HissaProp, string Khatooni_Kanal, string Khatooni_KanalProp, string Khatooni_Marla, string Khatooni_MarlaProp, string Khatooni_Sarsai, string Khatooni_SarsaiProp, string Khatooni_Feet, string Khatooni_FeetProp,string insertuserid, string InsertLoginName, string RHZ_ChangeId, string ChangeMode)
        {
            string spWithParam = "WEB_SP_INSERT_KhatooniRegisterEdit " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhatooniRecId + ", " + KhatooniId + ",'" + KhatooniNo + "','" + KhatooniNoProp + "',N'" + KhatooniKashtkaranFullDetail_New + "',N'" + KhatooniKashtkaranFullDetail_NewProp + "'," + RegisterHqDKhataId + ",N'" + Wasail_e_Abpashi + "',N'" + Wasail_e_AbpashiProp + "',N'" + KhatooniLagan + "',N'" + KhatooniLaganProp + "',"+BeahShud+","+
			BeahShudProp+","+Khatooni_Hissa+","+Khatooni_HissaProp+","+Khatooni_Kanal+","+Khatooni_KanalProp+","+Khatooni_Marla+","+Khatooni_MarlaProp+","+Khatooni_Sarsai+","+Khatooni_SarsaiProp+","+Khatooni_Feet+","+Khatooni_FeetProp+"," + insertuserid + ",'" + InsertLoginName + "',"+RHZ_ChangeId+",'"+ChangeMode+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveMushteriFareeqEdit(string MushtriFareeqRecId,string Rhz_ChangeId,string MushtriFareeqId , string PersonIdProp, string KhewatTypeIdProp, string FardAreaPartProp, string FardPartBataProp, 
           string KanalProp, string MarlaProp,  string SarsaiProp, string FeetProp, string insertuserid, string InsertLoginName, string RecStatusProp, string SeqNoProp)
        {
            string spWithParam = "WEB_SP_INSERT_MushteriFareeqain_Edit " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MushtriFareeqRecId +","+Rhz_ChangeId+ ", " + MushtriFareeqId + ", " +  PersonIdProp + ","  + KhewatTypeIdProp + ","   + FardAreaPartProp + ","  + FardAreaPartProp + ","  + KanalProp + ","  + MarlaProp + ","  + SarsaiProp + ","  + FeetProp + "," + insertuserid + ",'" + InsertLoginName + "',"   + RecStatusProp+","+SeqNoProp;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string SaveMushteriFareeq(string MushtriFareeqId,string TrasactionType,string KhatooniId, string PersonId, string KhewatTypeId, string FardAreaPart, string FardPartBata,
          string Kanal, string Marla, string Sarsai, string Feet, string insertuserid, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_MushtriFareeqein " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MushtriFareeqId + ",0, N'" + TrasactionType + "',0," + KhatooniId + ",0," + PersonId + ",0," + KhewatTypeId + "," + FardAreaPart + "," + FardPartBata + "," + Kanal + "," + Marla + "," + Sarsai + "," + Feet + "," + insertuserid + ",'" + InsertLoginName + "'," + insertuserid + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string DeleteKhatooniEdit(string KhatooniRecId)
        {
            return dbobject.ExecInsertUpdateStoredProcedure("WEB_SP_DELETE_KhatooniRegister_Edit "+Classess.UsersManagments._Tehsilid.ToString()+"," + KhatooniRecId);
        }
        public string DeleteKhassraRegisterEdit(string KhassraDetailRecId)
        {
            return dbobject.ExecInsertUpdateStoredProcedure("WEB_SP_DELETE_KhassraRegisterDetail_Edit " + Classess.UsersManagments._Tehsilid.ToString() + "," + KhassraDetailRecId);
        }
        public string DeleteMushtriFareeqEdit(string MushtriFareeqRecId)
        {
            return dbobject.ExecInsertUpdateStoredProcedure("WEB_SP_Delete_MushtriFareeqEdit " + Classess.UsersManagments._Tehsilid.ToString() + "," + MushtriFareeqRecId);
        }
        public string SaveKhassraRegister(string KhassraId, string KhatooniId, string MozaId, string KhassraNo, string insertuserid, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegisterWithKhatooniKhassraGroup " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhassraId + ", " + KhatooniId + ", " + MozaId + ",N'" + KhassraNo + "'," + insertuserid + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string SaveKhassraRegisterDetails(string KhassraDetailId, string KhassraId, string AreaTypeId, string Kanal, string Marla,string Sarsai, string Feet, string insertuserid)
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegisterDetail " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhassraDetailId + ", " + KhassraId + ", " + AreaTypeId + ", " + Kanal + ", " + Marla + ", " + Sarsai + ", " + Feet+ "," + insertuserid ;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string DeleteKhassraRegisterDetail(string KhassraDetailId,string RHZ_ChangeId, string UserId, string UserName)
        {
            string spWithParam = "WEB_SP_DELETE_KhassraRegisterDetail " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhassraDetailId +","+RHZ_ChangeId+ "," + UserId + ",'" + UserName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable Proc_Get_KhassraJatByIntiqalId(string khataid)
        {
            string spWithParam = "Proc_Get_KhassraJatByIntiqalId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + khataid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetKhassraListByKhatooni(string KhatooniId)
        {
            string spWithParam = "Proc_Get_Khatooni_Khasra_List "  + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable Proc_Get_KhassraJatByKhataId(string khataid)
        {
            string spWithParam = "Proc_Get_KhassraJatByKhataId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + khataid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_KhatooniKhassraDetail(string Khatooniid)
        {
            string spWithParam = "Proc_Get_Khatooni_KhassraArea_Detail " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + Khatooniid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhatooniKhassraDetailEdit(string Khatooniid, string RHZ_ChangeId)
        {
            string spWithParam = "Proc_Get_Khatooni_KhassraArea_Detail_Edit " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + Khatooniid+","+RHZ_ChangeId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_Khatoonis(string khataid)
        {
            string spWithParam = "Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + khataid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetKhatooniEditingDetailsByKhatooniId(string KhatooniId, string RHZ_ChangeId)
        {
            string spWithParam = "Proc_Get_KhatooniEditingDetail_By_KhatooniId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId+","+RHZ_ChangeId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_Khatoonis_Intiqal_Taqseem_by_IntiqalId(string intiqalid)
        {
            string spWithParam = "Proc_Get_Khatoonis_Intiqal_Taqseem_by_IntiqalId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + intiqalid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_KhewatFareeqeinBy_KhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqeinByKhataId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_KhewatFareeqeinBy_KhataId_Edite(string KhataId, string RHZ_ChangeId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqeinGroupEdit_By_Khata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId+","+RHZ_ChangeId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetKhatajatEditByKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_KhataJat_Edit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
     
        public DataTable Proc_Get_KhewatFareeqeinByKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        // Selfff 
        public DataTable Proc_Self_Get_KhewatFareeqeinByKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata_All_RecStatus  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        //------------------------------
        public DataTable Proc_Get_Taqseem_RegisterHqDKhataId(string RegisterHqDKhataId)
        {
            string spWithParam = "Proc_Get_Taqseem_RegisterHqDKhataId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + RegisterHqDKhataId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhewatTypes(string TehsilId)
        {
            string spWithParam = "Proc_Get_KhewatTypes  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString();//+ "," + TehsilId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable proc_Get_Intiqal_Buyers_List_ByIntiqal(string IniqalId)
        {
            string spWithParam = "proc_Get_Intiqal_Buyers_List_ByIntiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IniqalId + ""; //
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_Moza_Register_KhataJat_ParentKhataID(string MozaId, string ParentKhataId)
        {
            string spWithParam = "Proc_Get_Moza_Register_KhataJat_ParentKhataID  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + ParentKhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Intiqal_Ishtrak_Mushtrian(string IniqalId)
        {
            string spWithParam = "Proc_Intiqal_Ishtrak_Mushtrian  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IniqalId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public string SaveSubKhatooni(string KhatooniId, string ParentKhatooniId, string TotalParts, string Kanal, string Maral, string Sarsai, string feet, string IntiqalId, string KhatooniNo, string KhatooniKashtkaranFullDetail_New, string RegisterHqDKhataId, string Wasail_e_Abpashi, string KhatooniLagan, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_KhatooniRegisterSubKhatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId + "," + ParentKhatooniId + "," + TotalParts + "," + Kanal + "," + Maral + "," + Sarsai + "," + feet + "," + IntiqalId + ",'" + KhatooniNo + "',N'" + KhatooniKashtkaranFullDetail_New + "'," + RegisterHqDKhataId + ",N'" + Wasail_e_Abpashi + "',N'" + KhatooniLagan + "', " + InsertUserId + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string WEB_SP_INSERT_HaqdaranZameenKhatajatSubKhatta (string RegisterHqDKhataId, string RegisterHaqdaranId, string KhataNo, string Taraf, string Patai, string TotalParts, string Kanal, string Maral, string Sarsai, string feet, string malia, string kefiat, string mozaid, string insertuserid, string InsertLoginName, string ParentKhattaId, string IntiqalId)
        {
            string spWithParam = "WEB_SP_INSERT_HaqdaranZameenKhatajatSubKhatta  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + RegisterHqDKhataId + "," + RegisterHaqdaranId + ",'" + KhataNo + "','" + Taraf + "','" + Patai + "'," + TotalParts + "," + Kanal + "," + Maral + "," + Sarsai + "," + feet + ",N'" + malia + "',N'" + kefiat + "'," + mozaid + "," + insertuserid + ",'" + InsertLoginName + "'," + ParentKhattaId + ", '" + IntiqalId + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string proc_Intiqal_Ishtirak_Khattajat(string intiqalid)
        {
            string spWithParam = "proc_Intiqal_Ishtirak_Khattajat  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + intiqalid;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string WEB_SP_INSERT_KhewatGroupFareeqein(string KhewatGroupFareeqId,string KhewatGroupId,string PersonId,string FardAreaPart,string fardkanal,string fardmarla,string fardsarsai,string fardfeet,string KhewatTypeId,string RegisterHaqkhataid,string InsertUserId,string Dar,string TotalDarPart,string PersonDarPart,string OfDarPart,string InsertLoginName,string FardPart_Bata)
        {
            string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqein   " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + KhewatGroupFareeqId + "'," + KhewatGroupId + "," + PersonId + ",'" + FardAreaPart + "'," + fardkanal + "," + fardmarla + "," + fardsarsai + "," + fardfeet + "," + KhewatTypeId + "," + RegisterHaqkhataid + "," + InsertUserId + "," + Dar + "," + TotalDarPart + "," + PersonDarPart + "," + OfDarPart + ",'" + InsertLoginName + "','" + FardPart_Bata + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string WEB_SP_INSERT_KhewatGroupFareeqeinWithRecStatus(string KhewatGroupFareeqId, string KhewatGroupId, string PersonId, string FardAreaPart, string fardkanal, string fardmarla, string fardsarsai, string fardfeet, string KhewatTypeId, string RegisterHaqkhataid, string InsertUserId, string InsertLoginName, string FardPart_Bata, string TransactionType, string RecStatus)
        {
            string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqeinWithRecStatus " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + KhewatGroupFareeqId + "'," + KhewatGroupId + "," + PersonId + ",'" + FardAreaPart + "'," + fardkanal + "," + fardmarla + "," + fardsarsai + "," + fardfeet + "," + KhewatTypeId + "," + RegisterHaqkhataid + "," + InsertUserId + ",'" + InsertLoginName + "','" + FardPart_Bata + "','" + TransactionType + "'," + RecStatus;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string WEB_SP_INSERT_KhewatGroupFareeqeinEdit(string KhewatGroupFareeqRecId, string KhewatGroupFareeqId, string KhewatGroupId, string PersonId, string PersonIdProp, string FardAreaPart, string FardAreaPartProp, string fardkanal, string fardkanalProp, string fardmarla, string fardmarlaProp, string fardsarsai, string fardsarsaiProp, string fardfeet, string fardfeetProp, string KhewatTypeId, string KhewatTypeIdProp, string RegisterHaqkhataid, string InsertUserId, string InsertLoginName, string FardPart_Bata, string FardPart_BataProp, string TransactionType, string SeqNo, string RHZ_ChangeId, string EditMode)
        {
            string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqeinEdit " + KhewatGroupFareeqRecId + "," + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + KhewatGroupFareeqId + "'," + KhewatGroupId + "," + PersonId + "," + PersonIdProp + ",'" + FardAreaPart + "','" + FardAreaPartProp + "'," + fardkanal + "," + fardkanalProp + "," + fardmarla + "," + fardmarlaProp + "," + fardsarsai + "," + fardsarsaiProp + "," + fardfeet + "," + fardfeetProp + "," + KhewatTypeId + "," + KhewatTypeIdProp + "," + RegisterHaqkhataid + "," + InsertUserId + ",'" + InsertLoginName + "','" + FardPart_Bata + "','" + FardPart_BataProp +"','" + TransactionType + "'," + SeqNo+","+RHZ_ChangeId+",'"+EditMode+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }


        public DataTable WEB_SP_DELETE_KhewatGroupFareeqein(string Kgfid)
        {
            string spWithParam = "WEB_SP_DELETE_KhewatGroupFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + Kgfid + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable DeleteKhatooniRegister(string KhatooniId)
        {
            string spWithParam = "WEB_SP_DELETE_KhatooniRegister  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + KhatooniId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public void DeleteRegisterHaqdaranKhattaByKhataId(string KhataId)
        {
            //DataContext.WEB_SP_DELETE_Intiqal_Intiqal_KhataJat(IntiqalKhataRecId);
            string spWithParam = "WEB_SP_DELETE_HaqdaranZameenKhatajat_NewKhataTaqseem " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhataId + "";
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
        }

        public string DeleteKhewatGroupFareeqEdite(string KhewatGroupFareeqRecId)
        {
            //DataContext.WEB_SP_DELETE_Intiqal_Intiqal_KhataJat(IntiqalKhataRecId);
            string spWithParam = "WEB_SP_DELETE_KhewatGroupFareeqeinEdite " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhewatGroupFareeqRecId + "";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
    }
}
