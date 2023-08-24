using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class imagenesBingo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagenesBingo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreImagen = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    RutaImagen = table.Column<string>(type: "VARCHAR(8000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenesBingo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenesBingo");
        }
    }
}
