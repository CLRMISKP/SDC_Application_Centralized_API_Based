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
            string spWithParam = "Proc_Get_Intiqal_Zeretajwiz_Pending_By_Khatta " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetIntiqalPenginKharijByKhata(string KhataId)
        {
            string spWithParam = "Proc_Get_Intiqal_PendingKharij_By_Khatta " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetIntiqalAmalDaramadShodaByKhata(string KhataId)
        {
            string spWithParam = "Proc_Get_Intiqal_AmaldaramadShoda_By_Khatta " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetKhataNoByChildKhataId(string KhataId)
        {
            string spWithParam = "Proc_Get_Khata_By_Child_KhataId " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetKhewatFareeqeinGroupByKhataPrevious(string KhataId)
        {
            string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata_Previous " + KhataId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        #endregion

        #region Inteqal Repository Members

        public DataTable Proc_Get_KhassaAreaByKhatooniId(string khatooniid)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "Proc_Get_KhassaAreaByKhatooniId " + khatooniid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }

        public void DeleteIntiqalWitness(string IntiqalWitnessId)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "WEB_SP_DELETE_Intiqal_Witness " + IntiqalWitnessId;
            dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);

        }

        public DataTable SearchKhassraByKhassraNo( string MozaId, string KhassraNo)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "Proc_Get_Search_Khassra_ByKhassraNo_SDC " + KhassraNo+","+MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_KhassrasTotalArea_By_KhataId(string khataid)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "Proc_Get_KhassrasTotalArea_By_KhataId " + khataid;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable Proc_Get_Searched_Afrad_With_Family_Head(string Mozaid,string personame)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "Proc_Get_Searched_Afrad_With_Family_Head " + Mozaid + ",N'"+personame+"'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
         public DataTable GetSearchedPersonListforAllMouzas(string PersonName,string FatherName, string MozaId)//, string IntiqalID, string SeqNo)
        {
            string spWithParam = "Proc_Get_SearchPersonslistforAllMozas N'" + PersonName + "',N'"+FatherName+"',"+MozaId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable DeltefromRequiredDucoments(string IntiqalDOcId, string IntiqalID,string SeqNo)
        {
            string spWithParam = "WEB_SP_DELETE_Intiqal_DucomentsRequired '" + IntiqalDOcId + "','" + IntiqalID + "','" + SeqNo + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetCamFingerImage(string IntiqalId,string PersonId)
        {
            string spWithParam = "Proc_Get_Intiqal_PersonBothPics '" + IntiqalId + "','" + PersonId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetInsetedDocIamges(string IntiqalDocRecId)
        {
            string spWithParam = "Proc_Get_Intiqal_DocumentImages '" + IntiqalDocRecId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetIntiqalDocuments_RequiredforScanning(string IntiqalId)
        {
            string spWithParam = "proc_Get_Intiqal_DocumentsRequired " + IntiqalId;
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
            public DataTable GetIntiqalBankChallanByIntiqalId(string IntiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_BankChallan_List_By_IntiqalId " + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
           
            }

            public DataTable GetIntiqalBankChallanSinSaveintiqalMaingleByChallanId(string ChallanId)
            {
                string spWithParam = "proc_Get_Intiqal_BankChallan_Single " + ChallanId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalBuyersByIntiqalKhataRecId(string IntiqalKhataRecId, string IntiqalKhatooniRecid, string Malkiat)
            {
                string spWithParam = "proc_Get_Intiqal_Buyers " + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + " "; 
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalBuyersByKhataRecordId(string IntiqalKhataRecId, string IntiqalKhatooniRecid, string Malkiat)
            {
                string spWithParam = "proc_Get_Intiqal_Buyers_List_ByKhata " + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat +" "; 
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetIntiqalBuyersAmaldaramad(string IntiqalKhataRecId, string IntiqalKhatooniRecid, string Malkiat)
            {
                string spWithParam = "proc_Get_Intiqal_Buyers_List_Amaldaramad " + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + " ";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalSellersDependency(string IntiqalKhataId, string IntiqalKhataRecId, string IntiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_Sellers_Dependecy_ByKhata " + IntiqalKhataId + "," + IntiqalKhataRecId+","+IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable Proc_Get_Intiqal_TehsilDar_Report(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_TehsilDar_Report " + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetIntiqalFeeListByIntiqalId(string IntiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_Fees_List_By_IntiqalId " + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable DeleteMinKhasra(string IntiqalMinKhassraRecId)
            {
                string spWithParam = " WEB_SP_DELETE_Intiqal_Min_Khassra " + IntiqalMinKhassraRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable DeleteMinFareeq(string IntiqalMinFareeq)
            {
                string spWithParam = " WEB_SP_DELETE_Intiqal_Min_Fareeq " + IntiqalMinFareeq;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetIntiqalFeesSingleByFeesId(string FeesId)
            {
                string spWithParam = "proc_Get_Intiqal_Fees_Single " + FeesId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

            }

            public DataTable GetIntiqalFeesTypes()
            {
                string spWithParam = "proc_Intiqal_FeeTypes_List ";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalInitiationList()
            {
                string spWithParam = "proc_Intiqal_Initiation_List ";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalKhataJaatListByIntiqalId(string IntiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_KhataJat_List_By_IntiqalId_With_Khata_Amal " + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

           

            public DataTable GetintiqalMainByIntiqalId(string IntiqalId)
            {
                string spWithParam = "proc_Get_Intiqal_Main_SDC " + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalMainByIntiqalIdMozaId(string MozaId, string IntiqalNo)
            {
                string spWithParam = "proc_Get_Intiqal_Main_By_MozaId_By_IntiqalNo_SDC " + MozaId + ", " + IntiqalNo +"";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalMainListByMozaId(string MozaId)
            {
                string spWithParam = "proc_Get_Intiqal_Main_By_MozaId_SDC " + MozaId; 
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalNoListByMozaId(string MozaId)
            {
                string spWithParam = "proc_Get_IntiqalNo_List_By_MozaId " + MozaId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalMainListByMozaId(string MozaId, string IntiqalNo)
            {
                string spWithParam = "proc_Get_Intiqal_Main_By_MozaId_By_IntiqalNo_SDC " + MozaId+","+IntiqalNo; 
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetintiqalSellersBySellerRecId(string SellerRecId)
            {
                string spWithParam = "proc_Get_Intiqal_Sellers " + SellerRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

                            }

            //fill grid on load ,on save on delete on update in frm intiqalRegister
            public DataTable GetintiqalSellersListByKhataRecId(string IntiqalKhataRecId, string IntiqalKhatooniRecid, string Malkiat)
            {
                string spWithParam = "proc_Get_Intiqal_Sellers_List_ByKhata " + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            //Get Intiqal Sellers from Khewat Group Fareqain and MustheriFareeqain after intiqal Amaldaramad
            public DataTable GetintiqalSellersListAfterAmaldaramad(string IntiqalKhataRecId, string IntiqalKhatooniRecid, string Malkiat)
            {
                string spWithParam = "proc_Get_Intiqal_Sellers_List_Amaldaramad " + IntiqalKhataRecId + "," + IntiqalKhatooniRecid + "," + Malkiat + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            //fill Combobox in frmInteqalRegister
            public DataTable GetIntiqalKhataMalikanByKhataId(string KhataId)
            {
                string spWithParam = "proc_Get_Intiqal_Khata_Malkan " + KhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhataMalikanByKhataIdWithLogs(string KhataId)
            {
                string spWithParam = "proc_Get_Khata_Malkan_With_Logs " + KhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalKhanaKasht(string KhatooniId)
            {
                string spWithParam = "proc_Get_Intiqal_KhanaKashtKhatooni_Malkan " + KhatooniId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetintiqalTypes()
            {
                string spWithParam = "proc_Intiqal_Type_List ";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetMozaFamilyListByMozaId(string MozaId)
            {
                string spWithParam = "Proc_Get_Moza_Families_List " + MozaId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetMozaFamilyListByFamilyId(string familyid)
            {
                string spWithParam = "Proc_Get_FamilyPersons_List " + familyid;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalMainReports(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_Main_Reports " + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhataJatForintiqalByMozaId(string MozaId)
            {
               string spWithParam = "proc_Get_Moza_KhataJat_for_Intiqal " +MozaId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhatoniDetails(string IntiqalKhataRecId)
            {
                string spWithParam = "proc_Get_Intiqal_Khatoonies_List_By_KhattaRecId " + IntiqalKhataRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
        //public DataTable GetKhatoniDetails(string KhatoniRecid)
        //    {
        //        string spWithParam = "proc_Get_Moza_KhataJat_for_Intiqal " + KhatoniRecid;
        //        return dbobject.filldatatable_from_storedProcedure(spWithParam);
        //    }
            public string SaveintiqalBankChallan(string BankChalanId, string IntiqalId, string BankChallanNo, string BankChallanDate, string BankName, string BranchName, string ChallanAmount, string userid)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_BankChallan " + BankChalanId + "," + IntiqalId + "," + BankChallanNo + ",'" + BankChallanDate + "','" + BankName + "','" + BranchName + "'," + ChallanAmount + "," + userid;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string SaveintiqalKhatoni(string IntiqalKhatooniRecId, string intiqalId, string IntiqalKhataRecId, string IntiqalKhataId, string KhatoniId, string UserID,string UserName)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_KhanaKasht_Khatooni '" + IntiqalKhatooniRecId + "'," + intiqalId + "," + IntiqalKhataRecId + "," + IntiqalKhataId + "," + KhatoniId + "," + UserID + ",'" + UserName + "'," + UserID + ",'" + UserName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string SaveintiqalBuyers(string BuyerRecId, string IntiqalKhataRecId,string KhatoniRecid, string BuyerPersonId, string Hissa, string Kanal, string Marla, string Sarsai, string Feet, string KhewatTypeId, string BuyeraHisaBata)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Buyers_WithBata " + BuyerRecId + "," + IntiqalKhataRecId + "," + KhatoniRecid + "," + BuyerPersonId + "," + Hissa + "," + Kanal + "," + Marla + "," + Sarsai + "," + Feet + "," + KhewatTypeId + ",'" + BuyeraHisaBata + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveintiqalFees(string FeesId, string IntiqalId, string FeesTypeId, string IntiqalFeesAmount)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Fees " + FeesId + "," + IntiqalId + "," + FeesTypeId + "," + IntiqalFeesAmount;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveintiqalKhataJaat(string KhataRecId, string IntiqalId, string IntiqalKhataId)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_KhataJat " + KhataRecId + "," + IntiqalId + "," + IntiqalKhataId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveintiqalMain(string IntiqalId, string MozaId, string KhanaMalikat, string KhanaKasht,string khanakashtmalkiat, string IntiqalNo, string HawalaNo, string IntiqalTypeId, string InitiationId, string AndrajDate, string RapatNo, string RapatDate, string AmaldarDate, string LandValue, string IntiqalAttestationDate, string IntiqalReferenceNo, string LandTypeId, string LandValuationTableCost, string DegreeDate, string CourtName, string MisalNo, string otherDetails, string userid, string userName, string TokenId, string PlotTypeId, string PlotConstrTypeId, string PlotTerritoryTypeId, string LastIntiqalDate, string MinhayeIntiqalId)
            {
                //string KhanaMalikat1=Convert.ToString(KhanaMalikat);
                // string KhanaMalikat1=Convert.ToString(KhanaKasht);
                string spWithParam = "WEB_SP_INSERT_Intiqal_Main_SDC " + IntiqalId + "," + MozaId + ", " + KhanaMalikat + ", " + KhanaKasht + "," + khanakashtmalkiat + " ," + IntiqalNo + ", " + HawalaNo + "," + IntiqalTypeId + ", " + InitiationId + ", '" + AndrajDate + "', " + RapatNo + ",'" + RapatDate + "', '" + AmaldarDate + "'," + LandValue.ToString() + ", '" + IntiqalAttestationDate + "'," + IntiqalReferenceNo + ", " + LandTypeId + ", " + LandValuationTableCost + ", '" + DegreeDate + "', N'" + CourtName + "', " + MisalNo + ",N'" + otherDetails + "', " + userid + ", '" + userName + "', " + TokenId + ", " + PlotTypeId + ", " + PlotConstrTypeId + ", " + PlotTerritoryTypeId + ", '" + LastIntiqalDate + "',"+MinhayeIntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveintiqalSellers(string SellerRecId, string KhataRecId, string SellerPersonId, string isDead, string DeathDate, string TotalHissa, string TotalKanal, string TotalMarla, string TotalSarsai, string TotalFeet, string SoldHissa, string SoldKanal, string SoldMarla, string SoldSarsai, string SoldFeet, string khewatgroupfareeqid,string MustriFareeq,string KhatoniRecid)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Sellers " + Convert.ToInt32(SellerRecId) + ", " + KhataRecId + ", " + SellerPersonId + ", " + isDead + ", '" + DeathDate + "', " + TotalHissa + ", " + TotalKanal + ", " + TotalMarla + ", " + TotalSarsai + ", " + TotalFeet + ", " + SoldHissa + ", " + SoldKanal + ", " + SoldMarla + ", " + SoldSarsai + ", " + SoldFeet + ", " + khewatgroupfareeqid + "," + MustriFareeq + "," + KhatoniRecid + " ";
             return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }

            public string SaveSalamJuzviKhassraDetail(string SalamJuzviKhassraId,string KhassraId, string KhassraDetailId, string Min_KhassraNo,string MinType,string KhatooniId,string IntiqalKhataRecId,string IntiqalKhatoonirecId,string Min_Kanal,string Min_Marla,string Min_Sarsai,string Min_Feet,string AreaTypeId,string MozaId,string UserId,string LoginName	)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Juzvi_Khassra " + SalamJuzviKhassraId + ", " + KhassraId + "," + KhassraDetailId + ", N'" + Min_KhassraNo + "', N'" + MinType + "', " + KhatooniId + ", " + IntiqalKhataRecId + ", " + IntiqalKhatoonirecId + ", " + Min_Kanal + ", " + Min_Marla + ", " + Min_Sarsai + ", " + Min_Feet + ", " + AreaTypeId + ", " + MozaId + ", " + UserId + ",'" + LoginName + "' ";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }

            public string SaveIntiqalOperatorNote(string IntiqalId, string OperatorNote)
            {
                string spWithParam = "WEB_SP_UPDATE_Intiqal_Main_OperatorReport " + IntiqalId + ", N'" + OperatorNote + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }

            public DataTable GetInteqalTypesCategoriesList()
            {
               string spWithParam = "Proc_Get_IntiqalTypeCategoroies " ;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalSalamJuzviKhassra(string IntiqalKhataRecId)
            {
                string spWithParam = "Proc_Get_Intiqal_Juzvi_Salam_Khassra "+IntiqalKhataRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);

            }
            public DataTable GetIntiqalSalamJuzviKhassraByKhatooni(string IntiqalKhatooniRecId)
            {
                string spWithParam = "Proc_Get_Intiqal_Juzvi_Salam_Khassra_ByKhatooni " + IntiqalKhatooniRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhassrasByKhatoniMutation(string KhatooniId)
            {
                string spWithParam = "Proc_Get_Khatooni_KhassraArea_Detail_Mut " +KhatooniId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhassrasByKhatoni(string KhatooniId)
            {
                string spWithParam = "Proc_Get_Khatooni_KhassraArea_Detail " + KhatooniId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable SearchKhassraByKhassraNoMozaId(string KhassraNo, string MozaId)
            {
                string spWithParam = "Proc_Get_Search_Khassra_ByKhassraNo_SDC " + KhassraNo + "," + MozaId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }


            public string SaveKhassraMalikGroup(string KhassraMalikRecId, string KhassraId, string BuyerPersonId, string MozaId, string IntiqalId)
            {
                string spWithParam = "WEB_SP_INSERT_KhassraMalikGroup "+ KhassraMalikRecId+", "+KhassraId+", "+BuyerPersonId+", "+MozaId+", "+IntiqalId+"";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }


            public DataTable GetKhassraIntiqalBuyers(string IntiqalId)
            {
                 string spWithParam = "Proc_Get_KhassraInteqalBuyers " + IntiqalId;
             
                 return dbobject.filldatatable_from_storedProcedure(spWithParam);
             
            }


            public DataTable IntiqalAmalDaramad(string mozaid,string IntiqalId)
            {
                //string s = DataContext.Proc_Intiqal_Amaldaramad(stringiqalId).FirstOrDefault().ToString();
                //return s;
                string spWithParam = "proc_Intiqal_Amaldaramad_Combine_Taqseem " + mozaid + "," + IntiqalId + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public string IntiqalAmalDaramadByKhataIdSingle( string IntiqalId, string IntiqalKhataId, string userId, string userName)
            {

                string spWithParam = "Proc_Intiqal_Amaldaramad_By_KhataId_Single " + IntiqalId + "," + IntiqalKhataId + ","+userId+",'"+userName+"'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public DataTable KhewatGroupFareeqainAll(string KhataId)
            {
                string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata_All_RecStatus " + KhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable KhewatGroupFareeqByKhataIdPersonId(string KhataId, string PersonId)
            {

                string spWithParam = "Proc_Get_KhewatFareeqeinGroup_By_Khata_By_PersonId " + KhataId+","+PersonId;
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
                string spWithParam = "proc_Get_Intiqal_Sellers_Remaining_Hissa_Check " + intiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }


            public DataTable GetIntiqalMinGroup(string IntiqalId, string IntiqalKhataId, string IntiqalKhatooniRecId)
            {
                //string spWithParam = "Proc_Get_Intiqal_MinGroupsList " +
                   string spWithParam = "Proc_Get_Intiqal_MinGroupsList " +IntiqalId+","+IntiqalKhataId+", "+IntiqalKhatooniRecId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinMalikanList(string IntiqalKhataRecId, string MalikanType, string IntiqalId)
            {
                //string spWithParam = "Proc_Get_Intiqal_MinGroupsList " +
                string spWithParam = "Proc_Get_IntiqalMin_MalkanList " + IntiqalKhataRecId + "," + MalikanType + "," + IntiqalId + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinMushteryanList(string IntiqalKhatooniId, string MalikanType, string IntiqalId)
            {
                //string spWithParam = "Proc_Get_Intiqal_MinGroupsList " +
                string spWithParam = "Proc_Get_IntiqalMin_MalkanList_Khanakasht " + IntiqalKhatooniId + "," + MalikanType + "," + IntiqalId + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinGroupDetails(string IntiqalMinGroupId)
            {
                string spWithParam = "Proc_Get_Intiqal_MinGroup_Detail " +IntiqalMinGroupId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);  
            }


            public DataTable GetInsertedDocumentsImage(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_DocumentImages " + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);  
            }


            public DataTable GetIntiqalMinFareeqain(string IntiqalId, string IntiqalMinGroupId)
            {
               string spWithParam = "Proc_Get_Intiqal_MinFareeqein '"+IntiqalId+"','"+IntiqalMinGroupId+"'";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public string SaveDocumentImages(string IntiqalDocImageId,string Action, string IntiqalDocRecId, string InitqalId, string IntiqalDocId, string PageNo, byte[] IntiqalDocImage,string action_forInserting, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
            {
                //int insertpagno= Convert.ToInt32(action_forInserting);
                Database ojbdb = new Database();
                string lastId = "";
                SqlCommand mycomm = new SqlCommand();
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

            public string SaveIntiqalMinGroup(string IntiqalMinGroupId, string IntiqalId, string IntiqalMinOldKhataId, string IntiqalMinGroupNo, string IntiqalMinKhattaNo, string IntiqalMinOldKhatooniId, string IntiqalMinKhatooniRecId, string IntiqalMinKhatooniNo, string IntiqalMin_TotalParts, string IntiqalMin_Kanal, string IntiqalMin_Marla, string IntiqalMin_Sarsai, string IntiqalMin_Feet, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName, string MozaId)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_MinGroup " + IntiqalMinGroupId + ", " + IntiqalId + ", " + IntiqalMinOldKhataId + ", '" + IntiqalMinGroupNo + "', '" + IntiqalMinKhattaNo + "', '" + IntiqalMinOldKhatooniId + "', " + IntiqalMinKhatooniRecId + ", '" + IntiqalMinKhatooniNo + "', " + IntiqalMin_TotalParts + ", " + IntiqalMin_Kanal + ", " + IntiqalMin_Marla + ", " + IntiqalMin_Sarsai + ", " + IntiqalMin_Feet + ", " + InsertUserId + ", '" + InsertLoginName + "'," + UpdateUserId + ", '" + UpdateLoginName + "', " + MozaId + "";
                 return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
        //first
            public string SaveKhewatGrouFreeqein(string IntiqalMinKhewatFareeqId, string KhewatGroupId, string PersonId, string FardAreaPart, string FardKanal, string FardMarla, string FardSarsai, string FardFeet,string KhewatTypeId, string RegisterHDQKhataId, string Insertuserid,string Darno,string TotalDarPart,string PersonDarPart,string ofdarPart,string InsertLoginName,string FardpartBhata)
            {
                string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqein " + IntiqalMinKhewatFareeqId + ", " + KhewatGroupId + ", " + PersonId + ", " + FardAreaPart + ", " + FardKanal + ", " + FardMarla + ", " + FardSarsai + ", " + FardFeet + ", " + KhewatTypeId + ", " + RegisterHDQKhataId + ", " + Insertuserid + ", " + Darno + ", " + TotalDarPart + ", " + PersonDarPart + ", " + ofdarPart + ", " + InsertLoginName + "," + FardpartBhata + "";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
        //second
            public string SaveIntiqalMinFareeqain(string IntiqalMinKhewatFareeqId, string IntiqalId, string IntiqalMinGroupId, string OldKhataId, string KhewatGroupFareeqId,string OldKhatooniId, string KhatooniRecId, string MushtriFareeqId,  string SeqNo, string KhewatTypeId, string IntiqalMinPersonId, string Intiqal_Min_Hissa, string Intiqal_Min_Kanal, string Intiqal_Min_Marla, string Intiqal_Min_Sarsai, string Intiqal_Min_Feet, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName, string MozaId)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Min_Fareeqein '" + IntiqalMinKhewatFareeqId + "', " + IntiqalId + ", '" + IntiqalMinGroupId + "', " + OldKhataId + ", " + KhewatGroupFareeqId + ", " +OldKhatooniId +", " + KhatooniRecId+", " +MushtriFareeqId +", " + SeqNo + ", " + KhewatTypeId + ", " + IntiqalMinPersonId + ", " + Intiqal_Min_Hissa.ToString() + ", " + Intiqal_Min_Kanal + ", " + Intiqal_Min_Marla + ", " + Intiqal_Min_Sarsai.ToString() + ", " + Intiqal_Min_Feet.ToString() + ", " + InsertUserId + ", '" + InsertLoginName + "', " + UpdateUserId + ",'" + UpdateLoginName + "', " + MozaId + "";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveIntiqalMinKhassra(string IntiqalMinKhassraRecId, string IntiqalId, string IntiqalMinGroupId, string OldKhattaId, string OldKhatoniId, string OldKhassraId, string MinKhassraId, string OldKhassraDetailId, string MinNo, string Min_KhassraNo, string Min_KhatooniNo, string AreaTypeId, string MIntypeId, string Min_Kanal, string Min_Marla, float Min_Sarsai, float Min_Feet, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName, string MozaId)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Min_Khassras "+IntiqalMinKhassraRecId+", "+IntiqalId+", "+IntiqalMinGroupId+", "+OldKhattaId+","+ OldKhatoniId+", "+OldKhassraId+", "+OldKhassraDetailId+", "+MinKhassraId+", '"+MinNo+"', '"+Min_KhassraNo+"', '"+Min_KhatooniNo+"', "+AreaTypeId+", "+MIntypeId+", "+Min_Kanal+", "+Min_Marla+","+ Min_Sarsai.ToString()+","+ Min_Feet.ToString()+", "+InsertUserId+", '"+InsertLoginName+"', "+UpdateUserId+", '"+UpdateLoginName+"', "+MozaId+"";
                 return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public void SaveIntiqalMainReports(string IntiqalId, string PatwariReport, string PatwariReport_Date, string GardawarReport, string GardawarReport_Date, string TehsildarReport, string TehsildarReport_Date, string UpdateUserId)
            {
                string spWithParam = "WEB_SP_UPDATE_Intiqal_Main_Reports " + IntiqalId + ",N'" + PatwariReport + "', '" + PatwariReport_Date + "', N'" + GardawarReport + "', '" + GardawarReport_Date + "', N'" + TehsildarReport + "', '" + TehsildarReport_Date + "',"+UpdateUserId;
                 dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public DataTable GetIntiqalMalikanList(string IntiqalKhataId, string ListType)
            {
                string spWithParam = "Proc_Get_IntiqalMin_MalkanList "+IntiqalKhataId+","+ListType+"";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinKhassraJat(string IntiqalId, string IntiqalMinGroupId)
            {
                string spWithParam = "Proc_Get_Intiqal_MinKhassraJat " +IntiqalId+","+ IntiqalMinGroupId+"";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhassraJatByKhattaId(string IntiqalKhataId)
            {
                string spWithParam = "Proc_Get_KhassraJatByKhataId " +IntiqalKhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public void SetIntiqalMinGrpTotal(string IntiqalMinGroupId)
            {
              
               string spWithParam = "Proc_Set_Intiqal_MinGroup_Totals " +IntiqalMinGroupId;               
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public string IntiqalMinAmalDaramad(string MozaId, string IntiqalId)
            {
                string spWithParam ="proc_IntiqalMin_Amaldaramad "+MozaId+", "+IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);;
            }


            public DataTable GetIntiqalMIntypes()
            {
                string spWithParam = "Proc_Get_IntiqalMintypes " ;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhewatTypes(string TehsilId)
            {
                string spWithParam = "Proc_Get_KhewatTypes " + TehsilId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            
            }


            public string IntiqalMinBadasthor(string IntiqalId, string KhataId)
            {
                string spWithParam = "Proc_IntiqalMin_BadStoor "+IntiqalId+", "+KhataId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }


            public void DeleteIntiqalMinFareeq(string IntiqalMinKhewatFareeqId)
            {
              
                               string spWithParam=" WEB_SP_DELETE_Intiqal_Min_Fareeq "+IntiqalMinKhewatFareeqId;
                               dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public void DeleteIntiqalSalamJuzviKhassra(string SalamJUzviKhasraId)
            {

                string spWithParam = " WEB_SP_DELETE_Intiqal_SalamJuzviKhassra " + SalamJUzviKhasraId;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }


            public void DeleteIntiqalMinKhassra(string IntiqalMinKhassraRecId)
            {
               // DataContext.WEB_SP_DELETE_Intiqal_Min_Khassra(stringiqalMinKhassraRecId);
                  string spWithParam=" WEB_SP_DELETE_Intiqal_Min_Khassra"+IntiqalMinKhassraRecId;
                               dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }
            public void DeleteIntiqalMinGroupByKhata(string IntiqalMinOldKhataId,string Intiqalid)
            {
                // DataContext.WEB_SP_DELETE_Intiqal_Min_Khassra(stringiqalMinKhassraRecId);
                string spWithParam = " WEB_SP_DELETE_Intiqal_Min_Group_Khata " + IntiqalMinOldKhataId+","+Intiqalid;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }
            public void DeleteIntiqalMinGroupByKhatooni(string IntiqalMinKhatooniRecId)
            {
                // DataContext.WEB_SP_DELETE_Intiqal_Min_Khassra(stringiqalMinKhassraRecId);
                string spWithParam = " WEB_SP_DELETE_Intiqal_Min_Group_Khatooni " + IntiqalMinKhatooniRecId;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }



            public void UpdateIntiqalMinFareeqHissa(string IntiqalMinKhewatFareeqId, float Intiqal_Min_Hissa, string Intiqal_Min_Kanal, string Intiqal_Min_Marla, float Intiqal_Min_Sarsai, float Intiqal_Min_Feet, string MozaId)
            {
                string spWithParam= "WEB_SP_UPDATE_Intiqal_Min_FareeqeinHissa "+IntiqalMinKhewatFareeqId+", "+Intiqal_Min_Hissa.ToString()+", "+Intiqal_Min_Kanal+", "+Intiqal_Min_Marla.ToString()+", "+Intiqal_Min_Sarsai.ToString()+", "+Intiqal_Min_Feet+","+ MozaId+"";;
               dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }


            public void SetMushtarkaRaqbaMuntiqla(string IntiqalKhataId, string MustarqaMuntiqla, string MMR_Kanal, string MMR_Marla, string MMR_Sarsai, string MMR_Feet)
            {
               string spWithParam=  "Proc_Set_Intiqal_RaqbaMutiqla '"+IntiqalKhataId+"', '"+MustarqaMuntiqla+"',' "+MMR_Kanal+"','"+ MMR_Marla+"', '"+ MMR_Sarsai+"', '"+ MMR_Feet+"'";
               dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public void SetMushtarkaRaqbaMuntiqlaKhatooni(string IntiqalKhatooniRecId, string MustarqaMuntiqla, string MMR_Kanal, string MMR_Marla, string MMR_Sarsai, string MMR_Feet)
            {
                string spWithParam = "Proc_Set_Intiqal_Khatooni_RaqbaMutiqla '" + IntiqalKhatooniRecId + "', '" + MustarqaMuntiqla + "'," + MMR_Kanal + "," + MMR_Marla + ", " + MMR_Sarsai + ", " + MMR_Feet + "";
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            public DataTable GetIntiqalMushtariqaRaqbaMuntaqila(string IntiqalKhataId)
            {
                string spWithParam = "Proc_Get_Intiqal_RaqbaMutiqla " +IntiqalKhataId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }


            public string IntiqalWarasathManderjaKhattaWarisan(string khataid, string IntiqalId)
            {
                string spWithParam = "Proc_Intiqal_Warasat_MandarjaKhataWarsan "+khataid+","+IntiqalId+"";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }


            public DataTable GetKhattajatByPersonId(string MozaId, string PersonId)
            {
                string spWithParam = "Proc_Get_Person_KhataJats  "+MozaId+","+PersonId+"";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }


            public string GetKhassraTotalRaqbaByKhattaId(string KhattaId)
            {
                string spWithParam = "Proc_Get_KhassrasTotalArea_By_KhataId  "+ KhattaId;
                   return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string GetKhassraMIntotalRaqbaByMinGroup(string IntiqalMinGroupId)
            {
                string spWithParam = "proc_Get_IntiqalMin_KhassrasTotalArea_By_MinGroup "+IntiqalMinGroupId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public void setIntiqalPendingReason(string IntiqalId, bool IntiqalPending, string IntiqalPendingReasonId, string IntiqalPendingReasonRemarks)
            {
               string IntiqalPend=Convert.ToString(IntiqalPending);
               string spWithParam=" Proc_Set_IntiqalPending "+IntiqalId+", "+IntiqalPend+","+"0"+",N'"+IntiqalPendingReasonRemarks+"'";
               dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }


            public DataTable GetIntiqalPendingReason()
            {
                string spWithParam = "Proc_Get_IntiqalPendingReasons ";
                return  dbobject.filldatatable_from_storedProcedure(spWithParam);
            }


            public string GetKhattaInconsistencyStatus(string Khataid)
            {
                string spWithParam ="Proc_Get_Khata_Inconsistancy"+Khataid;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);

            }

            public DataTable GetIntiqalPersonsList(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_PersonsList "+IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public string SaveIntiqalDocumentsRequired(string IntiqalDocRecId, string Intiqalid, string SeqNo, string IntiqalDocId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
                {
                string spWithParam = " WEB_SP_INSERT_Intiqal_DocumentsRequired " + IntiqalDocRecId + ", " + Intiqalid + ", " + SeqNo + ", " +IntiqalDocId + ", " +  InsertUserId + ",'" + InsertLoginName + "',  " + UpdateUserId + ", '" + UpdateLoginName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public string INSERTIntiqalDocumentImages(string IntiqalDocRecId, string Intiqalid, string SeqNo, string IntiqalDocId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
                {
                    string spWithParam = " WEB_SP_INSERT_Intiqal_DocumentImages " + IntiqalDocRecId + ", " + Intiqalid + ", " + SeqNo + ", " + IntiqalDocId + ", " + InsertUserId + ",'" + InsertLoginName + "',  " + UpdateUserId + ", '" + UpdateLoginName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public DataTable GetIntiqalDocumentsRequired(string Intiqalid) 
            {
                string spWithParam = "proc_Get_Intiqal_DocumentsRequired  " + Intiqalid + "";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }
            public DataTable GetIntiqalDocumentsList()
            {
                string spWithParam = "proc_Get_Intiqal_DocumentsList ";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public void IntiqalAmalDaramadCombined(string MozaId, string IntiqalId)
            {
                string spWithParam = "proc_Intiqal_Amaldaramad_Combine_Taqseem " + MozaId + "," + IntiqalId;
                dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }
            public void IntiqalMinAmalDaramadKhanakasht(string MozaId, string IntiqalId, string KhattaId)
            {
                string spWithParam = "proc_IntiqalMin_KhanaKasht_Amaldaramad_By_KhataId " + MozaId + "," + IntiqalId+","+KhattaId;
                dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinGroup(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_MinList "+ IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public string SaveMushteriFareeqainFromKhatooniToNewKhatooni(string NewKhatooniId, string OldKhatooniId)
            {
                string spWithParam = "WEB_SP_INSERT_MushtriFareeqein_From_Khatooni " + NewKhatooniId + "," + OldKhatooniId ;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public DataTable GetKhatooniByParentKhatooniId(string parentKhatooniId, string IntiqalId)
            {
                string spWithParam = "Proc_Get_Khatoonis_ByParentKhatooni  " + parentKhatooniId + "," + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

        
       
            #endregion
            #region Get Next Intiqal No for Mouza

            public string GetNextIntiqalNoForMoza(string MozaId, string TokenId)
            {
                string spWithParam = "Proc_Get_Intiqal_Next_Intiqal_No_By_Moza " + MozaId+",'"+TokenId+"'";
                string lastNo= dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
                return lastNo;
            }

            #endregion
            #region Get Intiqal Juzvi Status

            public bool GetIntiqalKhataJuzviStatus(string IntiqalKhataRecId)
            {
                string spWithParam = "Proc_GET_Intiqal_JuzviKhataStatus " + IntiqalKhataRecId;
                return Convert.ToBoolean( dbobject.ExecInsertUpdateStoredProcedure(spWithParam));
            }

            #endregion

            #region Update Intiqal Khata Juzvi status

            public bool UpdateIntiqalKhataJuzviStatus(string isJuzvi, string IntiqalKhataRecId)
            {
                string spWithParam = "WEB_SP_Update_Intiqal_JuzviKhata " + isJuzvi + " ," + IntiqalKhataRecId;
                return Convert.ToBoolean(dbobject.ExecInsertUpdateStoredProcedure(spWithParam));
            }

            public bool UpdateIntiqalKhatooniJuzviStatus(string isJuzvi, string IntiqalKhatooniRecId)
            {
                string spWithParam = "WEB_SP_Update_Intiqal_JuzviKhatooni " + isJuzvi + " ," + IntiqalKhatooniRecId;
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
                string spWithParam = "WEB_SP_DELETE_Intiqal_Intiqal_Main " + IntiqalId + "";
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            /// <summary>
            /// Deletes Intiqal khattajat
            /// </summary>
            /// <param name="IntiqalKhataRecId"></param>
            public void DeleteIntiqalKhattajat(int IntiqalKhataRecId)
            {
                //DataContext.WEB_SP_DELETE_Intiqal_Intiqal_KhataJat(IntiqalKhataRecId);
                string spWithParam = "WEB_SP_DELETE_Intiqal_Intiqal_KhataJat " + IntiqalKhataRecId + "";
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            /// <summary>
            /// Deletes register Haqdaran khat Id
            /// </summary>
            /// <param name="IntiqalKhataRecId"></param>
            public void DeleteRegisterHaqdaranKhattaByKhataId(string KhataId)
            {
                //DataContext.WEB_SP_DELETE_Intiqal_Intiqal_KhataJat(IntiqalKhataRecId);
                string spWithParam = "WEB_SP_DELETE_HaqdaranZameenKhatajat_NewKhataTaqseem " + KhataId + "";
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            /// <summary>
            /// Deletes Intiqal seller record 
            /// </summary>
            /// <param name="IntiqalSellerRecId"></param>
            public void DeleteIntiqalSeller(string IntiqalSellerRecId)
            {
              
                string spWithParam = "WEB_SP_DELETE_Intiqal_Sellers "+IntiqalSellerRecId;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }
            /// <summary>
            /// Deletes Intiqal Buyer record
            /// </summary>
            /// <param name="IntiqalBuyerRecId"></param>
            public void DeleteIntiqalBuyer(string IntiqalBuyerRecId)
            {
                //DataContext.WEB_SP_DELETE_Intiqal_Buyers(IntiqalBuyerRecId);
                string spWithParam = "WEB_SP_DELETE_Intiqal_Buyers " + IntiqalBuyerRecId + "";
                dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

        /// <summary>
        /// Deletes Intiqal Khatooni Entry
        /// </summary>
        /// <param name="IntiqalKhanakashtKhatooniRecId"></param>
            public void DeleteIntiqalKhanakashtKhatooni(string IntiqalKhanakashtKhatooniRecId)
            {
                string spWithParam = "WEB_SP_DELETE_Intiqal_KhanaKasht_Khatooni " + IntiqalKhanakashtKhatooniRecId + "";
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

            #region GET Intiqal Tasdiq Date Status

            public string GetIntiqalTaqdeeqDateStatus(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_Visiting_Date " + IntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

            #region MinhayeIntiqal Multiple Entries

            public string SaveIntiqalMinhayeIntiqal(string IntiqalId, string MinhayeIntiqalId)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Main_MinhayeIntiqal " + IntiqalId + ", " + MinhayeIntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public DataTable GetIntiqalMinhayeIntiqals(string IntiqalId)
            {
                string spWithParam = "Proc_Get_Intqal_MinhayeIntiqals " + IntiqalId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public void DeleteIntiqalMinhayeIntiqals(string MinhayeIntiqalId)
            {
                string spWithParam = "WEB_SP_DELETE_MinhayeIntiqal " + MinhayeIntiqalId;
                 dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);
            }

            #endregion


            #region Khewat Malkan Merging

            public string SaveKhewatMalkanMerginRecord(string ParentKhewatGroupFareeqId, string KhewatGroupFareeqId, string InsertUserId, string InsertLoginName)
            {
                string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqainMerging " + ParentKhewatGroupFareeqId + ", " + KhewatGroupFareeqId + ", " + InsertUserId +",'" + InsertLoginName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string SaveMushteryanMerginRecord(string ParentMushteriFareeqId, string MushteriFareeqId, string InsertUserId, string InsertLoginName)
            {
                string spWithParam = "WEB_SP_INSERT_MushteriFareeqainMerging " + ParentMushteriFareeqId + ", " + MushteriFareeqId + ", " + InsertUserId + ",'" + InsertLoginName + "'";
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            public string DeleteKhewatGroupFareeq( string KhewatGroupFareeqId)
            {
                string spWithParam = "WEB_SP_DELETE_KhewatGroupFard " +KhewatGroupFareeqId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

         #endregion
        
        #region Intiqal Verification By Revenue Officer

            public string WEB_SP_Update_Intiqal_Verification(string IntiqalId, string RoId, byte[] FingerPrint)
            {
                string lastId = "";
                SqlCommand mycomm = new SqlCommand();

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

            #region Get Intiqal Minhaye Intiqal Seller hissa and raqba

            public DataTable GetIntiqalSellerHisaRaqbaMinhayeIntiqal(string IntiqalId, string IntiqalKhataId, string KhewatGroupFareeqId,  string MushteriFareeqId)
            {
                string spWithParam = "Proc_Get_Intiqal_Seller_Minhaye_Intiqal " + IntiqalId+","+IntiqalKhataId+","+KhewatGroupFareeqId+","+MushteriFareeqId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            #endregion

            #region Get Intiqal Intiqal Seller Status, if Allready added to sellers with existing Hissa and raqba

            public string GetIntiqalSellerStatusHisaRaqba(string PersonId, string KhewatGroupFareeqId, string MushteriFareeqId, string SellerTotalHissa)
            {
                string spWithParam = "Proc_Get_Intiqal_Seller_Status " + PersonId + ","  + KhewatGroupFareeqId + "," + MushteriFareeqId+ ","+SellerTotalHissa;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

            #region Get Minhaye Intiqal Status, if Allready added to against an Intiqal

            public string GetIntiqalMinhayeIntiqalIdByKhewatGroupId(string KhewatGroupFareeqId)
            {
                string spWithParam = "Proc_Get_Intiqal_Check_MinhayeIntiqal_by_KhewatGroupFareeqId_IntiqalId " + KhewatGroupFareeqId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

            #region Get Minhaye Intiqal Status, if Allready added to against an Intiqal in Khanakasht

            public string GetIntiqalMinhayeIntiqalIdByMushteriFareeqId(string MushteriFareeqId)
            {
                string spWithParam = "Proc_Get_Intiqal_Check_MinhayeIntiqal_by_MushteriFareeqId_IntiqalId " + MushteriFareeqId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

            #region Get Intiqal Intiqal Amaldaramad Status for Minhaye Intiqal (Dependent Intiqal)

            public string GetIntiqalAmaldaramadStatusForMinhayeIntiqal(string MinhayeIntiqalId)
            {
                string spWithParam = "Proc_Get_Intiqal_Minhaye_Status " + MinhayeIntiqalId;
                return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
            }

            #endregion

        #region Khatooni Bayan Mushteryan Procedures

            public DataTable GetKhatooniKhanakashtBayaByNameSearch(string MozaId, string BayaName)
            {
                string spWithParam = "Proc_Get_Khatooni_Khanakasht_Details " + MozaId+",N'"+BayaName+"'";
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

            public DataTable GetKhatooniKhanakashtBayaRaqbaByPersonId(string BayanPersonId)
            {
                string spWithParam = "Proc_Get_Khatooni_Khanakasht_Bayan " + BayanPersonId;
                return dbobject.filldatatable_from_storedProcedure(spWithParam);
            }

        #endregion

        #region Update Person Net Raqba 

        
            public void UpdateMalakRaqbaByHissa(string KhewatGroupFareeqId, string NetHissa, string Kanal, string Marla, string Sarsai, string Sft)//, string IntiqalID, string SeqNo)
            {
                string spWithParam = "WEB_SP_INSERT_KhewatGroupFareeqein_Update_NetPart " + KhewatGroupFareeqId+","+NetHissa+","+Kanal+","+Marla+","+Sarsai+","+Sft;
                dbobject.ExecUpdateStoredProcedureWithNoRet(spWithParam);

            }

        #endregion

        #region Update Intiqal Main Confirm by Operator

            public bool UpdateIntiqalMainConfirmByOperator(string IntiqalId, string isConfirm)
            {
                string spWithParam = "WEB_SP_INSERT_Intiqal_Main_ConfirmByOperator " + IntiqalId + " ," + isConfirm;
                return Convert.ToBoolean(dbobject.ExecInsertUpdateStoredProcedure(spWithParam));
            }

        #endregion


    }
    }
