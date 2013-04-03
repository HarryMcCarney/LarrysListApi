using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [Serializable]
    public class RankPage
    {
        [XmlAttribute]
        public string url { get; set; }
    }
}
