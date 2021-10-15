using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class FacturaCompraRepository:IFacturaCompraRepository
    {
        private readonly MyAppContext db;
        public FacturaCompraRepository(MyAppContext _db)
        {
            this.db =_db;
        }

        public FacturaCompra AddFacturaCompra (FacturaCompra factura)
        {
            db.FacturaCompra.Add(factura);
            db.SaveChangesAsync();

            return factura;
        }
    }
}
