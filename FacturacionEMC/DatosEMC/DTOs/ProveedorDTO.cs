using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class ProveedorDTO
    {
        public int Id { get; set; }
        public string NombreProveedor { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public int IdEmpresa {get;set;}
    }
}
