using DBVC;
using Ranking.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking
{
    public static class Collectors
    {


         public static List<Collector> getCollectors()
        {
            var orm = new Orm();
            var result = orm.execObject<Ranking.DataAccess.Result>(null, "api.get_collectors_names");
            return result.Collector;
        }

    }
}
