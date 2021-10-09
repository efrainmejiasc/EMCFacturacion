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

        public async Task<UsuarioDTO> GetUserDataAsync(int idEmpresa, string userMail, string password)
        {
            password = EngineTool.DecodeBase64(password);

            var usuario = new Usuario();
            usuario = await this.usuarioRepository.GetUserDataAsync(idEmpresa, userMail, password);
            var userData = mapper.Map<Usuario, UsuarioDTO>(usuario);

            return userData;
        }
    }
}
