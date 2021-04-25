using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.Exceptions;
using BackendChallenge.Pedidos.Application.Repositories;

namespace BackendChallenge.Pedidos.Application.UseCases.Pedidos.Atualizar
{
    public class AtualizarPedidoHandler : IAtualizarPedidoHandler
    {
        private readonly IPedidoRepository pedidoRepository;

        public AtualizarPedidoHandler(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoResult> ExecutarAsync(int id, PedidoCommand command)
        {
            var pedidoDb = await pedidoRepository.BuscarAsync(id);

            if (pedidoDb == null)
                throw new PedidoNaoEncontradoException($"Pedido {id} não encontrado");

            pedidoDb.Atualizar(command.MapEntity());

            await pedidoRepository.AtualizarAsync(pedidoDb);

            return new PedidoResult(pedidoDb);
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
        public void Dispose() => Dispose(true);
    }
}
