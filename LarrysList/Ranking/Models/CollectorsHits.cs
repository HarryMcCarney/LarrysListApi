using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1.Models
{

    [Serializable]
    public class CollectorsHits
    {
        [XmlElement]
        public List<Collector> Collectors { get; set; }
    }
}
