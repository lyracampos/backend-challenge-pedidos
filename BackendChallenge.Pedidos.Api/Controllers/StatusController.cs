using System;
using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.UseCases.Status;
using BackendChallenge.Pedidos.Application.UseCases.Status.StatusPedido;
using Microsoft.AspNetCore.Mvc;

namespace BackendChallenge.Pedidos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    {

        /// <summary>
        /// processa status do pedido
        /// </summary>
        /// <param name="command">playload das informações</param>
        /// <returns>status do pedido</returns>
        [HttpPost]
        public async Task<IActionResult> Status([FromBody] StatusPedidoCommand command, [FromServices] IStatusPedidoHandler handler)
        {
            try
            {
                var statusResult = await handler.ExecutarAsync(command);
                return Ok(statusResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
