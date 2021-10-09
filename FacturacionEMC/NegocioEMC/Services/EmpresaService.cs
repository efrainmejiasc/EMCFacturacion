using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public class EmpresaService: IEmpresaService
    {
        private readonly IEmpresaRepository EmpresaRepository;
        private readonly IMapper mapper;

        public EmpresaService(IEmpresaRepository _EmpresaRepository, IMapper _mapper)
        {
            this.EmpresaRepository = _EmpresaRepository;
            this.mapper = _mapper;
        }

        public async Task<List<EmpresaDTO>> GetEmpresaDataAsync()
        {
            var empresas = new List<Empresa>();
            empresas = await this.EmpresaRepository.GetEmpresasAsync();
            var empresasDto = mapper.Map<List<Empresa>, List<EmpresaDTO>>(empresas);

            return empresasDto;
        }
    }
}
