using ConectaCidadao.Application.Dtos;
using ConectaCidadao.Application.Validators;
using FluentAssertions;

namespace ConectaCidadao.Application.Tests.Validators;

public class ConteudoValidatorsTests
{
    [Fact]
    public async Task Create_Should_Pass_When_Valid()
    {
        var validator = new CreateConteudoRequestValidator();
        var req = new CreateConteudoRequest(
            Titulo: "Guia de Segurança Digital",
            Descricao: "Boas práticas",
            Categoria: "Segurança",
            Link: "https://exemplo.org/guia",
            Autor: "Equipe",
            Tags: ["segurança", "senhas"]
        );

        var result = await validator.ValidateAsync(req);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }
    
    [Fact]
    public async Task Create_Should_Fail_When_Title_Empty_Url_Invalid_And_Tags_Repeated()
    {
        var validator = new CreateConteudoRequestValidator();
        var req = new CreateConteudoRequest(
            Titulo: "",
            Descricao: null,
            Categoria: null,
            Link: "not-a-url",
            Autor: null,
            Tags: ["abc", "ABC"] // repetidas (case-insensitive)
        );

        var result = await validator.ValidateAsync(req);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Titulo");
        result.Errors.Should().Contain(e => e.PropertyName == "Link");
        result.Errors.Should().Contain(e => e.PropertyName == "Tags");
    }
    
    [Fact]
    public async Task Update_Should_Fail_When_Title_Empty()
    {
        var validator = new UpdateConteudoRequestValidator();
        var req = new UpdateConteudoRequest(
            Titulo: "",
            Descricao: null,
            Categoria: null,
            Link: null,
            Autor: null,
            Tags: null
        );

        var result = await validator.ValidateAsync(req);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == "Titulo");
    }
}