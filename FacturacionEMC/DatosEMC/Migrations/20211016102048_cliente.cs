using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class cliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreProveedor",
                table: "FacturaVenta",
                newName: "NombreCliente");

            migrationBuilder.RenameColumn(
                name: "IdProveedor",
                table: "FacturaVenta",
                newName: "IdCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreCliente",
                table: "FacturaVenta",
                newName: "NombreProveedor");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "FacturaVenta",
                newName: "IdProveedor");
        }
    }
}
