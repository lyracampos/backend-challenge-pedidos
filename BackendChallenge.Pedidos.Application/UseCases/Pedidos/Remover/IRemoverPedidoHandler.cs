using System;
using System.Threading.Tasks;
namespace BackendChallenge.Pedidos.Application.UseCases.Pedidos.Remover
{
    public interface IRemoverPedidoHandler : IDisposable
    {
        Task ExecutarAsync(int id);
    }
}
