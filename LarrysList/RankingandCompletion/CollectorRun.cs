using System.Collections.Generic;
using DBVC;
using LarrysList.Models;
using NLog;
using Result = LarrysList.Result;

namespace RankingandCompletion
{
    public class CollectorRun
    {
        public  List<Collector> collectors { get; set; }
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        public CollectorRun()
        {
            collectors = Collectors().Collector;

        }

        private Collectors Collectors()
        {
            
            log.Info("fetching all collectors from db");
            var orm = new Orm();
            var result  = orm.execObject<Result>(null, "job.collector_all");
            log.Info("fetched all collectors from db");
            return result.Collectors;
        }
    }
}
