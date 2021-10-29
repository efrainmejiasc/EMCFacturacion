using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IMapper _mapper;
        private readonly IProductoRepository productoRepository;

        public ProductoService(IMapper mapper , IProductoRepository _productoRepository)
        {
            this._mapper = mapper;
            this.productoRepository = _productoRepository;
        }

        public GenericResponse AddProducto(ProductoDTO productoDTO)
        {
            var producto = new Producto();
            producto = this._mapper.Map<Producto>(productoDTO);
            producto.Identificador = EngineTool.CreateUniqueidentifier();

            producto = this.productoRepository.AddProducto(producto);

            if (producto != null)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public List<ProductoDTO> GetProductos(int idEmpresa, bool activo)
        {
            var productos = this.productoRepository.GetProductos(idEmpresa,activo);

            var productosDTO = new List<ProductoDTO>();
            productosDTO = this._mapper.Map<List<ProductoDTO>>(productos);

            return productosDTO;
        }

    }
}
