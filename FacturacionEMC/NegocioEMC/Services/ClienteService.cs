using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public class ClienteService: IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository ClienteRepository;

        public ClienteService(IClienteRepository _ClienteRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this.ClienteRepository = _ClienteRepository;
        }

        public GenericResponse AddCliente(ClienteDTO ClienteDTO)
        {
            var cliente = new Cliente();
            cliente = this._mapper.Map<Cliente>(ClienteDTO);
            cliente.Identificador = EngineTool.CreateUniqueidentifier();

            cliente = this.ClienteRepository.AddClienteAsync(cliente);

            if (cliente != null)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public List<ClienteDTO> GetClientes(int idEmpresa)
        {
            var Clientees = this.ClienteRepository.GetClientes(idEmpresa);

            var ClienteesDTO = new List<ClienteDTO>();
            ClienteesDTO = this._mapper.Map<List<ClienteDTO>>(Clientees);

            return ClienteesDTO;
        }
    }
}
