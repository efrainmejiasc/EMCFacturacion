using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class VentaNumeroRangoRepository: IVentaNumeroRangoRepository
    {
        private readonly MyAppContext db;
        public VentaNumeroRangoRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public VentaNumeroRango GetRangoSorteoMasActualizado(int idEmpresa)
        {
            var registroMasActualizado = this.db.VentaNumeroRango
                                       .Where(r => r.IdEmpresa == idEmpresa)
                                       .OrderByDescending(r => r.Id)
                                       .FirstOrDefault();

            return registroMasActualizado;
        }

        public VentaNumeroRango AddSorteo(VentaNumeroRango v)
        {
            this.db.VentaNumeroRango.Add(v);
            this.db.SaveChanges();
            return v;
        }
    }
}
