using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Ranking.DataAccess;

namespace Ranking.Models
{

    [Serializable]
    public class CollectorsHits
    {
        [XmlElement]
        public List<Collector> Collectors { get; set; }
    }
}
