using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class correcStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockTotal");

            migrationBuilder.DropTable(
                name: "StockTransito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockTotal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    IdProducto = table.Column<int>(type: "INT", nullable: false),
                    IdUnidad = table.Column<int>(type: "INT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    Linea = table.Column<int>(type: "INT", nullable: false),
                    NombreProducto = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: true)
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
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    IdProducto = table.Column<int>(type: "INT", nullable: false),
                    IdUnidad = table.Column<int>(type: "INT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    IdVendedor = table.Column<int>(type: "INT", nullable: false),
                    NombreProducto = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransito", x => x.Id);
                });
        }
    }
}
