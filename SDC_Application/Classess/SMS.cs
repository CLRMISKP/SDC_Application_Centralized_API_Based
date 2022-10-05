using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
//using System.Net.;
using System.Threading.Tasks;
using System.Xml;  

namespace SDC_Application.Classess
{
    class SMS
    {
         private String MSISDN; 
        private String PASSWORD; 
        private String abc;

       public SMS(String msisdn, String password) 
        { 
            this.MSISDN = msisdn; 
            this.PASSWORD = password; 
        }  
        public  String getSessionId() 
        { 
            String url = "https://telenorcsms.com.pk:27677/corporate_sms2/api/auth.jsp?msisdn=" + MSISDN + "&password=" + PASSWORD; 
 
            return sendRequest(url); 
        } 
        public String sendQuickMessage(String sessionId,String messageText,String to,String mask) 
        { 
            String url = "https://telenorcsms.com.pk:27677/corporate_sms2/api/sendsms.jsp?session_id=" + sessionId + "&text=" + messageText+"&to="+ to; 
 
            if(mask!=null) 
            {                 
                url = url += "&mask="+mask+"&&unicode=true";             
            }             
            return sendRequest(url);         
        } 
 
        public String sendRequest(String url)         
        {             
            String response = null; 
            try 
            { 
                var client = new WebClient(); 
                response = client.DownloadString(url); 
 
                XmlDocument xmldoc = new XmlDocument(); 
                xmldoc.LoadXml(response); 
 
                XmlNodeList responseType = xmldoc.GetElementsByTagName("response"); 
                XmlNodeList data = xmldoc.GetElementsByTagName("data"); 
 
                if (responseType.Equals("Error")) 
                { 
                    return null; 
                } 
 
                response = data[0].InnerText; 
                return response; 
            } 
             catch (Exception e) 
            { 
                Console.WriteLine(e.Message); 
            } 
            return null; 
        } 
    }
}
