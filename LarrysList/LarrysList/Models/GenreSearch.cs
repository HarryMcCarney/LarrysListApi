using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class GenreSearch
    {
        [XmlAttribute]
        public string term { get; set; }
    }
}