using System;
using System.Threading.Tasks;
namespace BackendChallenge.Pedidos.Application.UseCases.Status.StatusPedido
{
    public interface IStatusPedidoHandler : IDisposable
    {
         Task<StatusPedidoResult> ExecutarAsync(StatusPedidoCommand command);
    }
}