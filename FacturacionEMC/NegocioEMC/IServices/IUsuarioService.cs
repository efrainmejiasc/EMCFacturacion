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
        GenericResponse AddUsuario(UsuarioDTO model);
        List<UsuarioDTO> GetUsuarios(int idEmpresa);
        GenericResponse DeleteUsuario(int idEmpresa, int idUsuario);
        GenericResponse UpdateEstatusUsuario(int idEmpresa, int idUsuario, bool activo);
        Task<UsuarioDTO> GetUserDataAsync(int idEmpresa, string userMail, string password);
    }
}
