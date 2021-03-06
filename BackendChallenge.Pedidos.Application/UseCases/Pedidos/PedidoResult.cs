using System.Collections.Generic;
using System.Linq;
using BackendChallenge.Pedidos.Domain.Entities;
using BackendChallenge.Pedidos.Domain.ValueObjects;

namespace BackendChallenge.Pedidos.Application.UseCases.Pedidos
{
    public class PedidoResult
    {
        public PedidoResult(Pedido pedido)
        {
            Numero = pedido.Id;
            Itens = pedido.Itens?.Select(p => new ItemResult(p.Produto, p.Preco, p.Quantidade)).ToList();
        }
        public int Numero { get; set; }
        public IList<ItemResult> Itens { get; set; }
        public int TotalDeItens { get { return Itens != null ? Itens.Count : 0; } }
        public decimal ValorTotal { get { return Itens != null ? Itens.Sum(p => p.Total) : 0; } }
    }

    public class ItemResult : ItemValueObject
    {
        public ItemResult(string produto, decimal preco, int quantidade)
            : base(produto, preco, quantidade) { }
    }
}
