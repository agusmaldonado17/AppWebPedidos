using AppWebPedidos.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebPedidos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Una categoría no puede eliminarse si tiene platos.
            modelBuilder.Entity<Plato>()
                .HasOne(p => p.Categoria)
                .WithMany()
                .HasForeignKey(p => p.IdCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            // Al eliminar un pedido también se eliminan sus detalles.
            modelBuilder.Entity<DetallePedido>()
                .HasOne(d => d.Pedido)
                .WithMany(p => p.Detalles)
                .HasForeignKey(d => d.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);

            // No permitimos eliminar un plato que ya aparece
            // en pedidos históricos.
            modelBuilder.Entity<DetallePedido>()
                .HasOne(d => d.Plato)
                .WithMany()
                .HasForeignKey(d => d.IdPlato)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}