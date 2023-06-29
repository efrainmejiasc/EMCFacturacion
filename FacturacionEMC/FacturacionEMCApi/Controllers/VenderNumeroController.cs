using DatosEMC.DataModels;
using DatosEMC.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

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
        /// Crear registro de venta numero - Venta Numero por ID
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


        /// <summary>
        /// Crear registro de venta numero - Venta Numero por TICKET
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostVentaNumeroTicket")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult PostVentaNumeroTicket([FromBody] List<VentaNumeroDTO> model)
        {
            try
            {
                var uuid = EngineTool.CreateUniqueidentifier();
                foreach (var item in model)
                {
                    item.Id = 0;
                    item.Identificador = uuid;
                }
                   

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
        /// Actualizar registro de Venta Numero - ID
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPut(Name = "UpdateVentaNumeroRegistro")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult UpdateVentaNumeroRegistro([FromBody] VentaNumeroDTO model)
        {
            try
            {
                var genericResponse = this._ventaNumeroService.UpdateVentaNumeroAsync(model);

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
        /// Actualizar Registros de Venta Numero - TICKET
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPut(Name = "UpdateVentaNumeroTicket")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult UpdateVentaNumeroTicket([FromBody] List<VentaNumeroDTO> model)
        {
            try
            {
                var genericResponse = this._ventaNumeroService.UpdateVentaNumeroAsync(model);

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
        /// Eliminar registro de Venta Numero - ID
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpDelete("{id}", Name = "DeleteVentaNumeroRegistro")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult DeleteVentaNumeroRegistro(int id)
        {
            try
            {
                var genericResponse = this._ventaNumeroService.DeleteVentaNumeroById(id);

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
        /// Eliminar registros de Venta Numero - TICKET
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpDelete("{Ticket}", Name = "DeleteVentaNumeroTicket")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult DeleteVentaNumeroTicket(string ticket)
        {
            try
            {
                var genericResponse = this._ventaNumeroService.DeleteVentaNumeroTicket(ticket);

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
        /// Obtiene Loterias - Devuelve lista de identificadores de loterias
        /// </summary>
        /// <returns> Loterias </returns>
        [HttpGet(Name = "GetLoterias")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<Loterias>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetLoterias()
        {
            try
            {
                var modelo = this._ventaNumeroService.GetLoterias();

                if (modelo.Count > 0)
                    return Ok(modelo);
                else
                    return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

        /// <summary>
        /// Obtiene numero premiado
        /// </summary>
        /// <returns> Loterias </returns>
        [HttpGet("{idEmpresa}/{numero}/{loteria}/{ticket}", Name = "GetPremio")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(VentaNumeroDTO))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetPremio(int idEmpresa, int numero, string loteria,string ticket)
        {
            try
            {
                var modelo = this._ventaNumeroService.GetPremio(idEmpresa,numero,loteria,ticket);

                if (modelo.Id > 0)
                    return Ok(modelo);
                else
                    return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

        /// <summary>
        /// Obtiene numeros premiados
        /// </summary>
        /// <returns> Loterias </returns>
        [HttpGet("{idEmpresa}/{numero}/{fecha}/{loteria}", Name = "GetPremiados")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<VentaNumeroDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetPremiados(int idEmpresa, int numero, DateTime fecha , string loteria)
        {
            try
            {
                var modelo = this._ventaNumeroService.GetPremiados(idEmpresa, numero, fecha, loteria);

                if (modelo.Count > 0)
                    return Ok(modelo);
                else
                    return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

        /// <summary>
        /// Obtiene TICKET
        /// </summary>
        /// <returns> Loterias </returns>
        [HttpGet("{ticket}", Name = "GetTicket")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<VentaNumeroDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetTicket(string ticket)
        {
            try
            {
                var modelo = this._ventaNumeroService.GetTicket(ticket);

                if (modelo.Count > 0)
                    return Ok(modelo);
                else
                    return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

        /// <summary>
        /// Obtiene Lista de Ventas - TICKETS 
        /// </summary>
        /// <returns> Loterias </returns>
        [HttpGet("{fecha}/{loteria}", Name = "GetListaVentas")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<VentaNumeroDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetListaVentas(DateTime fecha, string loteria)
        {
            try
            {
                var modelo = this._ventaNumeroService.GetListaVenta( fecha,loteria);

                if (modelo.Count > 0)
                    return Ok(modelo);
                else
                    return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

        /// <summary>
        /// Obtiene Nº Ticket Para Venta de Loterias - Devuelve un identificador
        /// </summary>
        /// <returns> Loterias </returns>
        [HttpGet(Name = "GetNumeroTicket")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(NumeroTicketDTO))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetNumeroTicket()
        {
            try
            {
                var modelo = this._ventaNumeroService.GetNumeroTicket();

                if (!string.IsNullOrEmpty(modelo.NumeroTicket))
                    return Ok(modelo);
                else
                    return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }
    }
}

