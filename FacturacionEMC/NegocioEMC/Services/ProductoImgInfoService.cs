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
        public ProductoImgInfoService (IProductoImgInfoRepository _productoImgInfoRepository)
        {
            this.productoImgInfoRepository= _productoImgInfoRepository;
        }

        public GenericResponse InsertProductoImgInfo(ProductoImgInfoDTO model)
        {
            var modelo = this.mapper.Map<ProductoImgInfo> (model);
            modelo =  this.productoImgInfoRepository.InsertProductImgInfo(modelo);

            if (model.Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada", modelo.Id);
            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }
    }
}
