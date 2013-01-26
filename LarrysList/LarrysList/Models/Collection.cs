using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Collection
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public string totalWorks { get; set; }
        [XmlAttribute]
        public bool totalWorksAprx { get; set; }
        [XmlAttribute]
        public string totalArtists { get; set; }
        [XmlAttribute]
        public bool totalArtistsAprx { get; set; }
        [XmlAttribute]
        public string foundation { get; set; }
        [XmlAttribute]
        public string started { get; set; }
        [XmlAttribute]
        public string url { get; set; }
        [XmlElement]
        public List<Genre> Genre { get; set; }
        [XmlElement]
        public List<Medium> Medium { get; set; }
        [XmlElement]
        public List<Region> Region { get; set; }
        [XmlElement]
        public List<Artist> Artist { get; set; }
        [XmlElement]
        public List<Publication> Publication { get; set; }
    }
}