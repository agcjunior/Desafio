using FluentValidation;

namespace Desafio.Aplicacao.Livros.AdicionarLivro
{
    public class AdicionarLivroCommandValidator : AbstractValidator<AdicionarLivroCommand>
    {
        public AdicionarLivroCommandValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do livro não pode ser vazio.")
                .MaximumLength(200).WithMessage("O nome do livro deve ter no máximo 200 caracteres.");

            RuleFor(x => x.GeneroId)
                .NotEmpty().WithMessage("O gênero do livro deve ser informado.");

            RuleFor(x => x.AutorId)
                .NotEmpty().WithMessage("O autor do livro deve ser informado.");
        }
    }
}
