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
    public class InicioFacturacion : ControllerBase
    {
        private readonly IInicioFacturacionService inicioFacturacionService;
        public InicioFacturacion(IInicioFacturacionService _inicioFacturacionService)
        {
            this.inicioFacturacionService = _inicioFacturacionService;
        }

        /// <summary>
        /// Establecer Inicio Facturacion
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostInicioFacturacion")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public GenericResponse PostInicioFacturacion(InicioFacturacionDTO model)
        {
            var inicio = this.inicioFacturacionService.SetInicioFacturacion(model);

            if (inicio != null)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }


        /// <summary>
        /// Obtiene el inicio de facturacion
        /// </summary>
        /// <returns>inicio de facturacion</returns>
        [HttpGet("{idEmpresa}", Name = "GetInicioFacturacionCtrl")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(InicioFacturacionDTO))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetInicioFacturacionCtrl(int idEmpresa)
        {
            var noIniciado = new InicioFacturacionDTO();

            var inicio = this.inicioFacturacionService.GetInicioFacturacionCtrl(idEmpresa);

            if (inicio != null)
                return Ok(inicio);
            else
                return Ok(noIniciado);

        }


        /// <summary>
        /// Establecer RE Inicio Facturacion
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPut("{idEmpresa}", Name = "ReInicioFacturacion")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public GenericResponse ReInicioFacturacion(int idEmpresa)
        {
            var inicio = this.inicioFacturacionService.ReInicioFacturacion(idEmpresa);

            if (inicio != null)
                return EngineService.SetGenericResponse(true, "La información ha sido actualizada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo actualizar la información");
        }


    }
}
