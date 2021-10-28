﻿// <auto-generated />
using System;
using DatosEMC.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatosEMC.Migrations
{
    [DbContext(typeof(MyAppContext))]
    partial class MyAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatosEMC.DataModels.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<string>("Direccion")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("INT");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Rfc")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("DatosEMC.DataModels.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<string>("Direccion")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("NombreEmpresa")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Rfc")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("DatosEMC.DataModels.FacturaCompra", b =>
                {
                    b.Property<string>("NumeroFactura")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("MONEY");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("INT");

                    b.Property<int>("IdMetodoPago")
                        .HasColumnType("INT");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("INT");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INT");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("MONEY");

                    b.Property<string>("NombreProveedor")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("PorcentajeDescuento")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("PorcentajeImpuesto")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Total")
                        .HasColumnType("MONEY");

                    b.HasKey("NumeroFactura");

                    b.ToTable("FacturaCompra");
                });

            modelBuilder.Entity("DatosEMC.DataModels.FacturaCompraDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("MONEY");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("INT");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INT");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("MONEY");

                    b.Property<int>("Linea")
                        .HasColumnType("INT");

                    b.Property<string>("NombreArticulo")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NumeroFactura")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<decimal>("PorcentajeDescuento")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("PorcentajeImpuesto")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Total")
                        .HasColumnType("MONEY");

                    b.Property<int>("Unidad")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("FacturaCompraDetalle");
                });

            modelBuilder.Entity("DatosEMC.DataModels.FacturaVenta", b =>
                {
                    b.Property<string>("NumeroFactura")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("MONEY");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCliente")
                        .HasColumnType("INT");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("INT");

                    b.Property<int>("IdMetodoPago")
                        .HasColumnType("INT");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INT");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("MONEY");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("PorcentajeDescuento")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("PorcentajeImpuesto")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Total")
                        .HasColumnType("MONEY");

                    b.HasKey("NumeroFactura");

                    b.ToTable("FacturaVenta");
                });

            modelBuilder.Entity("DatosEMC.DataModels.FacturaVentaDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Descuento")
                        .HasColumnType("MONEY");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("INT");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INT");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("MONEY");

                    b.Property<int>("Linea")
                        .HasColumnType("INT");

                    b.Property<string>("NombreArticulo")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NumeroFactura")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<decimal>("PorcentajeDescuento")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("PorcentajeImpuesto")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("MONEY");

                    b.Property<decimal>("Total")
                        .HasColumnType("MONEY");

                    b.Property<int>("Unidad")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("FacturaVentaDetalle");
                });

            modelBuilder.Entity("DatosEMC.DataModels.MetodoPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Idioma")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("Metodo")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("MetodoPago");
                });

            modelBuilder.Entity("DatosEMC.DataModels.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<string>("Direccion")
                        .HasColumnType("VARCHAR(300)");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("INT");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("NombreProveedor")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Rfc")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("DatosEMC.DataModels.Roles", b =>
                {
                    b.Property<string>("Rol")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Rol");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DatosEMC.DataModels.StockBodega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("MONEY");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("INT");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("INT");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INT");

                    b.Property<string>("NombreArticulo")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Unidad")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("StockBodega");
                });

            modelBuilder.Entity("DatosEMC.DataModels.StockTotal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("MONEY");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("INT");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("INT");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INT");

                    b.Property<int>("Linea")
                        .HasColumnType("INT");

                    b.Property<string>("NombreArticulo")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("NumeroFactura")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Unidad")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("StockTotal");
                });

            modelBuilder.Entity("DatosEMC.DataModels.StockTransito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("MONEY");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<int>("IdArticulo")
                        .HasColumnType("INT");

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("INT");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("INT");

                    b.Property<int>("IdVendedor")
                        .HasColumnType("INT");

                    b.Property<string>("NombreArticulo")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<int>("Unidad")
                        .HasColumnType("INT");

                    b.HasKey("Id");

                    b.ToTable("StockTransito");
                });

            modelBuilder.Entity("DatosEMC.DataModels.TipoInventario", b =>
                {
                    b.Property<string>("Inventario")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Inventario");

                    b.ToTable("TipoInventario");
                });

            modelBuilder.Entity("DatosEMC.DataModels.UnidadMedida", b =>
                {
                    b.Property<string>("Unidad")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("INT");

                    b.Property<string>("Sistema")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Unidad");

                    b.ToTable("UnidadMedida");
                });

            modelBuilder.Entity("DatosEMC.DataModels.Usuario", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<string>("Apellido")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdEmpresa")
                        .HasColumnType("INT");

                    b.Property<int>("IdRol")
                        .HasColumnType("INT");

                    b.Property<string>("Nombre")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Password")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Password2")
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Username")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Email");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
