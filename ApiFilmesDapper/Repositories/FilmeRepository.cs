using Dapper;
using FilmesApi.Data;
using FilmesApi.Models;

namespace FilmesApi.Repositories;

public class FilmeRepository : IFilmeRepository
{
    private readonly DbSession _session;

    public FilmeRepository(DbSession session)
    {
        _session = session;
    }

    public async Task<IEnumerable<Filme>> ListarTodosAsync()
    {
        return await _session.Connection.QueryAsync<Filme>("SELECT * FROM filme.Filmes f");
    }

    public async Task<Filme?> BuscarPorIdAsync(int id)
    {
        // Usamos @Id para evitar SQL Injection
        var sql = "SELECT * FROM filme.Filmes f WHERE f.Id = @Id";
        return await _session.Connection.QueryFirstOrDefaultAsync<Filme>(sql, new { Id = id });
    }

public async Task<bool> CriarAsync(Filme filme)
{
    // Adicionamos o SELECT LAST_INSERT_ID() ao final do comando
    var sql = @"INSERT INTO Filmes (Titulo, Genero, Duracao) 
                VALUES (@Titulo, @Genero, @Duracao);
                SELECT LAST_INSERT_ID();";
    
    // Usamos QuerySingleAsync para pegar o ID gerado
    var idGerado = await _session.Connection.QuerySingleAsync<int>(sql, filme);
    
    // Atribuímos o ID de volta ao objeto filme
    filme.Id = idGerado;
    
    return idGerado > 0;
}

    public async Task<bool> AtualizarAsync(Filme filme)
    {
        var sql = @"UPDATE filme.Filmes f
                    SET Titulo = @Titulo, Genero = @Genero, Duracao = @Duracao 
                    WHERE f.Id = @Id";
        var rows = await _session.Connection.ExecuteAsync(sql, filme);
        return rows > 0;
    }

    public async Task<bool> DeletarAsync(int id)
    {
        var sql = "DELETE FROM filme.Filmes f WHERE f.Id = @Id";
        var rows = await _session.Connection.ExecuteAsync(sql, new { Id = id });
        return rows > 0;
    }
}