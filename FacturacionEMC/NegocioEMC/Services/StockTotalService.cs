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

        public StockTotalService(IStockTotalRepository _stockTotalRepository)
        {
            this.stockTotalRepository = _stockTotalRepository;
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
                    Activo = true
                };
                stocks.Add(stock);
            }

            stocks = this.stockTotalRepository.AddExistencia(stocks);

            if (stocks.Count > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");


        }
    }
}
