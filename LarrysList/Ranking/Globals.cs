using DBVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    public class Globals
    {
        private static Globals instance = new Globals();
        public Dictionary<string, string> settings;
        public List<string> rankPages;
   

        public static Globals Instance
        {
            get { return instance; }
        }

        private Globals()
        {
            var orm = new Orm();
            var result = orm.execObject<Result>(null, "api.global_config");
            getSettings(result.Global);
            getRankPages(result.Global);
        }


        private void getRankPages(Global global)
        {
            rankPages = new List<string>();
            foreach (var p in global.RankPage)
            {
               rankPages.Add(p.url);
            }
        }

        private void getSettings(Global global)
        {
            settings = new Dictionary<string, string>();
            foreach (var s in global.Setting)
            {
                settings.Add(s.key, s.value);

            }

        }


    }
}
