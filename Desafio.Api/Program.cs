using Desafio.Api.Extensions;
using Desafio.Applicacao;
using Desafio.Infraestrutura;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAplicacao();
builder.Services.AddInfraestrutura(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger at the app root (http://localhost:8080)
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
