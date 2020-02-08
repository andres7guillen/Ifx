using IfxData.Entities;
using IfxDomain.Repositorio;
using IfxDomain.Servicio;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfxInfrastructure.Servicio
{
    public class EmpleadoServicio : IEmpleadoServicio
    {
        private IEmpleadoRepositorio _repositorio;
        public EmpleadoServicio(IEmpleadoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<Empleado> Actualizar(Empleado modelo) => await _repositorio.Actualizar(modelo);

        public async Task<Empleado> Crear(Empleado modelo) => await _repositorio.Crear(modelo);

        public async Task<bool> Eliminar(Guid IdEmpleado) => await _repositorio.Eliminar(IdEmpleado);

        public async Task<Empleado> Obtener(Guid IdEmpleado) => await _repositorio.Obtener(IdEmpleado);

        public async Task<List<Empleado>> ObtenerTodos() => await _repositorio.ObtenerTodos();
    }
}
