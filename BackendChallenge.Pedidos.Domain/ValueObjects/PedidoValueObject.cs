using System.Collections.Generic;
using System.Linq;

namespace BackendChallenge.Pedidos.Domain.ValueObjects
{
    public class PedidoValueObject
    {
        public virtual IList<ItemValueObject> Itens { get; set; }
        public int TotalDeItens { get { return Itens != null ? Itens.Count : 0; } }
        public decimal ValorTotal { get { return Itens != null ? Itens.Sum(p => p.Total) : 0; } }
    }
}
