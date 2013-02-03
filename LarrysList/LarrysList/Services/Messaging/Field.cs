using System;
using System.Xml.Serialization;

namespace LarrysList.Services.Messaging
{
    [Serializable]
    public class Field
    {
        [XmlAttribute]
        public string key { get; set; }
        [XmlAttribute]
        public string value { get; set; }
    }
}