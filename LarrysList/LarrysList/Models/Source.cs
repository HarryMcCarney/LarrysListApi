using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Source
    {
        [XmlAttribute]
        public string type { get; set; }
        [XmlAttribute]
        public string url { get; set; }
        [XmlAttribute]
        public string title { get; set; }
        [XmlAttribute]
        public string publisher { get; set; }
        [XmlAttribute]
        public string author { get; set; }
        [XmlAttribute]
        public string date { get; set; }
        [XmlAttribute]
        public string year { get; set; }
        [XmlAttribute]
        public string name { get; set; }
    }
}