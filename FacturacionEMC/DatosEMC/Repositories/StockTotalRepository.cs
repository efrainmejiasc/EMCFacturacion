using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class StockTotalRepository: IStockTotalRepository
    {
        private readonly MyAppContext db;
        public StockTotalRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public List<StockTotal> AddExistencia(List<StockTotal> model )
        {
            db.StockTotal.AddRange(model);
            db.SaveChanges();

            return model;
        }
    }
}
