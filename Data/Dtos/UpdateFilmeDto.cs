using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class UpdateFilmeDto
{
    // Campo Obrigatório / Limite Máximo de Caracteres 50
    [Required(ErrorMessage = "O Título do Filme é Obrigatório")]
    [StringLength(50, ErrorMessage = "O Titulo não pode ultrapassar 50 caracteres")]
    public string Titulo { get; set; } = string.Empty;

    // Campo Obrigatório / Limite Máximo de Caracteres 50
    [Required(ErrorMessage = "O Genero do Filme é Obrigatório")]
    [StringLength(50, ErrorMessage = "O Genero não pode ultrapassar 50 caracteres")]
    public string Genero { get; set; } = string.Empty;

    // Campo Obrigatório / Duração entre 70 e 600
    [Required]
    [Range(70, 600, ErrorMessage = "A Duração deve ser entre 70 e 600 minutos")]
    public int Duracao { get; set; }

}
