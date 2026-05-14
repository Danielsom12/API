using Dapper;
using FilmesApi.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient; // Importante para usar o MySqlConnection do MySQL

namespace FilmesApi.Repositories;

public class FilmeRepository : IFilmeRepository
{
    private readonly string _connectionString;
    public FilmeRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
        ?? throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi configurada.");
    }

    public async Task<IEnumerable<Filme>> ListarTodosAsync()
    {
        var sql = "SELECT * FROM filme.Filmes";

        // O 'using var' garante que a conexão será fechada e descartada ao fim deste método
        using var connection = new MySqlConnection(_connectionString);

        // Chamamos o Dapper diretamente na conexão que acabamos de criar
        return await connection.QueryAsync<Filme>(sql);
    }

    public async Task<Filme?> BuscarPorIdAsync(int id)
    {
        var sql = "SELECT * FROM filme.Filmes WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        return await connection.QueryFirstOrDefaultAsync<Filme>(sql, new { Id = id });
    }

    public async Task<bool> CriarAsync(Filme filme)
    {
        var sql = @"INSERT INTO filme.Filmes (Titulo, Genero, Duracao) 
                    VALUES (@Titulo, @Genero, @Duracao);
                    SELECT LAST_INSERT_ID();";

        using var connection = new MySqlConnection(_connectionString);

        // Executa o insert e retorna o ID gerado pelo MySQL
        var idGerado = await connection.QuerySingleAsync<int>(sql, filme);

        filme.Id = idGerado;
        return idGerado > 0;
    }

    public async Task<bool> AtualizarAsync(Filme filme)
    {
        var sql = @"UPDATE filme.Filmes 
                    SET Titulo = @Titulo, Genero = @Genero, Duracao = @Duracao 
                    WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        var rows = await connection.ExecuteAsync(sql, filme);
        return rows > 0;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var sql = "DELETE FROM filme.Filmes WHERE Id = @Id";

        using var connection = new MySqlConnection(_connectionString);
        var rows = await connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }
}