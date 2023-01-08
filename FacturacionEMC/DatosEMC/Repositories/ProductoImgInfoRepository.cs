using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using DatosEMC.Migrations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                       Precio = Math.Round(info.Precio,2),
                       NombreImg = img.NombreArchivo,
                       Identificador = img.Identificador,
                       StrBase64  = img.StrBase64,
                       Ubicacion = img.Ubicacion

                   }).ToList();

            return lst;
        }



        public List<ProductManagerImgDTO> GetProductImgInfo(string strProducto)
        {
            var lst = new List<ProductManagerImgDTO>();

            if (strProducto.Length >= 4)
            {
                var prefix = strProducto.Substring(0, 4);
                var endfix = strProducto.Substring(strProducto.Length - 4, 4);

                lst = (from info in db.ProductoImgInfo
                       join img in db.ProductoImg on info.Id equals img.ProductoImgInfoId
                       where info.Nombre.Contains(strProducto) || info.Categoria.Contains(strProducto) || info.Descripcion.Contains(strProducto)
                       || info.Nombre.StartsWith(prefix) || info.Nombre.EndsWith(prefix)
                       || info.Categoria.StartsWith(prefix) || info.Categoria.EndsWith(prefix)
                       || info.Descripcion.StartsWith(prefix) || info.Descripcion.EndsWith(prefix)
                       select new ProductManagerImgDTO
                       {
                           Id = info.Id,
                           Nombre = info.Nombre,
                           Categoria = info.Categoria,
                           Tamaño = info.Tamaño,
                           Peso = info.Peso,
                           Descripcion = info.Descripcion,
                           Precio = Math.Round(info.Precio, 2),
                           InfoImg = this.db.ProductoImg.Where(x => x.ProductoImgInfoId == info.Id).ToList()

                       }).ToList();
            }
            else
            {
                lst = (from info in db.ProductoImgInfo
                       join img in db.ProductoImg on info.Id equals img.ProductoImgInfoId
                       where info.Nombre.Contains(strProducto) || info.Categoria.Contains(strProducto) || info.Descripcion.Contains(strProducto)
                       || info.Nombre.StartsWith(strProducto) || info.Nombre.EndsWith(strProducto)
                       || info.Categoria.StartsWith(strProducto) || info.Categoria.EndsWith(strProducto)
                       || info.Descripcion.StartsWith(strProducto) || info.Descripcion.EndsWith(strProducto)
                       select new ProductManagerImgDTO
                       {
                           Id = info.Id,
                           Nombre = info.Nombre,
                           Categoria = info.Categoria,
                           Tamaño = info.Tamaño,
                           Peso = info.Peso,
                           Descripcion = info.Descripcion,
                           Precio = Math.Round(info.Precio, 2),
                           InfoImg = this.db.ProductoImg.Where(x => x.ProductoImgInfoId == info.Id).ToList()

                       }).ToList();
            }
;

            return lst;
        }


        public ProductoImgInfo EditImgProduct(ProductoImgInfo model)
        {
            var nuevo = new ProductoImgInfo();
            nuevo = this.db.ProductoImgInfo.Where(x => x.Id == model.Id).FirstOrDefault();
            if(nuevo != null)
            {
                nuevo.Nombre = model.Nombre;
                nuevo.Categoria = model.Categoria;
                nuevo.Peso = model.Peso;
                nuevo.Tamaño = model.Tamaño;
                nuevo.Precio = model.Precio;
                nuevo.Descripcion = model.Descripcion;

                this.db.ProductoImgInfo.Add(nuevo);
                this.db.SaveChanges();
            }

            return nuevo;
        }

        public bool DeleteImgProduct(int id)
        {
            var registro = this.db.ProductoImgInfo.Where(x => x.Id == id).FirstOrDefault();
            if(registro != null)
            {
                this.db.ProductoImgInfo.Attach(registro);
                this.db.ProductoImgInfo.Remove(registro);
                this.db.SaveChanges();

                var detail = this.db.ProductoImg.Where(x => x.ProductoImgInfoId == id).ToList();
                this.db.ProductoImg.AttachRange(detail);
                this.db.ProductoImg.RemoveRange(detail);
                this.db.SaveChanges();
            }
       

            return true;
        }

    }
}
