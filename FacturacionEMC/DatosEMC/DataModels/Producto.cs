using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "UNIQUEIDENTIFIER")]
        public Guid Identificador { get; set; }

        [Column(Order = 3, TypeName = "INT")]
        public int IdEmpresa { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(100)")]
        public string NombreProducto { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(200)")]
        public string Descripcion { get; set; }

        [Column(Order = 6, TypeName = "MONEY")]
        public decimal PrecioUnidad{ get; set; }

        [Column(Order = 7, TypeName = "VARCHAR(50)")]
        public string Presentacion { get; set; }

        [Column(Order = 8, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 9, TypeName = "INT")]
        public int IdUsuario { get; set; }

        [Column(Order = 10, TypeName = "BIT")]
        public bool Activo { get; set; }
    }
}
