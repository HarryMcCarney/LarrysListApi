using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class PaymentOption
    {
        [XmlAttribute]
        public string token { get; set; }
        [XmlAttribute]
        public string credit { get; set; }
        [XmlAttribute]
        public string price { get; set; }

    }
}