using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class VentaNumeroRepository: IVentaNumeroRepository
    {
        private readonly MyAppContext db;
        public VentaNumeroRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public VentaNumero AddVentaNumeroAsync(VentaNumero  x)
        {
            db.VentaNumero.AddAsync(x);
            db.SaveChanges();

            return x;
        }

        public List<VentaNumero> AddVentaNumeroAsync(List<VentaNumero> x)
        {
            db.VentaNumero.AddRangeAsync(x);
            db.SaveChanges();

            return x;
        }

        public VentaNumero UpdateVentaNumeroAsync(VentaNumero x)
        {
            var t = db.VentaNumero.Where(s => s.Id == x.Id).FirstOrDefault();
            if (t != null)
            {
                t.Numero = x.Numero;
                t.Telefono = x.Telefono;
                t.Email = x.Email;
                t.Loteria = x.Loteria;
                t.FechaSorteo = x.FechaSorteo;
                t.FechaVenta = x.FechaVenta;
                t.Activo = x.Activo;
                t.Monto = x.Monto;

                db.SaveChangesAsync();
            }

            return x;
        }

        public List<VentaNumero> UpdateVentaNumeroAsync(List<VentaNumero> x)
        {
            foreach (var t in x)
              UpdateVentaNumeroAsync(t); 

            return x;
        }

        public List<Loterias> GetLoterias()
        {
            return db.Loterias.ToList();
        }

        public VentaNumero GetPremio(int idEmpresa, int numero, string loteria)
        {
            return db.VentaNumero.Where(x => x.Numero == numero && 
                                             x.IdEmpresa == idEmpresa && 
                                             x.Activo == true && x.Loteria == loteria).FirstOrDefault();
        }
        public List<VentaNumero> GetPremiados(int idEmpresa, int numero, DateTime fecha)
        {
            return db.VentaNumero.Where(x => x.Numero == numero && 
                                             x.IdEmpresa == idEmpresa && 
                                             x.FechaSorteo >= fecha && 
                                             x.FechaSorteo <= fecha).
                                             OrderBy(x => x.FechaSorteo).ToList();
        }

        public List<VentaNumero> GetListaVenta(DateTime fecha, string loteria)
        {
            return db.VentaNumero.Where(x => x.FechaSorteo >= fecha && x.FechaSorteo <= fecha && 
                                             x.Loteria == loteria).ToList();
        }

        public List<VentaNumero> GetTicket(string ticket)
        {
            return db.VentaNumero.Where(x => x.Ticket == ticket).ToList();
        }


    }
}
