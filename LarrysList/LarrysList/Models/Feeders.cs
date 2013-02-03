using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Feeders
    {
        [XmlElement]
        public List<Feeder> Feeder { get; set; }
    }
}