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

        /// <summary>
        /// Obtiene detalle de la factura por id empresa
        /// </summary>
        /// <returns>Lista de facturas de venta</returns>
        [HttpGet("{idEmpresa}/{numeroFactura}", Name = "GetFacturaVentaDetalle")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<FacturaVentaDetalleDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetFacturaVentaDetalle(int idEmpresa, string numeroFactura)
        {
            var factura = this.facturaVentaDetalleService.GetFacturaVentaDetalle(idEmpresa, numeroFactura);

            if (factura.Count > 0)
                return Ok(factura);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
