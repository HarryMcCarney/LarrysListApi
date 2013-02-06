using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class InterstSearch
    {
        [XmlAttribute]
        public string term { get; set; }
    }
}
