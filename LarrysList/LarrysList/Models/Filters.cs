using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Filters
    {
        [XmlElement]
        public List<Gender> Gender { get; set; }
        [XmlElement]
        public List<Genre> Genre { get; set; }
        [XmlElement]
        public List<Origin> Origin { get; set; }
        [XmlElement]
        public List<Medium> Medium { get; set; }
        [XmlElement]
        public List<Artist> Artist { get; set; }
        [XmlElement]
        public List<City> City { get; set; }
        [XmlElement]
        public List<Region> Region { get; set; }
        [XmlElement]
        public List<Country> Country { get; set; }
    }
}