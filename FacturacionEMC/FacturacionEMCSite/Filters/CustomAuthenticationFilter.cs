using FacturacionEMCSite.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FacturacionEMCSite.Filters
{
    public class CustomAuthenticationFilter: ActionFilterAttribute //Attribute, IAuthorizationFilter
    {
        private readonly IHttpContextAccessor httpContext;

        public CustomAuthenticationFilter()
        {
            this.httpContext = new HttpContextAccessor();
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                base.OnActionExecuting(filterContext);

                if (filterContext.Controller is HomeController != true && filterContext.Controller is EmpresaController != true
                    && filterContext.Controller is ProductosClienteController != true)
                {
                    if (string.IsNullOrEmpty(this.httpContext.HttpContext.Session.GetString("UserLogin")))
                    {
                        filterContext.HttpContext.Response.Redirect("/Home/Index");
                    }
                }
            }
            catch
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }
        }
    }
}
