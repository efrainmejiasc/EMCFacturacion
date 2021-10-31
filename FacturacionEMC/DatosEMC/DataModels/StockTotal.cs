using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("StockTotal")]
    public class StockTotal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "INT")]
        public int IdEmpresa { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(50)")]
        public string NumeroFactura { get; set; }

        [Column(Order = 4, TypeName = "INT")]
        public int Linea { get; set; }

        [Column(Order = 5, TypeName = "MONEY")]
        public decimal Cantidad { get; set; }

        [Column(Order = 6, TypeName = "INT")]
        public int IdArticulo { get; set; }

        [Column(Order = 7, TypeName = "VARCHAR(100)")]
        public string NombreArticulo { get; set; }

        [Column(Order = 8, TypeName = "INT")]
        public int Unidad { get; set; }

        [Column(Order = 9, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 10, TypeName = "DATETIME")]
        public DateTime FechaModificacion { get; set; }

        [Column(Order = 11, TypeName = "BIT")]
        public bool Activo { get; set; }

        [Column(Order = 12, TypeName = "INT")]
        public int IdUsuario { get; set; }

        [Column(Order = 13, TypeName = "INT")]
        public int TipoFactura { get; set; }
    }
}
