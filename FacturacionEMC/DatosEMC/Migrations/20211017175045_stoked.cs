using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class stoked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreProveedor",
                table: "Proveedor",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreArticulo",
                table: "FacturaVentaDetalle",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cantidad",
                table: "FacturaVentaDetalle",
                type: "MONEY",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<string>(
                name: "NombreArticulo",
                table: "FacturaCompraDetalle",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cantidad",
                table: "FacturaCompraDetalle",
                type: "MONEY",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpresa",
                table: "Empresa",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreCliente",
                table: "Cliente",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "StockBodega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    IdProducto = table.Column<int>(type: "INT", nullable: false),
                    NombreProducto = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    IdUnidad = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBodega", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTotal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Linea = table.Column<int>(type: "INT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    IdProducto = table.Column<int>(type: "INT", nullable: false),
                    NombreProducto = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    IdUnidad = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTotal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTransito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    IdProducto = table.Column<int>(type: "INT", nullable: false),
                    NombreProducto = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    IdUnidad = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    IdVendedor = table.Column<int>(type: "INT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    Unidad = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.Unidad);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockBodega");

            migrationBuilder.DropTable(
                name: "StockTotal");

            migrationBuilder.DropTable(
                name: "StockTransito");

            migrationBuilder.DropTable(
                name: "UnidadMedida");

            migrationBuilder.AlterColumn<string>(
                name: "NombreProveedor",
                table: "Proveedor",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreArticulo",
                table: "FacturaVentaDetalle",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "FacturaVentaDetalle",
                type: "INT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "MONEY");

            migrationBuilder.AlterColumn<string>(
                name: "NombreArticulo",
                table: "FacturaCompraDetalle",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "FacturaCompraDetalle",
                type: "INT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "MONEY");

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpresa",
                table: "Empresa",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreCliente",
                table: "Cliente",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);
        }
    }
}
