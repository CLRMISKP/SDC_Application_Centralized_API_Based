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
    class frmcharges
    {
        DL.Database ojbdb = new Database();

        public DataTable fillDataTable(string b)
        {
            return ojbdb.fillDataTable(b);
        }
        //public DataTable viewgriddata(string b)
        //{
        //    return ojbdb.viewgriddata(b);
        //}
        //public int Insert(string str)
        //{
        //    return ojbdb.Insert(str);

        //}

    }
}

