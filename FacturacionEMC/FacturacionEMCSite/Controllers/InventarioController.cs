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
    public class InventarioController : Controller
    {
        private readonly DatosEMC.DTOs.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;
        public  InventarioController(ClientEMCApi _clienteApi ,IHttpContextAccessor _httpContext)
        {
            this.httpContext = _httpContext;
            this.clientApi = _clienteApi;

            if (!string.IsNullOrEmpty(httpContext.HttpContext.Session.GetString("UserLogin")))
                this.usuario = JsonConvert.DeserializeObject<DatosEMC.DTOs.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));
        }


        #region StockTotal

        [HttpGet]
        public async Task<IActionResult> GetStockTotalAsync()
        {
            ICollection<EMCApi.Client.StockTotalDTO> productos = new List<EMCApi.Client.StockTotalDTO>();
            try
            {
                productos = await this.clientApi.GetStockBodegaAsync(this.usuario.IdEmpresa, true);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(productos);
        }

        [HttpGet]
        public async Task<IActionResult> GetStockProductoBodegaAsync(int idArticulo)
        {
            EMCApi.Client.StockTotalDTO producto = new EMCApi.Client.StockTotalDTO();
            try
            {
                producto = await this.clientApi.GetStockProductoBodegaAsync(this.usuario.IdEmpresa,idArticulo, true);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(producto);
        }

        #endregion


        #region StockTransito

        [HttpPost]
        public async Task<IActionResult> GuardarAsignacionAsync(string asignaciones)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                var asignacionDTO = JsonConvert.DeserializeObject<List<EMCApi.Client.StockTransitoDTO>>(asignaciones);
                foreach (var modelo in asignacionDTO)
                {
                    modelo.IdEmpresa = usuario.IdEmpresa;
                    modelo.IdUsuario = usuario.Id;
                    modelo.Activo = true;
                    modelo.Fecha = modelo.FechaModificacion = DateTime.Now;
                }
                
                var saveModelo = await this.clientApi.PostStockTransitoAsync(asignacionDTO);
                response.Estatus = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetStockTransitoProducto(int idProducto)
        {
            ICollection<StockTransitoDTO> lst = new List<StockTransitoDTO>();

            try
            {
                lst = await this.clientApi.GetStockTransitoProductoAsync(this.usuario.IdEmpresa, idProducto, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(lst);
        }

        [HttpGet]
        public async Task<IActionResult> GetStockTransitoVendedor(int idVendedor, int idEmpresa)
        {
            ICollection<StockTransitoDTO> lst = new List<StockTransitoDTO>();

            try
            {
                lst = await this.clientApi.GetAsignacionesVendedorAsync(idEmpresa, idVendedor, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(lst);
        }

        #endregion


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
