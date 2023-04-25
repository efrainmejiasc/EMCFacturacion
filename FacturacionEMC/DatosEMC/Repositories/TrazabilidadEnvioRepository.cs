using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class TrazabilidadEnvioRepository : ITrazabilidadEnvioRepository
    {
        private readonly MyAppContext db;
        public TrazabilidadEnvioRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public TrazabilidadEnvio AddTrazabilidadEnvioAsync(TrazabilidadEnvio x)
        {
            db.TrazabilidadEnvio.AddAsync(x);
            db.SaveChanges();

            return x;
        }

        public List<TrazabilidadEnvio> GetTrazabilidadEnvio(int idEmpresa, DateTime fechaInicio , DateTime fechaFinal)
        {
            return db.TrazabilidadEnvio.Where(x => 
                                                   x.IdEmpresa == idEmpresa && 
                                                   x.FechaEnvio >= fechaInicio &&
                                                   x.FechaEnvio <= fechaFinal).ToList();
        }

        public TrazabilidadEnvio GetTrazabilidadEnvio(int idEmpresa, Guid identificador)
        {
            return db.TrazabilidadEnvio.Where(x => x.Identificador== identificador &&
                                                   x.IdEmpresa == idEmpresa).FirstOrDefault();
        }

        public List<TrazabilidadEnvio> GetTrazabilidadEnvio(int idEmpresa, string dni)
        {
            return db.TrazabilidadEnvio.Where(x => x.Dni == dni &&
                                                   x.IdEmpresa == idEmpresa).ToList();
        }
    }
}
