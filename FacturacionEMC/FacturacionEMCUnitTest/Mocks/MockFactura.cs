using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace FacturacionEMCUnitTest.Mocks
{
    public class MockFactura
    {
        public static EMCApi.Client.FacturaCompraDTO  SetValoresHeadersFactura(int idEmpresa, int idUsuario)
        {
            var factura = new EMCApi.Client.FacturaCompraDTO();
            factura.IdEmpresa = idEmpresa;
            factura.IdUsuario = idUsuario;
            factura.Activo = true;
            factura.Subtotal = 100;
            factura.Fecha = factura.FechaModificacion = DateTime.Now;
            factura.Descuento = factura.PorcentajeDescuento > 0 ? factura.Subtotal - (factura.Subtotal * factura.PorcentajeDescuento * 0.01F) : 0.00F;
            factura.Impuesto = factura.PorcentajeImpuesto > 0 ? (factura.Subtotal - factura.Descuento) - (factura.Subtotal * factura.PorcentajeImpuesto * 0.01F) : 0.00F;
            factura.Total = factura.Total - factura.Descuento + factura.Impuesto;

            return factura;

        }

        public static DatosEMC.DTOs.FacturaCompraDTO SetValoresHeadersFactura()
        {
            var factura = new DatosEMC.DTOs.FacturaCompraDTO();
            factura.IdEmpresa = 1;
            factura.IdUsuario = 2;
            factura.Activo = true;
            factura.Subtotal = 100;
            factura.Fecha = factura.FechaModificacion = DateTime.Now;
            factura.Descuento =0;
            factura.Impuesto = 0;
            factura.Total = factura.Total - factura.Descuento + factura.Impuesto;

            return factura;

        }

        public static DatosEMC.DataModels.FacturaCompra SetFacturaCompraToApi(DatosEMC.DTOs.FacturaCompraDTO x )
        {
            var factura = new DatosEMC.DataModels.FacturaCompra()
            {

            };

            return factura;
        }

    }
}
