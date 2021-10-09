using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly MyAppContext db;
        public UsuarioRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public async Task<Usuario> GetUserDataAsync (int idEmpresa, string userMail, string password)
        {
            return await db.Usuario.Where(x => x.IdEmpresa == idEmpresa 
                                    && x.Username == userMail || x.Email == userMail
                                    && x.Password == password || x.Password2 == password 
                                    && x.Activo == true).FirstOrDefaultAsync();
        }
    }
}
