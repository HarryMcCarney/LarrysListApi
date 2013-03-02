using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;



public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlInt32 CountJsonNodes(string json, string node)
    {

        var jObj = (JObject)JsonConvert.DeserializeObject(json);


        JObject jo = JObject.Parse(json);
        JToken nodes = jo.Descendants()
            .Where(t => t.Type == JTokenType.Property && ((JProperty)t).Name == node)
            .Select(p => ((JProperty)p).Value)
            .FirstOrDefault();

        if (nodes == null)
            return (SqlInt32)0;
        else
            return (SqlInt32)nodes.Count();
    
    }

    
}
