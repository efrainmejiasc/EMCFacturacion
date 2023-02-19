using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class TrazabilidadEnvioDTO
    {
        public int Id { get; set; }

        public Guid Identificador { get; set; }

        public string Nombre { get; set; }


        public string Dni { get; set; }


        public string Direccion { get; set; }


        public string Telefono { get; set; }


        public string Email { get; set; }


        public bool Activo { get; set; }


        public DateTime FechaEnvio { get; set; }


        public DateTime FechaLlegada { get; set; }


        public DateTime FechaReclamo { get; set; }


        public int IdEmpresa { get; set; }

        public string Observacion { get; set; }
    }
}
