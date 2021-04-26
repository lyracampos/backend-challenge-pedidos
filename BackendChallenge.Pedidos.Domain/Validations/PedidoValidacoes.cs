using BackendChallenge.Pedidos.Domain.Entities;
using FluentValidation;

namespace BackendChallenge.Pedidos.Domain.Validations
{
    public class PedidoValidacoes : AbstractValidator<Pedido>
    {
        public PedidoValidacoes()
        {
            RuleFor(p => p.TotalDeItens).GreaterThan(0)
                .WithMessage("O pedido deve ter ao menos um item");
        }
    }
}
