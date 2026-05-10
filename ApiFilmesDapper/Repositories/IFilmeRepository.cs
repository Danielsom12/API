using FilmesApi.Models;

namespace FilmesApi.Repositories;

public interface IFilmeRepository
{
    Task<IEnumerable<Filme>> ListarTodosAsync();
    Task<Filme?> BuscarPorIdAsync(int id);
    Task<bool> CriarAsync(Filme filme);
    Task<bool> AtualizarAsync(Filme filme);
    Task<bool> DeletarAsync(int id);
}