using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SDC_Application.DL;
using System.Data.SqlClient;

namespace SDC_Application.BL
{
    class TaqseemNewKhataJatMin
    {
        DL.Database dbobject = new Database();
       // Proc_Get_Gaintax

            public DataTable Proc_Get_Gaintax(string personid)
        {
            string spWithParam = "Proc_Get_Gaintax " +personid+"";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable WEB_SP_DELETE_KhatooniRegister(string khatooniid)
        {
            string spWithParam = "WEB_SP_DELETE_KhatooniRegister " + khatooniid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable WEB_SP_DELETE_KhassraRegisterDetail_Direct(string khasradetailid)
        {
            string spWithParam = "WEB_SP_DELETE_KhassraRegisterDetail_Direct " + khasradetailid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public string WEB_SP_INSERT_KhassraRegistert(string KhassraId, string MozaId, string KhassraCode, string KhassraNo, string KhassraCreation_Date, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegister " + KhassraId + "," + MozaId + "," + KhassraCode + ",'" + KhassraNo + "','" + KhassraCreation_Date + "'," + InsertUserId + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string WEB_SP_INSERT_KhassraRegisterDetail(string KhassraDetailId,string KhassraId , string AreaTypeId ,string Kanal  ,string Marla,string Sarsai,string Feet ,string InsertUserId   ) 
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegisterDetail " + KhassraDetailId + "," + KhassraId + "," + AreaTypeId + "," + Kanal + "," + Marla + "," + Sarsai + "," + Feet + "," + InsertUserId + "";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string WEB_SP_INSERT_KhassraRegister_Intiqal_Taqseem(string khasraid,string khatoniid,string userid,string loginname)
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegister_Intiqal_Taqseem '" + khasraid + "'," + khatoniid + "," + userid + ",'" + loginname + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable Proc_Get_Max_Khatooni_No_By_Moza(string mozaid)
        {
            string spWithParam = "Proc_Get_Max_Khatooni_No_By_Moza " + mozaid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_Max_Khata_No_By_Moza(string mozaid)
        {
            string spWithParam = "Proc_Get_Max_Khata_No_By_Moza " + mozaid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public string WEB_SP_INSERT_KhatooniRegister(string KhatooniId, string KhatooniNo, string KhatooniKashtkaranFullDetail_New, string RegisterHqDKhataId, string Wasail_e_Abpashi, string KhatooniLagan,string insertuserid, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_KhatooniRegister " + KhatooniId + ",'" + KhatooniNo + "',N'" + KhatooniKashtkaranFullDetail_New + "'," + RegisterHqDKhataId + ",N'" + Wasail_e_Abpashi + "',N'" + KhatooniLagan + "'," + insertuserid + ",'" + InsertLoginName+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable Proc_Get_KhassraJatByIntiqalId(string khataid)
        {
            string spWithParam = "Proc_Get_KhassraJatByIntiqalId " + khataid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_KhatooniKhassraDetail(string Khatooniid)
        {
            string spWithParam = "Proc_Get_Khatooni_KhassraArea_Detail " + Khatooniid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_Khatoonis(string khataid)
        {
            string spWithParam = "Proc_Get_Khatoonis " + khataid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_Khatoonis_Intiqal_Taqseem_by_IntiqalId(string intiqalid)
        {
            string spWithParam = "Proc_Get_Khatoonis_Intiqal_Taqseem_by_IntiqalId " + intiqalid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_KhewatFareeqeinBy_KhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqeinByKhataId " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable Proc_Get_KhewatFareeqeinByKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_Taqseem_RegisterHqDKhataId(string RegisterHqDKhataId)
        {
            string spWithParam = "Proc_Get_Taqseem_RegisterHqDKhataId '"+RegisterHqDKhataId+"'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable proc_Get_Intiqal_Buyers_List_ByIntiqal(string IniqalId)
        {
            string spWithParam = "proc_Get_Intiqal_Buyers_List_ByIntiqal " + IniqalId + "";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Intiqal_Ishtrak_Mushtrian(string IniqalId)
        {
            string spWithParam = "Proc_Intiqal_Ishtrak_Mushtrian '" + IniqalId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public string SaveSubKhatooni(string KhatooniId, string ParentKhatooniId, string TotalParts, string Kanal, string Maral, string Sarsai, string feet, string IntiqalId, string KhatooniNo, string KhatooniKashtkaranFullDetail_New, string RegisterHqDKhataId, string Wasail_e_Abpashi, string KhatooniLagan, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_KhatooniRegisterSubKhatooni " + KhatooniId + "," + ParentKhatooniId + "," + TotalParts + "," + Kanal + "," + Maral + "," + Sarsai + "," + feet + "," + IntiqalId + ",'" + KhatooniNo + "',N'" + KhatooniKashtkaranFullDetail_New + "'," + RegisterHqDKhataId + ",N'" + Wasail_e_Abpashi + "',N'" + KhatooniLagan + "', " + InsertUserId + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string WEB_SP_INSERT_HaqdaranZameenKhatajatSubKhatta (string RegisterHqDKhataId, string RegisterHaqdaranId, string KhataNo, string Taraf, string Patai, string TotalParts, string Kanal, string Maral, string Sarsai, string feet, string malia, string kefiat, string mozaid, string insertuserid, string InsertLoginName, string ParentKhattaId, string IntiqalId)
        {
            string spWithParam = "WEB_SP_INSERT_HaqdaranZameenKhatajatSubKhatta " + RegisterHqDKhataId + "," + RegisterHaqdaranId + ",'" + KhataNo + "','" + Taraf + "','" + Patai + "'," + TotalParts + "," + Kanal + "," + Maral + "," + Sarsai + "," + feet + ",'" + malia + "','" + kefiat + "'," + mozaid + "," + insertuserid + ",'" + InsertLoginName + "'," + ParentKhattaId + ", '" + IntiqalId + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string proc_Intiqal_Ishtirak_Khattajat(string intiqalid)
        {
            string spWithParam = "proc_Intiqal_Ishtirak_Khattajat " + intiqalid;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string WEB_SP_INSERT_KhewatGroupFareeqein(string KhewatGroupFareeqId,string KhewatGroupId,string PersonId,string FardAreaPart,string fardkanal,string fardmarla,string fardsarsai,string fardfeet,string KhewatTypeId,string RegisterHaqkhataid,string InsertUserId,string Dar,string TotalDarPart,string PersonDarPart,string OfDarPart,string InsertLoginName,string FardPart_Bata)
        {
            string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqein  '"+ KhewatGroupFareeqId + "'," + KhewatGroupId + "," + PersonId + ",'" + FardAreaPart + "'," + fardkanal + "," + fardmarla + "," + fardsarsai + "," + fardfeet + "," + KhewatTypeId + "," + RegisterHaqkhataid + "," + InsertUserId + "," + Dar + "," + TotalDarPart + "," + PersonDarPart + "," + OfDarPart + ",'" + InsertLoginName+"','"+FardPart_Bata+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }


        public DataTable WEB_SP_DELETE_KhewatGroupFareeqein(string Kgfid)
        {
            string spWithParam = "WEB_SP_DELETE_KhewatGroupFareeqein '" + Kgfid + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable DeleteKhatooniRegister(string KhatooniId)
        {
            string spWithParam = "WEB_SP_DELETE_KhatooniRegister '" + KhatooniId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
    }
}
