using System.Net.Http;
using BackendChallenge.Pedidos.Api;
using BackendChallenge.Pedidos.Application.Repositories;
using BackendChallenge.Pedidos.Domain.Entities;
using BackendChallenge.Pedidos.Infrastructure;
using BackendChallenge.Pedidos.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BackendChallenge.Pedidos.Tests.TestesIntegrados.Api
{
    public abstract class BaseControllerTests
    {
        protected readonly HttpClient httpClient;
        protected readonly IPedidoRepository pedidoRepository;

        public BaseControllerTests()
        {
            var factory = new WebApplicationFactory<Startup>();
            httpClient = factory.CreateClient();
            this.pedidoRepository = new PedidoRepository(new PedidoContext());
        }

        protected void AdicionarPedidoNaBase()
        {
            var pedido = new Pedido();
            pedido.AdicionarItem(new Item("Produto A", 120, 10));
            pedidoRepository.AdicionarAsync(pedido);
        }
    }
}
