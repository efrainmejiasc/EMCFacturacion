using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class StockBodegaDTO
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public decimal Cantidad { get; set; }
        public int IdArticulo{ get; set; }
        public string NombreArticulo { get; set; }
        public int Unidad { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Activo { get; set; }
        public int IdUsuario { get; set; }
    }
}
