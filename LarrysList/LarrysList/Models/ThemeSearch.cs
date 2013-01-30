using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class ThemeSearch
    {
        [XmlAttribute]
        public string term { get; set; }
    }
}