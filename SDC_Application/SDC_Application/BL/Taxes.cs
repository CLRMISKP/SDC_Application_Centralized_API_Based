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
    class Taxes
    {
        #region Class Variables

        Database ojbdb = new Database();

        #endregion

        #region Get Intiqal PlotTypes

        public DataTable GetIntiqalPlotTypes(string TehsilId)
        {
            string spWithParam = "Proc_Get_SDC_PlotTypes " + TehsilId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Intiqal Plot Territory Types

        public DataTable GetIntiqalPlotTerritoryTypes(string TehsilId)
        {
            string spWithParam = "Proc_Get_SDC_PlotTerritoryTypes " + TehsilId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Intiqal Plot Contruction Types

        public DataTable GetIntiqalPlotConstructionTypes(string TehsilId)
        {
            string spWithParam = "Proc_Get_SDC_PlotConstructionTypes " + TehsilId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        public DataTable GetIntiqalTaxlist()
        {
            string spWithParam = "Proc_Get_Intiqal_Taxes_List " ;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }
        #endregion        

        #region Get Intiqal Tax Notification

        public DataTable Get_SDC_IntiqalTaxNotification(string TehsilId)
        {
            string spWithParam = "Proc_Get_SDC_Intiqal_TaxNotifications " + TehsilId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }
        public DataTable GetIntiqalTaxNotification(string TehsilId)
        {
            string spWithParam = "Proc_Get_SDC_Intiqal_TaxNotifications "+TehsilId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Intiqal Tax Notification Details

        public DataTable GetIntiqalTaxNotificationDetails(string NotificationId)
        {
            string spWithParam = "Proc_Get_Intiqal_TaxNotificationDetail_List_By_NotificationId " + NotificationId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Intiqal Tax Notification Details By TehsilId

        public DataTable GetIntiqalTaxNotificationDetailsByTehsilId(string TehsilId)
        {
            string spWithParam = "Proc_Get_Intiqal_TaxNotificationDetail_List_By_TehsilId " + TehsilId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Intiqal Tax Notification Details

        public DataTable GetIntiqalTaxNotificationDetailsForNotificationUpdation(string NotificationId)
        {
            string spWithParam = "Proc_Get_Intiqal_TaxNotificationDetail_List_By_NotificationId_New " + NotificationId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Insert / Update Intiqal Tax Details

        public string SaveIntiqalTaxDetails(string IntiqalTaxId,string IntiqalId, string TaxNotificationId, string TaxNotificationDetailId,  string SeqNo, string TaxId, string SDCUnitId, string TaxRate, string TaxableQuantity, string TaxAmount, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string spWithParam = "WEB_SP_INSERT_Intiqal_TaxesDetail " + IntiqalTaxId + "," + IntiqalId + "," + TaxNotificationId + "," + TaxNotificationDetailId + "," + SeqNo + "," + TaxId + "," + SDCUnitId + "," + TaxRate + "," + TaxableQuantity + "," + TaxAmount + "," + InsertUserId + ",'" + InsertLoginName + "'," + UpdateUserId + ",'" + UpdateLoginName+"'";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);

        }

        #endregion

        #region Get Intiqal Taxes  Details

        public DataTable GetIntiqalTaxesDetails(string IntiqalId)
        {
            string spWithParam = "Proc_Get_SDC_Intiqal_TaxDetails " + IntiqalId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }


        #endregion

        #region Get Intiqal Taxes  Details

        public DataTable GetIntiqalTaxesDetailsByIntiqalId(string IntiqalId)
        {
            string spWithParam = "Proc_Get_Intiqal_TaxDetails_By_IntiqalId " + IntiqalId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }


        #endregion

        #region Get Intiqal Territory Types List

        public DataTable GetIntiqalTerritoryTypeList()
        {
            string spWithParam = "Proc_Get_Intiqal_PlotTerritoryTypes_List ";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }


        #endregion

        #region Get Intiqal Plot Area Types List

        public DataTable GetIntiqalPlotTypeList()
        {
            string spWithParam = "Proc_Get_Intiqal_PlotTypes_List ";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }


        #endregion

        #region Get Intiqal Land Types List

        public DataTable GetLandTypesList()
        {
            string spWithParam = "Proc_Get_LandTypes_List ";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }


        #endregion

         #region Get Intiqal Plot Contruction Types List

        public DataTable GetIntiqalPlotConstructionTypeList(string PlotTypeId)
        {
            string spWithParam = "Proc_Get_Intiqal_PlotConstructionTypes_By_PlotTypeId " + PlotTypeId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }


        #endregion


        #region Get Intiqal TaxDetails By TokenId

        public DataTable GetIntiqalTaxDetailsByTokenId(string TokenId)
        {
            string spWithParam = "Proc_Get_Intiqal_TaxDetails_By_TokenId " + TokenId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }


        #endregion

        #region Delete Intiqal TaxDetails By IntiqalTaxId

        public void DeleteIntiqalTaxDetails(string IntiqalTaxId)
        {
            string spWithParam = "WEB_SP_DELETE_Intiqal_TaxDetail " + IntiqalTaxId;
            ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }


        #endregion

        

        #region Update Intiqal Taxes  Details

        public DataTable UpdateIntiqalTaxesDetails(string Query)
        {
            string spWithParam = "WEB_SP_Update_Intiqal_TaxesDetail " + Query;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion
                                 
    }
}
