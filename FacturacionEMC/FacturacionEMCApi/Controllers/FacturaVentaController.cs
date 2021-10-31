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
    [Route("api/[controller]/[action]")]
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

        /// <summary>
        /// Obtiene Facturas de venta entre rango de fechas y id empresa
        /// </summary>
        /// <returns>Lista de facturas de venta</returns>
        [HttpGet("{id}/{fechaInicial}/{fechaFinal}", Name = "GetFacturasVentasFechas")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<FacturaVentaDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetFacturasVentasFechas(int id, DateTime fechaInicial, DateTime fechaFinal)
        {
            var facturas = this.facturaVentaService.GetFacturasVentasFechas(id, fechaInicial, fechaFinal);

            if (facturas.Count > 0)
                return Ok(facturas);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }

        /// <summary>
        /// Obtiene Facturas de ventas ultimas 50 por id empresa
        /// </summary>
        /// <returns>Lista de facturas de venta</returns>
        [HttpGet("{id}", Name = "GetFacturasVentas")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<FacturaVentaDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetFacturasVentas(int id)
        {
            var facturas = this.facturaVentaService.GetFacturasVentas(id);

            if (facturas.Count > 0)
                return Ok(facturas);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
