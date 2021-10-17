using DatosEMC.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class FacturaVentaController : ControllerBase
    {
        private readonly IFacturaVentaService facturaVentaService;

        public FacturaVentaController(IFacturaVentaService _facturaVentaService)
        {
            this.facturaVentaService = _facturaVentaService;
        }

        /// <summary>
        /// Crear registro de factura
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostFacturaVenta")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostFacturaVenta([FromBody] FacturaVentaDTO facturaDTO)
        {
            facturaDTO.Id = 0;

            var genericResponse = this.facturaVentaService.AddFacturaVenta(facturaDTO);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);

        }
    }
}
