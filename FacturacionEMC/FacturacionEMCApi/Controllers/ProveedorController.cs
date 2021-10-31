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
    public class ProveedorController : ControllerBase
    {
        IProveedorService proveedorService;
        public ProveedorController(IProveedorService _proveedorService )
        {
            proveedorService = _proveedorService;
        }

        /// <summary>
        /// Crea un nuevo proveedor
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostProveedor")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostProveedor([FromBody] ProveedorDTO proveedorDTO)
        {
            proveedorDTO.Id = 0;


            var genericResponse = this.proveedorService.AddProveedor(proveedorDTO);

            if (genericResponse.Ok)
                return Ok(EngineService.SetGenericResponse(true, "Proveedor agregado correctamente"));

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));

        }

        /// <summary>
        /// Obtiene los proveedores por idEmpresa
        /// </summary>
        /// <returns>Lista de proveedores por idEmpresa </returns>
        [HttpGet("{id}", Name = "GetProveedores")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<ProveedorDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetProveedores(int id)
        {
            var proveedores =  this.proveedorService.GetProveedores(id);

            if (proveedores.Count > 0)
                return Ok(proveedores);

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }


    }
}
