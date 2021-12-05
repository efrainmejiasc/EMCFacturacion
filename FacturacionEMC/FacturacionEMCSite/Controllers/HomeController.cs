using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMCApi.Client;
using System.Net.Http;
using FacturacionEMCSite.SecurityToken;
using System.Security.Claims;
using NegocioEMC.Commons;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using FacturacionEMCSite.Models;
using NegocioEMC.IServices;
using DatosEMC.DataModels;

namespace FacturacionEMCSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;
 
        public HomeController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
        {
            //var httpClient = new HttpClient();
            //var urlBase = "http://localhost:13170";
            this.clientApi = _clienteApi;
            this.httpContext = _httpContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> LoginAsync(int idEmpresa, string userMail, string password, string nombreEmpresa)
        {
            var passwordEncode = EngineTool.EnCodeBase64(userMail + password);
            JwtProvider jwtProvider = SecurityToken.JwtProvider.Create(clientApi);

            var credenciales = new CredencialesDTO()
            {
                IdEmpresa = idEmpresa,
                UserMail = userMail,
                Password = passwordEncode
            };

            var respuesta = new RespuestaModel();

            var accessToken = await jwtProvider.GetTokenAsync(credenciales);

            try
            {

                if (accessToken != null)
                {
                    ClaimsIdentity claims = jwtProvider.CreateIdentity(accessToken.Token);

                    var user = new UsuarioDTO();
                    user.Id = claims.GetId();
                    user.IdEmpresa = idEmpresa;
                    user.NombreEmpresa = nombreEmpresa;
                    user.Username = claims.GetUsuario();
                    user.IdRol = Convert.ToInt32(claims.GetRoles().FirstOrDefault());
                    user.Email = claims.GetEmail();
                    user.Token = accessToken.Token;

                    user = await InicioFacturacionDatosAsync(user);

                    httpContext.HttpContext.Session.SetString("UserLogin", JsonConvert.SerializeObject(user));
                    respuesta.Estatus = true;
                    respuesta.EstatusFacturacion = user.InicioFacturacion;
                }
                else
                {
                    respuesta.Estatus = false;
                }
            }
            catch
            {
                respuesta.Estatus = false;
            }

            return Json(respuesta);
        }

        private async Task<UsuarioDTO> InicioFacturacionDatosAsync(UsuarioDTO u)
        {
            var inicioFacturacion = new InicioFacturacionDTO();
            try
            {
                inicioFacturacion = await this.clientApi.GetInicioFacturacionCtrlAsync(u.IdEmpresa);
                u.InicioFacturacion = inicioFacturacion.Activo;
                u.InicioFacturacionNumero = inicioFacturacion.NumeroFactura;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return u;
        }
    }
}
