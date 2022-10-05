using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SDC_Application.DL;

namespace SDC_Application.BL
{
    class Persons
    {
        Database objdatabase = new Database();

        #region Save Inteqal Witness Method


        public string SaveInteqalWitness(string IntiqalWitnessId, string IntiqalId, string WitnessPersonId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName, string PersonId, string PersonName, string FatherName, string CNIC, string Gender, string MozaId, string Adress)
        {
            string SpwithPara = "WEB_SP_INSERT_Intiqal_Witness '" + IntiqalWitnessId + "'," + IntiqalId + "," + WitnessPersonId + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'," + PersonId + ",N'" + PersonName + "',N'" + FatherName + "','" + CNIC + "',N'" + Gender + "'," + MozaId + ",N'" + Adress + "'";
            return objdatabase.ExecInsertUpdateStoredProcedure(SpwithPara);

        }
        #endregion

        #region Save Inteqal Witness Method


        public string SaveInteqalAfradRegister(string PersonId, string PersonTypeId, string FamilyId, string QoamId, string FamilyHead, string FamilyLevel, string ParentId, string PersonName, string Relation, string Fathername, string MotherName, string Gender, string MozaId, string CNIC, string DateOfBirth, string Sakna, string Address, string PersonDied, string PersonCategoryId, string InsertUserId, string personfamilystatusid)
        {
            string SpwithPara = "WEB_SP_INSERT_AfradRegister " + PersonId + "," + PersonTypeId + "," + FamilyId + "," + QoamId + "," + FamilyHead + "," + FamilyLevel + "," + ParentId + ",N'" + PersonName + "',N'" + Relation + "',N'" + Fathername + "',N'" + MotherName + "',N'" + Gender + "'," + MozaId + "," + CNIC + "," + DateOfBirth + ",N'" + Sakna + "',N'" + Address + "'," + PersonDied + "," + PersonCategoryId + "," + InsertUserId + "," + personfamilystatusid + "";
            return objdatabase.ExecInsertUpdateStoredProcedure(SpwithPara);

        }
        #endregion


        public DataTable GetIntiqalWitnessList(string IntiqalId)
        {
            string spWithParam = "Proc_Get_Intiqal_Witness_List " + IntiqalId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetMozaParentsList(string MozaId, string familyId)
        {
            string spWithParam = "Proc_Get_Moza_Parents_List " + MozaId + ", " + familyId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetMozaFamiliesList(string MozaId)
        {
            string spWithParam = "Proc_Get_Moza_Families_List " + MozaId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetMozaAfradListAllTypes(string MozaId)
        {
            string spWithParam = "Proc_Get_Moza_AfradList_All_Types " + MozaId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetMozaAfradListByTypeId(string MozaId, string PersonFamilyStatusId)
        {
            string spWithParam = "Proc_Get_Moza_AfradList_By_TypeId " + MozaId + ", " + PersonFamilyStatusId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetPersonCategory(string TehsilId)
        {
            string spWithParam = "Proc_Get_ُPersonCategory " + TehsilId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetPersonCategoryList()
        {
            string spWithParam = "Proc_Get_PersonCategory_List ";
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetMozaList(string TehsilId)
        {
            string spWithParam = "Proc_Get_Moza_List "+TehsilId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetPersonChilds(string Personid)
        {
            string spWithParam = "proc_Get_PersonChilds " + Personid;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetQoam(string TehsilId)
        {
            string spWithParam = "Proc_Get_Qoam " + TehsilId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        //public DataTable GetFamilyLevel(string ParentId)
        //{
        //    string spWithParam = "Proc_Get_FamilyLevel " + ParentId;
        //    return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        //}

        public string GetFamilyLevel(string ParentId)
        {
            string spWithParam = "Proc_Get_FamilyLevel " + ParentId;
            return objdatabase.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable GetFamilyNo(string ParentId)
        {
            string spWithParam = "Proc_Get_FamilyNo " + ParentId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetFamilyPersonsList(string FamilyId)
        {
            string spWithParam = "Proc_Get_FamilyPersons_List " + FamilyId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetFamilyPersonsListByMozaId(string FamilyId, string MozaId)
        {
            string spWithParam = "Proc_Get_FamilyPersons_List_By_Moza " + FamilyId + ", " + MozaId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetCategoryByPersonId(string PersonId)
        {
            string spWithParam = "Proc_Get_Category_By_PersonId " + PersonId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetFardDetailByPersonId(string PersonId)
        {
            string spWithParam = "Proc_Get_FardDetail " + PersonId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }


        #region Record Delete Members

        public void DeleteAfradRegister(string PersonId)
        {
            string spWithParam = "WEB_SP_DELETE_AfradRegister " + PersonId;
            objdatabase.ExecUpdateStoredProcedureWithNoRet(spWithParam);
        }

        public void UpdateShajraStructure(string MozaId, string FamilyId)
        {
            string spWithParam = "pro_Set_Shajra_Seqno " + MozaId + "," + FamilyId;
            objdatabase.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            //return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }


        // ----- 
        public DataTable getAfradRegister(String fardTOSearch , String MozaID)
        {
            return objdatabase.fillDataTable("Proc_Get_Moza_Families_List " + MozaID);//(String.Format("SELECT * FROM AfradRegister where MozaID = '{0}'  and personName like N'%{1}%' and familyNo is not null ", MozaID, fardTOSearch));
        }

        public bool ChangeFamily(int PersonId , int FamilyId, int FamilyNo ,int ParentId , String MozaID)
        {

            objdatabase.ExecUpdateStoredProcedureWithNoRet(
                String.Format("UPDATE AfradRegister  SET FamilyNo = {0},FamilyId = {1},ParentId = {2} WHERE PersonId = {3} AND MozaId = {4}"
                 ,FamilyNo, FamilyId, ParentId, PersonId,MozaID
                )
                );

            return true;
        }

        public DataTable getDashBoard(int UserId)
        {
            return objdatabase.filldatatable_from_storedProcedure(String.Format("Proc_Get_Revenue_Dashboard_SDC {0}",UserId));
        }
        #endregion

    }
}
