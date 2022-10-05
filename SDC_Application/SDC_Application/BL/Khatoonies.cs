using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SDC_Application.DL;

namespace SDC_Application.BL
{
    class Khatoonies
    {
        Database dbobject = new Database();
        public DataTable Get_KhataJatbyMozaId(string MozaId, string registerId)
        {
            string spWithParam = "Proc_Get_Moza_Register_KhataJat " + MozaId + "," + registerId + "";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhataLockindDetailsByKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_Moza_Register_KhataJat_SDC_For_Locking_ByKhataId " +KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhewatGroupFareeqainLockindDetailsByKhataId(string KhataId, string isAllRecord)
        {
            string spWithParam = "Proc_Get_KhewatGroupFareeqain_By_KhataId_LockDetails " + KhataId+","+isAllRecord;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public void SaveKhewatGroupFareeqainLock(string KhewatGroupFareeqId, string LockDetails, string RecordLocked)
        {
            string spWithParam = "WEB_SP_Insert_KhewatGroupFareeq_Locking " + KhewatGroupFareeqId + ",N'" + LockDetails + "'," + RecordLocked;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);

        }
        public DataTable Get_Moza_HaqdaranRegisterNos(string MozaId)
        {
            string spWithParam = "Proc_Get_Moza_HaqdaranRegisterNos " + MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public DataTable Get_KhatoonisbyKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_Khatoonis " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhatooniNosListbyKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_KhatooniNos_List_By_KhataId " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhatooniDetailbyKhatooniId(string KhataId)
        {
            string spWithParam = "Proc_Get_KhatoonisDeatail_By_KhatooniId " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetMushteryanPreviousByKhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_MushtriFareeqein_Previous_By_KhatooniId " + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetKhatooniBayanByKhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_KhatooniKhewatGroupFareeqein_By_KhatooniId " + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetKhassrajatByKhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_Khatooni_KhassraArea_Detail " + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetKhewatFareeqainMeezan(string KhataId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqain_TotalHisa_ByKhataId " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetFardDetailsByKhataIdByTokenPurposeId(string KhataId, string PurposeId, string StartDate, string EndDate)
        {
            string spWithParam = "Proc_Get_SDC_FardDetail_By_Khata_By_Purpose " + KhataId+","+PurposeId+",'"+StartDate+"','"+EndDate+"'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable Get_Khatooni_BeahShud(string KhatooniId)
        {
            string spWithParam = "Proc_Get_Khatooni_BeahShud " + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }


        public DataTable Get_Moza_List(string TehsilId)
        {
            string spWithParam = "Proc_Get_Moza_List "+TehsilId ;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Get_KhewatFareeqeinGroup_By_KhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_KhatooniKhewatGroupFareeqein_By_KhatooniId " + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable Get_KhassrajatByMoza(string MozaId)
        {
            string spWithParam = "Proc_Get_Moza_Khassra_List " + MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        // Khassra Rgister Valuation 
        public DataTable GetKhassraRegisterValuationByMozaByYear(string MozaId, string Year)
        {
            string spWithParam = "Proc_Get_KhassraRegisterValuation_By_Moza_By_Year " + MozaId+",'"+Year+"'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        //public DataTable Get_KhewatFareeqeinGroup_By_KhatooniId(string KhatooniId)
        //{
        //    string spWithParam = "Proc_Get_KhatooniKhewatGroupFareeqein_By_KhatooniId " + KhatooniId;
        //    return dbobject.filldatatable_from_storedProcedure(spWithParam);

        //}
        public string SaveKhatooniKhewatGroupFareeqein(string KhatooniKhewatFareeqRecId, string KhewatGroupFareeqId, string RegisterHqDKhataId, string KhatooniId, string PersonId, string KhewatFareeq_Total_Hissa, string KhewatFareeq_Total_Kanal, string KhewatFareeq_Total_Marla, string KhewatFareeq_Total_Sarsai, string KhewatFareeq_Total_Feet, string KhewatFareeq_Sold_Hissa, string KhewatFareeq_Sold_Kanal, string KhewatFareeq_Sold_Marla, string KhewatFareeq_Sold_Sarsai, string KhewatFareeq_Sold_Feet, string InsertUserId, string InsertLoginName,string UpdateUserId  ,string UpdateLoginName )
        {
            string spWithParam = "WEB_SP_INSERT_KhatooniKhewatGroupFareeqein " + KhatooniKhewatFareeqRecId + "," + KhewatGroupFareeqId + "," + RegisterHqDKhataId + "," + KhatooniId+","+ PersonId +","+ KhewatFareeq_Total_Hissa +","+KhewatFareeq_Total_Kanal+","+KhewatFareeq_Total_Marla+","+KhewatFareeq_Total_Sarsai+","+KhewatFareeq_Total_Feet+","+KhewatFareeq_Sold_Hissa+","+KhewatFareeq_Sold_Kanal+","+KhewatFareeq_Sold_Marla+","+KhewatFareeq_Sold_Sarsai+","+KhewatFareeq_Sold_Feet+","+InsertUserId+",'"+InsertLoginName+"',"+UpdateUserId+",'"+UpdateLoginName+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public DataTable Get_MushtriFareeqein_By_KhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_MushtriFareeqein_By_KhatooniId " + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Get_MushtriFareeqein_By_Khatooni_All_Status(string KhatooniId)
        {
            string spWithParam = "Proc_Get_MushtriFareeqein_By_Khatooni_All_RecStatus " + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable MushteriFareeqByKhatooniIdPersonId(string KhatooniId, string PersonId)
        {

            string spWithParam = "Proc_Get_MushteriFareeqein_By_Khatooni_By_PersonId " + KhatooniId + "," + PersonId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public string UPDATE_SDC_khatooniregister_BeahShud(string KhatooniId, string KhatooniKashtkaranFullDetail_New, string NameBaya, string BeahShud, string Khatooni_Hissa, string Khatooni_Kanal, string Khatooni_Marla, string Khatooni_Sarsai, string Khatooni_Feet)
        {
            string spWithParam = "WEB_SP_UPDATE_SDC_khatooniregister_BeahShud " + KhatooniId + ",'" + KhatooniKashtkaranFullDetail_New + "',N'" + NameBaya + "'," + BeahShud + "," + Khatooni_Hissa + "," + Khatooni_Kanal + "," + Khatooni_Marla + "," + Khatooni_Sarsai + "," + Khatooni_Feet ;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string SaveMushtriFareeqein(string MushtriFareeqId, string KhatooniKhewatFareeqRecId, string TransactionType, string IntiqalId, string KhatooniId, string SeqNo, string PersonId, string MurthinId, string KhewatTypeId, string FardAreaPart, string FardPart_Bata, string Farad_Kanal, string Fard_Marla, string Fard_Sarsai, string Fard_Feet, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_MushtriFareeqein " + MushtriFareeqId + "," + KhatooniKhewatFareeqRecId + ",'" + TransactionType + "'," + IntiqalId + "," + KhatooniId + "," + SeqNo + "," + PersonId + "," + MurthinId + "," + KhewatTypeId+","+FardAreaPart+",'"+FardPart_Bata+"',"+Farad_Kanal+","+Fard_Marla+","+Fard_Sarsai+","+Fard_Feet+","+InsertUserId+",'"+InsertLoginName+"',"+UpdateUserId+",'"+UpdateLoginName+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        //public string DeleteKhewatGroupFareeqein(string KhewatGroupFareeqId)
        //{
        //    string spWithParam = "WEB_SP_DELETE_KhewatGroupFareeqein" + KhewatGroupFareeqId ;
        //    return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        //}
        public string DELETE_KhatooniKhewatGroupFareeqein(string KhatooniKhewatFareeqRecId)
        {
            string spWithParam = "WEB_SP_DELETE_KhatooniKhewatGroupFareeqein " + KhatooniKhewatFareeqRecId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string DELETE_MushtriFareeqein(string MushtriFareeqId)
        {
            string spWithParam = "WEB_SP_DELETE_MushtriFareeqein " + MushtriFareeqId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        // Khassra Valuation Insertion
        public string SaveKhassraValuation(string ValuationId, string MozaId, string KhassraDetailId, string KhassraId, string Year, string PlotTypeId, string Value, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegisterValuation " + ValuationId + "," +MozaId+ "," + KhassraDetailId + "," + KhassraId + ",'" + Year + "'," + PlotTypeId + ",'" + Value + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
    }
}
