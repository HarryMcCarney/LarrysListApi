using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class TypeAhead
    {
        [XmlAttribute]
        public string value { get; set; }
        [XmlAttribute]
        public string key { get; set; }
        [XmlAttribute]
        public string label { get; set; }
        [XmlAttribute]
        public string country { get; set; }
    }
}