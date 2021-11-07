
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
    public class InicioFacturacionController : Controller
    {
        //await Task.WhenAll(updateTask, updateStatusTask);
        private readonly DatosEMC.DTOs.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

        public InicioFacturacionController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
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

        public async Task<IActionResult> SetInicioFacturacionAsync(string numeroFactura)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            numeroFactura = numeroFactura.Replace(",", "");
            numeroFactura = numeroFactura.Replace(".", "");
            var inicioFacturacion = new EMCApi.Client.InicioFacturacionDTO()
            {
                NumeroFactura = numeroFactura,
                Fecha = DateTime.Now,
                Activo = true,
                IdEmpresa = this.usuario.IdEmpresa
            };

            try
            {
                var save = await this.clientApi.PostInicioFacturacionAsync(inicioFacturacion);
                response.Estatus = save.Ok ? true : false;

                if (response.Estatus)
                {
                    var user = JsonConvert.DeserializeObject<DatosEMC.DTOs.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));
                    user.InicioFacturacionNumero = (Convert.ToInt32(numeroFactura) + 1).ToString();
                    user.InicioFacturacion = true;
                    httpContext.HttpContext.Session.SetString("UserLogin", string.Empty);
                    httpContext.HttpContext.Session.SetString("UserLogin", JsonConvert.SerializeObject(user));
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(response);
        }


        [HttpPost]
        public async Task<IActionResult> ReInicioFacturacionAsync()
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                var save = await this.clientApi.ReInicioFacturacionAsync(this.usuario.IdEmpresa);
                response.Estatus = save.Ok ? true : false;
                if (response.Estatus)
                {
                    var user = JsonConvert.DeserializeObject<DatosEMC.DTOs.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));
                    user.InicioFacturacionNumero = string.Empty;
                    user.InicioFacturacion = false;
                    httpContext.HttpContext.Session.SetString("UserLogin", string.Empty);
                    httpContext.HttpContext.Session.SetString("UserLogin", JsonConvert.SerializeObject(user));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Json(response);
        }
    }
}
