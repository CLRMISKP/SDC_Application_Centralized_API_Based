
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using SDC_Application.Classess;
using static DPFP.Verification.Verification;

namespace SDC_Application
{
    public class APIClient
    {
        string baseUrlReader;
        string baseUrlScalar;
        string baseUrlNonQuery;
        string baseUrlDistrict;
        string baseUrlTehsilbyDist;
        string baseUrlLogin;
        string baseUrlLogout;
        string baseUrlMacInfo;
        string baseUrlMachineAccessRights;
        string baseUrlGetIntiqalPersonImage;
        string baseUrlGetGardawar;
        string baseUrlExecuteCommand;
        string baseUrlGetIntiqalPersonImage64;
        string baseUrlExecuteCommandFard;
        string baseUrlExecuteCommandInserUser;
        string baseUrlGetFardPersonImage;
        string baseUrlUserInfo;

        public APIClient()
        {
            // change to 1. reporting file, 2. API Client, 3. AfradRegister Shajra Link

            // Server Machine KPRA - Dir Kalam APIs
            //baseUrlReader = "http://175.107.62.190:1098/api/executeReader/execute";
            //baseUrlScalar = "http://175.107.62.190:1098/api/executeScalar/execute";
            //baseUrlNonQuery = "http://175.107.62.190:1098/api/executeNonQuery/execute";
            //baseUrlDistrict = "http://175.107.62.190:1098/api/executeReader/getDistricts";
            //baseUrlTehsilbyDist = "http://175.107.62.190:1098/api/executeReader/getDistrictTehsils?id=";
            //baseUrlLogin = "http://175.107.62.190:1098/api/executeReader/login";
            //baseUrlLogout = "http://175.107.62.190:1098/api/executeNonQuery/logout";
            ////baseUrlLogout= "http://175.107.63.31:9080/api/executeNonQuery/logout";

            // Server Machine KPRA - Dir Kalam APIs with HTTPS
            //baseUrlReader = "https://175.107.62.190:1099/api/executeReader/execute";
            //baseUrlScalar = "https://175.107.62.190:1099/api/executeScalar/execute";
            //baseUrlNonQuery = "https://175.107.62.190:1099/api/executeNonQuery/execute";
            //baseUrlDistrict = "https://175.107.62.190:1099/api/executeReader/getDistricts";
            //baseUrlTehsilbyDist = "https://175.107.62.190:1099/api/executeReader/getDistrictTehsils?id=";
            //baseUrlLogin = "https://175.107.62.190:1099/api/executeReader/login";
            //baseUrlLogout = "https://175.107.62.190:1099/api/executeNonQuery/logout";
            ////baseUrlLogout= "https://175.107.63.31:9080/api/executeNonQuery/logout";

            // Server Machine Data Center - CLRMIS  APIs
            //baseUrlReader = "http://localhost:65171/api/executeReader/execute";
            baseUrlReader = "https://kplr.gkp.pk:5001/api/executeReader/execute";
            baseUrlScalar = "https://kplr.gkp.pk:5001/api/executeScalar/execute";
            baseUrlNonQuery = "https://kplr.gkp.pk:5001/api/executeNonQuery/execute";
            baseUrlDistrict = "https://kplr.gkp.pk:5001/api/executeReader/getDistricts";
            baseUrlTehsilbyDist = "https://kplr.gkp.pk:5001/api/executeReader/getDistrictTehsils?id=";
            baseUrlLogin = "https://kplr.gkp.pk:5001/api/executeReader/login";
            baseUrlUserInfo = "https://kplr.gkp.pk:5001/api/executeReader/userInfo";
            baseUrlMacInfo = "https://kplr.gkp.pk:5001/api/executeReader/GetMachineInfo";
            baseUrlMachineAccessRights = "https://kplr.gkp.pk:5001/api/executeReader/GetMachineAccessRights";
            baseUrlLogout = "https://kplr.gkp.pk:5001/api/executeNonQuery/logout";
            baseUrlGetIntiqalPersonImage = "https://kplr.gkp.pk:5001/api/executeReader/GetIniqalPersonPicBoimetric?TehsilId=";
            baseUrlGetIntiqalPersonImage64 = "http://localhost:65171/api/executeReader/GetIniqalPersonPicBoimetricBase64?TehsilId="; //"https://kplr.gkp.pk:5001/api/executeReader/GetIniqalPersonPicBoimetricBase64?TehsilId=";
            baseUrlGetGardawar = "https://kplr.gkp.pk:5001/api/executeReader/GetGardwar?TehsilId=";// {TehsilId}&SubSdcId={SubSdcId}&dataTableName={dataTableName}";
            baseUrlExecuteCommand = "https://kplr.gkp.pk:5001/api/executeScalar/executeBio"; //api/executeScalar/executeBioFard
            baseUrlExecuteCommandFard = "https://kplr.gkp.pk:5001/api/executeScalar/executeBioFard"; //api/executeScalar/executeBioFard
            baseUrlExecuteCommandInserUser = "https://kplr.gkp.pk:5001/api/executeScalar/executeInsertUserProfile";
            baseUrlGetFardPersonImage = "https://kplr.gkp.pk:5001/api/executeReader/GetFardPersonPicBoimetric?TehsilId=";

            //baseUrlLogout= "http://kplr.gkp.pk:5001/api/executeReader/GetIniqalPersonPicBoimetric?TehsilId=";api/executeScalar/executeInsertUserProfile

            // Server Machine Data Center - Dir Kalam APIs
            //baseUrlReader = "https://175.107.63.31:5003/api/executeReader/execute";
            //baseUrlScalar = "https://175.107.63.31:5003/api/executeScalar/execute";
            //baseUrlNonQuery = "https://175.107.63.31:5003/api/executeNonQuery/execute";
            //baseUrlDistrict = "https://175.107.63.31:5003/api/executeReader/getDistricts";
            //baseUrlTehsilbyDist = "https://175.107.63.31:5003/api/executeReader/getDistrictTehsils?id=";
            //baseUrlLogin = "https://175.107.63.31:5003/api/executeReader/login";
            //baseUrlLogout = "https://175.107.63.31:5003/api/executeNonQuery/logout";
            //baseUrlLogout= "https://175.107.63.31:9080/api/executeNonQuery/logout";

            // local System
            //baseUrlReader = "http://localhost:65171/api/executeReader/execute";
            //baseUrlScalar = "http://localhost:65171/api/executeScalar/execute";
            //baseUrlNonQuery = "http://localhost:65171/api/executeNonQuery/execute";
            //baseUrlDistrict = "http://localhost:65171/api/executeReader/getDistricts";
            //baseUrlTehsilbyDist = "http://localhost:65171/api/executeReader/getDistrictTehsils?id=";
            //baseUrlLogin = "http://localhost:65171/api/executeReader/login";
            //baseUrlLogout = "http://localhost:65171/api/executeNonQuery/logout";
            ////baseUrlLogout= "http://175.107.63.31:9080/api/executeNonQuery/logout";
        }

