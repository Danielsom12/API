// Definição do Contexto e Como irá acessar o banco 

// Chamando as Referencias que Iremos Usar 
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using FilmesApi.Models;


namespace FilmesApi.Data;

// Criando a Classe com argumentos para se conectar ao banco
public class FilmeContext : DbContext
{
public FilmeContext(DbContextOptions<FilmeContext> opts)
: base (opts)
{
    
}

public DbSet<Filme> Filmes { get; set; }


}