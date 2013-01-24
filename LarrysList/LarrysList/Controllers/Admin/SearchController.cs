using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LarrysList.Models;

namespace LarrysList.Controllers.Admin
{
    public class SearchController : BaseController
    {
        public string address(AddressSearch search)
        {
            try
            {
                result = orm.execObject<Result>(search, "api.admin_search_address");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
