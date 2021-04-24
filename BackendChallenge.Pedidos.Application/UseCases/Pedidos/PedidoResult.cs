using System.Collections.Generic;
using System.Linq;
using BackendChallenge.Pedidos.Domain.Entities;

namespace BackendChallenge.Pedidos.Application.UseCases.Pedidos
{
    public class PedidoResult
    {
        public PedidoResult(Pedido pedido)
        {
            Numero = pedido.Id;
            Itens = pedido.Itens.Select(p => new ItemResult(p.Produto, p.Preco, p.Quantidade)).ToList();
        }
        public int Numero { get; set; }
        public IList<ItemResult> Itens { get; set; }
    }

    public class ItemResult
    {
        public ItemResult(string produto, decimal preco, int quantidade)
        {
            Produto = produto;
            Preco = preco;
            Quantidade = quantidade;
        }

        public string Produto { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }        
    }
}
