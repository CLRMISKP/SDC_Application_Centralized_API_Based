using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SDC_Application.DL;
using System.Data.SqlClient;

namespace SDC_Application.BL
{
    
    class Bank_SDC_Data
    {
        DL.Database dbobject = new Database();

        public DataTable getBankRecords(string pro)
        {
            return dbobject.filldatatable_from_storedProcedure(pro);
        }

        public string SaveBankSDCSlips(string DepositId, int TehsilId, string DepositDate, string DepositDateBank, string BankRecieptNo, string Amount, string dipositname, byte[] ImgBankReciept, byte[] ImgSDCReport, int InsertUserId, string username,int type, int UpdateUserId, string UpdateLoginName)
        {
            
            Database ojbdb = new Database();
            string lastId = "";
            SqlCommand mycomm = new SqlCommand();
            mycomm.Parameters.AddWithValue("@Tehsilid",  SDC_Application.Classess.UsersManagments._Tehsilid.ToString() );
            mycomm.Parameters.AddWithValue("@DepositId", DepositId);
            mycomm.Parameters.AddWithValue("@TehsilId", TehsilId);
            mycomm.Parameters.AddWithValue("@DepositDate", DepositDate);
            mycomm.Parameters.AddWithValue("@DepositDateBank", DepositDateBank);
            mycomm.Parameters.AddWithValue("@BankRecieptNo", BankRecieptNo);
            mycomm.Parameters.AddWithValue("@Amount", Amount);
            mycomm.Parameters.AddWithValue("@DepositedBy", dipositname);
            mycomm.Parameters.AddWithValue("@ImgBankReciept", (ImgBankReciept == null) ? (object)DBNull.Value : ImgBankReciept).SqlDbType = SqlDbType.Image;
            mycomm.Parameters.AddWithValue("@ImgSDCReport", (ImgSDCReport == null) ? (object)DBNull.Value :ImgSDCReport).SqlDbType = SqlDbType.Image;
            mycomm.Parameters.AddWithValue("@InsertUserId", InsertUserId);
            mycomm.Parameters.AddWithValue("@InsertLoginName", username);
            mycomm.Parameters.AddWithValue("@ServiceTypeId", type);
            mycomm.Parameters.AddWithValue("@UpdateUserId", InsertUserId);
            mycomm.Parameters.AddWithValue("@UpdateLoginName",UpdateLoginName);
            try
            {
                lastId = ojbdb.ExecStoredProcedure("WEB_SP_INSERT_SDC_Bank_Deposit", mycomm);

            }
            catch (Exception e)
            {
                throw e;
            }
            return lastId;
        }


    }
}
