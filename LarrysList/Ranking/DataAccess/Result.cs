using DBVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1
{
    [Serializable]
    public class Result:IResult
    {
        [XmlElement]
        public Global Global { get; set; }
        [XmlAttribute]
        public string dbMessage {get ; set;}
        [XmlAttribute]
        public string errorMessage {get ; set;}
        [XmlAttribute]
        public int status {get ; set;}
        [XmlAttribute]
        public string proc { get; set; }
        [XmlElement]
        public List<Collector> Collector { get; set; }
    }
}
