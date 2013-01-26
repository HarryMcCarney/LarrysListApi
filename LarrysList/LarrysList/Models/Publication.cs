using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace LarrysList.Models
{
   [Serializable]
    public class Publication
    {
       [XmlAttribute]
       public string title { get; set; }
       [XmlAttribute]
       public string year { get; set; }
       [XmlAttribute]
       public string publisher { get; set; }
    

    }
}