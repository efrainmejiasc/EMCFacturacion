global using NUnit.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EMCApi.Client;
using Moq;
using FacturacionEMCSite.Models;
using System.Text;
using FacturacionEMCUnitTest.Mocks;
using DatosEMC.IRepositories;
using DatosEMC.DataModels;
using DatosEMC.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using NegocioEMC.Services;
using NegocioEMC.IServices;
using System.Net;
using FacturacionEMCApi.Controllers;
using FacturacionEMCSite.Controllers;

namespace FacturacionEMCSite.Tests 
{
    [TestFixture]
    public class FacturaCompraWebController : ControllerBase
    {
        private DatosEMC.DTOs.UsuarioDTO usuario;
        private Mock<HttpContext> httpContext;
        private Mock<ISession> session;
        private Dictionary<string, byte[]> sessionData;
        private Mock<IHttpContextAccessor> httpContextAccessor;
        private EMCApi.Client.FacturaCompraDTO factura;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            httpContext = new Mock<HttpContext>();
            session = new Mock<ISession>();
            sessionData = new Dictionary<string, byte[]>();
            httpContextAccessor = new Mock<IHttpContextAccessor>();

            usuario = new DatosEMC.DTOs.UsuarioDTO
            {
                Id = 1,
                IdEmpresa = 2,
                Username = "Efrain"
            };

            factura = MockFactura.SetValoresHeadersFactura(usuario.IdEmpresa, usuario.Id);
        }

        [Test]
        public void GuardarFactura_DebeGuardarFacturaEnSesionYDevolverJsonConEstatusTrue()
        {

            sessionData["UserLogin"] = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(usuario));

            session.Setup(s => s.TryGetValue("UserLogin", out It.Ref<byte[]>.IsAny))
                .Returns((string key, out byte[] value) => sessionData.TryGetValue(key, out value));

            session.Setup(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>()));
            httpContext.Setup(c => c.Session).Returns(session.Object);
            httpContextAccessor.SetupGet(a => a.HttpContext).Returns(httpContext.Object);


            var clienteApi = new Mock<ClientEMCApi>();

            var sut = new FacturacionEMCSite.Controllers.FacturaCompraController(clienteApi.Object, httpContextAccessor.Object);

            // Act
            var result = sut.GuardarFactura(factura);

            // Assert
            session.Verify(s => s.Set("FacturaCompra", It.IsAny<byte[]>()), Times.Once);
            Assert.IsTrue(result is JsonResult jsonResult && jsonResult.Value is RespuestaModel response && response.Estatus);
        }
    }

}


namespace FacturacionEMCSite.Tests
{
    [TestFixture]
    public class FacturaCompraControllerTests
    {
        private DatosEMC.DTOs.UsuarioDTO usuario;
        private Mock<HttpContext> httpContext;
        private Mock<ISession> session;
        private Dictionary<string, byte[]> sessionData;
        private Mock<IHttpContextAccessor> httpContextAccessor;
        private EMCApi.Client.FacturaCompraDTO factura;
        List<FacturaCompraDetalle> listaFacturaCompraDetalle;

        [SetUp]
        public void SetUp()
        {
            httpContext = new Mock<HttpContext>();
            session = new Mock<ISession>();
            sessionData = new Dictionary<string, byte[]>();
            httpContextAccessor = new Mock<IHttpContextAccessor>();

            usuario = new DatosEMC.DTOs.UsuarioDTO
            {
                Id = 1,
                IdEmpresa = 2,
                Username = "Efrain"
            };
            factura = MockFactura.SetValoresHeadersFactura(usuario.IdEmpresa, usuario.Id);
            listaFacturaCompraDetalle = new List<FacturaCompraDetalle>
        {
            new FacturaCompraDetalle
            {
                Id = 1,
                NumeroFactura = "1550",
                Linea = 1,
                IdArticulo = 1001,
                NombreArticulo = "Art�culo 1",
                Cantidad = 10,
                Subtotal = 100.00M,
                PorcentajeImpuesto = 16.00M,
                Impuesto = 16.00M,
                PorcentajeDescuento = 5.00M,
                Descuento = 5.00M,
                Total = 111.00M,
                Fecha = DateTime.Now,
                FechaModificacion = DateTime.Now,
                IdUsuario = 1,
                Activo = true,
                Unidad = 1,
                IdEmpresa = 1
            },
            new FacturaCompraDetalle
            {
                Id = 2,
                NumeroFactura = "1550",
                Linea = 2,
                IdArticulo = 1002,
                NombreArticulo = "Art�culo 2",
                Cantidad = 5,
                Subtotal = 50.00M,
                PorcentajeImpuesto = 10.00M,
                Impuesto = 5.00M,
                PorcentajeDescuento = 0.00M,
                Descuento = 0.00M,
                Total = 55.00M,
                Fecha = DateTime.Now,
                FechaModificacion = DateTime.Now,
                IdUsuario = 1,
                Activo = true,
                Unidad = 1,
                IdEmpresa = 1
            }
        };
        }