        #region Get district and Tehsils List
        public DataTable GetDistrictList(string token)
        {
            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable();
                this.MakeClientSettings(client, baseUrlDistrict, token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                //var jsonStr = JsonConvert.SerializeObject(request);
                //var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage =  client.GetAsync(baseUrlDistrict);// PostAsync(this.baseUrlReader, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;
                client.Dispose();
                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        dt = this.JsonStringToDataTable(data);
                    else
                        dt = null;
                }
                return dt;
            }
        }
        public DataTable GetTehsilList(string DistrictId, string token)
        {
            
            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable();
                this.MakeClientSettings(client, baseUrlTehsilbyDist+DistrictId, token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                //var jsonStr = JsonConvert.SerializeObject(request);
                //var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.GetAsync(baseUrlTehsilbyDist + DistrictId);// PostAsync(this.baseUrlReader, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;
                client.Dispose();
                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        dt = this.JsonStringToDataTable(data);
                    else
                        dt = null;
                }
                return dt;
            }
        }

        public DataTable UserAuthentication(UserRequestLogin request)
        {
            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable();
                this.MakeClientSettings(client, baseUrlLogin,"");
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.PostAsync(this.baseUrlLogin, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;
                client.Dispose();
                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        dt = this.JsonStringToDataTable(data);
                    else
                        dt = null;
                }
                return dt;
            }
        }
        public DataTable GetUserInfo(UserInfoForMachinReg request)
        {
            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable();
                this.MakeClientSettings(client, baseUrlLogin, "");
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.PostAsync(this.baseUrlUserInfo, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;
                client.Dispose();
                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        dt = this.JsonStringToDataTable(data);
                    else
                        dt = null;
                }
                return dt;
            }
        }
        public DataTable GetMacInfo(MachineRegistrationDetails request)
        {
            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable();
                this.MakeClientSettings(client, baseUrlMacInfo, "");
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.PostAsync(this.baseUrlMacInfo, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;
                client.Dispose();
                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        dt = this.JsonStringToDataTable(data);
                    else
                        dt = null;
                }
                return dt;
            }
        }
        public DataTable GetMachineAccessRights(MachineRegistrationDetails request)
        {
            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable();
                this.MakeClientSettings(client, baseUrlMachineAccessRights, "");
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.PostAsync(this.baseUrlMachineAccessRights, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;
                client.Dispose();
                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        dt = this.JsonStringToDataTable(data);
                    else
                        dt = null;
                }
                return dt;
            }
        }
        #endregion

        public DataTable GetData(UserRequest request, string token)
        {
            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable();
                this.MakeClientSettings(client, baseUrlReader, token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                var jsonStr=JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.PostAsync(this.baseUrlReader, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;
                client.Dispose();
                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        dt = this.JsonStringToDataTable(data);
                    else
                        dt = null;
                }
                return dt;
            }
        }

        #region Execute Scalar

        public string exexuteScalar(UserRequest request, string token)
        {
            using (var client = new HttpClient())
            {
                string rtVal = "0";
                this.MakeClientSettings(client, baseUrlScalar, token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage =client.PostAsync(this.baseUrlScalar, content);
                var data =responseMessage.Result.Content.ReadAsStringAsync().Result;

                if (responseMessage.IsCompleted)
                {
                    if(data!= "\"[]\"")
                    rtVal = data.Trim('"');
                    else
                        rtVal = "0";
                }
                client.Dispose();
                return rtVal;
                
            }
        }
        public string exexuteScalarWithPicBio(UserRequestIwthPicBiometric request, string token)
        {
            using (var client = new HttpClient())
            {
                string rtVal = "0";
                this.MakeClientSettings(client, baseUrlScalar, token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.PostAsync(this.baseUrlExecuteCommand, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;

                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        rtVal = (data).ToString().Trim('"');
                    else
                        rtVal = "0";
                }
                client.Dispose();
                return rtVal;

            }
        }
        public string exexuteScalarWithPicBio(UserRequestBioFard request, string token)
        {
            using (var client = new HttpClient())
            {
                string rtVal = "0";
                this.MakeClientSettings(client, baseUrlScalar, token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.PostAsync(this.baseUrlExecuteCommandFard, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;

                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        rtVal = (data).ToString().Trim('"');
                    else
                        rtVal = "0";
                }
                client.Dispose();
                return rtVal;

            }
        }
        public string exexuteScalarWithPicBio(UserRequestUserProfile request, string token)
        {
            using (var client = new HttpClient())
            {
                string rtVal = "0";
                this.MakeClientSettings(client, baseUrlScalar, token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.PostAsync(this.baseUrlExecuteCommandInserUser, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;

                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        rtVal = (data).ToString().Trim('"');
                    else
                        rtVal = "0";
                }
                client.Dispose();
                return rtVal;

            }
        }

        #endregion
        #region Execute Scalar  / Command

        public string executeCommand(UserRequest request, string token)
        {
            using (var client = new HttpClient())
            {
                string rtVal = "0";
                this.MakeClientSettings(client, baseUrlScalar, token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.PostAsync(this.baseUrlExecuteCommand, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;

                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                        rtVal = JsonStringToDataTable(data).Rows[0][0].ToString();
                    else
                        rtVal = "0";
                }
                client.Dispose();
                return rtVal;

            }
        }

        #endregion

        #region Execute Non Query

        public void executeNonQuery(UserRequest request, string token)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    this.MakeClientSettings(client, baseUrlNonQuery, token);
                    //client.PostAsync(this.baseUrlNonQuery, request);
                    var jsonStr = JsonConvert.SerializeObject(request);
                    var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                    var result = client.PostAsync(this.baseUrlNonQuery, content);
                    client.Dispose();
                    if (result.IsCompleted)
                    {

                    }
                    else
                    {
                        string ret = result.Result.ReasonPhrase;
                    }
                }
                catch (Exception ex)
                {

                    //throw;
                }

            }
        }
        public void UserLogout(UserRequest request, string token)
        {
            using (var client = new HttpClient())
            {
                this.MakeClientSettings(client, baseUrlLogout, token);
                //client.PostAsync(this.baseUrlNonQuery, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                client.GetAsync(baseUrlLogout);
                client.Dispose();
            }
        }

        #endregion

        public DataTable JsonStringToDataTable(string jsonString)
        {
            DataTable dt = new DataTable();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            List<string> ColumnsName = new List<string>();
            foreach (string jSA in jsonStringArray)
            {
                int counter = 0;
                string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",\\\\");
                foreach (string ColumnsNameData in jsonStringData)
                {
                    try
                    {
                        int idx = ColumnsNameData.IndexOf(":");
                        string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                        if (!ColumnsName.Contains(ColumnsNameString))
                        {
                            ColumnsNameString = ColumnsNameString.Replace("\\", String.Empty);
                            ColumnsName.Add(ColumnsNameString);
                        }
                        counter = counter + 1;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                    }
                }
                break;
            }
            foreach (string AddColumnName in ColumnsName)
            {
                dt.Columns.Add(AddColumnName);
            }
            foreach (string jSA in jsonStringArray)
            {
                string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",\\\\");
                DataRow nr = dt.NewRow();
                foreach (string rowData in RowData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", String.Empty);
                        RowColumns = RowColumns.Replace("\\", "");
                        string RowDataString = rowData.Substring(idx + 1).Replace("\"", String.Empty);
                        RowDataString = RowDataString.Replace("\\", "");
                        nr[RowColumns] = rowData.Contains("Token")? RowDataString: RowDataString.Replace("rn", "-");
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                dt.Rows.Add(nr);
            }
            return dt;
        }
        public List<IntiqalPersonImages> JsonStringToList(string jsonString)
        {
           return IntiqalPersonImages.JsonToList(jsonString);

        }
        public List<IntiqalPersonImages> GetIntiqalPersonImages(string TehsilId, string IntiqalId, string PersonId, string Token)
        {
            //IEnumerable<IntiqalPersonsList> personImages = null;
            using (var client = new HttpClient())
            {
                List<IntiqalPersonImages> dt = new List<IntiqalPersonImages>();
                string baseUrlPersonImage = baseUrlGetIntiqalPersonImage + TehsilId + "&IntiqalId=" + IntiqalId + "&PersonId=" + PersonId;
                this.MakeClientSettings(client,baseUrlPersonImage , Token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                //var jsonStr = JsonConvert.SerializeObject(request);
                //var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var response = client.GetAsync(baseUrlPersonImage);// PostAsync(this.baseUrlReader, content);
                var data =@""+ response.Result.Content.ReadAsStringAsync().Result;
                if (response.IsCompleted)
                {
                    if (data != "\"[]\"")
                        dt = this.JsonStringToList(data);
                    else
                        dt = null;
                }
                return dt;
            }
        }
        public List<FardPersonImages> GetFardlPersonImages(string TehsilId, string TokenId,string PersonId, string FardRepRecId, string Token)
        {
            //IEnumerable<IntiqalPersonsList> personImages = null;
            using (var client = new HttpClient())
            {
                List<FardPersonImages> dt = new List<FardPersonImages>();
                string baseUrlPersonImage = baseUrlGetFardPersonImage + TehsilId + "&TokenId=" + TokenId + "&PersonId=" + PersonId+ "&FardRepRecId="+FardRepRecId;
                this.MakeClientSettings(client, baseUrlPersonImage, Token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                //var jsonStr = JsonConvert.SerializeObject(request);
                //var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var response = client.GetAsync(baseUrlPersonImage);// PostAsync(this.baseUrlReader, content);
                var data = @"" + response.Result.Content.ReadAsStringAsync().Result;
                if (response.IsCompleted)
                {
                    if (data != "\"[]\"")
                        dt = FardPersonImages.JsonToList(data);
                    else
                        dt = null;
                }
                return dt;
            }
        }
        public List<IntiqalPersonImagesBase64> GetIntiqalPersonImagesBase64(string TehsilId, string IntiqalId, string PersonId, string Token)
        {
            //IEnumerable<IntiqalPersonsList> personImages = null;
            using (var client = new HttpClient())
            {
                List<IntiqalPersonImagesBase64> dt = new List<IntiqalPersonImagesBase64>();
               
                //DataTable dt = new DataTable();
                string baseUrlPersonImage = baseUrlGetIntiqalPersonImage64 + TehsilId + "&IntiqalId=" + IntiqalId + "&PersonId=" + PersonId;
                this.MakeClientSettings(client, baseUrlPersonImage, Token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                //var jsonStr = JsonConvert.SerializeObject(request);
                //var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var response = client.GetAsync(baseUrlPersonImage);// PostAsync(this.baseUrlReader, content);
                var data = response.Result.Content.ReadAsStringAsync().Result;
                if (response.IsCompleted)
                {
                    if (data != "\"[]\"")
                    {
                        try
                        {
                            
                            
                        }
                        catch (JsonException)
                        {
                            // Handle other JSON errors
                            return new List<IntiqalPersonImagesBase64>();
                        }
                    }
                    else
                        dt = null;
                }
                return dt;
            }
        }
        public List<RoGardwar> GetGardwar(string TehsilId, string SubSdcId, string Token, string For)
        {
            using (var client = new HttpClient())
            {
                List<RoGardwar> dt = null;
                string baseUrlGardwar = baseUrlGetGardawar + TehsilId + "&SubSdcId=" + SubSdcId+"&For="+For ;
                this.MakeClientSettings(client, baseUrlGardwar, Token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                //var jsonStr = JsonConvert.SerializeObject(request);
                //var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.GetAsync(baseUrlGardwar);// PostAsync(this.baseUrlReader, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;
                client.Dispose();
                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                    {
                        dt= RoGardwar.JsonToList(data);
                    }
                    else
                        dt = null;
                }
                return dt;
            }
        }
        public List<RoGardwar> GetRoGardwar(string TehsilId, string SubSdcId, string dataTableName, string Token)
        {
            using (var client = new HttpClient())
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                List<RoGardwar> roGardwars = new List<RoGardwar>();
                string baseUrlGardwar = baseUrlGetGardawar + TehsilId + "&SubSdcId=" + SubSdcId + "&dataTableName=" + dataTableName;
                this.MakeClientSettings(client, baseUrlGardwar, Token);
                //var responseMessage = client.PostAsync(this.baseUrl, request);
                //var jsonStr = JsonConvert.SerializeObject(request);
                //var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var responseMessage = client.GetAsync(baseUrlGardwar);// PostAsync(this.baseUrlReader, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;
                client.Dispose();
                if (responseMessage.IsCompleted)
                {
                    if (data != "\"[]\"")
                    {
                        //XmlToDataSetConverter xmlToDataSetConverter = new XmlToDataSetConverter();
                        //roGardwars = RoGardwar.XmlToObjectList(data);
                        //using (StringReader sr = new StringReader(data))
                        //{
                        //    ds.ReadXml(sr);
                        //}
                    }
                    else
                        roGardwars = null;
                }
                return roGardwars;
            }
        }

        //Do client settings for every request
        private void MakeClientSettings(HttpClient client, string baseUrl, string token)
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Add("Bearer",  token);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }
}
