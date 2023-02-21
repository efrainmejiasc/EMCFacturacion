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
        GenericResponse DeleteImgProduct(int id);
        List<ProductManagerImgDTO> GetProductImgInfo(int id);
        List<string> GetCategoryDescription(int idEmpresa = 0);
        GenericResponse EditImgProduct(ProductoImgInfoDTO model);
        GenericResponse InsertProductoImgInfo(ProductoImgInfoDTO model);
        List<ProductManagerImgDTO> GetProductImgInfo(string strProducto);
    }
}
