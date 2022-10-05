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
    class fileIndexing
    {

       

        #region Class Variables

        Database ojbdb = new Database();

        /*
    int _thesilId;
        public int ThesilId
        {
            get
            {
                return _thesilId;
            }

            set
            {
                _thesilId = value;
            }
        }
*/
        #endregion

        #region Get Patwar Circles

        public DataTable GetPatwarCircle(string TehsilId)
        {
            string spWithParam = "Proc_Get_PatwarCircles " + TehsilId + "";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Mozas by Patwar Circle

        public DataTable GetMozaByPatwarCircle(string TehsilId, string PatwarCircleId)
        {
            string spWithParam = "Proc_Get_Moza_by_PatwarCircle " + TehsilId + ", " + PatwarCircleId + "";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Entry Patwar Circle

        public DataTable GetEntryPatwarCircle(string QanoonGoiId)
        {
            string spWithParam = "Proc_Entry_PatwarCircles  " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + QanoonGoiId + "";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Entry Qanoongois

        public DataTable GetEntryQanoonGoi(string TehsilId)
        {
            string spWithParam = "Proc_Entry_Qanoongois " + TehsilId + "";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Document Types

        public DataTable GetDocumentType()
        {
            string spWithParam = "proc_Get_DocumentTypes " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString();
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Save File Indexing

        public string saveFileIndexing(string IndexingId, string TehsilId, string MozaId, string DestinationFolder, string DocumentTypeId, string RecordNo, string ImageNo, string FileName, string InsertUserId)
        {
            string spWithParam = "WEB_SP_INSERT_FilesIndexing" + IndexingId + ", " + TehsilId + ", " + MozaId + ", '" + DestinationFolder + "', '" + DocumentTypeId + "', '" + RecordNo + "', " + ImageNo + ", '" + FileName + "', " + InsertUserId + "";
            return ojbdb.ExecInsertUpdateStoredProcedure(spWithParam);

        }

        #endregion

        #region Get Indexed Files By Type

        public DataTable GetInexedFilesByType(string MozaId, string DocNo, string TypeId)
        {
            string spWithParam = "Proc_Get_IndexedFiles_by_Type " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ", '" + DocNo + "', " + TypeId + "";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get Indexed Files By Khata

        public DataTable GetInexedFilesByKhata(string MozaId, string KhataNo)
        {
            string spWithParam = "Proc_Get_IndexedFiles_by_Khata " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ", '" + KhataNo + "'";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion

        #region Get File Indexing Records

        public DataTable GetFileIndexingRecords(string MozaId, string DocumentTypeId)
        {
            string spWithParam = "Proc_Get_FileIndexingRecords " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ", " + DocumentTypeId + "";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }

        #endregion

        #region Get File Indexing File Name

        public DataTable GetFileIndexingFileName(string MozaId, string DocumentType, string Recordno, string Picno)
        {
            string spWithParam = "Proc_Get_FileIndexing_FileName " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ", '" + DocumentType + "', '" + Recordno + "', " + Picno + "";
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);
        }

        #endregion

        #region Save Document Image

        public string saveDocImage(string IndexId, byte[] DocImage, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string lastId = "";
            SqlCommand mycomm = new SqlCommand();
            mycomm.Parameters.AddWithValue("@Tehsilid",  SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ); // this is stirng and in sp it is equated to bigint causes error
            mycomm.Parameters.AddWithValue("@IndexId", IndexId); // this is stirng and in sp it is equated to bigint causes error
            mycomm.Parameters.AddWithValue("@DocImage", DocImage);
            mycomm.Parameters.AddWithValue("@InsertUserId", InsertUserId);
            mycomm.Parameters.AddWithValue("@InsertLoginName", InsertLoginName);
            mycomm.Parameters.AddWithValue("@UpdateUserId", UpdateUserId);
            mycomm.Parameters.AddWithValue("@UpdateLoginName", UpdateLoginName);
            try
            {
                lastId = ojbdb.ExecStoredProcedure("WEB_SP_INSERT_DocumentImages", mycomm);

            }
            catch (Exception e)
            {
                throw e;
            }
            return lastId;
        }

        public string saveCamFingerImage(string IntialPersonImageId,string IntiqalId,string PersonId,byte[] imgDataPerson,byte[]imgDataFinger, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string lastId = "";
            SqlCommand mycomm = new SqlCommand();
            mycomm.Parameters.AddWithValue("@Tehsilid", SDC_Application.Classess.UsersManagments._Tehsilid.ToString());
            mycomm.Parameters.AddWithValue("@IntialPersonImageId", IntialPersonImageId);
            mycomm.Parameters.AddWithValue("@IntiqalId", IntiqalId);
            mycomm.Parameters.AddWithValue("@PersonId", PersonId);
            mycomm.Parameters.AddWithValue("@PersonPic", imgDataPerson);
            mycomm.Parameters.AddWithValue("@PersonFingerPrint", imgDataFinger);
            mycomm.Parameters.AddWithValue("@InsertUserId", InsertUserId);
            mycomm.Parameters.AddWithValue("@InsertLoginName", InsertLoginName);
            mycomm.Parameters.AddWithValue("@UpdateUserId", UpdateUserId);
            mycomm.Parameters.AddWithValue("@UpdateLoginName", UpdateLoginName);
            try
            {
                lastId = ojbdb.ExecStoredProcedure("WEB_SP_INSERT_Intiqal_PersonsImages", mycomm);

            }
            catch (Exception e)
            {
                throw e;
            }
            return lastId;
        }

        public string saveFingerImageSelf(string FardPersonFingerId, string tokenId, string PersonId, byte[] imgDataFinger, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string lastId = "";
            SqlCommand mycomm = new SqlCommand();
            mycomm.Parameters.AddWithValue("@Tehsilid", SDC_Application.Classess.UsersManagments._Tehsilid.ToString());
            mycomm.Parameters.AddWithValue("@PersonFingerPrintId", FardPersonFingerId);
            mycomm.Parameters.AddWithValue("@tokenId", tokenId);
            mycomm.Parameters.AddWithValue("@PersonId", PersonId);
            mycomm.Parameters.AddWithValue("@PersonFingerPrint", imgDataFinger);
            mycomm.Parameters.AddWithValue("@InsertUserId", InsertUserId);
            mycomm.Parameters.AddWithValue("@InsertLoginName", InsertLoginName);
            mycomm.Parameters.AddWithValue("@UpdateUserId", UpdateUserId);
            mycomm.Parameters.AddWithValue("@UpdateLoginName", UpdateLoginName);
            try
            {
                lastId = ojbdb.ExecStoredProcedure("Proc_Self_WEB_SP_INSERT_Fard_PersonsFingerPrints", mycomm);

            }
            catch (Exception e)
            {
                throw e;
            }
            return lastId;
        }

        #endregion

        #region Get Document Image from DB

        public DataTable GetDocumentImage()
        {
            string spWithParam = "Proc_Get_DocumentImage " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() ;
            return ojbdb.filldatatable_from_storedProcedure(spWithParam);

        }

        #endregion
    }
}
