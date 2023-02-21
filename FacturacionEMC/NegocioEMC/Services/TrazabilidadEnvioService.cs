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
    public class TrazabilidadEnvioService: ITrazabilidadEnvioService
    {
        private readonly IMapper mapper;
        private readonly ITrazabilidadEnvioRepository trazabilidadEnvioRepository;

        public TrazabilidadEnvioService(ITrazabilidadEnvioRepository _trazabilidadEnvioRepository, IMapper mapper)
        {
            this.trazabilidadEnvioRepository = _trazabilidadEnvioRepository;
            this.mapper = mapper;
        }


        public GenericResponse AddTrazabilidadEnvio(TrazabilidadEnvioDTO model)
        {
            var x = this.mapper.Map<TrazabilidadEnvio>(model);
            x.Identificador = EngineTool.CreateUniqueidentifier();
            x.FechaEnvio = DateTime.Now;
            x.FechaReclamo = DateTime.Now;
            x.Activo = true;
            x = this.trazabilidadEnvioRepository.AddTrazabilidadEnvioAsync(x);

            if (x.Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");

        }

        public List<TrazabilidadEnvio> GetTrazabilidadEnvio(int idEmpresa, string dni)
        {
            return this.trazabilidadEnvioRepository.GetTrazabilidadEnvio(idEmpresa, dni);
        }

        public TrazabilidadEnvio GetTrazabilidadEnvio(int idEmpresa, Guid identificador)
        {
            return this.trazabilidadEnvioRepository.GetTrazabilidadEnvio(idEmpresa, identificador);
        }

        public List<TrazabilidadEnvio> GetTrazabilidadEnvio(int idEmpresa, DateTime fechaInicio, DateTime fechaFinal)
        {
            return this.trazabilidadEnvioRepository.GetTrazabilidadEnvio(idEmpresa, fechaInicio, fechaFinal);
        }

    }
}
