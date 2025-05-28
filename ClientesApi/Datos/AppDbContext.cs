using ClientesApi.DTOs;
using ClientesApi.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ClientesApi.Datos
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClienteDTO>().HasNoKey();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pais> Paises { get; set; }
    }
}
