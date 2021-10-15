using DatosEMC.DTOs;
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
        private readonly UsuarioDTO usuario;
        private readonly IHttpContextAccessor httpContext;

        public FacturaCompraController(IHttpContextAccessor _httpContext)
        {
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

        [HttpPost]
        public IActionResult GuardarFactura(FacturaDTO factura)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                factura.IdEmpresa = usuario.IdEmpresa;
                factura.IdUsuario = usuario.Id;
                factura.NombreProveedor = string.Empty;
                factura.Activo = true;

                response.Estatus = true;
            }
            catch(Exception ex)
            {
                var error = ex.Message;
            }
            return Json(response);
        }

        [HttpPost]
        public IActionResult GuardarFacturaDetalle(string facturaDetalle)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                var facturaDetalleDTO = JsonConvert.DeserializeObject<List<FacturaDetalleDTO>>(facturaDetalle);
                foreach(var f in facturaDetalleDTO)
                {
                    f.IdUsuario = usuario.Id;
                    f.IdArticulo = 1;
                    f.NombreArticulo = f.Descripcion;
                    f.Descuento = f.PorcentajeDescuento > 0 ? f.Subtotal - (f.Subtotal * f.PorcentajeDescuento * 0.01M) : 0.00M;
                    f.Impuesto = f.PorcentajeImpuesto > 0 ? (f.Subtotal - f.Descuento) - (f.Subtotal * f.PorcentajeImpuesto * 0.01M) : 0.00M;
                }
                response.Estatus = true;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }
         

            return Json(response);
        }
    }
}
