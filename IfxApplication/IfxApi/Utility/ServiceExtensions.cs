using IfxDomain.Repositorio;
using IfxDomain.Servicio;
using IfxInfrastructure.Repositorio;
using IfxInfrastructure.Servicio;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IfxApi.Utility
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegistroServiciosNegocio(this IServiceCollection services)
        {
            services.AddScoped<IEmpleadoServicio, EmpleadoServicio>();
            services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();

            services.AddScoped<IEntidadServicio, EntidadServicio>();
            services.AddScoped<IEntidadRepositorio, EntidadRepositorio>();

            return services;
        }
    }
}
