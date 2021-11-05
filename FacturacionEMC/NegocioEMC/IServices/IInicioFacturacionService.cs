using DatosEMC.DataModels;
using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IInicioFacturacionService
    {
        bool GetInicioFacturacion(int idEmpresa);
        string GetNumeroFacturaInicio(int idEmpresa);
        InicioFacturacion ReInicioFacturacion(int idEmpresa);
        InicioFacturacion GetInicioFacturacionCtrl(int idEmpresa);
        InicioFacturacion SetInicioFacturacion(InicioFacturacionDTO model);
    }
}
