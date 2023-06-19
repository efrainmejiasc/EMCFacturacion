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
                                                   x.FechaEnvio < fechaFinal.AddDays(1)).ToList();
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

        public TrazabilidadEnvio UpdateTrazabilidadEnvio(TrazabilidadEnvio x)
        {
            var t = db.TrazabilidadEnvio.Where(s => s.Id == x.Id).FirstOrDefault();
            if (t != null)
            {
                t.Nombre = x.Nombre;
                t.Dni = x.Dni;
                t.Direccion = x.Direccion;
                t.Email = x.Email;
                t.Observacion = x.Observacion;
                t.FechaEnvio = x.FechaEnvio;
                t.FechaLlegada = x.FechaLlegada;
                t.FechaReclamo = x.FechaReclamo;
                t.Telefono = x.Telefono;
                t.Activo = t.FechaReclamo != x.FechaReclamo ? false : true;
                db.SaveChanges();
            }
          
            return x;
        }

        public bool DeleteTrazabilidadEnvio(int id)
        {
            var result = false;
            var t = this.db.TrazabilidadEnvio.Where(x => x.Id == id).FirstOrDefault();
            if (t != null)
            {
                this.db.TrazabilidadEnvio.Remove(t);
                this.db.SaveChanges();
                result = true;
            }

            return result;
        }
    }
}
