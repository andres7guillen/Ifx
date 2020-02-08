using IfxData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfxDomain.Repositorio
{
    public interface IEmpleadoRepositorio
    {
        Task<Empleado> Obtener(Guid IdEmpleado);
        Task<List<Empleado>> ObtenerTodos();
        Task<Empleado> Crear(Empleado modelo);
        Task<Empleado> Actualizar(Empleado modelo);
        Task<bool> Eliminar(Guid IdEmpleado);

    }
}
