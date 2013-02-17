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
        [XmlAttribute]
        public string line1 { get; set; }

        [XmlAttribute]
        public string line2 { get; set; }

        [XmlAttribute]
        public string postCode { get; set; }
        [XmlAttribute]
        public string country { get; set; }

       


    }
}