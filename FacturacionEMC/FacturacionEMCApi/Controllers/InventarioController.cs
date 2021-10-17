using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IStockTotalService stockTotalService;
        private readonly IStockBodegaService stockBodegaService;
        private readonly IStockTransitoService stockTransitoService;

        public InventarioController( IStockTotalService _stockTotalService, IStockBodegaService _stockBodegaService, IStockTransitoService _stockTransitoService)
        {
          this.stockTotalService = _stockTotalService;
          this.stockBodegaService = _stockBodegaService;
          this.stockTransitoService = _stockTransitoService;
       }
    }
}
