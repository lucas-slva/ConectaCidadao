using ConectaCidadao.API.Endpoints;
using ConectaCidadao.Application.Interfaces;
using ConectaCidadao.Application.Validators;
using ConectaCidadao.Infrastructure.Persistence;
using ConectaCidadao.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// EF + DI
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ConectaCidadaoDb"));
builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

// Validators
builder.Services.AddValidatorsFromAssemblyContaining<CreateConteudoRequestValidator>();

// Repository
builder.Services.AddScoped<IConteudoRepository, ConteudoRepository>();

// OpenAPI JSON
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // expõe o JSON
    app.MapOpenApi(); // GET /openapi/v1.json

    // UI do Swagger consumindo o JSON do OpenAPI
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/openapi/v1.json", "ConectaCidadao v1");
        c.RoutePrefix = "swagger"; // UI em /swagger
    });
}

// crud
app.MapConteudos();

app.Run();