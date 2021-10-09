using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NegocioEMC.Commons;
using EMCApi.Client;
using System.Net.Http;


namespace FacturacionEMCSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClientEMCApi clientApi;
        public HomeController(ClientEMCApi _clienteApi)
        {
            //var httpClient = new HttpClient();
            //var urlBase = "http://localhost:13170";
            clientApi = _clienteApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> LoginAsync(int idEmpresa, string userMail, string password)
        {
            var passwordEncode = EngineTool.EnCodeBase64(userMail + password);
            var user = await this.clientApi.GetUserDataAsync(idEmpresa, userMail, passwordEncode);

            return Json(user);
        }
    }
}
