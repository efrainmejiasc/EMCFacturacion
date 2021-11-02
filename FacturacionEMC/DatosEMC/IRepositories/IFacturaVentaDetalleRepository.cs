using DatosEMC.DataModels;
using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IFacturaVentaDetalleRepository
    {
        List<FacturaVentaDetalleDTO> GetDetalleFactura(int idEmpresa, string numeroFactura);
        FacturaVentaDetalle GetFacturaVentaDetalle(int idEmpresa, string numeroFactura);
        List<FacturaVentaDetalle> AddFacturaVentaDetalle(List<FacturaVentaDetalle> facturaDetalle);
    }
}
