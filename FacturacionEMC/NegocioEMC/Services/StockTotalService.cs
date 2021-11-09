using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public class StockTotalService: IStockTotalService 
    {
        private readonly IStockTotalRepository stockTotalRepository;
        private readonly IProductoRepository productoRepository;

        public StockTotalService(IStockTotalRepository _stockTotalRepository , IProductoRepository _productoRepository)
        {
            this.stockTotalRepository = _stockTotalRepository;
            this.productoRepository = _productoRepository;
        }

        public GenericResponse AddExistencia(List<FacturaCompraDetalleDTO> facturas )
        {
            var stock = new StockTotal();
            var stocks = new List<StockTotal>();
            foreach (var f in facturas)
            {
                stock = new StockTotal()
                {
                    IdEmpresa = f.IdEmpresa,
                    NumeroFactura = f.NumeroFactura,
                    Linea = f.Linea,
                    IdArticulo= f.IdArticulo,
                    NombreArticulo = f.NombreArticulo,
                    Unidad = f.Unidad,
                    Cantidad = f.Cantidad,
                    Fecha = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    IdUsuario = f.IdUsuario,
                    Activo = true,
                    TipoFactura = 1
                };
                stocks.Add(stock);
            }

            stocks = this.stockTotalRepository.AddExistencia(stocks);

            if (stocks.Count > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public GenericResponse RemoveExistencia(List<FacturaVentaDetalleDTO> facturas)
        {
            var stock = new StockTotal();
            var stocks = new List<StockTotal>();
            foreach (var f in facturas)
            {
                stock = new StockTotal()
                {
                    IdEmpresa = f.IdEmpresa,
                    NumeroFactura = f.NumeroFactura,
                    Linea = f.Linea,
                    IdArticulo = f.IdArticulo,
                    NombreArticulo = f.NombreArticulo,
                    Unidad = f.Unidad,
                    Cantidad = f.Cantidad,
                    Fecha = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    IdUsuario = f.IdUsuario,
                    Activo = true,
                    TipoFactura = 2
                };
                stocks.Add(stock);
            }

            stocks = this.stockTotalRepository.AddExistencia(stocks);

            if (stocks.Count > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public List<StockTotalDTO> GetStockTotal(int idEmpresa , bool activo = true)
        {
            var productos = this.productoRepository.GetProductos(idEmpresa, activo);
            var stockTotal = this.stockTotalRepository.GetProductosStock(idEmpresa, activo);

            var lst = new List<StockTotalDTO>();
            StockTotalDTO s ;

            foreach(var p in productos)
            {
                s = new StockTotalDTO();

                s.Identificador = p.Identificador.ToString();
                s.IdArticulo = p.Id;
                s.NombreProducto = p.NombreProducto;
                s.CantidadPositiva = stockTotal.Where(x => x.Activo == true && x.Id == p.Id && x.TipoFactura == 1).Sum(x => x.Cantidad);
                s.CantidadNegativa = stockTotal.Where(x => x.Activo == true && x.Id == p.Id && x.TipoFactura == 2).Sum(x => x.Cantidad);
                s.Cantidad = Math.Round( s.CantidadPositiva - s.CantidadNegativa ,2);
                s.Unidad = p.Presentacion;
                
                lst.Add(s);
            }

            return lst;
        }

        public decimal GetExistenciaProducto(int idEmpresa, int idArticulo, bool activo = true)
        {
            return this.stockTotalRepository.GetExistenciaProducto(idEmpresa, idArticulo,activo);
        }
    }
}
