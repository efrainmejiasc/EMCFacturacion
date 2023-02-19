using EMCApi.Client;
using FacturacionEMCSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace FacturacionEMCSite.Controllers
{
    public class ProductosClienteController : Controller
    {
        private readonly DatosEMC.DTOs.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductosClienteController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext,
                                        IWebHostEnvironment _webHostEnvironment)
        {
            this.httpContext = _httpContext;
            this.clientApi = _clienteApi;
            this._webHostEnvironment = _webHostEnvironment;

            if (!string.IsNullOrEmpty(httpContext.HttpContext.Session.GetString("UserLogin")))
                this.usuario = JsonConvert.DeserializeObject<DatosEMC.DTOs.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));

        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]

        public async Task<IActionResult> GetInfoProducto(string strProducto)
        {
            var imgInfoProductos = new List<EMCApi.Client.ProductManagerImgDTO>();
            try
            {
                imgInfoProductos = await this.clientApi.GetProductImgInfoExtendAsync(strProducto) as List<EMCApi.Client.ProductManagerImgDTO>;
            }
            catch (Exception ex)
            {
                var response = new RespuestaModel();
                response.Estatus = false;
                response.Descripcion = ex.Message;
                return Json(response);
            }

            return Json(imgInfoProductos);
        }
        [HttpGet]
        public async Task<IActionResult> GetProductosCategory()
        {
            ICollection<ProductoDTO> productos = new List<ProductoDTO>();
            try
            {
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
