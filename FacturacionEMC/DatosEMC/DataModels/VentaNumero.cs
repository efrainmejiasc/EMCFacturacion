using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    [Table("VentaNumero")]
    public class VentaNumero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "UNIQUEIDENTIFIER")]
        public Guid Identificador { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(250)")]
        public string Vendedor { get; set; }

        [Column(Order = 4, TypeName = "INT")]
        public int Numero { get; set; }

        [Column(Order = 5, TypeName = "VARCHAR(50)")]
        public string Telefono { get; set; }

        [Column(Order = 6, TypeName = "VARCHAR(50)")]
        public string Email { get; set; }

        [Column(Order = 7, TypeName = "VARCHAR(50)")]
        public string Loteria { get; set; }

        [Column(Order = 8, TypeName = "BIT")]
        public bool Activo { get; set; }

        [Column(Order = 9, TypeName = "DATETIME")]
        public DateTime FechaVenta { get; set; }

        [Column(Order = 10, TypeName = "DATETIME")]
        public DateTime FechaSorteo{ get; set; }

        [Column(Order = 11, TypeName = "INT")]
        public int IdEmpresa { get; set; }

        [Column(Order = 12, TypeName = "MONEY")]
        public decimal Monto { get; set; }

        [Column(Order = 13, TypeName = "VARCHAR(50)")]
        public string Ticket{ get; set; }

        [Column(Order = 14, TypeName = "INT")]
        public int Premiado { get; set; }

        [Column(Order = 15, TypeName = "VARCHAR(250)")]
        public string Nombre { get; set; }

        [Column(Order = 16, TypeName = "INT")]
        public int IdVentaNumeroRango { get; set; }
    }
}
