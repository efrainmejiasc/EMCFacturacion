using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Commons
{
    public class EngineEnums
    {
        public enum Roles
        {
            ADMINISTRADOR = 1,
            CLIENTE = 2,
            VENDEDOR = 3,  
            ROOT = 4
        }

        public enum InventoryLocation
        {
            BODEGA = 1,
            TRANSITO = 2,
        }
    }
}
