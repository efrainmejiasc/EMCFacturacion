using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class FacturaCompraDetalleRepository: IFacturaCompraDetalleRepository
    {
        private readonly MyAppContext db;
        public FacturaCompraDetalleRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public List<FacturaCompraDetalle> AddFacturaCompraDetalle(List<FacturaCompraDetalle> facturaDetalle)
        {
            this.db.FacturaCompraDetalle.AddRange(facturaDetalle);
            this.db.SaveChangesAsync();

            return facturaDetalle;
        }

        public FacturaCompraDetalle GetFacturaCompraDetalle(int idEmpresa, string numeroFactura)
        {
            return this.db.FacturaCompraDetalle.Where(x => x.IdEmpresa == idEmpresa && x.NumeroFactura == numeroFactura).FirstOrDefault();
        }

        public List<FacturaCompraDetalleDTO> GetDetalleFactura (int idEmpresa, string numeroFactura)
        {
            var lst = new List<FacturaCompraDetalleDTO>();
            lst = (from fd in db.FacturaCompraDetalle join u in db.UnidadMedida on fd.Unidad equals u.Id
                   where fd.IdEmpresa == idEmpresa && fd.NumeroFactura == numeroFactura
                   select new { fd, u}).AsEnumerable()
                    .Select(x => new FacturaCompraDetalleDTO
                    {
                        Linea = x.fd.Linea,
                        NombreArticulo = x.fd.NombreArticulo,
                        UnidadMedida = x.u.Unidad,
                        Cantidad = x.fd.Cantidad,
                        PrecioUnitario = Math.Round(x.fd.Subtotal/ x.fd.Cantidad,2) ,
                        Subtotal = x.fd.Subtotal,
                        Descuento = x.fd.Descuento,
                        Impuesto = x.fd.Impuesto,
                        Total = x.fd.Total

                    }).OrderBy(x => x.Linea).ToList();

            return lst;
        }
    }
}
