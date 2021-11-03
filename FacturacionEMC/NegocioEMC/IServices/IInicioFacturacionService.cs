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
        GenericResponse ReInicioFacturacion(int idEmpresa);
        GenericResponse SetInicioFacturacion(InicioFacturacionDTO model);
        
    }
}
