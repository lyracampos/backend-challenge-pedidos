using Xunit;
using BackendChallenge.Pedidos.Domain.Entities;

namespace BackendChallenge.Pedidos.Tests.Domain.Entities
{
    public class ItemTests
    {
        [Fact]
        public void DeveInstanciarPedidoValido()
        {
            var item = ItemMock.ItemValido();
            Assert.True(item.IsValid);
        }

        [Fact]
        public void DeveInstanciarPedidoInvalido()
        {
            var item = ItemMock.ItemInvalido();
            Assert.False(item.IsValid);
        }
    }

    public static class ItemMock
    {
        public static Item ItemValido() => new Item("item a", 120, 1);

        public static Item ItemInvalido() => new Item("", 0, 0);
    }
}
