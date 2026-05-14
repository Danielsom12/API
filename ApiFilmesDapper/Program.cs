using FilmesApi.Data;
using FilmesApi.Repositories;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// 1. Adiciona suporte aos Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Injeção de Dependência (Dapper Session + Repo)
builder.Services.AddScoped<DbSession>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// 3. Configura o Swagger para testar a API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 4. Mapeia os Controllers automaticamente
app.MapControllers();

app.Run();