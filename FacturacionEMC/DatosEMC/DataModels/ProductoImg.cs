using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("ProductoImg")]
    public class ProductoImg
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "INT")]
        public int ProductoImgInfoId { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(8000)")]
        public string StrBase64 { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(100)")]
        public string Identificador { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(100)")]
        public string NombreArchivo { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(1000)")]
        public string Ubicacion { get; set; }
    }
}
