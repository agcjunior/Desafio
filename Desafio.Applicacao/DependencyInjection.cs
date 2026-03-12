using Desafio.Aplicacao.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Applicacao
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplicacao(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
                // inserir LoggingBehavior
                configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
