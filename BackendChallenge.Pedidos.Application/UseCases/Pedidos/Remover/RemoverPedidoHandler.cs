using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.Exceptions;
using BackendChallenge.Pedidos.Application.Repositories;

namespace BackendChallenge.Pedidos.Application.UseCases.Pedidos.Remover
{
    public class RemoverPedidoHandler : IRemoverPedidoHandler
    {
        private readonly IPedidoRepository pedidoRepository;

        public RemoverPedidoHandler(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public async Task ExecutarAsync(int id)
        {
            var pedidoDb = await pedidoRepository.BuscarAsync(id);
            if (pedidoDb == null)
                throw new PedidoNaoEncontradoException($"Pedido {id} não encontrado");

            await pedidoRepository.RemoverAsync(id);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
                pedidoRepository.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
