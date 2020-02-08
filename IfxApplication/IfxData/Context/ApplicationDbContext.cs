using IfxData.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IfxData.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var roleAdmin = new IdentityRole()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Name = "admin",
            //    NormalizedName = "admin",
            //    ConcurrencyStamp = "0663BAE8-C5C5-48AE-92AC-D747ADC14EAE"
            //};
            //modelBuilder.Entity<UserRole>().HasData(roleAdmin);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entidad>()
                .HasMany(e => e.Empleados)
                .WithOne(c => c.Entidad);
        }


    }
}
