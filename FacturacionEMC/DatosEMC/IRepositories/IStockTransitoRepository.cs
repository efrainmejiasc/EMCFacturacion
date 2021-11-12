using DatosEMC.DataModels;
using DatosEMC.DTOs;
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
        List<StockTransitoDTO> GetAsignacionesVendedor(int idEmpresa, int idUsuario, bool activo);
        List<StockTransitoDTO> GetStockTransitoProducto(int idEmpresa, int idArticulo, bool activo);
    }
}
