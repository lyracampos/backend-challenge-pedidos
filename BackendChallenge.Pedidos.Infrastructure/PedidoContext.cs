using BackendChallenge.Pedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Pedidos.Infrastructure
{
    public class PedidoContext : DbContext
    {
        public PedidoContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BackendChallenge");
        }

        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var pedido = modelBuilder.Entity<Pedido>();
            pedido.HasKey(p => p.Id);
            pedido.HasMany(i => i.Itens).WithOne(p => p.Pedido);

            var item = modelBuilder.Entity<Item>();
            item.HasKey(p => p.Id);
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Item> Itens { get; set; }
    }
}
