using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LarrysList.Services.Messaging;

namespace BurnPlus.Services.Messaging.Templates
{
    public class ForgotPwdEmailUser : ITemplate
    {
        public string template { get; set; }
        public string type { get; set; }
        public string jangoId { get; set; }
        public string toEmail { get; set; }
        public string resetUrl { get; set; }
        public string userName { get; set; }

        public ForgotPwdEmailUser(string _toEmail, string _resetUrl, string _userName)
        {
            type = "EMAIL";
            jangoId = "281626559";
            template = "ForgotPwdEmailUser";

            toEmail = _toEmail;
            resetUrl = _resetUrl;
            userName = _userName;
        }



    }

}