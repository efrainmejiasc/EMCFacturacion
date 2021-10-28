using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IUnidadMedidaService
    {
        List<UnidadMedidaDTO> GetUnidadMedidas(int id, string sistema);
    }
}
