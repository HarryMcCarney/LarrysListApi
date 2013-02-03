using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using DBVC;
using NLog;
using WorkerRole1.Model;
using WorkerRole1.ModelMapper;
using Result = WorkerRole1.ModelMapper.Result;

namespace HnCMailQueue
{
    static class SendMessage
    {

        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        public static void SendMessages(IEnumerable<Message> messages)
        {
            var orm = new Orm(new MSSQLData());
            foreach (var m in messages)
            {
                var messageStatus = new MessageStatus { Message = m };
                if (m.type == "FACEBOOK")
                     messageStatus.status = (FacebookPost(m) == true) ? "SENT" : "FAILED";
                if (m.type == "EMAIL")
                    messageStatus.status = (JangoEmail(m) == true) ? "SENT" : "FAILED";
                orm.execObject<Result>(messageStatus, "mess.set_message_status");

            }

        }
        public static IEnumerable<Message> Messages()
        {
            var messages = new List<Message>();
            var result = new Result();
            var orm = new Orm(new MSSQLData());
            log.Info("getting messages from db");
            result = orm.execObject<Result>(null, "mess.dequeue_message");
            if (result.Message != null)
            {
                messages.AddRange(result.Message);
            }
            return messages;
        }

        static bool JangoEmail(Message message)
        {

            bool res;
            try
            {
                var jangoUrl = "http://api.jangomail.com/api.asmx/SendTransactionalEmailFromTemplate";
                var client = new WebClient();
                client.Headers.Add("Content-Type:application/x-www-form-urlencoded");  
                byte[] bytedata = Encoding.ASCII.GetBytes(BuildPostString(message));
                byte[] responseArray  = client.UploadData(jangoUrl, "POST", bytedata);
                var response = Encoding.UTF8.GetString(responseArray);
               
                if (response != null && response.Contains("SUCCESS") )
                {
                    res = true;
                    log.Info("messsage sent");
                }
                else
                {
                    res = false;
                }

                

            }
            catch (Exception exp)
            {
                log.Error(exp.InnerException);
                log.Error(exp.Message);
                res = false;
            }
            return res;

        }

        static string BuildPostString(Message message)
        {

            string postString = "";
            string keys = "";
            string values = "";
            var jangoId = "";
            var toEmail = "";
            foreach (var field in message.Field)
            {
                if (field.key == "toEmail")
                    toEmail = field.value;
                if (field.key == "jangoId")
                    jangoId = field.value;
                field.value = HttpUtility.UrlEncode(field.value);
                keys += (keys == "") ? field.key : "~" + field.key;
                values += (values == "") ? field.value : "~" + field.value;
            }
            postString = string.Format("Username={0}&Password={1}&CampaignID={2}&ToEmailAddress={3}&PersonalizationFields={4}&PersonalizationValues={5}&PersonalizationColDelimiter=~&Options=", message.jangoUser, message.jangoPwd, jangoId, toEmail, keys, values);
            log.Info("built post string:: " + postString);
            return postString;

        }



        static bool FacebookPost(Message message)
        {

            var targetFacebookId = "";
            var name = "";
            var link = "";
            var caption = "";
            var picture = "";
            var fbMessage = "";
            var accesstoken = "";
            var rootLink = "";
            var actionName = "";

            foreach (var field in message.Field)
            {
                if (field.key == "targetFacebookId")
                    targetFacebookId = field.value;
                if (field.key == "userNameCaption")
                    name = field.value;
                if (field.key == "link")
                    link = field.value;
                if (field.key == "caption")
                    caption = field.value;
                if (field.key == "picture")
                    picture = field.value;
                if (field.key == "fbMessage")
                    fbMessage = field.value;
                if (field.key == "accesstoken")
                    accesstoken = field.value;
                if (field.key == "actionName")
                    actionName = field.value;
                if (field.key == "rootLink")
                    rootLink = field.value;
            }
            var fb = new FacebookService(accesstoken);
            log.Info("posting to facebook target:" + targetFacebookId);

            var res = fb.StreamPublish(name, link, targetFacebookId, caption, picture, fbMessage,  rootLink,actionName, rootLink);


            return res;

        }



    }
}
