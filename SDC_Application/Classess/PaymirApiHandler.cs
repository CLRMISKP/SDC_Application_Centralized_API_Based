using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SDC_Application.Classess
{
    internal class PaymirApiHandler
    {
        private string UserName;
        private string Password;
        private string ServiceCode;
        private string Credentials;
        private string encryption_key;

        // HttpClient instance (backported from Microsoft.Net.Http for .NET 4.0)
        private readonly HttpClient _httpClient;

        public PaymirApiHandler(string userName, string password, string serviceCode)
        {
            this.UserName = userName;
            this.Password = password;
            this.ServiceCode = serviceCode;

            _httpClient = new HttpClient();

            // Convert "username:password" to Base64
            this.Credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes(userName.Trim() + ":" + password.Trim()));

            // Create the encryption key (example logic: substring + "2023KPITB")
            // Ensure Credentials is long enough for Substring(5, 25).
            if (Credentials != null && Credentials.Length >= 30)
            {
                this.encryption_key = Credentials.Substring(5, 25) + "2023KPITB";
            }
            else
            {
                // Handle cases where the credentials are not long enough
                this.encryption_key = "DefaultEncryptionKey2023KPITB";
            }
        }

        public async Task<HttpResponseMessage> PushVoucherJsonAsync(string jsonData)
        {
            // 1. Compute the updated JSON with serviceD
            string jsonData_WithServiceD_Updated = UpdateServiceD(jsonData);
            // The original code then wraps it in brackets to treat it as an array
            jsonData_WithServiceD_Updated =  jsonData_WithServiceD_Updated ;

            // 2. Prepare endpoint and headers
            string endpoint = "https://paymir-sandbox.kpitb.online/api/DepartmentSnippet/ReceiveApplicationsArchiveDataDpt";
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Credentials", Credentials },
                { "ServiceCode", ServiceCode }
            };

            // 3. Make the API call and await the response
            HttpResponseMessage response = await MakeApiCallWithJsonAsync(
                endpoint,
                HttpMethod.Post,
                jsonData_WithServiceD_Updated,
                headers
            );

            // 4. Read the response content as string
            string rawJson = await response.Content.ReadAsStringAsync();

            // 5. Beautify the JSON string
            string beautifiedJson = JsonUtility.BeautifyJson(rawJson);

            // 6. Build a new response (or modify the existing one) with the beautified content
            var newResponse = new HttpResponseMessage(response.StatusCode)
            {
                Content = new StringContent(beautifiedJson, Encoding.UTF8, "application/json")
            };

            // 7. Return the new response
            return newResponse;
        }

        /// <summary>
        /// A generic method to make HTTP API calls when given an already serialized JSON string.
        /// </summary>
        private async Task<HttpResponseMessage> MakeApiCallWithJsonAsync(
            string endpoint,
            HttpMethod method,
            string jsonData,
            Dictionary<string, string> headers)
        {
            using (var request = new HttpRequestMessage(method, endpoint))
            {
                if (!string.IsNullOrWhiteSpace(jsonData))
                {
                    request.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                }

                // Add custom headers (skip "Content-Type" as it's set by StringContent)
                foreach (var header in headers)
                {
                    if (!header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                    {
                        request.Headers.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }

                return await _httpClient.SendAsync(request);
            }
        }

        /// <summary>
        /// Converts a plain text to Base64 encoding.
        /// </summary>
        public string ToBase64(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
            {
                return null;
            }
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainBytes);
        }

        /// <summary>
        /// Decodes a Base64-encoded string back to plain text.
        /// </summary>
        public string Base64ToText(string base64Text)
        {
            if (string.IsNullOrWhiteSpace(base64Text))
            {
                return null;
            }
            try
            {
                byte[] base64Bytes = Convert.FromBase64String(base64Text);
                return Encoding.UTF8.GetString(base64Bytes);
            }
            catch (FormatException)
            {
                return null;
            }
        }

        /// <summary>
        /// Generates a HMAC-SHA256 hash of `data` using the provided `secret`.
        /// </summary>
        public static string EncDataObj(string data, string secret)
        {
            var key = Encoding.UTF8.GetBytes(secret);
            var bytes = Encoding.UTF8.GetBytes(data);

            using (var hmac = new HMACSHA256(key))
            {
                byte[] hash = hmac.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// Updates the JSON string by computing a signature (serviceD) from various fields,
        /// then adds/updates the "serviceD" key in the JSON.
        /// </summary>
        public string UpdateServiceD(string jsonData)
        {
            // Parse incoming JSON
            JsonUtility util = new JsonUtility(jsonData);

            // Extract needed fields
            string DPTPaymentID = util.Get("dptPaymentID");
            string CitizenCNIC = util.Get("citizenCNIC");
            string ServiceName = util.Get("ServiceName");
            string StatusCode = util.Get("statusCode");
            string FeeAmount = util.Get("feeAmount");
            string ServiceKey = util.Get("serviceKey");

            // Create the string to hash
            string strForEnc = DPTPaymentID + "&" +
                               CitizenCNIC + "&" +
                               ServiceName + "&" +
                               StatusCode + "&" +
                               FeeAmount + "&" +
                               ServiceKey;

            // Compute serviceD
            string serviceD = EncDataObj(strForEnc, encryption_key);

            // Update the JSON with serviceD
            string updatedJson = util.UpdateOrAddKey("serviceD", serviceD);

            // Return a beautified JSON
            return JsonUtility.BeautifyJson(updatedJson);
        }
    }

    /// <summary>
    /// Utility class for JSON parsing, retrieving, and updating using Newtonsoft.Json
    /// </summary>
    public class JsonUtility
    {
        private JToken _jToken;

        /// <summary>
        /// Parses the JSON string (removing outer [ ] if it's an array with a single object).
        /// </summary>
        public JsonUtility(string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                throw new ArgumentException("JSON string cannot be null or empty.", "jsonString");
            }

            jsonString = jsonString.Trim();

            /*
            // If it's an array that probably has a single object, remove brackets
            if (jsonString.StartsWith("[") && jsonString.EndsWith("]"))
            {
                // This is simplistic: it assumes there's only one object in the array
                jsonString = jsonString.Substring(1, jsonString.Length - 2).Trim();
            }
            */
            try
            {
                _jToken = JToken.Parse(jsonString);
            }
            catch (JsonReaderException ex)
            {
                throw new ArgumentException("Invalid JSON string.", ex);
            }
        }

        /// <summary>
        /// Gets the string value for the specified key in the JSON object.
        /// Returns null if key not found or if it's not an object.
        /// </summary>
        /// 
        /*
        public string Get(string key, bool caseInsensitive = true)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
            }

            // _jToken must be a JObject to have named properties
            // If it's not an object (maybe it's an array or primitive), return null
            if (!(_jToken is JObject jObject))
            {
                return null;
            }

            if (!caseInsensitive)
            {
                // Case-sensitive lookup
                // e.g. jObject["exactPropertyName"]
                JToken token = jObject[key];
                return token?.ToString();
            }
            else
            {
                // Case-insensitive lookup by enumerating properties
                foreach (var prop in jObject.Properties())
                {
                    if (string.Equals(prop.Name, key, StringComparison.OrdinalIgnoreCase))
                    {
                        return prop.Value?.ToString();
                    }
                }
                return null;
            }
        }
        */

        public string Get(string key, bool caseInsensitive = true)
{
    if (string.IsNullOrWhiteSpace(key))
    {
        throw new ArgumentException("Key cannot be null or empty.", nameof(key));
    }

    // Case A: JSON is an array with exactly one element which is an object
    if (_jToken is JArray jArray && jArray.Count == 1 && jArray[0] is JObject singleObj)
    {
        return FindPropertyValue(singleObj, key, caseInsensitive);
    }
    // Case B: JSON is a single object
    else if (_jToken is JObject jObject)
    {
        return FindPropertyValue(jObject, key, caseInsensitive);
    }
    // Neither a single-object array nor a single object
    return null;
}

/// <summary>
/// A helper method that finds a property in the given <see cref="JObject"/>.
/// Respects case sensitivity based on <paramref name="caseInsensitive"/>.
/// </summary>
private string FindPropertyValue(JObject jObject, string key, bool caseInsensitive)
{
    if (!caseInsensitive)
    {
        // Case-sensitive direct lookup
        JToken token = jObject[key];
        return token?.ToString();
    }
    else
    {
        // Case-insensitive property search
        foreach (var prop in jObject.Properties())
        {
            if (string.Equals(prop.Name, key, StringComparison.OrdinalIgnoreCase))
            {
                return prop.Value?.ToString();
            }
        }
        return null;
    }
}


        /// <summary>
        /// Formats JSON with indentation.
        /// </summary>
        public static string BeautifyJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return json;
            }

            try
            {
                var token = JToken.Parse(json);
                return token.ToString(Formatting.Indented);
            }
            catch
            {
                // If invalid JSON, return the original string
                return json;
            }
        }

        /// <summary>
        /// Updates or adds the specified key in the JSON (object or array of objects) with `newValue`.
        /// Returns the modified JSON string (pretty printed).
        /// </summary>
        public string UpdateOrAddKey(string key, string newValue)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Key cannot be null or empty.", "key");

            if (_jToken is JObject jObj)
            {
                // Single object
                jObj[key] = newValue;
            }
            else if (_jToken is JArray jArray)
            {
                // Array of objects
                foreach (var item in jArray)
                {
                    if (item is JObject o)
                    {
                        o[key] = newValue;
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("JSON must be an object or an array of objects to update a key.");
            }

            return _jToken.ToString(Formatting.Indented);
        }
    }
}
