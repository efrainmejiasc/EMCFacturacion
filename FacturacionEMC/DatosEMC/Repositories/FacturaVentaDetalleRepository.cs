using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class FacturaVentaDetalleRepository : IFacturaVentaDetalleRepository
    {
        private readonly MyAppContext db;
        public FacturaVentaDetalleRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public List<FacturaVentaDetalle> AddFacturaVentaDetalle(List<FacturaVentaDetalle> facturaDetalle)
        {
            db.FacturaVentaDetalle.AddRange(facturaDetalle);
            db.SaveChangesAsync();

            return facturaDetalle;
        }
    }
}
