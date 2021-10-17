using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly MyAppContext db;
        public ClienteRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public Cliente AddClienteAsync(Cliente x)
        {
            db.Cliente.AddAsync(x);
            db.SaveChanges();

            return x;
        }

        public List<Cliente> GetClientes(int idEmpresa)
        {
            return db.Cliente.Where(x => x.Activo == true && x.IdEmpresa == idEmpresa).ToList();
        }
    }
}
