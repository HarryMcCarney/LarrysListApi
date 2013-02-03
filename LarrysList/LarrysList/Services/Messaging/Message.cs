using System;
using System.Xml.Serialization;

namespace LarrysList.Services.Messaging
{
    [Serializable]
    public class Message
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string type { get; set; }
        [XmlAttribute]
        public string template { get; set; }
        [XmlAttribute]
        public string jangoID { get; set; }
        [XmlAttribute]
        public string emailTo { get; set; }
        [XmlAttribute]
        public string jangoUser { get; set; }
        [XmlAttribute]
        public string jangoPwd { get; set; }
        [XmlElement]
        public Field[] Field { get; set; }

    }
}