using DBVC;
using System;
using System.Xml.Serialization;
using WorkerRole1.Model;

namespace WorkerRole1.ModelMapper 
{
    [Serializable]
    public class Result : IResult
    {
        [XmlAttribute]
        public int status { get; set; }
        [XmlAttribute]
        public string procName { get; set; }
        [XmlAttribute]
        public string errorMessage { get; set; }
        [XmlAttribute]
        public string dbMessage { get; set; }
        [XmlElement]
        public Message[] Message { get; set; }
    }

}
