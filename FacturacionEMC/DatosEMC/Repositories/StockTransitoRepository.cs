using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public  class StockTransitoRepository : IStockTransitoRepository
    {
        private readonly MyAppContext db;
        public StockTransitoRepository(MyAppContext _db)
        {
            this.db = _db;
        }
        public List<StockTransito> AddStockTransito(List<StockTransito> model)
        {
            this.db.StockTransito.AddRange(model);
            this.db.SaveChangesAsync();

            return model;
        }

        public List<StockTransito>  GetAsignacionesVendedor (int idEmpresa,int idUsuario, bool activo)
        {
            return this.db.StockTransito.Where(x => x.IdEmpresa == idEmpresa && x.IdUsuario == idUsuario && x.Activo == activo).ToList();
        }

    }
}
