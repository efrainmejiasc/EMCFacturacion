using DatosEMC.DataModels;
using DatosEMC.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System.Collections.Generic;
using System.Net;

namespace FacturacionEMCApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductoManagerController : ControllerBase
    {
        private readonly IProductoImgInfoService productoImgInfoService;
        private readonly IProductoImgService productoImgService;
        public  ProductoManagerController(IProductoImgService _productoImgService, IProductoImgInfoService _productoImgInfoService)
        {
            this.productoImgInfoService = _productoImgInfoService;
            this.productoImgService = _productoImgService;
        }

        /// <summary>
        /// Crear registro 
        /// </summary>
        [HttpPost(Name = "PostProductoImgInfo")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult PostProductoImgInfo([FromBody] ProductoImgInfoDTO productoImgInfo)
        {
            var genericResponse = this.productoImgInfoService.InsertProductoImgInfo(productoImgInfo);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);
        }

        /// <summary>
        /// Crear registro 
        /// </summary>

        [HttpPost(Name = "PostProductoImg")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult InsertProductoImg([FromBody] List<ProductoImgDTO> lstProductImg)
        {
            var genericResponse  = this.productoImgService.InsertProductoImg(lstProductImg);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);
        }
    }
}
