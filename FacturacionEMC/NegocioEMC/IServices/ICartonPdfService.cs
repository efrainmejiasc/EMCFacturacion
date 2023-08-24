using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface ICartonPdfService
    {
        byte[] GeneratePdfImagenes(List<List<int>> numberLists, string path);
        byte[] GeneratePdfNumeros(List<List<int>> numberLists,string path);
    }
}
