using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class ArtFair
    {
        [XmlAttribute]
        public string name { set; get; }
    }
}