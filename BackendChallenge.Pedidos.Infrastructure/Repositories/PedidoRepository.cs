using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.Repositories;
using BackendChallenge.Pedidos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendChallenge.Pedidos.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext context;

        public PedidoRepository(PedidoContext context)
        {
            this.context = context;
        }

        public async Task AdicionarAsync(Pedido pedido)
        {
            try
            {
                await context.Pedidos.AddAsync(pedido);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task AtualizarAsync(Pedido pedido)
        {
            context.Update(pedido);
            await context.SaveChangesAsync();
        }

        public async Task<Pedido> BuscarAsync(int id) => await context.Pedidos.Include(p => p.Itens).FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Pedido>> ListarAsync() => await context.Pedidos.OrderBy(p => p.DataCriacao).ToArrayAsync();

        public async Task RemoverAsync(int id)
        {
            var pedido = context.Pedidos.FindAsync(id).Result;
            context.Remove(pedido);
            await context.SaveChangesAsync();
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
