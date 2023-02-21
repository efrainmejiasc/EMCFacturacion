using DatosEMC.DataModels;
using EMCApi.Client;
using FacturacionEMCSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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
    }
}
