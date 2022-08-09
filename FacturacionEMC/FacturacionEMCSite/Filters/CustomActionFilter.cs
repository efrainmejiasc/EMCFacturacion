using FacturacionEMCSite.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FacturacionEMCSite.Filters
{
    public class CustomActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
                OnActionExecuting(filterContext);
        }
    }
}
