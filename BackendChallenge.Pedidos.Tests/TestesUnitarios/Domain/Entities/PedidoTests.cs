using System.Collections.Generic;
using System.Linq;
using BackendChallenge.Pedidos.Domain.Entities;
using Xunit;
namespace BackendChallenge.Pedidos.Tests.TestesUnitarios.Domain.Entities
{
    public class PedidoTests
    {
        [Fact]
        public void DeveInstanciarPedidoValido()
        {
            var pedido = new Pedido();
            pedido.AdicionarItem(ItemMock.ItemValido());
            Assert.True(pedido.IsValid);
        }

        [Fact]
        public void DeveInstanciarPedidoInvalido()
        {
            var pedido = new Pedido();
            Assert.False(pedido.IsValid);
        }

        [Fact]
        public void AdicionarItemValidoAoPedido()
        {
            var pedido = new Pedido();
            var quantidadeInicial = pedido.TotalDeItens;

            pedido.AdicionarItem(ItemMock.ItemValido());

            Assert.True(quantidadeInicial < pedido.TotalDeItens);
        }

        [Fact]
        public void NaoAdicionarItemInvalidoAoPedido()
        {
            var pedido = new Pedido();
            var quantidadeInicial = pedido.TotalDeItens;

            pedido.AdicionarItem(ItemMock.ItemInvalido());

            Assert.True(quantidadeInicial == pedido.TotalDeItens);
        }

        [Fact]
        public void RemoverItemDoPedido()
        {
            var pedido = new Pedido();
            var item = ItemMock.ItemValido();
            pedido.AdicionarItem(item);
            var quantidadeInicial = pedido.Itens?.Count;

            pedido.RemoverItem(item.Produto);

            Assert.True(quantidadeInicial > pedido.TotalDeItens);
        }

        [Fact]
        public void DeveCalcularValorTotal()
        {
            var pedido = new Pedido();
            var item = ItemMock.ItemValido();
            pedido.AdicionarItem(item);

            Assert.Equal(pedido.ValorTotal, pedido.Itens.Sum(p => p.Total));
        }

        [Fact]
        public void DeveCalcularTotalDeItens()
        {
            var pedido = new Pedido();
            var item = ItemMock.ItemValido();
            pedido.AdicionarItem(item);

            Assert.Equal(pedido.TotalDeItens, pedido.Itens.Count);
        }

        [Fact]
        public void DeveAtualizarPedidoComSucesso()
        {
            var pedido = new Pedido();
            var item = ItemMock.ItemValido();
            pedido.AdicionarItem(item);
            var totalItemInicio = pedido.TotalDeItens;

            pedido.Atualizar(new List<Item> { ItemMock.ItemValido(), ItemMock.ItemValido(), ItemMock.ItemValido() });
            Assert.NotEqual(pedido.TotalDeItens, totalItemInicio);
        }
    }
}