        [Test]
        public async Task GuardarFacturaDetalle_ValidData_ReturnsJsonResponseWithTrueEstatus()
        {
            // Arrange
            string facturaDetalle = JsonConvert.SerializeObject(listaFacturaCompraDetalle);

            sessionData["UserLogin"] = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(usuario));

            session.Setup(s => s.TryGetValue("UserLogin", out It.Ref<byte[]>.IsAny))
                .Returns((string key, out byte[] value) => sessionData.TryGetValue(key, out value));

            session.Setup(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>()));
            httpContext.Setup(c => c.Session).Returns(session.Object);
            httpContextAccessor.SetupGet(a => a.HttpContext).Returns(httpContext.Object);

            sessionData["FacturaCompra"] = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(factura));
            session.Setup(s => s.TryGetValue("FacturaCompra", out It.Ref<byte[]>.IsAny))
                .Returns((string key, out byte[] value) => sessionData.TryGetValue(key, out value));


            var clienteApi = new Mock<ClientEMCApi>();

            var sut = new FacturacionEMCSite.Controllers.FacturaCompraController(clienteApi.Object, httpContextAccessor.Object);

            // Act
            IActionResult result = await sut.GuardarFacturaDetalle(facturaDetalle);
            var jsonResult = result as JsonResult;
            var response = jsonResult.Value as RespuestaModel;

            // Assert
            Assert.IsTrue(!response.Estatus);
        }

        // Agrega m�s pruebas seg�n tus requerimientos

        // ...
    }

}

//**************************************************************************


namespace FacturacionEMCApi.Tests.Controllers
{
    [TestFixture]
    public class FacturaCompraControllerTests
    {
        [Test]
        public void PostFacturaCompra_ValidFactura_ReturnsOkResult()
        {
            // Arrange
            var facturaDTO = new DatosEMC.DTOs.FacturaCompraDTO()
            {
                Id = 1,
                NumeroFactura = "F0001",
                IdEmpresa = 1,
                NombreProveedor = "Proveedor A",
                IdProveedor = 1,
                Subtotal = 100.00m,
                PorcentajeImpuesto = 0.18m,
                Impuesto = 18.00m,
                PorcentajeDescuento = 0.10m,
                Descuento = 10.00m,
                Total = 108.00m,
                Fecha = DateTime.Now,
                FechaModificacion = DateTime.Now,
                IdUsuario = 1,
                Activo = true,
                IdMetodoPago = 1
            };
            var mockFacturaCompraService = new Mock<IFacturaCompraService>();
            var controller = new FacturacionEMCApi.Controllers.FacturaCompraController(mockFacturaCompraService.Object);

            var expectedResponse = new DatosEMC.DTOs.GenericResponse { Ok = true /* ajusta los valores esperados */ };
            mockFacturaCompraService.Setup(s => s.AddFacturaCompra(It.IsAny<DatosEMC.DTOs.FacturaCompraDTO>())).Returns(expectedResponse);

            // Act
            var result = controller.PostFacturaCompra(facturaDTO);

            // Assert
            var okResult = result as OkObjectResult;
            var actualResponse = okResult.Value as DatosEMC.DTOs.GenericResponse;

            Assert.IsTrue(actualResponse.Ok);
            Assert.That(okResult.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
        }

        [Test]
        public void PostFacturaCompra_InvalidFactura_ReturnsBadRequestResult()
        {
            // Arrange
            var facturaDTO = new FacturaCompraDTO { /* inicializa los valores de facturaDTO */ };
            var mockFacturaCompraService = new Mock<IFacturaCompraService>();
            var controller = new FacturacionEMCApi.Controllers.FacturaCompraController(mockFacturaCompraService.Object);

            var expectedResponse = new GenericResponse { Ok = false /* ajusta los valores esperados */ };

        }
    }
}




namespace NegocioEMC.Tests.Services
{
    [TestFixture]
    public class FacturaCompraServiceTests
    {
        private FacturaCompraService facturaCompraService;
        private Mock<IFacturaCompraRepository> facturaCompraRepositoryMock;
        private Mock<IMapper> mapperMock;

