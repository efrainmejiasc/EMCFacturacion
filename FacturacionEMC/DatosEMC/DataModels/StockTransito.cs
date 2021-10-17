using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("StockTransito")]
    public class StockTransito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "INT")]
        public int IdEmpresa { get; set; }

        [Column(Order = 3, TypeName = "MONEY")]
        public decimal Cantidad { get; set; }

        [Column(Order = 4, TypeName = "INT")]
        public int IdProducto { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(100)")]
        public string NombreProducto { get; set; }

        [Column(Order = 6, TypeName = "INT")]
        public int IdUnidad { get; set; }

        [Column(Order = 7, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 8, TypeName = "DATETIME")]
        public DateTime FechaModificacion { get; set; }

        [Column(Order = 9, TypeName = "BIT")]
        public bool Activo { get; set; }

        [Column(Order = 10, TypeName = "INT")]
        public int IdVendedor { get; set; }

        [Column(Order = 11, TypeName = "INT")]
        public int IdUsuario { get; set; }
    }
}
