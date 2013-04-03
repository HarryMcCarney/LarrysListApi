using DBVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public static class Collectors
    {


         public static List<Collector> getCollectors()
        {
            var orm = new Orm();
            var result = orm.execObject<Result>(null, "api.get_collectors_names");
            return result.Collector;
        }

    }
}
