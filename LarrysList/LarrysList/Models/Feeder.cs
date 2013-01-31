using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Feeder
    {
        [XmlAttribute]
        public string token { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string picture { get; set; }
        [XmlAttribute]
        public string type { get; set; }
        [XmlAttribute]
        public string activationToken{ get; set; }
        [XmlAttribute]
        public string email { get; set; }
        [XmlAttribute]
        public string pwd { get; set; }
        [XmlElement]
        public List<Country> Country { get; set; }
    }
}