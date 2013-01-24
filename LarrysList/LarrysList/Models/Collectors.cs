using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Collectors
    {
        [XmlElement]
        public Collector[] Collector { get; set; }

    }
}