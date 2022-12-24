using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class imgproductsInf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificador",
                table: "ProductoImg",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreArchivo",
                table: "ProductoImg",
                type: "VARCHAR(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "ProductoImg",
                type: "VARCHAR(1000)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificador",
                table: "ProductoImg");

            migrationBuilder.DropColumn(
                name: "NombreArchivo",
                table: "ProductoImg");

            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "ProductoImg");
        }
    }
}
