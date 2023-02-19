using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface ITrazabilidadEnvioService
    {
        bool AddTrazabilidadEnvio(TrazabilidadEnvio x);


        TrazabilidadEnvio GetTrazabilidadEnvio(int idEmpresa, string dni);


        TrazabilidadEnvio GetTrazabilidadEnvio(int idEmpresa, Guid identificador);

        List<TrazabilidadEnvio> GetTrazabilidadEnvio(int idEmpresa, DateTime fechaInicio, DateTime fechaFinal);


    }
}
