using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SDC_Application
{
    public class MachineRegistrationDetails
    {
        public string Query { get; set; }
        public string MachineName { get; set; }
        public string MacAddress { get; set; }
        public string IPAddress { get; set; }
        public string RegisterAt { get; set; }
        public string isAllowedToLogin { get; set; }
        public string isAllowedOnWeekend { get; set; }
        public string LoginTime { get; set; }
        public string LogOutTime { get; set; }
        public string SiteId { get; set; }
        public string TehsilId { get; set; }
        public string DistrictId { get; set; }
    }
}
