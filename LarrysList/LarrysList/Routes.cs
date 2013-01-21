using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LarrysList
{
    public class Routes : NancyModule
    {
        public Routes()
        {
            Get["/"] = p => "Hello World";
        }
    }
}