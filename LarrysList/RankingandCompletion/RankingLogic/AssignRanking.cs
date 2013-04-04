using System;
using DBVC;
using LarrysList.Models;
using NLog;

namespace RankingandCompletion.RankingLogic
{
    public class AssignRanking
    {
        private Collector collector { get; set; }
        private int points { get; set; }
        private string metaJson { get; set; }
        private static readonly Logger log = LogManager.GetCurrentClassLogger();
        public AssignRanking(Collector c)
        {
            log.Info("begin ranking assigment");
            collector = c;
            collector.ranking = 0;
            var jsonProc = new MSSQLData();
            log.Info("getting meta info for ranking");
            metaJson = jsonProc.execStoredProc("api.admin_collector_meta_json", Int32.Parse(collector.id), null);
        }

        public void assign()
        {
            artfair();
            
            platform();
            museum();
            engagement();
            information();

            magazine();

            log.Info("assign calculated ranking points to collector");
            collector.ranking = points;
        }

        private void artfair()
        {

            log.Info("artfair ranking");

            var fairs = metaJson.countNodes("ArtFair");

            if (fairs == 1)
                points +=  1;
            if (fairs > 1)
                points += 2;
         }


        private void magazine()
        {
            log.Info("magazine ranking");
            points = points*800;
            points += collector.googleRankingPoints;
            

        }


        private void platform()
        {
            log.Info("platform ranking");
            var urls = metaJson.countNodes("url");
            var publications = metaJson.countNodes("Publication");

            if (urls > 0)
                points += 1;
            if (publications > 0)
                points += 1;
        }


        private void museum()
        {
            log.Info("museum ranking");
           var museums=  metaJson.countNodes("Museum");
           if (museums > 0)
               points += 1;
        }


        private void engagement()
        {
            log.Info("engagement ranking");
            var member = metaJson.countNodes("SocietyMember");
            if (member > 0)
                points += 1;

        }

        private void information()
        {
            log.Info("information ranking");
        }


    }
}
