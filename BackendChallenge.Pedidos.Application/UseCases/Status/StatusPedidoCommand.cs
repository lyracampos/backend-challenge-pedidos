using System.ComponentModel.DataAnnotations;
namespace BackendChallenge.Pedidos.Application.UseCases.Status
{
    public class StatusPedidoCommand
    {
        [Required(ErrorMessage="Campo status é obrigatório.")]
        public string Status { get; set; }

        [Required(ErrorMessage="Campo itensAprovado é obrigatório.")]
        public int ItensAprovados { get; set; }

        [Required(ErrorMessage="Campo valorAprovado é obrigatório.")]
        public decimal ValorAprovado { get; set; }

        [Required(ErrorMessage="Campo pedido é obrigatório.")]
        public int Pedido { get; set; }
    }
}