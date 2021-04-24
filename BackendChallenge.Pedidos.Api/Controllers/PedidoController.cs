using System;
using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.Exceptions;
using BackendChallenge.Pedidos.Application.Repositories;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos.Atualizar;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos.Criar;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos.Remover;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.Pedidos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoRepository pedidoRepository;

        public PedidoController(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        /// <summary>
        /// criar um pedido
        /// </summary>
        /// <param name="command">payload do pedido</param>
        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] PedidoCommand command, [FromServices] ICriarPedidoHandler handler)
        {
            try
            {
                var pedido = await handler.ExecutarAsync(command);
                return Created($"api/pedido/{pedido.Numero}", pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// atualizar pedido
        /// </summary>
        /// <param name="id">numero do pedido</param>
        /// <param name="command">payload do pedido</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPedido(int id, [FromBody] PedidoCommand command, [FromServices] IAtualizarPedidoHandler handler)
        {
            try
            {
                var pedido = await handler.ExecutarAsync(id, command);
                return Ok(pedido);
            }
            catch (PedidoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// buscar um pedudo
        /// </summary>
        /// <param name="id">numero do pedido</param>
        /// <returns>pedido do banco de dados</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PedidoResult), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> BuscarPedido(int id)
        {
            try
            {
                var pedido = await pedidoRepository.BuscarAsync(id);
                if (pedido != null)
                    return Ok(new PedidoResult(pedido));
                else
                    return NotFound($"Pedido {id} não encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// remover pedido
        /// </summary>
        /// <param name="id">numero do pedido</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverPedido(int id, [FromServices] IRemoverPedidoHandler handler)
        {
            try
            {
                await handler.ExecutarAsync(id);
                return NotFound();
            }
            catch (PedidoNaoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
