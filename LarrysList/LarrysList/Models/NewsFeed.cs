using System.Xml.Serialization;

namespace LarrysList.Models
{
    public class NewsFeed
    {
        [XmlAttribute]
        public string source { get; set; }
        [XmlAttribute]
        public string value { get; set; }

    }
}