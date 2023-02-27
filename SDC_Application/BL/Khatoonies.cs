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
            string spWithParam = "Proc_Get_Moza_Register_KhataJat " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId + "," + registerId + "";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhataLockindDetailsByKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_Moza_Register_KhataJat_SDC_For_Locking_ByKhataId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhewatGroupFareeqainLockindDetailsByKhataId(string KhataId, string isAllRecord)
        {
            string spWithParam = "Proc_Get_KhewatGroupFareeqain_By_KhataId_LockDetails  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId + "," + isAllRecord;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public void SaveKhewatGroupFareeqainLock(string KhewatGroupFareeqId, string LockDetails, string RecordLocked)
        {
            string spWithParam = "WEB_SP_Insert_KhewatGroupFareeq_Locking  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhewatGroupFareeqId + ",N'" + LockDetails + "'," + RecordLocked;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);

        }
        public DataTable Proc_Self_Get_Khata_Malkan_Area_Hissa(string KhataId)
        {
            string spWithParam = "Proc_Self_Get_Khata_Malkan_Area_Hissa " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Self_Get_Khatooni_Mushtryan_Area_Hissa(string KhatooniId)
        {
            string spWithParam = "Proc_Self_Get_Khatooni_Mushtryan_Area_Hissa " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public string DELETE_MushtriFareeqein_By_KhatooniId(string KhatooniId)
        {
            string spWithParam = "WEB_Self_SP_DELETE_All_MushtriFareeqein " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public DataTable Get_Moza_HaqdaranRegisterNos(string MozaId)
        {
            string spWithParam = "Proc_Get_Moza_HaqdaranRegisterNos  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public DataTable Get_KhatoonisbyKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhatooniNosListbyKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhatooniNosListbyKhataIdforRhzEdit(string KhataId)
        {
            string spWithParam = "Proc_Get_KhatoonisForEdit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhatooniEditedByKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_Khatoonis_Edit  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhatooniDetailbyKhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_KhatoonisDeatail_By_KhatooniId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetMushteryanPreviousByKhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_MushtriFareeqein_Previous_By_KhatooniId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetKhatooniBayanByKhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_KhatooniKhewatGroupFareeqein_By_KhatooniId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetKhassrajatByKhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_Khatooni_KhassraArea_Detail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhassraListByKhatooni(string KhatooniId)
        {
            string spWithParam = "Proc_Get_Khatooni_Khasra_List  "  + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetKhewatFareeqainMeezan(string KhataId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqain_TotalHisa_ByKhataId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetFardDetailsByKhataIdByTokenPurposeId(string KhataId, string PurposeId, string StartDate, string EndDate)
        {
            string spWithParam = "Proc_Get_SDC_FardDetail_By_Khata_By_Purpose  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId + "," + PurposeId + ",'" + StartDate + "','" + EndDate + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable Get_Khatooni_BeahShud(string KhatooniId)
        {
            string spWithParam = "Proc_Get_Khatooni_BeahShud  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }


        public DataTable Get_Moza_List()
        {
            string spWithParam = "Proc_Get_Moza_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Get_KhewatFareeqeinGroup_By_KhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_KhatooniKhewatGroupFareeqein_By_KhatooniId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable Get_KhassrajatByMoza(string MozaId)
        {
            string spWithParam = "Proc_Get_Moza_Khassra_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        // Khassra Rgister Valuation 
        public DataTable GetKhassraRegisterValuationByMozaByYear(string MozaId, string Year)
        {// --NOT_IMPLEMENTED_ not in db
            string spWithParam = "Proc_Get_KhassraRegisterValuation_By_Moza_By_Year  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ",'" + Year + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        //public DataTable Get_KhewatFareeqeinGroup_By_KhatooniId(string KhatooniId)
        //{
        //    string spWithParam = "Proc_Get_KhatooniKhewatGroupFareeqein_By_KhatooniId " + KhatooniId;
        //    return dbobject.filldatatable_from_storedProcedure(spWithParam);

        //}
        public string SaveKhatooniKhewatGroupFareeqein(string KhatooniKhewatFareeqRecId, string KhewatGroupFareeqId, string RegisterHqDKhataId, string KhatooniId, string PersonId, string KhewatFareeq_Total_Hissa, string KhewatFareeq_Total_Kanal, string KhewatFareeq_Total_Marla, string KhewatFareeq_Total_Sarsai, string KhewatFareeq_Total_Feet, string KhewatFareeq_Sold_Hissa, string KhewatFareeq_Sold_Kanal, string KhewatFareeq_Sold_Marla, string KhewatFareeq_Sold_Sarsai, string KhewatFareeq_Sold_Feet, string InsertUserId, string InsertLoginName,string UpdateUserId  ,string UpdateLoginName )
        {
            string spWithParam = "WEB_SP_INSERT_KhatooniKhewatGroupFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniKhewatFareeqRecId + "," + KhewatGroupFareeqId + "," + RegisterHqDKhataId + "," + KhatooniId + "," + PersonId + "," + KhewatFareeq_Total_Hissa + "," + KhewatFareeq_Total_Kanal + "," + KhewatFareeq_Total_Marla + "," + KhewatFareeq_Total_Sarsai + "," + KhewatFareeq_Total_Feet + "," + KhewatFareeq_Sold_Hissa + "," + KhewatFareeq_Sold_Kanal + "," + KhewatFareeq_Sold_Marla + "," + KhewatFareeq_Sold_Sarsai + "," + KhewatFareeq_Sold_Feet + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public DataTable Get_MushtriFareeqein_By_KhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Get_MushtriFareeqein_By_KhatooniId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable Get_Self_MushtriFareeqein_By_KhatooniId(string KhatooniId)
        {
            string spWithParam = "Proc_Self_Get_MushtriFareeqein_By_KhatooniId " + KhatooniId;// --NOT_IMPLEMENTED_ not in db
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Get_MushtriFareeqein_By_Khatooni_All_Status(string KhatooniId)
        {
            string spWithParam = "Proc_Get_MushtriFareeqein_By_Khatooni_All_RecStatus  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable MushteriFareeqByKhatooniIdPersonId(string KhatooniId, string PersonId)
        {

            string spWithParam = "Proc_Get_MushteriFareeqein_By_Khatooni_By_PersonId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId + "," + PersonId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public string UPDATE_SDC_khatooniregister_BeahShud(string KhatooniId, string KhatooniKashtkaranFullDetail_New, string NameBaya, string BeahShud, string Khatooni_Hissa, string Khatooni_Kanal, string Khatooni_Marla, string Khatooni_Sarsai, string Khatooni_Feet)
        {
            string spWithParam = "WEB_SP_UPDATE_SDC_khatooniregister_BeahShud  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId + ",'" + KhatooniKashtkaranFullDetail_New + "',N'" + NameBaya + "'," + BeahShud + "," + Khatooni_Hissa + "," + Khatooni_Kanal + "," + Khatooni_Marla + "," + Khatooni_Sarsai + "," + Khatooni_Feet;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string SaveMushtriFareeqein(string MushtriFareeqId, string KhatooniKhewatFareeqRecId, string TransactionType, string IntiqalId, string KhatooniId, string SeqNo, string PersonId, string MurthinId, string KhewatTypeId, string FardAreaPart, string FardPart_Bata, string Farad_Kanal, string Fard_Marla, string Fard_Sarsai, string Fard_Feet, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_MushtriFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() 
            +"," + MushtriFareeqId + "," + KhatooniKhewatFareeqRecId + ",'" + TransactionType + "'," + IntiqalId + "," + KhatooniId + "," + SeqNo + "," + PersonId + "," + MurthinId + "," + KhewatTypeId + "," + FardAreaPart + ",'" + FardPart_Bata + "'," + Farad_Kanal + "," + Fard_Marla + "," + Fard_Sarsai + "," + Fard_Feet + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        //public string DeleteKhewatGroupFareeqein(string KhewatGroupFareeqId)
        //{
        //    string spWithParam = "WEB_SP_DELETE_KhewatGroupFareeqein" + KhewatGroupFareeqId ;
        //    return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        //}
        public string DELETE_KhatooniKhewatGroupFareeqein(string KhatooniKhewatFareeqRecId)
        {
            string spWithParam = "WEB_SP_DELETE_KhatooniKhewatGroupFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniKhewatFareeqRecId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string DELETE_MushtriFareeqein(string MushtriFareeqId)
        {
            string spWithParam = "WEB_SP_DELETE_MushtriFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MushtriFareeqId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        // Khassra Valuation Insertion
        public string SaveKhassraValuation(string ValuationId, string MozaId, string KhassraDetailId, string KhassraId, string Year, string PlotTypeId, string Value, string InsertUserId, string InsertLoginName)
        {// --NOT_IMPLEMENTED_ not in db
            string spWithParam = "WEB_SP_INSERT_KhassraRegisterValuation " + ValuationId + "," +MozaId+ "," + KhassraDetailId + "," + KhassraId + ",'" + Year + "'," + PlotTypeId + ",'" + Value + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
    }
}
