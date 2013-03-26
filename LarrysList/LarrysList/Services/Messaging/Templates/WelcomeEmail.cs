using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LarrysList.Services.Messaging;

namespace BurnPlus.Services.Messaging.Templates
{
    public class WelcomeEmail : ITemplate
    {
        public string template { get; set; }
        public string type { get; set; }
        public string jangoId { get; set; }
        public string toEmail { get; set; }
        public string userName { get; set; }

        public WelcomeEmail(string _toEmail, string _userName)
        {
            type = "EMAIL";
            jangoId = "281624352";
            template = "WelcomeEmail";

            toEmail = _toEmail;
            userName = _userName;
        }

    }

}