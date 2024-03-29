﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public Guid Identificador { get; set; }
        public string NombreCliente { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaModificacion { get; set; }
        public float Longitud { get; set; }
        public float Latitud { get; set; }
        public float Altitud { get; set; }
    }
}
