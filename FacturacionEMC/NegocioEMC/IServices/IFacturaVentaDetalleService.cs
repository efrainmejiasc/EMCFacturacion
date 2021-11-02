using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IFacturaVentaDetalleService
    {
        List<FacturaVentaDetalleDTO> GetFacturaVentaDetalle(int idEmpresa, string numeroFactura);
        GenericResponse AddFacturaVentaDetalle(List<FacturaVentaDetalleDTO> facturaDetalleDTO);
    }
}
