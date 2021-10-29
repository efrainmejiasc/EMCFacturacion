using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IProductoRepository
    {
        Producto AddProducto(Producto model);
        List<Producto> GetProductos(int idEmpresa, bool activo);
    }
}
