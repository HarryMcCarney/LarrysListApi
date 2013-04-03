using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApplication1
{

        [Serializable]
        public class Setting
        {
            [XmlAttribute]
            public string key { get; set; }
            [XmlAttribute]
            public string value { get; set; }
       }
    
}
