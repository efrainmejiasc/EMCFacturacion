using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IUsuarioRepository
    {
        Usuario AddUsuario(Usuario model);
        List<Usuario> GetUsuarios(int idEmpresa);
        Usuario DeleteUsuario(int idEmpresa, int idUsuario);
        Usuario UpdateEstatusUsuario(int idEmpresa, int idUsuario, bool activo);
        public Task<Usuario> GetUserDataAsync(int idEmpresa, string userMail, string password);
    }
}
