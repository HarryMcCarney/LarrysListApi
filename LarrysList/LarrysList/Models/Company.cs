using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Company
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string position { get; set; }
        [XmlAttribute]
        public string industry { get; set; }
        [XmlAttribute]
        public string url { get; set; }
        [XmlAttribute]
        public string line1 { get; set; }
        [XmlAttribute]
        public string line2 { get; set; }
        [XmlAttribute]
        public string line3 { get; set; }
        [XmlAttribute]
        public string postCode { get; set; }
        [XmlElement]
        public City City { get; set; }
        [XmlElement]
        public Region Region { get; set; }
        [XmlElement]
        public Country Country { get; set; }
    }
}