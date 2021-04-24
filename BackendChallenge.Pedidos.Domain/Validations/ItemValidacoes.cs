using FluentValidation;
using BackendChallenge.Pedidos.Domain.Entities;
namespace BackendChallenge.Pedidos.Domain.Validations
{
    public class ItemValidacoes : AbstractValidator<Item>
    {
        public ItemValidacoes()
        {
            RuleFor(p => p.Produto)
                .NotNull().NotEmpty()
                .WithMessage("O produto deve ser informado.");

            RuleFor(p => p.Preco)
                .NotNull().GreaterThan(0)
                .WithMessage("O preço deve ser valor maior que 0.");

            RuleFor(p => p.Quantidade)
                .NotNull().NotEmpty().GreaterThan(0)
                .WithMessage("A quantidade do produto deve ser informada e maior que 0.");
        }
    }
}
