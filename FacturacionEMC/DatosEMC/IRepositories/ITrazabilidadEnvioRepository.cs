﻿using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface ITrazabilidadEnvioRepository
    {
        bool DeleteTrazabilidadEnvio(int id);
        TrazabilidadEnvio UpdateTrazabilidadEnvio(TrazabilidadEnvio x);
        TrazabilidadEnvio AddTrazabilidadEnvioAsync(TrazabilidadEnvio x);
        List<TrazabilidadEnvio> GetTrazabilidadEnvio(int idEmpresa, string dni);
        TrazabilidadEnvio GetTrazabilidadEnvio(int idEmpresa, Guid identificador);
        List<TrazabilidadEnvio> GetTrazabilidadEnvio(int idEmpresa, DateTime fechaInicio, DateTime fechaFinal);
    }
}
