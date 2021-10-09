using EMCApi.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCSite.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly ClientEMCApi clientApi;
        public EmpresaController(ClientEMCApi _clienteApi)
        {
            clientApi = _clienteApi;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> GetEmpresasAsync()
        {
            var empresas = await this.clientApi.GetEmpresasAsync() as List<EmpresaDTO>;
            return Json(empresas);
        }
    }
}
