using Facebook;
using NLog;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace HnCMailQueue
{
    public class FacebookService
    {
        private readonly string accessToken;

        private static readonly Logger log = LogManager.GetLogger("facebookService");

        public FacebookService(string _accessToken)
        {
            accessToken = _accessToken;
        }


        public bool StreamPublish(string userNameCaption, string mylink, string recipientId, string caption, string picture, string message,string actionLink, string actionName, string rootLink)
        {
            bool res;

            try
            {

                /*

                 * name =  " is using Doggity";
                 * actionName =  "Find Dog friendly places with Doggity",
                 * link = ConfigurationManager.AppSettings["root"],
                 
                 
                 
                 
                 */
                var client = new FacebookClient(accessToken);

                dynamic parameters = new ExpandoObject();
                parameters.message = caption;
                parameters.link = mylink;
                parameters.picture = picture;
                parameters.name = userNameCaption;
                parameters.caption = message;
                parameters.description = "";
                parameters.actions = new
                {
                    name = actionName,
                    link = rootLink,
                };
                log.Warn(parameters.actions.link);

                parameters.targeting = new
                {
                    countries = "DE",
                    regions = "6,53",
                    locales = "6",
                };

                dynamic result = client.Post(recipientId + "/feed", parameters);
                res = true;

            }
            catch (Exception exp)
            {
                log.Error(exp.Message.ToString());
                res = false;
            }
            return res;

        }
    }
}
