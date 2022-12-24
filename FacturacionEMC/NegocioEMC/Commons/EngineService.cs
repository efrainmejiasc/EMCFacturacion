using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatosEMC.DataModels;
using DatosEMC.DTOs;

namespace NegocioEMC.Commons
{
    public class EngineService
    {
        public static  GenericResponse SetGenericResponse(bool ok, string mensaje,int id = 0)
        {
            var response = new GenericResponse()
            {
                Id = id,
                Ok = ok,
                Mensaje = mensaje
            };

            return response;
        }


       
    }
}
