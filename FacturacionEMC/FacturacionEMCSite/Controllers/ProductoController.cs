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
    public class ProductoController : Controller
    {
        private readonly DatosEMC.DTOs.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

        public ProductoController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
        {
            this.httpContext = _httpContext;
            this.clientApi = _clienteApi;

            if (!string.IsNullOrEmpty(httpContext.HttpContext.Session.GetString("UserLogin")))
                this.usuario = JsonConvert.DeserializeObject<DatosEMC.DTOs.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductoDTO producto, string p)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                producto.IdEmpresa = this.usuario.IdEmpresa;
                producto.Fecha = DateTime.Now;
                producto.IdUsuario = this.usuario.Id;
                producto.Activo = true;
                producto.PrecioUnidad = Convert.ToDouble(p.Replace(".",","));

                var saveProducto = await this.clientApi.PostProductoAsync(producto);
                response.Estatus = saveProducto.Ok ? true : false;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            ICollection<ProductoDTO> productos = new List<ProductoDTO>();
            try
            {
                if (this.usuario != null)
                    productos = await this.clientApi.GetProductosAsync(this.usuario.IdEmpresa, true);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(productos);
        }
    }
}
