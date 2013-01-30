using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Document
    {
        [XmlAttribute]
        public string file { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string type { get; set; }
    }
}