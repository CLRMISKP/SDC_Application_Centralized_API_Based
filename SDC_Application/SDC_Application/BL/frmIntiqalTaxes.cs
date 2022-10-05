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
using SDC_Application.AL;

namespace SDC_Application.BL
{
    class frmIntiqalTaxes
    {
        DL.Database objdb = new Database();
        datagrid_controls objdatagrid = new datagrid_controls();
        

        public DataTable filldatatable_from_storedProcedure(string Query)
        {
            return objdb.filldatatable_from_storedProcedure(Query);
        }
        public DataTable viewGridData(string b)
        {
            return objdb.viewGridData(b);
        }
        public int Insert_StoreProcedure(string str)
        {
            return objdb.Insert_StoreProcedure(str);

        }
        public SqlDataReader fillDataReader(string str)
        {
            return objdb.fillDataReader(str);
        }
        public void VoucherGrid(DataGridView grdVoucherDetails)
        {
           
         
            
        }
      
       
    }
    }

