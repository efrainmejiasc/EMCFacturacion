using DatosEMC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.IRepositories
{
    public interface IClienteRepository
    {
        Cliente AddClienteAsync(Cliente x);
        List<Cliente> GetClientes(int idEmpresa);
    }
}
