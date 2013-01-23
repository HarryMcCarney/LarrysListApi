using System;
using System.Web.Mvc;
using LarrysList.Auth;

namespace LarrysList.Controllers
{
    public class ConfigController : BaseController
    {

        [AuthClient]
        public string Index()
        {
            try
            {
                result = orm.execObject<Result>(null, "api.config");
            }
            catch (Exception exp)
            {
                errorResult(exp);
            }
            return formattedResult(result);
        }

    }
}
