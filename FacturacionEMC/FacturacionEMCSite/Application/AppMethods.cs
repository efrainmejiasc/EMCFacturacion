
using DatosEMC.DTOs;
using NegocioEMC.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionEMCSite.Application
{
    public class AppMethods
    {
        public static string PathFolderImgProducts { get; set; }

        public static EMCApi.Client.ProductoImgInfoDTO SetProductImgInfo(ProductManagerImgDTO productoImgInfoDTO)
        {
            var productoImgInfo = new EMCApi.Client.ProductoImgInfoDTO()
            {
                Id = 0,
                Nombre = productoImgInfoDTO.Nombre,
                Categoria = productoImgInfoDTO.Categoria,
                Peso = productoImgInfoDTO.Peso,
                Tamaño = productoImgInfoDTO.Tamaño,
                Descripcion = productoImgInfoDTO.Descripcion
            };

            return productoImgInfo;
        }

        public static List<EMCApi.Client.ProductoImgDTO> SetProductImg(ProductManagerImgDTO productoImgInfoDTO, int productoImgInfoId, string webrootpath)
        {
            var lst = new List<EMCApi.Client.ProductoImgDTO>();
            var limite = productoImgInfoDTO.Identidades.Count - 1;
            for (int i = 0; i <= limite; i++)
            {
                var productoImg = new EMCApi.Client.ProductoImgDTO()
                {
                    Id = 0,
                    ProductoImgInfoId = productoImgInfoId,
                    Identificador = productoImgInfoDTO.Identidades[i],
                    NombreArchivo = productoImgInfoDTO.NombresImg[i],
                    Ubicacion = webrootpath + productoImgInfoDTO.Identidades[i] + "//" + productoImgInfoDTO.NombresImg[i],
                    StrBase64 = EngineImg.ConvertImageToBase64Str(webrootpath + productoImgInfoDTO.Identidades[i] + "//" + productoImgInfoDTO.NombresImg[i])
                };

                lst.Add(productoImg);
            }

            return lst;
        }
    }
}
