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
    public class FacturaVentaDetalleController : ControllerBase
    {
          private readonly IFacturaVentaDetalleService facturaVentaDetalleService; 

        public  FacturaVentaDetalleController (IFacturaVentaDetalleService _facturaVentaDetalleService)
        {
            this.facturaVentaDetalleService = _facturaVentaDetalleService;
        }

        /// <summary>
        /// Crear registro de detall de factura
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostFacturaVentaDetalle")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostFacturaVenta([FromBody] List<FacturaVentaDetalleDTO> facturaDetalleDTO)
        {

            var genericResponse = this.facturaVentaDetalleService.AddFacturaVentaDetalle(facturaDetalleDTO);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);

        }
    }
}
