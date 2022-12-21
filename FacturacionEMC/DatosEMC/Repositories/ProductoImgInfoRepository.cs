using DatosEMC.DataModels;
using DatosEMC.IRepositories;
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

    }
}
