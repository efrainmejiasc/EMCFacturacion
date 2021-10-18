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
    public class ProveedorService : IProveedorService
    {
        private readonly IMapper _mapper;
        private readonly IProveedorRepository proveedorRepository;

        public ProveedorService(IProveedorRepository _proveedorRepository, IMapper mapper)
        {
            this._mapper = mapper;
            this.proveedorRepository = _proveedorRepository;
        }

        public GenericResponse AddProveedor(ProveedorDTO proveedorDTO)
        {
            var proveedor = new Proveedor();
            proveedor = this._mapper.Map<Proveedor>(proveedorDTO);
            proveedor.Identificador = EngineTool.CreateUniqueidentifier();

            proveedor = this.proveedorRepository.AddProveedorAsync(proveedor);

            if (proveedor != null)
                return EngineService.SetGenericResponse(true, "La información ha sido registrada");

            else
                return EngineService.SetGenericResponse(false, "No se pudo registrar la información");
        }

        public List<ProveedorDTO> GetProveedores(int idEmpresa)
        {
            var proveedores = this.proveedorRepository.GetProveedores(idEmpresa);

            var proveedoresDTO = new List<ProveedorDTO>();
            proveedoresDTO = this._mapper.Map<List<ProveedorDTO>>(proveedores);

            return proveedoresDTO;
        }
    }
}
