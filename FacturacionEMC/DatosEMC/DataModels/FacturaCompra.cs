using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("FacturaCompra")]
    public class FacturaCompra
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "VARCHAR(50)")]
        public string NumeroFactura { get; set; }

        [Column(Order = 3, TypeName = "INT")]
        public int IdEmpresa { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(100)")]
        public string NombreProveedor { get; set; }

        [Column(Order = 5, TypeName = "INT")]
        public int IdProveedor{ get; set; }

        [Column(Order = 6, TypeName = "MONEY")]
        public decimal Subtotal { get; set; }

        [Column(Order = 7, TypeName = "MONEY")]
        public decimal PorcentajeImpuesto{ get; set; }

        [Column(Order = 8, TypeName = "MONEY")]
        public decimal Impuesto{ get; set; }

        [Column(Order = 9, TypeName = "MONEY")]
        public decimal PorcentajeDescuento { get; set; }

        [Column(Order = 10, TypeName = "MONEY")]
        public decimal Descuento { get; set; }

        [Column(Order = 11, TypeName = "MONEY")]
        public decimal Total { get; set; }

        [Column(Order = 12, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 13, TypeName = "DATETIME")]
        public DateTime FechaModificacion { get; set; }

        [Column(Order = 14, TypeName = "INT")]
        public int IdUsuario{ get; set; }

        [Column(Order = 15, TypeName = "BIT")]
        public bool Activo { get; set; }

    }
}
