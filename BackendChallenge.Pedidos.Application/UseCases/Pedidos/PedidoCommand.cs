using System.Collections.Generic;
using System.Linq;
using BackendChallenge.Pedidos.Domain.Entities;

namespace BackendChallenge.Pedidos.Application.UseCases.Pedidos
{
    public class PedidoCommand
    {
        public IList<ItemCommand> Itens { get; set; }

        public Pedido MapEntity() => new Pedido(Itens.Select(p => p.MapEntity()).ToList());
    }

    public class ItemCommand
    {
        public string Produto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }

        public Item MapEntity() => new Item(Produto, Preco, Quantidade);
    }
}
