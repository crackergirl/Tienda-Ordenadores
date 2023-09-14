using TiendaOrdenadoresAPI.Data;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services;

namespace TiendaOrdenadoresAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // A�ado la conexion a ADO SQL
        builder.Services.AddScoped(c =>
        {
            var connectionString = builder.Configuration.GetConnectionString("TiendaOrdenadoresDBContext") ?? "";
            var dataDirectory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\.."));
            connectionString = connectionString.Replace("|DataDirectory|", dataDirectory);

            return new ADOContext(connectionString);
        });

        builder.Services.AddScoped<IRepositorio<Componente>, RepositorioComponenteADO>();
        builder.Services.AddScoped<IRepositorio<Ordenador>, RepositorioOrdenadorADO>();
        builder.Services.AddScoped<IRepositorio<OrdenadorComponente>, RespositorioOrdenadorComponenteADO>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}

