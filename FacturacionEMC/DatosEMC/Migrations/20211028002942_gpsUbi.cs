using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class gpsUbi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Altitud",
                table: "Proveedor",
                type: "FLOAT",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitud",
                table: "Proveedor",
                type: "FLOAT",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitud",
                table: "Proveedor",
                type: "FLOAT",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Altitud",
                table: "Cliente",
                type: "FLOAT",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Latitud",
                table: "Cliente",
                type: "FLOAT",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitud",
                table: "Cliente",
                type: "FLOAT",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Altitud",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Proveedor");

            migrationBuilder.DropColumn(
                name: "Altitud",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Longitud",
                table: "Cliente");
        }
    }
}
