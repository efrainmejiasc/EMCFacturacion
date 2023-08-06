using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class GenericResponse
    {
        public int Id { get; set; }
        public bool Ok { get; set; }
        public string Mensaje { get; set; }

        public List<VentaNumero> VentaBumeroDTO { get; set; }

    }
}
