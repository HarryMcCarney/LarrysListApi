using System;
using System.Collections.Generic;
using System.Linq;
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

            var criteria2 = new List<int> {artfair(), platform(), museum(), engagement(), information(), url()};
            var optional = (from x in criteria2 orderby x ascending where x > 0 select x).
            First();
            criteria2.Add(optional);

            points = (from x in criteria2 select x).Sum() * 800;
           
            points  += magazine();

            log.Info("assign calculated ranking points to collector");
            collector.points = points;
        }

        private int artfair()
        {

            log.Info("artfair ranking");

            var fairs = metaJson.countNodes("ArtFair");

            if (fairs == 1)
                return   1;
            if (fairs > 1)
                return 2;
            return 0;
        }


        private int magazine()
        {
            log.Info("magazine ranking");
            return collector.googleRankingPoints;
            

        }


        private int platform()
        {
            log.Info("platform ranking");
            var publications = metaJson.countNodes("Publication");


            if (publications > 0)
                return 1;
            else 
                return 0;
        }


        private int url()
        {
            log.Info("platform ranking");
            var urls = metaJson.countNodes("url");


            if (urls > 0)
                return 1;
            else
            {
                return 0;
            }
          
        }


        private int museum()
        {
            log.Info("museum ranking");
           var museums=  metaJson.countNodes("Museum");
            if (museums > 0)
                return 1;
            else
                return 0;
        }


        private int engagement()
        {
            log.Info("engagement ranking");
            var member = metaJson.countNodes("SocietyMember");
            if (member > 0)
                return 1;
            else
                return 0;

        }

        private int information()
        {
            log.Info("information ranking");
            return 0;
        }


    }
}
