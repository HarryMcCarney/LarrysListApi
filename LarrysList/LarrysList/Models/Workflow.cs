using System.Collections.Generic;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    public class Workflow
    {
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public bool enforceOrder { get; set; }
        [XmlElement]
        public List<Stage> Stage { get; set; }

    }
}