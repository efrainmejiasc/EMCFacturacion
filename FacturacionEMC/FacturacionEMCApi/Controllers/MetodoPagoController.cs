using DatosEMC.DTOs;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FacturacionEMCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {
        IMetodoPagoService metodoPagoService;
        public MetodoPagoController(IMetodoPagoService _metodoPagoService)
        {
            metodoPagoService = _metodoPagoService;
        }

        /// <summary>
        /// Obtiene los metodos de pago
        /// </summary>
        /// <returns>Lista metodos Pago</returns>
        [HttpGet("idioma",Name = "GetMetodosPago")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<MetodoPagoDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetMetodosPago(string idioma)
        {
            var metodos = this.metodoPagoService.GetMetodoPago(idioma);

            if (metodos.Count > 0)
                return Ok(metodos);

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
