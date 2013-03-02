using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class TypeAhead
    {
        [XmlAttribute]
        public string value { get; set; }
    }
}