using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Ranking.Models
{
    [Serializable]
    public class RankPage
    {
        [XmlAttribute]
        public string url { get; set; }
    }
}