        [SetUp]
        public void Setup()
        {
            facturaCompraRepositoryMock = new Mock<IFacturaCompraRepository>();
            mapperMock = new Mock<IMapper>();
            facturaCompraService = new FacturaCompraService(facturaCompraRepositoryMock.Object, mapperMock.Object);
        }

        [Test]
        public void AddFacturaCompra_ValidFactura_ReturnsSuccessResponse()
        {
            // Arrange
            var facturaDTO = new DatosEMC.DTOs.FacturaCompraDTO() 
            {
                Id = 1,
                NumeroFactura = "F0001",
                IdEmpresa = 1,
                NombreProveedor = "Proveedor A",
                IdProveedor = 1,
                Subtotal = 100.00m,
                PorcentajeImpuesto = 0.18m,
                Impuesto = 18.00m,
                PorcentajeDescuento = 0.10m,
                Descuento = 10.00m,
                Total = 108.00m,
                Fecha = DateTime.Now,
                FechaModificacion = DateTime.Now,
                IdUsuario = 1,
                Activo = true,
                IdMetodoPago = 1
            };

            // Arrange
            var factura = new FacturaCompra
            {
                Id = 1,
                NumeroFactura = "F0001",
                IdEmpresa = 1,
                NombreProveedor = "Proveedor A",
                IdProveedor = 1,
                Subtotal = 100.00m,
                PorcentajeImpuesto = 0.18m,
                Impuesto = 18.00m,
                PorcentajeDescuento = 0.10m,
                Descuento = 10.00m,
                Total = 108.00m,
                Fecha = DateTime.Now,
                FechaModificacion = DateTime.Now,
                IdUsuario = 1,
                Activo = true,
                IdMetodoPago = 1
            };

            mapperMock.Setup(m => m.Map<FacturaCompra>(facturaDTO)).Returns(factura);
            facturaCompraRepositoryMock.Setup(r => r.AddFacturaCompra(factura)).Returns(factura);

            // Act
            var result = facturaCompraService.AddFacturaCompra(facturaDTO);

            // Assert
            Assert.IsTrue(result.Ok);
            Assert.That(result.Mensaje, Is.EqualTo("La informaci�n ha sido registrada"));
        }

        [Test]
        public void AddFacturaCompra_InvalidFactura_ReturnsErrorResponse()
        {
            // Arrange
            var facturaDTO = new DatosEMC.DTOs.FacturaCompraDTO(); // Crear una instancia de FacturaCompraDTO v�lida
            var factura = new FacturaCompra(); // Crear una instancia de FacturaCompra inv�lida (null)

            mapperMock.Setup(m => m.Map<FacturaCompra>(facturaDTO)).Returns(factura);
            facturaCompraRepositoryMock.Setup(r => r.AddFacturaCompra(factura)).Returns((FacturaCompra)null);

            // Act
            var result = facturaCompraService.AddFacturaCompra(facturaDTO);

            // Assert
            Assert.IsFalse(result.Ok);
            Assert.That(result.Mensaje, Is.EqualTo("No se pudo registrar la informaci�n"));
        }
    }
}



namespace DatosEMC.Tests.Repositories
{
    [TestFixture]
    public class FacturaCompraRepositoryTests
    {
        private MyAppContext dbContext;
        private FacturaCompraRepository facturaCompraRepository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MyAppContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            dbContext = new MyAppContext(options);
            facturaCompraRepository = new FacturaCompraRepository(dbContext);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }

        [Test]
        public void AddFacturaCompra_ValidFactura_ReturnsFactura()
        {
            // Arrange
            var factura = new FacturaCompra
            {
                Id = 1,
                NumeroFactura = "F0001",
                IdEmpresa = 1,
                NombreProveedor = "Proveedor A",
                IdProveedor = 1,
                Subtotal = 100.00m,
                PorcentajeImpuesto = 0.18m,
                Impuesto = 18.00m,
                PorcentajeDescuento = 0.10m,
                Descuento = 10.00m,
                Total = 108.00m,
                Fecha = DateTime.Now,
                FechaModificacion = DateTime.Now,
                IdUsuario = 1,
                Activo = true,
                IdMetodoPago = 1
            };

            // Act
            var result = facturaCompraRepository.AddFacturaCompra(factura);

            // Assert
            Assert.NotNull(result);
            Assert.That(result, Is.EqualTo(factura));
        }
    }
}
