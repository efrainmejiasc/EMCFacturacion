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
    public class MetodoPagoService : IMetodoPagoService
    {
        private readonly IMetodoPagoRepository metodoPagoRepository;
        private readonly IMapper mapper;
        public MetodoPagoService(IMetodoPagoRepository _metodoPagoRepository, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.metodoPagoRepository = _metodoPagoRepository;
        }

        public List<MetodoPagoDTO> GetMetodoPago(string idioma)
        {
            var metodos = this.metodoPagoRepository.GetMetodoPago(idioma);
            var metodosDto = mapper.Map<List<MetodoPago>, List<MetodoPagoDTO>>(metodos);

            return metodosDto;
        }
    }
}
