using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class CredencialesDTO
    {
        public int IdEmpresa { get; set; }
        public string UserMail { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
    }
}
