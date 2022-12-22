using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class ProductoImgInfoDTO
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Peso { get; set; }
        public string Tamaño { get; set; }
        public string Descripcion { get; set; }
    }
}
