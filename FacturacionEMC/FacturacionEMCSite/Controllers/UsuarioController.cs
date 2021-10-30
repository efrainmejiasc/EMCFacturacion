using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCSite.Controllers
{
    public class UsuarioController : Controller
    {
        public UsuarioController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
