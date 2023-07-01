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
        NumeroTicketDTO GetNumeroTicket(int id);
        GenericResponse DeleteVentaNumeroById(int id);
        List<VentaNumeroDTO> GetTicket(string ticket,int id);
        GenericResponse DeleteVentaNumeroTicket(string ticket, int id);
        GenericResponse AddVentaNumeroAsync(VentaNumeroDTO model);
        GenericResponse UpdateVentaNumeroAsync(VentaNumeroDTO model);
        GenericResponse AddVentaNumeroAsync(List<VentaNumeroDTO> lst);
        GenericResponse UpdateVentaNumeroAsync(List<VentaNumeroDTO> model);
        List<VentaNumeroDTO> GetListaVenta(DateTime fecha, string loteria, int id);
        VentaNumeroDTO GetPremio(int idEmpresa, int numero, string loteria, string ticket);
        List<VentaNumeroDTO> GetPremiados(int idEmpresa, int numero, DateTime fecha,string loteria);

    }
}
