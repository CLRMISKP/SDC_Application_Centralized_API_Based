using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SDC_Application.DL;
using System.Data.SqlClient;
namespace SDC_Application.BL
{
    class MasterDefinition
    {
        DL.Database dbobject = new Database();

        #region SDC and Intqalat Get Members

        public DataTable GetSDCTokenPurpose()
        {
            string spWithParam = "Proc_Get_SDC_TokenPurpose ";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetSDCTokenPurposeList()
        {
            string spWithParam = "Proc_Get_SDC_TokenPurpose_List ";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetSDCPaymentTypesList()
        {
            string spWithParam = "Proc_Get_SDC_PaymentTypes_List ";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetSDCServiceTypesList()
        {
            string spWithParam = "Proc_Get_SDC_ServiceTypes_List ";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetSDCServiceCostUnitsList()
        {
            string spWithParam = "Proc_Get_SDC_ServiceCostUnits_List ";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetSDCServicesList()
        {
            string spWithParam = "Proc_Get_SDC_Services_List ";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetSDCServiceCostNotificationsList()
        {
            string spWithParam = "Proc_Get_SDC_ServiceCostNotifications_List ";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetIntiqalTypesList()
        {
            string spWithParam = "Proc_Get_IntiqalTypes_List";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable WEB_SP_DELETE_DocmentID(string DocId)   
        {
            string spWithParam = "WEB_SP_DELETE_Intiqal_DucomentsList '" + DocId + "'";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

    public DataTable WEB_SP_DELETE_IntiqalType(string IntiqalTypeID)
        {
            string spWithParam = "WEB_SP_DELETE_IntiqalType " + IntiqalTypeID + "";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

     public DataTable GetIntiqalDocumentsList()  
        {
            string spWithParam = "Proc_Get_Intiqal_DocumentsList_List";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

     public DataTable DELETEPlotConstructionType(string PlotConstructionTypeId) 
        {
            string spWithParam = "WEB_SP_DELETE_Intiqal_PlotConstructionType " + PlotConstructionTypeId + "";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetIntiqalPlotConstructionTypesList() 
        {
            string spWithParam = "Proc_Get_Intiqal_PlotConstructionTypes_List";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable GetIntiqalPlotTypesList()  
        {
            string spWithParam = "Proc_Get_Intiqal_PlotTypes_List";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        public DataTable GetntiqalTaxCategoriesList()
        {
            string spWithParam = "Proc_Get_Intiqal_TaxCategories_List";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }

        public DataTable DELETE_PlotType(string IntiqalTypeId)  
        {
            string spWithParam = "WEB_SP_DELETE_PlotType " + IntiqalTypeId + "";
            return dbobject.filldatatable_from_storedProcedure(spWithParam);
        }
        #endregion

        #region Insertion Members for SDC and Intqalat


        public string SaveSDCTokenPurpose(string TokenPurposeId, string TokenPurpose_Urdu, string TokenPurpose_Eng, string TehsilId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_SDC_TokenPurpose " + TokenPurposeId + ",N'" + TokenPurpose_Urdu + "','" + TokenPurpose_Eng + "'," + TehsilId + "," + InsertUserId + "," + InsertLoginName + "," + UpdateUserId + "," + UpdateLoginName;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveSDCPaymentTypes(string PaymentTypeId, string PaymentType_Urdu, string PaymentType_Eng, string TehsilId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_SDC_PaymentTypes " + PaymentTypeId + ",N'" + PaymentType_Urdu + "',N'" + PaymentType_Eng + "'," + TehsilId + "," + InsertUserId + "," + InsertLoginName + "," + UpdateUserId + "," + UpdateLoginName;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveSDCServiceTypes(string ServiceTypeId, string TehsilId, string ServiceTypeName_Urdu, string ServiceTypeName_Eng, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_SDC_ServiceTypes " + ServiceTypeId + "," + TehsilId + ",N'" + ServiceTypeName_Urdu + "','" + ServiceTypeName_Eng + "'," + InsertUserId + "," + InsertLoginName + "," + UpdateUserId + "," + UpdateLoginName;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }
       
        public string SaveSDCServiceCostUnits(string SDCUnitId, string TehsilId, string SDCUnitName_Urdu, string SDCUnitName_Eng, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_SDC_ServiceCostUnits " + SDCUnitId + "," + TehsilId + ",N'" + SDCUnitName_Urdu + "','" + SDCUnitName_Eng + "'," + InsertUserId + "," + InsertLoginName + "," + UpdateUserId + "," + UpdateLoginName;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveSDCServices(string SDCServiceId, string TehsilId, string SDCServiceName_Urdu, string SDCServiceName_Eng, string ServiceTypeId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_SDC_Services " + SDCServiceId + "," + TehsilId + ",N'" + SDCServiceName_Urdu + "','" + SDCServiceName_Eng + "'," + ServiceTypeId + "," + InsertUserId + "," + InsertLoginName + "," + UpdateUserId + "," + UpdateLoginName;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveSDCServiceCostNotifications(string ServiceNotificationId, string TehsilId, string ServiceId, string ServiceTypeId, string ServiceCostUnitId, string ServiceCostPerUnit, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_SDC_ServiceCostNotifications '" + ServiceNotificationId + "'," + TehsilId + ",'" + ServiceId + "','" + ServiceTypeId + "','" + ServiceCostUnitId + "','" + ServiceCostPerUnit + "'," + InsertUserId + "," + InsertLoginName + "," + UpdateUserId + "," + UpdateLoginName;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveIntiqalTypes(string IntiqalTypeId, string TehsilId, string IntiqalType, string IntiqalTypeCategoryId, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_Intiqal_Types " + IntiqalTypeId + "," + TehsilId + ",N'" + IntiqalType + "'," + IntiqalTypeCategoryId + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveIntiqalDocumentsList(string IntiqalDocId, string TehsilId, string IntiqalDocName_Urdu, string IntiqalDocName_Eng,string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_Intiqal_DocumentsList " + IntiqalDocId + "," + TehsilId + ",N'" + IntiqalDocName_Urdu + "','" + IntiqalDocName_Eng + "'," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName + "'";
         
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveIntiqalPlotConstructionTypes(string PlotConstructionTypeId, string TehsilId,string PlotTypeId ,string PlotConstructionType_Urdu, string PlotConstructionType_Eng, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_Intiqal_PlotConstructionTypes " + PlotConstructionTypeId + "," + TehsilId + ","+PlotTypeId+",N'" + PlotConstructionType_Urdu + "','" + PlotConstructionType_Eng + "'," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveIntiqalPlotTypes(string PlotTypeId, string TehsilId, string PlotType_Urdu, string PlotType_Eng, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_Intiqal_PlotTypes " + PlotTypeId + "," + TehsilId + ",N'" + PlotType_Urdu + "','" + PlotType_Eng + "'," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveIntiqalTaxesList(string TaxeId, string TehsilId, string TaxCategoryId, string TaxName_Urdu, string TaxName_Eng, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_Intiqal_TaxesList " + TaxeId + "," + TehsilId + "," + TaxCategoryId + ",N'" + TaxName_Urdu + "','" + TaxName_Eng + "'," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveIntiqalTaxCategories(string TaxeCategoryId, string TehsilId, string TaxCategoryName_Urdu, string TaxCategoryName_Eng, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_Intiqal_TaxCategories " + TaxeCategoryId + "," + TehsilId + "," + TaxCategoryName_Urdu + "," + TaxCategoryName_Eng + "," + InsertUserId + "," + InsertLoginName + "," + UpdateUserId + "," + UpdateLoginName;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveIntiqalTaxNotifications(string TaxNotificationId, string TaxNotificationNo, string TehsilId, string TaxNotificationDate, string TaxNotificationActiveDate, string TaxNotificationExpiryDate, string TaxNotificationRemarks, string TaxNotificationActive, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_Intiqal_TaxNotifications " + TaxNotificationId + ",'" + TaxNotificationNo + "'," + TehsilId + ",'" + TaxNotificationDate + "','" + TaxNotificationActiveDate + "','" + TaxNotificationExpiryDate + "',N'" + TaxNotificationRemarks + "','" + TaxNotificationActive + "'," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName+"'";
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        public string SaveIntiqalTaxNotificationDetail(string TaxNotificationDetailId, string TaxNotificationId, string SeqNo, string TaxId,string PaymentTypeId, string SDCUnitId,string TaxRateType, string TaxRate, string TaxDetailNotfRemarks, string InsertUserId, string InsertLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_Intiqal_TaxNotificationDetail " + TaxNotificationDetailId + "," + TaxNotificationId + "," + SeqNo + "," + TaxId  + "," +PaymentTypeId+ "," + SDCUnitId + ",'"+TaxRateType+"','" + TaxRate + "',N'" + TaxDetailNotfRemarks + "'," + InsertUserId + ",'" + InsertLoginName + "'" ;
            return dbobject.ExecInsertUpdateStoredProcedure(spWithParam);
        }

        #endregion
    }
}
