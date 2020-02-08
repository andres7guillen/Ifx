using IfxData.Context;
using IfxData.Entities;
using IfxDomain.Repositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IfxInfrastructure.Repositorio
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private ApplicationDbContext _context;

        public EmpleadoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Empleado> Actualizar(Empleado modelo)
        {
            _context.Empleados.Update(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<Empleado> Crear(Empleado modelo)
        {
            modelo.Id = Guid.NewGuid();
            await _context.Empleados.AddAsync(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> Eliminar(Guid IdEmpleado)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Id == IdEmpleado);
            _context.Empleados.Remove(empleado);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Empleado> Obtener(Guid IdEmpleado)
        {
            return await _context.Empleados.FirstOrDefaultAsync(e => e.Id == IdEmpleado);
        }

        public async Task<List<Empleado>> ObtenerTodos()
        {
            return await _context.Empleados.ToListAsync();
        }
    }
}
