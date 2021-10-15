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
    public class FacturaCompraService : IFacturaCompraService
    {
        private readonly IMapper mapper;
        private readonly IFacturaCompraRepository facturaCompraRepository;

        public FacturaCompraService(IFacturaCompraRepository _facturaCompraRepository, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.facturaCompraRepository = _facturaCompraRepository;
        }

        public  GenericResponse AddFacturaCompra(FacturaCompraDTO facturaDTO)
        {
            var factura = this.mapper.Map<FacturaCompra>(facturaDTO);

            factura = this.facturaCompraRepository.AddFacturaCompra(factura);

            if (factura!= null)
                return  EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }
    }
}
