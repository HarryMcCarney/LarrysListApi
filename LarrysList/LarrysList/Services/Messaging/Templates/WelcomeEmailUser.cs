using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LarrysList.Services.Messaging;

namespace BurnPlus.Services.Messaging.Templates
{
    public class WelcomeEmailUser : ITemplate
    {
        public string template { get; set; }
        public string type { get; set; }
        public string jangoId { get; set; }
        public string toEmail { get; set; }
        public string userName { get; set; }

        public WelcomeEmailUser(string _toEmail, string _userName)
        {
            type = "EMAIL";
            jangoId = "281626539";
            template = "WelcomeEmailUser";

            toEmail = _toEmail;
            userName = _userName;
        }

    }

}