namespace ConectaCidadao.Domain.Entities;

public class ConteudoEducacional
{
    public Guid Id { get; set; }
    public string Titulo { get; set; } = default!;
    public string? Descricao { get; set; }
    public string? Categoria { get; set; }
    public string? Link { get; set; }
    public string? Autor { get; set; }
    public List<string> Tags { get; set; } = new();

    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? UpdatedAt { get; set; }
}