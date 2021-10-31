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
        [HttpPost( Name = "PostFacturaCompra")]
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

        /// <summary>
        /// Obtiene Facturas de compras entre rango de fechas y id empresa
        /// </summary>
        /// <returns>Lista de facturas de compra</returns>
        [HttpGet("{id}/{fechaInicial}/{fechaFinal}", Name = "GetFacturasComprasFechas")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<FacturaCompraDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetFacturasComprasFechas(int id,DateTime fechaInicial, DateTime fechaFinal)
        {
            var facturas = this.facturaCompraService.GetFacturasComprasFechas(id,fechaInicial, fechaFinal);

            if (facturas.Count > 0)
                return Ok(facturas);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }

        /// <summary>
        /// Obtiene Facturas de compras ultimas 50 por id empresa
        /// </summary>
        /// <returns>Lista de facturas de compra</returns>
        [HttpGet("{id}", Name = "GetFacturasCompras")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<FacturaCompraDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetFacturasCompras(int id)
        {
            var facturas = this.facturaCompraService.GetFacturasCompras(id);

            if (facturas.Count > 0)
                return Ok(facturas);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
