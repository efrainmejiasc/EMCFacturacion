using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatosEMC.DataModels
{
    [Table("ListaBingo")]
    public class ListaBingo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "INT")]
        public int Id { get; set; }

        [Column(Order = 2, TypeName = "UNIQUEIDENTIFIER")]
        public Guid IdentificadorUnico { get; set; }

        [Column(Order = 3, TypeName = "VARCHAR(100)")]
        public string Nombre { get; set; }

        [Column(Order = 4, TypeName = "DATETIME")]
        public DateTime FechaCreacion { get; set; }

        [Column(Order = 5, TypeName = "BIT")]
        public bool Activo { get; set; }

        [Column(Order = 6, TypeName = "INT")]
        public int Numero1 { get; set; }

        [Column(Order = 7, TypeName = "INT")]
        public int Numero2 { get; set; }

        [Column(Order = 8, TypeName = "INT")]
        public int Numero3 { get; set; }

        [Column(Order = 9, TypeName = "INT")]
        public int Numero4 { get; set;  }

        [Column(Order = 10, TypeName = "INT")]
        public int Numero5 { get; set; }

        [Column(Order = 11, TypeName = "INT")]
        public int Numero6 { get; set; }

        [Column(Order = 12, TypeName = "INT")]
        public int Numero7 { get; set; }

        [Column(Order = 13, TypeName = "INT")]
        public int Numero8 { get; set; }

        [Column(Order = 14, TypeName = "INT")]
        public int Numero9 { get; set; }

        [Column(Order = 15, TypeName = "INT")]
        public int Numero10 { get; set; }

        [Column(Order = 16, TypeName = "INT")]
        public int Numero11 { get; set; }

        [Column(Order = 17, TypeName = "INT")]
        public int Numero12 { get; set; }

        [Column(Order = 18, TypeName = "INT")]
        public int Numero13 { get; set; }

        [Column(Order = 19, TypeName = "INT")]
        public int Numero14 { get; set; }

        [Column(Order = 20, TypeName = "INT")]
        public int Numero15 { get; set; }

        [Column(Order = 21, TypeName = "INT")]
        public int Numero16 { get; set; }

        [Column(Order = 22, TypeName = "INT")]
        public int Numero17 { get; set; }

        [Column(Order = 23, TypeName = "INT")]
        public int Numero18 { get; set; }

        [Column(Order = 24, TypeName = "INT")]
        public int Numero19 { get; set; }

        [Column(Order = 25, TypeName = "INT")]
        public int Numero20 { get; set; }

        [Column(Order = 26, TypeName = "INT")]
        public int Numero21 { get; set; }

        [Column(Order = 27, TypeName = "INT")]
        public int Numero22 { get; set; }

        [Column(Order = 28, TypeName = "INT")]
        public int Numero23 { get; set; }

        [Column(Order = 30, TypeName = "INT")]
        public int Numero24 { get; set; }

        [Column(Order = 31, TypeName = "INT")]
        public int Numero25 { get; set; }

        [Column(Order = 32, TypeName = "INT")]
        public int Numero26 { get; set; }

        [Column(Order = 33, TypeName = "INT")]
        public int Numero27 { get; set; }

        [Column(Order = 34, TypeName = "INT")]
        public int Numero28 { get; set; }

        [Column(Order = 35, TypeName = "INT")]
        public int Numero29 { get; set; }

        [Column(Order = 36, TypeName = "INT")]
        public int Numero30 { get; set; }

        [Column(Order = 37, TypeName = "INT")]
        public int Numero31 { get; set; }

        [Column(Order = 38, TypeName = "INT")]
        public int Numero32 { get; set; }

        [Column(Order = 39, TypeName = "INT")]
        public int Numero33 { get; set; }

        [Column(Order = 40, TypeName = "INT")]
        public int Numero34 { get; set; }

        [Column(Order = 41, TypeName = "INT")]
        public int Numero35 { get; set; }

        [Column(Order = 42, TypeName = "INT")]
        public int Numero36 { get; set; }

        [Column(Order = 43, TypeName = "INT")]
        public int Numero37 { get; set; }

        [Column(Order = 44, TypeName = "INT")]
        public int Numero38 { get; set; }

        [Column(Order = 45, TypeName = "INT")]
        public int Numero39 { get; set; }

        [Column(Order = 46, TypeName = "INT")]
        public int Numero40 { get; set; }

        [Column(Order = 47, TypeName = "INT")]
        public int Numero41 { get; set; }

        [Column(Order = 48, TypeName = "INT")]
        public int Numero42 { get; set; }

        [Column(Order = 49, TypeName = "INT")]
        public int Numero43 { get; set; }

        [Column(Order = 50, TypeName = "INT")]
        public int Numero44 { get; set; }

        [Column(Order = 51, TypeName = "INT")]
        public int Numero45 { get; set; }

        [Column(Order = 52, TypeName = "INT")]
        public int Numero46 { get; set; }

        [Column(Order = 53, TypeName = "INT")]
        public int Numero47 { get; set; }

        [Column(Order = 54, TypeName = "INT")]
        public int Numero48 { get; set; }
    }
}
