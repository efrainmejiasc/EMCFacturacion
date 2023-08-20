using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public  class ListaBingoService: IListaBingoService
    {
        private readonly IMapper mapper;
        private readonly IListaBingoRepository listaBingoRepository;

        public ListaBingoService(IMapper _mapper, IListaBingoRepository _listaBingoRepository)
        {
            this.mapper = _mapper;
            this.listaBingoRepository = _listaBingoRepository;
        }
        public GenericResponse GenerarListas() 
        {
            var resultList = GenerateUniqueLists();

            if (resultList.Count == 1000)

                return EngineService.SetGenericResponse(true, "La información ha sido registrada");
            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        private List<ListaBingoDTO> GenerateUniqueLists()
        {
           var resultList = new List<List<int>>();

            for (int i = 0; i < 1000; i++)
            {
                var newList = new List<int>();
                AddNumberToList(newList);

                if(!ValidarExisteLista(resultList,newList))
                  resultList.Add(newList);
            }

            return FromContenedor(resultList);
        }


        private  List<int> AddNumberToList(List<int> newList)
        {
            while (newList.Count < 48)
            {
                var numero = Numero();
                if (newList.Contains(numero))
                    AddNumberToList(newList);
                else
                    newList.Add(numero);
            }

            //var min = newList.Where(x => x == 0);
            //var max = newList.Where(x => x == 269);

            return newList;
        }

        private int Numero()
        {
            int seed = DateTime.Now.Millisecond;
            Random random = new Random(seed);

            int minValue = 0;
            int maxValue = 269;

           return random.Next(minValue, maxValue + 1);
        }

      
        private bool ValidarExisteLista(List<List<int>> contenedor, List<int> lista)
        {
            foreach (var l in contenedor)
            {
                if (l.SequenceEqual(lista))
                {
                    return true;
                }
            }
            return false;
        }


        private List<ListaBingoDTO> FromContenedor(List<List<int>> contenedor)
        {
            var lstBingo = new List<ListaBingo>();
            var lstBingoDTO = new List<ListaBingoDTO>();

            foreach (var lista in contenedor)
            {

                var lst = new ListaBingo();
                lst.IdentificadorUnico = EngineTool.CreateUniqueidentifier();
                lst.FechaCreacion = DateTime.Now;
                lst.Activo = true;

                for (int i = 0; i < lista.Count; i++)
                {
                    var propName = $"Numero{i + 1}";
                    var prop = typeof(ListaBingo).GetProperty(propName);
                    if (prop != null)
                    {
                        prop.SetValue(lst, lista[i]);
                    }
                }

                lstBingo.Add(lst);
            }
            this.listaBingoRepository.InsertListaBingo(lstBingo);
            lstBingoDTO  = this.mapper.Map<List<ListaBingoDTO>>(lstBingo);
            return lstBingoDTO;
        }



    }
}
