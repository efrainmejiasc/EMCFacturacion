﻿using EMCApi.Client;
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

        public IActionResult Index()
        {
            return View();
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

        public IActionResult About()
        {
            return View();
        }
    }
}
