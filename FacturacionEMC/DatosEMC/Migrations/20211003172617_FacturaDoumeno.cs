using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class FacturaDoumeno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IdRol",
                table: "Usuario",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "FacturaCompra",
                columns: table => new
                {
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    NombreProveedor = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IdProveedor = table.Column<int>(type: "INT", nullable: false),
                    Subtotal = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeImpuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    Impuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Descuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Total = table.Column<decimal>(type: "MONEY", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaCompra", x => x.NumeroFactura);
                });

            migrationBuilder.CreateTable(
                name: "FacturaCompraDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Linea = table.Column<int>(type: "INT", nullable: false),
                    IdArticulo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    NombreArticulo = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Cantidad = table.Column<int>(type: "INT", nullable: false),
                    Subtotal = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeImpuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    Impuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Descuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Total = table.Column<decimal>(type: "MONEY", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaCompraDetalle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Rol = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Rol);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaCompra");

            migrationBuilder.DropTable(
                name: "FacturaCompraDetalle");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropColumn(
                name: "IdRol",
                table: "Usuario");
        }
    }
}
