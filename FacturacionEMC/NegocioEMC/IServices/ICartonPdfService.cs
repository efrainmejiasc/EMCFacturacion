using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.IServices
{
    public interface ICartonPdfService
    {
        byte[] GeneratePdf(List<List<string>> imageLists,string path);
        byte[] GeneratePdf(List<List<int>> numberLists,string path);
    }
}
