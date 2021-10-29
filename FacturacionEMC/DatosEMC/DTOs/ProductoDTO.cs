using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public Guid Identificador { get; set; }
        public int IdEmpresa { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnidad { get; set; }
        public string Presentacion { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public bool Activo { get; set; }
    }
}
