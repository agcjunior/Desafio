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
    app.UseSwaggerUI();

    app.ApplyMigrations();
    app.SeedData();
}


app.UseHttpsRedirection();

app.UseCustomExceptionHandler();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod());

app.MapControllers();

app.Run();
