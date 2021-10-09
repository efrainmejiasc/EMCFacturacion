using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosEMC.DTOs;

namespace NegocioEMC.Commons
{
    public class EngineService
    {
        public static  GenericResponse SetGenericResponse(bool ok, string mensaje)
        {
            var response = new GenericResponse()
            {
                Ok = ok,
                Mensaje = mensaje
            };

            return response;
        }
    }
}
