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

        public  ProductoImgService(IProductoImgRepository _productoImgRepository, IMapper _mapper)
        {
            this.productoImgRepository= _productoImgRepository;
            this.mapper = _mapper;
        }

        public GenericResponse InsertProductoImg(List<ProductoImgDTO> lstModel)
        {
            var lst= new List<ProductoImg>();
            var single = new ProductoImg();
            foreach ( var x in lstModel) 
            { 
                single = new  ProductoImg()
                {
                    Id = 0,
                    ProductoImgInfoId = x.ProductoImgInfoId,
                    Identificador = x.Identificador,
                    NombreArchivo = x.NombreArchivo,
                    Ubicacion = x.Ubicacion,
                    StrBase64 = x.StrBase64
                };

                lst.Add(single);
            }
            

            lst = this.productoImgRepository.InsertProductImg(lst);

            if (lst[0].Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");
            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }


        public List<ProductManagerImgDTO> GetAllProductImgInfo(int id)
        {
            return this.productoImgRepository.GetAllProductImgInfo(id);
        }

    }
}
