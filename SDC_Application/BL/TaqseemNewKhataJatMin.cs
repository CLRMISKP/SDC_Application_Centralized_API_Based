﻿using System;
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
            string spWithParam = "Proc_Get_Gaintax " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + personid + "";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
            public DataTable Proc_Self_Get_Khatoonis(string khataid)
            {
                string spWithParam = "Proc_Self_Get_Khatoonis " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + khataid;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

            }
            public DataTable Proc_Self_Get_Khatoonis_Intiqal_Taqseem_by_KhataId(string KhataId)
            {
                string spWithParam = "Proc_Self_Get_Khatoonis_Intiqal_Taqseem_by_KhataId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

            }
            public DataTable Proc_Self_Get_KhewatFareeqeinByKhataId(string KhataId)
            {
                string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata_All_RecStatus " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

            }
            public DataTable Zerikar_Proc_Self_Get_KhewatFareeqeinByKhataId(string KhataId)
            {
                string spWithParam = "Zerikar_Proc_Get_KhewatFareeqeinGroup_By_Khata "  + KhataId;
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
        public string WEB_SP_INSERT_KhassraRegistert(string KhassraId, string MozaId, string KhassraCode, string KhassraNo, string KhassraCreation_Date, string InsertUserId, string InsertLoginName, string KhatooniId)
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegister  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhassraId + "," + MozaId + "," + KhassraCode + ",N'" + KhassraNo + "','" + KhassraCreation_Date + "'," + InsertUserId + ",'" + InsertLoginName + "',"+KhatooniId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string WEB_SP_INSERT_KhassraRegisterDetail(string KhassraDetailId,string KhassraId , string AreaTypeId ,string Kanal  ,string Marla,string Sarsai,string Feet ,string InsertUserId   ) 
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegisterDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhassraDetailId + "," + KhassraId + "," + AreaTypeId + "," + Kanal + "," + Marla + "," + Sarsai + "," + Feet + "," + InsertUserId + "";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
        public string SaveAutoKhatooniesInKhassraIntiqal(string IntiqalKhataRecId, string RegisterHqDKhataIdNew, string KhataNoNew, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_Insert_Khatooni_New_Khata_Khassra_Intiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId + "," + RegisterHqDKhataIdNew + ",'" + KhataNoNew+ "'," + InsertUserId + ",'"+InsertLoginName+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string WEB_SP_INSERT_KhassraRegister_Intiqal_Taqseem(string khasraid,string khatoniid,string userid,string loginname)
        {
            string spWithParam = "WEB_SP_INSERT_KhassraRegister_Intiqal_Taqseem  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + khasraid + "'," + khatoniid + "," + userid + ",'" + loginname + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

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

        public DataTable Proc_Get_KhassraJatByIntiqalId(string khataid)
        {
            string spWithParam = "Proc_Get_KhassraJatByIntiqalId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + khataid;
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
        public DataTable Proc_Get_Khatoonis(string khataid)
        {
            string spWithParam = "Proc_Get_Khatoonis  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + khataid;
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
                         
        public DataTable Proc_Get_KhewatFareeqeinByKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public string WEB_SP_Update_MushtriFareeqein(string MushtriFareeqId, string FardAreaPart, string fardkanal, string fardmarla, string fardsarsai, string fardfeet, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_Self_SP_Update_MushtriFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + MushtriFareeqId + "'," + FardAreaPart + "," + fardkanal + ",'" + fardmarla + "'," + fardsarsai + "," + fardfeet + "," + InsertUserId + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable WEB_SP_DELETE_MushtriGroupFareeqein(string mfId, string KhatooniId, string All)
        {

            string spWithParam = "WEB_Self_SP_DELETE_MushtriFareeqein '" + mfId + "' ," + KhatooniId + "," + All;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_MushtriFareeqeinBy_KhatooniId_Taqseem(string KhatooniId)
        {
            string spWithParam = "Proc_Get_MushtriFareeqein_ByKhatooniId_For_Taqseem " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public string WEB_SP_INSERT_KhewatGroupFareeqein_From_Khatooni_Taqseem(string KhewatGroupFareeqId, string KhewatGroupId, string PersonId, string FardAreaPart, string fardkanal, string fardmarla, string fardsarsai, string fardfeet, string KhewatTypeId, string RegisterHaqkhataid, string InsertUserId, string Dar, string TotalDarPart, string PersonDarPart, string OfDarPart, string InsertLoginName, string FardPart_Bata)
        {
            string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqein_From_Khatooni_Taqseem  '" + KhewatGroupFareeqId + "'," + KhewatGroupId + "," + PersonId + ",'" + FardAreaPart + "'," + fardkanal + "," + fardmarla + "," + fardsarsai + "," + fardfeet + "," + KhewatTypeId + "," + RegisterHaqkhataid + "," + InsertUserId + "," + Dar + "," + TotalDarPart + "," + PersonDarPart + "," + OfDarPart + ",'" + InsertLoginName + "','" + FardPart_Bata + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
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
        public string WEB_Self_SP_INSERT_KhatooniRegister_Taqseem(string KhatooniId, string KhatooniNo, string KhatooniKashtkaranFullDetail_New, string RegisterHqDKhataId, string Wasail_e_Abpashi, string KhatooniLagan, float Hissa, int Kanal, int Marla, float Sarsai, float Feet, string insertuserid, string InsertLoginName)
        {
            string spWithParam = "WEB_Self_SP_INSERT_KhatooniRegister_Taqseem " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId + ",'" + KhatooniNo + "',N'" + KhatooniKashtkaranFullDetail_New + "'," + RegisterHqDKhataId + ",N'" + Wasail_e_Abpashi + "',N'" + KhatooniLagan + "'," + Hissa + "," + Kanal + "," + Marla + "," + Sarsai + "," + Feet + "," + insertuserid + ",'" + InsertLoginName + "'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable WEB_SP_DELETE_KhewatGroupFareeqein(string Kgfid)
        {
            string spWithParam = "WEB_SP_DELETE_KhewatGroupFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + Kgfid + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetKhataHissasArea(string KhataId)
        {
            string spWithParam = "select TotalParts, Khata_Kanal, Khata_Marla,Khata_Sarsai, Khata_Feet from HaqdaranZameenKhatajat where RegisterHqDKhataId=  " + KhataId;
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
        public DataTable WEB_SP_DELETE_KhassraRegister_Taqseem(string KhatooniId)
        {
            string spWithParam = "WEB_SP_DELETE_KhassraRegister_Taqseem " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhatooniId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable WEB_SP_DELETE_KhatooniRegister_Taqseem(string khatooniid, string KhataId, string all)
        {
            string spWithParam = "WEB_SP_DELETE_KhatooniRegister_Taqseem " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + khatooniid + "," + KhataId + "," + all;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable WEB_SP_DELETE_KhewatGroupFareeqein_Taqseem(string Kgfid, string KhataId, string All)
        {
            string spWithParam = "WEB_SP_DELETE_KhewatGroupFareeqein_Taqseem "+Classess.UsersManagments._Tehsilid.ToString()+", '" + Kgfid + "' ," + KhataId + "," + All;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
    }
}
