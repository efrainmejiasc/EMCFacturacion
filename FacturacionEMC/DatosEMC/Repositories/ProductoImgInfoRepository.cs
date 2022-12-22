using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using DatosEMC.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class ProductoImgInfoRepository : IProductoImgInfoRepository
    {
        private readonly MyAppContext db;

        public ProductoImgInfoRepository(MyAppContext _db) 
        { 
            this.db = _db;
        }

        public ProductoImgInfo InsertProductImgInfo(ProductoImgInfo model)
        {
            this.db.ProductoImgInfo.Add(model);
            this.db.SaveChanges();

            return model;
        }

        public List<ProductManagerImgDTO> GetProductImgInfo(int id)
        {
            var lst = new List<ProductManagerImgDTO>();
            lst = (from info in db.ProductoImgInfo
                   join img in db.ProductoImg  on info.Id equals img.ProductoImgInfoId 
                   where info.Id == id
                   select new ProductManagerImgDTO
                   {
                       Id = info.Id,
                       Nombre = info.Nombre,
                       Categoria = info.Categoria,
                       Tamaño = info.Tamaño,
                       Peso = info.Peso,
                       Descripcion = info.Descripcion,
                       NombreImg = img.NombreArchivo,
                       Identificador = img.Identificador,
                       StrBase64  = img.StrBase64,
                       Ubicacion = img.Ubicacion

                   }).ToList();

            return lst;
        }

    }
}
