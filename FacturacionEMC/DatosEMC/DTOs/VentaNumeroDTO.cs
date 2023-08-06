using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class VentaNumeroDTO
    {
        public int Id { get; set; }
        public Guid Identificador { get; set; }
        public string Vendedor { get; set; }
        public int Numero { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Loteria { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaVenta { get; set; }
        public DateTime FechaSorteo { get; set; }
        public int IdEmpresa { get; set; }
        public decimal Monto { get; set; }
        public int Premiado { get; set; }
        public decimal TotalVendido { get; set; }
        public string Ticket { get; set; }
        public string Nombre { get; set; }
        public int IdVentaNumeroRango { get; set; }
    }
}
