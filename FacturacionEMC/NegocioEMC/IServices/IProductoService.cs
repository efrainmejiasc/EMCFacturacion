using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IProductoService
    {
        GenericResponse AddProducto(ProductoDTO productoDTO);
        List<ProductoDTO> GetProductos(int idEmpresa, bool activo);
    }
}
