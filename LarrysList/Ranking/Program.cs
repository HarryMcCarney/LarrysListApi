using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Timers;
using Topshelf;


namespace Ranking
{
    class Program
    {
       

        static void Main(string[] args)
        {

           

            HostFactory.Run(x =>
            {
                x.Service<RankRunner>(s =>
                {
                    s.ConstructUsing(name => new RankRunner());
                    s.WhenStarted(tc => tc.start());
                    s.WhenStopped(tc => tc.stop());
                });
                x.RunAsNetworkService();
                var serviceName = Globals.Instance.settings["RankingServiceName"];
                x.SetDescription(serviceName);
                x.SetDisplayName(serviceName);
                x.SetServiceName(serviceName);

            });    

        }

        

       
    }
}