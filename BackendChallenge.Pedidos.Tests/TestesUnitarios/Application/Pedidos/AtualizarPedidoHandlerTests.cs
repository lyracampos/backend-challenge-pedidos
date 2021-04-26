using System;
using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.Exceptions;
using BackendChallenge.Pedidos.Application.Repositories;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos.Atualizar;
using BackendChallenge.Pedidos.Domain.Entities;
using BackendChallenge.Pedidos.Tests.TestesUnitarios.Domain.Entities;
using Moq;
using Xunit;

namespace BackendChallenge.Pedidos.Tests.TestesUnitarios.Application.Pedidos
{
    public class AtualizarPedidoHandlerTests
    {
        private readonly Mock<IPedidoRepository> pedidoRepository;
        private readonly IAtualizarPedidoHandler atualizarPedidoHandler;

        public AtualizarPedidoHandlerTests()
        {
            this.pedidoRepository = new Mock<IPedidoRepository>();
            this.atualizarPedidoHandler = new AtualizarPedidoHandler(pedidoRepository.Object);
        }

        [Fact]
        public async Task DeveAtualizarPedidoComSucesso()
        {
            // arrange
            var command = new PedidoCommand();
            command.Itens.Add(new ItemCommand() { Produto = "Produto 1", Preco = 10, Quantidade = 1 });

            var pedidoDb = new Pedido();
            pedidoDb.AdicionarItem(ItemMock.ItemValido());
            pedidoDb.AdicionarItem(ItemMock.ItemValido());
            var totalItensDb = pedidoDb.TotalDeItens;

            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);
            pedidoRepository.Setup(p => p.AtualizarAsync(pedidoDb));

            // act
            var result = await this.atualizarPedidoHandler.ExecutarAsync(1, command);

            // assert
            Assert.NotEqual(result.TotalDeItens, totalItensDb);
            pedidoRepository.Verify(p => p.AtualizarAsync(It.IsAny<Pedido>()), Times.Once);
        }

        [Fact]
        public async Task NaoDeveAtualizarPedido()
        {
            // arrange
            var command = new PedidoCommand();
            command.Itens.Add(new ItemCommand() { Produto = "Produto 1", Preco = 10, Quantidade = 1 });
            Pedido pedidoDb = null;
            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);


            // act
            var result = await Record.ExceptionAsync(() => atualizarPedidoHandler.ExecutarAsync(1, command));

            // assert
            Assert.IsType<PedidoNaoEncontradoException>(result);
            pedidoRepository.Verify(p => p.AtualizarAsync(It.IsAny<Pedido>()), Times.Never);
        }
    }
}
