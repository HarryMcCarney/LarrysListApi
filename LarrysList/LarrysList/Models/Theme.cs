using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Theme
    {
        [XmlAttribute]
        public string name { get; set; }
    }
}