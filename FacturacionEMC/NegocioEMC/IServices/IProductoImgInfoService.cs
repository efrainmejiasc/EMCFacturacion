using DatosEMC.DataModels;
using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IProductoImgInfoService
    {
       List<ProductManagerImgDTO> GetProductImgInfo(int id);
       GenericResponse InsertProductoImgInfo(ProductoImgInfoDTO model);
    }
}
