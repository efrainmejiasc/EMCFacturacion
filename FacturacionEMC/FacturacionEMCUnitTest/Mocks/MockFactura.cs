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
            var factura = new EMCApi.Client.FacturaCompraDTO()
            {
                Id = 1,
                NumeroFactura = "1550",
                IdEmpresa = 1,
                NombreProveedor = "Proveedor A",
                IdProveedor = 1,
                Subtotal = 100,
                PorcentajeImpuesto = 0.18,
                Impuesto = 18.00,
                PorcentajeDescuento = 0.10,
                Descuento = 10.00,
                Total = 108.00,
                Fecha = DateTime.Now,
                FechaModificacion = DateTime.Now,
                IdUsuario = 1,
                Activo = true,
                IdMetodoPago = 1,
                Rfc = "abdcestrsetr",
                MetodoPago = "EFECTIVO"
            };
            return factura;

        }

        public static DatosEMC.DTOs.FacturaCompraDTO SetValoresHeadersFactura()
        {
            var factura = new DatosEMC.DTOs.FacturaCompraDTO()
            {
                Id = 1,
                NumeroFactura = "1550",
                IdEmpresa = 1,
                NombreProveedor = "Proveedor A",
                IdProveedor = 1,
                Subtotal = 100.00m,
                PorcentajeImpuesto = 0.18m,
                Impuesto = 18.00m,
                PorcentajeDescuento = 0.10m,
                Descuento = 10.00m,
                Total = 108.00m,
                Fecha = DateTime.Now,
                FechaModificacion = DateTime.Now,
                IdUsuario = 1,
                Activo = true,
                IdMetodoPago = 1,
                 Rfc = "abdcestrsetr",
                 MetodoPago ="EFECTIVO"
            };

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
