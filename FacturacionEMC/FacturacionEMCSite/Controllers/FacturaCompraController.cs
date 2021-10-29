using DatosEMC.DTOs;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarFactura(EMCApi.Client.FacturaCompraDTO factura)
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

                factura.Subtotal = factura.Subtotal / 100;
                factura.Total = factura.Total / 100 - factura.Descuento + factura.Impuesto;

                var saveFactura = await this.clientApi.PostFacturaCompraAsync(factura);

                response.Estatus = saveFactura.Ok ? true : false; 
            }
            catch(Exception ex)
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
                foreach(var f in facturaDetalleDTO)
                {
                    var pArt = f.NombreArticulo.Trim().Split(' ');
                    f.IdArticulo = Convert.ToInt32(pArt[pArt.Length-1]);
                    f.IdEmpresa = this.usuario.IdEmpresa;
                    f.IdUsuario = usuario.Id;
                    f.NombreArticulo = f.NombreArticulo.Substring(0, f.NombreArticulo.Trim().Length - 1);
                    f.Descuento = f.PorcentajeDescuento > 0 ? f.Subtotal - (f.Subtotal * f.PorcentajeDescuento * 0.01F) : 0.00F;
                    f.Impuesto = f.PorcentajeImpuesto > 0 ? (f.Subtotal - f.Descuento) - (f.Subtotal * f.PorcentajeImpuesto * 0.01F) : 0.00F;
                    f.Total = f.Subtotal - f.Descuento + f.Impuesto;
                }

                var saveFacturaDetalle = await this.clientApi.PostFacturaCompraDetalleAsync(facturaDetalleDTO);
                var saveStock = await this.clientApi.PostStockTotalAsync(facturaDetalleDTO);
                response.Estatus = saveFacturaDetalle.Ok && saveStock.Ok ? true : false;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
         
            return Json(response);
        }

        public IActionResult _Facturas()
        {
            return View();
        }

    }
}
