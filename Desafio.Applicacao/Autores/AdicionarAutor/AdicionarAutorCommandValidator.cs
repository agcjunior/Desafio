using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Aplicacao.Autores.AdicionarAutor
{
    public class AdicionarAutorCommandValidator : AbstractValidator<AdicionarAutorCommand>
    {
        public AdicionarAutorCommandValidator()
        {
            RuleFor(x => x.nome)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
