using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class StockTotalDTO
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string NumeroFactura { get; set; }
        public int Linea { get; set; }
       
       
  
        public DateTime Fecha { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Activo { get; set; }
        public int IdUsuario { get; set; }


        public string Identificador { get; set; }
        public int IdArticulo { get; set; }
        public string NombreProducto{ get; set; }
        public decimal Cantidad { get; set; }
        public string Unidad { get; set; }
        public int TipoFactura { get; set; }
    }
}
