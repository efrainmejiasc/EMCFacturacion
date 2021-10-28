using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "UNIQUEIDENTIFIER")]
        public Guid Identificador { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(100)")]
        public string NombreCliente{ get; set; }

        [Column(Order = 4, TypeName = "VARCHAR(50)")]
        public string Rfc { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(300)")]
        public string Direccion { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(50)")]
        public string Telefono { get; set; }

        [Column(Order = 7, TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column(Order = 8, TypeName = "BIT")]
        public bool Activo { get; set; }

        [Column(Order = 9, TypeName = "DATETIME")]
        public DateTime Fecha { get; set; }

        [Column(Order = 10, TypeName = "DATETIME")]
        public DateTime FechaModificacion { get; set; }

        [Column(Order = 11, TypeName = "INT")]
        public int IdEmpresa { get; set; }

        [Column(Order = 12, TypeName = "FLOAT")]
        public float Longitud { get; set; }

        [Column(Order = 13, TypeName = "FLOAT")]
        public float Latitud { get; set; }

        [Column(Order = 14, TypeName = "FLOAT")]
        public float Altitud { get; set; }
    }
}
