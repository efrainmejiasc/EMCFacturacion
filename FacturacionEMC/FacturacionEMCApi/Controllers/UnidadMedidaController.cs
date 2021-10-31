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
    public class UnidadMedidaController : ControllerBase
    {

        IUnidadMedidaService unidadMedidaService;
        public UnidadMedidaController(IUnidadMedidaService _unidadMedidaService)
        {
            unidadMedidaService = _unidadMedidaService;
        }

        /// <summary> 
        /// Obtiene las unidades de medida por Id Empresa
        /// </summary>
        /// <returns>Lista metodos Pago</returns>
        [HttpGet("{id}/{idioma}", Name = "GetUnidadesMedida")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<UnidadMedidaDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetUnidadesMedida(int id,string idioma)
        {
            var unidades = this.unidadMedidaService.GetUnidadMedidas(id,idioma);

            if (unidades.Count > 0)
                return Ok(unidades);

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
