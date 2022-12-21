using DatosEMC.DTOs;
using EMCApi.Client;
using FacturacionEMCSite.Application;
using FacturacionEMCSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NegocioEMC.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FacturacionEMCSite.Controllers
{
    public class ProductosManagerController : Controller
    {
        private readonly DatosEMC.DTOs.UsuarioDTO usuario;
        private readonly ClientEMCApi clientApi;
        private readonly IHttpContextAccessor httpContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductosManagerController(ClientEMCApi _clienteApi, IHttpContextAccessor _httpContext, IWebHostEnvironment _webHostEnvironment)
        {
            this.httpContext = _httpContext;
            this.clientApi = _clienteApi;
            this._webHostEnvironment = _webHostEnvironment;

            if (!string.IsNullOrEmpty(httpContext.HttpContext.Session.GetString("UserLogin")))
                this.usuario = JsonConvert.DeserializeObject<DatosEMC.DTOs.UsuarioDTO>(httpContext.HttpContext.Session.GetString("UserLogin"));

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadDataImg(List<IFormFile> files)
        {
            var response = new RespuestaModel();
            response.Estatus = false;
            response.Identidades = new List<string>();
            response.Nombres = new List<string>();
            var nombresArchivos = new List<string>();
            try
            {
                foreach (var file in files)
                {
                    if (!nombresArchivos.Contains(file.Name))
                    {
                        var p = file.FileName.Replace("_", "").Replace("/", "").Replace(" ", "").Replace("-", "").Split('.');
                        var identificador = EngineTool.CreateUniqueidentifier();
                        var strIdentificador = identificador.ToString().ToUpper();
                        var name = p[0] + "_" + strIdentificador + "_.jpg".Replace(" ", "");
                        response.Nombres.Add(name);
                        response.Identidades.Add(strIdentificador);

                        EngineTool.CreateFolder(this._webHostEnvironment.WebRootPath, AppMethods.PathFolderImgProducts, strIdentificador);
                        var pathReadFile = this._webHostEnvironment.WebRootPath + AppMethods.PathFolderImgProducts + strIdentificador + "\\" + name;
                        var stream = System.IO.File.Create(pathReadFile);
                        file.CopyTo(stream);
                        stream.Dispose();
                    }
                }

                response.Estatus = true;
                response.Descripcion = "EXITO";
            }
            catch(Exception ex)
            {
                response.Descripcion = ex.Message;
            }

            return Json(response);
        }


        [HttpPost]
        public IActionResult UploadParametrosImg([FromBody] ProductManagerImgDTO productManagerImgDTO)
        {
            var response = new RespuestaModel();
            response.Estatus = false;
            var limite = productManagerImgDTO.Identidades.Count  -  1;
            try
            {
                for (int i = 0; i <= limite; i++)
                {

                }

                response.Estatus = true;
                response.Descripcion = "EXITO";
            }
            catch (Exception ex)
            {
                response.Descripcion = ex.Message;
            }

            return Json(response);
        }
    }
}
