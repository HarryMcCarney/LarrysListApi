using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class ArtWork
    {
        [XmlAttribute]
        public string title { get; set; }
        [XmlAttribute]
        public string year { get; set; }
        [XmlAttribute]
        public string medium { get; set; }
        [XmlAttribute]
        public string measurement { get; set; }
        [XmlAttribute]
        public string width { get; set; }
        [XmlAttribute]
        public string height { get; set; }
        [XmlAttribute]
        public string depth { get; set; }
        [XmlAttribute]
        public string material { get; set; }
        [XmlAttribute]
        public bool reassign { get; set; }

    }
}