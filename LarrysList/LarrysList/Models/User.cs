using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class User
    {
        [XmlAttribute]
        public string token { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string email { get; set; }
        [XmlAttribute]
        public string pwd { get; set; }
        [XmlAttribute]
        public string picture { get; set; }
		[XmlAttribute]
        public string activationToken { get; set; }

    }

}