using System;
using System.Threading.Tasks;

namespace BackendChallenge.Pedidos.Application.UseCases.Pedidos.Atualizar
{
    public interface IAtualizarPedidoHandler : IDisposable
    {
        Task<PedidoResult> ExecutarAsync(int id, PedidoCommand command);
    }
}
