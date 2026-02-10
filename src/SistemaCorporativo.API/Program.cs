using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaCorporativo.Aplicacao.Interfaces;
using SistemaCorporativo.Aplicacao.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); // Registrando controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrando nosso serviço de Funcionários (pode ser Singleton ou Scoped)
builder.Services.AddSingleton<IFuncionarioService, FuncionarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Mapear todos os controllers

app.Run();
