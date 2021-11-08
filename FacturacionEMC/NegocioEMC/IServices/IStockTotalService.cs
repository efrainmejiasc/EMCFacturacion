using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IStockTotalService
    {
        List<StockTotalDTO> GetStockTotal(int idEmpresa, bool activo = true);
        GenericResponse AddExistencia(List<FacturaCompraDetalleDTO> facturas);
        GenericResponse RemoveExistencia(List<FacturaVentaDetalleDTO> facturas);
        decimal GetExistenciaProducto(int idEmpresa, int idArticulo, bool activo = true);
    }
}
