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
    public class FacturaCompraRepository:IFacturaCompraRepository
    {
        private readonly MyAppContext db;
        public FacturaCompraRepository(MyAppContext _db)
        {
            this.db =_db;
        }

        public FacturaCompra AddFacturaCompra (FacturaCompra factura)
        {
            db.FacturaCompra.Add(factura);
            db.SaveChangesAsync();

            return factura;
        }

        public List<FacturaCompraDTO> GetFacturasCompras(int idEmpresa)
        {
            var facturas = (from f in db.FacturaCompra
                            join p in db.Proveedor on f.IdProveedor equals p.Id
                            join m in db.MetodoPago on f.IdMetodoPago equals m.Id
                            where f.IdEmpresa == idEmpresa
                            select new FacturaCompraDTO 
                            { 
                                NumeroFactura = f.NumeroFactura,
                                Fecha = f.Fecha,
                                NombreProveedor = f.NombreProveedor,
                                Rfc = p.Rfc,
                                MetodoPago = m.Metodo,
                                Subtotal = f.Subtotal,
                                Descuento = f.Descuento,
                                Impuesto = f.Impuesto,
                                Total = f.Total

                            }).OrderByDescending(f => f.Fecha).Take(50).ToList();

            return facturas;
        }

        public List<FacturaCompraDTO> GetFacturasComprasFechas(int idEmpresa , DateTime fInicio, DateTime fFinal)
        {
            var facturas = (from f in db.FacturaCompra
                            join p in db.Proveedor on f.IdProveedor equals p.Id
                            join m in db.MetodoPago on f.IdMetodoPago equals m.Id
                            where f.IdEmpresa == idEmpresa && f.Fecha >= fInicio && f.Fecha <= fFinal
                            select new FacturaCompraDTO
                            {
                                NumeroFactura = f.NumeroFactura,
                                Fecha = f.Fecha,
                                NombreProveedor = f.NombreProveedor,
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
