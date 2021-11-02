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
    public class FacturaVentaDetalleService: IFacturaVentaDetalleService
    {
        private readonly IMapper mapper;
        private readonly IFacturaVentaDetalleRepository facturaVentaDetalleRepository;

        public FacturaVentaDetalleService(IFacturaVentaDetalleRepository _facturaVentaDetalleRepository, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.facturaVentaDetalleRepository = _facturaVentaDetalleRepository;
        }


        public GenericResponse AddFacturaVentaDetalle(List<FacturaVentaDetalleDTO> facturaDetalleDTO)
        {
            var detalleFactura = this.mapper.Map<List<FacturaVentaDetalle>>(facturaDetalleDTO);

            detalleFactura = this.facturaVentaDetalleRepository.AddFacturaVentaDetalle(detalleFactura);

            if (detalleFactura.Count > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public List<FacturaVentaDetalleDTO> GetFacturaVentaDetalle(int idEmpresa, string numeroFactura)
        {
            var detalle = this.facturaVentaDetalleRepository.GetDetalleFactura(idEmpresa, numeroFactura);

            var detalleDTO = new List<FacturaVentaDetalleDTO>();
            detalleDTO = this.mapper.Map<List<FacturaVentaDetalleDTO>>(detalle);

            return detalleDTO;
        }
    }
}
