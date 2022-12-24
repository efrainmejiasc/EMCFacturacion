using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class imgproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductoImg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoImgInfoId = table.Column<int>(type: "INT", nullable: false),
                    StrBase64 = table.Column<string>(type: "VARCHAR(8000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoImg", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoImgInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    Categoria = table.Column<string>(type: "VARCHAR(150)", nullable: true),
                    Peso = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Tamaño = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Descripcion = table.Column<string>(type: "VARCHAR(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoImgInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoImg");

            migrationBuilder.DropTable(
                name: "ProductoImgInfo");
        }
    }
}
