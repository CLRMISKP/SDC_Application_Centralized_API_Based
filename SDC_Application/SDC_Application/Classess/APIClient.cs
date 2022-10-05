
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using Json.NET.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public APIClient()
        {
            baseUrlReader = "http://175.107.63.31:9080/api/executeReader/execute";
            baseUrlScalar = "http://175.107.63.31:9080/api/executeScalar/execute";
            baseUrlNonQuery = "http://175.107.63.31:9080/api/executeNonQuery/execute";
            baseUrlDistrict = "http://175.107.63.31:9080/api/executeReader/getDistricts";
            baseUrlTehsilbyDist= "http://175.107.63.31:9080/api/executeReader/getDistrictTehsils?id=";
            baseUrlLogin= "http://175.107.63.31:9080/api/executeReader/login";
            baseUrlLogout= "http://175.107.63.31:9080/api/executeNonQuery/logout";
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
                var responseMessage = client.GetAsync(baseUrlDistrict);// PostAsync(this.baseUrlReader, content);
                var data = responseMessage.Result.Content.ReadAsStringAsync().Result;

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
                var responseMessage =client.PostAsync(this.baseUrlReader, content);
                var data =responseMessage.Result.Content.ReadAsStringAsync().Result;

                if (responseMessage.IsCompleted)
                {
                    rtVal =JsonStringToDataTable( data).Rows[0][0].ToString();
                }
                return rtVal;
            }
        }

        #endregion

        #region Execute Non Query

        public void executeNonQuery(UserRequest request, string token)
        {
            using (var client = new HttpClient())
            {
                this.MakeClientSettings(client, baseUrlNonQuery, token);
                //client.PostAsync(this.baseUrlNonQuery, request);
                var jsonStr = JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
                var result = client.PostAsync(this.baseUrlNonQuery, content);
                if (result.IsCompleted)
                {

                }
                else
                {
                    string ret=result.Result.ReasonPhrase;
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
                        nr[RowColumns] = RowDataString.Replace("rn","-");
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                dt.Rows.Add(nr);
            }
            return dt;
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
