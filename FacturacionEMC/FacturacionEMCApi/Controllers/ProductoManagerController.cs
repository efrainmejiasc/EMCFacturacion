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
        public IActionResult PostProductoImg([FromBody] List<ProductoImgDTO> lstProductImg)
        {
            var genericResponse  = this.productoImgService.InsertProductoImg(lstProductImg);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);
        }

        /// <summary>
        /// Obtiene informacion de imagenes y productos 
        /// </summary>
        /// <returns>Lista informacion de imagenes y productos </returns>
        [HttpGet("{id}", Name = "GetProductImgInfo")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<ProductManagerImgDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetProductImgInfo(int id)
        {
            var productManagerImgs = this.productoImgInfoService.GetProductImgInfo(id);

            if (productManagerImgs.Count > 0)
                return Ok(productManagerImgs);

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }

        /// <summary>
        /// Obtiene informacion de imagenes y productos 
        /// </summary>
        /// <returns>Lista informacion de imagenes y productos </returns>
        [HttpGet("{strProducto}", Name = "GetProductImgInfoExtend")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<ProductManagerImgDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetProductImgInfoExtend(string strProducto)
        {
            var productManagerImgs = this.productoImgInfoService.GetProductImgInfo(strProducto);

            if (productManagerImgs.Count > 0)
                return Ok(productManagerImgs);

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
