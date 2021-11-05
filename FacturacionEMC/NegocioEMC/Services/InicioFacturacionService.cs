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
    public class InicioFacturacionService: IInicioFacturacionService
    {
        private readonly IMapper mapper;
        private readonly IInicioFacturacionRepository inicioFacturacionRepository;

        public InicioFacturacionService(IMapper _mapper ,IInicioFacturacionRepository _inicioFacturacionRepository)
        {
            this.mapper = _mapper;
            this.inicioFacturacionRepository = _inicioFacturacionRepository;
        }

        public InicioFacturacion  SetInicioFacturacion (InicioFacturacionDTO model)
        {
            var inicio = this.mapper.Map<InicioFacturacion>(model);

            inicio = this.inicioFacturacionRepository.SetInicioFacturacion(inicio);

            return inicio;
        }

        public bool GetInicioFacturacion (int idEmpresa)
        {
            var inicio = this.inicioFacturacionRepository.GetInicioFacturacion(idEmpresa);

            return inicio == null ? false : inicio.Activo;
        }

        public  InicioFacturacion GetInicioFacturacionCtrl(int idEmpresa)
        {
           return this.inicioFacturacionRepository.GetInicioFacturacion(idEmpresa);
        }

        public string GetNumeroFacturaInicio(int idEmpresa)
        {
            return this.inicioFacturacionRepository.GetNumeroFacturaInicio(idEmpresa);
        }

        public InicioFacturacion ReInicioFacturacion(int idEmpresa)
        {

            return this.inicioFacturacionRepository.ReInicioFacturacion(idEmpresa);
        }

    }
}
