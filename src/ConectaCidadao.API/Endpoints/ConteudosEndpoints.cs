using ConectaCidadao.Application.Dtos;
using ConectaCidadao.Application.Interfaces;
using ConectaCidadao.Domain.Entities;
using FluentValidation;

namespace ConectaCidadao.API.Endpoints;

public static class ConteudosEndpoints
{
    public static IEndpointRouteBuilder MapConteudos(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/conteudos").WithTags("Conteúdos");

        // LISTAR
        group.MapGet("/", async (IConteudoRepository repo, CancellationToken ct) =>
        {
            var list = await repo.ListAsync(ct);
            return Results.Ok(list.Select(ToResponse));
        });

        // GET por ID
        group.MapGet("/{id:guid}", async (Guid id, IConteudoRepository repo, CancellationToken ct) =>
        {
            var e = await repo.GetByIdAsync(id, ct);
            return e is null ? Results.NotFound() : Results.Ok(ToResponse(e));
        });

        // CRIAR
        group.MapPost("/", async (
            CreateConteudoRequest req,
            IValidator<CreateConteudoRequest> validator,
            IConteudoRepository repo,
            CancellationToken ct) =>
        {
            var vr = await validator.ValidateAsync(req, ct);
            if (!vr.IsValid) return Results.ValidationProblem(vr.ToDictionary());

            var entity = new ConteudoEducacional
            {
                Id = Guid.NewGuid(),
                Titulo = req.Titulo,
                Descricao = req.Descricao,
                Categoria = req.Categoria,
                Link = req.Link,
                Autor = req.Autor,
                Tags = req.Tags?.ToList() ?? new()
            };

            var created = await repo.AddAsync(entity, ct);
            return Results.Created($"/api/conteudos/{created.Id}", ToResponse(created));
        });

        // ATUALIZAR
        group.MapPut("/{id:guid}", async (
            Guid id,
            UpdateConteudoRequest req,
            IValidator<UpdateConteudoRequest> validator,
            IConteudoRepository repo,
            CancellationToken ct) =>
        {
            var vr = await validator.ValidateAsync(req, ct);
            if (!vr.IsValid) return Results.ValidationProblem(vr.ToDictionary());

            var e = await repo.GetByIdAsync(id, ct);
            if (e is null) return Results.NotFound();

            e.Titulo = req.Titulo;
            e.Descricao = req.Descricao;
            e.Categoria = req.Categoria;
            e.Link = req.Link;
            e.Autor = req.Autor;
            e.Tags = req.Tags?.ToList() ?? new();
            e.UpdatedAt = DateTimeOffset.UtcNow;

            await repo.UpdateAsync(e, ct);
            return Results.NoContent();
        });

        // DELETAR
        group.MapDelete("/{id:guid}", async (Guid id, IConteudoRepository repo, CancellationToken ct) =>
        {
            var exists = await repo.GetByIdAsync(id, ct);
            if (exists is null) return Results.NotFound();
            await repo.DeleteAsync(id, ct);
            return Results.NoContent();
        });

        return group;
    }
    
    private static ConteudoResponse ToResponse(ConteudoEducacional e) => new(e.Id, e.Titulo, e.Descricao, e.Categoria, e.Link, e.Autor, e.Tags?.ToArray());

    private static IDictionary<string, string[]> ToDictionary(this FluentValidation.Results.ValidationResult vr) =>
        vr.Errors.GroupBy(e => e.PropertyName)
            .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray());
}