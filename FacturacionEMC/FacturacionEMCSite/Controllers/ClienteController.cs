﻿using DatosEMC.DTOs;
using EMCApi.Client;
using FacturacionEMCSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCSite.Controllers
{
    public class ClienteController : Controller
    {
        private readonly EMCApi.Client.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

        public ClienteController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
        {
            clientApi = _clienteApi;
            httpContext = _httpContext;

            if (!string.IsNullOrEmpty(httpContext.HttpContext.Session.GetString("UserLogin")))
                this.usuario = JsonConvert.DeserializeObject<EMCApi.Client.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            ICollection<EMCApi.Client.ClienteDTO> clientes = new List<EMCApi.Client.ClienteDTO>();

            if (this.usuario != null)
                clientes = await this.clientApi.GetClientesAsync(this.usuario.IdEmpresa);

            return Json(clientes);
        }


        [HttpPost]
        public async Task<IActionResult> Agregarcliente(EMCApi.Client.ClienteDTO cliente)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                cliente.IdEmpresa = usuario.IdEmpresa;
                cliente.Fecha = cliente.FechaModificacion = DateTime.Now;
                cliente.Activo = true;
                var savecliente = await this.clientApi.PostClienteAsync(cliente);

                response.Estatus = savecliente.Ok ? true : false;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }
    }
}
