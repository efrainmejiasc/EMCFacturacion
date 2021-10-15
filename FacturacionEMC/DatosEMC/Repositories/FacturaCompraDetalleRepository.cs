using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class FacturaCompraDetalleRepository: IFacturaCompraDetalleRepository
    {
        private readonly MyAppContext db;
        public FacturaCompraDetalleRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public List<FacturaCompraDetalle> AddFacturaCompraDetalle(List<FacturaCompraDetalle> facturaDetalle)
        {
            db.FacturaCompraDetalle.AddRange(facturaDetalle);
            db.SaveChangesAsync();

            return facturaDetalle;
        }
    }
}
