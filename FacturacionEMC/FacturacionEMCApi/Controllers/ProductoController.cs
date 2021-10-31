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
    public class ProductoController : ControllerBase
    {
        IProductoService productoService;
        public ProductoController(IProductoService _productoService)
        {
            productoService = _productoService;
        }

        /// <summary>
        /// Crea un nuevo Producto
        /// </summary>
        /// <returns>Estado de la solicitud</returns>
        [HttpPost(Name = "PostProducto")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(GenericResponse))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]

        public IActionResult PostCliente([FromBody] ProductoDTO productoDTO)
        {
            productoDTO.Id = 0;


            var genericResponse = this.productoService.AddProducto(productoDTO);

            if (genericResponse.Ok)
                return Ok(EngineService.SetGenericResponse(true, "Producto agregado correctamente"));

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));

        }

        /// <summary>
        /// Obtiene los productos por idEmpresa
        /// </summary>
        /// <returns>Lista de Productos activos por idEmpresa </returns>
        [HttpGet("{id}/{activo}", Name = "GetProductos")]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.OK, Type = typeof(List<ProductoDTO>))]
        [ProducesResponseType(statusCode: (int)HttpStatusCode.BadRequest, Type = typeof(GenericResponse))]
        public IActionResult GetProductos(int id, bool activo)
        {
            var productos = this.productoService.GetProductos(id,activo);

            if (productos.Count > 0)
                return Ok(productos);

            else
                return BadRequest(EngineService.SetGenericResponse(false, "No se encontró información"));
        }

    }
}
