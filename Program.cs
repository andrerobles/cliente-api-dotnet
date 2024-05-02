using Microsoft.EntityFrameworkCore;

using ClienteApi.Services;
using ClienteApi.Data;
using ClienteApi.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (connectionString != null)
    {
        //options.UseNpgsql(connectionString); // Sem log de depuração

        options.UseNpgsql(connectionString)
               .LogTo(Console.WriteLine, LogLevel.Information); // Log de depuração
    }
});


//TODO: Adicionar uma classe posteriormente para injetar as dependencias
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepositoy>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
