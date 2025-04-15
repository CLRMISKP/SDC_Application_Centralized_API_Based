using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SDC_Application.Classess;
using System.Data;
using System.Data.SqlClient;
using SDC_Application.DL;
using SDC_Application.Classess;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;

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
            string spWithParam = "Proc_Get_Moza_by_PatwarCircle " + UsersManagments._Tehsilid.ToString() + ", " + PatwarCircleId + "";
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
            string spWithParam = "Proc_Entry_Qanoongois " + UsersManagments._Tehsilid.ToString();
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
        public DataTable GetFileIndexingFileNameByDocNo(string MozaId, string DocumentType, string Recordno)
        {
            string spWithParam = "Proc_Get_FileIndexingRecords_SDC " + SDC_Application.Classess.UsersManagments._Tehsilid.ToString() + "," + MozaId + ", '" + DocumentType + "', '" + Recordno + "'";
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
            UserRequestIwthPicBiometric request=new UserRequestIwthPicBiometric();
            request.TehsilId= SDC_Application.Classess.UsersManagments._Tehsilid.ToString();
            request.IntialPersonImageId= IntialPersonImageId ;
            request.IntiqalId= IntiqalId ;
            request.PersonId= PersonId ;
            request.PersonPic=Convert.ToBase64String(imgDataPerson) ;
            request.PersonFingerPrint=Convert.ToBase64String(imgDataFinger) ;
            request.InsertUserId= InsertUserId ;
            request.InsertLoginName= InsertLoginName ;
            request.UpdateUserId= UpdateUserId ;
            request.UpdateLoginName= UpdateLoginName ;
            request.Query = "WEB_SP_INSERT_Intiqal_PersonsImages";
            try
            {
                lastId = ojbdb.ExecStoredProcedure("WEB_SP_INSERT_Intiqal_PersonsImages", request);

            }
            catch (Exception e)
            {
                throw e;
            }
            return lastId;
        }

        public string saveFingerImageSelf(string FardPersonFingerId, string tokenId, string PersonId, string FardRepRecId, byte[] imgDataPerson, byte[] imgDataFinger, string InsertUserId, string InsertLoginName, string UpdateUserId, string UpdateLoginName)
        {
            string lastId = "";
            //SqlCommand mycomm = new SqlCommand();
            //mycomm.Parameters.AddWithValue("@Tehsilid", SDC_Application.Classess.UsersManagments._Tehsilid.ToString());
            //mycomm.Parameters.AddWithValue("@PersonFingerPrintId", FardPersonFingerId);
            //mycomm.Parameters.AddWithValue("@tokenId", tokenId);
            //mycomm.Parameters.AddWithValue("@PersonId", PersonId);
            //mycomm.Parameters.AddWithValue("@FardRepRecId", FardRepRecId);
            //mycomm.Parameters.AddWithValue("@PersonPic", imgDataPerson);
            //mycomm.Parameters.AddWithValue("@PersonFingerPrint", imgDataFinger);
            //mycomm.Parameters.AddWithValue("@InsertUserId", InsertUserId);
            //mycomm.Parameters.AddWithValue("@InsertLoginName", InsertLoginName);
            //mycomm.Parameters.AddWithValue("@UpdateUserId", UpdateUserId);
            //mycomm.Parameters.AddWithValue("@UpdateLoginName", UpdateLoginName);
            UserRequestBioFard request = new UserRequestBioFard();
            request.TehsilId = SDC_Application.Classess.UsersManagments._Tehsilid.ToString();
            request.PersonFingerPrintId = FardPersonFingerId;
            request.tokenId = tokenId;
            request.PersonId = PersonId;
            request.FardRepRecId = FardRepRecId;
            request.PersonPic = Convert.ToBase64String(imgDataPerson);
            request.PersonFingerPrint = Convert.ToBase64String(imgDataFinger);
            request.InsertUserId = InsertUserId;
            request.InsertLoginName = InsertLoginName;
            request.UpdateUserId = UpdateUserId;
            request.UpdateLoginName = UpdateLoginName;
            request.Query = "Proc_Self_WEB_SP_INSERT_Fard_PersonsFingerPrints";
            try
            {
                lastId = ojbdb.ExecStoredProcedure("Proc_Self_WEB_SP_INSERT_Fard_PersonsFingerPrints", request);

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

        #region File Uploading
         public string UploadFileToServer(string filePath, string targetUri ,int MozaId , int DocumentTypeID , int RecordNo, int ImageNo, DateTime ModifiedDate)
        {
            string formattedDate = ModifiedDate.ToString("dd MMM yyyy");


            string boundary = "------------------------" + DateTime.Now.Ticks.ToString("x");
            WebClient client = new WebClient();
            client.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);

            byte[] fileData = File.ReadAllBytes(filePath);

            List<byte> formData = new List<byte>();

            // Add file content to form data
            string fileHeader = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"ImageFile\"; filename=\"{1}\"\r\nContent-Type: application/octet-stream\r\n\r\n",boundary,Path.GetFileName(filePath));
            formData.AddRange(Encoding.UTF8.GetBytes(fileHeader));
            formData.AddRange(fileData);
            formData.AddRange(Encoding.UTF8.GetBytes("\r\n"));

            // Additional form fields
            formData.AddRange(Encoding.UTF8.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"MozaId\"\r\n\r\n{1}\r\n", boundary, MozaId)));
            formData.AddRange(Encoding.UTF8.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"DocumentTypeId\"\r\n\r\n{1}\r\n", boundary, DocumentTypeID)));
            formData.AddRange(Encoding.UTF8.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"RecordNo\"\r\n\r\n{1}\r\n", boundary, RecordNo)));
            formData.AddRange(Encoding.UTF8.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"ImageNo\"\r\n\r\n{1}\r\n", boundary, ImageNo)));
            formData.AddRange(Encoding.UTF8.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"ModifiedDate\"\r\n\r\n{1}\r\n", boundary, formattedDate)));
            formData.AddRange(Encoding.UTF8.GetBytes(string.Format("--{0}\r\nContent-Disposition: form-data; name=\"FileName\"\r\n\r\n{1}\r\n", boundary, Path.GetFileName(filePath))));
            formData.AddRange(Encoding.UTF8.GetBytes("--" + boundary + "--"));

            try
            {
                byte[] response = client.UploadData(targetUri, "POST", formData.ToArray());
                string responseString = Encoding.UTF8.GetString(response);
                if (responseString != "")
                {
                    //MessageBox.Show(responseString);
                }
                return responseString; //Console.WriteLine(responseString);
            }
            catch (WebException e)
            {
                string Error = "";
                Error = ("An error occurred: " + e.Message);
                if (e.InnerException != null)
                {
                    Error = Error + (" Inner Exception: " + e.InnerException.Message);
                }
                if (e.Response != null)
                {
                    using (var reader = new StreamReader(e.Response.GetResponseStream()))
                    {
                        Error = Error + (" Response: " + reader.ReadToEnd());
                    }
                }
                return Error;
            }
        }
       
        public void FetchImagesFromService()
        {
            // Bypass the SSL Certificate validation
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; // This corresponds to TLS 1.2
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; // Or Tls, Tls11, depending on server configuration



            // string url = "https://192.168.1.111:7050/Images?mozaId=15113&documentTypeId=11&recordNo=11";
            //string url = "http://192.168.1.111:5162/Images?mozaId=15113&documentTypeId=11&recordNo=11"; // ssl port mentioned in launchSettings.json of web api
            //string url = "https://172.16.100.130:5002/Images?mozaId=15113&documentTypeId=11&recordNo=11"; // ssl port mentioned in launchSettings.json of web api
            string url = "https://kplr.gkp.pk/:5002/Images?mozaId=15113&documentTypeId=11&recordNo=11"; // ssl port mentioned in launchSettings.json of web api

            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] responseData = client.DownloadData(url);
                    string responseString = System.Text.Encoding.UTF8.GetString(responseData);
                    Console.WriteLine(responseString);
                }
                catch (WebException e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                    if (e.InnerException != null)
                    {
                        Console.WriteLine("Inner Exception: " + e.InnerException.Message);
                    }
                    // Rest of your code...
                }

            }
        }

        #endregion
    }
}
