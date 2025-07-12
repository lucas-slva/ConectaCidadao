using ConectaCidadao.Application.Interfaces;
using ConectaCidadao.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("ConectaCidadaoDb"));
builder.Services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.MapGet("/api/conteudos", async (IAppDbContext context) =>
{
    var conteudos = await context.ConteudosEducacionais.ToListAsync();
    return Results.Ok(conteudos);
})
.WithName("GetConteudosEducacionais")
.WithTags("Conteudo");

app.Run();