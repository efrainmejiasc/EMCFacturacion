using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using DatosEMC.Repositories;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public class UsuarioService: IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public UsuarioService(IUsuarioRepository _usuarioRepository, IMapper _mapper)
        {
            this.usuarioRepository = _usuarioRepository;
            this.mapper = _mapper;
        }

        public GenericResponse AddUsuario(UsuarioDTO model)
        {
            var usuario = new Usuario();
            usuario = this.mapper.Map<Usuario>(model);

            usuario = this.usuarioRepository.AddUsuario(usuario);

            if (usuario != null)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public async Task<UsuarioDTO> GetUserDataAsync(int idEmpresa, string userMail, string password)
        {
            var usuario = new Usuario();
            usuario = await this.usuarioRepository.GetUserDataAsync(idEmpresa, userMail, password);
            var userData = mapper.Map<Usuario, UsuarioDTO>(usuario);

            return userData;
        }

        public  List<UsuarioDTO> GetUsuarios(int idEmpresa)
        {
            var usuario = new List<Usuario>();
            usuario = this.usuarioRepository.GetUsuarios(idEmpresa);
            var userData = mapper.Map<List<Usuario>, List<UsuarioDTO>>(usuario);

            return userData;
        }

        public GenericResponse UpdateEstatusUsuario (int idEmpresa, int idUsuario , bool activo)
        {

            var usuario = this.usuarioRepository.UpdateEstatusUsuario(idEmpresa, idUsuario, activo);

            if (usuario != null)
                return EngineService.SetGenericResponse(true, "La información ha sido actualizada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo actualizar la información");
        }


        public GenericResponse DeleteUsuario(int idEmpresa, int idUsuario)
        {

            var usuario = this.usuarioRepository.DeleteUsuario(idEmpresa, idUsuario);

            if (usuario != null)
                return EngineService.SetGenericResponse(true, "Usuario eliminado");

            else
                return EngineService.SetGenericResponse(false, "No se pudo eliminar el usuario");
        }
    }
}
