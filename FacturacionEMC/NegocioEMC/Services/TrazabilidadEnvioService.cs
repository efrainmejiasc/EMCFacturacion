using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.IRepositories;
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
        private readonly ITrazabilidadEnvioRepository trazabilidadEnvioRepository;

        public TrazabilidadEnvioService(ITrazabilidadEnvioRepository _trazabilidadEnvioRepository)
        {
            this.trazabilidadEnvioRepository = _trazabilidadEnvioRepository;
        }


        public bool AddTrazabilidadEnvio(TrazabilidadEnvio x)
        {
            var result = false;
            x = this.trazabilidadEnvioRepository.AddTrazabilidadEnvioAsync(x);
            if (x.Id > 0)
                result = true;

            return result;
        }

        public TrazabilidadEnvio GetTrazabilidadEnvio(int idEmpresa, string dni)
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
