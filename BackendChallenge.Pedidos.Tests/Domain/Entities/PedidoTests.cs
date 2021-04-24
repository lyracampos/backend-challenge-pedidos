using BackendChallenge.Pedidos.Domain.Entities;
using Xunit;
namespace BackendChallenge.Pedidos.Tests.Domain.Entities
{
    public class PedidoTests
    {
        [Fact]
        public void AdicionarItemValidoAoPedido()
        {
            var pedido = new Pedido();
            var quantidadeInicial = pedido.TotalItens;

            pedido.AdicionarItem(ItemMock.ItemValido());

            Assert.True(quantidadeInicial < pedido.TotalItens);
        }

        [Fact]
        public void NaoAdicionarItemInvalidoAoPedido()
        {
            var pedido = new Pedido();
            var quantidadeInicial = pedido.TotalItens;

            pedido.AdicionarItem(ItemMock.ItemInvalido());

            Assert.True(quantidadeInicial == pedido.TotalItens);
        }

        [Fact]
        public void RemoverItemDoPedido()
        {
            var pedido = new Pedido();
            var item = ItemMock.ItemValido();
            pedido.AdicionarItem(item);
            var quantidadeInicial = pedido.Itens?.Count;

            pedido.RemoverItem(item.Produto);

            Assert.True(quantidadeInicial > pedido.TotalItens);
        }
    }
}
