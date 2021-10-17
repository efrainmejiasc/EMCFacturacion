using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class FacturaVentaRepository: IFacturaVentaRepository
    {
        private readonly MyAppContext db;
        public FacturaVentaRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public FacturaVenta AddFacturaVenta(FacturaVenta factura)
        {
            db.FacturaVenta.Add(factura);
            db.SaveChangesAsync();

            return factura;
        }
    }
}
