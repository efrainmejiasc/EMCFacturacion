using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IVentaNumeroRepository
    {
        List<Loterias> GetLoterias();
        List<VentaNumero> GetTicket(string ticket);
        VentaNumero AddVentaNumeroAsync(VentaNumero x);
        VentaNumero UpdateVentaNumeroAsync(VentaNumero x);
        List<VentaNumero> UpdateVentaNumeroAsync(List<VentaNumero> x);
        List<VentaNumero> AddVentaNumeroAsync(List<VentaNumero> x);
        List<VentaNumero> GetListaVenta(DateTime fecha, string loteria);
        VentaNumero GetPremio(int idEmpresa, int numero, string loteria);
        List<VentaNumero> GetPremiados(int idEmpresa, int numero, DateTime fecha);
    }
}
