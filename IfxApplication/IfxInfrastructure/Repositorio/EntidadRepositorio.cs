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
        public async Task<Entidad> Crear(Entidad modelo)
        {
            modelo.Id = Guid.NewGuid();
            await _context.Entidades.AddAsync(modelo);
            await _context.SaveChangesAsync();
            return modelo;
        }

        public async Task<List<Entidad>> obtenerTodas()
        {
            return await _context.Entidades.ToListAsync();
        }
    }
}
