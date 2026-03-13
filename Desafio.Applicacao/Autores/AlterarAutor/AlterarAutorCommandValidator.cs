using FluentValidation;

namespace Desafio.Aplicacao.Autores.AlterarAutor
{
    public class AlterarAutorCommandValidator : AbstractValidator<AlterarAutorCommand>
    {
        public AlterarAutorCommandValidator()
        {
            RuleFor(x => x.nome)
                .NotEmpty().WithMessage("O nome do autor não pode ser vazio ou conter apenas espaços em branco.")
                .MaximumLength(100).WithMessage("O nome do autor deve ter no máximo 100 caracteres.");
        }
    }
}
