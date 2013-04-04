using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Collectors
    {
        [XmlElement]
        public List<Collector>  Collector { get; set; }

    }
}