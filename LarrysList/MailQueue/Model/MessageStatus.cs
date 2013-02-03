using System;
using System.Xml.Serialization;

namespace WorkerRole1.Model
{
   
        [Serializable]
        public class MessageStatus
        {
            [XmlElement]
            public Message Message { get; set; }
            [XmlAttribute]
            public string status { get; set; }
        }

}
