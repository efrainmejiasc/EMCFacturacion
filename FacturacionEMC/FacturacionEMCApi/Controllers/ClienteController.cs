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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace FacturacionEMCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClienteController : ControllerBase
    {

        IClienteService clienteService;
        public ClienteController(IClienteService _clienteService)
        {
            clienteService = _clienteService;
        }

        /// <summary>
        /// Crea un nuevo Cliente
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostCliente")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostCliente([FromBody] ClienteDTO clienteDTO)
        {
            clienteDTO.Id = 0;


            var genericResponse = this.clienteService.AddCliente(clienteDTO);

            if (genericResponse.Ok)
                return Ok(EngineService.SetGenericResponse(true, "Cliente agregado correctamente"));

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));

        }

        /// <summary>
        /// Obtiene los Clientes por idEmpresa
        /// </summary>
        /// <returns>Lista de Clientes por idEmpresa </returns>
        [HttpGet("{idEmpresa}", Name = "GetClientes")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<ClienteDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetClientes(int idEmpresa)
        {
            var clientes = this.clienteService.GetClientes(idEmpresa);

            if (clientes.Count > 0)
                return Ok(clientes);

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }

    }
}
