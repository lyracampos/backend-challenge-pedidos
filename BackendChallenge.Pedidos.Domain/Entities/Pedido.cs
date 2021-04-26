using System;
using System.Collections.Generic;
using System.Linq;
using BackendChallenge.Pedidos.Domain.Validations;

namespace BackendChallenge.Pedidos.Domain.Entities
{
    public class Pedido : Entidade
    {
        public Pedido()
        {
            Itens = new List<Item>();
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
        public void RemoverItem(string produto) => Itens?.Remove(Itens.FirstOrDefault(i => i.Produto.ToLowerInvariant().Equals(produto.ToLowerInvariant())));

        public void Atualizar(List<Item> itens)
        {
            base.Atualizar();
            if (TotalDeItens > 0)
            {
                Itens = null;
                Itens = itens;
            }
        }

        public override bool IsValid { get { return Validar(); } protected set { } }
        protected override bool Validar() => new PedidoValidacoes().Validate(this).IsValid;
    }
}
