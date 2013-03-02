using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Search
    {
        [XmlAttribute]
        public string term { get; set; }
    }
}