using Desafio.Aplicacao.Interfaces;
using Desafio.Comum;
using Desafio.Dominio.Autores;
using Desafio.Dominio.Generos;
using Desafio.Dominio.Livros;
using Desafio.Infraestrutura.Data;
using Desafio.Infraestrutura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.Infraestrutura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestrutura(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            var connectionString = 
                configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IAutorRepositorio, AutorRepositorio>();
            services.AddScoped<IGeneroRepositorio, GeneroRepositorio>();
            services.AddScoped<ILivroRepositorio, LivroRepositorio>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ => 
                new SqlConnectionFactory(connectionString));

            return services;
        }

    }
}
