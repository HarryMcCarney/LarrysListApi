using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class Collector
    {
        [XmlAttribute]
        public string id { get; set; }
        [XmlAttribute]
        public string firstName { get; set; }
        [XmlAttribute]
        public string lastName { get; set; }
        [XmlAttribute]
        public string origName { get; set; }
        [XmlAttribute]
        public string gender { get; set; }
        [XmlAttribute]
        public string dob { get; set; }
        [XmlAttribute]
        public string nationality { get; set; }
        [XmlAttribute]
        public string wikipedia { get; set; }
        [XmlAttribute]
        public string title { get; set; }
        [XmlAttribute]
        public string picture { get; set; }
        [XmlElement]
        public List<Address> Address { get; set; }
        [XmlElement]
        public List<University> University { get; set; }
        [XmlElement]
        public Workflow Workflow { get; set; }
        [XmlElement]
        public List<Network> Network { get; set; }
        [XmlElement]
        public List<Email> Email { get; set; }
        [XmlElement]
        public List<Company> Company { get; set; }
        [XmlElement]
        public List<Interest> Interest { get; set; }

        [XmlElement]
        public Collection Collection { get; set; }


    }
 
}