using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.DL;

namespace SDC_Application.BL
{
    class frmToken
    {
        DL.Database ojbdb = new Database();

        //public DataTable fillDataTable(string b)
        //{
        //    return ojbdb.fillDataTable(b);
        //}
           public DataTable filldatatable_from_storedProcedure(string b)
        {
               return ojbdb.filldatatable_from_storedProcedure(b);
           }
           public DataTable viewGridData(string b)
        {
            return ojbdb.viewGridData(b);
        }
           public int Insert_StoreProcedure(string str)
        {
            return ojbdb.Insert_StoreProcedure(str);

        }
           public SqlDataReader fillDataReader(string str)
           {
               return ojbdb.fillDataReader(str);
           }

        #region Get Token No by Token Id

           public string GetTokenNoByTokenId(string TokenId)
           {
               string spWithParam = "Proc_Get_SDCToken_By_TokenId  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + TokenId;
               return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);
           }

        #endregion


          
    }
}
