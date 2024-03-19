using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SDC_Application.DL;
using System.Data.SqlClient;

namespace SDC_Application.BL
{
    class Intiqal
    {
        DL.Database dbobject=new Database();

        #region Get Intiqal list Pending By Khata

        public DataTable GetIntiqalZeretajwizPendingByKhata(string KhataId)
        {
            string spWithParam = "Proc_Get_Intiqal_Zeretajwiz_Pending_By_Khatta " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public DataTable GetSelfCamFingerImage(string IntiqalId)
        {
            string spWithParam = "Proc_Self_Get_Intiqal_PersonBothPics " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetAllIntiqalByPersonId(string PersonId)
        {
            string spWithParam = "Proc_Get_Person_Intiqalat_All " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PersonId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public DataTable GetIntiqalPenginKharijByKhata(string KhataId)
        {
            string spWithParam = "Proc_Get_Intiqal_PendingKharij_By_Khatta " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetIntiqalAmalDaramadShodaByKhata(string KhataId)
        {
            string spWithParam = "Proc_Get_Intiqal_AmaldaramadShoda_By_Khatta " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetKhataNoByChildKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_Khata_By_Child_KhataId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetKhewatFareeqeinGroupByKhataPrevious(string KhataId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata_Previous " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        #endregion

        #region Inteqal Repository Members

        public DataTable Proc_Get_KhassaAreaByKhatooniId(string khatooniid)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "Proc_Get_KhassaAreaByKhatooniId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + khatooniid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public void DeleteIntiqalWitness(string IntiqalWitnessId)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "WEB_SP_DELETE_Intiqal_Witness  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalWitnessId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);

        }

        public DataTable SearchKhassraByKhassraNo( string MozaId, string KhassraNo)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "Proc_Get_Search_Khassra_ByKhassraNo_SDC " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhassraNo + "," + MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_KhassrasTotalArea_By_KhataId(string khataid)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "Proc_Get_KhassrasTotalArea_By_KhataId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + khataid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_Searched_Afrad_With_Family_Head(string Mozaid,string personame)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "Proc_Get_Searched_Afrad_With_Family_Head " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + Mozaid + ",N'" + personame + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
         public DataTable GetSearchedPersonListforAllMouzas(string PersonName,string FatherName)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "Proc_Get_SearchPersonslistforAllMozas " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString()+","+Classess.UsersManagments.SubSdcId.ToString() + ",N'" + PersonName + "',N'" + FatherName + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable DeltefromRequiredDucoments(string IntiqalDOcId, string IntiqalID,string SeqNo)
        {
            string spWithParam = "WEB_SP_DELETE_Intiqal_DucomentsRequired " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalDOcId + "','" + IntiqalID + "','" + SeqNo + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetCamFingerImage(string IntiqalId,string PersonId)
        {
            string spWithParam = "Proc_Get_Intiqal_PersonBothPics " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalId + "','" + PersonId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public string DeleteIntiqalPersonSnaps(string Personid, string IntiqalId, string UserId)
        {
            string spWithParam = "WEB_Self_SP_DELETE_Intiqal_PersonSnaps " + Personid + "," + IntiqalId + "," + UserId;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public DataTable GetFingerImageSelf(string tokenId, string PersonId)
        {
            string spWithParam = "Proc_Self_Get_Fard_PersonFingerPrint " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + tokenId + "','" + PersonId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetInsetedDocIamges(string IntiqalDocRecId)
        {
            string spWithParam = "Proc_Get_Intiqal_DocumentImages " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalDocRecId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetKhataIamges(string KhataId)
        {
            string spWithParam = "Proc_Self_Get_SDC_StayOrder " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + KhataId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetCancelFardIamges(string TokenId)
        {
            string spWithParam = "Proc_Self_Get_CancelFard_Images " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetMisalIamges(string MisalId)
        {
            string spWithParam = "Proc_Self_Get_Misal_Images " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MisalId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetIntiqalDocuments_RequiredforScanning(string IntiqalId)
        {
            string spWithParam = "proc_Get_Intiqal_DocumentsRequired " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
            public DataTable GetIntiqalBankChallanByIntiqalId(string IntiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_BankChallan_List_By_IntiqalId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
           
            }

            public DataTable GetIntiqalBankChallanSinSaveintiqalMaingleByChallanId(string ChallanId)
            {
                string spWithParam = "proc_Get_Intiqal_BankChallan_Single " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + ChallanId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalBuyersByIntiqalKhataRecId(string IntiqalKhataRecId, string IntiqalKhatooniRecid, string Malkiat)
            {
                string spWithParam = "proc_Get_Intiqal_Buyers " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + " "; 
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalBuyersByIntiqalKhataRecIdKK(string IntiqalKhataRecId)
            {
                string spWithParam = "proc_Self_Get_Intiqal_Buyers_KK " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalBuyersByKhataRecordId(string IntiqalKhataRecId, string IntiqalKhatooniRecid, string Malkiat)
            {
                string spWithParam = "proc_Get_Intiqal_Buyers_List_ByKhata " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + " "; 
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetIntiqalBuyersAmaldaramad(string IntiqalKhataRecId, string IntiqalKhatooniRecid, string Malkiat)
            {
                string spWithParam = "proc_Get_Intiqal_Buyers_List_Amaldaramad " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + " ";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalBuyersAmaldaramadKK(string IntiqalKhataRecId)
            {
                string spWithParam = "proc_Self_Get_Intiqal_Buyers_List_Amaldaramad_KK " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalSellersDependency(string IntiqalKhataId, string IntiqalKhataRecId, string IntiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_Sellers_Dependecy_ByKhata " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataId + "," + IntiqalKhataRecId + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable Proc_Get_Intiqal_TehsilDar_Report(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_TehsilDar_Report " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable Proc_Get_Intiqal_Roznamcha_Report(string IntiqalId)
            {
                string spWithParam = "Proc_Self_Get_Intiqal_Roznamcha_Report " + IntiqalId; //--NOT_IMPLEMENTED_missing
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            //public DataTable Proc_Get_Intiqal_Roznamcha_Report_Detail(string IntiqalId)
            //{
            //    string spWithParam = "Proc_Self_Get_Intiqal_Roznamcha_Detail " + IntiqalId;
            //    return dbobject.filldatatable_from_storedProcedure(spWithParam);
            //}

            public DataTable Proc_Get_Intiqal_Girdawar_Report(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_Girdawar_Report " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetIntiqalFeeListByIntiqalId(string IntiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_Fees_List_By_IntiqalId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable DeleteMinKhasra(string IntiqalMinKhassraRecId)
            {
                string spWithParam = " WEB_SP_DELETE_Intiqal_Min_Khassra " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinKhassraRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable DeleteMinFareeq(string IntiqalMinFareeq)
            {
                string spWithParam = " WEB_SP_DELETE_Intiqal_Min_Fareeq " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinFareeq;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetIntiqalFeesSingleByFeesId(string FeesId)
            {
                string spWithParam = "proc_Get_Intiqal_Fees_Single " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FeesId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

            }

            public DataTable GetIntiqalFeesTypes()
            {
                string spWithParam = "proc_Intiqal_FeeTypes_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalInitiationList()
            {
                string spWithParam = "proc_Intiqal_Initiation_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalKhataJaatListByIntiqalId(string IntiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_KhataJat_List_By_IntiqalId_With_Khata_Amal " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

           

            public DataTable GetintiqalMainByIntiqalId(string IntiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_Main_SDC " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalMainByIntiqalIdMozaId(string MozaId, string IntiqalNo)
            {
               // string spWithParam = "proc_Get_Intiqal_Main_By_MozaId_By_IntiqalNo_SDC " + MozaId + ", " + IntiqalNo +"";
                string spWithParam = "proc_Self_Get_Intiqal_Main_By_MozaId_By_IntiqalNo_SDC " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ", " + IntiqalNo + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public String GetRegistryIntiqalKhataCheck(string MozaId, string IntiqalNo)
            {
                string spWithParam = "proc_Self_Get_RegistryIntiqal_Khat_Check  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ", " + IntiqalNo + "";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public String GetIntiqalSellerBuyerDependencyByKhata(string IntiqalId, string IntiqalKhataRecId)
            {
                string spWithParam = "Proc_Intiqal_Revert_Sellers_Buyers_Dependency_Check_By_Khata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ", " + IntiqalKhataRecId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public String GetIntiqalatByKhewatGroupFareeqId(string KhewatGroupFareeqId)
            {
                string spWithParam = "Proc_Get_Intiqal_by_KhewatGroupFareeqId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhewatGroupFareeqId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public String GetPersonIdByKhewatgroupFareeqId(string KhewatGroupFareeqId)
            {
                string spWithParam = "proc_Self_Get_PersonId_By_KhewatGroupFareeqId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhewatGroupFareeqId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public String GetPersonIdByMushtriFareeqId(string MushtriFareeqId)
            {
                string spWithParam = "proc_Self_Get_PersonId_By_MushtriFareeqId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MushtriFareeqId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public DataTable GetintiqalMainListByMozaId(string MozaId)
            {
                string spWithParam = "proc_Get_Intiqal_Main_By_MozaId_SDC " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId; 
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalNoListByMozaId(string MozaId)
            {
                string spWithParam = "proc_Get_IntiqalNo_List_By_MozaId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetTransactionalTokenNoListByDate(int MozaId,string dateToken)
            {
                string spWithParam = "proc_Self_Get_TokenNo_List_By_Date_Transactional " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId + ",'" + dateToken + "'";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalMainListByMozaId(string MozaId, string IntiqalNo)
            {
                string spWithParam = "proc_Get_Intiqal_Main_By_MozaId_By_IntiqalNo_SDC  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + IntiqalNo; 
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetintiqalSellersBySellerRecId(string SellerRecId)
            {
                string spWithParam = "proc_Get_Intiqal_Sellers  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + SellerRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

                            }

            //fill grid on load ,on save on delete on update in frm intiqalRegister
            public DataTable GetintiqalSellersListByKhataRecId(string IntiqalKhataRecId, string IntiqalKhatooniRecid, string Malkiat)
            {
                //string spWithParam = "proc_Get_Intiqal_Sellers_List_ByKhata " + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + "";
                string spWithParam = "proc_Self_Get_Intiqal_Sellers_List_ByKhata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public void SetMushtarkaRaqbaMuntiqlaByHissa(string IntiqalKhataId, string KhataMuntaqilaHissa, string MMR_Kanal, string MMR_Marla, string MMR_Sarsai, string MMR_Feet)
            {
                string spWithParam = "Proc_Self_Set_Intiqal_Sellers_By_Hissa "+Classess.UsersManagments._Tehsilid.ToString()+",'" + IntiqalKhataId + "',  " + KhataMuntaqilaHissa + ",' " + MMR_Kanal + "','" + MMR_Marla + "', '" + MMR_Sarsai + "', '" + MMR_Feet + "'";
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public string IntiqalWarasathManderjaKhattajatWarisan(string khataid, string IntiqalId)
            {
                string spWithParam = "Proc_Self_Intiqal_Warasat_MandarjaKhatajatWarsan " + Classess.UsersManagments._Tehsilid.ToString() + "," + khataid + "," + IntiqalId + "";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public DataTable GetintiqalRahinSellersListByKhataRecId(string IntiqalKhataRecId, string IntiqalKhatooniRecid)
            {

                string spWithParam = "proc_Self_Get_Intiqal_Rahin_Sellers_List_ByKhata " + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public string WEB_Self_SP_INSERT_Fard_KhataJat_and_Malikan(string TokenId, string KhataId, string PersonId, string InsertUserid, string InsertLoginName, string TehsilId)
            {
                string spWithParam = "WEB_Self_SP_INSERT_Fard_KhataJat_and_Malikan " + TokenId + ", " + KhataId + ", " + PersonId + ", " + InsertUserid + ",'" + InsertLoginName + "'," + TehsilId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }
            public string GetDawraValidity(string Date)
            {
                string spWithParam = "select dbo.getFnDowra ( " + Classess.UsersManagments._Tehsilid.ToString() + ",'" + Date + "')";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }
            public string WEB_Self_SP_INSERT_Intiqal_KhataJat_and_Sellers(string IntiqalId, string IntiqalKhataId, string SellerPersonId, string InsertUserid)
            {
                string spWithParam = "WEB_Self_SP_INSERT_Intiqal_KhataJat_and_Sellers " + Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ", " + IntiqalKhataId + ", " + SellerPersonId + ", " + InsertUserid + " ";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }
            public DataTable GetTransactionalTokenNoListByDateKhata(string KhataId, string dateToken)
            {
                string spWithParam = "proc_Self_Get_TokenNo_List_By_Date_KhataId_Transactional " + Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId + ",'" + dateToken + "'";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetintiqalSellersListByKhataRecIdKK(string IntiqalKhataRecId)
            {
                //string spWithParam = "proc_Get_Intiqal_Sellers_List_ByKhata " + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + "";
                string spWithParam = "proc_Self_Get_Intiqal_Sellers_List_ByKhata_KK  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable Proc_Self_Get_KhassrasTotalArea_By_KhataId(string khataid)//, string IntiqalID, string SeqNo)
            {
                string spWithParam = "Proc_Self_Get_KhassrasTotalArea_By_KhataId " + Classess.UsersManagments._Tehsilid.ToString() + "," + khataid;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

            }
            //Get Intiqal Sellers from Khewat Group Fareqain and MustheriFareeqain after intiqal Amaldaramad
            public DataTable GetintiqalSellersListAfterAmaldaramad(string IntiqalKhataRecId, string IntiqalKhatooniRecid, string Malkiat)
            {
                string spWithParam = "proc_Get_Intiqal_Sellers_List_Amaldaramad  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalSellersListAfterAmaldaramadKK(string IntiqalKhataRecId)
            {
                string spWithParam = "proc_Self_Get_Intiqal_Sellers_List_Amaldaramad_KK  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            //fill Combobox in frmInteqalRegister
            public DataTable GetIntiqalKhataMalikanByKhataId(string KhataId)
            {
                string spWithParam = "proc_Get_Intiqal_Khata_Malkan " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + KhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetRegistryIntiqalKhataMalikanByKhataIdByFardTokenId(string KhataId, string fardTokenId)
            {
                string spWithParam = "proc_Self_Get_RegistryIntiqal_Khata_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + KhataId + "'" + "," + fardTokenId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetRegistryIntiqalKhatooniMalikanByFardTokenId(string KhatooniId, string fardTokenId)
            {
                string spWithParam = "proc_Self_Get_RegistryIntiqal_KhanaKashtKhatooni_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + KhatooniId + "'" + "," + fardTokenId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhataMalikanByKhataIdWithLogs(string KhataId)
            {
                string spWithParam = "proc_Get_Khata_Malkan_With_Logs  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalKhanaKasht(string KhatooniId)
            {
                string spWithParam = "proc_Get_Intiqal_KhanaKashtKhatooni_Malkan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalTypes()
            {
                string spWithParam = "proc_Intiqal_Type_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetMozaFamilyListByMozaId(string MozaId)
            {
                string spWithParam = "Proc_Get_Moza_Families_List " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + MozaId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetMozaFamilyListByFamilyId(string familyid)
            {
                string spWithParam = "Proc_Get_FamilyPersons_List  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + familyid;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalMainReports(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_Main_Reports  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }


            public DataTable GetRoznamchaDetails(string IntiqalId)
            {
                string spWithParam = "Proc_Self_Get_RoznamchaDetails " + IntiqalId;//--NOT_IMPLEMENTED_
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhataJatForintiqalByMozaId(string MozaId)
            {
                string spWithParam = "proc_Get_Moza_KhataJat_for_Intiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public string GetIntiqalOnParentKhata(string ParentKhataId, string IntiqalId)
            {
                string spWithParam = "Proc_Get_KhataParentStatus  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + ParentKhataId + "," + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public DataTable GetKhatJatForStayOrder(string MozaId)
            {
                string spWithParam = "Proc_Self_Get_Khatajat_For_StayOrder  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalatForAttestation(string dt)
            {
                string spWithParam = "Proc_Self_Get_Intiqalat_for_Attestation " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + dt + "',"+Classess.UsersManagments.SubSdcId.ToString();
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalatForVerification(string type)
            {
                string spWithParam = "Proc_Self_Get_Intiqalat_for_Verification  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + type + "'," + Classess.UsersManagments.SubSdcId.ToString();
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetFardBadratForVerification()
            {
                string spWithParam = "Proc_Get_FBs_for_Verification  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + Classess.UsersManagments.SubSdcId.ToString();
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhataJatForRegistryintiqalByFardTokenId(string fardTokenId)
            {
                string spWithParam = "proc_Self_Get_KhataJat_for_RegistryIntiqal_By_FardTokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fardTokenId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhataJatofKhatooniesForRegistryintiqalByFardTokenId(string fardTokenId)
            {
                string spWithParam = "proc_Self_Get_Khatajat_of_Khatoonies_for_RegistryIntiqal_By_FardTokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fardTokenId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhataJatKhatooniesForRegistryintiqalByFardTokenId(string fardTokenId)
            {
                string spWithParam = "proc_Self_Get_KhataJat_All_for_RegistryIntiqal_By_FardTokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fardTokenId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalByMozaIdSelf(string MozaId)
            {
                string spWithParam = "Proc_Self_Get_Intiqal_List_ByMoza  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhatoniDetails(string IntiqalKhataRecId)
            {
                string spWithParam = "proc_Get_Intiqal_Khatoonies_List_By_KhattaRecId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
        //public DataTable GetKhatoniDetails(string KhatoniRecid)
        //    {
        //        string spWithParam = "proc_Get_Moza_KhataJat_for_Intiqal " + KhatoniRecid;
        //        return dbobject.filldatatable_from_storedProcedure(spWithParam);
        //    }
            public string SaveintiqalBankChallan(string BankChalanId, string IntiqalId, string BankChallanNo, string BankChallanDate, string BankName, string BranchName, string ChallanAmount, string userid)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_BankChallan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + BankChalanId + "," + IntiqalId + "," + BankChallanNo + ",'" + BankChallanDate + "','" + BankName + "','" + BranchName + "'," + ChallanAmount + "," + userid;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string SaveintiqalKhatoni(string IntiqalKhatooniRecId, string intiqalId, string IntiqalKhataRecId, string IntiqalKhataId, string KhatoniId, string UserID,string UserName)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_KhanaKasht_Khatooni " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", '" + IntiqalKhatooniRecId + "'," + intiqalId + "," + IntiqalKhataRecId + "," + IntiqalKhataId + "," + KhatoniId + "," + UserID + ",'" + UserName + "'," + UserID + ",'" + UserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string SaveintiqalBuyers(string BuyerRecId, string IntiqalKhataRecId, string KhatoniRecid, string BuyerPersonId, string Hissa, string Kanal, string Marla, string Sarsai, string Feet, string KhewatTypeId, string BuyeraHisaBata, string InsertUserId, string InsertUserName)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Buyers_WithBata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + BuyerRecId + "," + IntiqalKhataRecId + "," + KhatoniRecid + "," + BuyerPersonId + "," + Hissa + "," + Kanal + "," + Marla + "," + Sarsai + "," + Feet + "," + KhewatTypeId + ",'" + BuyeraHisaBata + "'," + InsertUserId + ",'" + InsertUserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveintiqalBuyersSelf(string BuyerRecId, string IntiqalKhataRecId, string KhatoniRecid, string BuyerPersonId, string Hissa, string Kanal, string Marla, string Sarsai, string Feet, string KhewatTypeId, string BuyeraHisaBata, string Rishta,string InsertUserId, string InsertUserName)
            {
                string spWithParam = "WEB_Self_SP_INSERT_Intiqal_Buyers  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + BuyerRecId + "," + IntiqalKhataRecId + "," + KhatoniRecid + "," + BuyerPersonId + "," + Hissa + "," + Kanal + "," + Marla + "," + Sarsai + "," + Feet + "," + KhewatTypeId + ",'" + BuyeraHisaBata + "'," + Rishta + "," + InsertUserId + ",'" + InsertUserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveintiqalFees(string FeesId, string IntiqalId, string FeesTypeId, string IntiqalFeesAmount)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Fees  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FeesId + "," + IntiqalId + "," + FeesTypeId + "," + IntiqalFeesAmount;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveintiqalKhataJaat(string KhataRecId, string IntiqalId, string IntiqalKhataId, string InsertUserId)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_KhataJat  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataRecId + "," + IntiqalId + "," + IntiqalKhataId + "," + InsertUserId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveintiqalMain(string IntiqalId, string MozaId, string KhanaMalikat, string KhanaKasht, string khanakashtmalkiat, string IntiqalNo, string HawalaNo, string IntiqalTypeId, string InitiationId, string AndrajDate, string RapatNo, string RapatDate, string AmaldarDate, string LandValue, string IntiqalAttestationDate, string IntiqalReferenceNo, string LandTypeId, string LandValuationTableCost, string DegreeDate, string CourtName, string MisalNo, string otherDetails, string userid, string userName, string TokenId, string PlotTypeId, string PlotConstrTypeId, string PlotTerritoryTypeId, string LastIntiqalDate, string MinhayeIntiqalId, string fardTokenId, string fardTokenDate, string ReceivngId, string MisalDate)
            {
                //string KhanaMalikat1=Convert.ToString(KhanaMalikat);
                // string KhanaMalikat1=Convert.ToString(KhanaKasht);
                //string spWithParam = "WEB_SP_INSERT_Intiqal_Main_SDC " + IntiqalId + "," + MozaId + ", " + KhanaMalikat + ", " + KhanaKasht + "," + khanakashtmalkiat + " ," + IntiqalNo + ", " + HawalaNo + "," + IntiqalTypeId + ", " + InitiationId + ", '" + AndrajDate + "', " + RapatNo + ",'" + RapatDate + "', '" + AmaldarDate + "'," + LandValue.ToString() + ", '" + IntiqalAttestationDate + "'," + IntiqalReferenceNo + ", " + LandTypeId + ", " + LandValuationTableCost + ", '" + DegreeDate + "', N'" + CourtName + "', " + MisalNo + ",N'" + otherDetails + "', " + userid + ", '" + userName + "', " + TokenId + ", " + PlotTypeId + ", " + PlotConstrTypeId + ", " + PlotTerritoryTypeId + ", '" + LastIntiqalDate + "',"+MinhayeIntiqalId + "," + fardTokenId + ",'" + fardTokenDate +"'" ;
                string spWithParam = "WEB_SP_Self_INSERT_Intiqal_Main_SDC  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + "," + MozaId + ", " + KhanaMalikat + ", " + KhanaKasht + "," + khanakashtmalkiat + " ,'" + IntiqalNo + "', '" + HawalaNo + "'," + IntiqalTypeId + ", " + InitiationId + ", '" + AndrajDate + "', " + RapatNo + ",'" + RapatDate + "', '" + AmaldarDate + "'," + LandValue.ToString() + ", '" + IntiqalAttestationDate + "'," + IntiqalReferenceNo + ", " + LandTypeId + ", " + LandValuationTableCost + ", '" + DegreeDate + "', N'" + CourtName + "', " + MisalNo + ",N'" + otherDetails + "', " + userid + ", '" + userName + "', " + TokenId + ", " + PlotTypeId + ", " + PlotConstrTypeId + ", " + PlotTerritoryTypeId + ", '" + LastIntiqalDate + "'," + MinhayeIntiqalId + "," + fardTokenId + ",'" + fardTokenDate + "'" + "," + ReceivngId + ", '" + MisalDate + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string SaveIntiqalMainManual(string IntiqalId, string MozaId, string KhanaMalikat, string KhanaKasht, string khanakashtmalkiat, string IntiqalNo, string HawalaNo, string IntiqalTypeId, string InitiationId, string AndrajDate, string RapatNo, string RapatDate, string AmaldarDate, string LandValue, string IntiqalAttestationDate, string IntiqalReferenceNo, string LandTypeId, string LandValuationTableCost, string DegreeDate, string CourtName, string MisalNo, string otherDetails, string userid, string userName)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Main  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + "," + MozaId + ", " + KhanaMalikat + ", " + KhanaKasht + "," + khanakashtmalkiat + " ,'" + IntiqalNo + "', " + HawalaNo + "," + IntiqalTypeId + ", " + InitiationId + ", '" + AndrajDate + "', " + RapatNo + ",'" + RapatDate + "', '" + AmaldarDate + "'," + LandValue.ToString() + ", '" + IntiqalAttestationDate + "'," + IntiqalReferenceNo + ", " + LandTypeId + ", " + LandValuationTableCost + ", '" + DegreeDate + "', N'" + CourtName + "', " + MisalNo + ",N'" + otherDetails + "', " + userid + ", '" + userName +"'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveintiqalSellers(string SellerRecId, string KhataRecId, string SellerPersonId, string isDead, string DeathDate, string TotalHissa, string TotalKanal, string TotalMarla, string TotalSarsai, string TotalFeet, string SoldHissa, string SoldKanal, string SoldMarla, string SoldSarsai, string SoldFeet, string khewatgroupfareeqid, string MustriFareeq, string KhatoniRecid, string InsertUserid)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Sellers  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + SellerRecId + ", " + KhataRecId + ", " + SellerPersonId + ", " + isDead + ", '" + DeathDate + "', " + TotalHissa + ", " + TotalKanal + ", " + TotalMarla + ", " + TotalSarsai + ", " + TotalFeet + ", " + SoldHissa + ", " + SoldKanal + ", " + SoldMarla + ", " + SoldSarsai + ", " + SoldFeet + ", " + khewatgroupfareeqid + "," + MustriFareeq + "," + KhatoniRecid + "," + InsertUserid + " ";
             return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }

            public string SaveRegistryintiqalSellers(string SellerRecId, string KhataRecId, string SellerPersonId, string isDead, string DeathDate, string TotalHissa, string TotalKanal, string TotalMarla, string TotalSarsai, string TotalFeet, string SoldHissa, string SoldKanal, string SoldMarla, string SoldSarsai, string SoldFeet, string khewatgroupfareeqid, string MustriFareeq, string KhatoniRecid, string fardTokenId, string InsertUserid)
            {
                string spWithParam = "WEB_Self_SP_INSERT_RegistryIntiqal_Sellers  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + SellerRecId + ", " + KhataRecId + ", " + SellerPersonId + ", " + isDead + ", '" + DeathDate + "', " + TotalHissa + ", " + TotalKanal + ", " + TotalMarla + ", " + TotalSarsai + ", " + TotalFeet + ", " + SoldHissa + ", " + SoldKanal + ", " + SoldMarla + ", " + SoldSarsai + ", " + SoldFeet + ", " + khewatgroupfareeqid + "," + MustriFareeq + "," + KhatoniRecid + "," + fardTokenId + "," + InsertUserid + " ";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }

            public string SaveSalamJuzviKhassraDetail(string SalamJuzviKhassraId,string KhassraId, string KhassraDetailId, string Min_KhassraNo,string MinType,string KhatooniId,string IntiqalKhataRecId,string IntiqalKhatoonirecId,string Min_Kanal,string Min_Marla,string Min_Sarsai,string Min_Feet,string AreaTypeId,string MozaId,string UserId,string LoginName	)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Juzvi_Khassra  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + SalamJuzviKhassraId + ", " + KhassraId + "," + KhassraDetailId + ", N'" + Min_KhassraNo + "', N'" + MinType + "', " + KhatooniId + ", " + IntiqalKhataRecId + ", " + IntiqalKhatoonirecId + ", " + Min_Kanal + ", " + Min_Marla + ", " + Min_Sarsai + ", " + Min_Feet + ", " + AreaTypeId + ", " + MozaId + ", " + UserId + ",'" + LoginName + "' ";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }
            public string SaveAutoKhatajatForKhassraIntiqal(string IntiqalKhataRecId, string UserId, string LoginName)
            {
                string spWithParam = "WEB_SP_Insert_Khatajat_New_Khassra_Intiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + IntiqalKhataRecId + ", " + UserId + ",'" + LoginName + "' ";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }
            public string SaveIntiqalOperatorNote(string IntiqalId, string OperatorNote)
            {
                string spWithParam = "WEB_SP_UPDATE_Intiqal_Main_OperatorReport  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ", N'" + OperatorNote + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }

            public DataTable GetInteqalTypesCategoriesList()
            {
                string spWithParam = "Proc_Get_IntiqalTypeCategoroies  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString();
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalSalamJuzviKhassra(string IntiqalKhataRecId)
            {
                string spWithParam = "Proc_Get_Intiqal_Juzvi_Salam_Khassra  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

            }
            public DataTable GetIntiqalSalamJuzviKhassraByKhatooni(string IntiqalKhatooniRecId)
            {
                string spWithParam = "Proc_Get_Intiqal_Juzvi_Salam_Khassra_ByKhatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhatooniRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhassrasByKhatoniMutation(string KhatooniId)
            {
                string spWithParam = "Proc_Get_Khatooni_KhassraArea_Detail_Mut  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhassrasByKhatoni(string KhatooniId)
            {
                string spWithParam = "Proc_Get_Khatooni_KhassraArea_Detail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable SearchKhassraByKhassraNoMozaId(string KhassraNo, string MozaId)
            {
                string spWithParam = "Proc_Get_Search_Khassra_ByKhassraNo_SDC  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + KhassraNo + "'," + MozaId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }


            public string SaveKhassraMalikGroup(string KhassraMalikRecId, string KhassraId, string BuyerPersonId, string MozaId, string IntiqalId)
            {
                string spWithParam = "WEB_SP_INSERT_KhassraMalikGroup  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhassraMalikRecId + ", " + KhassraId + ", " + BuyerPersonId + ", " + MozaId + ", " + IntiqalId + "";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }


            public DataTable GetKhassraIntiqalBuyers(string IntiqalId)
            {
                string spWithParam = "Proc_Get_KhassraInteqalBuyers " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + IntiqalId;
             
                 return dbobject.filldatatable_from_storedProcedure(spWithParam);
             
            }
            public string SaveAllMushtryanofKhatooni(string KhataRecId, string KhatoniRecId, string KhatooniId, string InsertUserId)
            {
                string spWithParam = "WEB_Self_SP_INSERT_Intiqal_Sellers_AllMushtryanofKhatooni "+Classess.UsersManagments._Tehsilid.ToString()+"," + KhataRecId + "," + KhatoniRecId + "," + KhatooniId + "," + InsertUserId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string SaveAllMushtryanofAllKhatooni(string KhataRecId, string InsertUserId, string InsertUserName)
            {
                string spWithParam = "WEB_Self_SP_INSERT_Intiqal_Buyers_AllMushtryanofKhatoonies " + Classess.UsersManagments._Tehsilid.ToString() + "," + KhataRecId + "," + InsertUserId + ",'" + InsertUserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public DataTable IntiqalAmalDaramad(string mozaid,string IntiqalId, string userId, string UserName)
            {
                //string s = DataContext.Proc_Intiqal_Amaldaramad(stringiqalId).FirstOrDefault().ToString();
                //return s;
                string spWithParam = "proc_Intiqal_Amaldaramad_Combine_Taqseem  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + mozaid + "," + IntiqalId + ","+userId+",'"+UserName+"'";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public string IntiqalAmalDaramadByKhataIdSingle( string IntiqalId, string IntiqalKhataId, string userId, string userName)
            {

                string spWithParam = "Proc_Intiqal_Amaldaramad_By_KhataId_Single  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + "," + IntiqalKhataId + "," + userId + ",'" + userName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string FardCancel(string fardTokenid, string PicId,  string userId, string userName)
            {

                string spWithParam = "Proc_Self_Insert_Fard_Cancel  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fardTokenid + "," + PicId + "," + userId + ",'" + userName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string CheckKKinKhata(string KhataId)
            {
                string spWithParam = "Proc_Self_Check_KK_in_Khata_YesNo " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string RemAreaofPersonByKhata(string personId, string KhataId)
            {
                string spWithParam = "Proc_Self_Get_SDC_Remaining_Area_By_PersonId_KhataId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + personId + "," + KhataId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string FardCancelCheck(string fardTokenid)
            {

                string spWithParam = "Proc_Self_Check_Fard_Cancel  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fardTokenid;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public DataTable KhewatGroupFareeqainAll(string KhataId)
            {
                string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata_All_RecStatus  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable KhewatGroupFareeqByKhataIdPersonId(string KhataId, string PersonId)
            {

                string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata_By_PersonId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId + "," + PersonId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable KhewatGroupFareeqByKhataIdPersonIdForOtherDistTehsil(string TehsilId, string KhataId, string PersonId)
            {

                string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata_By_PersonId  " + TehsilId + "," + KhataId + "," + PersonId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
        /// <summary>
        /// Before amal daramad of any intiqal this function check the saved value of seller hissa and area and actual hissa and area of 
        /// malik at the time of execution of amal daramad procedure
        /// </summary>
        /// <param name="intiqalId"></param>
        /// <returns></returns>
            public string CheckMalikRemainingHissaCheck(string intiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_Sellers_Remaining_Hissa_Check  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + intiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }


            public DataTable GetIntiqalMinGroup(string IntiqalId, string IntiqalKhataId, string IntiqalKhatooniRecId)
            {
                //string spWithParam = "Proc_Get_Intiqal_MinGroupsList " +
                string spWithParam = "Proc_Get_Intiqal_MinGroupsList  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + "," + IntiqalKhataId + ", " + IntiqalKhatooniRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinMalikanList(string IntiqalKhataRecId, string MalikanType, string IntiqalId)
            {
                //string spWithParam = "Proc_Get_Intiqal_MinGroupsList " +
                string spWithParam = "Proc_Get_IntiqalMin_MalkanList  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId + "," + MalikanType + "," + IntiqalId + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinMushteryanList(string IntiqalKhatooniId, string MalikanType, string IntiqalId)
            {
                //string spWithParam = "Proc_Get_Intiqal_MinGroupsList " +
                string spWithParam = "Proc_Get_IntiqalMin_MalkanList_Khanakasht  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhatooniId + "," + MalikanType + "," + IntiqalId + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinGroupDetails(string IntiqalMinGroupId)
            {
                string spWithParam = "Proc_Get_Intiqal_MinGroup_Detail  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinGroupId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);  
            }


            public DataTable GetInsertedDocumentsImage(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_DocumentImages  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);  
            }


            public DataTable GetIntiqalMinFareeqain(string IntiqalId, string IntiqalMinGroupId)
            {
                string spWithParam = "Proc_Get_Intiqal_MinFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalId + "','" + IntiqalMinGroupId + "'";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public string SaveDocumentImages(string IntiqalDocImageId,string Action, string IntiqalDocRecId, string InitqalId, string IntiqalDocId, string PageNo, byte[] IntiqalDocImage,string action_forInserting, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
            {
                //int insertpagno= Convert.ToInt32(action_forInserting);
                Database ojbdb = new Database();
                string lastId = "";
                SqlCommand mycomm = new SqlCommand();
                mycomm.Parameters.AddWithValue("@Tehsilid",  SDC_Application.Classess.UsersManagments._Tehsilid.ToString() );
                mycomm.Parameters.AddWithValue("@IntiqalDocImageId",IntiqalDocImageId);
                mycomm.Parameters.AddWithValue("@ActionType", Action);
                mycomm.Parameters.AddWithValue("@IntiqalDocRecId", IntiqalDocRecId);
                mycomm.Parameters.AddWithValue("@InitqalId", InitqalId);
                mycomm.Parameters.AddWithValue("@IntiqalDocId", IntiqalDocId);
                mycomm.Parameters.AddWithValue("@IntiqalDoc_PageNo", PageNo);
                mycomm.Parameters.AddWithValue("@IntiqalDocImage", IntiqalDocImage);

                mycomm.Parameters.AddWithValue("@insertatpageno", action_forInserting);

                mycomm.Parameters.AddWithValue("@InsertUserId", InsertUserId);
                mycomm.Parameters.AddWithValue("@InsertLoginName", InsertLoginName);
                mycomm.Parameters.AddWithValue("@UpdateUserId", UpdateUserId);
                mycomm.Parameters.AddWithValue("@UpdateLoginName", UpdateLoginName);
                try
                {
                    lastId = ojbdb.ExecStoredProcedure("WEB_SP_INSERT_Intiqal_DocumentImages", mycomm);

                }
                catch (Exception e)
                {
                    throw e;
                }
                return lastId;
            }


            public string SaveKhataImages(string ImageId, string MozaId,  byte[] Image,string PageNos, string UserId,string UserName)
            {
                //int insertpagno= Convert.ToInt32(action_forInserting);
                Database ojbdb = new Database();
                string lastId = "";
                SqlCommand mycomm = new SqlCommand();
                mycomm.Parameters.AddWithValue("@Tehsilid", SDC_Application.Classess.UsersManagments._Tehsilid.ToString());
                mycomm.Parameters.AddWithValue("@ImageId", ImageId);
                mycomm.Parameters.AddWithValue("@MozaId", MozaId);
                mycomm.Parameters.AddWithValue("@Image", Image);
                mycomm.Parameters.AddWithValue("@PageNos", PageNos);
                mycomm.Parameters.AddWithValue("@InsertUserId", UserId);
                mycomm.Parameters.AddWithValue("@InsertLoginName", UserName);

                try
                {
                    lastId = ojbdb.ExecStoredProcedure("WEB_SELF_SP_INSERT_Khata_Images", mycomm);

                }
                catch (Exception e)
                {
                    throw e;
                }
                return lastId;
            }

            public string SaveCancelFardImages(string ImageId, string MozaId, byte[] Image, string PageNos, string UserId, string UserName)
            {
                //int insertpagno= Convert.ToInt32(action_forInserting);
                Database ojbdb = new Database();
                string lastId = "";
                SqlCommand mycomm = new SqlCommand();
                mycomm.Parameters.AddWithValue("@Tehsilid", SDC_Application.Classess.UsersManagments._Tehsilid.ToString());
                mycomm.Parameters.AddWithValue("@ImageId", ImageId);
                mycomm.Parameters.AddWithValue("@MozaId", MozaId);
                mycomm.Parameters.AddWithValue("@Image", Image);
                mycomm.Parameters.AddWithValue("@PageNos", PageNos);
                mycomm.Parameters.AddWithValue("@InsertUserId", UserId);
                mycomm.Parameters.AddWithValue("@InsertLoginName", UserName);

                try
                {
                    lastId = ojbdb.ExecStoredProcedure("WEB_SELF_SP_INSERT_CancelFard_Images", mycomm);

                }
                catch (Exception e)
                {
                    throw e;
                }
                return lastId;
            }


            public string SaveMisalImages(string ImageId, string MozaId, string MisalId, byte[] Image, string PageNos, string UserId, string UserName)
            {
                //int insertpagno= Convert.ToInt32(action_forInserting);
                Database ojbdb = new Database();
                string lastId = "";
                SqlCommand mycomm = new SqlCommand();
                mycomm.Parameters.AddWithValue("@Tehsilid", SDC_Application.Classess.UsersManagments._Tehsilid.ToString());
                mycomm.Parameters.AddWithValue("@ImageId", ImageId);
                mycomm.Parameters.AddWithValue("@MozaId", MozaId);
                mycomm.Parameters.AddWithValue("@MisalId", MisalId);
                mycomm.Parameters.AddWithValue("@Image", Image);
                mycomm.Parameters.AddWithValue("@PageNos", PageNos);
                mycomm.Parameters.AddWithValue("@InsertUserId", UserId);
                mycomm.Parameters.AddWithValue("@InsertLoginName", UserName);

                try
                {
                    lastId = ojbdb.ExecStoredProcedure("WEB_SELF_SP_INSERT_Misal_Images", mycomm);

                }
                catch (Exception e)
                {
                    throw e;
                }
                return lastId;
            }

            public string SaveIntiqalMinGroup(string IntiqalMinGroupId, string IntiqalId, string IntiqalMinOldKhataId, string IntiqalMinGroupNo, string IntiqalMinKhattaNo, string IntiqalMinOldKhatooniId, string IntiqalMinKhatooniRecId, string IntiqalMinKhatooniNo, string IntiqalMin_TotalParts, string IntiqalMin_Kanal, string IntiqalMin_Marla, string IntiqalMin_Sarsai, string IntiqalMin_Feet, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName, string MozaId)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_MinGroup  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinGroupId + ", " + IntiqalId + ", " + IntiqalMinOldKhataId + ", '" + IntiqalMinGroupNo + "', '" + IntiqalMinKhattaNo + "', '" + IntiqalMinOldKhatooniId + "', " + IntiqalMinKhatooniRecId + ", '" + IntiqalMinKhatooniNo + "', " + IntiqalMin_TotalParts + ", " + IntiqalMin_Kanal + ", " + IntiqalMin_Marla + ", " + IntiqalMin_Sarsai + ", " + IntiqalMin_Feet + ", " + InsertUserId + ", '" + InsertLoginName + "'," + UpdateUserId + ", '" + UpdateLoginName + "', " + MozaId + "";
                 return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
        //first
            public string SaveKhewatGrouFreeqein(string IntiqalMinKhewatFareeqId, string KhewatGroupId, string PersonId, string FardAreaPart, string FardKanal, string FardMarla, string FardSarsai, string FardFeet,string KhewatTypeId, string RegisterHDQKhataId, string Insertuserid,string Darno,string TotalDarPart,string PersonDarPart,string ofdarPart,string InsertLoginName,string FardpartBhata)
            {
                string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinKhewatFareeqId + ", " + KhewatGroupId + ", " + PersonId + ", " + FardAreaPart + ", " + FardKanal + ", " + FardMarla + ", " + FardSarsai + ", " + FardFeet + ", " + KhewatTypeId + ", " + RegisterHDQKhataId + ", " + Insertuserid + ", " + Darno + ", " + TotalDarPart + ", " + PersonDarPart + ", " + ofdarPart + ", '" + InsertLoginName + "'," + FardpartBhata + "";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
        //second
            public string SaveIntiqalMinFareeqain(string IntiqalMinKhewatFareeqId, string IntiqalId, string IntiqalMinGroupId, string OldKhataId, string KhewatGroupFareeqId,string OldKhatooniId, string KhatooniRecId, string MushtriFareeqId,  string SeqNo, string KhewatTypeId, string IntiqalMinPersonId, string Intiqal_Min_Hissa, string Intiqal_Min_Kanal, string Intiqal_Min_Marla, string Intiqal_Min_Sarsai, string Intiqal_Min_Feet, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName, string MozaId)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Min_Fareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalMinKhewatFareeqId + "', " + IntiqalId + ", '" + IntiqalMinGroupId + "', " + OldKhataId + ", " + KhewatGroupFareeqId + ", " + OldKhatooniId + ", " + KhatooniRecId + ", " + MushtriFareeqId + ", " + SeqNo + ", " + KhewatTypeId + ", " + IntiqalMinPersonId + ", " + Intiqal_Min_Hissa.ToString() + ", " + Intiqal_Min_Kanal + ", " + Intiqal_Min_Marla + ", " + Intiqal_Min_Sarsai.ToString() + ", " + Intiqal_Min_Feet.ToString() + ", " + InsertUserId + ", '" + InsertLoginName + "', " + UpdateUserId + ",'" + UpdateLoginName + "', " + MozaId + "";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveIntiqalMinKhassra(string IntiqalMinKhassraRecId, string IntiqalId, string IntiqalMinGroupId, string OldKhattaId, string OldKhatoniId, string OldKhassraId, string MinKhassraId, string OldKhassraDetailId, string MinNo, string Min_KhassraNo, string Min_KhatooniNo, string AreaTypeId, string MIntypeId, string Min_Kanal, string Min_Marla, float Min_Sarsai, float Min_Feet, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName, string MozaId)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Min_Khassras  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinKhassraRecId + ", " + IntiqalId + ", " + IntiqalMinGroupId + ", " + OldKhattaId + "," + OldKhatoniId + ", " + OldKhassraId + ", " + OldKhassraDetailId + ", " + MinKhassraId + ", '" + MinNo + "', '" + Min_KhassraNo + "', '" + Min_KhatooniNo + "', " + AreaTypeId + ", " + MIntypeId + ", " + Min_Kanal + ", " + Min_Marla + "," + Min_Sarsai.ToString() + "," + Min_Feet.ToString() + ", " + InsertUserId + ", '" + InsertLoginName + "', " + UpdateUserId + ", '" + UpdateLoginName + "', " + MozaId + "";
                 return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string DelCancelFardImage(string PicId)
            {
                string spWithParam = "WEB_Self_SP_DELETE_CancelFard_Image  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + PicId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public void SaveIntiqalMainReports(string IntiqalId, string PatwariReport, string PatwariReport_Date, string GardawarReport, string GardawarReport_Date, string TehsildarReport, string TehsildarReport_Date,string IntiqalTaxDetails, string UpdateUserId)
            {
                string spWithParam = "WEB_SP_UPDATE_Intiqal_Main_Reports  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ",N'" + PatwariReport + "', '" + PatwariReport_Date + "', N'" + GardawarReport + "', '" + GardawarReport_Date + "', N'" + TehsildarReport + "', '" + TehsildarReport_Date + "',N'" + IntiqalTaxDetails + "'," + UpdateUserId;
                 dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public void SaveIntiqalRoznamcha(string RoznamchaId, string MozaId, string IntiqalId, string Roznamcha,  string dtRoznamcha, string RoznamchaNo, string UpdateUserId, string UserName)
            {
                // --NOT_IMPLEMENTED_ not in db
                string spWithParam = "WEB_Self_SP_Insert_Intiqal_Roznamcha " + RoznamchaId + "," + MozaId + "," + IntiqalId + ",N'" + Roznamcha +  "','" + dtRoznamcha + "',N'" + RoznamchaNo + "'," + UpdateUserId + ",N'" + UserName + "'";
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public DataTable GetIntiqalMalikanList(string IntiqalKhataId, string ListType)
            {
                string spWithParam = "Proc_Get_IntiqalMin_MalkanList  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataId + "," + ListType + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinKhassraJat(string IntiqalId, string IntiqalMinGroupId)
            {
                string spWithParam = "Proc_Get_Intiqal_MinKhassraJat  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + "," + IntiqalMinGroupId + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhassraJatByKhattaId(string IntiqalKhataId)
            {
                string spWithParam = "Proc_Get_KhassraJatByKhataId " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + IntiqalKhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public void SetIntiqalMinGrpTotal(string IntiqalMinGroupId)
            {

                string spWithParam = "Proc_Set_Intiqal_MinGroup_Totals  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinGroupId;               
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public string IntiqalMinAmalDaramad(string MozaId, string IntiqalId)
            {
                string spWithParam = "proc_IntiqalMin_Amaldaramad  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ", " + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);;
            }


            public DataTable GetIntiqalMIntypes()
            {
                string spWithParam = "Proc_Get_IntiqalMintypes  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhewatTypes(string TehsilId)
            {
                string spWithParam = "Proc_Get_KhewatTypes " + TehsilId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            
            }


            public string IntiqalMinBadasthor(string IntiqalId, string KhataId)
            {
                string spWithParam = "Proc_IntiqalMin_BadStoor  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ", " + KhataId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }


            public void DeleteIntiqalMinFareeq(string IntiqalMinKhewatFareeqId)
            {

                string spWithParam = " WEB_SP_DELETE_Intiqal_Min_Fareeq  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinKhewatFareeqId;
                               dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public void DeleteIntiqalSalamJuzviKhassra(string SalamJUzviKhasraId)
            {

                string spWithParam = " WEB_SP_DELETE_Intiqal_SalamJuzviKhassra  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + SalamJUzviKhasraId;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }


            public void DeleteIntiqalMinKhassra(string IntiqalMinKhassraRecId)
            {
               // DataContext.WEB_SP_DELETE_Intiqal_Min_Khassra(stringiqalMinKhassraRecId);
                string spWithParam = " WEB_SP_DELETE_Intiqal_Min_Khassra  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinKhassraRecId;
                               dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }
            public void DeleteIntiqalMinGroupByKhata(string IntiqalMinOldKhataId,string Intiqalid)
            {
                // DataContext.WEB_SP_DELETE_Intiqal_Min_Khassra(stringiqalMinKhassraRecId);
                string spWithParam = " WEB_SP_DELETE_Intiqal_Min_Group_Khata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinOldKhataId + "," + Intiqalid;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }
            public void DeleteIntiqalMinGroupByKhatooni(string IntiqalMinKhatooniRecId)
            {
                // DataContext.WEB_SP_DELETE_Intiqal_Min_Khassra(stringiqalMinKhassraRecId);
                string spWithParam = " WEB_SP_DELETE_Intiqal_Min_Group_Khatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinKhatooniRecId;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }



            public void UpdateIntiqalMinFareeqHissa(string IntiqalMinKhewatFareeqId, float Intiqal_Min_Hissa, string Intiqal_Min_Kanal, string Intiqal_Min_Marla, float Intiqal_Min_Sarsai, float Intiqal_Min_Feet, string MozaId)
            {
                string spWithParam = "WEB_SP_UPDATE_Intiqal_Min_FareeqeinHissa  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinKhewatFareeqId + ", " + Intiqal_Min_Hissa.ToString() + ", " + Intiqal_Min_Kanal + ", " + Intiqal_Min_Marla.ToString() + ", " + Intiqal_Min_Sarsai.ToString() + ", " + Intiqal_Min_Feet + "," + MozaId + ""; ;
               dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }


            public void SetMushtarkaRaqbaMuntiqla(string IntiqalKhataId, string MustarqaMuntiqla, string MMR_Kanal, string MMR_Marla, string MMR_Sarsai, string MMR_Feet)
            {
                string spWithParam = "Proc_Set_Intiqal_RaqbaMutiqla  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhataId + "', '" + MustarqaMuntiqla + "',' " + MMR_Kanal + "','" + MMR_Marla + "', '" + MMR_Sarsai + "', '" + MMR_Feet + "'";
               dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public void SetMushtarkaRaqbaMuntiqlaKhatooni(string IntiqalKhatooniRecId, string MustarqaMuntiqla, string MMR_Kanal, string MMR_Marla, string MMR_Sarsai, string MMR_Feet)
            {
                string spWithParam = "Proc_Set_Intiqal_Khatooni_RaqbaMutiqla  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + IntiqalKhatooniRecId + "', '" + MustarqaMuntiqla + "'," + MMR_Kanal + "," + MMR_Marla + ", " + MMR_Sarsai + ", " + MMR_Feet + "";
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public DataTable GetIntiqalMushtariqaRaqbaMuntaqila(string IntiqalKhataId)
            {
                string spWithParam = "Proc_Get_Intiqal_RaqbaMutiqla  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }


            public string IntiqalWarasathManderjaKhattaWarisan(string khataid, string IntiqalId)
            {
                string spWithParam = "Proc_Intiqal_Warasat_MandarjaKhataWarsan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + khataid + "," + IntiqalId + "";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string IntiqalWarasathManderjaKhatooniWarisan(string KhatooniRecId, string khataRecid, string IntiqalId)
            {


                string spWithParam = "Proc_Intiqal_Warasat_MandarjaKhatooniWarsan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhatooniRecId + "," + khataRecid + "," + IntiqalId + "";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }


            public DataTable GetKhattajatByPersonId(string MozaId, string PersonId)
            {
                string spWithParam = "Proc_Get_Person_KhataJats   " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + PersonId + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }


            public string GetKhassraTotalRaqbaByKhattaId(string KhattaId)
            {
                string spWithParam = "Proc_Get_KhassrasTotalArea_By_KhataId   " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhattaId;
                   return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string GetKhassraMIntotalRaqbaByMinGroup(string IntiqalMinGroupId)
            {
                string spWithParam = "proc_Get_IntiqalMin_KhassrasTotalArea_By_MinGroup  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalMinGroupId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string setIntiqalPendingReason(string IntiqalId, bool IntiqalPending, string IntiqalPendingReasonId,string UserId, string IntiqalPendingReasonRemarks)
            {
               string IntiqalPend=Convert.ToString(IntiqalPending);
               string spWithParam = " Proc_Set_IntiqalPending  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ", " + IntiqalPend + "," +"'"+IntiqalPendingReasonId+"'"+","+UserId + ",N'" + IntiqalPendingReasonRemarks + "'";
               return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string SaveintiqalKhatoniWithKhashtkaranDetail(string IntiqalKhatooniRecId, string intiqalId, string IntiqalKhataRecId, string IntiqalKhataId, string KhatoniId, string KashtkaranDetails, string UserID, string UserName)
            {
                string spWithParam = "WEB_Self_SP_INSERT_Intiqal_KhanaKasht_Khatooni_WithKhashtkaranDetail "+Classess.UsersManagments._Tehsilid.ToString()+ ",'"+ IntiqalKhatooniRecId + "'," + intiqalId + "," + IntiqalKhataRecId + "," + IntiqalKhataId + "," + KhatoniId + ",N'" + KashtkaranDetails + "'," + UserID + ",'" + UserName + "'," + UserID + ",'" + UserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public DataTable GetKhatoniDetailsWithKashtkaran(string IntiqalKhataRecId)
            {
                string spWithParam = "proc_Self_Get_Intiqal_Khatoonies_List_By_KhattaRecId_WithKashtkaran "+Classess.UsersManagments._Tehsilid.ToString()+"," + IntiqalKhataRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public string Proc_Self_Get_Registrar_For_Intiqal(string RegNo, int Y, string mozaId)
            {
                string RegistrarOffice = "0";
                string spWithParam = "Proc_Self_Get_Registrar_For_Intiqal "+SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + RegNo + "'," + Y + "," + mozaId;
                RegistrarOffice = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
                return RegistrarOffice;
            }
            public DataTable GetIntiqalPendingReason()
            {
                string spWithParam = "Proc_Get_IntiqalPendingReasons  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
                return  dbobject.filldatatable_from_storedProcedure(spWithParam);
            }


            public string GetKhattaInconsistencyStatus(string Khataid)
            {
                string spWithParam = "Proc_Get_Khata_Inconsistancy " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + Khataid;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }

            public DataTable GetIntiqalPersonsList(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_PersonsList  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalPersonsListFardSelf(string tokenId)
            {
                string spWithParam = "Proc_Self_Get_Fard_PersonsList  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + tokenId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalatEnteredFardTokenId(string tokenId)
            {
                string spWithParam = "Proc_Self_Get_SDC_Fard_Intiqalat_Details  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + tokenId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetRemainingFardTokenId(string tokenId)
            {
                string spWithParam = "Proc_Self_Get_SDC_Remaining_Area_of_Fard  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + tokenId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetCancelFardTokenId(string tokenId)
            {
                string spWithParam = "Proc_Self_Get_SDC_Cancel_Area_of_Fard  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + tokenId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public string SaveIntiqalDocumentsRequired(string IntiqalDocRecId, string Intiqalid, string SeqNo, string IntiqalDocId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
                {
                    string spWithParam = " WEB_SP_INSERT_Intiqal_DocumentsRequired  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalDocRecId + ", " + Intiqalid + ", " + SeqNo + ", " + IntiqalDocId + ", " + InsertUserId + ",'" + InsertLoginName + "',  " + UpdateUserId + ", '" + UpdateLoginName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string INSERTIntiqalDocumentImages(string IntiqalDocRecId, string Intiqalid, string SeqNo, string IntiqalDocId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
                {
                    string spWithParam = " WEB_SP_INSERT_Intiqal_DocumentImages  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalDocRecId + ", " + Intiqalid + ", " + SeqNo + ", " + IntiqalDocId + ", " + InsertUserId + ",'" + InsertLoginName + "',  " + UpdateUserId + ", '" + UpdateLoginName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public DataTable GetIntiqalDocumentsRequired(string Intiqalid) 
            {
                string spWithParam = "proc_Get_Intiqal_DocumentsRequired   " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + Intiqalid + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetIntiqalDocumentsList()
            {
                string spWithParam = "proc_Get_Intiqal_DocumentsList  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public void IntiqalAmalDaramadCombined(string MozaId, string IntiqalId)
            {
                string spWithParam = "proc_Intiqal_Amaldaramad_Combine_Taqseem  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + IntiqalId;
                dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public void IntiqalMinAmalDaramadKhanakasht(string MozaId, string IntiqalId, string KhattaId)
            {
                string spWithParam = "proc_IntiqalMin_KhanaKasht_Amaldaramad_By_KhataId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + "," + IntiqalId + "," + KhattaId;
                dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinGroup(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_MinList  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public string SaveMushteriFareeqainFromKhatooniToNewKhatooni(string NewKhatooniId, string OldKhatooniId)
            {
                string spWithParam = "WEB_SP_INSERT_MushtriFareeqein_From_Khatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + NewKhatooniId + "," + OldKhatooniId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public DataTable GetKhatooniByParentKhatooniId(string parentKhatooniId, string IntiqalId)
            {
                string spWithParam = "Proc_Get_Khatoonis_ByParentKhatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + parentKhatooniId + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

        
       
            #endregion

            #region Get Next Intiqal No for Mouza 

            public string GetNextIntiqalNoForMoza(string MozaId, string TokenId) //--GetintiqalMainByIntiqalNoMozaId
            {
                string spWithParam = "Proc_Get_Intiqal_Next_Intiqal_No_By_Moza  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ",'" + TokenId + "'";
                string lastNo= dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
                return lastNo;
            }

            public DataTable GetintiqalMainByIntiqalNoMozaId(string MozaId, string IntiqalNo) //--GetintiqalMainByIntiqalNoMozaId
            {
                string spWithParam = "proc_Get_Intiqal_Main_By_MozaId_By_IntiqalNo  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ",'" + IntiqalNo + "'";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
                
            }


            #endregion

            #region Get Intiqal Juzvi Status

            public bool GetIntiqalKhataJuzviStatus(string IntiqalKhataRecId)
            {
                string spWithParam = "Proc_GET_Intiqal_JuzviKhataStatus " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + IntiqalKhataRecId;
                return Convert.ToBoolean( dbobject.ExecInsertUpdateStoredProcedure(spWithParam));
            }

            #endregion

            #region Update Intiqal Khata Juzvi status

            public bool UpdateIntiqalKhataJuzviStatus(string isJuzvi, string IntiqalKhataRecId)
            {
                string spWithParam = "WEB_SP_Update_Intiqal_JuzviKhata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + isJuzvi + " ," + IntiqalKhataRecId;
                return Convert.ToBoolean(dbobject.ExecInsertUpdateStoredProcedure(spWithParam));
            }

            public bool UpdateIntiqalKhatooniJuzviStatus(string isJuzvi, string IntiqalKhatooniRecId)
            {
                string spWithParam = "WEB_SP_Update_Intiqal_JuzviKhatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + isJuzvi + " ," + IntiqalKhatooniRecId;
                return Convert.ToBoolean(dbobject.ExecInsertUpdateStoredProcedure(spWithParam));
            }

            #endregion

            #region Intiqalat deletion portion
            /// <summary>
            /// Deletes intiqal main record
            /// </summary>
            /// <param name="IntiqalId"></param>
            public void DeleteIntiqalMain(int IntiqalId)
            {
                //DataContext.WEB_SP_DELETE_Intiqal_Intiqal_Main(IntiqalId);
                string spWithParam = "WEB_SP_DELETE_Intiqal_Intiqal_Main  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + "";
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            /// <summary>
            /// Deletes Intiqal khattajat
            /// </summary>
            /// <param name="IntiqalKhataRecId"></param>
            public void DeleteIntiqalKhattajat(string IntiqalKhataRecId)
            {
                //DataContext.WEB_SP_DELETE_Intiqal_Intiqal_KhataJat(IntiqalKhataRecId);
                string spWithParam = "WEB_SP_DELETE_Intiqal_Intiqal_KhataJat  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId + "";
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            /// <summary>
            /// Deletes register Haqdaran khat Id
            /// </summary>
            /// <param name="IntiqalKhataRecId"></param>
            public void DeleteRegisterHaqdaranKhattaByKhataId(string KhataId)
            {
                //DataContext.WEB_SP_DELETE_Intiqal_Intiqal_KhataJat(IntiqalKhataRecId);
                string spWithParam = "WEB_SP_DELETE_HaqdaranZameenKhatajat_NewKhataTaqseem  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataId + "";
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            /// <summary>
            /// Deletes Intiqal seller record 
            /// </summary>
            /// <param name="IntiqalSellerRecId"></param>
            public DataTable DeleteIntiqalSeller(string IntiqalSellerRecId)
            {

                string spWithParam = "WEB_SP_DELETE_Intiqal_Sellers  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalSellerRecId;
               return dbobject. filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable DeleteIntiqalSellerAllBYKhata(string IntiqalKhataRecId)
            {

                string spWithParam = "WEB_SP_DELETE_Intiqal_Sellers_All_By_Khata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhataRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            /// <summary>
            /// Deletes Intiqal Buyer record
            /// </summary>
            /// <param name="IntiqalBuyerRecId"></param>
            public void DeleteIntiqalBuyer(string IntiqalBuyerRecId)
            {
                //DataContext.WEB_SP_DELETE_Intiqal_Buyers(IntiqalBuyerRecId);
                string spWithParam = "WEB_SP_DELETE_Intiqal_Buyers  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalBuyerRecId + "";
                dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

        /// <summary>
        /// Deletes Intiqal Khatooni Entry
        /// </summary>
        /// <param name="IntiqalKhanakashtKhatooniRecId"></param>
            public void DeleteIntiqalKhanakashtKhatooni(string IntiqalKhanakashtKhatooniRecId)
            {
                string spWithParam = "WEB_SP_DELETE_Intiqal_KhanaKasht_Khatooni  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalKhanakashtKhatooniRecId + "";
                dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            #endregion

         #region Intiqal Tasdiq Date and Time Assignment

            public string SaveIntiqalTasdiqDate(string VistingPlanId, string TehsilId, string TokenId, string UserId, string IntiqalId, string VisitingDateTime, string VisitingStatus, string Remarks,  string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
            {
                string spWithParam = "WEB_SP_INSERT_SDC_Intiqal_VisitingPlan " + VistingPlanId + ", " + TehsilId + ", " + TokenId + ", " + UserId + ", " + IntiqalId + ", '" + VisitingDateTime + "', " + VisitingStatus + ", N'" + Remarks + "', " + InsertUserId + ", '" + InsertLoginName + "'," + UpdateUserId + ", '" + UpdateLoginName + "' ";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

         #endregion

            #region Get Message Text By Intiqal Id

            public string GetIntiqalMessageText( string IntiqalId,  string IntiqalType)
            {
                string spWithParam = "Proc_Get_SDC_Intiqal_MessageText  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ", '" + IntiqalType + "' ";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

            #region Get Visitor Contact No  By Intiqal Id

            public DataTable GetVisitorConactByIntiqalId(string IntiqalId)
            {
                string spWithParam = "Proc_Get_SDC_VisitorContact_By_IntiqalId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            #endregion

            #region GET Intiqal Validity


            public string GetIntiqalSellerBuyerAreaCheck(string IntiqalId)
            {

                string spWithParam = "Proc_Self_Check_Intiqal_Buyer_Seller_Area  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string ChecIntiqalEnteredTaxReceived(string TokenId)
            {
                string spWithParam = "Proc_Self_Check_Intiqal_Taxes_Received  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string ChecIntiqalTaxVsPayment(string IntiqalId)
            {
                string spWithParam = "Proc_Self_Check_Intiqal_Tax_Vs_Payment_YesNo  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string ChecIntiqalReceiptVsPayment(string IntiqalId)
            {
                string spWithParam = "Proc_Self_Check_Intiqal_Receipt_Vs_Payment_YesNo " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string ChecIntiqalPaymentVerified(string IntiqalId)
            {
                string spWithParam = "Proc_Self_Check_Intiqal_Payment_Verified_YesNo  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string GetIntiqalTaqdeeqDateStatus(string IntiqalId)
            {
                //string spWithParam = "Proc_Self_Get_Intiqal_Visiting_Date " + IntiqalId;
                string spWithParam = "Proc_Self_Get_Intiqal_Validity_For_Dawra  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string GetIntiqalVisitingPlanYesNo(string IntiqalId)
            {

                string spWithParam = "Proc_Self_Intiqal_VisitingPlane_YesNo " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string GetIntiqalWitnessYesNo(string IntiqalId)
            {

                string spWithParam = "Proc_Self_Intiqal_Witness_YesNo  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string GetIntiqalPersonsImagesYesNo(string IntiqalId)
            {

                string spWithParam = "Proc_Self_Intiqal_PersonImages_YesNo  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string GetIntiqalVisitingPlanNos(string VisitingDate)
            {

                string spWithParam = "Proc_Self_Intiqal_VisitingPlane_Nos " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + "'" + VisitingDate + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string GetIntiqalGainTaxStatus(string IntiqalId)
            {
               // string spWithParam = "Proc_Self_Get_Intiqal_Validity_of_Taxes_For_Dawra " + IntiqalId;
                string spWithParam = "Proc_Self_Get_Intiqal_Validity_of_GainTax_For_Dawra  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string GetFardKhataUpdateValidity(string KhataRecId)
            {
                // string spWithParam = "Proc_Self_Get_Intiqal_Validity_of_Taxes_For_Dawra " + IntiqalId;
                string spWithParam = "Proc_Self_Get_Fard_Validity_For_Khata_Update  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataRecId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string GetFardKhatooniUpdateValidity(string KhataRecId)
            {
                // string spWithParam = "Proc_Self_Get_Intiqal_Validity_of_Taxes_For_Dawra " + IntiqalId;
                string spWithParam = "Proc_Self_Get_Fard_Validity_For_Khatooni_Update  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhataRecId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }


            public string GetIntiqalDawraDateValidity(string IntiqalId, string VisitingDateTime)
            {
                string spWithParam = "Proc_Self_Get_Dawra_Date_Validity  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ", '" + VisitingDateTime + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string CheckIntiqalGainTax(string IntiqalId)
            {
                string spWithParam = "Proc_Self_Intiqal_Gain_Tax_Check  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string CheckFardGainTax(string FardTokenId)
            {
                string spWithParam = "Proc_Self_Intiqal_Gain_Tax_Check_Fard " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + FardTokenId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

            #region check registry fard in intiqal

            public string GetFardinIntiqalSellerStatus(string fardTokenId)
            {
                //string spWithParam = "Proc_Self_Get_Intiqal_Visiting_Date " + IntiqalId;
                string spWithParam = "Proc_Self_Get_Intiqal_Seller_For_Fard_Change  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fardTokenId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            #endregion

            #region MinhayeIntiqal Multiple Entries

            public string SaveIntiqalMinhayeIntiqal(string IntiqalId, string MinhayeIntiqalId)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Main_MinhayeIntiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ", " + MinhayeIntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinhayeIntiqals(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intqal_MinhayeIntiqals  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public void DeleteIntiqalMinhayeIntiqals(string MinhayeIntiqalId)
            {
                string spWithParam = "WEB_SP_DELETE_MinhayeIntiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MinhayeIntiqalId;
                 dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            #endregion


            #region Khewat Malkan Merging

            public string SaveKhewatMalkanMerginRecord(string ParentKhewatGroupFareeqId, string KhewatGroupFareeqId, string InsertUserId, string InsertLoginName)
            {
                string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqainMerging  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + ParentKhewatGroupFareeqId + ", " + KhewatGroupFareeqId + ", " + InsertUserId + ",'" + InsertLoginName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveMushteryanMerginRecord(string ParentMushteriFareeqId, string MushteriFareeqId, string InsertUserId, string InsertLoginName)
            {
                string spWithParam = "WEB_SP_INSERT_MushteriFareeqainMerging  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + ParentMushteriFareeqId + ", " + MushteriFareeqId + ", " + InsertUserId + ",'" + InsertLoginName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string DeleteKhewatGroupFareeq( string KhewatGroupFareeqId)
            {
                string spWithParam = "WEB_SP_DELETE_KhewatGroupFard  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhewatGroupFareeqId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

         #endregion
        
        #region Intiqal Verification By Revenue Officer

            public string WEB_SP_Update_Intiqal_Verification(string IntiqalId, string RoId, byte[] FingerPrint)
            {
                string lastId = "";
                SqlCommand mycomm = new SqlCommand();

                mycomm.Parameters.AddWithValue("@Tehsilid", SDC_Application.Classess.UsersManagments._Tehsilid.ToString());
                mycomm.Parameters.AddWithValue("@IntiqalId", IntiqalId);
                mycomm.Parameters.AddWithValue("@RoId", RoId);
                mycomm.Parameters.AddWithValue("@FingerPrint", (FingerPrint == null) ? (object)DBNull.Value : FingerPrint).SqlDbType = SqlDbType.Image;

                try
                {
                    lastId = dbobject.ExecStoredProcedure("WEB_SP_Update_Verify_Intiqal_ByRO", mycomm);

                }
                catch (Exception e)
                {
                    throw e;
                }
                return lastId;
            }
        #endregion

        #region Intiqal Cancellation By Revenue Officer

        public string UpdateIntiqalCancel(string IntiqalId, string RoId, byte[] FingerPrint)
        {
            string lastId = "";
            SqlCommand mycomm = new SqlCommand();

            mycomm.Parameters.AddWithValue("@Tehsilid", SDC_Application.Classess.UsersManagments._Tehsilid.ToString());
            mycomm.Parameters.AddWithValue("@IntiqalId", IntiqalId);
            mycomm.Parameters.AddWithValue("@RoId", RoId);
            mycomm.Parameters.AddWithValue("@FingerPrint", (FingerPrint == null) ? (object)DBNull.Value : FingerPrint).SqlDbType = SqlDbType.Image;

            try
            {
                lastId = dbobject.ExecStoredProcedure("WEB_SP_Update_Cancell_Intiqal_ByRO", mycomm);

            }
            catch (Exception e)
            {
                throw e;
            }
            return lastId;
        }
        #endregion

        #region Get Intiqal Minhaye Intiqal Seller hissa and raqba

        public DataTable GetIntiqalSellerHisaRaqbaMinhayeIntiqal(string IntiqalId, string IntiqalKhataId, string KhewatGroupFareeqId,  string MushteriFareeqId)
            {
                string spWithParam = "Proc_Get_Intiqal_Seller_Minhaye_Intiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + "," + IntiqalKhataId + "," + KhewatGroupFareeqId + "," + MushteriFareeqId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            #endregion

            #region Get Intiqal Intiqal Seller Status, if Allready added to sellers with existing Hissa and raqba

            public string GetIntiqalSellerStatusHisaRaqba(string PersonId, string KhewatGroupFareeqId, string MushteriFareeqId, string SellerTotalHissa)
            {
                string spWithParam = "Proc_Get_Intiqal_Seller_Status " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + PersonId + "," + KhewatGroupFareeqId + "," + MushteriFareeqId + "," + SellerTotalHissa;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

            #region Get Minhaye Intiqal Status, if Allready added to against an Intiqal

            public string GetIntiqalMinhayeIntiqalIdByKhewatGroupId(string KhewatGroupFareeqId)
            {
                string spWithParam = "Proc_Get_Intiqal_Check_MinhayeIntiqal_by_KhewatGroupFareeqId_IntiqalId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhewatGroupFareeqId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

            #region Get Minhaye Intiqal Status, if Allready added to against an Intiqal in Khanakasht

            public string GetIntiqalMinhayeIntiqalIdByMushteriFareeqId(string MushteriFareeqId)
            {
                string spWithParam = "Proc_Get_Intiqal_Check_MinhayeIntiqal_by_MushteriFareeqId_IntiqalId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MushteriFareeqId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

            #region Get Intiqal Intiqal Amaldaramad Status for Minhaye Intiqal (Dependent Intiqal)

            public string GetIntiqalAmaldaramadStatusForMinhayeIntiqal(string MinhayeIntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_Minhaye_Status  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MinhayeIntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

        #region Khatooni Bayan Mushteryan Procedures

            public DataTable GetKhatooniKhanakashtBayaByNameSearch(string MozaId, string BayaName)
            {
                string spWithParam = "Proc_Get_Khatooni_Khanakasht_Details  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ",N'" + BayaName + "'";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhatooniKhanakashtBayaRaqbaByPersonId(string BayanPersonId)
            {
                string spWithParam = "Proc_Get_Khatooni_Khanakasht_Bayan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + BayanPersonId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

        #endregion

        #region Update Person Net Raqba 

        
            public void UpdateMalakRaqbaByHissa(string KhewatGroupFareeqId, string NetHissa, string Kanal, string Marla, string Sarsai, string Sft)//, string IntiqalID, string SeqNo)
            {
                string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqein_Update_NetPart  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + KhewatGroupFareeqId + "," + NetHissa + "," + Kanal + "," + Marla + "," + Sarsai + "," + Sft;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);

            }

        #endregion

        #region Update Intiqal Main Confirm by Operator

            public bool UpdateIntiqalMainConfirmByOperator(string IntiqalId, string isConfirm)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Main_ConfirmByOperator  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + " ," + isConfirm;
                return Convert.ToBoolean(dbobject.ExecInsertUpdateStoredProcedure(spWithParam));
            }
            public string Fb_Attestation_Amaldaramad(string FbId, string AttestedBy)
            {
                string spWithParam = "Proc_EFB_Amaldaramad  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + FbId + " ,'" + AttestedBy+"'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

        #endregion

        #region Check for Intiqal Dependency before Intiqal Revert Operation

            public string CheckIntiqalDependencyBeforeRevert(string IntiqalId)
            {
                string IntiqalNo = "0";
                string spWithParam = "Proc_Intiqal_Revert_Sellers_Buyers_Dependent_Intiqal_Check  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                IntiqalNo= dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
                return IntiqalNo;
            }
            public string CheckIntiqalDependencyBeforeRevertKhanakasht(string IntiqalId)
            {
                string IntiqalNo = "0";
                string spWithParam = "Proc_Intiqal_Revert_Sellers_Buyers_Dependent_Intiqal_Check_Khanakasht  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                IntiqalNo = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
                return IntiqalNo;
            }

        #endregion

            # region "Get Deatils for Shajra"

            public string GetMutawafiHissa(string IntiqalId)
            {
                string spWithParam = "Proc_Self_Get_Intiqal_Mutawafi_Hissa  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string GetMutawafiName(string IntiqalId)
            {
                string spWithParam = "Proc_Self_Get_Intiqal_Mutawafi_Name " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ", " + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public DataTable GetWarisan(string IntiqalId)
            {
                string spWithParam = "proc_Self_Get_Intiqal_Warisan  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            # endregion

            #region Check for registry alrady Entered

            public string CheckRegAlreadyEntered(string RegNo, int Y, string mozaId)
            {
                string IntiqalNo = "0";
                string spWithParam = " Proc_Self_Get_Intiqal_on_Registry " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + RegNo + "'," + Y+"," + mozaId;
                IntiqalNo = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
                return IntiqalNo;
            }

            public string CheckRegAlreadyReceived(string RegNo, int Y, string mozaId)
            {
                string ReceivingId = "0";
                string spWithParam = "Proc_Self_Get_Registry_For_Intiqal  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + RegNo + "'," + Y + "," + mozaId;
                ReceivingId = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
                return ReceivingId;
            }

            public string CheckRegAlreadyReceivedForRecvReg(string RegNo, string Id, int Y, string MozaId, string SRID)
            {
                string RegId = "0";
                string spWithParam = "Proc_Self_Check_Registry_Received_For_RecvReg  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + RegNo + "'," + Id + "," + Y+","+MozaId+","+SRID;
                RegId = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
                return RegId;
            }
            public string GetLetterNo(string ReceivingId)
            {
                string RegId = "0";
                string spWithParam = "Proc_Self_Get_Letter_No " + ReceivingId;
                RegId = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
                return RegId;
            }

            #endregion

            #region Revert Intiqal for Nazar e Sani

            public string RevertIntiqal(string IntiqalId, string RoId, string RevertComments)
            {
                string IntiqalNo = "0";
                string spWithParam = "Proc_Intiqal_Revert_Combine  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ", " + RoId + ",N'" + RevertComments + "'";
                IntiqalNo = dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
                return IntiqalNo;
            }
            //
            #endregion
            #region Intiqal Cancel, non cancel

            public void IntiqalMarkCancelNonCancel(string IntiqalId, string Cancel, string userId)
            {
                string spWithParam = "WEB_SP_Update_Intiqal_Mark_Cancel_NonCancel  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + ", " + Cancel+"," + userId;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }
            //WEB_SP_Update_Intiqal_Mark_Cancel_NonCancel
            #endregion

            #region save khatalock documents

            //public string SaveDocumentImagesKhataLock(string KhataLockDetailId, string InitqalId, string KhataId, string PageNo, byte[] IntiqalDocImage, string action_forInserting, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
            //{
                ////int insertpagno= Convert.ToInt32(action_forInserting);
                //Database ojbdb = new Database();
                //string lastId = "";
                //SqlCommand mycomm = new SqlCommand();
                //mycomm.Parameters.AddWithValue("@IntiqalDocImageId", IntiqalDocImageId);
                //mycomm.Parameters.AddWithValue("@ActionType", Action);
                //mycomm.Parameters.AddWithValue("@IntiqalDocRecId", IntiqalDocRecId);
                //mycomm.Parameters.AddWithValue("@InitqalId", InitqalId);
                //mycomm.Parameters.AddWithValue("@IntiqalDocId", IntiqalDocId);
                //mycomm.Parameters.AddWithValue("@IntiqalDoc_PageNo", PageNo);
                //mycomm.Parameters.AddWithValue("@IntiqalDocImage", IntiqalDocImage);

                //mycomm.Parameters.AddWithValue("@insertatpageno", action_forInserting);

                //mycomm.Parameters.AddWithValue("@InsertUserId", InsertUserId);
                //mycomm.Parameters.AddWithValue("@InsertLoginName", InsertLoginName);
                //mycomm.Parameters.AddWithValue("@UpdateUserId", UpdateUserId);
                //mycomm.Parameters.AddWithValue("@UpdateLoginName", UpdateLoginName);
                //try
                //{
                //    lastId = ojbdb.ExecStoredProcedure("WEB_SP_INSERT_Intiqal_DocumentImages", mycomm);

                //}
                //catch (Exception e)
                //{
                //    throw e;
                //}
                //return lastId;
            //}

            #endregion

            #region Approval of Gardawar
            public string UpdateIntiqalApprovalStatusGardawar(string TokenId, string Token_CurrentStatus, string Token_CurrentStatus_Reason, string GardawarId)
            {
                string lastId = "";
                string spWithParams = "WEB_SP_UPDATE_SDC_TokenStatus_Gardawar  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId + ",N'" + Token_CurrentStatus + "',N'" + Token_CurrentStatus_Reason + "', " + GardawarId;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParams);
                return lastId;
            }
        #endregion

        #region Intiqal Enable Disable Operations

            public string IntiqalEnableDisable(string IntiqalId, string UpdateMode, string UpdateType, string Comments)
            {
                string spWithParam = "Web_Sp_Update_Intiqal_Amal_Attestation  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + " ,'" + UpdateMode+"','"+UpdateType+"',N'"+Comments+"',"+Classess.UsersManagments.UserId.ToString()+",'"+Classess.UsersManagments.UserName+"'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

        #endregion
        //Proc_Intiqal_Revert_By_Khata
             #region Intiqal Revert by Khata

            public string IntiqalRevertByKhata(string IntiqalId, string IntiqalKhataRecId, string Comments)
            {
                string spWithParam = "Proc_Intiqal_Revert_By_Khata  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + IntiqalId + " ," + IntiqalKhataRecId + ",N'" + Comments + "'," + Classess.UsersManagments.UserId.ToString() + ",'" + Classess.UsersManagments.UserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string GetRegFardDispatchStatus(string tokenId, string DispatchId)
            {

                string spWithParam = "Proc_Self_Check_RegFard_Sent_YesNo " + tokenId + "," + DispatchId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string CheckShortFardReceiptVerified(string TokenId, string UserId)
            {
                string spWithParam = "Proc_Self_Check_ShortFard_Receipt_Verified_YesNo " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId + "," + UserId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string CheckFardReceiptVerified(string TokenId, string UserId)
            {
                string spWithParam = "Proc_Self_Check_Fard_Receipt_Verified_YesNo " + TokenId + "," + UserId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public DataTable GetNonTransactionalFard(string TokenNo, string dt)
            {
                string spWithParam = "Proc_Self_Get_Non_Transactional_Fard " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenNo + ", '" + dt + "'";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetNonTransactionalFardForOtherDistTehsil(string TehsilId , string TokenId)
            {
                string spWithParam = "proc_Self_Get_Non_Transactional_Fard_For_OtherDistTehsils " + TehsilId + "," + TokenId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public string WEB_Self_SP_INSERT_ShortFard_Khattajat_KhewatGroupFareeqein( string fardpersonrecid, string fardKhataRecid, string TokenId, string RegisterHqDKhataId, string TotalParts, string Khata_kanal, string Khata_marla, string Khata_sarsai, string Khata_feet, string @PersonId, string @KhewatGroupFareeqId, string Hissa, string kanal, string marla, string sarsai, string feet, string KhewatTypeId, string UserID, string UserName)
            {
                string spWithParam = "WEB_Self_SP_INSERT_ShortFard_Khattajat_KhewatGroupFareeqein " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + fardpersonrecid + "','" + fardKhataRecid + "','" + TokenId + "'," + RegisterHqDKhataId + "," + TotalParts + "," + Khata_kanal + "," + Khata_marla + "," + Khata_sarsai + "," + Khata_feet + "," + @PersonId + "," + @KhewatGroupFareeqId + "," + Hissa + "," + kanal + "," + marla + "," + sarsai + "," + feet + "," + KhewatTypeId + "," + UserID + ",'" + UserName + "'"; 
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string WEB_Self_SP_INSERT_ShortFard_Fareeqain_Hissa_Raqba_Muntaqla_Update(string fardpersonrecid, string fardMushtriRecid, string TotalParts, string kanal, string marla, string sarsai, string feet, string UserId, string UserName)
            {
                string spWithParam = "WEB_Self_SP_INSERT_ShortFard_Fareeqain_Hissa_Raqba_Muntaqla_Update " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + fardpersonrecid + "','" + fardMushtriRecid + "','" + TotalParts + "'," + kanal + "," + marla + "," + sarsai + "," + feet + "," + UserId + ",'" + UserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string WEB_Self_SP_INSERT_ShortFard_Khattajat_KhewatGroupFareeqeinForOtherDistTehsil(string TehsilId, string fardpersonrecid, string fardKhataRecid, string TokenId, string RegisterHqDKhataId, string TotalParts, string Khata_kanal, string Khata_marla, string Khata_sarsai, string Khata_feet, string @PersonId, string @KhewatGroupFareeqId, string Hissa, string kanal, string marla, string sarsai, string feet, string KhewatTypeId, string UserID, string UserName)
            {
                string spWithParam = "WEB_Self_SP_INSERT_ShortFard_Khattajat_KhewatGroupFareeqein " + TehsilId + ",'" + fardpersonrecid + "','" + fardKhataRecid + "','" + TokenId + "'," + RegisterHqDKhataId + "," + TotalParts + "," + Khata_kanal + "," + Khata_marla + "," + Khata_sarsai + "," + Khata_feet + "," + @PersonId + "," + @KhewatGroupFareeqId + "," + Hissa + "," + kanal + "," + marla + "," + sarsai + "," + feet + "," + KhewatTypeId + "," + UserID + ",'" + UserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string WEB_Self_SP_INSERT_ShortFard_Khattajat_Khatoonies_MushtriFareeqein(string fardMushtriRecid, string fardKhatoonirecId, string fardKhataRecid, string TokenId, string RegisterHqDKhataId, string TotalParts, string Khata_kanal, string Khata_marla, string Khata_sarsai, string Khata_feet, string KhatooniId, string Khatooni_Hissa, string Khatooni_kanal, string Khatooni_marla, string Khatooni_sarsai, string Khatooni_feet, string @PersonId, string @MushtriFareeqId, string Hissa, string kanal, string marla, string sarsai, string feet, string KhewatTypeId, string UserID, string UserName)
            {
                string spWithParam = "WEB_Self_SP_INSERT_ShortFard_Khattajat_Khatoonies_MushtriFareeqein  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + ",'" + fardMushtriRecid + "','" + fardKhatoonirecId + "','" + fardKhataRecid + "','" + TokenId + "'," + RegisterHqDKhataId + "," + TotalParts + "," + Khata_kanal + "," + Khata_marla + "," + Khata_sarsai + "," + Khata_feet + "," + KhatooniId + "," + Khatooni_Hissa + "," + Khatooni_kanal + "," + Khatooni_marla + "," + Khatooni_sarsai + "," + Khatooni_feet + "," + @PersonId + "," + @MushtriFareeqId + "," + Hissa + "," + kanal + "," + marla + "," + sarsai + "," + feet + "," + KhewatTypeId + "," + UserID + ",'" + UserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string WEB_Self_SP_INSERT_ShortFard_Khattajat_Khatoonies_MushtriFareeqeinForOtherDistTehsils(string TehsilId, string fardMushtriRecid, string fardKhatoonirecId, string fardKhataRecid, string TokenId, string RegisterHqDKhataId, string TotalParts, string Khata_kanal, string Khata_marla, string Khata_sarsai, string Khata_feet, string KhatooniId, string Khatooni_Hissa, string Khatooni_kanal, string Khatooni_marla, string Khatooni_sarsai, string Khatooni_feet, string @PersonId, string @MushtriFareeqId, string Hissa, string kanal, string marla, string sarsai, string feet, string KhewatTypeId, string UserID, string UserName)
            {
                string spWithParam = "WEB_Self_SP_INSERT_ShortFard_Khattajat_Khatoonies_MushtriFareeqein  " + TehsilId + ",'" + fardMushtriRecid + "','" + fardKhatoonirecId + "','" + fardKhataRecid + "','" + TokenId + "'," + RegisterHqDKhataId + "," + TotalParts + "," + Khata_kanal + "," + Khata_marla + "," + Khata_sarsai + "," + Khata_feet + "," + KhatooniId + "," + Khatooni_Hissa + "," + Khatooni_kanal + "," + Khatooni_marla + "," + Khatooni_sarsai + "," + Khatooni_feet + "," + @PersonId + "," + @MushtriFareeqId + "," + Hissa + "," + kanal + "," + marla + "," + sarsai + "," + feet + "," + KhewatTypeId + "," + UserID + ",'" + UserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string WEB_Self_SP_DELETE_ShortFard_Record(string fardpersonrecId, string FardMushteriRecId, string fardKhataRecId, string FardKhatooniRecId)
            {
                string spWithParam = "WEB_Self_SP_DELETE_ShortFard_Record " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + fardpersonrecId + "," + FardMushteriRecId + "," + fardKhataRecId + "," + FardKhatooniRecId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

        #endregion
    }
    }
