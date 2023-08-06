using DatosEMC.DataModels;
using DatosEMC.IRepositories;
using DatosEMC.Repositories;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public class VentaNumeroRangoService: IVentaNumeroRangoService
    {
        private readonly IVentaNumeroRangoRepository ventaNumeroRangoRepository;
        public VentaNumeroRangoService(IVentaNumeroRangoRepository _ventaNumeroRangoRepository)
        {
            this.ventaNumeroRangoRepository = _ventaNumeroRangoRepository;
        }

        public VentaNumeroRango GetRangoSorteoMasActualizado(int idEmpresa)
        {
            return  this.ventaNumeroRangoRepository.GetRangoSorteoMasActualizado(idEmpresa);
        }

        public VentaNumeroRango AddSorteo(int idEmpresa)
        {
            var ventaNumeroRango = new VentaNumeroRango()
            {
                FechaInicial = DateTime.Now,
                FechaFinal = DateTime.Now.AddDays(56),
                IdEmpresa= idEmpresa
            };

            return this.ventaNumeroRangoRepository.AddSorteo(ventaNumeroRango);
        }

        public VentaNumeroRango  ValidarRango(int idEmpresa)
        {
            var rangoSorteo = GetRangoSorteoMasActualizado(idEmpresa);
            if (rangoSorteo == null)
                rangoSorteo = AddSorteo(idEmpresa);
            else if (rangoSorteo != null)
            {
                if (DateTime.Now.Date > rangoSorteo.FechaFinal)
                    rangoSorteo = AddSorteo(idEmpresa);
            }

            return rangoSorteo;
        }
    }
}
