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
    public class FacturaCompraDetalleService : IFacturaCompraDetalleService
    {
        private readonly IMapper mapper;
        private readonly IFacturaCompraDetalleRepository facturaCompraDetalleRepository;

        public FacturaCompraDetalleService(IFacturaCompraDetalleRepository _facturaCompraDetalleRepository,IMapper _mapper)
        {
            this.mapper = _mapper;
            this.facturaCompraDetalleRepository = _facturaCompraDetalleRepository;
        }


        public GenericResponse AddFacturaCompraDetalle(List<FacturaCompraDetalleDTO> facturaDetalleDTO)
        {
            var detalleFactura = this.mapper.Map<List<FacturaCompraDetalle>>(facturaDetalleDTO);

            detalleFactura = this.facturaCompraDetalleRepository.AddFacturaCompraDetalle(detalleFactura);

            if (detalleFactura.Count > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public List<FacturaCompraDetalleDTO> GetFacturaCompraDetalle(int idEmpresa, string numeroFactura)
        {
            var detalle = this.facturaCompraDetalleRepository.GetDetalleFactura(idEmpresa, numeroFactura);

            var detalleDTO = new List<FacturaCompraDetalleDTO>();
            detalleDTO = this.mapper.Map<List<FacturaCompraDetalleDTO>>(detalle);

            return detalleDTO;
        }
    }
}
