using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendChallenge.Pedidos.Domain.Entities
{
    public class Pedido : Entidade
    {
        public Pedido()
        {

        }

        public Pedido(ICollection<Item> itens)
        {
            Itens = itens;
        }

        public virtual ICollection<Item> Itens { get; set; }

        public int TotalDeItens { get { return Itens != null ? Itens.Count : 0; } }
        public decimal ValorTotal { get { return Itens != null ? Itens.Sum(p => p.Total) : 0; } }
        public void AdicionarItem(Item item)
        {
            if (item.IsValid)
                Itens?.Add(item);
        }

        public void RemoverItem(string produto)
        {
            Itens?.Remove(Itens.FirstOrDefault(i => i.Produto.ToLowerInvariant().Equals(produto.ToLowerInvariant())));
        }

        public void Atualizar(Pedido pedido)
        {
            base.Atualizar();
            if (TotalDeItens > 0)
            {
                Itens = null;
                Itens = pedido.Itens;
            }
        }
        public override bool IsValid { get; protected set; }

        protected override bool Validar()
        {
            return true;
        }
    }
}
