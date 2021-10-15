using EMCApi.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCSite.Controllers
{
    public class ProveedorController : Controller
    {
        private readonly UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

        public ProveedorController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
        {
            clientApi = _clienteApi;
            httpContext = _httpContext;

            if (!string.IsNullOrEmpty(httpContext.HttpContext.Session.GetString("UserLogin")))
                this.usuario = JsonConvert.DeserializeObject<UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));
            else
                RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProveedores()
        {
            var proveedores = await this.clientApi.GetProveedoresAsync(this.usuario.IdEmpresa);

            return Json(proveedores);
        }
    }
}
