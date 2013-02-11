using System;
using System.Xml.Serialization;

namespace LarrysList.Services.PaymentService
{
    [Serializable]
    public class PaymentNotice
    {

        [XmlAttribute]
        public string type { get; set; }
        [XmlAttribute]
        public bool success { get; set; }
        [XmlAttribute]
        public string paymentRef { get; set; }
        [XmlAttribute]
        public string transactionId { get; set; }
        [XmlAttribute]
        public string reason { get; set; }
    }
}