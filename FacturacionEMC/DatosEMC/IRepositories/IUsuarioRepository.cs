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
        public Task<Usuario> GetUserDataAsync(int idEmpresa, string userMail, string password);
    }
}
