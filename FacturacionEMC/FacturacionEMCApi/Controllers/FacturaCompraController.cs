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
    public class FacturaCompraController : ControllerBase
    {
        private readonly IFacturaCompraService facturaCompraService;

        public FacturaCompraController (IFacturaCompraService _facturaCompraService)
        {
            this.facturaCompraService = _facturaCompraService;
        }

        /// <summary>
        /// Crear registro de factura
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostFacturaCompra")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostFacturaCompra([FromBody] FacturaCompraDTO facturaDTO)
        {
            facturaDTO.Id = 0;

            var genericResponse = this.facturaCompraService.AddFacturaCompra(facturaDTO);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);

        }
    }
}
