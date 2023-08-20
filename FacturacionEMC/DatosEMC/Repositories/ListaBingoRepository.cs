using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosEMC.Repositories
{
    public class ListaBingoRepository: IListaBingoRepository
    {
        private readonly MyAppContext db;
        public ListaBingoRepository(MyAppContext _db) 
        {
            this.db = _db;
        }

        public List<ListaBingo> InsertListaBingo(List<ListaBingo> model)
        {
            db.ListaBingo.AddRangeAsync(model);
            db.SaveChanges();

            return model;
        }

        public List<ListaBingo> GetListaBingo()
        {
            var lista = db.ListaBingo.OrderByDescending(registro => registro.Id) 
                       .Take(1000) 
                       .ToList();

            return lista;
        }
    }
}
