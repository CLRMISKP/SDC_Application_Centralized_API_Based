using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace SDC_Application.Classess
{
    public class XmlToDataSetConverter
    {
        public DataTable ConvertXmlToDataSet(string xmlData)
        {
            DataTable ds = new DataTable();
            xmlData = RemoveBom(xmlData);
            xmlData = SanitizeXmlString(xmlData);
            // Solution: Add validation
            if (string.IsNullOrWhiteSpace(xmlData))
            {
                throw new ArgumentException("XML data is empty or null");
            }
            ds=convertXmlToDataSet(xmlData);
            // Configure the DataSet to handle binary serialization
            //ds.RemotingFormat = SerializationFormat.Binary;
            //using (StringReader sr = new StringReader(xmlData))
            //using (XmlTextReader reader = new XmlTextReader(sr))
            //{
            //    // Read the XML into the DataSet
            //    ds.ReadXml(reader, XmlReadMode.ReadSchema);

            //    // Ensure all binary columns are properly typed
            //    foreach (DataTable table in ds.Tables)
            //    {
            //        foreach (DataColumn column in table.Columns)
            //        {
            //            if (column.DataType == typeof(string) &&
            //                column.ColumnName.EndsWith("Image") ||
            //                column.ColumnName.Equals("Finger", StringComparison.OrdinalIgnoreCase))
            //            {
            //                // Check if the string might actually be Base64 binary data
            //                if (table.Rows.Count > 0 && table.Rows[0][column] is string)
            //                {
            //                    try
            //                    {
            //                        byte[] test = Convert.FromBase64String(table.Rows[0][column] as string);
            //                        column.DataType = typeof(byte[]);

            //                        // Convert all rows
            //                        foreach (DataRow row in table.Rows)
            //                        {
            //                            if (row[column] != DBNull.Value)
            //                            {
            //                                row[column] = Convert.FromBase64String(row[column] as string);
            //                            }
            //                        }
            //                    }
            //                    catch (FormatException)
            //                    {
            //                        // Not Base64, leave as string
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            return ds;
        }
        public static string RemoveBom(string xml)
        {
            string bomMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            if (xml.StartsWith(bomMarkUtf8))
            {
                xml = xml.Remove(0, bomMarkUtf8.Length);
            }
            return xml;
        }
        // Solution: Trim and validate XML
        public static string SanitizeXml(string xml)
        {
            xml = xml.Trim();

            // Remove any non-XML content before the opening tag
            int firstOpen = xml.IndexOf('<');
            if (firstOpen > 0)
            {
                xml = xml.Substring(firstOpen);
            }

            return xml;
        }
        // Solution: Ensure proper encoding
        public static DataTable convertXmlToDataSet(string xmlData)
        {
            // First ensure proper encoding
            byte[] byteArray = Encoding.UTF8.GetBytes(xmlData);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                DataTable ds = new DataTable();
                ds.ReadXml(stream);
                return ds;
            }
        }
        public static DataSet SafeXmlToDataSet(string xmlData)
        {
            try
            {
                // 1. First validate and clean the XML
                xmlData = SanitizeXmlString(xmlData);
                xmlData = RemoveBom(xmlData);
                // Solution: Add validation
                if (string.IsNullOrWhiteSpace(xmlData))
                {
                    throw new ArgumentException("XML data is empty or null");
                }
                // 2. Use XmlReaderSettings for proper handling
                XmlReaderSettings settings = new XmlReaderSettings
                {
                    CheckCharacters = false, // Allows more character flexibility
                    IgnoreProcessingInstructions = true,
                    IgnoreComments = true,
                    ValidationType = ValidationType.None
                };

                // 3. Parse using StringReader and XmlReader
                using (StringReader sr = new StringReader(xmlData))
                using (XmlReader xr = XmlReader.Create(sr, settings))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(xr);
                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw new XmlException("Failed to convert XML to DataSet", ex);
            }
        }
        public static string SanitizeXmlString(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return xml;

            // Fix common issues that cause token errors
            StringBuilder sb = new StringBuilder(xml.Length);

            bool inAttribute = false;
            char lastChar = '\0';

            foreach (char c in xml)
            {
                // Handle attribute value quoting
                if (c == '=' && lastChar == ' ')
                {
                    inAttribute = true;
                    sb.Append(c);
                }
                else if (inAttribute && (c == '\'' || c == '"'))
                {
                    inAttribute = false;
                    sb.Append(c);
                }
                // Escape problematic characters
                else if (c == '\\')
                {
                    sb.Append(@"\\"); // Double the backslash
                }
                else if (c == '<' && lastChar == '\\')
                {
                    sb.Remove(sb.Length - 1, 1); // Remove the preceding backslash
                    sb.Append("&lt;");
                }
                else
                {
                    sb.Append(c);
                }

                lastChar = c;
            }

            return sb.ToString();
        }
        public static string EscapePathStrings(string xml)
        {
            // Matches common path-like patterns in attributes
            Regex pathRegex = new Regex(@"([a-zA-Z]:\\[^\""]+)");
            return pathRegex.Replace(xml, m => m.Value.Replace("\\", "/"));
        }
        public static string FixAttributeQuotes(string xml)
        {
            // Fix unquoted or improperly quoted attributes
            Regex attrRegex = new Regex(@"(\w+)=([^""'\s][^\s>]*)");
            return attrRegex.Replace(xml, @"$1=""$2""");
        }
        public static string FullXmlSanitization(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return xml;

            // Apply all fixes in proper order
            xml = EscapePathStrings(xml);
            xml = FixAttributeQuotes(xml);
            xml = SanitizeXmlString(xml);

            // Final validation
            try
            {
                XDocument.Parse(xml);
                return xml;
            }
            catch
            {
                // If still invalid, try wrapping in CDATA
                return $"<root><![CDATA[{xml}]]></root>";
            }
        }

    }
}
