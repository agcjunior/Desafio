using FluentValidation;

namespace Desafio.Aplicacao.Generos.AlterarGenero
{
    public class AlterarGeneroCommandValidator : AbstractValidator<AlterarGeneroCommand>
    {
        public AlterarGeneroCommandValidator()
        {
            RuleFor(x => x.nome)
                .NotEmpty().WithMessage("O nome do gênero não pode ser vazio ou conter apenas espaços em branco.")
                .MaximumLength(100).WithMessage("O nome do gênero deve ter no máximo 100 caracteres.");
        }
    }
}
