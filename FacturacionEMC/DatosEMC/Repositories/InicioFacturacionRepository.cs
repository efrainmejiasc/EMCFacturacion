using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class InicioFacturacionRepository: IInicioFacturacionRepository
    {
        private readonly MyAppContext db;

        public InicioFacturacionRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public InicioFacturacion SetInicioFacturacion(InicioFacturacion model)
        {
            var t = this.db.InicioFacturacion.Where(x => x.IdEmpresa == model.IdEmpresa).FirstOrDefault();

            if (t != null)
            {
                t.IdEmpresa = model.IdEmpresa;
                t.Activo = true;
                t.Fecha = DateTime.Now;
                t.NumeroFactura = model.NumeroFactura;
            }
            else
                this.db.InicioFacturacion.Add(model);

            this.db.SaveChanges();

            return model;
        }

        public InicioFacturacion GetInicioFacturacion (int idEmpresa)
        {
            return this.db.InicioFacturacion.Where(x => x.IdEmpresa == idEmpresa).FirstOrDefault();
        }

        public string GetNumeroFacturaInicio (int idEmpresa)
        {
            var numeroInicio =  this.db.InicioFacturacion.Where(x => x.IdEmpresa == idEmpresa).Select(x => x.NumeroFactura).FirstOrDefault();

            return string.IsNullOrEmpty(numeroInicio) ? string.Empty : numeroInicio;
        }

        public InicioFacturacion ReInicioFacturacion(int idEmpresa)
        {
            var reInicio = this.db.InicioFacturacion.Where(x => x.IdEmpresa == idEmpresa).FirstOrDefault();
            if (reInicio != null)
            {
                reInicio.Activo = false;
                reInicio.NumeroFactura = string.Empty;
                this.db.SaveChanges();
            }

            return reInicio;
        }
    }
}
