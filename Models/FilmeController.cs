namespace FilmesApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using Microsoft.Extensions.Localization;

[ApiController]
[Route("[controller]")]

public class FilmeController : ControllerBase
{
       private static List<Filme> filmes = new List<Filme>();
        private static int id =0;

        [HttpPost]

        public void AdicionaFilme([FromBody]Filme filme){
           
           filme.Id = id++;
           filmes.Add(filme);
        }

        [HttpGet]
        public IEnumerable<Filme> GetFilmes([FromQuery]int skip = 0 ,
        [FromQuery] int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }
        [HttpGet("{id}")]
         public IActionResult GetFilmesId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        else {return Ok(filme);
    }
    
    }}
