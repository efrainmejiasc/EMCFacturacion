using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("VentaNumeroRango")]
    public  class VentaNumeroRango
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "DATETIME")]
        public DateTime FechaInicial { get; set; }

        [Column(Order = 3, TypeName = "DATETIME")]
        public DateTime FechaFinal { get; set; }

        [Column(Order = 4, TypeName = "INT")]
        public int IdEmpresa { get; set; }

    }
}
