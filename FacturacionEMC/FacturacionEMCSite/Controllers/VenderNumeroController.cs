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
    public class VenderNumeroController : Controller
    {
        private readonly DatosEMC.DTOs.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

        public VenderNumeroController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
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
        public IActionResult Contact()
        {
            return View();
        }

        #region LOTERIAS 

        [HttpGet]
        public async Task<IActionResult> GetLoteriasAsync()
        {
            ICollection<EMCApi.Client.Loterias> loterias = new List<EMCApi.Client.Loterias>();

            try
            {
                loterias= await this.clientApi.GetLoteriasAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(loterias);
        }

        #endregion

        #region TICKET
        [HttpPost]
        public async Task<IActionResult> GuardarTicketAsync(string VentaNumeroDTO)
        {
            var response = new RespuestaModel();
            response.Estatus = false;
            try
            {
                List<VentaNumeroDTO> ventaNumeros = JsonConvert.DeserializeObject<List<VentaNumeroDTO>>(VentaNumeroDTO);
               foreach ( var x in ventaNumeros) 
               {
                    x.Vendedor = this.usuario.Username;
                    x.IdEmpresa = this.usuario.IdEmpresa;
               }

                 var result = await this.clientApi.PostVentaNumeroTicketAsync(ventaNumeros);
                 if (result.Ok) 
                 {
                    response.VentaNumero = result.VentaNumero;
                    response.Estatus = true; 
                 }
                
            }
            catch(Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);

        }

        [HttpGet]

        public async Task<IActionResult> GetNumeroTicketAsync()
        {
            var response = new NumeroTicketDTO();
            try
            {
                response = await this.clientApi.GetNumeroTicketAsync(this.usuario.IdEmpresa);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                response = null;
            }

            return Json(response);

        }

        #endregion
    }



}

