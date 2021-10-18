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
                    f.IdUsuario = usuario.Id;
                    f.IdArticulo = 1;
                    f.NombreArticulo = f.Descripcion;
                    f.Descuento = f.PorcentajeDescuento > 0 ? f.Subtotal - (f.Subtotal * f.PorcentajeDescuento * 0.01F) : 0.00F;
                    f.Impuesto = f.PorcentajeImpuesto > 0 ? (f.Subtotal - f.Descuento) - (f.Subtotal * f.PorcentajeImpuesto * 0.01F) : 0.00F;
                }

                var saveFacturaDetalle = await this.clientApi.PostFacturaCompraDetalleAsync(facturaDetalleDTO);

                response.Estatus = saveFacturaDetalle.Ok ? true : false;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
         
            return Json(response);
        }

    }
}
