using System.Linq;
using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.Repositories;
using BackendChallenge.Pedidos.Application.UseCases.Status;
using BackendChallenge.Pedidos.Application.UseCases.Status.StatusPedido;
using BackendChallenge.Pedidos.Domain.Entities;
using BackendChallenge.Pedidos.Tests.TestesUnitarios.Domain.Entities;
using Moq;
using Xunit;

namespace BackendChallenge.Pedidos.Tests.TestesUnitarios.Application.Status
{
    public class StatusPedidoHandlerTests
    {
        private readonly Mock<IPedidoRepository> pedidoRepository;
        private readonly IStatusPedidoHandler statusPedidoHandler;

        public StatusPedidoHandlerTests()
        {
            this.pedidoRepository = new Mock<IPedidoRepository>();
            this.statusPedidoHandler = new StatusPedidoHandler(pedidoRepository.Object);
        }

        [Fact]
        public async Task DeveRetornarCodidoPedidoInvalido()
        {
            // arrange
            var command = new StatusPedidoCommand{ ItensAprovados = 3, Pedido = 1, Status = StatusPedidoType.APROVADO.ToString(), ValorAprovado = 30 };

            Pedido pedidoDb = null;
            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);

            // act
            var result = await statusPedidoHandler.ExecutarAsync(command);

            // arrange
            Assert.Contains(StatusPedidoType.CODIGO_PEDIDO_INVALIDO.ToString(), result.Status);
        }

        [Fact]
        public async Task DeveRetornarReprovado()
        {
            // arrange
            var command = new StatusPedidoCommand { ItensAprovados = 3, Pedido = 1, Status = StatusPedidoType.REPROVADO.ToString(), ValorAprovado = 30 };

            var pedidoDb = new Pedido();
            pedidoDb.AdicionarItem(ItemMock.ItemValido());
            pedidoDb.AdicionarItem(ItemMock.ItemValido());
            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);

            // act
            var result = await statusPedidoHandler.ExecutarAsync(command);

            // arrange
            Assert.Contains(StatusPedidoType.REPROVADO.ToString(), result.Status);
        }

        [Fact]
        public async Task DeveRetornarAprovado()
        {
            // arrange
            var command = new StatusPedidoCommand { ItensAprovados = 1, Pedido = 1, Status = StatusPedidoType.APROVADO.ToString(), ValorAprovado = 12 };
            var pedidoDb = new Pedido();
            pedidoDb.AdicionarItem(new Item("Produto A", 12, 1));
            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);

            // act
            var result = await statusPedidoHandler.ExecutarAsync(command);

            // arrange
            Assert.Contains(StatusPedidoType.APROVADO.ToString(), result.Status);
        }

        [Fact]
        public async Task DeveRetornarAprovadoValorMenor()
        {
            // arrange
            var command = new StatusPedidoCommand { ItensAprovados = 1, Pedido = 1, Status = StatusPedidoType.APROVADO.ToString(), ValorAprovado = 11 };
            var pedidoDb = new Pedido();
            pedidoDb.AdicionarItem(new Item("Produto A", 12, 1));
            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);

            // act
            var result = await statusPedidoHandler.ExecutarAsync(command);

            // arrange
            Assert.Contains(StatusPedidoType.APROVADO_VALOR_A_MENOR.ToString(), result.Status);
        }

        [Fact]
        public async Task DeveRetornarAprovadoQuantidadeMenor()
        {
            // arrange
            var command = new StatusPedidoCommand { ItensAprovados = 1, Pedido = 1, Status = StatusPedidoType.APROVADO.ToString(), ValorAprovado = 20 };
            var pedidoDb = new Pedido();
            pedidoDb.AdicionarItem(new Item("Produto A", 10, 2));
            pedidoDb.AdicionarItem(new Item("Produto B", 10, 1));
            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);

            // act
            var result = await statusPedidoHandler.ExecutarAsync(command);

            // arrange
            Assert.Contains(StatusPedidoType.APROVADO_QTD_A_MENOR.ToString(), result.Status);
        }

        [Fact]
        public async Task DeveRetornarAprovadoValorMaior()
        {
            // arrange
            var command = new StatusPedidoCommand { ItensAprovados = 1, Pedido = 1, Status = StatusPedidoType.APROVADO.ToString(), ValorAprovado = 13 };
            var pedidoDb = new Pedido();
            pedidoDb.AdicionarItem(new Item("Produto A", 12, 1));
            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);

            // act
            var result = await statusPedidoHandler.ExecutarAsync(command);

            // arrange
            Assert.Contains(StatusPedidoType.APROVADO_VALOR_A_MAIOR.ToString(), result.Status);
        }

        [Fact]
        public async Task DeveRetornarAprovadoQuantidadeMaior()
        {
            // arrange
            var command = new StatusPedidoCommand { ItensAprovados = 2, Pedido = 1, Status = StatusPedidoType.APROVADO.ToString(), ValorAprovado = 20 };
            var pedidoDb = new Pedido();
            pedidoDb.AdicionarItem(new Item("Produto A", 10, 2));
            pedidoRepository.Setup(p => p.BuscarAsync(1)).ReturnsAsync(pedidoDb);

            // act
            var result = await statusPedidoHandler.ExecutarAsync(command);

            // arrange
            Assert.Contains(StatusPedidoType.APROVADO_QTD_A_MAIOR.ToString(), result.Status);
        }
    }
}
