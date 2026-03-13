using Desafio.Aplicacao.Exceptions;
using Microsoft.AspNetCore.Mvc;


namespace Desafio.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
               var exceptionDetails = GetExceptionDetails(ex);
               var problemDetais = new ProblemDetails
               {
                   Status = exceptionDetails.Status,
                   Type = exceptionDetails.Type,
                   Title = exceptionDetails.Title,
                   Detail = exceptionDetails.Detail,
               };
                if (problemDetais != null)
                {
                    problemDetais.Extensions["errors"] = exceptionDetails.Errors;
                }
                context.Response.StatusCode = exceptionDetails.Status;
                await context.Response.WriteAsJsonAsync(problemDetais);
            }
        }

        private static ExceptionDetails GetExceptionDetails(Exception ex)
        {
            return ex switch
            {
                ValidationException validationException => new ExceptionDetails(
                    StatusCodes.Status400BadRequest,
                    "FalhaValidação",
                    "Erro de validação",
                    "Um ou mais erros de validação ocorreram.",
                    validationException.Errors),
                    _ => new ExceptionDetails(
                        StatusCodes.Status500InternalServerError,
                        "ErroInternoServidor",
                        "Erro interno do servidor",
                        "Ocorreu um erro inesperado no servidor.",
                        null
                        )                
            };
        }
    }

    internal record ExceptionDetails
    (
        int Status,
        string Type,
        string Title,
        string Detail,
        IEnumerable<object>? Errors
    );
}
