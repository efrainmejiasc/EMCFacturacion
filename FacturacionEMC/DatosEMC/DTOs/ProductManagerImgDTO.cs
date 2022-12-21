using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public  class ProductManagerImgDTO
    {
        public int  Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Peso{ get; set; }
        public string Tamaño { get; set; }
        public string Descripcion { get; set; }
        public List<string> Identidades { get; set; }
        public List<string> NombresImg { get; set; }

    }
}
