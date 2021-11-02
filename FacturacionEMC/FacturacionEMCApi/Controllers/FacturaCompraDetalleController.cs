using DatosEMC.DTOs;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Obtiene detalle de la factura por id empresa
        /// </summary>
        /// <returns>Lista de facturas de Compra</returns>
        [HttpGet("{idEmpresa}/{numeroFactura}", Name = "GetFacturaCompraDetalle")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<FacturaCompraDetalleDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetFacturaCompraDetalle(int idEmpresa, string numeroFactura)
        {
            var factura = this.facturaCompraDetalleService.GetFacturaCompraDetalle(idEmpresa, numeroFactura);

            if (factura.Count > 0)
                return Ok(factura);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
