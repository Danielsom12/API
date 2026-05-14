using FilmesApi.Models;
using FilmesApi.Repositories;
using FluentValidation; // IMPORTANTE: Para reconhecer o IValidator
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly IFilmeRepository _repository;
    private readonly IValidator<Filme> _validator; // Adicionado o validador aqui

    // O construtor deve receber o repositório E o validador
    public FilmeController(IFilmeRepository repository, IValidator<Filme> validator)
    {
        _repository = repository;
        _validator = validator;
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
        
        var validationResult = await _validator.ValidateAsync(filme);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.ToDictionary());
        }

        var sucesso = await _repository.CriarAsync(filme);
        return CreatedAtAction(nameof(GetById), new { id = filme.Id }, filme);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Filme filme)
    {
        filme.Id = id;
        
        var validationResult = await _validator.ValidateAsync(filme);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.ToDictionary());
        }

        var sucesso = await _repository.AtualizarAsync(filme);
        return Ok(new { mensagem = "Filme Editado com sucesso!" });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var sucesso = await _repository.DeletarAsync(id);
        return sucesso ? Ok("Filme deletado com sucesso.") : NotFound();
    }
}