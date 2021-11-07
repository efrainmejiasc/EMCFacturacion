using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IFacturaVentaService
    {
        string GetNumeroFactura(int idEmpresa);
        List<FacturaVentaDTO> GetFacturasVentas(int idEmpresa);
        GenericResponse AddFacturaVenta(FacturaVentaDTO facturaDTO);
        List<FacturaVentaDTO> GetFacturasVentasFechas(int idEmpresa, DateTime fechaInicial, DateTime fechaFinal);
    }
}
