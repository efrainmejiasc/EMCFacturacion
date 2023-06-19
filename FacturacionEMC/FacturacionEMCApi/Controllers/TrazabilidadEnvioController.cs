using DatosEMC.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System.Collections.Generic;
using System;
using System.Net;
using DatosEMC.DataModels;

namespace FacturacionEMCApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TrazabilidadEnvioController : ControllerBase
    {
        private readonly ITrazabilidadEnvioService  trazabilidadEnvioService;
        public TrazabilidadEnvioController(ITrazabilidadEnvioService _trazabilidadEnvioService)
        {
            this.trazabilidadEnvioService = _trazabilidadEnvioService;
        }

        /// <summary>
        /// Crear registro de Envio - Guia
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostTrazabilidadEnvio")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostTrazabilidadEnvio([FromBody] TrazabilidadEnvioDTO model)
        {
            try
            {
                model.Id = 0;
                var genericResponse = this.trazabilidadEnvioService.AddTrazabilidadEnvio(model);

                if (genericResponse.Ok)
                    return Ok(genericResponse);
                else
                    return BadRequest(genericResponse);
            }
            catch (Exception ex){
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

        /// <summary>
        /// Obtiene Envio - Guia entre rango de fechas y id empresa
        /// </summary>
        /// <returns>Lista de facturas de compra</returns>
        [HttpGet("{idEmpresa}/{fechaInicial}/{fechaFinal}", Name = "GetTrazabilidadesEnvio")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<TrazabilidadEnvio>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetTrazabilidadesEnvio(int idEmpresa, DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                var modelo = this.trazabilidadEnvioService.GetTrazabilidadEnvio(idEmpresa, fechaInicial, fechaFinal);

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
        /// Obtiene Envio - Guia por idEmpresa e identificador
        /// </summary>
        /// <returns>Envio - Guia</returns>
        [HttpGet("{idEmpresa}/{guid}", Name = "GetTrazabilidadEnvioIdentidad")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(TrazabilidadEnvio))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetTrazabilidadEnvioIdentidad(int idEmpresa,string guid)
        {
            try
            {
                var identificador = new Guid(guid);
                var modelo = this.trazabilidadEnvioService.GetTrazabilidadEnvio(idEmpresa,identificador);

                if (modelo != null  && modelo.Id > 0)
                    return Ok(modelo);
                else
                    return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

        ///// <summary 
        ///// Obtiene Envio - Guia por idEmpresa y dni
        ///// </summary>
        ///// <returns>Envio - Guia</returns>
        [HttpGet("{idEmpresa}/{dni}", Name = "GetTrazabilidadesEnvioDni")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<TrazabilidadEnvio>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetTrazabilidadesEnvioDni(int idEmpresa, string dni)
        {
            try
            {
                var modelo = this.trazabilidadEnvioService.GetTrazabilidadEnvio(idEmpresa, dni);

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
        /// Actualizar registro de Envio - Guia
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPut(Name = "UpdateTrazabilidadEnvio")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult UpdateTrazabilidadEnvio([FromBody] TrazabilidadEnvioDTO model)
        {
            try
            {
                var genericResponse = this.trazabilidadEnvioService.UpdateTrazabilidadEnvio(model);

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
        /// Eliminar registro de Envio - Guia
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpDelete("{id}", Name = "DeleteTrazabilidadEnvio")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult DeleteTrazabilidadEnvio(int id)
        {
            try
            {
                var genericResponse = this.trazabilidadEnvioService.DeleteTrazabilidadEnvio(id);

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
