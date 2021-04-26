using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.UseCases.Status;
using Newtonsoft.Json;
using Xunit;

namespace BackendChallenge.Pedidos.Tests.TestesIntegrados.Api
{
    public class StatusControllerTests : BaseControllerTests
    {
        [Fact]
        public async Task DeveVerificarStatusDoPedidoComSucesso()
        {
            // arrange
            AdicionarPedidoNaBase();
            var command = new StatusPedidoCommand { ItensAprovados = 4, Pedido = 1, Status = "APROVADO", ValorAprovado = 120 };
            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

            // act
            var response = await httpClient.PostAsync("/api/status", content);
            response.EnsureSuccessStatusCode();

            // assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
