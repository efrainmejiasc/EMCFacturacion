using DatosEMC.DataModels;
using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IProductoImgInfoRepository
    {
        bool DeleteImgProduct(int id);
        List<ProductManagerImgDTO> GetProductImgInfo(int id);
        ProductoImgInfo EditImgProduct(ProductoImgInfo model);
        List<string> GetCategoryDescription(int idEmpresa = 0);
        ProductoImgInfo InsertProductImgInfo(ProductoImgInfo model);
        List<ProductManagerImgDTO> GetProductImgInfo(string strProducto);

    }
}
