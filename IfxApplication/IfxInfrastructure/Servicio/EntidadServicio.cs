using IfxData.Entities;
using IfxDomain.Repositorio;
using IfxDomain.Servicio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfxInfrastructure.Servicio
{
    public class EntidadServicio : IEntidadServicio
    {
        private readonly IEntidadRepositorio _repositorio;
        public EntidadServicio(IEntidadRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Entidad> Actualizar(Entidad Model) => await _repositorio.Actualizar(Model);

        public async Task<Entidad> Crear(Entidad modelo) => await _repositorio.Crear(modelo);

        public async Task<bool> Eliminar(Guid EntidadId) => await _repositorio.Eliminar(EntidadId);

        public async Task<Entidad> Obtener(Guid EntidadId) => await _repositorio.Obtener(EntidadId);

        public async Task<List<Entidad>> obtenerTodas() => await _repositorio.obtenerTodas();
    }
}
