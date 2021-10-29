using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class articl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    NombreProducto = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Descripcion = table.Column<string>(type: "VARCHAR(200)", nullable: true),
                    PrecioUnidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    Presentacion = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
