using FluentValidation;
using FilmesApi.Models;

public class CriarFilmesValidation : AbstractValidator<Filme>
{
    public CriarFilmesValidation()
    {
            RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("O título do filme é obrigatório.")
            .MaximumLength(150).WithMessage("O título não pode passar de 150 caracteres.");

        RuleFor(x => x.Genero)
            .NotEmpty().WithMessage("O Gênero é obrigatório.");

        RuleFor(x => x.Duracao)
            .GreaterThan(0).WithMessage("A Duração deve ser maior que zero.");
    }
}