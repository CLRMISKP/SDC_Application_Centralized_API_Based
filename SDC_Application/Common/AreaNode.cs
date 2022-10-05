using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandInfo.Common
{
    public class AreaNode
    {
         
        /// <summary>
        /// Get or Set Area id
        /// </summary>
        public Int64 ID { get; set; }
        /// <summary>
        /// Get or Set Area code
        /// </summary>
        public Int64 Code { get; set; }
        /// <summary>
        /// Get or Set Area parent code
        /// </summary>
        public Int64 ParentCode { get; set; }
        /// <summary> parent node id
        /// Get or Set 
        /// </summary>
        public Int64 ParentNodeID { get; set; }
        /// <summary>
        /// Get or Set  Area name
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// Get or Set  Area type
        /// </summary>
        public string AreaType { get; set; }
        /// <summary>
        /// Get or Set  Area urdu
        /// </summary>
        public string AreaTypeUrdu { get; set; }
        /// <summary>
        /// Get or Set attributes of list
        /// </summary>
        public List<AreaNode> Attributes { get; set; }
    }
    public class MozaData
    {
        /// <summary>
        /// Get or Set  Area code
        /// </summary>
        public Int64 AreaCode { get; set; }
        /// <summary>
        /// Get or Set Area Name
        /// </summary>
        public string AreaName { get; set; }
        /// <summary>
        /// Get or Set Area parent Code
        /// </summary>
        public Int64 ParentCode { get; set; }
        /// <summary> 
        /// Get or Set Area type
        /// </summary>
        public string AreaType { get; set; }
    }
    
}
