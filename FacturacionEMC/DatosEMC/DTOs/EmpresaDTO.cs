using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public Guid Identificador { get; set; }
        public string NombreEmpresa { get; set; }
        public string Rfc { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
    }
}
