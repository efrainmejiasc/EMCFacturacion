using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IStockTransitoRepository
    {
        List<StockTransito> AddStockTransito(List<StockTransito> model);
        List<StockTransito> GetAsignacionesVendedor(int idEmpresa, int idUsuario, bool activo);
    }
}
