using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set;}
        public string Username { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; }
    }
}
