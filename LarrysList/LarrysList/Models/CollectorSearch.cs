using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class CollectorSearch
    {
        [XmlAttribute]
        public string term { get; set; }
        [XmlElement]
        public Filters Filters { get; set; }
        [XmlAttribute]
        public bool my { get; set; }
        [XmlAttribute]
        public string userToken { get; set; }
    }
}