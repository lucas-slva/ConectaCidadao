namespace ConectaCidadao.Application.Dtos;

public record ConteudoResponse(
    Guid Id,
    string Titulo,
    string? Descricao,
    string? Categoria,
    string? Link,
    string? Autor,
    string[]? Tags
);

public record CreateConteudoRequest(
    string Titulo,
    string? Descricao,
    string? Categoria,
    string? Link,
    string? Autor,
    string[]? Tags
);

public record UpdateConteudoRequest(
    string Titulo,
    string? Descricao,
    string? Categoria,
    string? Link,
    string? Autor,
    string[]? Tags
);