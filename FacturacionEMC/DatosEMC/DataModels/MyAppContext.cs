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
        public virtual DbSet<TipoFactura> TipoFactura { get; set; }
        public virtual DbSet<UnidadMedida> UnidadMedida { get; set; }
        public virtual DbSet<TipoInventario> TipoInventario { get; set; }
        public virtual DbSet<InicioFacturacion> InicioFacturacion { get; set; }



        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Proveedor> Proveedor { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }


        public virtual DbSet<StockTotal> StockTotal { get; set; }
        public virtual DbSet<StockTransito> StockTransito { get; set; }
        public virtual DbSet<StockBodega> StockBodega { get; set; }


        public virtual DbSet<FacturaCompra> FacturaCompra { get; set; }
        public virtual DbSet<FacturaCompraDetalle> FacturaCompraDetalle { get; set; }
        public virtual DbSet<FacturaVenta> FacturaVenta { get; set; }
        public virtual DbSet<FacturaVentaDetalle> FacturaVentaDetalle { get; set; }


        public virtual DbSet<ProductoImgInfo> ProductoImgInfo { get; set; }
        public virtual DbSet<ProductoImg> ProductoImg { get; set; }


        public virtual DbSet<TrazabilidadEnvio> TrazabilidadEnvio { get; set; }

        public virtual DbSet<VentaNumero> VentaNumero { get; set; }
        public virtual DbSet<Loterias> Loterias{ get; set; }
        public virtual DbSet<VentaNumeroRango> VentaNumeroRango { get; set; }
        public virtual DbSet<ListaBingo> ListaBingo{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(EngineData.ConnectionDb);
            }

        }
    }
}
