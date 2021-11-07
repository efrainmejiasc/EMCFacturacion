using DatosEMC.DTOs;
using EMCApi.Client;
using FacturacionEMCSite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCSite.Controllers
{
    public class FacturaCompraController : Controller
    {
        private readonly DatosEMC.DTOs.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

  
        public FacturaCompraController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
        {
            this.httpContext = _httpContext;
            this.clientApi = _clienteApi;

            if (!string.IsNullOrEmpty(httpContext.HttpContext.Session.GetString("UserLogin")))
                this.usuario = JsonConvert.DeserializeObject<DatosEMC.DTOs.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));
        }

        #region Index_Factura

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult  GuardarFactura(EMCApi.Client.FacturaCompraDTO factura)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                factura.IdEmpresa = usuario.IdEmpresa;
                factura.IdUsuario = usuario.Id;
                factura.Activo = true;
                factura.Fecha = factura.FechaModificacion = DateTime.Now;
                factura.Descuento = factura.PorcentajeDescuento > 0 ? factura.Subtotal - (factura.Subtotal * factura.PorcentajeDescuento * 0.01F) : 0.00F;
                factura.Impuesto = factura.PorcentajeImpuesto > 0 ? (factura.Subtotal - factura.Descuento) - (factura.Subtotal * factura.PorcentajeImpuesto * 0.01F) : 0.00F;
                factura.Subtotal = factura.Subtotal ;
                factura.Total = factura.Total  - factura.Descuento + factura.Impuesto;

                httpContext.HttpContext.Session.SetString("FacturaCompra", JsonConvert.SerializeObject(factura));
                response.Estatus = true;

            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> GuardarFacturaDetalle(string facturaDetalle)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                var facturaDetalleDTO = JsonConvert.DeserializeObject<List<EMCApi.Client.FacturaCompraDetalleDTO>>(facturaDetalle);
                foreach (var f in facturaDetalleDTO)
                {
                    var pArt = f.NombreArticulo.Trim().Split(' ');
                    f.IdArticulo = Convert.ToInt32(pArt[pArt.Length - 1]);
                    f.IdEmpresa = this.usuario.IdEmpresa;
                    f.IdUsuario = usuario.Id;
                    f.NombreArticulo = f.NombreArticulo.Substring(0, f.NombreArticulo.Trim().Length - 1);
                    f.Descuento = f.PorcentajeDescuento > 0 ? f.Subtotal - (f.Subtotal * f.PorcentajeDescuento * 0.01F) : 0.00F;
                    f.Impuesto = f.PorcentajeImpuesto > 0 ? (f.Subtotal - f.Descuento) - (f.Subtotal * f.PorcentajeImpuesto * 0.01F) : 0.00F;
                    f.Total = f.Subtotal - f.Descuento + f.Impuesto;
                    f.IdEmpresa = this.usuario.IdEmpresa;
                }

                var factura = JsonConvert.DeserializeObject<EMCApi.Client.FacturaCompraDTO>(httpContext.HttpContext.Session.GetString("FacturaCompra"));
                var saveFactura = await this.clientApi.PostFacturaCompraAsync(factura);
                var saveFacturaDetalle = await this.clientApi.PostFacturaCompraDetalleAsync(facturaDetalleDTO);
                var saveStock = await this.clientApi.PostStockTotalAddAsync(facturaDetalleDTO);
                response.Estatus =saveFactura.Ok && saveFacturaDetalle.Ok && saveStock.Ok ? true : false;
                httpContext.HttpContext.Session.SetString("FacturaCompra", string.Empty);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }

        #endregion


        #region About_ResumenFacturas
        public IActionResult About()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetFacturasAsync()
        {
            ICollection<EMCApi.Client.FacturaCompraDTO> facturas = new List<EMCApi.Client.FacturaCompraDTO>();

            try
            {
                facturas = await this.clientApi.GetFacturasComprasAsync(this.usuario.IdEmpresa);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(facturas);
        }

        [HttpGet]
        public async Task<IActionResult> GetFacturasFechasAsync(DateTime fechaInicial, DateTime fechaFinal)
        {
            ICollection<EMCApi.Client.FacturaCompraDTO> facturas = new List<EMCApi.Client.FacturaCompraDTO>();

            try
            {
                facturas = await this.clientApi.GetFacturasComprasFechasAsync(this.usuario.IdEmpresa,fechaInicial,fechaFinal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(facturas);
        }

        [HttpGet]
        public async Task<IActionResult> GetFacturasDetallesAsync(string numeroFactura)
        {
            ICollection<EMCApi.Client.FacturaCompraDetalleDTO> facturas = new List<EMCApi.Client.FacturaCompraDetalleDTO>();

            try
            {
                facturas = await this.clientApi.GetFacturaCompraDetalleAsync(this.usuario.IdEmpresa, numeroFactura);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(facturas);
        }

        #endregion

    }
}
