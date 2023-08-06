using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class VentaNumeroRango : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdVentaNumeroRango",
                table: "VentaNumero",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "VentaNumero",
                type: "VARCHAR(250)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VentaNumeroRango",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicial = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaNumeroRango", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentaNumeroRango");

            migrationBuilder.DropColumn(
                name: "IdVentaNumeroRango",
                table: "VentaNumero");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "VentaNumero");
        }
    }
}
