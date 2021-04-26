using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos;
using Newtonsoft.Json;
using Xunit;

namespace BackendChallenge.Pedidos.Tests.TestesIntegrados.Api
{
    public class PedidoControllerTests : BaseControllerTests
    {
        [Fact]
        public async Task DeveCriarUmPedidoComSucesso()
        {
            var command = new PedidoCommand();
            command.Itens.Add(new ItemCommand { Produto = "Item A", Preco = 10, Quantidade = 2 });
            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("/api/pedido", content);
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task DeveAtualizarUmPedidoComSucesso()
        {
            AdicionarPedidoNaBase();
            var command = new PedidoCommand();
            command.Itens.Add(new ItemCommand { Produto = "Item A", Preco = 100, Quantidade = 5 });
            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync("/api/pedido/1", content);
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeveBuscarUmPedidoComSucesso()
        { 
            AdicionarPedidoNaBase();

            var response = await httpClient.GetAsync("/api/pedido/1");
            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeveRemoverUmPedidoComSucesso()
        {
            AdicionarPedidoNaBase();
            
            var response = await httpClient.DeleteAsync("/api/pedido/1");
            
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
