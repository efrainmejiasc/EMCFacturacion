using DatosEMC.DTOs;
using FacturacionEMCApi.SecurityToken;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
    public class AutentificacionController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;
        private readonly JwtBearerTokenSettings _jwtBearerTokenSettings;
        public AutentificacionController(IUsuarioService _usuarioService, IOptions<JwtBearerTokenSettings> jwtTokenOptions)
        {
            this.usuarioService = _usuarioService;
            this._jwtBearerTokenSettings = jwtTokenOptions.Value;
        }

        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(AccessToken))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Login([FromBody] CredencialesDTO credencialesDTO)
        {

            if (credencialesDTO == null)
            {
                return BadRequest(new { Message = "No se envió la información de las credenciales" });
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            else
            {
                var usuarioDTO = await this.usuarioService.GetUserDataAsync(credencialesDTO.IdEmpresa, credencialesDTO.UserMail, credencialesDTO.Password);

                if (usuarioDTO != null)
                {
                    // Instancia el provedor de token
                    TokenProvider tokenProvider = new TokenProvider(_jwtBearerTokenSettings);

                    AccessToken token = tokenProvider.GenerarToken(usuarioDTO);

                    return Ok(token);
                }
                else
                {
                    return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
                }
            }

        }

    }
}
