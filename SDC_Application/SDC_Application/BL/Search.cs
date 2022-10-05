using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.DL;

namespace SDC_Application.BL
{
    
    class Search
    {
        #region Class Variables

        Database ojbdb = new Database();


        #endregion

        #region Get Searched Afrad List By Moza By Person Name

        //public DataTable GetSearchedAfradList_Khanakasht(string MozaId, string PersonName)
        //{
        //    //DataTable afradList = new DataTable();
        //    string spWithParam = "Proc_Get_Person_KhataJats_KhanaKasht " + MozaId + ", 1,N'" + PersonName + "'";
        //    return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        //    //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        //}

        public DataTable GetSearchedAfradList( string MozaId,string PersonName)
        {
            //DataTable afradList = new DataTable();
            string spWithParam = "Proc_Get_SDC_Searched_Afrad_List " + MozaId + ", 1,N'" + PersonName+"'";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        #endregion

        #region Get Searched Afrad List By Moza By Person Name

        public DataTable GetPersonFamilyMembers(string FamilyId)
        {
           // DataTable familyList = new DataTable();
            string spWithParam = "Proc_Get_FamilyPersons_List "+ FamilyId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }

        #endregion

        #region Get Malik Khattajat in Moza

        public DataTable GetMalikKhattas(string PersonId, string MozaId)
        {
            //DataTable PersonKhattas = new DataTable();
            string spWithParam = "Proc_Get_Person_KhataJats_WithLocks " + MozaId + "," + PersonId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        public DataTable GetMalikKhattasPersonDetails(string FGID)
        {
            //DataTable PersonKhattas = new DataTable();
            string spWithParam = "Proc_Get_SDC_FardKhatasDetail "+FGID+"";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            //objauto.value("Proc_Get_SDC_TokenList_For_PaymentVoucher", "TokenId", txtTokenID);
        }
        #endregion

        #region Get FB Searched AfradList by Moza
        public DataTable GetSearchedAfardListFBShajra(string MozaId, string PersonName)
        {
            string spWithParms = "Proc_Get_Searched_Afrad_List_Fb_Shajra_FatherName " + MozaId + ",N'" + PersonName + "'";
            return ojbdb.filldatatable_from_storedProcedure(spWithParms);
        }
        #endregion

        #region Get Search Afrad list
        public DataTable GetSearchAfradList(string MozaId, string Type, string PersonName)
        {
            string spWithParam = "Proc_Get_Searched_Afrad_List " + MozaId + "," + Type+",N'"+PersonName+"'";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }
        #endregion

        #region Get Search Afrad list with Logs
        public DataTable GetSearchAfradListWithLogs(string MozaId, string Type, string PersonName)
        {
            string spWithParam = "Proc_Get_Searched_Afrad_List_With_Logs " + MozaId + "," + Type + ",N'" + PersonName + "'";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }
        #endregion

        #region Get Tokens Details by Person CNIC
        public DataTable GetTokenDetailByPersonCNIC(string PersonCNIC)
        {
            string spWithParam = "Proc_Get_SDC_TokenDetail_By_Person_CNIC '" + PersonCNIC + "'";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }
        #endregion

        #region Get Afard List by Khata No (Taken from Intiqal BL Class)
        public DataTable KhewatGroupFareeqainAll(string KhataId)
            {
            string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata_All_RecStatus " + KhataId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            }
        #endregion

        #region Get Khewat Fareeqain Group By Khatta (Taken from Misal BL Class, Need to discuss this)
        public DataTable GetKhewatFareeqeinGroupByKhatta(string KhattaId)
            {
            string spWithParms = "Proc_Get_KhewatFareeqeinGroup_By_Khata " + KhattaId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParms);
            }
        #endregion

    }
}
