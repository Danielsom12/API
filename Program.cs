// Chamando as Referencias que Iremos Usar 
using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;

// Fazendo a conexão com o banco e Definindo a Versão e o tipo do banco
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");

builder.Services.AddDbContext<FilmeContext>(opts => 
opts.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0))));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
