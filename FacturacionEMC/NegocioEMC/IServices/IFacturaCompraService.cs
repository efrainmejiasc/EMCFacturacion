using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IFacturaCompraService
    {
        List<FacturaCompraDTO> GetFacturasCompras(int idEmpresa);
        GenericResponse AddFacturaCompra(FacturaCompraDTO facturaDTO);
        List<FacturaCompraDTO> GetFacturasComprasFechas(int idEmpresa, DateTime fechaInicial, DateTime fechaFinal);
    }
}
