using EMCApi.Client;
using FacturacionEMCSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCSite.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly EMCApi.Client.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;

        public UsuarioController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext)
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

        public IActionResult About()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUsuarioAsync(EMCApi.Client.UsuarioDTO usuarioDTO) 
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                usuarioDTO.IdEmpresa = usuario.IdEmpresa;
                usuarioDTO.Fecha = DateTime.Now;
                usuarioDTO.Activo = true;
                var noPassword64 = usuarioDTO.Password;
                usuarioDTO.Password = EngineTool.EnCodeBase64(usuarioDTO.Email + noPassword64);
                usuarioDTO.Password2 = EngineTool.EnCodeBase64(usuarioDTO.Username + noPassword64);

                var saveusuario = await this.clientApi.PostUsuarioAsync(usuarioDTO);

                response.Estatus = saveusuario.Ok ? true : false;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEstatusUsuarioAsync(EMCApi.Client.UsuarioDTO usuarioDTO)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                var updateusuario = await this.clientApi.UpdateEstatusUsuarioAsync(usuarioDTO);

                response.Estatus = updateusuario.Ok ? true : false;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            ICollection<EMCApi.Client.UsuarioDTO> usuariosDTO = new List<EMCApi.Client.UsuarioDTO>();

            try
            {
                if (this.usuario != null)
                    usuariosDTO = await this.clientApi.GeUsuariosAsync(this.usuario.IdEmpresa);
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(usuariosDTO);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUsuarioAsync(EMCApi.Client.UsuarioDTO usuarioDTO)
        {
            var response = new RespuestaModel();
            response.Estatus = false;

            try
            {
                var deleteusuario = await this.clientApi.EliminarUsuarioAsync(usuarioDTO);

                response.Estatus = deleteusuario.Ok ? true : false;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
            }

            return Json(response);
        }
    }
}
