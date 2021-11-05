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
        public string Nombre{ get; set; }
        public string Apellido { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int IdRol { get; set; }
        public int IdEmpresa { get; set; }
        public string Token { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public bool InicioFacturacion { get; set; }
        public string InicioFacturacionNumero{ get; set; }

    }
}
