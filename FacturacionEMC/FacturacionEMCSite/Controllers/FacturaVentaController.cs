﻿using EMCApi.Client;
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
    public class FacturaVentaController : Controller
    {
        private readonly DatosEMC.DTOs.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

        public FacturaVentaController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
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
        public IActionResult GuardarFactura(EMCApi.Client.FacturaVentaDTO factura)
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

                httpContext.HttpContext.Session.SetString("FacturaVenta", JsonConvert.SerializeObject(factura));
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
                var facturaDetalleDTO = JsonConvert.DeserializeObject<List<FacturaVentaDetalleDTO>>(facturaDetalle);
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

                var factura = JsonConvert.DeserializeObject<EMCApi.Client.FacturaVentaDTO>(httpContext.HttpContext.Session.GetString("FacturaVenta"));
                var saveFactura = await this.clientApi.PostFacturaVentaAsync(factura);
                var saveFacturaDetalle = await this.clientApi.PostFacturaVentaDetalleAsync(facturaDetalleDTO);
                var saveStock = await this.clientApi.PostStockTotalRemoveAsync(facturaDetalleDTO);
                response.Estatus = saveFactura.Ok && saveFacturaDetalle.Ok && saveStock.Ok ? true : false;
                httpContext.HttpContext.Session.SetString("FacturaVenta",string.Empty);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetNumeroFacturaAsync()
        {
            EMCApi.Client.InicioFacturacionDTO factura = new EMCApi.Client.InicioFacturacionDTO();

            try
            {
                factura = await this.clientApi.GetNumeroFacturaAsync(this.usuario.IdEmpresa);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(factura);
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
            ICollection<EMCApi.Client.FacturaVentaDTO> facturas = new List<EMCApi.Client.FacturaVentaDTO>();

            try
            {
                facturas = await this.clientApi.GetFacturasVentasAsync(this.usuario.IdEmpresa);
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
            ICollection<EMCApi.Client.FacturaVentaDTO> facturas = new List<EMCApi.Client.FacturaVentaDTO>();

            try
            {
                facturas = await this.clientApi.GetFacturasVentasFechasAsync(this.usuario.IdEmpresa,fechaInicial,fechaFinal);
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
            ICollection<EMCApi.Client.FacturaVentaDetalleDTO> facturas = new List<EMCApi.Client.FacturaVentaDetalleDTO>();

            try
            {
                facturas = await this.clientApi.GetFacturaVentaDetalleAsync(this.usuario.IdEmpresa, numeroFactura);
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
