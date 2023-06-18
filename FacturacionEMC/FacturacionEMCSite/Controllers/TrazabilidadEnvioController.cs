using DatosEMC.DataModels;
using EMCApi.Client;
using FacturacionEMCSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacturacionEMCSite.Controllers
{
    public class TrazabilidadEnvioController : Controller
    {
        private readonly DatosEMC.DTOs.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;


        public TrazabilidadEnvioController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
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
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarTrazabilidadEnvio(EMCApi.Client.TrazabilidadEnvioDTO modelo)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                modelo.IdEmpresa = this.usuario.IdEmpresa;
                var result = await this.clientApi.PostTrazabilidadEnvioAsync(modelo);
                if(result.Ok)
                response.Estatus = true;

            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTrazabilidadesEnvio(string dni)
        {
            var trazabilidadEnvio = new List<EMCApi.Client.TrazabilidadEnvio>();
            try
            {
               var idEmpresa = this.usuario.IdEmpresa;
               trazabilidadEnvio = await this.clientApi.GetTrazabilidadesEnvioDniAsync(idEmpresa, dni);                   

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                trazabilidadEnvio = null;
            }

            return Json(trazabilidadEnvio);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTrazabilidadEnvio(string guid)
        {
            var trazabilidadEnvio = new EMCApi.Client.TrazabilidadEnvio();
            try
            {
                var idEmpresa = this.usuario.IdEmpresa;
                trazabilidadEnvio = await this.clientApi.GetTrazabilidadEnvioIdentidadAsync(idEmpresa,guid);

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                trazabilidadEnvio = null;
            }

            return Json(trazabilidadEnvio);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTrazabilidadesEnvios(string fInicial, string fFinal)
        {
            var trazabilidadEnvio = new List<EMCApi.Client.TrazabilidadEnvio>();
            try
            {
                var idEmpresa = this.usuario.IdEmpresa;
                var fechaInicial = Convert.ToDateTime(fInicial);
                var fechaFinal = Convert.ToDateTime(fFinal);
                trazabilidadEnvio = (List<EMCApi.Client.TrazabilidadEnvio>)await this.clientApi.GetTrazabilidadesEnvioAsync(idEmpresa,fechaInicial,fechaFinal);

            }
            catch (Exception ex)
            {
                var error = ex.Message;
                trazabilidadEnvio = null;
            }

            return Json(trazabilidadEnvio);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTrazabilidad(EMCApi.Client.TrazabilidadEnvioDTO modelo)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                modelo.IdEmpresa = this.usuario.IdEmpresa;
                var result = await this.clientApi.PostTrazabilidadEnvioAsync(modelo);
                if (result.Ok)
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
