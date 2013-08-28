using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Topshelf;

namespace HnCMailQueue
{
    public class Program
    {
        public static void Main()
        {
            /*
            HostFactory.Run(x =>                                 
            {
                x.Service<QueueRunner>(s =>                        
                {
                    s.ConstructUsing(name => new QueueRunner());     
                    s.WhenStarted(tc => tc.start());              
                    s.WhenStopped(tc => tc.stop());               
                });
                x.RunAsNetworkService();                            

                x.SetDescription("LarrysList Mail Queue");
                x.SetDisplayName("LarrysListMailQueue");
                x.SetServiceName("LarrysListMailQueue");                       
            });  
             * 
             * */

            new QueueRunner().process();

        }
    }

   

}
