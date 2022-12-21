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
    public class ProductoImgDTO
    {

        public int Id { get; set; }


        public int ProductoImgInfoId { get; set; }


        public string StrBase64 { get; set; }


        public string Identificador { get; set; }

        public string NombreArchivo { get; set; }

        public string Ubicacion { get; set; }
    }
}
