﻿using DatosEMC.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCSite.Controllers
{
    public class FacturaCompraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GuardarFactura(FacturaDTO x)
        {

            return Json("");
        }

        [HttpPost]
        public IActionResult GuardarFacturaDetalle(List<FacturaDetalleDTO> x)
        {

            return Json("");
        }
    }
}
