using System;
using System.Threading.Tasks;

namespace BackendChallenge.Pedidos.Application.UseCases.Pedidos.Criar
{
    public interface ICriarPedidoHandler : IDisposable
    {
        Task<PedidoResult> ExecutarAsync(PedidoCommand command);
    }
}
