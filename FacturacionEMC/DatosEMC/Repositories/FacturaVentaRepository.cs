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
    public class FacturaVentaRepository: IFacturaVentaRepository
    {
        private readonly MyAppContext db;
        public FacturaVentaRepository(MyAppContext _db)
        {
            this.db = _db;
        }

        public FacturaVenta AddFacturaVenta(FacturaVenta factura)
        {
            db.FacturaVenta.Add(factura);
            db.SaveChangesAsync();

            return factura;
        }
        public List<FacturaVentaDTO> GetFacturasVentas(int idEmpresa)
        {
            var facturas = (from f in db.FacturaVenta
                            join p in db.Cliente on f.IdCliente equals p.Id
                            join m in db.MetodoPago on f.IdMetodoPago equals m.Id
                            where f.IdEmpresa == idEmpresa
                            select new FacturaVentaDTO
                            {
                                NumeroFactura = f.NumeroFactura,
                                Fecha = f.Fecha.Date,
                                NombreCliente = f.NombreCliente,
                                Rfc = p.Rfc,
                                MetodoPago = m.Metodo,
                                Subtotal = f.Subtotal,
                                Descuento = f.Descuento,
                                Impuesto = f.Impuesto,
                                Total = f.Total

                            }).OrderByDescending(f => f.Fecha).Take(50).ToList();

            return facturas;
        }

        public List<FacturaVentaDTO> GetFacturasVentasFechas(int idEmpresa, DateTime fInicio, DateTime fFinal)
        {
            var facturas = (from f in db.FacturaVenta
                            join p in db.Cliente on f.IdCliente equals p.Id
                            join m in db.MetodoPago on f.IdMetodoPago equals m.Id
                            where f.IdEmpresa == idEmpresa && f.Fecha >= fInicio && f.Fecha <= fFinal
                            select new FacturaVentaDTO
                            {
                                NumeroFactura = f.NumeroFactura,
                                Fecha = f.Fecha.Date,
                                NombreCliente = f.NombreCliente,
                                Rfc = p.Rfc,
                                MetodoPago = m.Metodo,
                                Subtotal = f.Subtotal,
                                Descuento = f.Descuento,
                                Impuesto = f.Impuesto,
                                Total = f.Total

                            }).OrderByDescending(f => f.Fecha).ToList();

            return facturas;
        }
    }
}
