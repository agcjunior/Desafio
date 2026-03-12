using Desafio.Aplicacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Aplicacao.Autores.AdicionarAutor
{
    public record AdicionarAutorCommand(string nome) : ICommand<Guid>
    {
    }
}
