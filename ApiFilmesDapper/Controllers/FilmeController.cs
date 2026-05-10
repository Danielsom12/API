using FilmesApi.Models;
using FilmesApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")] // A rota será api/filme
public class FilmeController : ControllerBase
{
    private readonly IFilmeRepository _repository;

    public FilmeController(IFilmeRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var filmes = await _repository.ListarTodosAsync();
        return Ok(filmes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var filme = await _repository.BuscarPorIdAsync(id);
        return filme is not null ? Ok(filme) : NotFound("Filme não encontrado.");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Filme filme)
    {
        var sucesso = await _repository.CriarAsync(filme);
        if (!sucesso) return BadRequest();
        return CreatedAtAction(nameof(GetById), new { id = filme.Id }, filme);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Filme filme)
    {
        filme.Id = id;
        var sucesso = await _repository.AtualizarAsync(filme);
        return sucesso ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sucesso = await _repository.DeletarAsync(id);
        return sucesso ? Ok("Filme deletado com sucesso.") : NotFound();
    }
}