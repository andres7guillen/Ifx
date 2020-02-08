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
        public async Task<Entidad> Crear(Entidad modelo) => await _repositorio.Crear(modelo);

        public async Task<List<Entidad>> obtenerTodas() => await _repositorio.obtenerTodas();
    }
}
