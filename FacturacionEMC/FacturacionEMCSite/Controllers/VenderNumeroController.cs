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
        public IActionResult GuardarTicket(string VentaNumeroDTO)
        {
            var response = new
            {
                estatus = true,
                message = "Ticket saved successfully"
            };

            try
            {
                List<VentaNumeroDTO> ventaNumeros = JsonConvert.DeserializeObject<List<VentaNumeroDTO>>(VentaNumeroDTO);
                var e = VentaNumeroDTO;
               
            }
            catch(Exception ex)
            {
                var error = ex.Message;
            }
           

            return Ok(response);
        }

        #endregion
    }



}

