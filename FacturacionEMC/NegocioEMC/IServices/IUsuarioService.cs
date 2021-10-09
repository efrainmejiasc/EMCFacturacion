using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> GetUserDataAsync(int idEmpresa, string userMail, string password);
    }
}
