using DatosEMC.DataModels;
using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IVentaNumeroService
    {
        List<Loterias> GetLoterias();
        GenericResponse DeleteVentaNumeroById(int id);
        List<VentaNumeroDTO> GetTicket(string ticket);
        GenericResponse DeleteVentaNumeroTicket(string ticket);
        GenericResponse AddVentaNumeroAsync(VentaNumeroDTO model);
        GenericResponse UpdateVentaNumeroAsync(VentaNumeroDTO model);
        GenericResponse AddVentaNumeroAsync(List<VentaNumeroDTO> lst);
        GenericResponse UpdateVentaNumeroAsync(List<VentaNumeroDTO> model);
        List<VentaNumeroDTO> GetListaVenta(DateTime fecha, string loteria);
        VentaNumeroDTO GetPremio(int idEmpresa, int numero, string loteria);
        List<VentaNumeroDTO> GetPremiados(int idEmpresa, int numero, DateTime fecha);

    }
}
