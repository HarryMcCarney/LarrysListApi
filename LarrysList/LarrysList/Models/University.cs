using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class University
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string city { get; set; }
    }
}