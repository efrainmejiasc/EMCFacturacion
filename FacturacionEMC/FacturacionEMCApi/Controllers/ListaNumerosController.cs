using DatosEMC.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.IO;
using System.Net;

namespace FacturacionEMCApi.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class ListaNumerosController : ControllerBase
    {
        private readonly IListaBingoService _listaBingoService;
        private readonly IWebHostEnvironment _environment;
        private readonly string _contentPath;

        public ListaNumerosController(IListaBingoService listaBingoService,IWebHostEnvironment environment)
        {
            this._listaBingoService = listaBingoService;
            _environment = environment;
            _contentPath = Path.Combine(_environment.ContentRootPath, "wwwroot");
            if (!Directory.Exists(_contentPath))
            {
                Directory.CreateDirectory(_contentPath);
            }

        }


        /// <summary>
        /// Crear listas de bingo
        /// </summary>
        /// <returns>listas</returns>
        [HttpPost(Name = "PostListasNumeros")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostListasNumeros()
        {
            try
            {
                var genericResponse = this._listaBingoService.GenerarListas(this._contentPath);

                if (genericResponse.Ok)
                    return Ok(genericResponse);

                else
                    return BadRequest(genericResponse);
            }
            catch(Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }

        }

    }
}
