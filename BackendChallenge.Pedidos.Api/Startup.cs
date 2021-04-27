using System;
using System.IO;
using System.Reflection;
using BackendChallenge.Pedidos.Application.Repositories;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos.Atualizar;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos.Criar;
using BackendChallenge.Pedidos.Application.UseCases.Pedidos.Remover;
using BackendChallenge.Pedidos.Application.UseCases.Status.StatusPedido;
using BackendChallenge.Pedidos.Infrastructure;
using BackendChallenge.Pedidos.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BackendChallenge.Pedidos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BackendChallenge.Pedidos",
                    Version = "v1",
                    Description = "Api para acompanhamento de pedidos.",
                    Contact = new OpenApiContact
                    {
                        Name = "Guilherme Lyra Campos",
                        Url = new Uri("https://github.com/lyracampos")
                    },
                });
                c.CustomSchemaIds(_ => _.FullName);

                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddTransient<ICriarPedidoHandler, CriarPedidoHandler>();
            services.AddTransient<IAtualizarPedidoHandler, AtualizarPedidoHandler>();
            services.AddTransient<IRemoverPedidoHandler, RemoverPedidoHandler>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IStatusPedidoHandler, StatusPedidoHandler>();
            services.AddDbContext<PedidoContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackendChallenge.Pedidos.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
