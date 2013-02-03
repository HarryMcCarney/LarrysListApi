using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class TopMuseum
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string city { get; set; }
    }
}