﻿using DatosEMC.DataModels;
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


        /// <summary>
        /// Obtiene informacion de imagenes y productos segun id empresa
        /// </summary>
        /// <returns>Lista informacion de imagenes y productos </returns>
        [HttpGet("{id}", Name = "GetProductAllImgInfo")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<ProductManagerImgDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetProductAllImgInfo(int id)
        {
            var productManagerImgs = this.productoImgService.GetAllProductImgInfo(id);

            if (productManagerImgs.Count > 0)
                return Ok(productManagerImgs);

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }


        /// <summary>
        /// Editar  registros de imagenes de productos
        /// </summary>

        [HttpPut(Name = "EditImgProduct")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult EditImgProduct ([FromBody] ProductoImgInfoDTO productImg)
        {
            var genericResponse = this.productoImgInfoService.EditImgProduct(productImg);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);
        }

        /// <summary>
        /// Eliminar registros de imagenes de productos
        /// </summary>

        [HttpDelete("{id}", Name = "DeleteImgProduct")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult DeleteImgProduct(int id)
        {
            var genericResponse = this.productoImgInfoService.DeleteImgProduct(id);

            if (genericResponse.Ok)
                return Ok(genericResponse);

            else
                return BadRequest(genericResponse);
        }



        /// <summary>
        /// Obtiene descripcion y categorias de productos 
        /// </summary>
        /// <returns>Lista informacion de imagenes y productos </returns>
        [HttpGet("{idEmpresa}", Name = "GetCategoryDescription")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<string>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetCategoryDescription(int idEmpresa)
        {
            var info  = this.productoImgInfoService.GetCategoryDescription(idEmpresa);

            if (info.Count > 0)
                return Ok(info);

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }
    }
}
