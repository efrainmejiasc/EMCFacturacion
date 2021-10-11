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
            clientApi = _clienteApi;
            httpContext = _httpContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> LoginAsync(int idEmpresa, string userMail, string password)
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
            if (accessToken != null)
            {
                ClaimsIdentity claims = jwtProvider.CreateIdentity(accessToken.Token);

                var user = new UsuarioDTO();
                user.Id = claims.GetId();
                user.IdEmpresa = idEmpresa;
                user.Username = claims.GetUsuario();
                user.IdRol = Convert.ToInt32(claims.GetRoles().FirstOrDefault());
                user.Email = claims.GetEmail();
                user.Token = accessToken.Token;

                httpContext.HttpContext.Session.SetString("UserLogin", JsonConvert.SerializeObject(user));
                respuesta.Estatus = true;
            }
            else
            {
                respuesta.Estatus = false;
            }

            
            return Json(respuesta);
        }
    }
}
