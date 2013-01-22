using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Email
    {
        [XmlAttribute]
        public string address { get; set; }
    }
}