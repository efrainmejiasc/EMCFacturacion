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

        public Usuario AddUsuario(Usuario model)
        {
            this.db.Usuario.Add(model);
            this.db.SaveChanges();

            return model;
        }

        public Usuario UpdateEstatusUsuario(int idEmpresa, int idUsuario, bool activo)
        {
            var usuario =this.db.Usuario.Where(x => x.IdEmpresa == idEmpresa && x.Id == idUsuario).FirstOrDefault();
            if (usuario != null)
            {
                usuario.Activo = activo;
                this.db.SaveChanges();
            }

            return usuario;
        }

        public List<Usuario> GetUsuarios(int idEmpresa)
        {
            return db.Usuario.Where(x =>  x.IdEmpresa == idEmpresa ).ToList();
        }

        public async Task<Usuario> GetUserDataAsync (int idEmpresa, string userMail, string password)
        {
            return await db.Usuario.Where(x => (x.Password == password || x.Password2 == password ) && (x.Email  == userMail || x.Username == userMail)
                                            && x.IdEmpresa == idEmpresa && x.Activo == true).FirstOrDefaultAsync();
        }

        public Usuario DeleteUsuario(int idEmpresa, int idUsuario)
        {
            var usuario = this.db.Usuario.Where(x => x.IdEmpresa == idEmpresa && x.Id == idUsuario).FirstOrDefault();
            if (usuario != null)
            {
                this.db.Usuario.Remove(usuario);
                this.db.SaveChanges();
            }

            return usuario;
        }
    }
}
