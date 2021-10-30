using DatosEMC.DataModels;
using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IFacturaVentaRepository
    {
        FacturaVenta AddFacturaVenta(FacturaVenta factura);
        List<FacturaVentaDTO> GetFacturasVentas(int idEmpresa);
        List<FacturaVentaDTO> GetFacturasVentasFechas(int idEmpresa, DateTime fInicio, DateTime fFinal);
    }
}
