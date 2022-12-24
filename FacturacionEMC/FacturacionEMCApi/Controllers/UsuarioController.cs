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
using FacturacionEMCApi.SecurityToken;

namespace FacturacionEMCApi.Controllers
{
    [Route("api/[controller]/[action]")]
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
        ///<param name="idEmpresa">Id Empresa</param>
        ///<param name="userMail">Inombre usuario</param>
        ///<param name="password">Inombre usuario</param>
        ///</summary>
        ///<returns>Datos del usuario</returns>
        // GET: api/GetUserData
        [HttpGet("{idEmpresa}/{userMail}/{password}",Name = "GetUserData")]
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

        /// <summary>
        ///Obtiene usuarios por id empresa 
        ///<param name="idEmpresa">Id Empresa</param>
        ///</summary>
        ///<returns>Usuarios de la empresa </returns>
        // GET: api/GetUsuarios
        [HttpGet("idEmpresa", Name = "GeUsuarios")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<UsuarioDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult GetUsuarios(int idEmpresa)
        {
            var usuariosDTO = this.usuarioService.GetUsuarios(idEmpresa);

            if (usuariosDTO.Count > 0)
                return Ok(usuariosDTO);
            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }


        /// <summary>
        /// Crea un nuevo Usuario
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostUsuario")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Id = 0;


            var genericResponse = this.usuarioService.AddUsuario(usuarioDTO);

            if (genericResponse.Ok)
                return Ok(EngineService.SetGenericResponse(true, "Usuario agregado correctamente"));

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));

        }


        /// <summary>
        /// actualiza estatus de usuario
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPut(Name = "UpdateEstatusUsuario")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult UpdateEstatusUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            var genericResponse = this.usuarioService.UpdateEstatusUsuario(usuarioDTO.IdEmpresa, usuarioDTO.Id, usuarioDTO.Activo);

            if (genericResponse.Ok)
                return Ok(EngineService.SetGenericResponse(true, "Usuario actualizado correctamente"));

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));

        }

        /// <summary>
        /// Eliminar usuario
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpDelete(Name = "EliminarUsuario")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult EliminarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            var genericResponse = this.usuarioService.DeleteUsuario(usuarioDTO.IdEmpresa, usuarioDTO.Id);

            if (genericResponse.Ok)
                return Ok(EngineService.SetGenericResponse(true, "Usuario eliminado correctamente"));

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));

        }


    }
}
