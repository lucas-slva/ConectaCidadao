using ConectaCidadao.Domain.Entities;
using FluentAssertions;

namespace ConectaCidadao.Domain.Tests.Entities;

public class ConteudoEducacionalTests
{
    [Fact]
    public void New_Entity_Should_Have_Defaults()
    {
        var before = DateTimeOffset.UtcNow.AddMinutes(-1);

        var e = new ConteudoEducacional { Titulo = "Teste" };

        e.Id.Should().Be(Guid.Empty);                 // ainda não persistido
        e.Titulo.Should().Be("Teste");
        e.Tags.Should().NotBeNull().And.BeEmpty();    // lista inicializada
        e.CreatedAt.Should().BeOnOrAfter(before);     // criado “agora”
        e.UpdatedAt.Should().BeNull();                // sem updates ainda
    }
    
    [Fact]
    public void Update_Should_Change_Fields_And_Set_UpdatedAt()
    {
        var e = new ConteudoEducacional
        {
            Id = Guid.NewGuid(),
            Titulo = "Antigo",
            CreatedAt = DateTimeOffset.UtcNow.AddDays(-1)
        };

        e.Titulo = "Novo";
        e.Descricao = "Desc";
        e.Categoria = "Cat";
        e.Link = "https://exemplo.org";
        e.Autor = "Autor";
        e.Tags.Add("a");
        e.UpdatedAt = DateTimeOffset.UtcNow;

        e.Titulo.Should().Be("Novo");
        e.Descricao.Should().Be("Desc");
        e.Categoria.Should().Be("Cat");
        e.Link.Should().Be("https://exemplo.org");
        e.Autor.Should().Be("Autor");
        e.Tags.Should().ContainSingle("a");
        e.UpdatedAt.Should().NotBeNull();
        e.UpdatedAt!.Value.Should().BeOnOrAfter(e.CreatedAt);
    }
}