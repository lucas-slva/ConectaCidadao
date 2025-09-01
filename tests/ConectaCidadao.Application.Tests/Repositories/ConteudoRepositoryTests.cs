using ConectaCidadao.Domain.Entities;
using ConectaCidadao.Infrastructure.Persistence;
using ConectaCidadao.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace ConectaCidadao.Application.Tests.Repositories;

public class ConteudoRepositoryTests
{
    private static AppDbContext NewDb()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        return new AppDbContext(options);
    }
    
    [Fact]
    public async Task Add_And_GetById_Should_Work()
    {
        await using var db = NewDb();
        var repo = new ConteudoRepository(db);

        var entity = new ConteudoEducacional
        {
            Id = Guid.NewGuid(),
            Titulo = "Introdução à Web",
            Descricao = "Navegação básica",
            Categoria = "Navegação",
            Link = "https://exemplo.org/web",
            Autor = "Equipe",
            Tags = ["básico"]
        };

        await repo.AddAsync(entity);
        var found = await repo.GetByIdAsync(entity.Id);

        found.Should().NotBeNull();
        found!.Titulo.Should().Be("Introdução à Web");
    }

    [Fact]
    public async Task Update_Should_Persist_Changes()
    {
        await using var db = NewDb();
        var repo = new ConteudoRepository(db);

        var e = new ConteudoEducacional { Id = Guid.NewGuid(), Titulo = "Antigo" };
        await repo.AddAsync(e);

        e.Titulo = "Novo";
        await repo.UpdateAsync(e);

        var again = await repo.GetByIdAsync(e.Id);
        again!.Titulo.Should().Be("Novo");
    }

    [Fact]
    public async Task Delete_Should_Remove()
    {
        await using var db = NewDb();
        var repo = new ConteudoRepository(db);

        var e = new ConteudoEducacional { Id = Guid.NewGuid(), Titulo = "Remover" };
        await repo.AddAsync(e);

        await repo.DeleteAsync(e.Id);

        var gone = await repo.GetByIdAsync(e.Id);
        gone.Should().BeNull();
    }

    [Fact]
    public async Task List_Should_Return_All()
    {
        await using var db = NewDb();
        var repo = new ConteudoRepository(db);

        await repo.AddAsync(new ConteudoEducacional { Id = Guid.NewGuid(), Titulo = "A" });
        await repo.AddAsync(new ConteudoEducacional { Id = Guid.NewGuid(), Titulo = "B" });

        var all = await repo.ListAsync();
        all.Should().HaveCount(2);
    }
}