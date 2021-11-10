using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IStockTransitoService
    {
        GenericResponse AddStockTransito(List<StockTransitoDTO> model);
        List<StockTransitoDTO> GetAsignacionesVendedor(int idEmpresa, int idUsuario, bool activo);
    }
}
