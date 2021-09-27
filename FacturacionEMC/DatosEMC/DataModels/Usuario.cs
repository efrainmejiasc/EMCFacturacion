using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatosEMC.DataModels
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "INT")]
        public int IdEmpresa { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(50)")]
        public int Nombre { get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(50)")]
        public int Apellido { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(50)")]
        public int Username { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(50)")]
        public int Password { get; set; }

        [Column(Order = 7, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 8, TypeName = "BIT")]
        public bool Activo { get; set; }
    }
}
