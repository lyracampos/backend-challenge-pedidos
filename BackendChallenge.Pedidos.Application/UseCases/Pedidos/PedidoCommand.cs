using System.Collections.Generic;
using System.Linq;
using BackendChallenge.Pedidos.Domain.Entities;
using BackendChallenge.Pedidos.Domain.ValueObjects;

namespace BackendChallenge.Pedidos.Application.UseCases.Pedidos
{
    public class PedidoCommand
    {
        public PedidoCommand()
        {
            Itens = new List<ItemCommand>();
        }
        public IList<ItemCommand> Itens { get; set; }

        public Pedido MapEntity() => new Pedido(MapItens());
        private List<Item> MapItens() => Itens.Select(p => p.MapEntity()).ToList();
        public int TotalDeItens { get { return Itens != null ? Itens.Count : 0; } }
        public decimal ValorTotal { get { return Itens != null ? Itens.Sum(p => p.Total) : 0; } }
    }

    public class ItemCommand : ItemValueObject
    {
        public Item MapEntity() => new Item(Produto, Preco, Quantidade);
    }
}
