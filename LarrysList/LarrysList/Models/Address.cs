using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Address
    {
        [XmlAttribute]
        public string line1 { get; set; }
        [XmlAttribute]
        public string line2 { get; set; }
        [XmlAttribute]
        public string line3 { get; set; }
        [XmlAttribute]
        public string postCode { get; set; }
        [XmlAttribute]
        public string cityToken { get; set; }
        [XmlAttribute]
        public string city { get; set; }
    }
}