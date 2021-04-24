using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.Repositories;

namespace BackendChallenge.Pedidos.Application.UseCases.Pedidos.Criar
{
    public class CriarPedidoHandler : ICriarPedidoHandler
    {
        private readonly IPedidoRepository pedidoRepository;

        public CriarPedidoHandler(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoResult> ExecutarAsync(PedidoCommand command)
        {
            var pedido = command.MapEntity();

            await pedidoRepository.AdicionarAsync(pedido);

            return new PedidoResult(pedido);
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
