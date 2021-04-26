using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.Repositories;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos.Criar;
using Moq;
using Xunit;

namespace BackendChallenge.Pedidos.Tests.TestesUnitarios.Application.Pedidos
{
    public class CriarPedidoHandlerTests
    {
        private readonly Mock<IPedidoRepository> pedidoRepository;
        private readonly ICriarPedidoHandler criarPedidoHandler;

        public CriarPedidoHandlerTests()
        {
            this.pedidoRepository = new Mock<IPedidoRepository>();
            this.criarPedidoHandler = new CriarPedidoHandler(pedidoRepository.Object);
        }

        [Fact]
        public async Task DeveCriarPedidoComSucesso()
        {
            // arrange
            var command = new PedidoCommand();
            command.Itens.Add(new ItemCommand() { Produto = "Produto 1", Preco = 10, Quantidade = 1 });

            pedidoRepository.Setup(p => p.AdicionarAsync(command.MapEntity()));

            // act
            var result = await this.criarPedidoHandler.ExecutarAsync(command);

            // assert
            Assert.NotNull(result);
            Assert.Equal(result.TotalDeItens, command.Itens.Count);
        }
    }
}
