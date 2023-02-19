using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DatosEMC.Migrations
{
    public partial class inicial : Migration
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
                    NombreCliente = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Rfc = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Direccion = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Longitud = table.Column<double>(type: "FLOAT", nullable: false),
                    Latitud = table.Column<double>(type: "FLOAT", nullable: false),
                    Altitud = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Rfc = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Direccion = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacturaCompra",
                columns: table => new
                {
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    NombreProveedor = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    IdProveedor = table.Column<int>(type: "INT", nullable: false),
                    Subtotal = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeImpuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    Impuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Descuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Total = table.Column<decimal>(type: "MONEY", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    IdMetodoPago = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaCompra", x => x.NumeroFactura);
                });

            migrationBuilder.CreateTable(
                name: "FacturaCompraDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Linea = table.Column<int>(type: "INT", nullable: false),
                    IdArticulo = table.Column<int>(type: "INT", nullable: false),
                    NombreArticulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    Subtotal = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeImpuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    Impuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Descuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Total = table.Column<decimal>(type: "MONEY", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    Unidad = table.Column<int>(type: "INT", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaCompraDetalle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacturaVenta",
                columns: table => new
                {
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    NombreCliente = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    IdCliente = table.Column<int>(type: "INT", nullable: false),
                    Subtotal = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeImpuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    Impuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Descuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Total = table.Column<decimal>(type: "MONEY", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    IdMetodoPago = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaVenta", x => x.NumeroFactura);
                });

            migrationBuilder.CreateTable(
                name: "FacturaVentaDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Linea = table.Column<int>(type: "INT", nullable: false),
                    IdArticulo = table.Column<int>(type: "INT", nullable: false),
                    NombreArticulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    Subtotal = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeImpuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    Impuesto = table.Column<decimal>(type: "MONEY", nullable: false),
                    PorcentajeDescuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Descuento = table.Column<decimal>(type: "MONEY", nullable: false),
                    Total = table.Column<decimal>(type: "MONEY", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    Unidad = table.Column<int>(type: "INT", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaVentaDetalle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InicioFacturacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InicioFacturacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metodo = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Idioma = table.Column<string>(type: "VARCHAR(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "ProductoImg",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoImgInfoId = table.Column<int>(type: "INT", nullable: false),
                    StrBase64 = table.Column<string>(type: "VARCHAR(8000)", nullable: true),
                    Identificador = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    NombreArchivo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Ubicacion = table.Column<string>(type: "VARCHAR(1000)", nullable: true)
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
                    Descripcion = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Precio = table.Column<decimal>(type: "MONEY", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoImgInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    NombreProveedor = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Rfc = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Direccion = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Longitud = table.Column<double>(type: "FLOAT", nullable: false),
                    Latitud = table.Column<double>(type: "FLOAT", nullable: false),
                    Altitud = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Rol = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Rol);
                });

            migrationBuilder.CreateTable(
                name: "StockBodega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    IdArticulo = table.Column<int>(type: "INT", nullable: false),
                    NombreArticulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Unidad = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockBodega", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTotal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    NumeroFactura = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Linea = table.Column<int>(type: "INT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    IdArticulo = table.Column<int>(type: "INT", nullable: false),
                    NombreArticulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Unidad = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false),
                    TipoFactura = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTotal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTransito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Cantidad = table.Column<decimal>(type: "MONEY", nullable: false),
                    IdArticulo = table.Column<int>(type: "INT", nullable: false),
                    NombreArticulo = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Unidad = table.Column<int>(type: "INT", nullable: false),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    IdVendedor = table.Column<int>(type: "INT", nullable: false),
                    IdUsuario = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransito", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoFactura",
                columns: table => new
                {
                    FacturaTipo = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoFactura", x => x.FacturaTipo);
                });

            migrationBuilder.CreateTable(
                name: "TipoInventario",
                columns: table => new
                {
                    Inventario = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInventario", x => x.Inventario);
                });

            migrationBuilder.CreateTable(
                name: "TrazabilidadEnvio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificador = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(250)", nullable: true),
                    Dni = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Direccion = table.Column<string>(type: "VARCHAR(300)", nullable: true),
                    Telefono = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaLlegada = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    FechaReclamo = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Observacion = table.Column<string>(type: "VARCHAR(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrazabilidadEnvio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadMedida",
                columns: table => new
                {
                    Unidad = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Sistema = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadMedida", x => x.Unidad);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Email = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEmpresa = table.Column<int>(type: "INT", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Apellido = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Username = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Password = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Password2 = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Activo = table.Column<bool>(type: "BIT", nullable: false),
                    IdRol = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "FacturaCompra");

            migrationBuilder.DropTable(
                name: "FacturaCompraDetalle");

            migrationBuilder.DropTable(
                name: "FacturaVenta");

            migrationBuilder.DropTable(
                name: "FacturaVentaDetalle");

            migrationBuilder.DropTable(
                name: "InicioFacturacion");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "ProductoImg");

            migrationBuilder.DropTable(
                name: "ProductoImgInfo");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "StockBodega");

            migrationBuilder.DropTable(
                name: "StockTotal");

            migrationBuilder.DropTable(
                name: "StockTransito");

            migrationBuilder.DropTable(
                name: "TipoFactura");

            migrationBuilder.DropTable(
                name: "TipoInventario");

            migrationBuilder.DropTable(
                name: "TrazabilidadEnvio");

            migrationBuilder.DropTable(
                name: "UnidadMedida");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
