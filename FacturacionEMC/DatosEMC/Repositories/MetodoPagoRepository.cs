using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class MetodoPagoRepository: IMetodoPagoRepository
    {
        private readonly MyAppContext db;
        public MetodoPagoRepository(MyAppContext _db)
        {
            this.db = _db;
        }
        public List<MetodoPago> GetMetodoPago(string idioma)
        {
            return this.db.MetodoPago.Where(x => x.Idioma == idioma.ToUpper()).ToList();
        }
    }
}
