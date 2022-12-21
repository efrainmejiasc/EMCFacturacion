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
    public class ProductoImgService: IProductoImgService
    {
        private readonly IMapper mapper;
        private readonly IProductoImgRepository productoImgRepository;

        public  ProductoImgService(IProductoImgRepository _productoImgRepository)
        {
            this.productoImgRepository= _productoImgRepository;
        }

        public GenericResponse InsertProductoImg(List<ProductoImgDTO> lstModel)
        {
            var lst= this.mapper.Map<List<ProductoImg>>(lstModel);

            lst = this.productoImgRepository.InsertProductImg(lst);

            if (lstModel[0].Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");
            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }
    }
}
