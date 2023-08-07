using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace FacturacionEMCSite.Models
{
    public class RespuestaModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estatus { get; set; }
        public bool EstatusFacturacion { get; set; }
        public List<string> Identidades { get; set; }
        public List<string> Nombres { get; set; }
        public List<VentaNumero> VentaNumero { get; set; }
    }
}
