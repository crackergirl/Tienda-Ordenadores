using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLog;
using Polly;
using Polly.Extensions.Http;
using TiendaOrdenadoresDB.Data;
using TiendaOrdenadoresDB.Logging;
using TiendaOrdenadoresDB.Mapper;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Services;
using TiendaOrdenadoresDB.Services.API;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TiendaOrdenadoresDBContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("TiendaOrdenadoresDBContext") ?? "";
                var dataDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\.."));
                connectionString = connectionString.Replace("|DataDirectory|", dataDirectory);


                options.UseSqlServer(connectionString ??
                                     throw new InvalidOperationException(
                                         "Connection string 'TiendaContext' not found."));
            });

            LogManager.Setup()
                .LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            builder.Services.AddHttpClient("MyHttpClient")
               .AddPolicyHandler(GetCircuitBreakerPolicy());

            builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
            builder.Services.AddScoped<IRepositorio<Componente>, RepositorioComponenteAPI>();
            builder.Services.AddScoped<IRepositorio<Ordenador>, RepositorioOrdenadorAPI>();
            builder.Services.AddScoped<IRepositorio<OrdenadorComponente>, RepositorioOrdenadorComponenteAPI>();
            builder.Services.AddScoped<IRepositorio<Pedido>, RepositorioPedidoDB>();
            builder.Services.AddScoped<IRepositorio<OrdenadorPedido>, RepositorioOrdenadorPedidoDB>();

            //Configuracion automapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperComponentes());
                cfg.AddProfile(new AutoMapperOrdenador());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

        private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 3, 
                    durationOfBreak: TimeSpan.FromSeconds(30) 
                );
        }
    }
}