using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Filme
{

        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int Duracao { get; set; }
    }
}