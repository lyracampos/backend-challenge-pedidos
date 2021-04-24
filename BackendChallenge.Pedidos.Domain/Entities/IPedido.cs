using System;
namespace BackendChallenge.Pedidos.Domain.Entities
{
    public interface IPedido
    {
        void AdicionarItem(Item item);
        void RemoverItem(Item item);
    }
}
