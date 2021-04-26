using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.Repositories;
using BackendChallenge.Pedidos.Domain.Entities;

namespace BackendChallenge.Pedidos.Application.UseCases.Status.StatusPedido
{
    public class StatusPedidoHandler : IStatusPedidoHandler
    {
        private readonly IPedidoRepository pedidoRepository;
        private Pedido pedido { get; set; }
        private StatusPedidoCommand command { get; set; }
        private bool pedidoExisteNoBanco;

        public StatusPedidoHandler(IPedidoRepository pedidoReposito)
        {
            this.pedidoRepository = pedidoReposito;
        }

        public async Task<StatusPedidoResult> ExecutarAsync(StatusPedidoCommand command)
        {
            this.command = command;

            this.pedido = await pedidoRepository.BuscarAsync(command.Pedido);
            this.pedidoExisteNoBanco = pedido != null;
            var verificarStatus = RetornarStatusDoPedido();

            return new StatusPedidoResult() { Pedido = command.Pedido, Status = verificarStatus };
        }

        public string[] RetornarStatusDoPedido()
        {
            var valoresDeStatusDoPedido = new Dictionary<StatusPedidoType, bool>
            {
                { StatusPedidoType.CODIGO_PEDIDO_INVALIDO, SePedidoInvalido() },
                { StatusPedidoType.REPROVADO, SePedidoReprovado() },
                { StatusPedidoType.APROVADO, SePedidoAprovado() },
                { StatusPedidoType.APROVADO_VALOR_A_MENOR, SePedidoAprovadoValorMenor() },
                { StatusPedidoType.APROVADO_QTD_A_MENOR, SePedidoAprovadoQuantidadeMenor() },
                { StatusPedidoType.APROVADO_VALOR_A_MAIOR, SePedidoAprovadoValorMaior() },
                { StatusPedidoType.APROVADO_QTD_A_MAIOR, SePedidoAprovadoQuantidadeMaior() },
            };

            return valoresDeStatusDoPedido.Where(p => p.Value == true).Select(p => p.Key.ToString()).ToArray();
        }

        private bool SePedidoInvalido() =>
            !this.pedidoExisteNoBanco;

        private bool SePedidoReprovado() =>
            this.pedidoExisteNoBanco && this.command.Status == StatusPedidoType.REPROVADO.ToString();

        private bool SePedidoAprovado() =>
            this.pedidoExisteNoBanco && this.command.ItensAprovados == this.pedido.TotalDeItens &&
            this.command.ValorAprovado == this.pedido.ValorTotal &&
            this.command.Status == StatusPedidoType.APROVADO.ToString();

        private bool SePedidoAprovadoValorMenor() =>
            pedidoExisteNoBanco &&
            this.command.ValorAprovado < this.pedido.ValorTotal &&
            this.command.Status == StatusPedidoType.APROVADO.ToString();

        private bool SePedidoAprovadoQuantidadeMenor() =>
            pedidoExisteNoBanco &&
            this.command.ItensAprovados < this.pedido.TotalDeItens &&
            this.command.Status == StatusPedidoType.APROVADO.ToString();

        private bool SePedidoAprovadoValorMaior() =>
            pedidoExisteNoBanco &&
            this.command.ValorAprovado > this.pedido.ValorTotal &&
            this.command.Status == StatusPedidoType.APROVADO.ToString();

        private bool SePedidoAprovadoQuantidadeMaior() =>
            pedidoExisteNoBanco &&
            this.command.ItensAprovados > this.pedido.TotalDeItens &&
            this.command.Status == StatusPedidoType.APROVADO.ToString();

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }
        public void Dispose() => Dispose(true);
    }
}