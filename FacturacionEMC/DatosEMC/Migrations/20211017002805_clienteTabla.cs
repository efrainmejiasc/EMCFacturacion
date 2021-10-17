using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class clienteTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    NombreCliente = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Rfc = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Direccion = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
