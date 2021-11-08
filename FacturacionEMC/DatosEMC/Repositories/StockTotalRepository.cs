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

        public List<StockTotal> GetProductosStock(int idEmpresa, bool activo = true)
        {
            return db.StockTotal.Where(x => x.Activo == activo && x.IdEmpresa == idEmpresa).ToList();
        }

        public decimal GetExistenciaProducto (int idEmpresa, int idArticulo,bool activo = true)
        {
            var numeroPositivo = db.StockTotal.Where(x => x.Activo == activo && x.IdEmpresa == idEmpresa && x.IdArticulo == idArticulo && x.TipoFactura == 1).Sum(x => x.Cantidad);

            var numeroNegativo = db.StockTotal.Where(x => x.Activo == activo && x.IdEmpresa == idEmpresa && x.IdArticulo == idArticulo && x.TipoFactura == 2).Sum(x => x.Cantidad);

            var resultado = numeroPositivo - numeroNegativo;

            return Math.Round(resultado, 2);

        }

    }
}
