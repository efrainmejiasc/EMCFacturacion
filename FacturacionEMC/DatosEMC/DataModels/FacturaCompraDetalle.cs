using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("FacturaCompraDetalle")]
    public class FacturaCompraDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string NumeroFactura { get; set; }

        [Column(Order = 3, TypeName = "INT")]
        public int Linea { get; set; }

        [Column(Order = 4, TypeName = "INT")]
        public int IdArticulo { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(50)")]
        public string NombreArticulo { get; set; }

        [Column(Order = 6, TypeName = "INT")]
        public int Cantidad { get; set; }

        [Column(Order = 7, TypeName = "MONEY")]
        public decimal Subtotal { get; set; }

        [Column(Order = 8, TypeName = "MONEY")]
        public decimal PorcentajeImpuesto { get; set; }

        [Column(Order = 9, TypeName = "MONEY")]
        public decimal Impuesto { get; set; }

        [Column(Order = 10, TypeName = "MONEY")]
        public decimal PorcentajeDescuento { get; set; }

        [Column(Order = 11, TypeName = "MONEY")]
        public decimal Descuento { get; set; }

        [Column(Order = 12, TypeName = "MONEY")]
        public decimal Total { get; set; }

        [Column(Order = 13, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 14, TypeName = "DATETIME")]
        public DateTime FechaModificacion { get; set; }

        [Column(Order = 15, TypeName = "INT")]
        public int IdUsuario { get; set; }

        [Column(Order = 16, TypeName = "BIT")]
        public bool Activo { get; set; }

        [Column(Order = 17, TypeName = "VARCHAR(50)")]
        public string Unidad { get; set; }
    }
}
