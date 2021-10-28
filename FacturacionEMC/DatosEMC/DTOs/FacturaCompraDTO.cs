using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class FacturaCompraDTO
    {
        public int Id{ get; set; }
        public string NumeroFactura { get; set; }

        public int IdEmpresa { get; set; }

        public string NombreProveedor { get; set; }

        public int IdProveedor { get; set; }

        public decimal Subtotal { get; set; }

        public decimal PorcentajeImpuesto { get; set; }

        public decimal Impuesto { get; set; }

        public decimal PorcentajeDescuento { get; set; }

        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        public DateTime Fecha { get; set; }

        public DateTime FechaModificacion { get; set; }

        public int IdUsuario { get; set; }

        public bool Activo { get; set; }

        public int IdMetodoPago { get; set; }
    }
}
