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
        List<ProductManagerImgDTO> GetProductImgInfo(int id);
        ProductoImgInfo InsertProductImgInfo(ProductoImgInfo model);
        List<ProductManagerImgDTO> GetProductImgInfo(string strProducto);
    }
}
