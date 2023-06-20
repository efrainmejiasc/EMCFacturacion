using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("Loterias")]
    public class Loterias
    {
        [Key]
        [Column(Order = 1, TypeName = "VARCHAR(50)")]
        public int Id { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(50)")]
        public string Nombre { get; set; }
    }
}
