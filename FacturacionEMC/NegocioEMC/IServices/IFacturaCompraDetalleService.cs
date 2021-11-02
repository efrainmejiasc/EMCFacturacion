using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IFacturaCompraDetalleService
    {
        List<FacturaCompraDetalleDTO> GetFacturaCompraDetalle(int idEmpresa, string numeroFactura);
        GenericResponse AddFacturaCompraDetalle(List<FacturaCompraDetalleDTO> facturaDetalleDTO);
    }
}
