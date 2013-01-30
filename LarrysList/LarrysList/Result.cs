using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using DBVC;
using LarrysList.Models;

namespace LarrysList
{
    [Serializable]
    public class Result : IResult
    {
        [XmlAttribute]
        public string errorMessage { get; set; }
        [XmlAttribute]
        public int status { get; set; }
        [XmlAttribute]
        public string dbMessage { get; set; }
        [XmlAttribute]
        public string procName { get; set; }
        [XmlElement]
        public Global Global { get; set; }
        [XmlElement]
        public Collector Collector { get; set; }
        [XmlElement]
        public Config Config { get; set; }
        [XmlElement]
        public List<AddressSearchResult> AddressSearchResult { get; set; }
        [XmlElement]
        public Collectors Collectors { get; set; }
        [XmlElement]
        public Collection Collection { get; set; }
        [XmlElement]
        public List<Artist> Artist { get; set; }
        [XmlElement]
        public Feeder Feeder { get; set; }
        [XmlElement]
        public Upload Upload { get; set; }
    }
}