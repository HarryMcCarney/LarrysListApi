using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
  
    [Serializable]
    public  class Collector
    {
        [XmlAttribute]
        public int id { get; set; }

        [XmlAttribute]
        public string firstName { get; set; }

        [XmlAttribute]
        public string lastName { get; set; }

        [XmlAttribute]
        public int hits { get; set; }
    }
}
