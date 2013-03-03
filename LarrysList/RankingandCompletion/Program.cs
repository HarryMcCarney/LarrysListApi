using System;
using System.Collections.Generic;
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

                x.SetDescription("LarrysList Ranking and Completion Live");
                x.SetDisplayName("LarrysListRankingandCompletionLive");
                x.SetServiceName("LarrysListRankingandCompletionLive");
            });                                                    
        }
    }
}
