using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class newstock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockBodega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    IdArticulo = table.Column<int>(type: "INT", nullable: false),
                    NombreArticulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Unidad = table.Column<int>(type: "INT", nullable: false),
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
                    IdArticulo = table.Column<int>(type: "INT", nullable: false),
                    NombreArticulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Unidad = table.Column<int>(type: "INT", nullable: false),
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
                    IdArticulo = table.Column<int>(type: "INT", nullable: false),
                    NombreArticulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Unidad = table.Column<int>(type: "INT", nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockBodega");

            migrationBuilder.DropTable(
                name: "StockTotal");

            migrationBuilder.DropTable(
                name: "StockTransito");
        }
    }
}
