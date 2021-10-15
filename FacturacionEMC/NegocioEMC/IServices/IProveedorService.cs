using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IProveedorService
    {
        List<ProveedorDTO> GetProveedores(int idEmpresa);
        GenericResponse AddProveedor(ProveedorDTO proveedorDTO);
    }
}
