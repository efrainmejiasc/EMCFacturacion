using DatosEMC.DataModels;
using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IFacturaCompraRepository
    {
        FacturaCompra AddFacturaCompra(FacturaCompra factura);
        List<FacturaCompraDTO> GetFacturasCompras(int idEmpresa);
        List<FacturaCompraDTO> GetFacturasComprasFechas(int idEmpresa, DateTime fInicio, DateTime fFinal);
    }
}
