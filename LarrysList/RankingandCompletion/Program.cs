using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace RankingandCompletion
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<QueueRunner>(s =>
                {
                    s.ConstructUsing(name => new QueueRunner());
                    s.WhenStarted(tc => tc.start());
                    s.WhenStopped(tc => tc.stop());
                });
                x.RunAsNetworkService();


                var serviceName = Globals.Instance.settings["RankingandCompletionServiceName"];
                x.SetDescription(serviceName);
                x.SetDisplayName(serviceName);
                x.SetServiceName(serviceName);
            });                                                    
        }
    }
}
