using Atividade2.Repositories;
using Atividade2.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IProjetoRepository, ProjetoRepository>();
builder.Services.AddSingleton<IVisitaRepository, VisitaRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
