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
    public class EmpresaRepository:IEmpresaRepository
    {
        private readonly MyAppContext db;
        public EmpresaRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public async Task<List<Empresa>> GetEmpresasAsync()
        {
            return await this.db.Empresa.Where(x =>  x.Activo == true).ToListAsync();
        }
    }
}
