using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public  class ProductoImgRepository: IProductoImgRepository
    {
        private readonly MyAppContext db;

        public ProductoImgRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public List<ProductoImg>  InsertProductImg(List<ProductoImg> model)
        {
            this.db.ProductoImg.AddRange(model);
            this.db.SaveChanges();

            return model;
        }

        public List<ProductManagerImgDTO> GetAllProductImgInfo(int idEmpresa)
        {
            var lst = new List<ProductManagerImgDTO>();

            lst = (from info in db.ProductoImgInfo where info.IdEmpresa == idEmpresa
                   select new ProductManagerImgDTO
                   {
                       Id = info.Id,
                       IdEmpresa = info.IdEmpresa,
                       Nombre = info.Nombre,
                       Categoria = info.Categoria,
                       Tamaño = info.Tamaño,
                       Peso = info.Peso,
                       Descripcion = info.Descripcion,
                       Precio = Math.Round(info.Precio, 2),
                       StrBase64 = this.db.ProductoImg.Where(x => x.ProductoImgInfoId == info.Id).Select(x => x.StrBase64).FirstOrDefault()

                   }).ToList();

            return lst;
        }
    }
}
