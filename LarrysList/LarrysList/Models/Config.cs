using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Config
    {
        [XmlElement]
        public List<Nationality> Nationality { get; set; }
        [XmlElement]
        public List<Position> Position { get; set; }
        [XmlElement]
        public List<Title> Title { get; set; }
       [XmlElement]
        public List<Industry> Industry { get; set; }
       [XmlElement]
       public List<Interest> Interest { get; set; }
       [XmlElement]
       public List<Genre> Genre { get; set; }
       [XmlElement]
       public List<Medium> Medium { get; set; }
       [XmlElement]
       public List<Publisher> Publisher { get; set; }
       [XmlElement]
       public List<SourceType> SourceType { get; set; }
       [XmlElement]
       public List<TopMuseum> TopMuseum { get; set; }
       [XmlElement]
       public List<Relation> Relation { get; set; }
       [XmlElement]
       public List<ArtFair> ArtFair { get; set; }
       [XmlElement]
       public List<PaymentOption> PaymentOption { get; set; }
       [XmlElement]
       public List<Material> Material { get; set; }
       [XmlElement]
       public ReviewedCollectors ReviewedCollectors { get; set; }
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