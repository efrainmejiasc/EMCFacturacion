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
    public  class StockTransitoRepository : IStockTransitoRepository
    {
        private readonly MyAppContext db;
        public StockTransitoRepository(MyAppContext _db)
        {
            this.db = _db;
        }
        public List<StockTransito> AddStockTransito(List<StockTransito> model)
        {
            this.db.StockTransito.AddRange(model);
            this.db.SaveChangesAsync();

            return model;
        }

        public List<StockTransitoDTO>  GetAsignacionesVendedor (int idEmpresa,int idUsuario, bool activo)
        {
            var lst = new List<StockTransitoDTO>();
            var lista = new List<StockTransitoDTO>();

            var productos = this.db.Producto.Where(x => x.Activo == true).ToList();
            var stTransito = this.db.StockTransito.ToList();


            foreach(var producto in productos)
            {
                     var r = (from t in db.StockTransito
                             join u in db.Usuario on t.IdUsuario equals u.Id
                             join p in db.Producto on t.IdArticulo equals p.Id
                             where t.IdEmpresa == idEmpresa && p.IdEmpresa == idEmpresa && p.Activo == activo && t.IdArticulo == producto.Id && t.IdVendedor == idUsuario
                             select new { t, u, p }).AsEnumerable()
                            .Select(x => new StockTransitoDTO
                            {
                              Id = x.p.Id,
                              Identificador = x.p.Identificador.ToString(),
                              NombreVendedor = x.u.Nombre + " " + x.u.Apellido,
                              IdVendedor = x.u.Id,
                              NombreArticulo = x.p.NombreProducto,
                              Cantidad = stTransito.Where(s => s.IdArticulo == producto.Id && s.IdEmpresa == idEmpresa && s.IdVendedor == idUsuario).Sum(s => s.Cantidad),
                              Unidad = x.t.Unidad,
                              StrUnidad = x.p.Presentacion,
                              IdArticulo = x.t.IdArticulo

                             }).ToList();

                lista.AddRange(r);
             }


            foreach (var single in lista)
            {
                if (lst.Where(x => x.Identificador == single.Identificador).FirstOrDefault() == null)
                    lst.Add(single);
            }

            return lst;
        }


        public List<StockTransitoDTO> GetStockTransitoProducto(int idEmpresa, int idArticulo, bool activo)
        {
            var lst = new List<StockTransitoDTO>();
            var stTransito = this.db.StockTransito.ToList();

            var lista = (from t in db.StockTransito
                   join u in db.Usuario on t.IdUsuario equals u.Id
                   join p in db.Producto on t.IdArticulo equals p.Id
                   where t.IdEmpresa == idEmpresa && p.IdEmpresa == idEmpresa && p.Activo == activo && t.IdArticulo == idArticulo
                   select new { t, u, p }).AsEnumerable()
                   .Select(x => new StockTransitoDTO
                   {
                       Id = x.p.Id,
                       Identificador = x.p.Identificador.ToString(),
                       NombreVendedor = x.u.Nombre + " " + x.u.Apellido,
                       IdVendedor = x.u.Id,
                       NombreArticulo = x.p.NombreProducto,
                       Cantidad = stTransito.Where(s => s.IdArticulo == idArticulo && s.IdEmpresa == idEmpresa && s.IdVendedor == x.u.Id).Sum(s => s.Cantidad),
                       Unidad = x.t.Unidad,
                       StrUnidad = x.p.Presentacion,
                       IdArticulo = x.t.IdArticulo

                   }).ToList();


            foreach(var single in lista)
            {
                if (lst.Where(x => x.Identificador == single.Identificador).FirstOrDefault() == null)
                    lst.Add(single);
            }

            return lst;
        }

    }
}
