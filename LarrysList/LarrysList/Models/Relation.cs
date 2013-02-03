using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Relation
    {
        [XmlAttribute]
        public string name { get; set; }
    }
}