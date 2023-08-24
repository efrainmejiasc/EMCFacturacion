using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("ImagenesBingo")]
    public class ImagenesBingo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(100)")]
        public string NombreImagen { get; set; }


        [Column(Order = 3, TypeName = "VARCHAR(8000)")]
        public string RutaImagen { get; set; }
    }
}
