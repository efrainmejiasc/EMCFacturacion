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
    public class FacturaVentaService: IFacturaVentaService
    {
        private readonly IMapper mapper;
        private readonly IFacturaVentaRepository facturaVentaRepository;

        public FacturaVentaService(IFacturaVentaRepository _facturaVentaRepository, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.facturaVentaRepository = _facturaVentaRepository;
        }

        public GenericResponse AddFacturaVenta(FacturaVentaDTO facturaDTO)
        {
            var factura = this.mapper.Map<FacturaVenta>(facturaDTO);

            factura = this.facturaVentaRepository.AddFacturaVenta(factura);

            if (factura != null)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public List<FacturaVentaDTO> GetFacturasVentas(int idEmpresa)
        {
            var facturas = this.facturaVentaRepository.GetFacturasVentas(idEmpresa);

            return facturas;
        }

        public List<FacturaVentaDTO> GetFacturasVentasFechas(int idEmpresa, DateTime fechaInicial, DateTime fechaFinal)
        {
            var facturas = this.facturaVentaRepository.GetFacturasVentasFechas(idEmpresa, fechaInicial, fechaFinal);

            return facturas;
        }
    }
}
