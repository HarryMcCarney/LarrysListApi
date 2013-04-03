using DBVC;
using LarrysList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Result = LarrysList.Result;

namespace RankingandCompletion
{

    public class Globals
    {
        private static Globals instance = new Globals();
        public Dictionary<string, string> settings;
   

        public static Globals Instance
        {
            get { return instance; }
        }

        private Globals()
        {
            var orm = new Orm();
            var result = orm.execObject<Result>(null, "api.global_config");
            getSettings(result.Global);
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
