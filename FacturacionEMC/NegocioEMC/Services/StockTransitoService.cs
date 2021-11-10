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
    public class StockTransitoService : IStockTransitoService
    {
        private readonly IMapper mapper;
        private readonly IStockTransitoRepository stockTransitoRepository;

        public StockTransitoService(IStockTransitoRepository _stockTransitoRepository, IMapper _mapper)
        {
            this.mapper = _mapper;
            this.stockTransitoRepository = _stockTransitoRepository;
        }

        public GenericResponse AddStockTransito(List<StockTransitoDTO> model)
        {
            var lstStockTransito = this.mapper.Map<List<StockTransito>>(model);

            lstStockTransito = this.stockTransitoRepository.AddStockTransito(lstStockTransito);

            if (lstStockTransito.Count > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public List<StockTransitoDTO> GetAsignacionesVendedor(int idEmpresa, int idUsuario, bool activo)
        {
            var lstTransito = this.stockTransitoRepository.GetAsignacionesVendedor(idEmpresa, idUsuario, activo);

            var stockTransitoDTO = new List<StockTransitoDTO>();
            stockTransitoDTO = this.mapper.Map<List<StockTransitoDTO>>(lstTransito);

            return stockTransitoDTO;
        }

    }
}
