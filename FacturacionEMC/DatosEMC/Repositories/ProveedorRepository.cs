using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class ProveedorRepository:IProveedorRepository
    {
        private readonly MyAppContext db;
        public ProveedorRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public Proveedor AddProveedorAsync (Proveedor x)
        {
            db.Proveedor.AddAsync(x);
            db.SaveChanges();

            return x;
        }

        public List<Proveedor> GetProveedores( int idEmpresa)
        {
            return db.Proveedor.Where(x => x.Activo == true && x.IdEmpresa == idEmpresa).ToList();
        }
    }
}
