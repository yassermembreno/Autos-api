using Application.Interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Test
{
    public class ApplicationFactoryTest<Program> : WebApplicationFactory<Program> where Program : class
    {
        private ApplicationFixture? _applicationFixture;
       
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            _applicationFixture = new ApplicationFixture();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Configurar servicios de la aplicación
            builder.ConfigureServices(services =>
            {
                AddInfrastructureServices(services, _applicationFixture);
            });

            builder.ConfigureAppConfiguration(config =>
            {
                config.Sources.Clear();
                config.AddConfiguration(configuration);
            });
        }

        private static void AddInfrastructureServices(IServiceCollection services, ApplicationFixture applicationFixture)
        {
            // Remover todos los servicios inyectados
            services.RemoveAll<IMarcaAutoRepository>();
            services.RemoveAll<IMarcaAutosService>();
            
            //Mock Services
            services.AddScoped(_ => applicationFixture.marcaAutoService.Object);

            // Mock Repositories
            services.AddScoped(_ => applicationFixture.marcaAutoRepository.Object);
          

        }
    }
}
