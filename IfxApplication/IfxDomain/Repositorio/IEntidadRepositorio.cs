using IfxData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfxDomain.Repositorio
{
    public interface IEntidadRepositorio
    {
        Task<List<Entidad>> obtenerTodas();
        Task<Entidad> Crear(Entidad modelo);

        Task<Entidad> Actualizar(Entidad Model);
        Task<bool> Eliminar(Guid EntidadId);
        Task<Entidad> Obtener(Guid EntidadId);
    }
}
