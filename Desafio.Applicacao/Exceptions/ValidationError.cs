using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio.Aplicacao.Exceptions
{
    public sealed record ValidationError(string PropertyName, string ErrorMessage);
    
}
