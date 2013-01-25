using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LarrysList.Models;

namespace LarrysList.Controllers.Admin
{
    public class CollectionController : BaseController
    {
  
        public string create(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collection_create");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

        public string basicEdit(Collector collector)
        {
            try
            {
                result = orm.execObject<Result>(collector, "api.admin_collection_base_edit");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
