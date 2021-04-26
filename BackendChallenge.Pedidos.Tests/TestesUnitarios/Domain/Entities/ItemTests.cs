using Xunit;
using BackendChallenge.Pedidos.Domain.Entities;

namespace BackendChallenge.Pedidos.Tests.TestesUnitarios.Domain.Entities
{
    public class ItemTests
    {
        [Fact]
        public void DeveInstanciarItemValido()
        {
            var item = ItemMock.ItemValido();
            Assert.True(item.IsValid);
        }

        [Fact]
        public void DeveInstanciarItemInvalido()
        {
            var item = ItemMock.ItemInvalido();
            Assert.False(item.IsValid);
        }

        [Fact]
        public void DeveAtualizarItemComSucesso()
        {
            var item = ItemMock.ItemValido();
            item.Atualizar("item b", 10, 2);
            Assert.NotEqual(item.Produto, ItemMock.ItemValido().Produto);
            Assert.NotEqual(item.Preco, ItemMock.ItemValido().Preco);
            Assert.NotEqual(item.Quantidade, ItemMock.ItemValido().Quantidade);
        }

        [Fact]
        public void DeveCalcularTotalDoItem()
        {
            var item = ItemMock.ItemValido();
            Assert.Equal(item.Total, ItemMock.ItemValido().Total);
        }
    }

    public static class ItemMock
    {
        public static Item ItemValido() => new Item("item a", 120, 1);

        public static Item ItemInvalido() => new Item("", 0, 0);
    }
}
