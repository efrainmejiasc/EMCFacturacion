﻿using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IFacturaVentaDetalleRepository
    {
        List<FacturaVentaDetalle> AddFacturaVentaDetalle(List<FacturaVentaDetalle> facturaDetalle);
    }
}