using Desafio.Infraestrutura;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }    

        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
            {
                app.UseMiddleware<Middleware.ExceptionHandlingMiddleware>();
            }
        }
}