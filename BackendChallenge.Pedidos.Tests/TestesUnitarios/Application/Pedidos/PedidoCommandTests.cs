using BackendChallenge.Pedidos.Application.UseCases.Pedidos;
using Xunit;

namespace BackendChallenge.Pedidos.Tests.TestesUnitarios.Application.Pedidos
{
    public class PedidoCommandTests
    {
        [Fact]
        public void DeveMapearPedidoCommandParaPedidoEntidade()
        {
            var pedidoCommand = new PedidoCommand();
            pedidoCommand.Itens.Add(new ItemCommand() { Produto = "Produto 1", Preco = 10, Quantidade = 1 });

            var pedidoEntidade = pedidoCommand.MapEntity();

            Assert.NotNull(pedidoEntidade);
            Assert.Equal(pedidoEntidade.TotalDeItens, pedidoCommand.TotalDeItens);
        }
    }
}
