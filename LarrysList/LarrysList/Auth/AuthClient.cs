﻿using System.Web;
using System.Web.Mvc;
using LarrysList.Services.GlobalConfig;

namespace LarrysList.Auth
{
    public class AuthClientAttribute : System.Web.Mvc.ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            var headerToken = actionContext.RequestContext.HttpContext.Request.Headers["Client-Token"];

            var clientToken = Globals.Instance.settings["ClientToken"];

            if (clientToken != headerToken)
            {
                throw new HttpException(403, "Forbidden");
            }
        }

    }
}