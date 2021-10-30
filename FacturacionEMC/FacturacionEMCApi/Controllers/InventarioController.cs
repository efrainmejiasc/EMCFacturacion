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
    public class InventarioController : ControllerBase
    {
        private readonly IStockTotalService stockTotalService;
        private readonly IStockBodegaService stockBodegaService;
        private readonly IStockTransitoService stockTransitoService;

        public InventarioController( IStockTotalService _stockTotalService, IStockBodegaService _stockBodegaService, IStockTransitoService _stockTransitoService)
        {
          this.stockTotalService = _stockTotalService;
          this.stockBodegaService = _stockBodegaService;
          this.stockTransitoService = _stockTransitoService;
       }


        /// <summary>
        /// Crear registro de stock
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostStockTotal")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostStockTotal([FromBody] List<FacturaCompraDetalleDTO> facturaDTO)
        {
            var genericResponse = this.stockTotalService.AddExistencia(facturaDTO);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);

        }

        /// <summary>
        /// Obtiene stock en bodega
        /// </summary>
        /// <returns>Lista de productos y existencia</returns>
        [HttpGet("id/activo", Name = "GetStockBodega")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<StockTotalDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetStockBodega(int id,bool activo = true)
        {
            var lstStock = this.stockTotalService.GetStockTotal(id, activo);

            if (lstStock.Count > 0)
                return Ok(lstStock);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
