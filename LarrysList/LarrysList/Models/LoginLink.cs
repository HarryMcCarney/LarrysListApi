using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class LoginLink
    {
        [XmlAttribute]
        public string token { get; set; }
    }
}