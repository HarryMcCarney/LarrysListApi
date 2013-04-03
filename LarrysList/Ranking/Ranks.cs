using Ranking.DataAccess;
using DBVC;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using Ranking.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace Ranking
{
    public class Ranks
    {
        public static string myKey = Globals.Instance.settings["RankApiMyKey"];
        public static string user = Globals.Instance.settings["RankApiUser"];
        public static string cse = Globals.Instance.settings["RankApiCse"];
        private static Logger log = LogManager.GetCurrentClassLogger();
        public static void getRanks()
        {
            log.Info("Seting up pages on google cse");           
            SearchPages.createSearchPages();

            var collectors = Collectors.getCollectors();
            log.Info("Getting all collectors from database - number of collectors " + collectors.Count);
            
            foreach (Collector c in collectors)
            {
                var searchTerm = String.Format("{0} {1}", c.firstName, c.lastName);
                c.hits = (int)getNumberOfHits(searchTerm);            
            }
            setColectorHits(collectors);
            
           log.Info("Cleaning cse");
           SearchPages.deleteSearchPages();

            

        }

        private static void setColectorHits(List<Collector> collectors)
        {
            var cr = new CollectorsHits {Collectors = collectors};
            var orm = new Orm();
            log.Info("Writting information to database - number of hits");
            var res = orm.execObject<Ranking.DataAccess.Result>(cr, "api.set_collectors_rank");
     }

        public static int getNumberOfHits(string searchTerm)
        {
            var sUrl = getSearchString(searchTerm);
            WebClient wc = new WebClient();
            var json = (JObject)JsonConvert.DeserializeObject(wc.DownloadString(sUrl));
            var searchTemp = (JObject)json["searchInformation"];
            return (int)searchTemp["totalResults"];
        }

        public static string getSearchString(string searchTerm)
        {
            var url = String.Format("https://www.googleapis.com/customsearch/v1?key={0}&cx={1}:{2}&q={3}", myKey, user, cse, searchTerm);
            return url;
        }
        
    }
}
