using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Director
    {
        [XmlAttribute]
        public string firstName { get; set; }
        [XmlAttribute]
        public string lastName { get; set; }
        [XmlAttribute]
        public string origName { get; set; }
        [XmlAttribute]
        public string title { get; set; }
        [XmlAttribute]
        public string gender { get; set; }
        [XmlAttribute]
        public string email { get; set; }
        [XmlAttribute]
        public string facebook { get; set; }
        [XmlAttribute]
        public string linkedin { get; set; }
    }
}