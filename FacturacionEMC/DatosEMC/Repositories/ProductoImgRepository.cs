using DatosEMC.DataModels;
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
    }
}
