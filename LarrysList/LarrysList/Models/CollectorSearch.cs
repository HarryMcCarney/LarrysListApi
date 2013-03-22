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
        [XmlElement]
        public List<Filter> Filter { get; set; }
        [XmlAttribute]
        public bool my { get; set; }
        [XmlAttribute]
        public string userToken { get; set; }
    }
}