using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LarrysList.Services.Messaging;

namespace BurnPlus.Services.Messaging.Templates
{
    public class SendReceiptEmail : ITemplate
    {
        public string template { get; set; }
        public string type { get; set; }
        public string jangoId { get; set; }

        public string paymentRef { get; set; }
        public int amount { get; set; }        
        public string currency { get; set; }       
        public string toEmail { get; set; }
        public string userName { get; set; }
       

        public SendReceiptEmail(string _paymentRef, int _amount, string _currency, string _toEmail, string _userName)
        {
            type = "EMAIL";
            jangoId = "281626572";
            template = "SendReceiptEmail";
            paymentRef = _paymentRef;
            amount = _amount;
            currency = _currency;
            toEmail = _toEmail;
            userName = _userName;
        }

    }

}