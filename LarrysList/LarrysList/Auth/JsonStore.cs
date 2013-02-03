using System.Web;
using System.Web.Mvc;
using LarrysList.Services.GlobalConfig;

namespace LarrysList.Auth
{
    public class JsonStoreAttribute : System.Web.Mvc.ActionFilterAttribute
    {
        public string JsonObjectId { get; set; }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            JsonObjectId = actionContext.RequestContext.HttpContext.Request.Headers["JsonObjectId"];

        }

    }
}