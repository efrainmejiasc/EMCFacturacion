using DatosEMC.DataModels;
using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IFacturaCompraDetalleRepository
    {
        List<FacturaCompraDetalleDTO> GetDetalleFactura(int idEmpresa, string numeroFactura);
        FacturaCompraDetalle GetFacturaCompraDetalle(int idEmpresa, string numeroFactura);
        List<FacturaCompraDetalle> AddFacturaCompraDetalle(List<FacturaCompraDetalle> facturaDetalle);
    }
}
