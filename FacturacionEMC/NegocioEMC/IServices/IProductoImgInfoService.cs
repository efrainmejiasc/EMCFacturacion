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
       List<ProductManagerImgDTO> GetProductImgInfo(string strProducto);
       GenericResponse InsertProductoImgInfo(ProductoImgInfoDTO model);
    }
}
