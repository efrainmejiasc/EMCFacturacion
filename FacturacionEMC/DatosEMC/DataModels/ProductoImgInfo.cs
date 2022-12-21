using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("ProductoImgInfo")]
    public class ProductoImgInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "VARCHAR(150)")]
        public string Nombre{ get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(150)")]
        public string Categoria{ get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(100)")]
        public string Peso{ get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(100)")]
        public string Tamaño { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(500)")]
        public string Descripcion{ get; set; }
    }
}
