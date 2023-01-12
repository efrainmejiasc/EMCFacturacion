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
    public class ProductoImgInfoService: IProductoImgInfoService
    {
        private readonly IMapper mapper;
        private readonly IProductoImgInfoRepository productoImgInfoRepository;
        public ProductoImgInfoService (IProductoImgInfoRepository _productoImgInfoRepository, IMapper _mapper)
        {
            this.productoImgInfoRepository= _productoImgInfoRepository;
            this.mapper = _mapper;
        }

        public GenericResponse InsertProductoImgInfo(ProductoImgInfoDTO model)
        {
            var modelo = new ProductoImgInfo() {
                Nombre = model.Nombre,
                Categoria = model.Categoria,
                Tamaño = model.Tamaño,
                Peso = model.Peso,
                Descripcion = model.Descripcion,
                Id = 0,
                IdEmpresa = model.IdEmpresa,
                Precio = model.Precio
            };
            modelo =  this.productoImgInfoRepository.InsertProductImgInfo(modelo);

            if (modelo.Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada", modelo.Id);
            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public List<ProductManagerImgDTO> GetProductImgInfo(int id)
        {
            return this.productoImgInfoRepository.GetProductImgInfo(id);
        }

        public List<ProductManagerImgDTO> GetProductImgInfo(string strProducto)
        {
            return this.productoImgInfoRepository.GetProductImgInfo(strProducto);
        }


        public GenericResponse EditImgProduct(ProductoImgInfoDTO model)
        {
            var modelo = new ProductoImgInfo()
            {
                Id = model.Id,
                Nombre = model.Nombre,
                Categoria = model.Categoria,
                Tamaño = model.Tamaño,
                Peso = model.Peso,
                Descripcion = model.Descripcion,
                IdEmpresa = model.IdEmpresa,
                Precio = model.Precio
            };

            modelo =  this.productoImgInfoRepository.EditImgProduct(modelo);

            if (modelo.Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada", modelo.Id);
            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public GenericResponse DeleteImgProduct(int id)
        {
            var result = this.productoImgInfoRepository.DeleteImgProduct(id);

            if (result)
                return EngineService.SetGenericResponse(true, "La información ha sido eliminada", 0);
            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

    }
}
