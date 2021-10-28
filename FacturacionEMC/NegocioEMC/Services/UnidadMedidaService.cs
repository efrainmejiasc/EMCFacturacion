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
    public class UnidadMedidaService: IUnidadMedidaService
    {
        private readonly IUnidadMedidaRepository unidadMedidaRepository;
        private readonly IMapper mapper;
        public UnidadMedidaService(IUnidadMedidaRepository _unidadMedidaRepository, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.unidadMedidaRepository = _unidadMedidaRepository;
        }

        public List<UnidadMedidaDTO> GetUnidadMedidas(int id , string sistema)
        {
            var unidades =  this.unidadMedidaRepository.GetUnidadMedida(id, sistema);
            var unidadesDto = mapper.Map<List<UnidadMedida>, List<UnidadMedidaDTO>>(unidades);

            return unidadesDto;
        }
    }
}
