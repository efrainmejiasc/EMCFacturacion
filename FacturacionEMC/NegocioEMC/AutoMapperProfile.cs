using AutoMapper;
using DatosEMC.DataModels;
using DatosEMC.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
            CreateMap<EmpresaDTO, Empresa>().ReverseMap();
            CreateMap<ProveedorDTO, Proveedor>().ReverseMap();
            CreateMap<FacturaCompraDTO, FacturaCompra>().ReverseMap();
            CreateMap<FacturaCompraDetalleDTO, FacturaCompraDetalle>().ReverseMap();
            CreateMap<FacturaVentaDTO, FacturaVenta>().ReverseMap();
            CreateMap<FacturaVentaDetalleDTO, FacturaVentaDetalle>().ReverseMap();
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<StockTotalDTO, StockTotal>().ReverseMap();
            CreateMap<StockBodegaDTO, StockBodega>().ReverseMap();
            CreateMap<StockTransitoDTO, StockTransito>().ReverseMap();
            CreateMap<MetodoPagoDTO, MetodoPago>().ReverseMap();
            CreateMap<UnidadMedidaDTO, UnidadMedida>().ReverseMap();
            CreateMap<ProductoDTO, Producto>().ReverseMap();
            CreateMap<InicioFacturacionDTO, InicioFacturacion>().ReverseMap();
            CreateMap<ProductoImgInfoDTO, ProductoImgInfo>().ReverseMap();
            CreateMap<ProductoImgDTO, ProductoImg>().ReverseMap();
        }
    }
}
