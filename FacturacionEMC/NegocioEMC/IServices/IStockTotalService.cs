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
        GenericResponse AddExistencia(List<FacturaCompraDetalleDTO> facturas);
        List<StockTotalDTO> GetStockTotal(int idEmpresa, bool activo = true);
    }
}
