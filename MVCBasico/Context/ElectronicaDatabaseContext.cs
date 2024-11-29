using Microsoft.EntityFrameworkCore;
using MVCBasico.Models;

namespace MVCBasico.Context
{
    public class ElectronicaDatabaseContext : DbContext
    {
        public ElectronicaDatabaseContext(DbContextOptions<ElectronicaDatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auricular>().ToTable("Auriculares");
            modelBuilder.Entity<Celular>().ToTable("Celulares");
            modelBuilder.Entity<Computadora>().ToTable("Computadoras");
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Auricular> Auriculares { get; set; }
        public DbSet<Celular> Celulares { get; set; }
        public DbSet<Computadora> Computadoras { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }

    }
}
