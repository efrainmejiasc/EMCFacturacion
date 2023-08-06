using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IVentaNumeroRangoService
    {
        VentaNumeroRango AddSorteo(int idEmpresa);
        VentaNumeroRango ValidarRango(int idEmpresa);
        VentaNumeroRango GetRangoSorteoMasActualizado(int idEmpresa);
    }
}
