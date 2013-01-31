using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class AddressSearch
    {
        [XmlAttribute]
        public string term { get; set; }
        [XmlAttribute]
        public string type { get; set; }
        [XmlAttribute]
        public string filter { get; set; }
        [XmlAttribute]
        public string filterType { get; set; }
    }
}
