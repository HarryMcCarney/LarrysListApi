using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class InterestSearch
    {
        [XmlAttribute]
        public string term { get; set; }
    }
}
