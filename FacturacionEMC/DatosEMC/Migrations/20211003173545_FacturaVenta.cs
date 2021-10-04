using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class FacturaVenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdRol",
                table: "Usuario",
                type: "INT",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "BIT");

            migrationBuilder.AlterColumn<int>(
                name: "IdArticulo",
                table: "FacturaCompraDetalle",
                type: "INT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)");

            migrationBuilder.CreateTable(
                name: "FacturaVenta",
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
                    table.PrimaryKey("PK_FacturaVenta", x => x.NumeroFactura);
                });

            migrationBuilder.CreateTable(
                name: "FacturaVentaDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Linea = table.Column<int>(type: "INT", nullable: false),
                    IdArticulo = table.Column<int>(type: "INT", nullable: false),
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
                    table.PrimaryKey("PK_FacturaVentaDetalle", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaVenta");

            migrationBuilder.DropTable(
                name: "FacturaVentaDetalle");

            migrationBuilder.AlterColumn<bool>(
                name: "IdRol",
                table: "Usuario",
                type: "BIT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<string>(
                name: "IdArticulo",
                table: "FacturaCompraDetalle",
                type: "VARCHAR(50)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");
        }
    }
}
