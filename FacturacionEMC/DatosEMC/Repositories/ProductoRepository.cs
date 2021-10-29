using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MyAppContext db;
        public ProductoRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public Producto AddProducto(Producto model)
        {
            this.db.Producto.Add(model);
            this.db.SaveChanges();

            return model;
        }

        public List<Producto> GetProductos(int idEmpresa, bool activo)
        {
            return this.db.Producto.Where(x => x.IdEmpresa == idEmpresa && x.Activo == activo).ToList();
        }
    }
}
