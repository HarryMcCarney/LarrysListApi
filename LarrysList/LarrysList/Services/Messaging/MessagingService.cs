using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DBVC;
using LarrysList.Services.GlobalConfig;
using NLog;



namespace LarrysList.Services.Messaging
{
    public class MessagingService
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public void enqueueMessage(ITemplate template)
        {
            var message = buildMessage(template);

            var data = new MSSQLData(Globals.Instance.settings["MessagingConnection"]);
            var orm = new Orm(data);
           var res = orm.execObject<Result>(message, "mess.enqueue_message");
        }



        private Message buildMessage(ITemplate template)
        {
            try
            {
                var messageType = template.GetType();
                PropertyInfo[] myProps = messageType.GetProperties();
                var dict = new Dictionary<string, string>();
                var builtMessage = new Message
                                           {
                                               id = Guid.NewGuid().ToString(),
                                               Field = new Field[myProps.Count()],
                                               jangoUser = Globals.Instance.settings["JangoUser"],
                                               jangoPwd = Globals.Instance.settings["JangoPwd"]
                                           };

                var i = 0;
                foreach (var prop in myProps)
                {
                    if (prop.Name == "type")
                    {
                        builtMessage.type = prop.GetValue(template, null) as string;
                    }
                    if (prop.Name == "template")
                    {
                        builtMessage.template = prop.GetValue(template, null) as string;
                    }

                    builtMessage.Field[i] = new Field {key = prop.Name, value = prop.GetValue(template, null) as string};
                    i++;
                }
                return builtMessage;
            }
            catch (Exception exp)
            {
                log.Error(exp.Message);
                throw;
            }
        }
    }
}