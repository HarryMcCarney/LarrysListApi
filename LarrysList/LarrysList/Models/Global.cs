using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Global
    {
        [XmlElement]
        public Setting[] Setting { get; set; }
    }

    
}