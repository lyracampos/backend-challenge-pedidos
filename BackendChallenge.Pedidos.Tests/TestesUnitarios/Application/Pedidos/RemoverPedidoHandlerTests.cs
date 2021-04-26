using System;
using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.Exceptions;
using BackendChallenge.Pedidos.Application.Repositories;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos.Remover;
using BackendChallenge.Pedidos.Domain.Entities;
using BackendChallenge.Pedidos.Tests.TestesUnitarios.Domain.Entities;
using Moq;
using Xunit;

namespace BackendChallenge.Pedidos.Tests.TestesUnitarios.Application.Pedidos
{
    public class RemoverPedidoHandlerTests
    {
        private readonly Mock<IPedidoRepository> pedidoRepository;
        private readonly IRemoverPedidoHandler removerPedidoHandler;

        public RemoverPedidoHandlerTests()
        {
            this.pedidoRepository = new Mock<IPedidoRepository>();
            this.removerPedidoHandler = new RemoverPedidoHandler(pedidoRepository.Object);
        }

        [Fact]
        public async Task DeveRemoverPedidoComSucesso()
        {
            // arrange
            var id = 1;
            var pedidoDb = new Pedido();
            pedidoDb.AdicionarItem(ItemMock.ItemValido());

            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);
            pedidoRepository.Setup(p => p.RemoverAsync(id));

            // act
            await this.removerPedidoHandler.ExecutarAsync(id);

            // assert
            pedidoRepository.Verify(p => p.RemoverAsync(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task NaoDeveRemoverPedido()
        {
            // arrange
            var id = 1;
            Pedido pedidoDb = null;
            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);

            // act
            var result = await Record.ExceptionAsync(() => removerPedidoHandler.ExecutarAsync(id));

            // assert
            Assert.IsType<PedidoNaoEncontradoException>(result);
            pedidoRepository.Verify(p => p.RemoverAsync(It.IsAny<int>()), Times.Never);
        }
    }
}
