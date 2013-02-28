using System;
using System.Xml.Serialization;

namespace LarrysList.Models
{
    [Serializable]
    public class ReviewedCollectors
    {      
            [XmlAttribute]
           public string no { get; set; }
    }
}