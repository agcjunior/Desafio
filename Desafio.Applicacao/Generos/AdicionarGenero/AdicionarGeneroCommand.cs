using Desafio.Aplicacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Aplicacao.Generos.AdicionarGenero
{
    public record AdicionarGeneroCommand(string nome) : ICommand<Guid>
    {
    }
}
