using IfxData.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfxDomain.Servicio
{
    public interface IEntidadServicio
    {
        Task<List<Entidad>> obtenerTodas();
        Task<Entidad> Crear(Entidad modelo);
    }
}
