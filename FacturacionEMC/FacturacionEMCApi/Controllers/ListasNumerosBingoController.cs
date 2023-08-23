using DatosEMC.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;

namespace FacturacionEMCApi.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class ListasNumerosBingoController : ControllerBase
    {
        private readonly IListaBingoService _listaBingoService;
        private readonly IWebHostEnvironment _environment;
        private readonly string _contentPath;

        public ListasNumerosBingoController(IListaBingoService listaBingoService,IWebHostEnvironment environment)
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


        /// <summary>
        /// Obtener archivo de listas de bingo
        /// </summary>
        /// <returns>archivo listas</returns>
        [HttpGet(Name = "CompressLatestPdfList")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult CompressLatestPdfList()
        {
            try
            {
                // Buscar el último archivo PDF creado en la carpeta
                var latestPdfFile = Directory.GetFiles(this._contentPath, "*.pdf")
                    .OrderByDescending(f => new FileInfo(f).CreationTime)
                    .FirstOrDefault();

                if (latestPdfFile == null)
                    return BadRequest(EngineService.SetGenericResponse(false, "No se encontraron archivos PDF."));

                // Nombre del archivo ZIP
                var zipFileName = Path.ChangeExtension(latestPdfFile, "zip");

                // Comprimir el archivo PDF en un ZIP
                using (var zipArchive = ZipFile.Open(zipFileName, ZipArchiveMode.Create))
                {
                    zipArchive.CreateEntryFromFile(latestPdfFile, Path.GetFileName(latestPdfFile));
                }

                // Devolver el archivo ZIP como respuesta
                var zipFileBytes = System.IO.File.ReadAllBytes(zipFileName);
                System.IO.File.Delete(zipFileName); // Eliminar el archivo ZIP después de su uso

                return File(zipFileBytes, "application/zip", Path.GetFileName(zipFileName));
            }
            catch (Exception ex)
            {
                return BadRequest(EngineService.SetGenericResponse(false, ex.Message));
            }
        }

    }
}



