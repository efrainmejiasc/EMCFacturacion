using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class UnidadMedidaRepository: IUnidadMedidaRepository
    {
        private readonly MyAppContext db;

        public UnidadMedidaRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public List<UnidadMedida> GetUnidadMedida( int idEmpresa, string sistema)
        {
            return this.db.UnidadMedida.Where(x => x.IdEmpresa == idEmpresa &&  x.Sistema == sistema).ToList();
        }
    }
}
