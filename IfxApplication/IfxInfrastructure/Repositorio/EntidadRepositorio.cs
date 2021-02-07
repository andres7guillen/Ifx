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
    public class EntidadRepositorio : IEntidadRepositorio
    {
        private readonly ApplicationDbContext _context;
        public EntidadRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Entidad> Actualizar(Entidad model)
        {
            _context.Entidades.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Entidad> Crear(Entidad modelo)
        {
            try
            {
                modelo.Id = Guid.NewGuid();
                await _context.Entidades.AddAsync(modelo);
                await _context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<bool> Eliminar(Guid EntidadId)
        {
            var entidad = await _context.Entidades.FirstOrDefaultAsync(e => e.Id == EntidadId);
            _context.Entidades.Remove(entidad);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Entidad> Obtener(Guid EntidadId)
        {
            return await _context.Entidades.FirstOrDefaultAsync(e => e.Id == EntidadId);
        }

        public async Task<List<Entidad>> obtenerTodas()
        {
            return await _context.Entidades.ToListAsync();
        }
    }
}
