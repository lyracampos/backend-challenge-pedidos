namespace BackendChallenge.Pedidos.Application.UseCases.Status
{
    public class StatusPedidoResult
    {
        public int Pedido { get; set; }
        public string[] Status { get; set; }
    }

    public enum StatusPedidoType
    {
        CODIGO_PEDIDO_INVALIDO,
        REPROVADO,
        APROVADO,
        APROVADO_VALOR_A_MENOR,
        APROVADO_QTD_A_MENOR,
        APROVADO_VALOR_A_MAIOR,
        APROVADO_QTD_A_MAIOR,
    }
}