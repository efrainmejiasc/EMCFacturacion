using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class Loteria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loterias",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loterias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VentaNumero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Vendedor = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    Numero = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Loteria = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    FechaVenta = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaSorteo = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaNumero", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loterias");

            migrationBuilder.DropTable(
                name: "VentaNumero");
        }
    }
}
