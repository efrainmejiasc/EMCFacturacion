using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IInicioFacturacionRepository
    {
        InicioFacturacion GetInicioFacturacion(int idEmpresa);
        string GetNumeroFacturaInicio(int idEmpresa);
        InicioFacturacion ReInicioFacturacion(int idEmpresa);
        InicioFacturacion SetInicioFacturacion(InicioFacturacion model);
    }
}
