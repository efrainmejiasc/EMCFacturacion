using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DatosEMC.DTOs;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using DatosEMC.DataModels;

namespace FacturacionEMCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;
        public UsuarioController(IUsuarioService _usuarioService)
        {
            usuarioService = _usuarioService;
        }


        /// <summary>
        ///Obtiene datos del usuario
        /// <param name="idEmpresa">Id Empresa</param>
        /// <param name="userMail">Inombre usuario</param>
        /// <param name="password">Inombre usuario</param>
        /// </summary>
        /// <returns>Datos del usuario</returns>
        // GET: api/GetUserData
        [HttpGet(Name = "GetUserData")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(UsuarioDTO))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public async Task<IActionResult> GetUserData(int idEmpresa, string userMail, string password)
        {
            var usuarioDTO = await this.usuarioService.GetUserDataAsync(idEmpresa, userMail, password);

            if (usuarioDTO != null)
                return Ok(usuarioDTO);
            else
            return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
