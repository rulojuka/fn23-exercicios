using System.Web.Mvc;
using System.Web.Routing;

namespace Blog.Filters
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["usuario"];
            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                  new RouteValueDictionary(
                    new
                    {
                        area = "",
                        controller = "Usuario",
                        action = "Login"
                    }));
            }
        }
    }
}