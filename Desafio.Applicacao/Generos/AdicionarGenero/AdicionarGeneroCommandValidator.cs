using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Aplicacao.Generos.AdicionarGenero
{
    public class AdicionarGeneroCommandValidator : AbstractValidator<AdicionarGeneroCommand>
    {
        public AdicionarGeneroCommandValidator()
        {
            RuleFor(x => x.nome)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
