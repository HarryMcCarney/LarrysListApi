using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [Serializable]
    public class Global
    {
        [XmlElement]
        public Setting[] Setting { get; set; }

        [XmlElement]
        public RankPage[] RankPage { get; set; }
    }
}
