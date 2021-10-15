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
    public class FacturaCompraDetalleController : ControllerBase
    {
        private readonly IFacturaCompraDetalleService facturaCompraDetalleService; 

        public  FacturaCompraDetalleController (IFacturaCompraDetalleService _facturaCompraDetalleService)
        {
            this.facturaCompraDetalleService = _facturaCompraDetalleService;
        }

        /// <summary>
        /// Crear registro de detall de factura
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostFacturaCompraDetalle")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostFacturaCompra([FromBody] List<FacturaCompraDetalleDTO> facturaDetalleDTO)
        {

            var genericResponse = this.facturaCompraDetalleService.AddFacturaCompraDetalle(facturaDetalleDTO);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);

        }
    }
}
