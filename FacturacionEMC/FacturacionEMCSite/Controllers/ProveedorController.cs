using EMCApi.Client;
using FacturacionEMCSite.Models;
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
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetProveedores()
        {
            ICollection<ProveedorDTO> proveedores = new List<ProveedorDTO>();

            if(this.usuario != null)
               proveedores = await this.clientApi.GetProveedoresAsync(this.usuario.IdEmpresa);

            return Json(proveedores);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProveedor (EMCApi.Client.ProveedorDTO proveedor)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                proveedor.IdEmpresa = usuario.IdEmpresa;
                proveedor.Fecha = proveedor.FechaModificacion = DateTime.Now;
                proveedor.Activo = true;
                var saveProveedor = await this.clientApi.PostProveedorAsync(proveedor);

                response.Estatus = saveProveedor.Ok ? true : false;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }
    }
}
