
// Chamando as Referencias que Iremos Usar 
namespace FilmesApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using Microsoft.Extensions.Localization;

// Definindo o Tipo de API e qual o Caminho que iremos usar --> https://localhost:7106/Filme/
[ApiController]
[Route("[controller]")]

// Criando a classe e Referenciando a ControllerBase -> Comandos de Api
public class FilmeController : ControllerBase
{
        // Criando a Lista de Filmes e Criando o Id
       private static List<Filme> filmes = new List<Filme>();
        private static int id =0;

        // Metodo POST para inserir Informações na lista por meio de Json / Ex: {"Titulo": "Minha Mãe é uma Peça", "Genero": "Comédia", "Duracao": 85}
        [HttpPost]
        public IActionResult AdicionaFilme([FromBody]Filme filme){
           
           filme.Id = id++;
           filmes.Add(filme);
          return CreatedAtAction(nameof(GetFilmesId), 
          new{id = filme.Id}, filme);
        }

        // Metodo GET para viasualizar todos os filmes da lista / Skip-> quantos filmes desejamos pular na exibição / Take-> quantos queremos apresentar
        [HttpGet]
        public IEnumerable<Filme> GetFilmes([FromQuery]int skip = 0 ,
        [FromQuery] int take = 50)
    {
        return filmes.Skip(skip).Take(take);
    }
    // Metodo GET para exibir apenas 1 filme com base no seu Id, se não existir o id ele retorna um erro 404 NotFound
        [HttpGet("{id}")]
         public IActionResult GetFilmesId(int id)
    {
        var filme = filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        return Ok(filme);
    }
    
    }
