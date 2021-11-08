using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IStockTotalRepository
    {
        List<StockTotal> AddExistencia(List<StockTotal> model);
        List<StockTotal> GetProductosStock(int idEmpresa, bool activo = true);
        decimal GetExistenciaProducto(int idEmpresa, int idArticulo, bool activo = true);
    }
}
