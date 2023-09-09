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
    class AreaProfile
    {
        #region Class Variables

        Database ojbdb = new Database();

        #endregion

        #region Get Patwar Circles

        public DataTable GetPatwarCircle(string TehsilId)
        {
             string spWithParam = "Proc_Get_PatwarCircles " + TehsilId;
             return ojbdb.filldatatable_from_storedProcedure(spWithParam);
            
        }

        #endregion

        #region Get Mozas by Patwar Circle

        public DataTable GetMozaByPatwarCircle(string TehsilId, string PatwarCircleId)
        {
            string spWithParam = "Proc_Get_Moza_by_PatwarCircle " + TehsilId+", "+PatwarCircleId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Tehsil District Name

        public DataTable GetDistTehsilNames(string TehsilId, string SubSdcId)
        {
            string spWithParam = "Proc_Get_Dist_Tehsils_By_TehsilId " + TehsilId+","+SubSdcId;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }

        #endregion

    }
}
