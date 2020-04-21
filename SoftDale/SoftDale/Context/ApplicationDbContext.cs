using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftDale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftDale.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
             

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Servicio> Servicios { get; set; }

        public DbSet<Pais> Pais { get; set; }
        public DbSet<ClienteXServicio> ClienteXServicios { get; set; }

        public DbSet<ClienteSevicioXPais> ClienteSevicioXPais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<UserInfo>().ToTable("UserInfo");
            //modelBuilder.Entity<Cliente>().ToTable("Clientes");
            //modelBuilder.Entity<Servicio>().ToTable("Servicios");
            //modelBuilder.Entity<Pais>().ToTable("Pais");
            //modelBuilder.Entity<ClienteXServicio>().ToTable("ClienteXServicios");
            //modelBuilder.Entity<ClienteSevicioXPais>().ToTable("ClienteSevicioXPais");
        }

    }
}
