using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SDC_Application.Classess
{

    public class IntiqalPersonImages
    {

        [JsonProperty]
        public string IntialPersonImageId { get; set; }
        [JsonProperty]
        public string PersonId { get; set; }
        [JsonProperty]
        public string CompleteName { get; set; }
        [JsonProperty]
        public byte[] PersonPic { get; set; }
        [JsonProperty]
        public byte[] PersonFingerPrint { get; set; }

        public static List<IntiqalPersonImages> JsonToList(string jsonString)
        {
            List<IntiqalPersonImages> people = new List<IntiqalPersonImages>();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            int arraySize = jsonStringArray.Length; int indx = 1;
            foreach (string rowData in jsonStringArray)
            {

                try
                {
                    
                    IntiqalPersonImages person = new IntiqalPersonImages();
                    int idx = rowData.IndexOf("PersonFingerPrint");
                    person.IntialPersonImageId = rowData.Substring(rowData.IndexOf("IntialPersonImageId\":\"") + 22, rowData.IndexOf("PersonId\":\"") - (rowData.IndexOf("IntialPersonImageId\":\"") + 25));
                    person.PersonId = rowData.Substring(rowData.IndexOf("PersonId\":\"") + 11, rowData.IndexOf("CompleteName\":\"") - (rowData.IndexOf("PersonId\":\"") + 14));
                    person.CompleteName = rowData.Substring(rowData.IndexOf("CompleteName\":\"") + 15, rowData.IndexOf("PersonPic\":\"") - (rowData.IndexOf("CompleteName\":\"") + 18));
                    string personPc = rowData.Substring(rowData.IndexOf("PersonPic\":\"") + 12, rowData.IndexOf("PersonFingerPrint") - (rowData.IndexOf("PersonPic\":\"") + 15));
                    string PersonFinger = rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.Length - rowData.IndexOf("PersonFingerPrint\":\"") - 21);
                    person.PersonPic = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("PersonPic\":\"") + 12, rowData.IndexOf("PersonFingerPrint") - (rowData.IndexOf("PersonPic\":\"") + 15)));
                    if (arraySize > indx)
                    {
                        person.PersonFingerPrint = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.Length - rowData.IndexOf("PersonFingerPrint\":\"") - 21));
                    }
                    else
                    {
                        string PersonFinger1 = rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.IndexOf("\"},\"Id\"") - (rowData.IndexOf("PersonFingerPrint\":\"") + 20));
                        person.PersonFingerPrint = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.IndexOf("\"},\"Id\"") - (rowData.IndexOf("PersonFingerPrint\":\"") + 20)));
                    }
                    people.Add(person);
                    indx = indx + 1;
                }
                catch (Exception)
                {
                    continue;
                }

            }
            return people;

        }
    }
    public class RoGardwar
    {

        [JsonProperty]
        public string RecStatus { get; set; }
        [JsonProperty]
        public string UserId { get; set; }
        [JsonProperty]
        public string CompleteName { get; set; }
        [JsonProperty]
        public string LoginName { get; set; }
        [JsonProperty]
        public byte[] FingerPrintImage { get; set; }

        public static List<RoGardwar> JsonToList(string jsonString)
        {
            List<RoGardwar> people = new List<RoGardwar>();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            int arraySize = jsonStringArray.Length; int indx = 1;
            foreach (string rowData in jsonStringArray)
            {

                try
                {

                    RoGardwar person = new RoGardwar();
                    int idx = rowData.IndexOf("UserId");
                    person.RecStatus = rowData.Substring(rowData.IndexOf("RecStatus\":\"") + 12, rowData.IndexOf("UserId") - (rowData.IndexOf("RecStatus\":\"") + 15));
                    person.UserId = rowData.Substring(rowData.IndexOf("UserId\":\"") + 9, rowData.IndexOf("CompleteName\":\"") - (rowData.IndexOf("UserId\":\"") + 12));
                    person.CompleteName = rowData.Substring(rowData.IndexOf("CompleteName\":\"") + 15, rowData.IndexOf("LoginName\":\"") - (rowData.IndexOf("CompleteName\":\"") + 18));
                    person.LoginName = rowData.Substring(rowData.IndexOf("LoginName\":\"") + 12, rowData.IndexOf("FingerPrintImage\":\"") - (rowData.IndexOf("LoginName\":\"") + 15));
                    //string personPc = rowData.Substring(rowData.IndexOf("PersonPic\":\"") + 12, rowData.IndexOf("PersonFingerPrint") - (rowData.IndexOf("PersonPic\":\"") + 15));
                    string PersonFinger = rowData.Substring(rowData.IndexOf("FingerPrintImage\":\"") + 19, rowData.Length - rowData.IndexOf("FingerPrintImage\":\"") - 20);

                    if (arraySize > indx)
                    {
                        person.FingerPrintImage = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("FingerPrintImage\":\"") + 19, rowData.Length - rowData.IndexOf("FingerPrintImage\":\"") - 20));
                    }
                    else
                    {
                        string PersonFinger1 = rowData.Substring(rowData.IndexOf("FingerPrintImage\":\"") + 19, rowData.IndexOf("\"},\"Id\"") - (rowData.IndexOf("FingerPrintImage\":\"") + 20));
                        person.FingerPrintImage = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("FingerPrintImage\":\"") + 19, rowData.IndexOf("\"},\"Id\"") - (rowData.IndexOf("FingerPrintImage\":\"") + 19)));
                    }
                    people.Add(person);
                    indx = indx + 1;
                    //JsonUtility util= new JsonUtility(rowData);
                    //if(rowData.Contains("Result"))
                    //{
                    //    string data=util.Get("Result");
                    //    JsonUtility util1 = new JsonUtility(data);
                    //    util = util1;
                    //}

                    //// Extract needed fields
                    //person.RecStatus = util.Get("RecStatus");
                    //person.UserId = util.Get("UserId");
                    //person.CompleteName= util.Get("CompleteName");
                    //person.LoginName = util.Get("LoginName");
                    //try
                    //{
                    //    person.FingerPrintImage = Convert.FromBase64String(util.Get("FingerPrintImage"));
                    //}
                    //catch (Exception)
                    //{
                    //    person.FingerPrintImage = null;
                    //}

                    //people.Add(person);
                }
                catch (Exception)
                {
                    continue;
                }

            }
            return people;

        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dt = new DataTable(typeof(T).Name);

            // Get all the properties
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Create columns
            foreach (PropertyInfo prop in props)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Add rows
            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null) ?? DBNull.Value;
                }
                dt.Rows.Add(values);
            }

            return dt;
        }

    }
    public class PersonImageRoot
    {
        [JsonProperty("IntiqalPersonImagesBase64")]
        public List<IntiqalPersonImagesBase64> IntiqalPersonImagesBase64 { get; set; }
    }
    public class IntiqalPersonImagesBase64
    {
        [JsonProperty("IntialPersonImageId")]
        public string IntialPersonImageId { get; set; }
        [JsonProperty("PersonId")]
        public string PersonId { get; set; }
        [JsonProperty("CompleteName")]
        public string CompleteName { get; set; }
        [JsonProperty("PersonPic")]
        public string PersonPic { get; set; }
        [JsonProperty("PersonFingerPrint")]
        public string PersonFingerPrint { get; set; }

        public static List<IntiqalPersonImagesBase64> JsonToListBase64(string jsonString)
        {
            List<IntiqalPersonImagesBase64> people = new List<IntiqalPersonImagesBase64>();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            int arraySize = jsonStringArray.Length; int indx = 1;
            foreach (string rowData in jsonStringArray)
            {

                try
                {
                    
                    IntiqalPersonImagesBase64 person = new IntiqalPersonImagesBase64();
                    int idx = rowData.IndexOf("PersonFingerPrint");
                    person.IntialPersonImageId = rowData.Substring(rowData.IndexOf("IntialPersonImageId\":\"") + 22, rowData.IndexOf("PersonId\":\"") - (rowData.IndexOf("IntialPersonImageId\":\"") + 25));
                    person.PersonId = rowData.Substring(rowData.IndexOf("PersonId\":\"") + 11, rowData.IndexOf("CompleteName\":\"") - (rowData.IndexOf("PersonId\":\"") + 14));
                    person.CompleteName = rowData.Substring(rowData.IndexOf("CompleteName\":\"") + 15, rowData.IndexOf("PersonPic\":\"") - (rowData.IndexOf("CompleteName\":\"") + 18));
                    string personPc = rowData.Substring(rowData.IndexOf("PersonPic\":\"") + 12, rowData.IndexOf("PersonFingerPrint") - (rowData.IndexOf("PersonPic\":\"") + 15));
                    string PersonFinger = rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.Length - rowData.IndexOf("PersonFingerPrint\":\"") - 21);
                    //person.PersonPic = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("PersonPic\":\"") + 12, rowData.IndexOf("PersonFingerPrint") - (rowData.IndexOf("PersonPic\":\"") + 15)));
                    //if (arraySize > indx)
                    //{
                    //    person.PersonFingerPrint = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.Length - rowData.IndexOf("PersonFingerPrint\":\"") - 21));
                    //}
                    //else
                    //{
                    //    string PersonFinger1 = rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.IndexOf("\"},\"Id\"") - (rowData.IndexOf("PersonFingerPrint\":\"") + 20));
                    //    person.PersonFingerPrint = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.IndexOf("\"},\"Id\"") - (rowData.IndexOf("PersonFingerPrint\":\"") + 20)));
                    //}
                    people.Add(person);
                    indx = indx + 1;
                }
                catch (Exception)
                {
                    continue;
                }

            }
            return people;

        }

    }
    public class FardPersonImages
    {
        [JsonProperty("FardPersonFingerId")]
        public string FardPersonFingerId { get; set; }

        [JsonProperty("PersonId")]
        public string PersonId { get; set; }

        [JsonProperty("PersonPic")]
        public byte[] PersonPic { get; set; }

        [JsonProperty("PersonFingerPrint")]
        public byte[] PersonFingerPrint { get; set; }

        public static List<FardPersonImages> JsonToList(string jsonString)
        {
            List<FardPersonImages> people = new List<FardPersonImages>();
            string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
            int arraySize = jsonStringArray.Length; int indx = 1;
            foreach (string rowData in jsonStringArray)
            {

                try
                {
                    
                    FardPersonImages person = new FardPersonImages();
                    int idx = rowData.IndexOf("PersonFingerPrint");
                    person.FardPersonFingerId = rowData.Substring(rowData.IndexOf("FardPersonFingerId\":\"") + 21, rowData.IndexOf("PersonId\":\"") - (rowData.IndexOf("FardPersonFingerId\":\"") + 24));
                    person.PersonId = rowData.Substring(rowData.IndexOf("PersonId\":\"") + 11, rowData.IndexOf("PersonPic\":\"") - (rowData.IndexOf("PersonId\":\"") + 14));
                    string personPc = rowData.Substring(rowData.IndexOf("PersonPic\":\"") + 12, rowData.IndexOf("PersonFingerPrint") - (rowData.IndexOf("PersonPic\":\"") + 15));
                    person.PersonPic = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("PersonPic\":\"") + 12, rowData.IndexOf("PersonFingerPrint") - (rowData.IndexOf("PersonPic\":\"") + 15)));
                  
                    //person.CompleteName = rowData.Substring(rowData.IndexOf("CompleteName\":\"") + 15, rowData.IndexOf("PersonPic\":\"") - (rowData.IndexOf("CompleteName\":\"") + 18));
                    
                    string PersonFinger = rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.Length - rowData.IndexOf("PersonFingerPrint\":\"") - 21);
                    
                    if (arraySize > indx)
                    {
                        person.PersonFingerPrint = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.Length - rowData.IndexOf("PersonFingerPrint\":\"") - 21));
                    }
                    else
                    {
                        string PersonFinger1 = rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.IndexOf("\"},\"Id\"") - (rowData.IndexOf("PersonFingerPrint\":\"") + 20));
                        person.PersonFingerPrint = Convert.FromBase64String(rowData.Substring(rowData.IndexOf("PersonFingerPrint\":\"") + 20, rowData.IndexOf("\"},\"Id\"") - (rowData.IndexOf("PersonFingerPrint\":\"") + 20)));
                    }
                    people.Add(person);
                    indx = indx + 1;
                }
                catch (Exception)
                {
                    continue;
                }

            }
            return people;

        }
    }
    }
