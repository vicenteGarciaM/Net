using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Clientes)
                .WithMany()
                .HasForeignKey(c => c.IdCliente);

            modelBuilder.Entity<Inventario>()
                .HasOne(i => i.Tiendas)
                .WithMany()
                .HasForeignKey(i => i.IdTienda);
        }
    }
}
