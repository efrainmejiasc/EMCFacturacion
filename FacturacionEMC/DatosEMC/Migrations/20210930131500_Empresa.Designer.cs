﻿// <auto-generated />
using System;
using DatosEMC.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatosEMC.Migrations
{
    [DbContext(typeof(MyAppContext))]
    [Migration("20210930131500_Empresa")]
    partial class Empresa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatosEMC.DataModels.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("BIT");

                    b.Property<string>("Direccion")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("DATETIME");

                    b.Property<Guid>("Identificador")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("NombreEmpresa")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Rfc")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.ToTable("Empresa");
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

                    b.Property<string>("Nombre")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Password")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Password2")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Username")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Email");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
