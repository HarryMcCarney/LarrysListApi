using LarrysList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LarrysList.Controllers.Web
{
    public class SearchController : BaseController
    {
        public string collector(CollectorSearch search)
        {
            try
            {
                result = orm.execObject<Result>(search, "api.user_collector_search");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
