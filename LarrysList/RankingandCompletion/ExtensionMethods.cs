using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RankingandCompletion
{
    public static class ExtensionMethods
    {
        public static int countNodes(this String json, string node)
        {
            if (String.IsNullOrEmpty(json))
                return 0;



            JObject jo = JObject.Parse(json);
            JToken nodes = jo.Descendants()
                .Where(t => t.Type == JTokenType.Property && ((JProperty)t).Name == node)
                .Select(p => ((JProperty)p).Value)
                .FirstOrDefault();

            if (nodes == null)
                return 0;
            else
                return nodes.Count();



        }

    }
}
