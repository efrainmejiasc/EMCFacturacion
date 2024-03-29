﻿using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.DTOs;
using DatosEMC.IRepositories;
using DatosEMC.Migrations;
using NegocioEMC.Commons;
using NegocioEMC.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Services
{
    public class VentaNumeroService : IVentaNumeroService
    {
        private readonly IMapper mapper;
        private readonly IVentaNumeroRepository _ventaNumeroRepository;

        public VentaNumeroService(IVentaNumeroRepository ventaNumeroRepository, IMapper mapper)
        {
            this._ventaNumeroRepository = ventaNumeroRepository;
            this.mapper = mapper;
        }

        public GenericResponse AddVentaNumeroAsync(VentaNumeroDTO model)
        {

            var x = this.mapper.Map<VentaNumero>(model);
            x.Identificador = EngineTool.CreateUniqueidentifier();
            x.FechaVenta = DateTime.Now.Date;
            x.Activo = true;
            x = this._ventaNumeroRepository.AddVentaNumeroAsync(x);

            if (x.Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public GenericResponse AddVentaNumeroAsync(List<VentaNumeroDTO> lst)
        {
             var ide =   EngineTool.CreateUniqueidentifier();
             var lstVentaNumero = new List<VentaNumero>();
            foreach(var model in lst)
            {
                var x = this.mapper.Map<VentaNumero>(model);
                x.Identificador = ide;
                x.FechaVenta = DateTime.Now.Date;
                x.Activo = true;
                x = this._ventaNumeroRepository.AddVentaNumeroAsync(x);
                lstVentaNumero.Add(x);
            }

            var verificated = lstVentaNumero.Where(s => s.Id == 0).ToList().Count;
            if (verificated == 0)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");
            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }



        public GenericResponse UpdateVentaNumeroAsync(VentaNumeroDTO model)
        {
            var x = this.mapper.Map<VentaNumero>(model);
            x = this._ventaNumeroRepository.UpdateVentaNumeroAsync(x);

            if (x.Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido actualizada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo actualizar la información");
        }

        public GenericResponse UpdateVentaNumeroAsync(List<VentaNumeroDTO> model)
        {
            var x = this.mapper.Map<List<VentaNumero>>(model);
            x = this._ventaNumeroRepository.UpdateVentaNumeroAsync(x);

            if (x[0].Id > 0)
                return EngineService.SetGenericResponse(true, "La información ha sido actualizada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo actualizar la información");
        }

        public List<Loterias> GetLoterias()
        {
            return this._ventaNumeroRepository.GetLoterias();
        }

        public VentaNumeroDTO GetPremio(int idEmpresa, int numero, string loteria,string ticket)
        {
           var x = this._ventaNumeroRepository.GetPremio(idEmpresa,numero,loteria,ticket);

           return  this.mapper.Map<VentaNumeroDTO>(x);
        }
        public List<VentaNumeroDTO > GetPremiados(int idEmpresa, int numero, DateTime fecha,string loteria)
        {
            var x = this._ventaNumeroRepository.GetPremiados(idEmpresa, numero, fecha,loteria);

            return this.mapper.Map<List<VentaNumeroDTO>>(x);
        }

        public List<VentaNumeroDTO> GetListaVenta(DateTime fecha, string loteria, int id)
        {
            var x = this._ventaNumeroRepository.GetListaVenta(fecha ,loteria,id);
            var dto = this.mapper.Map<List<VentaNumeroDTO>>(x);

                dto[0].TotalVendido = x.Sum(x => x.Monto);

            return dto;
        }

        public List<VentaNumeroDTO> GetTicket( string ticket,int id)
        {
            var x = this._ventaNumeroRepository.GetTicket(ticket,id);
            var dto = this.mapper.Map<List<VentaNumeroDTO>>(x);

            dto[0].TotalVendido = x.Sum(x => x.Monto);

            return dto;
        }

        public GenericResponse DeleteVentaNumeroById(int id)
        {
            var result = this._ventaNumeroRepository.DeleteVentaNumeroById(id);
            if (result)
                return EngineService.SetGenericResponse(true, "La información ha sido eliminada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public GenericResponse DeleteVentaNumeroTicket(string ticket,int id)
        {
            var result = this._ventaNumeroRepository.DeleteVentaNumeroTicket(ticket,id);
            if (result)
                return EngineService.SetGenericResponse(true, "La información ha sido eliminada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public NumeroTicketDTO GetNumeroTicket(int id)
        {
            var x = this._ventaNumeroRepository.GetNumeroTicket(id);
            
            return x;
        }
    }
}
