using System;
namespace BackendChallenge.Pedidos.Application.Exceptions
{
    public class PedidoNaoEncontradoException : Exception
    {
        public PedidoNaoEncontradoException(string message) : base(message)
        {
        }
    }
}
