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


        public string SaveInteqalWitness(string IntiqalWitnessId, string IntiqalId, string WitnessPersonId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName, string PersonId, string PersonName, string FatherName, string CNIC, string Gender, string MozaId, string Adress,string WitnessTypeId)
        {
            string SpwithPara = "WEB_SP_INSERT_Intiqal_Witness " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + IntiqalWitnessId + "'," + IntiqalId + "," + WitnessPersonId + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'," + PersonId + ",N'" + PersonName + "',N'" + FatherName + "','" + CNIC + "',N'" + Gender + "'," + MozaId + ",N'" + Adress + "'," + WitnessTypeId;
            return objdatabase.ExecInsertUpdateStoredProcedure(SpwithPara);

        }
        #endregion

        #region Save Inteqal Witness Method
        public string SaveInteqalAfradRegister(string PersonId, string PersonTypeId, string FamilyId, string QoamId, string FamilyHead, string FamilyLevel, string ParentId, string PersonName, string Relation, string Fathername, string MotherName, string Gender, string MozaId, string CNIC, string DateOfBirth, string Sakna, string Address, string PersonDied, string PersonCategoryId, string InsertUserId, string personfamilystatusid, string InserUserName, string SerialNo)
        {
            string SpwithPara = "WEB_SP_INSERT_AfradRegister_SDC " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + PersonId + "," + PersonTypeId + "," + FamilyId + "," + QoamId + "," + FamilyHead + "," + FamilyLevel + "," + ParentId + ",N'" + PersonName + "',N'" + Relation + "',N'" + Fathername + "',N'" + MotherName + "',N'" + Gender + "'," + MozaId + "," + CNIC + "," + DateOfBirth + ",N'" + Sakna + "',N'" + Address + "'," + PersonDied + "," + PersonCategoryId + "," + InsertUserId + "," + personfamilystatusid + ",'" + InserUserName + "'," + SerialNo;
            return objdatabase.ExecInsertUpdateStoredProcedure(SpwithPara);

        }
        #endregion

        #region Check for CNIC already Entered

        public string CheckCNICAlreadyEntered(string PersonId, String Mozaid, String CNIC)
        {
            string R_CNIC = "0";
            string spWithParam = "Proc_Self_Get_CNIC_From_AfradRegister " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + Mozaid + "," + CNIC + "," + PersonId;
            R_CNIC = objdatabase.ExecInsertUpdateStoredProcedure(spWithParam);
            return R_CNIC;
        }

        public string CheckCNICWitness(string  CNIC)
        {
            string R_CNIC = "0";
            string spWithParam = "Proc_Self_Get_No_of_Intiqal_CNIC_Witness  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + CNIC;
            R_CNIC = objdatabase.ExecInsertUpdateStoredProcedure(spWithParam);
            return R_CNIC;
        }


        #endregion

        public string CheckFardPersonFingerPrintsSelf(string TokenId)
        {
            string Rem = "0";
            //string spWithParam = "Proc_Self_Get_Fard_PersonFingerPrint_All_Captured " + TokenId;
            string spWithParam = "Proc_Self_Get_Fard_PersonFingerPrint_Captured  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId;
            Rem = objdatabase.ExecInsertUpdateStoredProcedure(spWithParam);
            return Rem;
        }


        public DataTable GetIntiqalWitnessList(string IntiqalId)
        {
            string spWithParam = "Proc_Get_Intiqal_Witness_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetMozaParentsList(string MozaId, string familyId)
        {
            string spWithParam = "Proc_Get_Moza_Parents_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ", " + familyId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetMozaFamiliesList(string MozaId)
        {
            string spWithParam = "Proc_Get_Moza_Families_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetMozaAfradListAllTypes(string MozaId)
        {
            string spWithParam = "Proc_Get_Moza_AfradList_All_Types  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetMozaAfradListByTypeId(string MozaId, string PersonFamilyStatusId)
        {
            string spWithParam = "Proc_Get_Moza_AfradList_By_TypeId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId + ", " + PersonFamilyStatusId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetPersonCategory(string TehsilId)
        {
            string spWithParam = "Proc_Get_PersonCategory " + TehsilId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetPersonCategoryList()
        {
            string spWithParam = "Proc_Get_PersonCategory_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetMozaList()
        {
            string spWithParam = "Proc_Get_Moza_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+SDC_Application.Classess.UsersManagments.SubSdcId.ToString() ;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetPersonChilds(string Personid)
        {
            string spWithParam = "proc_Get_PersonChilds " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + Personid;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetQoam(string TehsilId)
        {
            string spWithParam = "Proc_Get_Qoam  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        //public DataTable GetFamilyLevel(string ParentId)
        //{
        //    string spWithParam = "Proc_Get_FamilyLevel " + ParentId;
        //    return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        //}

        public string GetFamilyLevel(string ParentId)
        {
            string spWithParam = "Proc_Get_FamilyLevel " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + ParentId;
            return objdatabase.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string UpdatePersonCnic(string MozaId, string PersonId, string CNIC, string UserId, string isPassport, string PassportCountry)
        {
            string spWithParam = "WEB_SP_UPDATE_Person_CNIC " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId + "," + PersonId + ",'" + CNIC + "'," + UserId + "," + isPassport + ",N'" + PassportCountry+"'";
            return objdatabase.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable GetFamilyNo(string ParentId)
        {
            string spWithParam = "Proc_Get_FamilyNo  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + ParentId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetFamilyPersonsList(string FamilyId)
        {
            string spWithParam = "Proc_Get_FamilyPersons_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FamilyId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetFamilyPersonsListByMozaId(string FamilyId, string MozaId)
        {
            string spWithParam = "Proc_Get_FamilyPersons_List_By_Moza  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FamilyId + ", " + MozaId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetCategoryByPersonId(string PersonId)
        {
            string spWithParam = "Proc_Get_Category_By_PersonId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + PersonId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetFardDetailByPersonId(string PersonId)
        {
            string spWithParam = "Proc_Get_FardDetail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PersonId;
            return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }


        #region Record Delete Members

        public void DeleteAfradRegister(string PersonId)
        {
            string spWithParam = "WEB_SP_DELETE_AfradRegister  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PersonId;
            objdatabase.ExecUpdateStoredProcedureWithNoRet(spWithParam);
        }

        public void UpdateShajraStructure(string MozaId, string FamilyId)
        {
            string spWithParam = "pro_Set_Shajra_Seqno  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + FamilyId;
            objdatabase.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            //return objdatabase.filldatatable_from_storedProcedure(spWithParam);
        }


        // ----- 
        public DataTable getAfradRegister(String fardTOSearch , String MozaID)
        {
            return objdatabase.fillDataTable(String.Format("SELECT * FROM AfradRegister where MozaID = '{0}'  and personName like N'%{1}%' and familyNo is not null AND Tehsilid={2}", MozaID, fardTOSearch, SDC_Application.Classess.UsersManagments._Tehsilid));
        }

        public bool ChangeFamily(long PersonId , long FamilyId, int FamilyNo ,long ParentId , String MozaID)
        {

            objdatabase.ExecUpdateStoredProcedureWithNoRet(
                    String.Format("UPDATE AfradRegister  SET FamilyNo = {0},FamilyId = {1},ParentId = {2} WHERE PersonId = {3} AND MozaId = {4} and Tehsilid={5} "
                     ,FamilyNo, FamilyId, ParentId, PersonId,MozaID , SDC_Application.Classess.UsersManagments._Tehsilid
                    )
                );

            return true;
        }

        public DataTable getDashBoard(int UserId)
        {
            return objdatabase.filldatatable_from_storedProcedure(String.Format("Proc_Get_Revenue_Dashboard_SDC  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",{0}", UserId));
        }
        #endregion

    }
}
