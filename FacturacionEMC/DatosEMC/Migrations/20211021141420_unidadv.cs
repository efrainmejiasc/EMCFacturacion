using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class unidadv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Unidad",
                table: "FacturaVentaDetalle",
                type: "INT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Unidad",
                table: "FacturaCompraDetalle",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unidad",
                table: "FacturaVentaDetalle");

            migrationBuilder.AlterColumn<string>(
                name: "Unidad",
                table: "FacturaCompraDetalle",
                type: "VARCHAR(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");
        }
    }
}
