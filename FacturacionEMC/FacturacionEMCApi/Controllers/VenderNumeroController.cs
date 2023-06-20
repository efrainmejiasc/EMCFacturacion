using DatosEMC.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Net;

namespace FacturacionEMCApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VenderNumeroController : ControllerBase
    {
        private readonly IVentaNumeroService _ventaNumeroService;
        public VenderNumeroController(IVentaNumeroService ventaNumeroService)
        {
            this._ventaNumeroService = ventaNumeroService;
        }

        /// <summary>
        /// Crear registro de venta numero - Venta Numero por Ticket
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostVentaNumeroTicket")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult PostVentaNumeroTicket([FromBody] List<VentaNumeroDTO> model)
        {
            try
            {
                foreach (var item in model)
                   item.Id = 0;

                var genericResponse = this._ventaNumeroService.AddVentaNumeroAsync(model);

                if (genericResponse.Ok)
                    return Ok(genericResponse);
                else
                    return BadRequest(genericResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }


        /// <summary>
        /// Crear registro de venta numero - Venta Numero por Id
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostVentaNumeroId")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult PostVentaNumeroId([FromBody] VentaNumeroDTO model)
        {
            try
            {
                model.Id = 0;
                var genericResponse = this._ventaNumeroService.AddVentaNumeroAsync(model);

                if (genericResponse.Ok)
                    return Ok(genericResponse);
                else
                    return BadRequest(genericResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }
    }
}
