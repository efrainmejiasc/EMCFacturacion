using DatosEMC.Clases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DataModels
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }
        public virtual DbSet<TipoInventario> TipoInventario { get; set; }


        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }


        public virtual DbSet<StockTotal> StockTotal { get; set; }
        public virtual DbSet<StockTransito> StockTransito { get; set; }
        public virtual DbSet<StockBodega> StockBodega { get; set; }


        public virtual DbSet<FacturaCompra> FacturaCompra { get; set; }
        public virtual DbSet<FacturaCompraDetalle> FacturaCompraDetalle { get; set; }
        public virtual DbSet<FacturaVenta> FacturaVenta { get; set; }
        public virtual DbSet<FacturaVentaDetalle> FacturaVentaDetalle { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(EngineData.ConnectionDb);
            }

        }
    }
}
