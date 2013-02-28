using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class NewsFeeds
    {
        [XmlElement]
        public List<NewsFeed> NewsFeed { get; set; }
    }
}