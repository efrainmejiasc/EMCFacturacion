using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("InicioFacturacion")]
    public class InicioFacturacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "INT")]
        public int IdEmpresa { get; set; }

        [Column(Order = 3, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 4, TypeName = "BIT")]
        public bool Activo { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(50)")]
        public string NumeroFactura { get; set; }
    }
}
