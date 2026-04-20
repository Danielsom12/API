
// Chamando as Referencias que Iremos Usar 
namespace FilmesApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using FilmesApi.Models;
    using Microsoft.Extensions.Localization;
    using FilmesApi.Data;
    using FilmesApi.Data.Dtos;
    using AutoMapper;

    // Definindo o Tipo de API e qual o Caminho que iremos usar --> https://localhost:7106/Filme/
    [ApiController]
    [Route("[controller]")]

    // Criando a classe e Referenciando a ControllerBase -> Comandos de Api
    public class FilmeController : ControllerBase
    {       // Declarando o Contexto
            private FilmeContext _context;
            private IMapper _mapper;



        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Metodo POST para inserir Informações na lista por meio de Json / Ex: {"Titulo": "Minha Mãe é uma Peça", "Genero": "Comédia", "Duracao": 85}
        [HttpPost]
            public IActionResult AdicionaFilme([FromBody]CreateFilmeDto filmeDto)
            {

                    Filme filme = _mapper.Map<Filme>(filmeDto);

                _context.Filmes.Add(filme);
                _context.SaveChanges();
              return CreatedAtAction(nameof(GetFilmesId), 
              new{id = filme.Id}, filme);
            }

            // Metodo GET para viasualizar todos os filmes da lista / Skip-> quantos filmes desejamos pular na exibição / Take-> quantos queremos apresentar
            [HttpGet]
            public IEnumerable<Filme> GetFilmes([FromQuery]int skip = 0 ,
            [FromQuery] int take = 50)
        {
            return _context.Filmes.Skip(skip).Take(take);
        }
            // Metodo GET para exibir apenas 1 filme com base no seu Id, se não existir o id ele retorna um erro 404 NotFound
            [HttpGet("{id}")]
             public IActionResult GetFilmesId(int id)
        {
            var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
            if (filme == null) return NotFound();
            return Ok(filme);
        }
    
        }
}
