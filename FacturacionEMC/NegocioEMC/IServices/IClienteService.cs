using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface IClienteService
    {
        List<ClienteDTO> GetClientes(int idEmpresa);
        GenericResponse AddCliente(ClienteDTO ClienteDTO);
    }
}
