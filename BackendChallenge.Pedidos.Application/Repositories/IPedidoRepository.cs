using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendChallenge.Pedidos.Domain.Entities;

namespace BackendChallenge.Pedidos.Application.Repositories
{
    public interface IPedidoRepository : IDisposable
    {
        Task AdicionarAsync(Pedido pedido);
        Task AtualizarAsync(Pedido pedido);
        Task RemoverAsync(int id);
        Task<Pedido> BuscarAsync(int id);
        Task<IEnumerable<Pedido>> ListarAsync();
    }
}
