using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class InicioFacturacionDTO
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public bool Activo { get; set; }
        public string NumeroFactura { get; set; }
    }
}
