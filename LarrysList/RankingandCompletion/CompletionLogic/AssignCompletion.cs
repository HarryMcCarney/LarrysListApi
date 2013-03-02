using System;
using DBVC;
using LarrysList.Models;
using NLog;

namespace RankingandCompletion.CompletionLogic
{
    class AssignCompletion
    {
        private Collector collector { get; set; }
        private int points { get; set; }
        private string metaJson { get; set; }
        private static readonly Logger log = LogManager.GetCurrentClassLogger();


        public AssignCompletion(Collector c)
        {
            log.Info("completion assignmetn starting for " + c.firstName + " " + c.lastName);
            collector = c;
            collector.completion = 0;
            var jsonProc = new MSSQLData();
            metaJson = jsonProc.execStoredProc("api.admin_collection_meta_json", Int32.Parse(collector.id), null);
        }


        public void assign()
        {

            if (collector.lastName != null)
                points += 4;
            if (collector.gender != null)
                points += 4;
            if (collector.Address != null && collector.Address.Count > 0  && collector.Address[0].City != null)
                points += 4;
            if (collector.Address != null && collector.Address.Count > 0 && collector.Address[0].line1 != null)
                points += 4;
            if (collector.University != null && collector.University.Count > 0 && collector.University[0] != null)
                points += 4;
            if (collector.Interest != null && collector.Interest.Count > 0   && collector.Interest[0] != null)
                points += 4;
            if (collector.Email != null)
                points += 4;
            if (collector.Company != null && collector.Company.Count > 0 && collector.Company[0].name != null)
                points += 4;
            if (collector.Industry != null && collector.Industry.Count > 0 && collector.Industry[0].name != null)
                points += 4;
            if (collector.Collection != null && collector.Collection.totalWorks != null)
                points += 4;
            if (collector.Collection != null &&  collector.Collection.totalArtists != null)
                points += 4;
            if (collector.Collection != null && collector.Collection.started != null)
                points += 4;
            if (collector.Collection != null && collector.Collection.Genre != null && collector.Collection.Genre.Count > 0 && collector.Collection.Genre[0] != null)
                points += 4;
            if (collector.Collection != null && collector.Collection.Genre != null && collector.Collection.Genre.Count > 1 && collector.Collection.Genre[1] != null)
                points += 4;
            if (collector.Collection != null && collector.Collection.Region != null && collector.Collection.Region.Count > 0 && collector.Collection.Region[0] != null)
                points += 4;
            if (collector.Collection != null && collector.Collection.Artist != null && collector.Collection.Artist.Count > 0 && collector.Collection.Artist[0] != null)
                points += 4;
            if (collector.Collection != null && collector.Collection.Artist != null && collector.Collection.Artist.Count > 1 && collector.Collection.Artist[1] != null)
                points += 4;
            if (collector.Collection != null && collector.Collection.Artist != null && collector.Collection.Artist.Count > 2 && collector.Collection.Artist[2] != null)
                points += 4;

            log.Info("finsihed calculating conpletion points for " + collector.firstName + " " + collector.lastName);
            collector.completion = points;
        }
    }
}
