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
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
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
