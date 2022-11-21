using Codecool.CodecoolShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Codecool.CodecoolShop.Controllers
{
    public abstract class BaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string user = SessionHelper.GetUserFromJson(HttpContext.Session, "user");

            ViewData["user"] = user;
        }
    }
}
