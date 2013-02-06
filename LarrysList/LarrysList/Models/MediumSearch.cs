using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class MediumSearch
    {
        [XmlAttribute]
        public string term { get; set; }
    }
}