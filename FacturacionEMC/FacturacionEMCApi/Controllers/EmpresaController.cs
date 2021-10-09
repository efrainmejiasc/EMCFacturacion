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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService EmpresaService;
        public EmpresaController(IEmpresaService _EmpresaService)
        {
            EmpresaService = _EmpresaService;
        }


        /// <summary>
        ///Obtiene datos de la Empresa
        /// </summary>
        /// <returns>Datos del Empresa</returns>
        // GET: api/GetEmpresas
        [HttpGet(Name = "GetEmpresas")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<EmpresaDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public async Task<IActionResult> GetEmpresas()
        {
            var EmpresasDTO = await this.EmpresaService.GetEmpresaDataAsync();

            if (EmpresasDTO.Count > 0)
                return Ok(EmpresasDTO);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
